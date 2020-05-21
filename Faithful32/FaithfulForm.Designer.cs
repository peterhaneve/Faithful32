namespace Faithful32 {
	partial class FaithfulForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaithfulForm));
			this.lblMod = new System.Windows.Forms.Label();
			this.lblPack = new System.Windows.Forms.Label();
			this.packFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.colorizeDialog = new System.Windows.Forms.ColorDialog();
			this.modFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.btnMod = new System.Windows.Forms.Button();
			this.btnPack = new System.Windows.Forms.Button();
			this.tabPane = new System.Windows.Forms.TabControl();
			this.pageRecolor = new System.Windows.Forms.TabPage();
			this.tvRecolorSource = new Faithful32.PackTreeView();
			this.pbRecolorOutput = new Faithful32.PictureBoxNN();
			this.gbRecolorParams = new System.Windows.Forms.GroupBox();
			this.btnWriteRecolor = new System.Windows.Forms.Button();
			this.cbRecolor = new System.Windows.Forms.CheckBox();
			this.pbRecolorInput = new Faithful32.PictureBoxNN();
			this.btnDefaults = new System.Windows.Forms.Button();
			this.btnPick = new System.Windows.Forms.Button();
			this.txtContrast = new System.Windows.Forms.NumericUpDown();
			this.txtBright = new System.Windows.Forms.NumericUpDown();
			this.txtLight = new System.Windows.Forms.NumericUpDown();
			this.txtSat = new System.Windows.Forms.NumericUpDown();
			this.txtHue = new System.Windows.Forms.NumericUpDown();
			this.lblContrast = new System.Windows.Forms.Label();
			this.lblBright = new System.Windows.Forms.Label();
			this.lblLightness = new System.Windows.Forms.Label();
			this.lblSat = new System.Windows.Forms.Label();
			this.lblHue = new System.Windows.Forms.Label();
			this.pageGUI = new System.Windows.Forms.TabPage();
			this.cbRescaleType = new System.Windows.Forms.ComboBox();
			this.cbAutoGui = new System.Windows.Forms.CheckBox();
			this.btnExtract = new System.Windows.Forms.Button();
			this.btnWriteGui = new System.Windows.Forms.Button();
			this.pbGuiOutput = new Faithful32.PictureBoxNN();
			this.tvPack = new Faithful32.PackTreeView();
			this.tvMod = new Faithful32.PackTreeView();
			this.tabPane.SuspendLayout();
			this.pageRecolor.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbRecolorOutput)).BeginInit();
			this.gbRecolorParams.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbRecolorInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtContrast)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtBright)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSat)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtHue)).BeginInit();
			this.pageGUI.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbGuiOutput)).BeginInit();
			this.SuspendLayout();
			// 
			// lblMod
			// 
			this.lblMod.Location = new System.Drawing.Point(12, 17);
			this.lblMod.Name = "lblMod";
			this.lblMod.Size = new System.Drawing.Size(144, 13);
			this.lblMod.TabIndex = 0;
			this.lblMod.Text = "None";
			// 
			// lblPack
			// 
			this.lblPack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPack.Location = new System.Drawing.Point(796, 17);
			this.lblPack.Name = "lblPack";
			this.lblPack.Size = new System.Drawing.Size(144, 13);
			this.lblPack.TabIndex = 2;
			this.lblPack.Text = "None";
			// 
			// colorizeDialog
			// 
			this.colorizeDialog.AnyColor = true;
			this.colorizeDialog.SolidColorOnly = true;
			// 
			// modFileDialog
			// 
			this.modFileDialog.DefaultExt = "jar";
			this.modFileDialog.Filter = "JAR files|*.jar|ZIP files|*.zip|All files|*.*";
			// 
			// btnMod
			// 
			this.btnMod.Location = new System.Drawing.Point(162, 12);
			this.btnMod.Name = "btnMod";
			this.btnMod.Size = new System.Drawing.Size(50, 23);
			this.btnMod.TabIndex = 1;
			this.btnMod.Text = "&Mod...";
			this.btnMod.UseVisualStyleBackColor = true;
			this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
			// 
			// btnPack
			// 
			this.btnPack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPack.Location = new System.Drawing.Point(946, 12);
			this.btnPack.Name = "btnPack";
			this.btnPack.Size = new System.Drawing.Size(50, 23);
			this.btnPack.TabIndex = 3;
			this.btnPack.Text = "Pac&k...";
			this.btnPack.UseVisualStyleBackColor = true;
			this.btnPack.Click += new System.EventHandler(this.btnPack_Click);
			// 
			// tabPane
			// 
			this.tabPane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabPane.Controls.Add(this.pageRecolor);
			this.tabPane.Controls.Add(this.pageGUI);
			this.tabPane.Location = new System.Drawing.Point(218, 12);
			this.tabPane.Name = "tabPane";
			this.tabPane.SelectedIndex = 0;
			this.tabPane.Size = new System.Drawing.Size(572, 537);
			this.tabPane.TabIndex = 6;
			// 
			// pageRecolor
			// 
			this.pageRecolor.Controls.Add(this.tvRecolorSource);
			this.pageRecolor.Controls.Add(this.pbRecolorOutput);
			this.pageRecolor.Controls.Add(this.gbRecolorParams);
			this.pageRecolor.Location = new System.Drawing.Point(4, 22);
			this.pageRecolor.Name = "pageRecolor";
			this.pageRecolor.Padding = new System.Windows.Forms.Padding(3);
			this.pageRecolor.Size = new System.Drawing.Size(564, 511);
			this.pageRecolor.TabIndex = 0;
			this.pageRecolor.Text = "Recolor Texture";
			this.pageRecolor.UseVisualStyleBackColor = true;
			// 
			// tvRecolorSource
			// 
			this.tvRecolorSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tvRecolorSource.FullRowSelect = true;
			this.tvRecolorSource.HideSelection = false;
			this.tvRecolorSource.ImageIndex = 0;
			this.tvRecolorSource.Location = new System.Drawing.Point(6, 7);
			this.tvRecolorSource.Name = "tvRecolorSource";
			this.tvRecolorSource.PathSeparator = "/";
			this.tvRecolorSource.SelectedImageIndex = 0;
			this.tvRecolorSource.ShowNodeToolTips = true;
			this.tvRecolorSource.Size = new System.Drawing.Size(200, 498);
			this.tvRecolorSource.TabIndex = 7;
			this.tvRecolorSource.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRecolorSource_AfterSelect);
			// 
			// pbRecolorOutput
			// 
			this.pbRecolorOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbRecolorOutput.BackColor = System.Drawing.Color.LightGray;
			this.pbRecolorOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbRecolorOutput.Location = new System.Drawing.Point(228, 7);
			this.pbRecolorOutput.Name = "pbRecolorOutput";
			this.pbRecolorOutput.Size = new System.Drawing.Size(319, 311);
			this.pbRecolorOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbRecolorOutput.SourceImage = null;
			this.pbRecolorOutput.TabIndex = 8;
			this.pbRecolorOutput.TabStop = false;
			// 
			// gbRecolorParams
			// 
			this.gbRecolorParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbRecolorParams.Controls.Add(this.btnWriteRecolor);
			this.gbRecolorParams.Controls.Add(this.cbRecolor);
			this.gbRecolorParams.Controls.Add(this.pbRecolorInput);
			this.gbRecolorParams.Controls.Add(this.btnDefaults);
			this.gbRecolorParams.Controls.Add(this.btnPick);
			this.gbRecolorParams.Controls.Add(this.txtContrast);
			this.gbRecolorParams.Controls.Add(this.txtBright);
			this.gbRecolorParams.Controls.Add(this.txtLight);
			this.gbRecolorParams.Controls.Add(this.txtSat);
			this.gbRecolorParams.Controls.Add(this.txtHue);
			this.gbRecolorParams.Controls.Add(this.lblContrast);
			this.gbRecolorParams.Controls.Add(this.lblBright);
			this.gbRecolorParams.Controls.Add(this.lblLightness);
			this.gbRecolorParams.Controls.Add(this.lblSat);
			this.gbRecolorParams.Controls.Add(this.lblHue);
			this.gbRecolorParams.Location = new System.Drawing.Point(212, 324);
			this.gbRecolorParams.Name = "gbRecolorParams";
			this.gbRecolorParams.Size = new System.Drawing.Size(346, 181);
			this.gbRecolorParams.TabIndex = 7;
			this.gbRecolorParams.TabStop = false;
			this.gbRecolorParams.Text = "Recolor";
			// 
			// btnWriteRecolor
			// 
			this.btnWriteRecolor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnWriteRecolor.Location = new System.Drawing.Point(265, 70);
			this.btnWriteRecolor.Name = "btnWriteRecolor";
			this.btnWriteRecolor.Size = new System.Drawing.Size(75, 23);
			this.btnWriteRecolor.TabIndex = 22;
			this.btnWriteRecolor.Text = "&Write";
			this.btnWriteRecolor.UseVisualStyleBackColor = true;
			this.btnWriteRecolor.Click += new System.EventHandler(this.btnWriteRecolor_Click);
			// 
			// cbRecolor
			// 
			this.cbRecolor.AutoSize = true;
			this.cbRecolor.Checked = true;
			this.cbRecolor.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbRecolor.Location = new System.Drawing.Point(7, 157);
			this.cbRecolor.Name = "cbRecolor";
			this.cbRecolor.Size = new System.Drawing.Size(69, 17);
			this.cbRecolor.TabIndex = 19;
			this.cbRecolor.Text = "&Recolor?";
			this.cbRecolor.UseVisualStyleBackColor = true;
			this.cbRecolor.CheckedChanged += new System.EventHandler(this.ColorValueChanged);
			// 
			// pbRecolorInput
			// 
			this.pbRecolorInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pbRecolorInput.BackColor = System.Drawing.Color.LightGray;
			this.pbRecolorInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbRecolorInput.Cursor = System.Windows.Forms.Cursors.Cross;
			this.pbRecolorInput.Location = new System.Drawing.Point(276, 111);
			this.pbRecolorInput.Name = "pbRecolorInput";
			this.pbRecolorInput.Size = new System.Drawing.Size(64, 64);
			this.pbRecolorInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbRecolorInput.SourceImage = null;
			this.pbRecolorInput.TabIndex = 21;
			this.pbRecolorInput.TabStop = false;
			this.pbRecolorInput.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbInput_MouseClick);
			// 
			// btnDefaults
			// 
			this.btnDefaults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDefaults.Location = new System.Drawing.Point(265, 44);
			this.btnDefaults.Name = "btnDefaults";
			this.btnDefaults.Size = new System.Drawing.Size(75, 23);
			this.btnDefaults.TabIndex = 21;
			this.btnDefaults.Text = "&Defaults";
			this.btnDefaults.UseVisualStyleBackColor = true;
			this.btnDefaults.Click += new System.EventHandler(this.btnDefaults_Click);
			// 
			// btnPick
			// 
			this.btnPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPick.Location = new System.Drawing.Point(265, 18);
			this.btnPick.Name = "btnPick";
			this.btnPick.Size = new System.Drawing.Size(75, 23);
			this.btnPick.TabIndex = 20;
			this.btnPick.Text = "&Pick Color";
			this.btnPick.UseVisualStyleBackColor = true;
			this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
			// 
			// txtContrast
			// 
			this.txtContrast.Location = new System.Drawing.Point(75, 125);
			this.txtContrast.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
			this.txtContrast.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
			this.txtContrast.Name = "txtContrast";
			this.txtContrast.Size = new System.Drawing.Size(60, 20);
			this.txtContrast.TabIndex = 18;
			this.txtContrast.ValueChanged += new System.EventHandler(this.ColorValueChanged);
			// 
			// txtBright
			// 
			this.txtBright.Location = new System.Drawing.Point(75, 99);
			this.txtBright.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
			this.txtBright.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
			this.txtBright.Name = "txtBright";
			this.txtBright.Size = new System.Drawing.Size(60, 20);
			this.txtBright.TabIndex = 16;
			this.txtBright.ValueChanged += new System.EventHandler(this.ColorValueChanged);
			// 
			// txtLight
			// 
			this.txtLight.DecimalPlaces = 3;
			this.txtLight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.txtLight.Location = new System.Drawing.Point(75, 73);
			this.txtLight.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.txtLight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.txtLight.Name = "txtLight";
			this.txtLight.Size = new System.Drawing.Size(60, 20);
			this.txtLight.TabIndex = 14;
			this.txtLight.ValueChanged += new System.EventHandler(this.ColorValueChanged);
			// 
			// txtSat
			// 
			this.txtSat.DecimalPlaces = 3;
			this.txtSat.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.txtSat.Location = new System.Drawing.Point(75, 47);
			this.txtSat.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.txtSat.Name = "txtSat";
			this.txtSat.Size = new System.Drawing.Size(60, 20);
			this.txtSat.TabIndex = 12;
			this.txtSat.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.txtSat.ValueChanged += new System.EventHandler(this.ColorValueChanged);
			// 
			// txtHue
			// 
			this.txtHue.DecimalPlaces = 3;
			this.txtHue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.txtHue.Location = new System.Drawing.Point(75, 21);
			this.txtHue.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.txtHue.Name = "txtHue";
			this.txtHue.Size = new System.Drawing.Size(60, 20);
			this.txtHue.TabIndex = 10;
			this.txtHue.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.txtHue.ValueChanged += new System.EventHandler(this.ColorValueChanged);
			// 
			// lblContrast
			// 
			this.lblContrast.AutoSize = true;
			this.lblContrast.Location = new System.Drawing.Point(23, 127);
			this.lblContrast.Name = "lblContrast";
			this.lblContrast.Size = new System.Drawing.Size(46, 13);
			this.lblContrast.TabIndex = 17;
			this.lblContrast.Text = "C&ontrast";
			// 
			// lblBright
			// 
			this.lblBright.AutoSize = true;
			this.lblBright.Location = new System.Drawing.Point(13, 101);
			this.lblBright.Name = "lblBright";
			this.lblBright.Size = new System.Drawing.Size(56, 13);
			this.lblBright.TabIndex = 15;
			this.lblBright.Text = "&Brightness";
			// 
			// lblLightness
			// 
			this.lblLightness.AutoSize = true;
			this.lblLightness.Location = new System.Drawing.Point(17, 75);
			this.lblLightness.Name = "lblLightness";
			this.lblLightness.Size = new System.Drawing.Size(52, 13);
			this.lblLightness.TabIndex = 13;
			this.lblLightness.Text = "&Lightness";
			// 
			// lblSat
			// 
			this.lblSat.AutoSize = true;
			this.lblSat.Location = new System.Drawing.Point(14, 49);
			this.lblSat.Name = "lblSat";
			this.lblSat.Size = new System.Drawing.Size(55, 13);
			this.lblSat.TabIndex = 11;
			this.lblSat.Text = "&Saturation";
			// 
			// lblHue
			// 
			this.lblHue.AutoSize = true;
			this.lblHue.Location = new System.Drawing.Point(42, 23);
			this.lblHue.Name = "lblHue";
			this.lblHue.Size = new System.Drawing.Size(27, 13);
			this.lblHue.TabIndex = 9;
			this.lblHue.Text = "&Hue";
			// 
			// pageGUI
			// 
			this.pageGUI.Controls.Add(this.cbRescaleType);
			this.pageGUI.Controls.Add(this.cbAutoGui);
			this.pageGUI.Controls.Add(this.btnExtract);
			this.pageGUI.Controls.Add(this.btnWriteGui);
			this.pageGUI.Controls.Add(this.pbGuiOutput);
			this.pageGUI.Location = new System.Drawing.Point(4, 22);
			this.pageGUI.Name = "pageGUI";
			this.pageGUI.Padding = new System.Windows.Forms.Padding(3);
			this.pageGUI.Size = new System.Drawing.Size(564, 511);
			this.pageGUI.TabIndex = 1;
			this.pageGUI.Text = "GUI Assistant";
			this.pageGUI.UseVisualStyleBackColor = true;
			// 
			// cbRescaleType
			// 
			this.cbRescaleType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cbRescaleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRescaleType.Items.AddRange(new object[] {
            "None",
            "Waifu2X"});
			this.cbRescaleType.Location = new System.Drawing.Point(249, 484);
			this.cbRescaleType.Name = "cbRescaleType";
			this.cbRescaleType.Size = new System.Drawing.Size(84, 21);
			this.cbRescaleType.TabIndex = 13;
			this.cbRescaleType.SelectedIndexChanged += new System.EventHandler(this.GuiValueChanged);
			// 
			// cbAutoGui
			// 
			this.cbAutoGui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cbAutoGui.AutoSize = true;
			this.cbAutoGui.Checked = true;
			this.cbAutoGui.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbAutoGui.Location = new System.Drawing.Point(339, 486);
			this.cbAutoGui.Name = "cbAutoGui";
			this.cbAutoGui.Size = new System.Drawing.Size(137, 17);
			this.cbAutoGui.TabIndex = 10;
			this.cbAutoGui.Text = "A&uto GUI Slots/Borders";
			this.cbAutoGui.UseVisualStyleBackColor = true;
			this.cbAutoGui.CheckedChanged += new System.EventHandler(this.GuiValueChanged);
			// 
			// btnExtract
			// 
			this.btnExtract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnExtract.Location = new System.Drawing.Point(6, 482);
			this.btnExtract.Name = "btnExtract";
			this.btnExtract.Size = new System.Drawing.Size(75, 23);
			this.btnExtract.TabIndex = 12;
			this.btnExtract.Text = "E&xtract";
			this.btnExtract.UseVisualStyleBackColor = true;
			this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
			// 
			// btnWriteGui
			// 
			this.btnWriteGui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnWriteGui.Location = new System.Drawing.Point(483, 482);
			this.btnWriteGui.Name = "btnWriteGui";
			this.btnWriteGui.Size = new System.Drawing.Size(75, 23);
			this.btnWriteGui.TabIndex = 11;
			this.btnWriteGui.Text = "&Write";
			this.btnWriteGui.UseVisualStyleBackColor = true;
			this.btnWriteGui.Click += new System.EventHandler(this.btnWriteGui_Click);
			// 
			// pbGuiOutput
			// 
			this.pbGuiOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbGuiOutput.BackColor = System.Drawing.Color.LightGray;
			this.pbGuiOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbGuiOutput.Location = new System.Drawing.Point(6, 7);
			this.pbGuiOutput.Name = "pbGuiOutput";
			this.pbGuiOutput.Size = new System.Drawing.Size(552, 469);
			this.pbGuiOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbGuiOutput.SourceImage = null;
			this.pbGuiOutput.TabIndex = 9;
			this.pbGuiOutput.TabStop = false;
			// 
			// tvPack
			// 
			this.tvPack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tvPack.FullRowSelect = true;
			this.tvPack.HideSelection = false;
			this.tvPack.ImageIndex = 0;
			this.tvPack.Location = new System.Drawing.Point(796, 41);
			this.tvPack.Name = "tvPack";
			this.tvPack.PathSeparator = "/";
			this.tvPack.SelectedImageIndex = 0;
			this.tvPack.ShowNodeToolTips = true;
			this.tvPack.Size = new System.Drawing.Size(200, 508);
			this.tvPack.TabIndex = 5;
			// 
			// tvMod
			// 
			this.tvMod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tvMod.FullRowSelect = true;
			this.tvMod.HideSelection = false;
			this.tvMod.ImageIndex = 0;
			this.tvMod.Location = new System.Drawing.Point(12, 41);
			this.tvMod.Name = "tvMod";
			this.tvMod.PathSeparator = "/";
			this.tvMod.SelectedImageIndex = 0;
			this.tvMod.ShowNodeToolTips = true;
			this.tvMod.Size = new System.Drawing.Size(200, 508);
			this.tvMod.TabIndex = 4;
			this.tvMod.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMod_AfterSelect);
			// 
			// FaithfulForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 561);
			this.Controls.Add(this.tvPack);
			this.Controls.Add(this.tvMod);
			this.Controls.Add(this.tabPane);
			this.Controls.Add(this.btnPack);
			this.Controls.Add(this.btnMod);
			this.Controls.Add(this.lblPack);
			this.Controls.Add(this.lblMod);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(898, 394);
			this.Name = "FaithfulForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Faithful 32 Texture Designer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FaithfulForm_FormClosing);
			this.tabPane.ResumeLayout(false);
			this.pageRecolor.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbRecolorOutput)).EndInit();
			this.gbRecolorParams.ResumeLayout(false);
			this.gbRecolorParams.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbRecolorInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtContrast)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtBright)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSat)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtHue)).EndInit();
			this.pageGUI.ResumeLayout(false);
			this.pageGUI.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbGuiOutput)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label lblMod;
		private System.Windows.Forms.Label lblPack;
		private System.Windows.Forms.FolderBrowserDialog packFolderDialog;
		private System.Windows.Forms.ColorDialog colorizeDialog;
		private System.Windows.Forms.OpenFileDialog modFileDialog;
		private System.Windows.Forms.Button btnMod;
		private System.Windows.Forms.Button btnPack;
		private System.Windows.Forms.TabControl tabPane;
		private System.Windows.Forms.TabPage pageRecolor;
		private System.Windows.Forms.TabPage pageGUI;
		private System.Windows.Forms.GroupBox gbRecolorParams;
		private System.Windows.Forms.Label lblLightness;
		private System.Windows.Forms.Label lblSat;
		private System.Windows.Forms.Label lblHue;
		private System.Windows.Forms.NumericUpDown txtLight;
		private System.Windows.Forms.NumericUpDown txtSat;
		private System.Windows.Forms.NumericUpDown txtHue;
		private System.Windows.Forms.NumericUpDown txtContrast;
		private System.Windows.Forms.NumericUpDown txtBright;
		private System.Windows.Forms.Label lblContrast;
		private System.Windows.Forms.Label lblBright;
		private System.Windows.Forms.Button btnPick;
		private PictureBoxNN pbRecolorOutput;
		private PictureBoxNN pbRecolorInput;
		private System.Windows.Forms.Button btnDefaults;
		private System.Windows.Forms.CheckBox cbRecolor;
		private System.Windows.Forms.Button btnWriteRecolor;
		private PackTreeView tvMod;
		private PackTreeView tvPack;
		private PackTreeView tvRecolorSource;
		private System.Windows.Forms.CheckBox cbAutoGui;
		private System.Windows.Forms.Button btnWriteGui;
		private PictureBoxNN pbGuiOutput;
		private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.ComboBox cbRescaleType;
    }
}

