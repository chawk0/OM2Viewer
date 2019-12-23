namespace OpenMOO2Viewer
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.gameFolderPathLabel = new System.Windows.Forms.Label();
            this.gameFolderPathBrowseButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lbxFileListLabel = new System.Windows.Forms.Label();
            this.lbxFilesListBox = new System.Windows.Forms.ListBox();
            this.lbxFileListRefreshButton = new System.Windows.Forms.Button();
            this.currentLBXFileLabel = new System.Windows.Forms.Label();
            this.prevLBXBlockButton = new System.Windows.Forms.Button();
            this.nextLBXBlockButton = new System.Windows.Forms.Button();
            this.currentLBXBlockLabel = new System.Windows.Forms.Label();
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.currentLBXFileSizeLabel = new System.Windows.Forms.Label();
            this.imageHeaderHeightTextBox = new System.Windows.Forms.TextBox();
            this.imageHeaderFrameCountTextBox = new System.Windows.Forms.TextBox();
            this.imageHeaderWidthTextBox = new System.Windows.Forms.TextBox();
            this.imageHeaderFlagsTextBox = new System.Windows.Forms.TextBox();
            this.imageHeaderFrameDelayTextBox = new System.Windows.Forms.TextBox();
            this.imageHeaderZeroTextBox = new System.Windows.Forms.TextBox();
            this.imageHeaderSizeLabel = new System.Windows.Forms.Label();
            this.imageHeaderFrameCountLabel = new System.Windows.Forms.Label();
            this.imageHeaderFlagsLabel = new System.Windows.Forms.Label();
            this.imageHeaderZeroLabel = new System.Windows.Forms.Label();
            this.imageHeaderFrameDelayLabel = new System.Windows.Forms.Label();
            this.imageHeaderSizeLabelX = new System.Windows.Forms.Label();
            this.imageHeaderFlagsLabelKey = new System.Windows.Forms.Label();
            this.currentImageFrameLabel = new System.Windows.Forms.Label();
            this.nextImageFrameButton = new System.Windows.Forms.Button();
            this.prevImageFrameButton = new System.Windows.Forms.Button();
            this.palettesListBox = new System.Windows.Forms.ListBox();
            this.palettesListLabel = new System.Windows.Forms.Label();
            this.externalPalettePictureBox = new System.Windows.Forms.PictureBox();
            this.internalPalettePictureBox = new System.Windows.Forms.PictureBox();
            this.mixedPalettePictureBox = new System.Windows.Forms.PictureBox();
            this.currentLBXBlockLabel2 = new System.Windows.Forms.Label();
            this.currentImageFrameLabel2 = new System.Windows.Forms.Label();
            this.blockViewTabControl = new System.Windows.Forms.TabControl();
            this.blockViewImageTab = new System.Windows.Forms.TabPage();
            this.currentImageFrameOffsetTextBox = new System.Windows.Forms.TextBox();
            this.currentImageFrameSizeTextBox = new System.Windows.Forms.TextBox();
            this.currentImageFrameOffsetLabel = new System.Windows.Forms.Label();
            this.currentImageFrameSizeLabel = new System.Windows.Forms.Label();
            this.imageZoomFactorLabel = new System.Windows.Forms.Label();
            this.imageZoomTrackBar = new System.Windows.Forms.TrackBar();
            this.internalPaletteLockButton = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fontColorsListTextBox = new System.Windows.Forms.TextBox();
            this.testButton = new System.Windows.Forms.Button();
            this.fontsLabel = new System.Windows.Forms.Label();
            this.fontsListBox = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.externalPalettePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.internalPalettePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixedPalettePictureBox)).BeginInit();
            this.blockViewTabControl.SuspendLayout();
            this.blockViewImageTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageZoomTrackBar)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gameFolderPathTextBox
            // 
            this.gameFolderPathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameFolderPathTextBox.Location = new System.Drawing.Point(27, 48);
            this.gameFolderPathTextBox.Name = "gameFolderPathTextBox";
            this.gameFolderPathTextBox.Size = new System.Drawing.Size(357, 22);
            this.gameFolderPathTextBox.TabIndex = 0;
            this.gameFolderPathTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameFolderPathTextBox_KeyDown);
            // 
            // gameFolderPathLabel
            // 
            this.gameFolderPathLabel.AutoSize = true;
            this.gameFolderPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameFolderPathLabel.Location = new System.Drawing.Point(23, 25);
            this.gameFolderPathLabel.Name = "gameFolderPathLabel";
            this.gameFolderPathLabel.Size = new System.Drawing.Size(199, 20);
            this.gameFolderPathLabel.TabIndex = 1;
            this.gameFolderPathLabel.Text = "Master of Orion 2 directory:";
            // 
            // gameFolderPathBrowseButton
            // 
            this.gameFolderPathBrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gameFolderPathBrowseButton.Location = new System.Drawing.Point(390, 48);
            this.gameFolderPathBrowseButton.Name = "gameFolderPathBrowseButton";
            this.gameFolderPathBrowseButton.Size = new System.Drawing.Size(84, 22);
            this.gameFolderPathBrowseButton.TabIndex = 2;
            this.gameFolderPathBrowseButton.Text = "Browse...";
            this.gameFolderPathBrowseButton.UseVisualStyleBackColor = true;
            this.gameFolderPathBrowseButton.Click += new System.EventHandler(this.gameFolderPathBrowseButton_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Select the Master of Orion 2 game folder:";
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // lbxFileListLabel
            // 
            this.lbxFileListLabel.AutoSize = true;
            this.lbxFileListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxFileListLabel.Location = new System.Drawing.Point(23, 93);
            this.lbxFileListLabel.Name = "lbxFileListLabel";
            this.lbxFileListLabel.Size = new System.Drawing.Size(76, 20);
            this.lbxFileListLabel.TabIndex = 4;
            this.lbxFileListLabel.Text = "LBX files:";
            // 
            // lbxFilesListBox
            // 
            this.lbxFilesListBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxFilesListBox.FormattingEnabled = true;
            this.lbxFilesListBox.ItemHeight = 18;
            this.lbxFilesListBox.Location = new System.Drawing.Point(27, 120);
            this.lbxFilesListBox.Name = "lbxFilesListBox";
            this.lbxFilesListBox.Size = new System.Drawing.Size(154, 688);
            this.lbxFilesListBox.TabIndex = 5;
            this.lbxFilesListBox.DoubleClick += new System.EventHandler(this.lbxFilesListBox_DoubleClick);
            // 
            // lbxFileListRefreshButton
            // 
            this.lbxFileListRefreshButton.Location = new System.Drawing.Point(106, 91);
            this.lbxFileListRefreshButton.Name = "lbxFileListRefreshButton";
            this.lbxFileListRefreshButton.Size = new System.Drawing.Size(75, 23);
            this.lbxFileListRefreshButton.TabIndex = 6;
            this.lbxFileListRefreshButton.Text = "Refresh";
            this.lbxFileListRefreshButton.UseVisualStyleBackColor = true;
            this.lbxFileListRefreshButton.Click += new System.EventHandler(this.lbxFileListRefreshButton_Click);
            // 
            // currentLBXFileLabel
            // 
            this.currentLBXFileLabel.AutoSize = true;
            this.currentLBXFileLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentLBXFileLabel.Location = new System.Drawing.Point(232, 93);
            this.currentLBXFileLabel.Name = "currentLBXFileLabel";
            this.currentLBXFileLabel.Size = new System.Drawing.Size(0, 18);
            this.currentLBXFileLabel.TabIndex = 7;
            // 
            // prevLBXBlockButton
            // 
            this.prevLBXBlockButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevLBXBlockButton.Location = new System.Drawing.Point(443, 97);
            this.prevLBXBlockButton.Name = "prevLBXBlockButton";
            this.prevLBXBlockButton.Size = new System.Drawing.Size(75, 23);
            this.prevLBXBlockButton.TabIndex = 8;
            this.prevLBXBlockButton.Text = "<---";
            this.prevLBXBlockButton.UseVisualStyleBackColor = true;
            this.prevLBXBlockButton.Click += new System.EventHandler(this.prevLBXBlockButton_Click);
            // 
            // nextLBXBlockButton
            // 
            this.nextLBXBlockButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextLBXBlockButton.Location = new System.Drawing.Point(610, 97);
            this.nextLBXBlockButton.Name = "nextLBXBlockButton";
            this.nextLBXBlockButton.Size = new System.Drawing.Size(75, 23);
            this.nextLBXBlockButton.TabIndex = 9;
            this.nextLBXBlockButton.Text = "--->";
            this.nextLBXBlockButton.UseVisualStyleBackColor = true;
            this.nextLBXBlockButton.Click += new System.EventHandler(this.nextLBXBlockButton_Click);
            // 
            // currentLBXBlockLabel
            // 
            this.currentLBXBlockLabel.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentLBXBlockLabel.Location = new System.Drawing.Point(524, 101);
            this.currentLBXBlockLabel.Name = "currentLBXBlockLabel";
            this.currentLBXBlockLabel.Size = new System.Drawing.Size(80, 16);
            this.currentLBXBlockLabel.TabIndex = 10;
            this.currentLBXBlockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePictureBox.Location = new System.Drawing.Point(13, 164);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(642, 482);
            this.imagePictureBox.TabIndex = 12;
            this.imagePictureBox.TabStop = false;
            this.imagePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.imagePictureBox_Paint);
            this.imagePictureBox.DoubleClick += new System.EventHandler(this.imagePictureBox_DoubleClick);
            // 
            // currentLBXFileSizeLabel
            // 
            this.currentLBXFileSizeLabel.AutoSize = true;
            this.currentLBXFileSizeLabel.Location = new System.Drawing.Point(373, 96);
            this.currentLBXFileSizeLabel.Name = "currentLBXFileSizeLabel";
            this.currentLBXFileSizeLabel.Size = new System.Drawing.Size(0, 13);
            this.currentLBXFileSizeLabel.TabIndex = 16;
            // 
            // imageHeaderHeightTextBox
            // 
            this.imageHeaderHeightTextBox.Location = new System.Drawing.Point(152, 43);
            this.imageHeaderHeightTextBox.Name = "imageHeaderHeightTextBox";
            this.imageHeaderHeightTextBox.ReadOnly = true;
            this.imageHeaderHeightTextBox.Size = new System.Drawing.Size(80, 20);
            this.imageHeaderHeightTextBox.TabIndex = 17;
            this.imageHeaderHeightTextBox.TabStop = false;
            // 
            // imageHeaderFrameCountTextBox
            // 
            this.imageHeaderFrameCountTextBox.Location = new System.Drawing.Point(310, 44);
            this.imageHeaderFrameCountTextBox.Name = "imageHeaderFrameCountTextBox";
            this.imageHeaderFrameCountTextBox.ReadOnly = true;
            this.imageHeaderFrameCountTextBox.Size = new System.Drawing.Size(80, 20);
            this.imageHeaderFrameCountTextBox.TabIndex = 18;
            this.imageHeaderFrameCountTextBox.TabStop = false;
            // 
            // imageHeaderWidthTextBox
            // 
            this.imageHeaderWidthTextBox.Location = new System.Drawing.Point(48, 43);
            this.imageHeaderWidthTextBox.Name = "imageHeaderWidthTextBox";
            this.imageHeaderWidthTextBox.ReadOnly = true;
            this.imageHeaderWidthTextBox.Size = new System.Drawing.Size(80, 20);
            this.imageHeaderWidthTextBox.TabIndex = 19;
            this.imageHeaderWidthTextBox.TabStop = false;
            // 
            // imageHeaderFlagsTextBox
            // 
            this.imageHeaderFlagsTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageHeaderFlagsTextBox.Location = new System.Drawing.Point(465, 44);
            this.imageHeaderFlagsTextBox.Name = "imageHeaderFlagsTextBox";
            this.imageHeaderFlagsTextBox.ReadOnly = true;
            this.imageHeaderFlagsTextBox.Size = new System.Drawing.Size(160, 22);
            this.imageHeaderFlagsTextBox.TabIndex = 20;
            this.imageHeaderFlagsTextBox.TabStop = false;
            // 
            // imageHeaderFrameDelayTextBox
            // 
            this.imageHeaderFrameDelayTextBox.Location = new System.Drawing.Point(310, 69);
            this.imageHeaderFrameDelayTextBox.Name = "imageHeaderFrameDelayTextBox";
            this.imageHeaderFrameDelayTextBox.ReadOnly = true;
            this.imageHeaderFrameDelayTextBox.Size = new System.Drawing.Size(80, 20);
            this.imageHeaderFrameDelayTextBox.TabIndex = 21;
            this.imageHeaderFrameDelayTextBox.TabStop = false;
            // 
            // imageHeaderZeroTextBox
            // 
            this.imageHeaderZeroTextBox.Location = new System.Drawing.Point(48, 73);
            this.imageHeaderZeroTextBox.Name = "imageHeaderZeroTextBox";
            this.imageHeaderZeroTextBox.ReadOnly = true;
            this.imageHeaderZeroTextBox.Size = new System.Drawing.Size(33, 20);
            this.imageHeaderZeroTextBox.TabIndex = 22;
            this.imageHeaderZeroTextBox.TabStop = false;
            // 
            // imageHeaderSizeLabel
            // 
            this.imageHeaderSizeLabel.AutoSize = true;
            this.imageHeaderSizeLabel.Location = new System.Drawing.Point(12, 46);
            this.imageHeaderSizeLabel.Name = "imageHeaderSizeLabel";
            this.imageHeaderSizeLabel.Size = new System.Drawing.Size(30, 13);
            this.imageHeaderSizeLabel.TabIndex = 23;
            this.imageHeaderSizeLabel.Text = "Size:";
            // 
            // imageHeaderFrameCountLabel
            // 
            this.imageHeaderFrameCountLabel.AutoSize = true;
            this.imageHeaderFrameCountLabel.Location = new System.Drawing.Point(260, 47);
            this.imageHeaderFrameCountLabel.Name = "imageHeaderFrameCountLabel";
            this.imageHeaderFrameCountLabel.Size = new System.Drawing.Size(44, 13);
            this.imageHeaderFrameCountLabel.TabIndex = 25;
            this.imageHeaderFrameCountLabel.Text = "Frames:";
            // 
            // imageHeaderFlagsLabel
            // 
            this.imageHeaderFlagsLabel.AutoSize = true;
            this.imageHeaderFlagsLabel.Location = new System.Drawing.Point(424, 48);
            this.imageHeaderFlagsLabel.Name = "imageHeaderFlagsLabel";
            this.imageHeaderFlagsLabel.Size = new System.Drawing.Size(35, 13);
            this.imageHeaderFlagsLabel.TabIndex = 26;
            this.imageHeaderFlagsLabel.Text = "Flags:";
            // 
            // imageHeaderZeroLabel
            // 
            this.imageHeaderZeroLabel.AutoSize = true;
            this.imageHeaderZeroLabel.Location = new System.Drawing.Point(12, 76);
            this.imageHeaderZeroLabel.Name = "imageHeaderZeroLabel";
            this.imageHeaderZeroLabel.Size = new System.Drawing.Size(30, 13);
            this.imageHeaderZeroLabel.TabIndex = 27;
            this.imageHeaderZeroLabel.Text = "zero:";
            // 
            // imageHeaderFrameDelayLabel
            // 
            this.imageHeaderFrameDelayLabel.AutoSize = true;
            this.imageHeaderFrameDelayLabel.Location = new System.Drawing.Point(267, 72);
            this.imageHeaderFrameDelayLabel.Name = "imageHeaderFrameDelayLabel";
            this.imageHeaderFrameDelayLabel.Size = new System.Drawing.Size(37, 13);
            this.imageHeaderFrameDelayLabel.TabIndex = 28;
            this.imageHeaderFrameDelayLabel.Text = "Delay:";
            // 
            // imageHeaderSizeLabelX
            // 
            this.imageHeaderSizeLabelX.AutoSize = true;
            this.imageHeaderSizeLabelX.Location = new System.Drawing.Point(134, 47);
            this.imageHeaderSizeLabelX.Name = "imageHeaderSizeLabelX";
            this.imageHeaderSizeLabelX.Size = new System.Drawing.Size(12, 13);
            this.imageHeaderSizeLabelX.TabIndex = 29;
            this.imageHeaderSizeLabelX.Text = "x";
            // 
            // imageHeaderFlagsLabelKey
            // 
            this.imageHeaderFlagsLabelKey.AutoSize = true;
            this.imageHeaderFlagsLabelKey.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageHeaderFlagsLabelKey.Location = new System.Drawing.Point(465, 74);
            this.imageHeaderFlagsLabelKey.Name = "imageHeaderFlagsLabelKey";
            this.imageHeaderFlagsLabelKey.Size = new System.Drawing.Size(160, 16);
            this.imageHeaderFlagsLabelKey.TabIndex = 30;
            this.imageHeaderFlagsLabelKey.Text = "..JI FB.N .... ....";
            // 
            // currentImageFrameLabel
            // 
            this.currentImageFrameLabel.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentImageFrameLabel.Location = new System.Drawing.Point(285, 136);
            this.currentImageFrameLabel.Name = "currentImageFrameLabel";
            this.currentImageFrameLabel.Size = new System.Drawing.Size(80, 16);
            this.currentImageFrameLabel.TabIndex = 33;
            this.currentImageFrameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nextImageFrameButton
            // 
            this.nextImageFrameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextImageFrameButton.Location = new System.Drawing.Point(371, 132);
            this.nextImageFrameButton.Name = "nextImageFrameButton";
            this.nextImageFrameButton.Size = new System.Drawing.Size(75, 23);
            this.nextImageFrameButton.TabIndex = 32;
            this.nextImageFrameButton.Text = "--->";
            this.nextImageFrameButton.UseVisualStyleBackColor = true;
            this.nextImageFrameButton.Click += new System.EventHandler(this.nextImageFrameButton_Click);
            // 
            // prevImageFrameButton
            // 
            this.prevImageFrameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevImageFrameButton.Location = new System.Drawing.Point(204, 132);
            this.prevImageFrameButton.Name = "prevImageFrameButton";
            this.prevImageFrameButton.Size = new System.Drawing.Size(75, 23);
            this.prevImageFrameButton.TabIndex = 31;
            this.prevImageFrameButton.Text = "<---";
            this.prevImageFrameButton.UseVisualStyleBackColor = true;
            this.prevImageFrameButton.Click += new System.EventHandler(this.prevImageFrameButton_Click);
            // 
            // palettesListBox
            // 
            this.palettesListBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.palettesListBox.FormattingEnabled = true;
            this.palettesListBox.ItemHeight = 18;
            this.palettesListBox.Location = new System.Drawing.Point(707, 48);
            this.palettesListBox.Name = "palettesListBox";
            this.palettesListBox.Size = new System.Drawing.Size(181, 76);
            this.palettesListBox.TabIndex = 35;
            this.palettesListBox.SelectedIndexChanged += new System.EventHandler(this.palettesListBox_SelectedIndexChanged);
            // 
            // palettesListLabel
            // 
            this.palettesListLabel.AutoSize = true;
            this.palettesListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.palettesListLabel.Location = new System.Drawing.Point(723, 25);
            this.palettesListLabel.Name = "palettesListLabel";
            this.palettesListLabel.Size = new System.Drawing.Size(71, 20);
            this.palettesListLabel.TabIndex = 36;
            this.palettesListLabel.Text = "Palettes:";
            // 
            // externalPalettePictureBox
            // 
            this.externalPalettePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.externalPalettePictureBox.Location = new System.Drawing.Point(727, 148);
            this.externalPalettePictureBox.Name = "externalPalettePictureBox";
            this.externalPalettePictureBox.Size = new System.Drawing.Size(162, 162);
            this.externalPalettePictureBox.TabIndex = 37;
            this.externalPalettePictureBox.TabStop = false;
            // 
            // internalPalettePictureBox
            // 
            this.internalPalettePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.internalPalettePictureBox.Location = new System.Drawing.Point(727, 316);
            this.internalPalettePictureBox.Name = "internalPalettePictureBox";
            this.internalPalettePictureBox.Size = new System.Drawing.Size(162, 162);
            this.internalPalettePictureBox.TabIndex = 38;
            this.internalPalettePictureBox.TabStop = false;
            // 
            // mixedPalettePictureBox
            // 
            this.mixedPalettePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mixedPalettePictureBox.Location = new System.Drawing.Point(726, 484);
            this.mixedPalettePictureBox.Name = "mixedPalettePictureBox";
            this.mixedPalettePictureBox.Size = new System.Drawing.Size(162, 162);
            this.mixedPalettePictureBox.TabIndex = 39;
            this.mixedPalettePictureBox.TabStop = false;
            // 
            // currentLBXBlockLabel2
            // 
            this.currentLBXBlockLabel2.AutoSize = true;
            this.currentLBXBlockLabel2.Location = new System.Drawing.Point(547, 84);
            this.currentLBXBlockLabel2.Name = "currentLBXBlockLabel2";
            this.currentLBXBlockLabel2.Size = new System.Drawing.Size(34, 13);
            this.currentLBXBlockLabel2.TabIndex = 40;
            this.currentLBXBlockLabel2.Text = "Block";
            // 
            // currentImageFrameLabel2
            // 
            this.currentImageFrameLabel2.AutoSize = true;
            this.currentImageFrameLabel2.Location = new System.Drawing.Point(307, 119);
            this.currentImageFrameLabel2.Name = "currentImageFrameLabel2";
            this.currentImageFrameLabel2.Size = new System.Drawing.Size(36, 13);
            this.currentImageFrameLabel2.TabIndex = 41;
            this.currentImageFrameLabel2.Text = "Frame";
            // 
            // blockViewTabControl
            // 
            this.blockViewTabControl.Controls.Add(this.blockViewImageTab);
            this.blockViewTabControl.Controls.Add(this.tabPage2);
            this.blockViewTabControl.Location = new System.Drawing.Point(187, 120);
            this.blockViewTabControl.Name = "blockViewTabControl";
            this.blockViewTabControl.SelectedIndex = 0;
            this.blockViewTabControl.Size = new System.Drawing.Size(913, 688);
            this.blockViewTabControl.TabIndex = 42;
            // 
            // blockViewImageTab
            // 
            this.blockViewImageTab.BackColor = System.Drawing.SystemColors.Control;
            this.blockViewImageTab.Controls.Add(this.currentImageFrameOffsetTextBox);
            this.blockViewImageTab.Controls.Add(this.currentImageFrameSizeTextBox);
            this.blockViewImageTab.Controls.Add(this.currentImageFrameOffsetLabel);
            this.blockViewImageTab.Controls.Add(this.currentImageFrameSizeLabel);
            this.blockViewImageTab.Controls.Add(this.imageZoomFactorLabel);
            this.blockViewImageTab.Controls.Add(this.imageZoomTrackBar);
            this.blockViewImageTab.Controls.Add(this.internalPaletteLockButton);
            this.blockViewImageTab.Controls.Add(this.imagePictureBox);
            this.blockViewImageTab.Controls.Add(this.currentImageFrameLabel2);
            this.blockViewImageTab.Controls.Add(this.mixedPalettePictureBox);
            this.blockViewImageTab.Controls.Add(this.imageHeaderFlagsTextBox);
            this.blockViewImageTab.Controls.Add(this.internalPalettePictureBox);
            this.blockViewImageTab.Controls.Add(this.imageHeaderHeightTextBox);
            this.blockViewImageTab.Controls.Add(this.externalPalettePictureBox);
            this.blockViewImageTab.Controls.Add(this.imageHeaderFrameCountTextBox);
            this.blockViewImageTab.Controls.Add(this.palettesListLabel);
            this.blockViewImageTab.Controls.Add(this.imageHeaderWidthTextBox);
            this.blockViewImageTab.Controls.Add(this.palettesListBox);
            this.blockViewImageTab.Controls.Add(this.imageHeaderFrameDelayTextBox);
            this.blockViewImageTab.Controls.Add(this.imageHeaderZeroTextBox);
            this.blockViewImageTab.Controls.Add(this.imageHeaderSizeLabel);
            this.blockViewImageTab.Controls.Add(this.imageHeaderFrameCountLabel);
            this.blockViewImageTab.Controls.Add(this.currentImageFrameLabel);
            this.blockViewImageTab.Controls.Add(this.nextImageFrameButton);
            this.blockViewImageTab.Controls.Add(this.imageHeaderFlagsLabel);
            this.blockViewImageTab.Controls.Add(this.prevImageFrameButton);
            this.blockViewImageTab.Controls.Add(this.imageHeaderZeroLabel);
            this.blockViewImageTab.Controls.Add(this.imageHeaderFrameDelayLabel);
            this.blockViewImageTab.Controls.Add(this.imageHeaderFlagsLabelKey);
            this.blockViewImageTab.Controls.Add(this.imageHeaderSizeLabelX);
            this.blockViewImageTab.Location = new System.Drawing.Point(4, 22);
            this.blockViewImageTab.Name = "blockViewImageTab";
            this.blockViewImageTab.Padding = new System.Windows.Forms.Padding(3);
            this.blockViewImageTab.Size = new System.Drawing.Size(905, 662);
            this.blockViewImageTab.TabIndex = 0;
            this.blockViewImageTab.Text = "Image";
            // 
            // currentImageFrameOffsetTextBox
            // 
            this.currentImageFrameOffsetTextBox.Location = new System.Drawing.Point(610, 134);
            this.currentImageFrameOffsetTextBox.Name = "currentImageFrameOffsetTextBox";
            this.currentImageFrameOffsetTextBox.ReadOnly = true;
            this.currentImageFrameOffsetTextBox.Size = new System.Drawing.Size(68, 20);
            this.currentImageFrameOffsetTextBox.TabIndex = 50;
            // 
            // currentImageFrameSizeTextBox
            // 
            this.currentImageFrameSizeTextBox.Location = new System.Drawing.Point(501, 134);
            this.currentImageFrameSizeTextBox.Name = "currentImageFrameSizeTextBox";
            this.currentImageFrameSizeTextBox.ReadOnly = true;
            this.currentImageFrameSizeTextBox.Size = new System.Drawing.Size(50, 20);
            this.currentImageFrameSizeTextBox.TabIndex = 49;
            // 
            // currentImageFrameOffsetLabel
            // 
            this.currentImageFrameOffsetLabel.AutoSize = true;
            this.currentImageFrameOffsetLabel.Location = new System.Drawing.Point(569, 137);
            this.currentImageFrameOffsetLabel.Name = "currentImageFrameOffsetLabel";
            this.currentImageFrameOffsetLabel.Size = new System.Drawing.Size(35, 13);
            this.currentImageFrameOffsetLabel.TabIndex = 48;
            this.currentImageFrameOffsetLabel.Text = "Offset";
            // 
            // currentImageFrameSizeLabel
            // 
            this.currentImageFrameSizeLabel.AutoSize = true;
            this.currentImageFrameSizeLabel.Location = new System.Drawing.Point(465, 137);
            this.currentImageFrameSizeLabel.Name = "currentImageFrameSizeLabel";
            this.currentImageFrameSizeLabel.Size = new System.Drawing.Size(30, 13);
            this.currentImageFrameSizeLabel.TabIndex = 47;
            this.currentImageFrameSizeLabel.Text = "Size:";
            // 
            // imageZoomFactorLabel
            // 
            this.imageZoomFactorLabel.AutoSize = true;
            this.imageZoomFactorLabel.Location = new System.Drawing.Point(208, 106);
            this.imageZoomFactorLabel.Name = "imageZoomFactorLabel";
            this.imageZoomFactorLabel.Size = new System.Drawing.Size(0, 13);
            this.imageZoomFactorLabel.TabIndex = 46;
            // 
            // imageZoomTrackBar
            // 
            this.imageZoomTrackBar.Location = new System.Drawing.Point(26, 119);
            this.imageZoomTrackBar.Maximum = 2;
            this.imageZoomTrackBar.Minimum = 1;
            this.imageZoomTrackBar.Name = "imageZoomTrackBar";
            this.imageZoomTrackBar.Size = new System.Drawing.Size(151, 45);
            this.imageZoomTrackBar.TabIndex = 45;
            this.imageZoomTrackBar.TickFrequency = 100;
            this.imageZoomTrackBar.Value = 1;
            this.imageZoomTrackBar.ValueChanged += new System.EventHandler(this.imageZoomTrackBar_ValueChanged);
            // 
            // internalPaletteLockButton
            // 
            this.internalPaletteLockButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.internalPaletteLockButton.Location = new System.Drawing.Point(670, 327);
            this.internalPaletteLockButton.Name = "internalPaletteLockButton";
            this.internalPaletteLockButton.Size = new System.Drawing.Size(51, 23);
            this.internalPaletteLockButton.TabIndex = 44;
            this.internalPaletteLockButton.Text = "Lock";
            this.internalPaletteLockButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.internalPaletteLockButton.UseVisualStyleBackColor = true;
            this.internalPaletteLockButton.CheckedChanged += new System.EventHandler(this.internalPaletteLockButton_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.fontColorsListTextBox);
            this.tabPage2.Controls.Add(this.testButton);
            this.tabPage2.Controls.Add(this.fontsLabel);
            this.tabPage2.Controls.Add(this.fontsListBox);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(947, 662);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // fontColorsListTextBox
            // 
            this.fontColorsListTextBox.Location = new System.Drawing.Point(115, 124);
            this.fontColorsListTextBox.Name = "fontColorsListTextBox";
            this.fontColorsListTextBox.Size = new System.Drawing.Size(445, 20);
            this.fontColorsListTextBox.TabIndex = 4;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(289, 81);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 3;
            this.testButton.Text = "Gulp";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // fontsLabel
            // 
            this.fontsLabel.AutoSize = true;
            this.fontsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontsLabel.Location = new System.Drawing.Point(724, 23);
            this.fontsLabel.Name = "fontsLabel";
            this.fontsLabel.Size = new System.Drawing.Size(54, 20);
            this.fontsLabel.TabIndex = 2;
            this.fontsLabel.Text = "Fonts:";
            // 
            // fontsListBox
            // 
            this.fontsListBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontsListBox.FormattingEnabled = true;
            this.fontsListBox.ItemHeight = 18;
            this.fontsListBox.Location = new System.Drawing.Point(728, 46);
            this.fontsListBox.Name = "fontsListBox";
            this.fontsListBox.Size = new System.Drawing.Size(181, 76);
            this.fontsListBox.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(13, 164);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(642, 482);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(797, 96);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(91, 16);
            this.errorLabel.TabIndex = 43;
            this.errorLabel.Text = "Error: things";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(1107, 142);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(268, 662);
            this.treeView1.TabIndex = 44;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 819);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.blockViewTabControl);
            this.Controls.Add(this.currentLBXBlockLabel2);
            this.Controls.Add(this.currentLBXFileSizeLabel);
            this.Controls.Add(this.currentLBXBlockLabel);
            this.Controls.Add(this.nextLBXBlockButton);
            this.Controls.Add(this.prevLBXBlockButton);
            this.Controls.Add(this.currentLBXFileLabel);
            this.Controls.Add(this.lbxFileListRefreshButton);
            this.Controls.Add(this.lbxFilesListBox);
            this.Controls.Add(this.lbxFileListLabel);
            this.Controls.Add(this.gameFolderPathBrowseButton);
            this.Controls.Add(this.gameFolderPathLabel);
            this.Controls.Add(this.gameFolderPathTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mainForm";
            this.Text = "OpenMOO2Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.externalPalettePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.internalPalettePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixedPalettePictureBox)).EndInit();
            this.blockViewTabControl.ResumeLayout(false);
            this.blockViewImageTab.ResumeLayout(false);
            this.blockViewImageTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageZoomTrackBar)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox gameFolderPathTextBox;
        private System.Windows.Forms.Label gameFolderPathLabel;
        private System.Windows.Forms.Button gameFolderPathBrowseButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lbxFileListLabel;
        private System.Windows.Forms.ListBox lbxFilesListBox;
        private System.Windows.Forms.Button lbxFileListRefreshButton;
        private System.Windows.Forms.Label currentLBXFileLabel;
        private System.Windows.Forms.Button prevLBXBlockButton;
        private System.Windows.Forms.Button nextLBXBlockButton;
        private System.Windows.Forms.Label currentLBXBlockLabel;
        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.Label currentLBXFileSizeLabel;
        private System.Windows.Forms.TextBox imageHeaderHeightTextBox;
        private System.Windows.Forms.TextBox imageHeaderFrameCountTextBox;
        private System.Windows.Forms.TextBox imageHeaderWidthTextBox;
        private System.Windows.Forms.TextBox imageHeaderFlagsTextBox;
        private System.Windows.Forms.TextBox imageHeaderFrameDelayTextBox;
        private System.Windows.Forms.TextBox imageHeaderZeroTextBox;
        private System.Windows.Forms.Label imageHeaderSizeLabel;
        private System.Windows.Forms.Label imageHeaderFrameCountLabel;
        private System.Windows.Forms.Label imageHeaderFlagsLabel;
        private System.Windows.Forms.Label imageHeaderZeroLabel;
        private System.Windows.Forms.Label imageHeaderFrameDelayLabel;
        private System.Windows.Forms.Label imageHeaderSizeLabelX;
        private System.Windows.Forms.Label imageHeaderFlagsLabelKey;
        private System.Windows.Forms.Label currentImageFrameLabel;
        private System.Windows.Forms.Button nextImageFrameButton;
        private System.Windows.Forms.Button prevImageFrameButton;
        private System.Windows.Forms.ListBox palettesListBox;
        private System.Windows.Forms.Label palettesListLabel;
        private System.Windows.Forms.PictureBox externalPalettePictureBox;
        private System.Windows.Forms.PictureBox internalPalettePictureBox;
        private System.Windows.Forms.PictureBox mixedPalettePictureBox;
        private System.Windows.Forms.Label currentLBXBlockLabel2;
        private System.Windows.Forms.Label currentImageFrameLabel2;
        private System.Windows.Forms.TabControl blockViewTabControl;
        private System.Windows.Forms.TabPage blockViewImageTab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.CheckBox internalPaletteLockButton;
        private System.Windows.Forms.TrackBar imageZoomTrackBar;
        private System.Windows.Forms.Label imageZoomFactorLabel;
        private System.Windows.Forms.TextBox currentImageFrameSizeTextBox;
        private System.Windows.Forms.Label currentImageFrameOffsetLabel;
        private System.Windows.Forms.Label currentImageFrameSizeLabel;
        private System.Windows.Forms.TextBox currentImageFrameOffsetTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox fontsListBox;
        private System.Windows.Forms.Label fontsLabel;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.TextBox fontColorsListTextBox;
        private System.Windows.Forms.TreeView treeView1;
    }
}

