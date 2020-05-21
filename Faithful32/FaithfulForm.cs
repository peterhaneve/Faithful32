using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faithful32 {
	public partial class FaithfulForm : Form {
		private TexturePack mod;
		private TexturePack pack;

		private static bool Confirm(string message) {
			return MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning) == DialogResult.Yes;
		}

		private static void Error(string message) {
			MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public FaithfulForm() {
			mod = null;
			pack = null;
			InitializeComponent();
			cbRescaleType.SelectedIndex = 0;
		}

		private void BeginInvoke(Action cmd) {
			base.BeginInvoke(cmd);
		}

		private void Colorize() {
			var tag = tvRecolorSource.SelectedTexture;
			if (tag != null) {
				var colorizer = new ImageColorizer(tag.ImageData);
				if (cbRecolor.Checked)
					colorizer.Colorize(txtHue.Value.RoundToFloat(), txtSat.Value.RoundToFloat(),
						txtLight.Value.RoundToFloat());
				colorizer.BrightnessContrast(txtBright.Value.RoundToInt(), txtContrast.Value.
					RoundToInt());
				SetRecolorImage(colorizer.Result);
			}
		}

		private void DisposeMod() {
			if (mod != null) {
				tvMod.SetPack(null);
				SetInputImage(null);
				mod.Dispose();
				mod = null;
			}
		}

		private void DisposePack() {
			if (pack != null) {
				tvPack.SetPack(null);
				tvRecolorSource.SetPack(null);
				SetGuiImage(null);
				SetRecolorImage(null);
				pack.Dispose();
				pack = null;
			}
		}

		private void GuiRescale() {
			var src = tvMod.SelectedTexture;
			if (src != null) {
				Bitmap bitmap = null;
				// This allocates a bitmap
				if (cbRescaleType.SelectedIndex == 1)
					try {
						bitmap = new Waifu2XImageRescaler().Rescale(src.ImageData);
					} catch (IOException e) {
						Error("Unable to start Waifu2X: " + e.Message);
					} catch (System.ComponentModel.Win32Exception e) {
						Error("Unable to start Waifu2X: " + e.Message);
					}
				if (bitmap == null)
					bitmap = new DefaultImageRescaler().Rescale(src.ImageData);
				var rescaler = new GuiImageReplacer(bitmap);
				if (cbAutoGui.Checked)
					rescaler.GuiReplace();
				// Result is the same as the bitmap, do not destroy bitmap
				SetGuiImage(rescaler.Result);
			}
		}

		private void LoadMod(string path) {
			string modName = "None";
			BasicTreeNode<TextureEntry> tree = null;
			try {
				using (var file = ZipFile.OpenRead(path)) {
					mod = ImageLoader.GetModTextures(path, file);
				}
				modName = Path.GetFileName(path);
				tree = mod.AsTree();
			} catch (IOException e) {
				Error("Unable to load mod \"" + Path.GetFileName(path) + "\": " + e.Message);
			}
			BeginInvoke(() => {
				lblMod.Text = modName;
				btnMod.Enabled = true;
				tvMod.SetPack(tree);
			});
		}

		private void LoadPack(string path) {
			string assetsDir = Path.Combine(Path.GetFullPath(path), TextureEntry.ASSETS);
			string packName = "None";
			BasicTreeNode<TextureEntry> tree = null;
			if (!Directory.Exists(assetsDir))
				Error("Invalid pack directory, must have assets folder");
			else
				try {
					pack = ImageLoader.GetPackTextures(path, Directory.GetFiles(assetsDir,
						"*." + ImageLoader.TEXTURE_EXT, SearchOption.AllDirectories));
					packName = Path.GetFileName(path);
					tree = pack.AsTree();
				} catch (IOException e) {
					Error("Unable to load pack: " + e.Message);
				}
			BeginInvoke(() => {
				lblPack.Text = packName;
				btnPack.Enabled = true;
				tvPack.SetPack(tree);
				tvRecolorSource.SetPack(tree);
			});
		}

		private void PickColor(Color color) {
			float h, s, l;
			ImageColorizer.RGBtoHSL(color.R, color.G, color.B, out h, out s, out l);
			txtHue.Value = h.RoundToDisplay();
			txtSat.Value = s.RoundToDisplay();
			// color is 0 to 1 but lightness is -1 to 1
			txtLight.Value = l.RoundToDisplay() * 2.0m - 1.0m;
		}

		private void SetGuiImage(Bitmap image) {
			pbGuiOutput.DisposeImage();
			pbGuiOutput.SourceImage = image;
		}

		private void SetInputImage(Bitmap image) {
			pbRecolorInput.SourceImage = image;
		}

		private void SetRecolorImage(Bitmap image) {
			pbRecolorOutput.DisposeImage();
			pbRecolorOutput.SourceImage = image;
		}

		private void WriteImage(Image img, string aniData = null) {
			var modTex = tvMod.SelectedTexture;
			if (modTex != null && pack != null && img != null) {
				// fullpath is relative for the mod
				string relPath = modTex.FullPath, newPath = pack.FindPathToImage(relPath);
				if (!File.Exists(newPath) || Confirm("Overwrite " + relPath + "?"))
					try {
						Directory.CreateDirectory(Path.GetDirectoryName(newPath));
						img.Save(newPath, ImageFormat.Png);
						// compatibility fix, set archive attribute to false
						var info = new FileInfo(newPath);
						info.Attributes &= ~FileAttributes.Archive;
						if (!string.IsNullOrWhiteSpace(aniData))
							File.WriteAllText(newPath + "." + ImageLoader.ANI_EXT, aniData);
					} catch (IOException ex) {
						Error("Error when writing file \"" + relPath + "\": " + ex.Message);
					}
			}
		}

		#region Events
		private void btnMod_Click(object sender, EventArgs e) {
			if (modFileDialog.ShowDialog(this) == DialogResult.OK) {
				btnMod.Enabled = false;
				DisposeMod();
				Task.Run(() => LoadMod(modFileDialog.FileName));
			}
		}

		private void btnPack_Click(object sender, EventArgs e) {
			if (packFolderDialog.ShowDialog(this) == DialogResult.OK) {
				btnPack.Enabled = false;
				DisposePack();
				Task.Run(() => LoadPack(packFolderDialog.SelectedPath));
			}
		}

		private void FaithfulForm_FormClosing(object sender, FormClosingEventArgs e) {
			SetInputImage(null);
			SetGuiImage(null);
			SetRecolorImage(null);
			if (mod != null)
				mod.Dispose();
			if (pack != null)
				pack.Dispose();
		}

		private void tvMod_AfterSelect(object sender, TreeViewEventArgs e) {
			var tag = tvMod.GetEntry(e.Node);
			if (tag != null) {
				tvPack.FindEntry(tag);
				SetInputImage(tag.ImageData);
				GuiRescale();
			}
		}

		private void ColorValueChanged(object sender, EventArgs e) {
			Colorize();
		}

		private void GuiValueChanged(object sender, EventArgs e) {
			GuiRescale();
		}

		private void btnDefaults_Click(object sender, EventArgs e) {
			txtHue.Value = 0.5m;
			txtSat.Value = 0.5m;
			txtLight.Value = 0.0m;
			txtBright.Value = 0;
			txtContrast.Value = 0;
		}

		private void btnPick_Click(object sender, EventArgs e) {
			if (colorizeDialog.ShowDialog(this) == DialogResult.OK)
				PickColor(colorizeDialog.Color);
		}
		
		private void pbInput_MouseClick(object sender, MouseEventArgs e) {
			// sourceImage is not what is actually displayed due to animation support
			var src = pbRecolorInput.Image as Bitmap;
			if (src != null) {
				var size = src.Size;
				int w = size.Width, h = size.Height;
				float ratio = Math.Max(w, h) / (float)Math.Min(pbRecolorInput.Width, pbRecolorInput.Height);
				// compensate for zoom
				int ex = (e.X * ratio).RoundToInt(), ey = (e.Y * ratio).RoundToInt();
				PickColor(src.GetPixel(ex.ToRange(0, w - 1), ey.ToRange(0, h - 1)));
			}
		}

		private void tvRecolorSource_AfterSelect(object sender, TreeViewEventArgs e) {
			Colorize();
		}

		private void btnWriteRecolor_Click(object sender, EventArgs e) {
			WriteImage(pbRecolorOutput.SourceImage, tvRecolorSource.SelectedTexture?.AnimationData);
		}

		private void btnWriteGui_Click(object sender, EventArgs e) {
			WriteImage(pbGuiOutput.SourceImage, tvMod.SelectedTexture?.AnimationData);
		}

		private void btnExtract_Click(object sender, EventArgs e) {
			var selected = tvMod.SelectedTexture;
			if (selected != null)
				WriteImage(selected.ImageData, selected.AnimationData);
		}
		#endregion
	}
}
