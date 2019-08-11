namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.trkzoom = new System.Windows.Forms.TrackBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEditor = new System.Windows.Forms.TabPage();
            this.btnColorSwap2 = new System.Windows.Forms.Button();
            this.btnZXpaint2 = new System.Windows.Forms.Button();
            this.btnToolPixelPaint = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFixedFileSize = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbo4colorDither = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grpSpriteSize = new System.Windows.Forms.GroupBox();
            this.rdospr512 = new System.Windows.Forms.RadioButton();
            this.rdospr256 = new System.Windows.Forms.RadioButton();
            this.GrpFrameOverlay = new System.Windows.Forms.GroupBox();
            this.rdoFrameLast = new System.Windows.Forms.RadioButton();
            this.rdoFrameNext = new System.Windows.Forms.RadioButton();
            this.rdoFrameNone = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkHasDosHeader = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoVic20MultiColor = new System.Windows.Forms.RadioButton();
            this.rdoHalfWidthFourColor = new System.Windows.Forms.RadioButton();
            this.rdoAppleColor = new System.Windows.Forms.RadioButton();
            this.rdoC64_4Color = new System.Windows.Forms.RadioButton();
            this.rdoCPCdither = new System.Windows.Forms.RadioButton();
            this.rdoSpecDither = new System.Windows.Forms.RadioButton();
            this.RdoTIquarter = new System.Windows.Forms.RadioButton();
            this.rdoCPCpairs = new System.Windows.Forms.RadioButton();
            this.rdoDisplayCPC0 = new System.Windows.Forms.RadioButton();
            this.rdoDisplaySpeccy = new System.Windows.Forms.RadioButton();
            this.rdoDisplayCPC = new System.Windows.Forms.RadioButton();
            this.rdoDisplayMSX = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoC64Sprite = new System.Windows.Forms.RadioButton();
            this.rdoGuide7_14_28 = new System.Windows.Forms.RadioButton();
            this.rdoGuide4_8_32 = new System.Windows.Forms.RadioButton();
            this.rdoGuide4_8_24 = new System.Windows.Forms.RadioButton();
            this.rdoGuideNone = new System.Windows.Forms.RadioButton();
            this.chkStrongGrid = new System.Windows.Forms.CheckBox();
            this.ChkBackgroundTestDots = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblMaxSpritesByOffset = new System.Windows.Forms.Label();
            this.txtSpriteDataOffSet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstSprites = new System.Windows.Forms.ListBox();
            this.tabNotes = new System.Windows.Forms.TabPage();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblSpriteInfo = new System.Windows.Forms.Label();
            this.pnlMSXpal = new System.Windows.Forms.Panel();
            this.pnlNESpal = new System.Windows.Forms.Panel();
            this.pnlC64pal = new System.Windows.Forms.Panel();
            this.pnlZXPalette = new System.Windows.Forms.Panel();
            this.BtnAltPal = new System.Windows.Forms.Button();
            this.tabSpriteTools = new System.Windows.Forms.TabControl();
            this.tabSpriteOptions = new System.Windows.Forms.TabPage();
            this.chkFixedSize = new System.Windows.Forms.CheckBox();
            this.chkAligned = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSpriteSettings = new System.Windows.Forms.TextBox();
            this.tabPixelPaint = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCheckMode = new System.Windows.Forms.ComboBox();
            this.tabZXPaint = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.cboZxPaintMode = new System.Windows.Forms.ComboBox();
            this.tabColorSwap = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.cboFillCheck = new System.Windows.Forms.ComboBox();
            this.cboColorConvertMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNextBank = new System.Windows.Forms.Button();
            this.btnLastBank = new System.Windows.Forms.Button();
            this.btnNextSprite = new System.Windows.Forms.Button();
            this.btnLastSprite = new System.Windows.Forms.Button();
            this.btnSetPal = new System.Windows.Forms.Button();
            this.tmrBackup = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.reSaveSpritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSpritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recent1 = new System.Windows.Forms.ToolStripMenuItem();
            this.recent2 = new System.Windows.Forms.ToolStripMenuItem();
            this.recent3 = new System.Windows.Forms.ToolStripMenuItem();
            this.recent4 = new System.Windows.Forms.ToolStripMenuItem();
            this.recent5 = new System.Windows.Forms.ToolStripMenuItem();
            this.recent6 = new System.Windows.Forms.ToolStripMenuItem();
            this.recent7 = new System.Windows.Forms.ToolStripMenuItem();
            this.recent8 = new System.Windows.Forms.ToolStripMenuItem();
            this.recent9 = new System.Windows.Forms.ToolStripMenuItem();
            this.recent10 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPixelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBMPMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBMPMaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSX16ColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cPC4ColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorpairsCPCENTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorditheredCPCENTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zX2ColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorditheredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.cPC16ColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.highVisToggleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overlayLastFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overlayNextFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.applyViewColorConversionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToClipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvasSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateOffsetFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pxShiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelShiftRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelShiftUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelShiftDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileShiftXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yInterlaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAllAttribsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackBorderTightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PaletteTint = new System.Windows.Forms.ToolStripMenuItem();
            this.cPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCPCBinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCPCBinaryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCPCBinaryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCPCBinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveCPCRawBmp = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCPCZigTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCPCSCRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rLEASMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spriteCompilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addOneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CpcSpriteConvaddOneDiffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CpcSpriteCompilerClear = new System.Windows.Forms.ToolStripMenuItem();
            this.saveASMPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMSXASMPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMSXBinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMSXBitmapToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMSXBitmapWithPaletteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMSXBitmapSpritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rLEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildRLEASMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMSXRLEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMSXRLEPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMSXRLESpritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRAWBitmapToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRAWMSX1BitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRAWMSX1Raw16x16SpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawVdpTileBitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSpectrumScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSpectrumBinaryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSpectrumTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSpectrumFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSpectrumScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmapToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.rLEASMToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rLEASMCOLORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fourColor2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertZXToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.halfSizeFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spriteCompilerToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.addOneToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteZXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.z80ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmapToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.tIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmapToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sAMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmapToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRLEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBinarySpritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eNTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRAWBitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rLEASMToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.sMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmapToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.camputersLynxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmapToolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRaw8x8TileBitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.atari5200800ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmap2ColorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmap4ColorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.atariLynxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmapToolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.save16colorLinearSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save8colorLinearSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.save16ColorRLESpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save8ColorRLESpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save4ColorRLESpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save2ColorRLESpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmap2ColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmap4ColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bBCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmapToolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.c64ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmap2ColorToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmap4ColorToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSprite2ColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSprite4ColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nESFamicomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmapToolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.pCEngineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmapToolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.savePCESpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.superNintendoSFCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmapToolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.vic20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmapToolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.neoGeoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFIXFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atariSTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmapToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.AmigaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmapToolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.x68000ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmapToolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.megaDriveGenesisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRawBitmapToolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.sinclairQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raw8colorBitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlApplePal = new System.Windows.Forms.Panel();
            this.bigfont = new System.Windows.Forms.Label();
            this.raw4colorBitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkzoom)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabEditor.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpSpriteSize.SuspendLayout();
            this.GrpFrameOverlay.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabNotes.SuspendLayout();
            this.tabSpriteTools.SuspendLayout();
            this.tabSpriteOptions.SuspendLayout();
            this.tabPixelPaint.SuspendLayout();
            this.tabZXPaint.SuspendLayout();
            this.tabColorSwap.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(48, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 631);
            this.panel1.TabIndex = 0;
            // 
            // picPreview
            // 
            this.picPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picPreview.BackColor = System.Drawing.Color.Black;
            this.picPreview.Location = new System.Drawing.Point(781, 388);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(256, 236);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPreview.TabIndex = 1;
            this.picPreview.TabStop = false;
            // 
            // trkzoom
            // 
            this.trkzoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trkzoom.Location = new System.Drawing.Point(778, 85);
            this.trkzoom.Maximum = 32;
            this.trkzoom.Minimum = 2;
            this.trkzoom.Name = "trkzoom";
            this.trkzoom.Size = new System.Drawing.Size(153, 42);
            this.trkzoom.TabIndex = 2;
            this.trkzoom.TickFrequency = 2;
            this.trkzoom.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trkzoom.Value = 4;
            this.trkzoom.Scroll += new System.EventHandler(this.trkzoom_Scroll);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabEditor);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabNotes);
            this.tabControl1.Location = new System.Drawing.Point(4, 71);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(773, 673);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl1_KeyDown);
            // 
            // tabEditor
            // 
            this.tabEditor.Controls.Add(this.btnColorSwap2);
            this.tabEditor.Controls.Add(this.btnZXpaint2);
            this.tabEditor.Controls.Add(this.btnToolPixelPaint);
            this.tabEditor.Controls.Add(this.btnRedo);
            this.tabEditor.Controls.Add(this.btnUndo);
            this.tabEditor.Controls.Add(this.btnRefresh);
            this.tabEditor.Controls.Add(this.panel1);
            this.tabEditor.Location = new System.Drawing.Point(4, 21);
            this.tabEditor.Name = "tabEditor";
            this.tabEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditor.Size = new System.Drawing.Size(765, 648);
            this.tabEditor.TabIndex = 0;
            this.tabEditor.Text = "Editor";
            this.tabEditor.UseVisualStyleBackColor = true;
            this.tabEditor.Click += new System.EventHandler(this.tabEditor_Click);
            // 
            // btnColorSwap2
            // 
            this.btnColorSwap2.Location = new System.Drawing.Point(0, 102);
            this.btnColorSwap2.Name = "btnColorSwap2";
            this.btnColorSwap2.Size = new System.Drawing.Size(48, 48);
            this.btnColorSwap2.TabIndex = 24;
            this.btnColorSwap2.Text = "Color Swap";
            this.btnColorSwap2.UseVisualStyleBackColor = true;
            this.btnColorSwap2.Click += new System.EventHandler(this.btnColorSwap_Click_1);
            // 
            // btnZXpaint2
            // 
            this.btnZXpaint2.Location = new System.Drawing.Point(0, 54);
            this.btnZXpaint2.Name = "btnZXpaint2";
            this.btnZXpaint2.Size = new System.Drawing.Size(48, 48);
            this.btnZXpaint2.TabIndex = 22;
            this.btnZXpaint2.Text = "ZX Paint";
            this.btnZXpaint2.UseVisualStyleBackColor = true;
            this.btnZXpaint2.Click += new System.EventHandler(this.btnZXpaint2_Click);
            // 
            // btnToolPixelPaint
            // 
            this.btnToolPixelPaint.Location = new System.Drawing.Point(0, 3);
            this.btnToolPixelPaint.Name = "btnToolPixelPaint";
            this.btnToolPixelPaint.Size = new System.Drawing.Size(48, 48);
            this.btnToolPixelPaint.TabIndex = 21;
            this.btnToolPixelPaint.Text = "Pixel Paint";
            this.btnToolPixelPaint.UseVisualStyleBackColor = true;
            this.btnToolPixelPaint.Click += new System.EventHandler(this.btnToolPixelPaint_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(0, 284);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(48, 48);
            this.btnRedo.TabIndex = 12;
            this.btnRedo.Text = "Redo";
            this.toolTip1.SetToolTip(this.btnRedo, "Redo (Ctrl-Shift-Z)");
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(0, 230);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(48, 48);
            this.btnUndo.TabIndex = 11;
            this.btnUndo.Text = "Undo";
            this.toolTip1.SetToolTip(this.btnUndo, "Undo (Ctrl-Z)");
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(0, 179);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(48, 48);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Re Fresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.grpSpriteSize);
            this.tabPage2.Controls.Add(this.GrpFrameOverlay);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(765, 648);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.txtFixedFileSize);
            this.groupBox5.Location = new System.Drawing.Point(428, 229);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(142, 75);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "NeoGeo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "Fixed File Size";
            // 
            // txtFixedFileSize
            // 
            this.txtFixedFileSize.Location = new System.Drawing.Point(16, 33);
            this.txtFixedFileSize.Name = "txtFixedFileSize";
            this.txtFixedFileSize.Size = new System.Drawing.Size(120, 19);
            this.txtFixedFileSize.TabIndex = 0;
            this.txtFixedFileSize.Text = "&100000";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbo4colorDither);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(171, 381);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 106);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dither Option";
            // 
            // cbo4colorDither
            // 
            this.cbo4colorDither.FormattingEnabled = true;
            this.cbo4colorDither.Items.AddRange(new object[] {
            "Normal",
            "Alternate"});
            this.cbo4colorDither.Location = new System.Drawing.Point(97, 13);
            this.cbo4colorDither.Name = "cbo4colorDither";
            this.cbo4colorDither.Size = new System.Drawing.Size(132, 20);
            this.cbo4colorDither.TabIndex = 1;
            this.cbo4colorDither.SelectedIndexChanged += new System.EventHandler(this.cbo4colorDither_SelectedIndexChanged);
            this.cbo4colorDither.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCheckMode_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "4Color";
            // 
            // grpSpriteSize
            // 
            this.grpSpriteSize.Controls.Add(this.rdospr512);
            this.grpSpriteSize.Controls.Add(this.rdospr256);
            this.grpSpriteSize.Location = new System.Drawing.Point(427, 67);
            this.grpSpriteSize.Name = "grpSpriteSize";
            this.grpSpriteSize.Size = new System.Drawing.Size(171, 63);
            this.grpSpriteSize.TabIndex = 15;
            this.grpSpriteSize.TabStop = false;
            this.grpSpriteSize.Text = "MAX SpriteSize";
            // 
            // rdospr512
            // 
            this.rdospr512.AutoSize = true;
            this.rdospr512.Location = new System.Drawing.Point(7, 35);
            this.rdospr512.Name = "rdospr512";
            this.rdospr512.Size = new System.Drawing.Size(65, 16);
            this.rdospr512.TabIndex = 1;
            this.rdospr512.Text = "512x512";
            this.rdospr512.UseVisualStyleBackColor = true;
            this.rdospr512.CheckedChanged += new System.EventHandler(this.rdospr512_CheckedChanged);
            // 
            // rdospr256
            // 
            this.rdospr256.AutoSize = true;
            this.rdospr256.Checked = true;
            this.rdospr256.Location = new System.Drawing.Point(6, 18);
            this.rdospr256.Name = "rdospr256";
            this.rdospr256.Size = new System.Drawing.Size(65, 16);
            this.rdospr256.TabIndex = 0;
            this.rdospr256.TabStop = true;
            this.rdospr256.Text = "256x256";
            this.rdospr256.UseVisualStyleBackColor = true;
            this.rdospr256.CheckedChanged += new System.EventHandler(this.rdospr256_CheckedChanged);
            // 
            // GrpFrameOverlay
            // 
            this.GrpFrameOverlay.Controls.Add(this.rdoFrameLast);
            this.GrpFrameOverlay.Controls.Add(this.rdoFrameNext);
            this.GrpFrameOverlay.Controls.Add(this.rdoFrameNone);
            this.GrpFrameOverlay.Location = new System.Drawing.Point(427, 136);
            this.GrpFrameOverlay.Name = "GrpFrameOverlay";
            this.GrpFrameOverlay.Size = new System.Drawing.Size(144, 88);
            this.GrpFrameOverlay.TabIndex = 14;
            this.GrpFrameOverlay.TabStop = false;
            this.GrpFrameOverlay.Text = "FrameOverlay";
            // 
            // rdoFrameLast
            // 
            this.rdoFrameLast.AutoSize = true;
            this.rdoFrameLast.Location = new System.Drawing.Point(8, 62);
            this.rdoFrameLast.Name = "rdoFrameLast";
            this.rdoFrameLast.Size = new System.Drawing.Size(45, 16);
            this.rdoFrameLast.TabIndex = 16;
            this.rdoFrameLast.Text = "Last";
            this.rdoFrameLast.UseVisualStyleBackColor = true;
            this.rdoFrameLast.CheckedChanged += new System.EventHandler(this.rdoFrameLast_CheckedChanged);
            // 
            // rdoFrameNext
            // 
            this.rdoFrameNext.AutoSize = true;
            this.rdoFrameNext.Location = new System.Drawing.Point(8, 40);
            this.rdoFrameNext.Name = "rdoFrameNext";
            this.rdoFrameNext.Size = new System.Drawing.Size(47, 16);
            this.rdoFrameNext.TabIndex = 15;
            this.rdoFrameNext.Text = "Next";
            this.rdoFrameNext.UseVisualStyleBackColor = true;
            this.rdoFrameNext.CheckedChanged += new System.EventHandler(this.rdoFrameNext_CheckedChanged);
            // 
            // rdoFrameNone
            // 
            this.rdoFrameNone.AutoSize = true;
            this.rdoFrameNone.Checked = true;
            this.rdoFrameNone.Location = new System.Drawing.Point(9, 18);
            this.rdoFrameNone.Name = "rdoFrameNone";
            this.rdoFrameNone.Size = new System.Drawing.Size(49, 16);
            this.rdoFrameNone.TabIndex = 15;
            this.rdoFrameNone.TabStop = true;
            this.rdoFrameNone.Text = "None";
            this.rdoFrameNone.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkHasDosHeader);
            this.groupBox4.Location = new System.Drawing.Point(426, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(173, 50);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Binary Files";
            // 
            // chkHasDosHeader
            // 
            this.chkHasDosHeader.AutoSize = true;
            this.chkHasDosHeader.Checked = true;
            this.chkHasDosHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHasDosHeader.Location = new System.Drawing.Point(6, 18);
            this.chkHasDosHeader.Name = "chkHasDosHeader";
            this.chkHasDosHeader.Size = new System.Drawing.Size(100, 16);
            this.chkHasDosHeader.TabIndex = 6;
            this.chkHasDosHeader.Text = "HasDosHeader";
            this.toolTip1.SetToolTip(this.chkHasDosHeader, "File has a header");
            this.chkHasDosHeader.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoVic20MultiColor);
            this.groupBox2.Controls.Add(this.rdoHalfWidthFourColor);
            this.groupBox2.Controls.Add(this.rdoAppleColor);
            this.groupBox2.Controls.Add(this.rdoC64_4Color);
            this.groupBox2.Controls.Add(this.rdoCPCdither);
            this.groupBox2.Controls.Add(this.rdoSpecDither);
            this.groupBox2.Controls.Add(this.RdoTIquarter);
            this.groupBox2.Controls.Add(this.rdoCPCpairs);
            this.groupBox2.Controls.Add(this.rdoDisplayCPC0);
            this.groupBox2.Controls.Add(this.rdoDisplaySpeccy);
            this.groupBox2.Controls.Add(this.rdoDisplayCPC);
            this.groupBox2.Controls.Add(this.rdoDisplayMSX);
            this.groupBox2.Location = new System.Drawing.Point(171, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 364);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DisplayMode";
            // 
            // rdoVic20MultiColor
            // 
            this.rdoVic20MultiColor.AutoSize = true;
            this.rdoVic20MultiColor.Location = new System.Drawing.Point(6, 278);
            this.rdoVic20MultiColor.Name = "rdoVic20MultiColor";
            this.rdoVic20MultiColor.Size = new System.Drawing.Size(106, 16);
            this.rdoVic20MultiColor.TabIndex = 24;
            this.rdoVic20MultiColor.Text = "Vic20 Multicolor";
            this.toolTip1.SetToolTip(this.rdoVic20MultiColor, "4 color");
            this.rdoVic20MultiColor.UseVisualStyleBackColor = true;
            // 
            // rdoHalfWidthFourColor
            // 
            this.rdoHalfWidthFourColor.AutoSize = true;
            this.rdoHalfWidthFourColor.Location = new System.Drawing.Point(6, 256);
            this.rdoHalfWidthFourColor.Name = "rdoHalfWidthFourColor";
            this.rdoHalfWidthFourColor.Size = new System.Drawing.Size(126, 16);
            this.rdoHalfWidthFourColor.TabIndex = 23;
            this.rdoHalfWidthFourColor.Text = "HalfWidth FourColor";
            this.toolTip1.SetToolTip(this.rdoHalfWidthFourColor, "4 color");
            this.rdoHalfWidthFourColor.UseVisualStyleBackColor = true;
            // 
            // rdoAppleColor
            // 
            this.rdoAppleColor.AutoSize = true;
            this.rdoAppleColor.Location = new System.Drawing.Point(6, 234);
            this.rdoAppleColor.Name = "rdoAppleColor";
            this.rdoAppleColor.Size = new System.Drawing.Size(93, 16);
            this.rdoAppleColor.TabIndex = 22;
            this.rdoAppleColor.Text = "Apple 4-color";
            this.toolTip1.SetToolTip(this.rdoAppleColor, "4 color");
            this.rdoAppleColor.UseVisualStyleBackColor = true;
            // 
            // rdoC64_4Color
            // 
            this.rdoC64_4Color.AutoSize = true;
            this.rdoC64_4Color.Location = new System.Drawing.Point(8, 212);
            this.rdoC64_4Color.Name = "rdoC64_4Color";
            this.rdoC64_4Color.Size = new System.Drawing.Size(84, 16);
            this.rdoC64_4Color.TabIndex = 21;
            this.rdoC64_4Color.Text = "C64 4-color";
            this.toolTip1.SetToolTip(this.rdoC64_4Color, "4 color");
            this.rdoC64_4Color.UseVisualStyleBackColor = true;
            // 
            // rdoCPCdither
            // 
            this.rdoCPCdither.AutoSize = true;
            this.rdoCPCdither.Location = new System.Drawing.Point(8, 74);
            this.rdoCPCdither.Name = "rdoCPCdither";
            this.rdoCPCdither.Size = new System.Drawing.Size(172, 16);
            this.rdoCPCdither.TabIndex = 20;
            this.rdoCPCdither.Text = "CPC/ENT Mode 1 - Dithered";
            this.toolTip1.SetToolTip(this.rdoCPCdither, "4 color");
            this.rdoCPCdither.UseVisualStyleBackColor = true;
            this.rdoCPCdither.CheckedChanged += new System.EventHandler(this.rdoCPCdither_CheckedChanged);
            // 
            // rdoSpecDither
            // 
            this.rdoSpecDither.AutoSize = true;
            this.rdoSpecDither.Location = new System.Drawing.Point(8, 165);
            this.rdoSpecDither.Name = "rdoSpecDither";
            this.rdoSpecDither.Size = new System.Drawing.Size(140, 16);
            this.rdoSpecDither.TabIndex = 19;
            this.rdoSpecDither.Text = "Spectrum/TI-83 Dither";
            this.toolTip1.SetToolTip(this.rdoSpecDither, "Spectrum screen - Anything not Color 1 is on");
            this.rdoSpecDither.UseVisualStyleBackColor = true;
            this.rdoSpecDither.CheckedChanged += new System.EventHandler(this.rdoSpecDither_CheckedChanged);
            // 
            // RdoTIquarter
            // 
            this.RdoTIquarter.AutoSize = true;
            this.RdoTIquarter.Location = new System.Drawing.Point(8, 190);
            this.RdoTIquarter.Name = "RdoTIquarter";
            this.RdoTIquarter.Size = new System.Drawing.Size(167, 16);
            this.RdoTIquarter.TabIndex = 18;
            this.RdoTIquarter.Text = "Spectrum/TI-83 QuarterRes";
            this.toolTip1.SetToolTip(this.RdoTIquarter, "Spectrum screen - Anything not Color 1 is on");
            this.RdoTIquarter.UseVisualStyleBackColor = true;
            // 
            // rdoCPCpairs
            // 
            this.rdoCPCpairs.AutoSize = true;
            this.rdoCPCpairs.Location = new System.Drawing.Point(8, 52);
            this.rdoCPCpairs.Name = "rdoCPCpairs";
            this.rdoCPCpairs.Size = new System.Drawing.Size(181, 16);
            this.rdoCPCpairs.TabIndex = 17;
            this.rdoCPCpairs.Text = "CPC/ENT Mode 1 - Colorpairs";
            this.toolTip1.SetToolTip(this.rdoCPCpairs, "4 color");
            this.rdoCPCpairs.UseVisualStyleBackColor = true;
            // 
            // rdoDisplayCPC0
            // 
            this.rdoDisplayCPC0.AutoSize = true;
            this.rdoDisplayCPC0.Location = new System.Drawing.Point(8, 103);
            this.rdoDisplayCPC0.Name = "rdoDisplayCPC0";
            this.rdoDisplayCPC0.Size = new System.Drawing.Size(115, 16);
            this.rdoDisplayCPC0.TabIndex = 16;
            this.rdoDisplayCPC0.Text = "CPC/ENT Mode 0";
            this.toolTip1.SetToolTip(this.rdoDisplayCPC0, "4 color");
            this.rdoDisplayCPC0.UseVisualStyleBackColor = true;
            this.rdoDisplayCPC0.CheckedChanged += new System.EventHandler(this.rdoDisplayCPC0_CheckedChanged);
            // 
            // rdoDisplaySpeccy
            // 
            this.rdoDisplaySpeccy.AutoSize = true;
            this.rdoDisplaySpeccy.Location = new System.Drawing.Point(8, 143);
            this.rdoDisplaySpeccy.Name = "rdoDisplaySpeccy";
            this.rdoDisplaySpeccy.Size = new System.Drawing.Size(105, 16);
            this.rdoDisplaySpeccy.TabIndex = 6;
            this.rdoDisplaySpeccy.Text = "Spectrum/TI-83";
            this.toolTip1.SetToolTip(this.rdoDisplaySpeccy, "Spectrum screen - Anything not Color 1 is on");
            this.rdoDisplaySpeccy.UseVisualStyleBackColor = true;
            this.rdoDisplaySpeccy.CheckedChanged += new System.EventHandler(this.rdoDisplaySpeccy_CheckedChanged);
            // 
            // rdoDisplayCPC
            // 
            this.rdoDisplayCPC.AutoSize = true;
            this.rdoDisplayCPC.Location = new System.Drawing.Point(8, 33);
            this.rdoDisplayCPC.Name = "rdoDisplayCPC";
            this.rdoDisplayCPC.Size = new System.Drawing.Size(115, 16);
            this.rdoDisplayCPC.TabIndex = 5;
            this.rdoDisplayCPC.Text = "CPC/ENT Mode 1";
            this.toolTip1.SetToolTip(this.rdoDisplayCPC, "4 color");
            this.rdoDisplayCPC.UseVisualStyleBackColor = true;
            this.rdoDisplayCPC.CheckedChanged += new System.EventHandler(this.rdoDisplayCPC_CheckedChanged);
            // 
            // rdoDisplayMSX
            // 
            this.rdoDisplayMSX.AutoSize = true;
            this.rdoDisplayMSX.Checked = true;
            this.rdoDisplayMSX.Location = new System.Drawing.Point(8, 15);
            this.rdoDisplayMSX.Name = "rdoDisplayMSX";
            this.rdoDisplayMSX.Size = new System.Drawing.Size(127, 16);
            this.rdoDisplayMSX.TabIndex = 4;
            this.rdoDisplayMSX.TabStop = true;
            this.rdoDisplayMSX.Text = "MSX / SAM / CPC+";
            this.toolTip1.SetToolTip(this.rdoDisplayMSX, "16 color");
            this.rdoDisplayMSX.UseVisualStyleBackColor = true;
            this.rdoDisplayMSX.CheckedChanged += new System.EventHandler(this.rdoDisplayMSX_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoC64Sprite);
            this.groupBox1.Controls.Add(this.rdoGuide7_14_28);
            this.groupBox1.Controls.Add(this.rdoGuide4_8_32);
            this.groupBox1.Controls.Add(this.rdoGuide4_8_24);
            this.groupBox1.Controls.Add(this.rdoGuideNone);
            this.groupBox1.Controls.Add(this.chkStrongGrid);
            this.groupBox1.Controls.Add(this.ChkBackgroundTestDots);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Guides";
            // 
            // rdoC64Sprite
            // 
            this.rdoC64Sprite.AutoSize = true;
            this.rdoC64Sprite.Location = new System.Drawing.Point(4, 98);
            this.rdoC64Sprite.Name = "rdoC64Sprite";
            this.rdoC64Sprite.Size = new System.Drawing.Size(122, 16);
            this.rdoC64Sprite.TabIndex = 17;
            this.rdoC64Sprite.Text = "7,14,28 (C64 sprite)";
            this.rdoC64Sprite.UseVisualStyleBackColor = true;
            // 
            // rdoGuide7_14_28
            // 
            this.rdoGuide7_14_28.AutoSize = true;
            this.rdoGuide7_14_28.Location = new System.Drawing.Point(4, 74);
            this.rdoGuide7_14_28.Name = "rdoGuide7_14_28";
            this.rdoGuide7_14_28.Size = new System.Drawing.Size(98, 16);
            this.rdoGuide7_14_28.TabIndex = 16;
            this.rdoGuide7_14_28.Text = "7,14,28 (Apple)";
            this.rdoGuide7_14_28.UseVisualStyleBackColor = true;
            this.rdoGuide7_14_28.CheckedChanged += new System.EventHandler(this.rdoGuide6_12_24_CheckedChanged);
            // 
            // rdoGuide4_8_32
            // 
            this.rdoGuide4_8_32.AutoSize = true;
            this.rdoGuide4_8_32.Location = new System.Drawing.Point(4, 52);
            this.rdoGuide4_8_32.Name = "rdoGuide4_8_32";
            this.rdoGuide4_8_32.Size = new System.Drawing.Size(51, 16);
            this.rdoGuide4_8_32.TabIndex = 4;
            this.rdoGuide4_8_32.Text = "4,8,32";
            this.rdoGuide4_8_32.UseVisualStyleBackColor = true;
            this.rdoGuide4_8_32.CheckedChanged += new System.EventHandler(this.rdoGuide4_8_32_CheckedChanged);
            // 
            // rdoGuide4_8_24
            // 
            this.rdoGuide4_8_24.AutoSize = true;
            this.rdoGuide4_8_24.Checked = true;
            this.rdoGuide4_8_24.Location = new System.Drawing.Point(4, 33);
            this.rdoGuide4_8_24.Name = "rdoGuide4_8_24";
            this.rdoGuide4_8_24.Size = new System.Drawing.Size(51, 16);
            this.rdoGuide4_8_24.TabIndex = 3;
            this.rdoGuide4_8_24.TabStop = true;
            this.rdoGuide4_8_24.Text = "4,8,24";
            this.rdoGuide4_8_24.UseVisualStyleBackColor = true;
            this.rdoGuide4_8_24.CheckedChanged += new System.EventHandler(this.rdoGuide4_8_24_CheckedChanged);
            // 
            // rdoGuideNone
            // 
            this.rdoGuideNone.AutoSize = true;
            this.rdoGuideNone.Location = new System.Drawing.Point(4, 15);
            this.rdoGuideNone.Name = "rdoGuideNone";
            this.rdoGuideNone.Size = new System.Drawing.Size(49, 16);
            this.rdoGuideNone.TabIndex = 2;
            this.rdoGuideNone.Text = "None";
            this.rdoGuideNone.UseVisualStyleBackColor = true;
            this.rdoGuideNone.CheckedChanged += new System.EventHandler(this.rdoGuideNone_CheckedChanged);
            // 
            // chkStrongGrid
            // 
            this.chkStrongGrid.AutoSize = true;
            this.chkStrongGrid.Checked = true;
            this.chkStrongGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStrongGrid.Location = new System.Drawing.Point(4, 120);
            this.chkStrongGrid.Name = "chkStrongGrid";
            this.chkStrongGrid.Size = new System.Drawing.Size(121, 16);
            this.chkStrongGrid.TabIndex = 14;
            this.chkStrongGrid.Text = "High Visibility Grid";
            this.toolTip1.SetToolTip(this.chkStrongGrid, "Make the Grid more visible");
            this.chkStrongGrid.UseVisualStyleBackColor = true;
            this.chkStrongGrid.CheckedChanged += new System.EventHandler(this.chkStrongGrid_CheckedChanged);
            // 
            // ChkBackgroundTestDots
            // 
            this.ChkBackgroundTestDots.AutoSize = true;
            this.ChkBackgroundTestDots.Location = new System.Drawing.Point(4, 142);
            this.ChkBackgroundTestDots.Name = "ChkBackgroundTestDots";
            this.ChkBackgroundTestDots.Size = new System.Drawing.Size(139, 16);
            this.ChkBackgroundTestDots.TabIndex = 15;
            this.ChkBackgroundTestDots.Text = "Background Test Dots";
            this.toolTip1.SetToolTip(this.ChkBackgroundTestDots, "Make the Grid more visible");
            this.ChkBackgroundTestDots.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblMaxSpritesByOffset);
            this.tabPage1.Controls.Add(this.txtSpriteDataOffSet);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lstSprites);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(765, 648);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "SpriteList";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblMaxSpritesByOffset
            // 
            this.lblMaxSpritesByOffset.AutoSize = true;
            this.lblMaxSpritesByOffset.Location = new System.Drawing.Point(635, 11);
            this.lblMaxSpritesByOffset.Name = "lblMaxSpritesByOffset";
            this.lblMaxSpritesByOffset.Size = new System.Drawing.Size(7, 12);
            this.lblMaxSpritesByOffset.TabIndex = 3;
            this.lblMaxSpritesByOffset.Text = ".";
            // 
            // txtSpriteDataOffSet
            // 
            this.txtSpriteDataOffSet.Location = new System.Drawing.Point(512, 8);
            this.txtSpriteDataOffSet.Name = "txtSpriteDataOffSet";
            this.txtSpriteDataOffSet.Size = new System.Drawing.Size(108, 19);
            this.txtSpriteDataOffSet.TabIndex = 2;
            this.txtSpriteDataOffSet.Text = "&180";
            this.toolTip1.SetToolTip(this.txtSpriteDataOffSet, "Memory offset of first sprite in binary files");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(413, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "SpriteDataOffSet";
            // 
            // lstSprites
            // 
            this.lstSprites.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSprites.FormattingEnabled = true;
            this.lstSprites.ItemHeight = 14;
            this.lstSprites.Location = new System.Drawing.Point(4, 4);
            this.lstSprites.Name = "lstSprites";
            this.lstSprites.Size = new System.Drawing.Size(404, 368);
            this.lstSprites.TabIndex = 0;
            this.lstSprites.SelectedIndexChanged += new System.EventHandler(this.lstSprites_SelectedIndexChanged);
            // 
            // tabNotes
            // 
            this.tabNotes.Controls.Add(this.txtNotes);
            this.tabNotes.Location = new System.Drawing.Point(4, 21);
            this.tabNotes.Name = "tabNotes";
            this.tabNotes.Size = new System.Drawing.Size(765, 648);
            this.tabNotes.TabIndex = 3;
            this.tabNotes.Text = "Notes";
            this.tabNotes.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(4, 3);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(758, 634);
            this.txtNotes.TabIndex = 0;
            this.txtNotes.Text = "This is a free text box for your notes... it\'s saved with the sprites";
            // 
            // lblSpriteInfo
            // 
            this.lblSpriteInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpriteInfo.AutoSize = true;
            this.lblSpriteInfo.Location = new System.Drawing.Point(784, 637);
            this.lblSpriteInfo.Name = "lblSpriteInfo";
            this.lblSpriteInfo.Size = new System.Drawing.Size(7, 12);
            this.lblSpriteInfo.TabIndex = 6;
            this.lblSpriteInfo.Text = ".";
            // 
            // pnlMSXpal
            // 
            this.pnlMSXpal.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlMSXpal.Location = new System.Drawing.Point(648, 27);
            this.pnlMSXpal.Name = "pnlMSXpal";
            this.pnlMSXpal.Size = new System.Drawing.Size(433, 48);
            this.pnlMSXpal.TabIndex = 29;
            this.pnlMSXpal.Visible = false;
            // 
            // pnlNESpal
            // 
            this.pnlNESpal.BackColor = System.Drawing.SystemColors.Control;
            this.pnlNESpal.Location = new System.Drawing.Point(571, 31);
            this.pnlNESpal.Name = "pnlNESpal";
            this.pnlNESpal.Size = new System.Drawing.Size(433, 48);
            this.pnlNESpal.TabIndex = 28;
            this.pnlNESpal.Visible = false;
            // 
            // pnlC64pal
            // 
            this.pnlC64pal.Location = new System.Drawing.Point(639, 24);
            this.pnlC64pal.Name = "pnlC64pal";
            this.pnlC64pal.Size = new System.Drawing.Size(433, 48);
            this.pnlC64pal.TabIndex = 27;
            this.pnlC64pal.Visible = false;
            // 
            // pnlZXPalette
            // 
            this.pnlZXPalette.Location = new System.Drawing.Point(641, 30);
            this.pnlZXPalette.Name = "pnlZXPalette";
            this.pnlZXPalette.Size = new System.Drawing.Size(433, 48);
            this.pnlZXPalette.TabIndex = 26;
            this.pnlZXPalette.Visible = false;
            // 
            // BtnAltPal
            // 
            this.BtnAltPal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAltPal.Location = new System.Drawing.Point(991, 85);
            this.BtnAltPal.Name = "BtnAltPal";
            this.BtnAltPal.Size = new System.Drawing.Size(48, 48);
            this.BtnAltPal.TabIndex = 25;
            this.BtnAltPal.Text = "AltPal:  ";
            this.BtnAltPal.UseVisualStyleBackColor = true;
            this.BtnAltPal.Click += new System.EventHandler(this.BtnAltPal_Click);
            // 
            // tabSpriteTools
            // 
            this.tabSpriteTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSpriteTools.Controls.Add(this.tabSpriteOptions);
            this.tabSpriteTools.Controls.Add(this.tabPixelPaint);
            this.tabSpriteTools.Controls.Add(this.tabZXPaint);
            this.tabSpriteTools.Controls.Add(this.tabColorSwap);
            this.tabSpriteTools.Location = new System.Drawing.Point(786, 139);
            this.tabSpriteTools.Name = "tabSpriteTools";
            this.tabSpriteTools.SelectedIndex = 0;
            this.tabSpriteTools.Size = new System.Drawing.Size(251, 187);
            this.tabSpriteTools.TabIndex = 20;
            // 
            // tabSpriteOptions
            // 
            this.tabSpriteOptions.Controls.Add(this.chkFixedSize);
            this.tabSpriteOptions.Controls.Add(this.chkAligned);
            this.tabSpriteOptions.Controls.Add(this.label3);
            this.tabSpriteOptions.Controls.Add(this.label2);
            this.tabSpriteOptions.Controls.Add(this.txtSpriteSettings);
            this.tabSpriteOptions.Location = new System.Drawing.Point(4, 21);
            this.tabSpriteOptions.Name = "tabSpriteOptions";
            this.tabSpriteOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpriteOptions.Size = new System.Drawing.Size(243, 162);
            this.tabSpriteOptions.TabIndex = 0;
            this.tabSpriteOptions.Text = "Settings";
            this.tabSpriteOptions.UseVisualStyleBackColor = true;
            // 
            // chkFixedSize
            // 
            this.chkFixedSize.AutoSize = true;
            this.chkFixedSize.Location = new System.Drawing.Point(160, 13);
            this.chkFixedSize.Name = "chkFixedSize";
            this.chkFixedSize.Size = new System.Drawing.Size(73, 16);
            this.chkFixedSize.TabIndex = 4;
            this.chkFixedSize.Text = "FixedSize";
            this.chkFixedSize.UseVisualStyleBackColor = true;
            this.chkFixedSize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chkFixedSize_MouseUp);
            // 
            // chkAligned
            // 
            this.chkAligned.AutoSize = true;
            this.chkAligned.Location = new System.Drawing.Point(68, 13);
            this.chkAligned.Name = "chkAligned";
            this.chkAligned.Size = new System.Drawing.Size(90, 16);
            this.chkAligned.TabIndex = 0;
            this.chkAligned.Text = "Byte Aligned";
            this.chkAligned.UseVisualStyleBackColor = true;
            this.chkAligned.CheckedChanged += new System.EventHandler(this.chkAligned_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(65, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 52);
            this.label3.TabIndex = 3;
            this.label3.Text = "+128 = PSET\r\n+64 = DblHeight / nocolorZX\r\n+32 = SpeccyTransp\r\n+4/5 = CPC transp\r\n" +
                "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Settings";
            // 
            // txtSpriteSettings
            // 
            this.txtSpriteSettings.Location = new System.Drawing.Point(65, 34);
            this.txtSpriteSettings.Name = "txtSpriteSettings";
            this.txtSpriteSettings.Size = new System.Drawing.Size(92, 19);
            this.txtSpriteSettings.TabIndex = 2;
            this.txtSpriteSettings.TextChanged += new System.EventHandler(this.txtSpriteSettings_TextChanged);
            // 
            // tabPixelPaint
            // 
            this.tabPixelPaint.Controls.Add(this.label4);
            this.tabPixelPaint.Controls.Add(this.cboCheckMode);
            this.tabPixelPaint.Location = new System.Drawing.Point(4, 21);
            this.tabPixelPaint.Name = "tabPixelPaint";
            this.tabPixelPaint.Size = new System.Drawing.Size(243, 162);
            this.tabPixelPaint.TabIndex = 2;
            this.tabPixelPaint.Text = "PixelPaint";
            this.tabPixelPaint.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Check Mode";
            // 
            // cboCheckMode
            // 
            this.cboCheckMode.FormattingEnabled = true;
            this.cboCheckMode.Items.AddRange(new object[] {
            "Off",
            "1/3",
            "2/3",
            "3/3"});
            this.cboCheckMode.Location = new System.Drawing.Point(112, 18);
            this.cboCheckMode.Name = "cboCheckMode";
            this.cboCheckMode.Size = new System.Drawing.Size(112, 20);
            this.cboCheckMode.TabIndex = 0;
            this.cboCheckMode.Text = "Off";
            this.cboCheckMode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCheckMode_KeyPress);
            // 
            // tabZXPaint
            // 
            this.tabZXPaint.Controls.Add(this.label5);
            this.tabZXPaint.Controls.Add(this.cboZxPaintMode);
            this.tabZXPaint.Location = new System.Drawing.Point(4, 21);
            this.tabZXPaint.Name = "tabZXPaint";
            this.tabZXPaint.Size = new System.Drawing.Size(243, 162);
            this.tabZXPaint.TabIndex = 3;
            this.tabZXPaint.Text = "ZxPaint";
            this.tabZXPaint.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "ZX Paintmode";
            // 
            // cboZxPaintMode
            // 
            this.cboZxPaintMode.FormattingEnabled = true;
            this.cboZxPaintMode.Items.AddRange(new object[] {
            "Normal",
            "Colors",
            "PixelMap"});
            this.cboZxPaintMode.Location = new System.Drawing.Point(111, 15);
            this.cboZxPaintMode.Name = "cboZxPaintMode";
            this.cboZxPaintMode.Size = new System.Drawing.Size(121, 20);
            this.cboZxPaintMode.TabIndex = 0;
            this.cboZxPaintMode.Text = "Colors";
            this.cboZxPaintMode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCheckMode_KeyPress);
            // 
            // tabColorSwap
            // 
            this.tabColorSwap.Controls.Add(this.label7);
            this.tabColorSwap.Controls.Add(this.cboFillCheck);
            this.tabColorSwap.Controls.Add(this.cboColorConvertMode);
            this.tabColorSwap.Controls.Add(this.label6);
            this.tabColorSwap.Location = new System.Drawing.Point(4, 21);
            this.tabColorSwap.Name = "tabColorSwap";
            this.tabColorSwap.Size = new System.Drawing.Size(243, 162);
            this.tabColorSwap.TabIndex = 4;
            this.tabColorSwap.Text = "ColorSwap";
            this.tabColorSwap.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "Check Mode";
            // 
            // cboFillCheck
            // 
            this.cboFillCheck.FormattingEnabled = true;
            this.cboFillCheck.Items.AddRange(new object[] {
            "Off",
            "1/3",
            "2/3",
            "3/3"});
            this.cboFillCheck.Location = new System.Drawing.Point(105, 36);
            this.cboFillCheck.Name = "cboFillCheck";
            this.cboFillCheck.Size = new System.Drawing.Size(125, 20);
            this.cboFillCheck.TabIndex = 22;
            this.cboFillCheck.Text = "Off";
            // 
            // cboColorConvertMode
            // 
            this.cboColorConvertMode.FormattingEnabled = true;
            this.cboColorConvertMode.Items.AddRange(new object[] {
            "Block",
            "Sprite",
            "AllSprites"});
            this.cboColorConvertMode.Location = new System.Drawing.Point(105, 10);
            this.cboColorConvertMode.Name = "cboColorConvertMode";
            this.cboColorConvertMode.Size = new System.Drawing.Size(125, 20);
            this.cboColorConvertMode.TabIndex = 21;
            this.cboColorConvertMode.Text = "Block";
            this.cboColorConvertMode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCheckMode_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "ColorConversion";
            // 
            // btnNextBank
            // 
            this.btnNextBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextBank.Location = new System.Drawing.Point(986, 332);
            this.btnNextBank.Name = "btnNextBank";
            this.btnNextBank.Size = new System.Drawing.Size(48, 48);
            this.btnNextBank.TabIndex = 17;
            this.btnNextBank.Text = "Next Bank";
            this.toolTip1.SetToolTip(this.btnNextBank, "Last Bank (Cursor Up)");
            this.btnNextBank.UseVisualStyleBackColor = true;
            this.btnNextBank.Click += new System.EventHandler(this.btnNextBank_Click);
            // 
            // btnLastBank
            // 
            this.btnLastBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLastBank.Location = new System.Drawing.Point(934, 332);
            this.btnLastBank.Name = "btnLastBank";
            this.btnLastBank.Size = new System.Drawing.Size(48, 48);
            this.btnLastBank.TabIndex = 16;
            this.btnLastBank.Text = "Last Bank";
            this.toolTip1.SetToolTip(this.btnLastBank, "Last Bank (Cursor Down)");
            this.btnLastBank.UseVisualStyleBackColor = true;
            this.btnLastBank.Click += new System.EventHandler(this.btnLastBank_Click);
            // 
            // btnNextSprite
            // 
            this.btnNextSprite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextSprite.Location = new System.Drawing.Point(837, 332);
            this.btnNextSprite.Name = "btnNextSprite";
            this.btnNextSprite.Size = new System.Drawing.Size(48, 48);
            this.btnNextSprite.TabIndex = 14;
            this.btnNextSprite.Text = "Next Sprite";
            this.toolTip1.SetToolTip(this.btnNextSprite, "Next Sprite (Cursor Right)");
            this.btnNextSprite.UseVisualStyleBackColor = true;
            this.btnNextSprite.Click += new System.EventHandler(this.btnNextSprite_Click);
            // 
            // btnLastSprite
            // 
            this.btnLastSprite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLastSprite.Location = new System.Drawing.Point(785, 332);
            this.btnLastSprite.Name = "btnLastSprite";
            this.btnLastSprite.Size = new System.Drawing.Size(48, 48);
            this.btnLastSprite.TabIndex = 13;
            this.btnLastSprite.Text = "Last Sprite";
            this.toolTip1.SetToolTip(this.btnLastSprite, "Last Sprite (Cursor Left)");
            this.btnLastSprite.UseVisualStyleBackColor = true;
            this.btnLastSprite.Click += new System.EventHandler(this.btnLastSprite_Click);
            // 
            // btnSetPal
            // 
            this.btnSetPal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetPal.Location = new System.Drawing.Point(937, 85);
            this.btnSetPal.Name = "btnSetPal";
            this.btnSetPal.Size = new System.Drawing.Size(48, 48);
            this.btnSetPal.TabIndex = 4;
            this.btnSetPal.Text = "SetPal  ";
            this.btnSetPal.UseVisualStyleBackColor = true;
            this.btnSetPal.Click += new System.EventHandler(this.btnSetPal_Click);
            // 
            // tmrBackup
            // 
            this.tmrBackup.Tick += new System.EventHandler(this.tmrBackup_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem2,
            this.ViewToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.cPCToolStripMenuItem,
            this.mSXToolStripMenuItem,
            this.zXToolStripMenuItem,
            this.z80ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1039, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem2
            // 
            this.fileToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reSaveSpritesToolStripMenuItem,
            this.saveSpritesToolStripMenuItem,
            this.savePaletteToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.recentFilesToolStripMenuItem,
            this.loadPaletteToolStripMenuItem,
            this.loadPixelsToolStripMenuItem,
            this.importBackgroundToolStripMenuItem,
            this.saveBMPMapToolStripMenuItem,
            this.loadBMPMaToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem2.Name = "fileToolStripMenuItem2";
            this.fileToolStripMenuItem2.Size = new System.Drawing.Size(36, 20);
            this.fileToolStripMenuItem2.Text = "File";
            // 
            // reSaveSpritesToolStripMenuItem
            // 
            this.reSaveSpritesToolStripMenuItem.Enabled = false;
            this.reSaveSpritesToolStripMenuItem.Name = "reSaveSpritesToolStripMenuItem";
            this.reSaveSpritesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.reSaveSpritesToolStripMenuItem.Text = "ReSave Sprites";
            this.reSaveSpritesToolStripMenuItem.Click += new System.EventHandler(this.reSaveSpritesToolStripMenuItem_Click);
            // 
            // saveSpritesToolStripMenuItem
            // 
            this.saveSpritesToolStripMenuItem.Name = "saveSpritesToolStripMenuItem";
            this.saveSpritesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.saveSpritesToolStripMenuItem.Text = "Save Sprites As";
            this.saveSpritesToolStripMenuItem.Click += new System.EventHandler(this.saveSpritesToolStripMenuItem_Click);
            // 
            // savePaletteToolStripMenuItem
            // 
            this.savePaletteToolStripMenuItem.Name = "savePaletteToolStripMenuItem";
            this.savePaletteToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.savePaletteToolStripMenuItem.Text = "Save Palette";
            this.savePaletteToolStripMenuItem.Click += new System.EventHandler(this.savePaletteToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // recentFilesToolStripMenuItem
            // 
            this.recentFilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recent1,
            this.recent2,
            this.recent3,
            this.recent4,
            this.recent5,
            this.recent6,
            this.recent7,
            this.recent8,
            this.recent9,
            this.recent10});
            this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
            this.recentFilesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.recentFilesToolStripMenuItem.Text = "Load Recent";
            // 
            // recent1
            // 
            this.recent1.Name = "recent1";
            this.recent1.Size = new System.Drawing.Size(65, 22);
            this.recent1.Click += new System.EventHandler(this.recent1_Click);
            // 
            // recent2
            // 
            this.recent2.Name = "recent2";
            this.recent2.Size = new System.Drawing.Size(65, 22);
            this.recent2.Click += new System.EventHandler(this.recent2_Click);
            // 
            // recent3
            // 
            this.recent3.Name = "recent3";
            this.recent3.Size = new System.Drawing.Size(65, 22);
            this.recent3.Click += new System.EventHandler(this.recent3_Click);
            // 
            // recent4
            // 
            this.recent4.Name = "recent4";
            this.recent4.Size = new System.Drawing.Size(65, 22);
            this.recent4.Click += new System.EventHandler(this.recent4_Click);
            // 
            // recent5
            // 
            this.recent5.Name = "recent5";
            this.recent5.Size = new System.Drawing.Size(65, 22);
            this.recent5.Click += new System.EventHandler(this.recent5_Click);
            // 
            // recent6
            // 
            this.recent6.Name = "recent6";
            this.recent6.Size = new System.Drawing.Size(65, 22);
            this.recent6.Click += new System.EventHandler(this.recent6_Click);
            // 
            // recent7
            // 
            this.recent7.Name = "recent7";
            this.recent7.Size = new System.Drawing.Size(65, 22);
            this.recent7.Click += new System.EventHandler(this.recent7_Click);
            // 
            // recent8
            // 
            this.recent8.Name = "recent8";
            this.recent8.Size = new System.Drawing.Size(65, 22);
            this.recent8.Click += new System.EventHandler(this.recent8_Click);
            // 
            // recent9
            // 
            this.recent9.Name = "recent9";
            this.recent9.Size = new System.Drawing.Size(65, 22);
            this.recent9.Click += new System.EventHandler(this.recent9_Click);
            // 
            // recent10
            // 
            this.recent10.Name = "recent10";
            this.recent10.Size = new System.Drawing.Size(65, 22);
            this.recent10.Click += new System.EventHandler(this.recent10_Click);
            // 
            // loadPaletteToolStripMenuItem
            // 
            this.loadPaletteToolStripMenuItem.Name = "loadPaletteToolStripMenuItem";
            this.loadPaletteToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.loadPaletteToolStripMenuItem.Text = "Inport Palette";
            this.loadPaletteToolStripMenuItem.Click += new System.EventHandler(this.loadPaletteToolStripMenuItem_Click);
            // 
            // loadPixelsToolStripMenuItem
            // 
            this.loadPixelsToolStripMenuItem.Name = "loadPixelsToolStripMenuItem";
            this.loadPixelsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.loadPixelsToolStripMenuItem.Text = "Inport Pixels";
            this.loadPixelsToolStripMenuItem.Click += new System.EventHandler(this.loadPixelsToolStripMenuItem_Click);
            // 
            // importBackgroundToolStripMenuItem
            // 
            this.importBackgroundToolStripMenuItem.Name = "importBackgroundToolStripMenuItem";
            this.importBackgroundToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.importBackgroundToolStripMenuItem.Text = "Inport ColorAttribs";
            this.importBackgroundToolStripMenuItem.Click += new System.EventHandler(this.importBackgroundToolStripMenuItem_Click);
            // 
            // saveBMPMapToolStripMenuItem
            // 
            this.saveBMPMapToolStripMenuItem.Name = "saveBMPMapToolStripMenuItem";
            this.saveBMPMapToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.saveBMPMapToolStripMenuItem.Text = "Save BMP Map";
            this.saveBMPMapToolStripMenuItem.Click += new System.EventHandler(this.saveBMPMapToolStripMenuItem_Click);
            // 
            // loadBMPMaToolStripMenuItem
            // 
            this.loadBMPMaToolStripMenuItem.Name = "loadBMPMaToolStripMenuItem";
            this.loadBMPMaToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.loadBMPMaToolStripMenuItem.Text = "Load BMP Map";
            this.loadBMPMaToolStripMenuItem.Click += new System.EventHandler(this.loadBMPMaToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ViewToolStripMenuItem
            // 
            this.ViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mSX16ColorToolStripMenuItem,
            this.cPC4ColorToolStripMenuItem,
            this.colorpairsCPCENTToolStripMenuItem,
            this.colorditheredCPCENTToolStripMenuItem,
            this.zX2ColorToolStripMenuItem,
            this.colorditheredToolStripMenuItem,
            this.toolStripMenuItem4,
            this.cPC16ColorToolStripMenuItem,
            this.toolStripMenuItem3,
            this.highVisToggleToolStripMenuItem,
            this.overlayLastFrameToolStripMenuItem,
            this.overlayNextFrameToolStripMenuItem,
            this.toolStripMenuItem6,
            this.applyViewColorConversionToolStripMenuItem});
            this.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
            this.ViewToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.ViewToolStripMenuItem.Text = "View";
            // 
            // mSX16ColorToolStripMenuItem
            // 
            this.mSX16ColorToolStripMenuItem.Name = "mSX16ColorToolStripMenuItem";
            this.mSX16ColorToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.mSX16ColorToolStripMenuItem.Text = "16 Color";
            this.mSX16ColorToolStripMenuItem.Click += new System.EventHandler(this.mSX16ColorToolStripMenuItem_Click);
            // 
            // cPC4ColorToolStripMenuItem
            // 
            this.cPC4ColorToolStripMenuItem.Name = "cPC4ColorToolStripMenuItem";
            this.cPC4ColorToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.cPC4ColorToolStripMenuItem.Text = "4 Color";
            this.cPC4ColorToolStripMenuItem.Click += new System.EventHandler(this.cPC4ColorToolStripMenuItem_Click);
            // 
            // colorpairsCPCENTToolStripMenuItem
            // 
            this.colorpairsCPCENTToolStripMenuItem.Name = "colorpairsCPCENTToolStripMenuItem";
            this.colorpairsCPCENTToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.colorpairsCPCENTToolStripMenuItem.Text = "4 Color (pairs) ";
            this.colorpairsCPCENTToolStripMenuItem.Click += new System.EventHandler(this.colorpairsCPCENTToolStripMenuItem_Click);
            // 
            // colorditheredCPCENTToolStripMenuItem
            // 
            this.colorditheredCPCENTToolStripMenuItem.Name = "colorditheredCPCENTToolStripMenuItem";
            this.colorditheredCPCENTToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.colorditheredCPCENTToolStripMenuItem.Text = "4 Color (dithered)";
            this.colorditheredCPCENTToolStripMenuItem.Click += new System.EventHandler(this.colorditheredCPCENTToolStripMenuItem_Click);
            // 
            // zX2ColorToolStripMenuItem
            // 
            this.zX2ColorToolStripMenuItem.Name = "zX2ColorToolStripMenuItem";
            this.zX2ColorToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.zX2ColorToolStripMenuItem.Text = "2 Color";
            this.zX2ColorToolStripMenuItem.Click += new System.EventHandler(this.zX2ColorToolStripMenuItem_Click);
            // 
            // colorditheredToolStripMenuItem
            // 
            this.colorditheredToolStripMenuItem.Name = "colorditheredToolStripMenuItem";
            this.colorditheredToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.colorditheredToolStripMenuItem.Text = "2 Color (dithered)";
            this.colorditheredToolStripMenuItem.Click += new System.EventHandler(this.colorditheredToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(217, 6);
            // 
            // cPC16ColorToolStripMenuItem
            // 
            this.cPC16ColorToolStripMenuItem.Name = "cPC16ColorToolStripMenuItem";
            this.cPC16ColorToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.cPC16ColorToolStripMenuItem.Text = "HalfWidth 16 Color (CPC)";
            this.cPC16ColorToolStripMenuItem.Click += new System.EventHandler(this.cPC16ColorToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(217, 6);
            // 
            // highVisToggleToolStripMenuItem
            // 
            this.highVisToggleToolStripMenuItem.Name = "highVisToggleToolStripMenuItem";
            this.highVisToggleToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.highVisToggleToolStripMenuItem.Text = "HighVis Toggle";
            this.highVisToggleToolStripMenuItem.Click += new System.EventHandler(this.highVisToggleToolStripMenuItem_Click);
            // 
            // overlayLastFrameToolStripMenuItem
            // 
            this.overlayLastFrameToolStripMenuItem.Name = "overlayLastFrameToolStripMenuItem";
            this.overlayLastFrameToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.overlayLastFrameToolStripMenuItem.Text = "Overlay LastFrame";
            this.overlayLastFrameToolStripMenuItem.Click += new System.EventHandler(this.overlayLastFrameToolStripMenuItem_Click);
            // 
            // overlayNextFrameToolStripMenuItem
            // 
            this.overlayNextFrameToolStripMenuItem.Name = "overlayNextFrameToolStripMenuItem";
            this.overlayNextFrameToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.overlayNextFrameToolStripMenuItem.Text = "Overlay NextFrame";
            this.overlayNextFrameToolStripMenuItem.Click += new System.EventHandler(this.overlayNextFrameToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(217, 6);
            // 
            // applyViewColorConversionToolStripMenuItem
            // 
            this.applyViewColorConversionToolStripMenuItem.Name = "applyViewColorConversionToolStripMenuItem";
            this.applyViewColorConversionToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.applyViewColorConversionToolStripMenuItem.Text = "Apply View Color Conversion";
            this.applyViewColorConversionToolStripMenuItem.Click += new System.EventHandler(this.applyViewColorConversionToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardToolStripMenuItem,
            this.pasteToClipToolStripMenuItem,
            this.copyPreviewToolStripMenuItem,
            this.canvasSizeToolStripMenuItem,
            this.duplicateFromToolStripMenuItem,
            this.duplicateOffsetFromToolStripMenuItem,
            this.makeTilesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy to Clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // pasteToClipToolStripMenuItem
            // 
            this.pasteToClipToolStripMenuItem.Name = "pasteToClipToolStripMenuItem";
            this.pasteToClipToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToClipToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.pasteToClipToolStripMenuItem.Text = "Paste from Clipboard";
            this.pasteToClipToolStripMenuItem.Click += new System.EventHandler(this.pasteToClipToolStripMenuItem_Click);
            // 
            // copyPreviewToolStripMenuItem
            // 
            this.copyPreviewToolStripMenuItem.Name = "copyPreviewToolStripMenuItem";
            this.copyPreviewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.C)));
            this.copyPreviewToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.copyPreviewToolStripMenuItem.Text = "Copy Preview";
            this.copyPreviewToolStripMenuItem.Click += new System.EventHandler(this.copyPreviewToolStripMenuItem_Click);
            // 
            // canvasSizeToolStripMenuItem
            // 
            this.canvasSizeToolStripMenuItem.Name = "canvasSizeToolStripMenuItem";
            this.canvasSizeToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.canvasSizeToolStripMenuItem.Text = "Canvas Size";
            this.canvasSizeToolStripMenuItem.Click += new System.EventHandler(this.canvasSizeToolStripMenuItem_Click);
            // 
            // duplicateFromToolStripMenuItem
            // 
            this.duplicateFromToolStripMenuItem.Name = "duplicateFromToolStripMenuItem";
            this.duplicateFromToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.duplicateFromToolStripMenuItem.Text = "Duplicate From";
            this.duplicateFromToolStripMenuItem.Click += new System.EventHandler(this.duplicateFromToolStripMenuItem_Click);
            // 
            // duplicateOffsetFromToolStripMenuItem
            // 
            this.duplicateOffsetFromToolStripMenuItem.Name = "duplicateOffsetFromToolStripMenuItem";
            this.duplicateOffsetFromToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.duplicateOffsetFromToolStripMenuItem.Text = "Duplicate Offset From";
            this.duplicateOffsetFromToolStripMenuItem.Click += new System.EventHandler(this.duplicateOffsetFromToolStripMenuItem_Click);
            // 
            // makeTilesToolStripMenuItem
            // 
            this.makeTilesToolStripMenuItem.Name = "makeTilesToolStripMenuItem";
            this.makeTilesToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.makeTilesToolStripMenuItem.Text = "Make Tiles";
            this.makeTilesToolStripMenuItem.Click += new System.EventHandler(this.makeTilesToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transformToolStripMenuItem,
            this.yInterlaceToolStripMenuItem,
            this.setAllAttribsToolStripMenuItem,
            this.blackBorderToolStripMenuItem,
            this.blackBorderTightToolStripMenuItem,
            this.PaletteTint});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // transformToolStripMenuItem
            // 
            this.transformToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flipXToolStripMenuItem,
            this.flipYToolStripMenuItem,
            this.pxShiftToolStripMenuItem,
            this.pixelShiftRightToolStripMenuItem,
            this.pixelShiftUpToolStripMenuItem,
            this.pixelShiftDownToolStripMenuItem,
            this.tileShiftXToolStripMenuItem});
            this.transformToolStripMenuItem.Name = "transformToolStripMenuItem";
            this.transformToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.transformToolStripMenuItem.Text = "Transform";
            // 
            // flipXToolStripMenuItem
            // 
            this.flipXToolStripMenuItem.Name = "flipXToolStripMenuItem";
            this.flipXToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.flipXToolStripMenuItem.Text = "FlipX";
            this.flipXToolStripMenuItem.Click += new System.EventHandler(this.flipXToolStripMenuItem_Click);
            // 
            // flipYToolStripMenuItem
            // 
            this.flipYToolStripMenuItem.Name = "flipYToolStripMenuItem";
            this.flipYToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.flipYToolStripMenuItem.Text = "FlipY";
            this.flipYToolStripMenuItem.Click += new System.EventHandler(this.flipYToolStripMenuItem_Click);
            // 
            // pxShiftToolStripMenuItem
            // 
            this.pxShiftToolStripMenuItem.Name = "pxShiftToolStripMenuItem";
            this.pxShiftToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pxShiftToolStripMenuItem.Text = "Pixel Shift Left";
            this.pxShiftToolStripMenuItem.Click += new System.EventHandler(this.pxShiftToolStripMenuItem_Click);
            // 
            // pixelShiftRightToolStripMenuItem
            // 
            this.pixelShiftRightToolStripMenuItem.Name = "pixelShiftRightToolStripMenuItem";
            this.pixelShiftRightToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pixelShiftRightToolStripMenuItem.Text = "Pixel Shift Right";
            this.pixelShiftRightToolStripMenuItem.Click += new System.EventHandler(this.pixelShiftRightToolStripMenuItem_Click);
            // 
            // pixelShiftUpToolStripMenuItem
            // 
            this.pixelShiftUpToolStripMenuItem.Name = "pixelShiftUpToolStripMenuItem";
            this.pixelShiftUpToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pixelShiftUpToolStripMenuItem.Text = "Pixel Shift Up";
            this.pixelShiftUpToolStripMenuItem.Click += new System.EventHandler(this.pixelShiftUpToolStripMenuItem_Click);
            // 
            // pixelShiftDownToolStripMenuItem
            // 
            this.pixelShiftDownToolStripMenuItem.Name = "pixelShiftDownToolStripMenuItem";
            this.pixelShiftDownToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pixelShiftDownToolStripMenuItem.Text = "Pixel Shift Down";
            this.pixelShiftDownToolStripMenuItem.Click += new System.EventHandler(this.pixelShiftDownToolStripMenuItem_Click);
            // 
            // tileShiftXToolStripMenuItem
            // 
            this.tileShiftXToolStripMenuItem.Name = "tileShiftXToolStripMenuItem";
            this.tileShiftXToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.tileShiftXToolStripMenuItem.Text = "TileShiftX";
            this.tileShiftXToolStripMenuItem.Click += new System.EventHandler(this.tileShiftXToolStripMenuItem_Click);
            // 
            // yInterlaceToolStripMenuItem
            // 
            this.yInterlaceToolStripMenuItem.Name = "yInterlaceToolStripMenuItem";
            this.yInterlaceToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.yInterlaceToolStripMenuItem.Text = "Interlace-Y";
            this.yInterlaceToolStripMenuItem.Click += new System.EventHandler(this.yInterlaceToolStripMenuItem_Click);
            // 
            // setAllAttribsToolStripMenuItem
            // 
            this.setAllAttribsToolStripMenuItem.Name = "setAllAttribsToolStripMenuItem";
            this.setAllAttribsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.setAllAttribsToolStripMenuItem.Text = "SetAllAttribs";
            this.setAllAttribsToolStripMenuItem.Click += new System.EventHandler(this.setAllAttribsToolStripMenuItem_Click);
            // 
            // blackBorderToolStripMenuItem
            // 
            this.blackBorderToolStripMenuItem.Name = "blackBorderToolStripMenuItem";
            this.blackBorderToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.blackBorderToolStripMenuItem.Text = "BlackBorder";
            this.blackBorderToolStripMenuItem.Click += new System.EventHandler(this.blackBorderToolStripMenuItem_Click);
            // 
            // blackBorderTightToolStripMenuItem
            // 
            this.blackBorderTightToolStripMenuItem.Name = "blackBorderTightToolStripMenuItem";
            this.blackBorderTightToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.blackBorderTightToolStripMenuItem.Text = "BlackBorder Tight";
            this.blackBorderTightToolStripMenuItem.Click += new System.EventHandler(this.blackBorderTightToolStripMenuItem_Click);
            // 
            // PaletteTint
            // 
            this.PaletteTint.Name = "PaletteTint";
            this.PaletteTint.Size = new System.Drawing.Size(163, 22);
            this.PaletteTint.Text = "Palette Tint";
            this.PaletteTint.Click += new System.EventHandler(this.PaletteTint_Click);
            // 
            // cPCToolStripMenuItem
            // 
            this.cPCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem3,
            this.spriteCompilerToolStripMenuItem,
            this.saveASMPaletteToolStripMenuItem});
            this.cPCToolStripMenuItem.Name = "cPCToolStripMenuItem";
            this.cPCToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.cPCToolStripMenuItem.Text = "<CPC>";
            // 
            // fileToolStripMenuItem3
            // 
            this.fileToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadCPCBinaryToolStripMenuItem,
            this.saveCPCBinaryToolStripMenuItem1,
            this.loadCPCBinaryToolStripMenuItem1,
            this.saveCPCBinaryToolStripMenuItem,
            this.SaveCPCRawBmp,
            this.saveCPCZigTileToolStripMenuItem,
            this.saveCPCSCRToolStripMenuItem,
            this.rLEASMToolStripMenuItem});
            this.fileToolStripMenuItem3.Name = "fileToolStripMenuItem3";
            this.fileToolStripMenuItem3.Size = new System.Drawing.Size(163, 22);
            this.fileToolStripMenuItem3.Text = "File";
            // 
            // loadCPCBinaryToolStripMenuItem
            // 
            this.loadCPCBinaryToolStripMenuItem.Name = "loadCPCBinaryToolStripMenuItem";
            this.loadCPCBinaryToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.loadCPCBinaryToolStripMenuItem.Text = "Load CPC+ Binary";
            this.loadCPCBinaryToolStripMenuItem.Click += new System.EventHandler(this.loadCPCBinaryToolStripMenuItem_Click);
            // 
            // saveCPCBinaryToolStripMenuItem1
            // 
            this.saveCPCBinaryToolStripMenuItem1.Name = "saveCPCBinaryToolStripMenuItem1";
            this.saveCPCBinaryToolStripMenuItem1.Size = new System.Drawing.Size(199, 22);
            this.saveCPCBinaryToolStripMenuItem1.Text = "Save CPC+ Binary";
            this.saveCPCBinaryToolStripMenuItem1.Click += new System.EventHandler(this.saveCPCBinaryToolStripMenuItem1_Click);
            // 
            // loadCPCBinaryToolStripMenuItem1
            // 
            this.loadCPCBinaryToolStripMenuItem1.Name = "loadCPCBinaryToolStripMenuItem1";
            this.loadCPCBinaryToolStripMenuItem1.Size = new System.Drawing.Size(199, 22);
            this.loadCPCBinaryToolStripMenuItem1.Text = "Load CPC Binary";
            this.loadCPCBinaryToolStripMenuItem1.Click += new System.EventHandler(this.loadCPCBinaryToolStripMenuItem1_Click);
            // 
            // saveCPCBinaryToolStripMenuItem
            // 
            this.saveCPCBinaryToolStripMenuItem.Name = "saveCPCBinaryToolStripMenuItem";
            this.saveCPCBinaryToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.saveCPCBinaryToolStripMenuItem.Text = "Save CPC Binary Sprites";
            this.saveCPCBinaryToolStripMenuItem.Click += new System.EventHandler(this.saveCPCBinaryToolStripMenuItem_Click);
            // 
            // SaveCPCRawBmp
            // 
            this.SaveCPCRawBmp.Name = "SaveCPCRawBmp";
            this.SaveCPCRawBmp.Size = new System.Drawing.Size(199, 22);
            this.SaveCPCRawBmp.Text = "Save RAW Bitmap";
            this.SaveCPCRawBmp.Click += new System.EventHandler(this.SaveCPCRawBmp_Click);
            // 
            // saveCPCZigTileToolStripMenuItem
            // 
            this.saveCPCZigTileToolStripMenuItem.Name = "saveCPCZigTileToolStripMenuItem";
            this.saveCPCZigTileToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.saveCPCZigTileToolStripMenuItem.Text = "Save CPC ZigTile";
            this.saveCPCZigTileToolStripMenuItem.Click += new System.EventHandler(this.saveCPCZigTileToolStripMenuItem_Click);
            // 
            // saveCPCSCRToolStripMenuItem
            // 
            this.saveCPCSCRToolStripMenuItem.Name = "saveCPCSCRToolStripMenuItem";
            this.saveCPCSCRToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.saveCPCSCRToolStripMenuItem.Text = "Save CPC SCR";
            this.saveCPCSCRToolStripMenuItem.Click += new System.EventHandler(this.saveCPCSCRToolStripMenuItem_Click);
            // 
            // rLEASMToolStripMenuItem
            // 
            this.rLEASMToolStripMenuItem.Name = "rLEASMToolStripMenuItem";
            this.rLEASMToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.rLEASMToolStripMenuItem.Text = "RLE ASM";
            this.rLEASMToolStripMenuItem.Click += new System.EventHandler(this.rLEASMToolStripMenuItem_Click);
            // 
            // spriteCompilerToolStripMenuItem
            // 
            this.spriteCompilerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOneToolStripMenuItem,
            this.CpcSpriteConvaddOneDiffToolStripMenuItem,
            this.CpcSpriteCompilerClear});
            this.spriteCompilerToolStripMenuItem.Name = "spriteCompilerToolStripMenuItem";
            this.spriteCompilerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.spriteCompilerToolStripMenuItem.Text = "SpriteCompiler";
            // 
            // addOneToolStripMenuItem
            // 
            this.addOneToolStripMenuItem.Name = "addOneToolStripMenuItem";
            this.addOneToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.addOneToolStripMenuItem.Text = "AddOne";
            this.addOneToolStripMenuItem.Click += new System.EventHandler(this.addOneToolStripMenuItem_Click);
            // 
            // CpcSpriteConvaddOneDiffToolStripMenuItem
            // 
            this.CpcSpriteConvaddOneDiffToolStripMenuItem.Name = "CpcSpriteConvaddOneDiffToolStripMenuItem";
            this.CpcSpriteConvaddOneDiffToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.CpcSpriteConvaddOneDiffToolStripMenuItem.Text = "AddOneDiff";
            this.CpcSpriteConvaddOneDiffToolStripMenuItem.Click += new System.EventHandler(this.CpcSpriteConvaddOneDiffToolStripMenuItem_Click);
            // 
            // CpcSpriteCompilerClear
            // 
            this.CpcSpriteCompilerClear.Name = "CpcSpriteCompilerClear";
            this.CpcSpriteCompilerClear.Size = new System.Drawing.Size(129, 22);
            this.CpcSpriteCompilerClear.Text = "Clear";
            this.CpcSpriteCompilerClear.Click += new System.EventHandler(this.CpcSpriteCompilerClear_Click);
            // 
            // saveASMPaletteToolStripMenuItem
            // 
            this.saveASMPaletteToolStripMenuItem.Name = "saveASMPaletteToolStripMenuItem";
            this.saveASMPaletteToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveASMPaletteToolStripMenuItem.Text = "Save ASM Palette";
            this.saveASMPaletteToolStripMenuItem.Click += new System.EventHandler(this.saveASMPaletteToolStripMenuItem_Click);
            // 
            // mSXToolStripMenuItem
            // 
            this.mSXToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1});
            this.mSXToolStripMenuItem.Name = "mSXToolStripMenuItem";
            this.mSXToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.mSXToolStripMenuItem.Text = "<MSX>";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMSXASMPaletteToolStripMenuItem,
            this.saveMSXBinaryToolStripMenuItem,
            this.bMPToolStripMenuItem,
            this.rLEToolStripMenuItem,
            this.saveRAWBitmapToolStripMenuItem3,
            this.saveRAWMSX1BitmapToolStripMenuItem,
            this.saveRAWMSX1Raw16x16SpriteToolStripMenuItem,
            this.saveRawVdpTileBitmapToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(89, 22);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // saveMSXASMPaletteToolStripMenuItem
            // 
            this.saveMSXASMPaletteToolStripMenuItem.Name = "saveMSXASMPaletteToolStripMenuItem";
            this.saveMSXASMPaletteToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.saveMSXASMPaletteToolStripMenuItem.Text = "Save MSX ASM Palette";
            this.saveMSXASMPaletteToolStripMenuItem.Click += new System.EventHandler(this.saveMSXASMPaletteToolStripMenuItem_Click);
            // 
            // saveMSXBinaryToolStripMenuItem
            // 
            this.saveMSXBinaryToolStripMenuItem.Name = "saveMSXBinaryToolStripMenuItem";
            this.saveMSXBinaryToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.saveMSXBinaryToolStripMenuItem.Text = "Save MSX Binary Sprites";
            this.saveMSXBinaryToolStripMenuItem.Visible = false;
            this.saveMSXBinaryToolStripMenuItem.Click += new System.EventHandler(this.saveMSXBinaryToolStripMenuItem_Click);
            // 
            // bMPToolStripMenuItem
            // 
            this.bMPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMSXBitmapToolStripMenuItem1,
            this.saveMSXBitmapWithPaletteToolStripMenuItem1,
            this.saveMSXBitmapSpritesToolStripMenuItem});
            this.bMPToolStripMenuItem.Name = "bMPToolStripMenuItem";
            this.bMPToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.bMPToolStripMenuItem.Text = "BMP";
            this.bMPToolStripMenuItem.Visible = false;
            // 
            // saveMSXBitmapToolStripMenuItem1
            // 
            this.saveMSXBitmapToolStripMenuItem1.Name = "saveMSXBitmapToolStripMenuItem1";
            this.saveMSXBitmapToolStripMenuItem1.Size = new System.Drawing.Size(228, 22);
            this.saveMSXBitmapToolStripMenuItem1.Text = "save MSX bitmap";
            this.saveMSXBitmapToolStripMenuItem1.Click += new System.EventHandler(this.saveMSXBitmapToolStripMenuItem1_Click);
            // 
            // saveMSXBitmapWithPaletteToolStripMenuItem1
            // 
            this.saveMSXBitmapWithPaletteToolStripMenuItem1.Name = "saveMSXBitmapWithPaletteToolStripMenuItem1";
            this.saveMSXBitmapWithPaletteToolStripMenuItem1.Size = new System.Drawing.Size(228, 22);
            this.saveMSXBitmapWithPaletteToolStripMenuItem1.Text = "Save MSX Bitmap With Palette";
            this.saveMSXBitmapWithPaletteToolStripMenuItem1.Click += new System.EventHandler(this.saveMSXBitmapWithPaletteToolStripMenuItem1_Click);
            // 
            // saveMSXBitmapSpritesToolStripMenuItem
            // 
            this.saveMSXBitmapSpritesToolStripMenuItem.Name = "saveMSXBitmapSpritesToolStripMenuItem";
            this.saveMSXBitmapSpritesToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.saveMSXBitmapSpritesToolStripMenuItem.Text = "save MSX Bitmap Sprites";
            this.saveMSXBitmapSpritesToolStripMenuItem.Click += new System.EventHandler(this.saveMSXBitmapSpritesToolStripMenuItem_Click);
            // 
            // rLEToolStripMenuItem
            // 
            this.rLEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildRLEASMToolStripMenuItem,
            this.saveMSXRLEToolStripMenuItem,
            this.saveMSXRLEPaletteToolStripMenuItem,
            this.toolStripMenuItem5,
            this.saveMSXRLESpritesToolStripMenuItem});
            this.rLEToolStripMenuItem.Name = "rLEToolStripMenuItem";
            this.rLEToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.rLEToolStripMenuItem.Text = "RLE";
            // 
            // buildRLEASMToolStripMenuItem
            // 
            this.buildRLEASMToolStripMenuItem.Name = "buildRLEASMToolStripMenuItem";
            this.buildRLEASMToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.buildRLEASMToolStripMenuItem.Text = "Build RLE ASM";
            this.buildRLEASMToolStripMenuItem.Visible = false;
            this.buildRLEASMToolStripMenuItem.Click += new System.EventHandler(this.buildRLEASMToolStripMenuItem_Click);
            // 
            // saveMSXRLEToolStripMenuItem
            // 
            this.saveMSXRLEToolStripMenuItem.Name = "saveMSXRLEToolStripMenuItem";
            this.saveMSXRLEToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.saveMSXRLEToolStripMenuItem.Text = "Save MSX RLE";
            this.saveMSXRLEToolStripMenuItem.Click += new System.EventHandler(this.saveMSXRLEToolStripMenuItem_Click);
            // 
            // saveMSXRLEPaletteToolStripMenuItem
            // 
            this.saveMSXRLEPaletteToolStripMenuItem.Name = "saveMSXRLEPaletteToolStripMenuItem";
            this.saveMSXRLEPaletteToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.saveMSXRLEPaletteToolStripMenuItem.Text = "Save MSX RLE with Palette";
            this.saveMSXRLEPaletteToolStripMenuItem.Click += new System.EventHandler(this.saveMSXRLEPaletteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(209, 6);
            // 
            // saveMSXRLESpritesToolStripMenuItem
            // 
            this.saveMSXRLESpritesToolStripMenuItem.Name = "saveMSXRLESpritesToolStripMenuItem";
            this.saveMSXRLESpritesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.saveMSXRLESpritesToolStripMenuItem.Text = "Save MSX RLE Sprites";
            this.saveMSXRLESpritesToolStripMenuItem.Click += new System.EventHandler(this.saveMSXRLESpritesToolStripMenuItem_Click);
            // 
            // saveRAWBitmapToolStripMenuItem3
            // 
            this.saveRAWBitmapToolStripMenuItem3.Name = "saveRAWBitmapToolStripMenuItem3";
            this.saveRAWBitmapToolStripMenuItem3.Size = new System.Drawing.Size(262, 22);
            this.saveRAWBitmapToolStripMenuItem3.Text = "Save RAW Bitmap";
            this.saveRAWBitmapToolStripMenuItem3.Click += new System.EventHandler(this.saveRAWBitmapToolStripMenuItem3_Click);
            // 
            // saveRAWMSX1BitmapToolStripMenuItem
            // 
            this.saveRAWMSX1BitmapToolStripMenuItem.Name = "saveRAWMSX1BitmapToolStripMenuItem";
            this.saveRAWMSX1BitmapToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.saveRAWMSX1BitmapToolStripMenuItem.Text = "Save RAW MSX1 Bitmap / 8x8 sprite";
            this.saveRAWMSX1BitmapToolStripMenuItem.Click += new System.EventHandler(this.saveRAWMSX1BitmapToolStripMenuItem_Click);
            // 
            // saveRAWMSX1Raw16x16SpriteToolStripMenuItem
            // 
            this.saveRAWMSX1Raw16x16SpriteToolStripMenuItem.Name = "saveRAWMSX1Raw16x16SpriteToolStripMenuItem";
            this.saveRAWMSX1Raw16x16SpriteToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.saveRAWMSX1Raw16x16SpriteToolStripMenuItem.Text = "Save RAW MSX1 16x16 Sprite";
            this.saveRAWMSX1Raw16x16SpriteToolStripMenuItem.Click += new System.EventHandler(this.saveRAWMSX1Raw16x16SpriteToolStripMenuItem_Click);
            // 
            // saveRawVdpTileBitmapToolStripMenuItem
            // 
            this.saveRawVdpTileBitmapToolStripMenuItem.Name = "saveRawVdpTileBitmapToolStripMenuItem";
            this.saveRawVdpTileBitmapToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.saveRawVdpTileBitmapToolStripMenuItem.Text = "Save Raw MSX2 VdpTile Bitmap";
            this.saveRawVdpTileBitmapToolStripMenuItem.Click += new System.EventHandler(this.saveRawVdpTileBitmapToolStripMenuItem_Click);
            // 
            // zXToolStripMenuItem
            // 
            this.zXToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem1,
            this.spriteCompilerToolStripMenuItem2,
            this.pasteZXToolStripMenuItem});
            this.zXToolStripMenuItem.Name = "zXToolStripMenuItem";
            this.zXToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.zXToolStripMenuItem.Text = "<ZX>";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSpectrumScreenToolStripMenuItem,
            this.saveSpectrumBinaryToolStripMenuItem1,
            this.saveSpectrumTilesToolStripMenuItem,
            this.saveSpectrumFontToolStripMenuItem,
            this.saveSpectrumScreenToolStripMenuItem,
            this.saveRawBitmapToolStripMenuItem4,
            this.rLEASMToolStripMenuItem1,
            this.rLEASMCOLORToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadSpectrumScreenToolStripMenuItem
            // 
            this.loadSpectrumScreenToolStripMenuItem.Name = "loadSpectrumScreenToolStripMenuItem";
            this.loadSpectrumScreenToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.loadSpectrumScreenToolStripMenuItem.Text = "Load Spectrum Screen";
            this.loadSpectrumScreenToolStripMenuItem.Click += new System.EventHandler(this.loadSpectrumScreenToolStripMenuItem_Click);
            // 
            // saveSpectrumBinaryToolStripMenuItem1
            // 
            this.saveSpectrumBinaryToolStripMenuItem1.Name = "saveSpectrumBinaryToolStripMenuItem1";
            this.saveSpectrumBinaryToolStripMenuItem1.Size = new System.Drawing.Size(224, 22);
            this.saveSpectrumBinaryToolStripMenuItem1.Text = "Save Spectrum Binary Sprites";
            this.saveSpectrumBinaryToolStripMenuItem1.Click += new System.EventHandler(this.saveSpectrumBinaryToolStripMenuItem1_Click);
            // 
            // saveSpectrumTilesToolStripMenuItem
            // 
            this.saveSpectrumTilesToolStripMenuItem.Name = "saveSpectrumTilesToolStripMenuItem";
            this.saveSpectrumTilesToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.saveSpectrumTilesToolStripMenuItem.Text = "Save Spectrum Tiles";
            this.saveSpectrumTilesToolStripMenuItem.Click += new System.EventHandler(this.saveSpectrumTilesToolStripMenuItem_Click);
            // 
            // saveSpectrumFontToolStripMenuItem
            // 
            this.saveSpectrumFontToolStripMenuItem.Name = "saveSpectrumFontToolStripMenuItem";
            this.saveSpectrumFontToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.saveSpectrumFontToolStripMenuItem.Text = "Save 2 Bit Spectrum Font";
            this.saveSpectrumFontToolStripMenuItem.Click += new System.EventHandler(this.saveSpectrumFontToolStripMenuItem_Click);
            // 
            // saveSpectrumScreenToolStripMenuItem
            // 
            this.saveSpectrumScreenToolStripMenuItem.Name = "saveSpectrumScreenToolStripMenuItem";
            this.saveSpectrumScreenToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.saveSpectrumScreenToolStripMenuItem.Text = "Save Spectrum Screen";
            this.saveSpectrumScreenToolStripMenuItem.Click += new System.EventHandler(this.saveSpectrumScreenToolStripMenuItem_Click);
            // 
            // saveRawBitmapToolStripMenuItem4
            // 
            this.saveRawBitmapToolStripMenuItem4.Name = "saveRawBitmapToolStripMenuItem4";
            this.saveRawBitmapToolStripMenuItem4.Size = new System.Drawing.Size(224, 22);
            this.saveRawBitmapToolStripMenuItem4.Text = "Save Raw Bitmap";
            this.saveRawBitmapToolStripMenuItem4.Click += new System.EventHandler(this.saveRawBitmapToolStripMenuItem4_Click);
            // 
            // rLEASMToolStripMenuItem1
            // 
            this.rLEASMToolStripMenuItem1.Name = "rLEASMToolStripMenuItem1";
            this.rLEASMToolStripMenuItem1.Size = new System.Drawing.Size(224, 22);
            this.rLEASMToolStripMenuItem1.Text = "RLE ASM";
            this.rLEASMToolStripMenuItem1.Visible = false;
            // 
            // rLEASMCOLORToolStripMenuItem
            // 
            this.rLEASMCOLORToolStripMenuItem.Name = "rLEASMCOLORToolStripMenuItem";
            this.rLEASMCOLORToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.rLEASMCOLORToolStripMenuItem.Text = "RLE ASM COLOR";
            this.rLEASMCOLORToolStripMenuItem.Click += new System.EventHandler(this.rLEASMCOLORToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem1
            // 
            this.toolsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fourColor2ToolStripMenuItem,
            this.invertZXToolStripMenuItem1,
            this.halfSizeFontToolStripMenuItem});
            this.toolsToolStripMenuItem1.Name = "toolsToolStripMenuItem1";
            this.toolsToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.toolsToolStripMenuItem1.Text = "Tools";
            // 
            // fourColor2ToolStripMenuItem
            // 
            this.fourColor2ToolStripMenuItem.Name = "fourColor2ToolStripMenuItem";
            this.fourColor2ToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.fourColor2ToolStripMenuItem.Text = "4 Color->2 ";
            this.fourColor2ToolStripMenuItem.Click += new System.EventHandler(this.fourColor2ToolStripMenuItem_Click);
            // 
            // invertZXToolStripMenuItem1
            // 
            this.invertZXToolStripMenuItem1.Name = "invertZXToolStripMenuItem1";
            this.invertZXToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.invertZXToolStripMenuItem1.Text = "Invert ZX";
            this.invertZXToolStripMenuItem1.Click += new System.EventHandler(this.invertZXToolStripMenuItem1_Click);
            // 
            // halfSizeFontToolStripMenuItem
            // 
            this.halfSizeFontToolStripMenuItem.Name = "halfSizeFontToolStripMenuItem";
            this.halfSizeFontToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.halfSizeFontToolStripMenuItem.Text = "HalfSizeFont";
            this.halfSizeFontToolStripMenuItem.Click += new System.EventHandler(this.halfSizeFontToolStripMenuItem_Click);
            // 
            // spriteCompilerToolStripMenuItem2
            // 
            this.spriteCompilerToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOneToolStripMenuItem2});
            this.spriteCompilerToolStripMenuItem2.Name = "spriteCompilerToolStripMenuItem2";
            this.spriteCompilerToolStripMenuItem2.Size = new System.Drawing.Size(145, 22);
            this.spriteCompilerToolStripMenuItem2.Text = "SpriteCompiler";
            // 
            // addOneToolStripMenuItem2
            // 
            this.addOneToolStripMenuItem2.Name = "addOneToolStripMenuItem2";
            this.addOneToolStripMenuItem2.Size = new System.Drawing.Size(110, 22);
            this.addOneToolStripMenuItem2.Text = "AddOne";
            this.addOneToolStripMenuItem2.Click += new System.EventHandler(this.addOneToolStripMenuItem2_Click);
            // 
            // pasteZXToolStripMenuItem
            // 
            this.pasteZXToolStripMenuItem.Name = "pasteZXToolStripMenuItem";
            this.pasteZXToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.pasteZXToolStripMenuItem.Text = "Paste ZX";
            this.pasteZXToolStripMenuItem.Click += new System.EventHandler(this.pasteZXToolStripMenuItem_Click);
            // 
            // z80ToolStripMenuItem
            // 
            this.z80ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gBToolStripMenuItem,
            this.tIToolStripMenuItem,
            this.sAMToolStripMenuItem,
            this.eNTToolStripMenuItem,
            this.sMSToolStripMenuItem,
            this.camputersLynxToolStripMenuItem});
            this.z80ToolStripMenuItem.Name = "z80ToolStripMenuItem";
            this.z80ToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.z80ToolStripMenuItem.Text = "* Z80 *";
            // 
            // gBToolStripMenuItem
            // 
            this.gBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem7});
            this.gBToolStripMenuItem.Name = "gBToolStripMenuItem";
            this.gBToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.gBToolStripMenuItem.Text = "GameBoy / GBC";
            // 
            // fileToolStripMenuItem7
            // 
            this.fileToolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmapToolStripMenuItem6});
            this.fileToolStripMenuItem7.Name = "fileToolStripMenuItem7";
            this.fileToolStripMenuItem7.Size = new System.Drawing.Size(89, 22);
            this.fileToolStripMenuItem7.Text = "File";
            // 
            // saveRawBitmapToolStripMenuItem6
            // 
            this.saveRawBitmapToolStripMenuItem6.Name = "saveRawBitmapToolStripMenuItem6";
            this.saveRawBitmapToolStripMenuItem6.Size = new System.Drawing.Size(161, 22);
            this.saveRawBitmapToolStripMenuItem6.Text = "Save Raw Bitmap";
            this.saveRawBitmapToolStripMenuItem6.Click += new System.EventHandler(this.saveRawBitmapToolStripMenuItem6_Click);
            // 
            // tIToolStripMenuItem
            // 
            this.tIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filrToolStripMenuItem});
            this.tIToolStripMenuItem.Name = "tIToolStripMenuItem";
            this.tIToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.tIToolStripMenuItem.Text = "TI-83";
            // 
            // filrToolStripMenuItem
            // 
            this.filrToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmapToolStripMenuItem1});
            this.filrToolStripMenuItem.Name = "filrToolStripMenuItem";
            this.filrToolStripMenuItem.Size = new System.Drawing.Size(89, 22);
            this.filrToolStripMenuItem.Text = "File";
            // 
            // saveRawBitmapToolStripMenuItem1
            // 
            this.saveRawBitmapToolStripMenuItem1.Name = "saveRawBitmapToolStripMenuItem1";
            this.saveRawBitmapToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.saveRawBitmapToolStripMenuItem1.Text = "Save Raw Bitmap";
            this.saveRawBitmapToolStripMenuItem1.Click += new System.EventHandler(this.saveRawBitmapToolStripMenuItem1_Click);
            // 
            // sAMToolStripMenuItem
            // 
            this.sAMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem5});
            this.sAMToolStripMenuItem.Name = "sAMToolStripMenuItem";
            this.sAMToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.sAMToolStripMenuItem.Text = "Sam Coupe";
            // 
            // fileToolStripMenuItem5
            // 
            this.fileToolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmapToolStripMenuItem2,
            this.saveRLEToolStripMenuItem,
            this.saveBinarySpritesToolStripMenuItem});
            this.fileToolStripMenuItem5.Name = "fileToolStripMenuItem5";
            this.fileToolStripMenuItem5.Size = new System.Drawing.Size(89, 22);
            this.fileToolStripMenuItem5.Text = "File";
            // 
            // saveRawBitmapToolStripMenuItem2
            // 
            this.saveRawBitmapToolStripMenuItem2.Name = "saveRawBitmapToolStripMenuItem2";
            this.saveRawBitmapToolStripMenuItem2.Size = new System.Drawing.Size(172, 22);
            this.saveRawBitmapToolStripMenuItem2.Text = "Save Raw Bitmap";
            this.saveRawBitmapToolStripMenuItem2.Click += new System.EventHandler(this.saveRawBitmapToolStripMenuItem2_Click);
            // 
            // saveRLEToolStripMenuItem
            // 
            this.saveRLEToolStripMenuItem.Name = "saveRLEToolStripMenuItem";
            this.saveRLEToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.saveRLEToolStripMenuItem.Text = "Save RLE ASM";
            this.saveRLEToolStripMenuItem.Click += new System.EventHandler(this.saveRLEToolStripMenuItem_Click);
            // 
            // saveBinarySpritesToolStripMenuItem
            // 
            this.saveBinarySpritesToolStripMenuItem.Name = "saveBinarySpritesToolStripMenuItem";
            this.saveBinarySpritesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.saveBinarySpritesToolStripMenuItem.Text = "Save Binary Sprites";
            this.saveBinarySpritesToolStripMenuItem.Click += new System.EventHandler(this.saveBinarySpritesToolStripMenuItem_Click);
            // 
            // eNTToolStripMenuItem
            // 
            this.eNTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem4});
            this.eNTToolStripMenuItem.Name = "eNTToolStripMenuItem";
            this.eNTToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.eNTToolStripMenuItem.Text = "Elan Enterprise";
            // 
            // fileToolStripMenuItem4
            // 
            this.fileToolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRAWBitmapToolStripMenuItem,
            this.rLEASMToolStripMenuItem2});
            this.fileToolStripMenuItem4.Name = "fileToolStripMenuItem4";
            this.fileToolStripMenuItem4.Size = new System.Drawing.Size(89, 22);
            this.fileToolStripMenuItem4.Text = "File";
            // 
            // saveRAWBitmapToolStripMenuItem
            // 
            this.saveRAWBitmapToolStripMenuItem.Name = "saveRAWBitmapToolStripMenuItem";
            this.saveRAWBitmapToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.saveRAWBitmapToolStripMenuItem.Text = "Save RAW Bitmap";
            this.saveRAWBitmapToolStripMenuItem.Click += new System.EventHandler(this.saveRAWBitmapToolStripMenuItem_Click);
            // 
            // rLEASMToolStripMenuItem2
            // 
            this.rLEASMToolStripMenuItem2.Name = "rLEASMToolStripMenuItem2";
            this.rLEASMToolStripMenuItem2.Size = new System.Drawing.Size(164, 22);
            this.rLEASMToolStripMenuItem2.Text = "RLE ASM";
            this.rLEASMToolStripMenuItem2.Click += new System.EventHandler(this.rLEASMToolStripMenuItem2_Click);
            // 
            // sMSToolStripMenuItem
            // 
            this.sMSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem6});
            this.sMSToolStripMenuItem.Name = "sMSToolStripMenuItem";
            this.sMSToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.sMSToolStripMenuItem.Text = "Master System / GameGear";
            // 
            // fileToolStripMenuItem6
            // 
            this.fileToolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmapToolStripMenuItem5});
            this.fileToolStripMenuItem6.Name = "fileToolStripMenuItem6";
            this.fileToolStripMenuItem6.Size = new System.Drawing.Size(89, 22);
            this.fileToolStripMenuItem6.Text = "File";
            // 
            // saveRawBitmapToolStripMenuItem5
            // 
            this.saveRawBitmapToolStripMenuItem5.Name = "saveRawBitmapToolStripMenuItem5";
            this.saveRawBitmapToolStripMenuItem5.Size = new System.Drawing.Size(161, 22);
            this.saveRawBitmapToolStripMenuItem5.Text = "Save Raw Bitmap";
            this.saveRawBitmapToolStripMenuItem5.Click += new System.EventHandler(this.saveRawBitmapToolStripMenuItem5_Click);
            // 
            // camputersLynxToolStripMenuItem
            // 
            this.camputersLynxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmapToolStripMenuItem17,
            this.saveRaw8x8TileBitmapToolStripMenuItem});
            this.camputersLynxToolStripMenuItem.Name = "camputersLynxToolStripMenuItem";
            this.camputersLynxToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.camputersLynxToolStripMenuItem.Text = "Camputers Lynx";
            // 
            // saveRawBitmapToolStripMenuItem17
            // 
            this.saveRawBitmapToolStripMenuItem17.Name = "saveRawBitmapToolStripMenuItem17";
            this.saveRawBitmapToolStripMenuItem17.Size = new System.Drawing.Size(206, 22);
            this.saveRawBitmapToolStripMenuItem17.Text = "Save Raw Bitmap";
            this.saveRawBitmapToolStripMenuItem17.Click += new System.EventHandler(this.saveRawBitmapToolStripMenuItem17_Click);
            // 
            // saveRaw8x8TileBitmapToolStripMenuItem
            // 
            this.saveRaw8x8TileBitmapToolStripMenuItem.Name = "saveRaw8x8TileBitmapToolStripMenuItem";
            this.saveRaw8x8TileBitmapToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.saveRaw8x8TileBitmapToolStripMenuItem.Text = "Save Raw 8x8 Tile Bitmap";
            this.saveRaw8x8TileBitmapToolStripMenuItem.Click += new System.EventHandler(this.saveRaw8x8TileBitmapToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atari5200800ToolStripMenuItem,
            this.atariLynxToolStripMenuItem,
            this.aToolStripMenuItem,
            this.bBCToolStripMenuItem,
            this.c64ToolStripMenuItem,
            this.nESFamicomToolStripMenuItem,
            this.pCEngineToolStripMenuItem,
            this.superNintendoSFCToolStripMenuItem,
            this.vic20ToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItem2.Text = "* 6502 *";
            // 
            // atari5200800ToolStripMenuItem
            // 
            this.atari5200800ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmap2ColorToolStripMenuItem1,
            this.saveRawBitmap4ColorToolStripMenuItem1});
            this.atari5200800ToolStripMenuItem.Name = "atari5200800ToolStripMenuItem";
            this.atari5200800ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.atari5200800ToolStripMenuItem.Text = "Atari 5200/800";
            // 
            // saveRawBitmap2ColorToolStripMenuItem1
            // 
            this.saveRawBitmap2ColorToolStripMenuItem1.Name = "saveRawBitmap2ColorToolStripMenuItem1";
            this.saveRawBitmap2ColorToolStripMenuItem1.Size = new System.Drawing.Size(210, 22);
            this.saveRawBitmap2ColorToolStripMenuItem1.Text = "Save Raw Bitmap (2 Color)";
            this.saveRawBitmap2ColorToolStripMenuItem1.Click += new System.EventHandler(this.saveRawBitmap2ColorToolStripMenuItem1_Click);
            // 
            // saveRawBitmap4ColorToolStripMenuItem1
            // 
            this.saveRawBitmap4ColorToolStripMenuItem1.Name = "saveRawBitmap4ColorToolStripMenuItem1";
            this.saveRawBitmap4ColorToolStripMenuItem1.Size = new System.Drawing.Size(210, 22);
            this.saveRawBitmap4ColorToolStripMenuItem1.Text = "Save Raw Bitmap (4 Color)";
            this.saveRawBitmap4ColorToolStripMenuItem1.Click += new System.EventHandler(this.saveRawBitmap4ColorToolStripMenuItem1_Click);
            // 
            // atariLynxToolStripMenuItem
            // 
            this.atariLynxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmapToolStripMenuItem11,
            this.save16colorLinearSpriteToolStripMenuItem,
            this.save8colorLinearSpriteToolStripMenuItem,
            this.sToolStripMenuItem,
            this.sToolStripMenuItem1,
            this.save16ColorRLESpriteToolStripMenuItem,
            this.save8ColorRLESpriteToolStripMenuItem,
            this.save4ColorRLESpriteToolStripMenuItem,
            this.save2ColorRLESpriteToolStripMenuItem});
            this.atariLynxToolStripMenuItem.Name = "atariLynxToolStripMenuItem";
            this.atariLynxToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.atariLynxToolStripMenuItem.Text = "Atari Lynx";
            // 
            // saveRawBitmapToolStripMenuItem11
            // 
            this.saveRawBitmapToolStripMenuItem11.Name = "saveRawBitmapToolStripMenuItem11";
            this.saveRawBitmapToolStripMenuItem11.Size = new System.Drawing.Size(212, 22);
            this.saveRawBitmapToolStripMenuItem11.Text = "Save Raw Bitmap";
            this.saveRawBitmapToolStripMenuItem11.Click += new System.EventHandler(this.saveRawBitmapToolStripMenuItem11_Click);
            // 
            // save16colorLinearSpriteToolStripMenuItem
            // 
            this.save16colorLinearSpriteToolStripMenuItem.Name = "save16colorLinearSpriteToolStripMenuItem";
            this.save16colorLinearSpriteToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.save16colorLinearSpriteToolStripMenuItem.Text = "Save 16 Color Literal Sprite";
            this.save16colorLinearSpriteToolStripMenuItem.Click += new System.EventHandler(this.save16colorLinearSpriteToolStripMenuItem_Click);
            // 
            // save8colorLinearSpriteToolStripMenuItem
            // 
            this.save8colorLinearSpriteToolStripMenuItem.Name = "save8colorLinearSpriteToolStripMenuItem";
            this.save8colorLinearSpriteToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.save8colorLinearSpriteToolStripMenuItem.Text = "Save  8 Color Literal Sprite";
            this.save8colorLinearSpriteToolStripMenuItem.Click += new System.EventHandler(this.save8colorLinearSpriteToolStripMenuItem_Click);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.sToolStripMenuItem.Text = "Save  4 Color Literal Sprite";
            this.sToolStripMenuItem.Click += new System.EventHandler(this.sToolStripMenuItem_Click);
            // 
            // sToolStripMenuItem1
            // 
            this.sToolStripMenuItem1.Name = "sToolStripMenuItem1";
            this.sToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.sToolStripMenuItem1.Text = "Save  2 Color Literal Sprite";
            this.sToolStripMenuItem1.Click += new System.EventHandler(this.sToolStripMenuItem1_Click);
            // 
            // save16ColorRLESpriteToolStripMenuItem
            // 
            this.save16ColorRLESpriteToolStripMenuItem.Name = "save16ColorRLESpriteToolStripMenuItem";
            this.save16ColorRLESpriteToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.save16ColorRLESpriteToolStripMenuItem.Text = "Save 16 Color RLE Sprite";
            this.save16ColorRLESpriteToolStripMenuItem.Click += new System.EventHandler(this.save16ColorRLESpriteToolStripMenuItem_Click);
            // 
            // save8ColorRLESpriteToolStripMenuItem
            // 
            this.save8ColorRLESpriteToolStripMenuItem.Name = "save8ColorRLESpriteToolStripMenuItem";
            this.save8ColorRLESpriteToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.save8ColorRLESpriteToolStripMenuItem.Text = "Save  8 Color RLE Sprite";
            this.save8ColorRLESpriteToolStripMenuItem.Click += new System.EventHandler(this.save8ColorRLESpriteToolStripMenuItem_Click);
            // 
            // save4ColorRLESpriteToolStripMenuItem
            // 
            this.save4ColorRLESpriteToolStripMenuItem.Name = "save4ColorRLESpriteToolStripMenuItem";
            this.save4ColorRLESpriteToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.save4ColorRLESpriteToolStripMenuItem.Text = "Save  4 Color RLE Sprite";
            this.save4ColorRLESpriteToolStripMenuItem.Click += new System.EventHandler(this.save4ColorRLESpriteToolStripMenuItem_Click);
            // 
            // save2ColorRLESpriteToolStripMenuItem
            // 
            this.save2ColorRLESpriteToolStripMenuItem.Name = "save2ColorRLESpriteToolStripMenuItem";
            this.save2ColorRLESpriteToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.save2ColorRLESpriteToolStripMenuItem.Text = "Save  2 Color RLE Sprite";
            this.save2ColorRLESpriteToolStripMenuItem.Click += new System.EventHandler(this.save2ColorRLESpriteToolStripMenuItem_Click);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmap2ColorToolStripMenuItem,
            this.saveRawBitmap4ColorToolStripMenuItem});
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.aToolStripMenuItem.Text = "Apple II";
            // 
            // saveRawBitmap2ColorToolStripMenuItem
            // 
            this.saveRawBitmap2ColorToolStripMenuItem.Name = "saveRawBitmap2ColorToolStripMenuItem";
            this.saveRawBitmap2ColorToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.saveRawBitmap2ColorToolStripMenuItem.Text = "Save Raw Bitmap (2 color)";
            this.saveRawBitmap2ColorToolStripMenuItem.Click += new System.EventHandler(this.saveRawBitmap2ColorToolStripMenuItem_Click);
            // 
            // saveRawBitmap4ColorToolStripMenuItem
            // 
            this.saveRawBitmap4ColorToolStripMenuItem.Name = "saveRawBitmap4ColorToolStripMenuItem";
            this.saveRawBitmap4ColorToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.saveRawBitmap4ColorToolStripMenuItem.Text = "Save Raw Bitmap (4 color)";
            this.saveRawBitmap4ColorToolStripMenuItem.Click += new System.EventHandler(this.saveRawBitmap4ColorToolStripMenuItem_Click);
            // 
            // bBCToolStripMenuItem
            // 
            this.bBCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmapToolStripMenuItem12});
            this.bBCToolStripMenuItem.Name = "bBCToolStripMenuItem";
            this.bBCToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.bBCToolStripMenuItem.Text = "BBC";
            // 
            // saveRawBitmapToolStripMenuItem12
            // 
            this.saveRawBitmapToolStripMenuItem12.Name = "saveRawBitmapToolStripMenuItem12";
            this.saveRawBitmapToolStripMenuItem12.Size = new System.Drawing.Size(161, 22);
            this.saveRawBitmapToolStripMenuItem12.Text = "Save Raw Bitmap";
            this.saveRawBitmapToolStripMenuItem12.Click += new System.EventHandler(this.saveRawBitmapToolStripMenuItem12_Click);
            // 
            // c64ToolStripMenuItem
            // 
            this.c64ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmap2ColorToolStripMenuItem2,
            this.saveRawBitmap4ColorToolStripMenuItem2,
            this.saveSprite2ColorToolStripMenuItem,
            this.saveSprite4ColorToolStripMenuItem});
            this.c64ToolStripMenuItem.Name = "c64ToolStripMenuItem";
            this.c64ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.c64ToolStripMenuItem.Text = "C64";
            // 
            // saveRawBitmap2ColorToolStripMenuItem2
            // 
            this.saveRawBitmap2ColorToolStripMenuItem2.Name = "saveRawBitmap2ColorToolStripMenuItem2";
            this.saveRawBitmap2ColorToolStripMenuItem2.Size = new System.Drawing.Size(210, 22);
            this.saveRawBitmap2ColorToolStripMenuItem2.Text = "Save Raw Bitmap (2 Color)";
            this.saveRawBitmap2ColorToolStripMenuItem2.Click += new System.EventHandler(this.saveRawBitmap2ColorToolStripMenuItem2_Click);
            // 
            // saveRawBitmap4ColorToolStripMenuItem2
            // 
            this.saveRawBitmap4ColorToolStripMenuItem2.Name = "saveRawBitmap4ColorToolStripMenuItem2";
            this.saveRawBitmap4ColorToolStripMenuItem2.Size = new System.Drawing.Size(210, 22);
            this.saveRawBitmap4ColorToolStripMenuItem2.Text = "Save Raw Bitmap (4 Color)";
            this.saveRawBitmap4ColorToolStripMenuItem2.Click += new System.EventHandler(this.saveRawBitmap4ColorToolStripMenuItem2_Click);
            // 
            // saveSprite2ColorToolStripMenuItem
            // 
            this.saveSprite2ColorToolStripMenuItem.Name = "saveSprite2ColorToolStripMenuItem";
            this.saveSprite2ColorToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.saveSprite2ColorToolStripMenuItem.Text = "Save Sprite (2 Color)";
            this.saveSprite2ColorToolStripMenuItem.Click += new System.EventHandler(this.saveSprite2ColorToolStripMenuItem_Click);
            // 
            // saveSprite4ColorToolStripMenuItem
            // 
            this.saveSprite4ColorToolStripMenuItem.Name = "saveSprite4ColorToolStripMenuItem";
            this.saveSprite4ColorToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.saveSprite4ColorToolStripMenuItem.Text = "Save Sprite (4 Color)";
            this.saveSprite4ColorToolStripMenuItem.Click += new System.EventHandler(this.saveSprite4ColorToolStripMenuItem_Click);
            // 
            // nESFamicomToolStripMenuItem
            // 
            this.nESFamicomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmapToolStripMenuItem14});
            this.nESFamicomToolStripMenuItem.Name = "nESFamicomToolStripMenuItem";
            this.nESFamicomToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.nESFamicomToolStripMenuItem.Text = "NES/Famicom";
            // 
            // saveRawBitmapToolStripMenuItem14
            // 
            this.saveRawBitmapToolStripMenuItem14.Name = "saveRawBitmapToolStripMenuItem14";
            this.saveRawBitmapToolStripMenuItem14.Size = new System.Drawing.Size(161, 22);
            this.saveRawBitmapToolStripMenuItem14.Text = "Save Raw Bitmap";
            this.saveRawBitmapToolStripMenuItem14.Click += new System.EventHandler(this.saveRawBitmapToolStripMenuItem14_Click);
            // 
            // pCEngineToolStripMenuItem
            // 
            this.pCEngineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmapToolStripMenuItem13,
            this.savePCESpriteToolStripMenuItem});
            this.pCEngineToolStripMenuItem.Name = "pCEngineToolStripMenuItem";
            this.pCEngineToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.pCEngineToolStripMenuItem.Text = "PC Engine";
            // 
            // saveRawBitmapToolStripMenuItem13
            // 
            this.saveRawBitmapToolStripMenuItem13.Name = "saveRawBitmapToolStripMenuItem13";
            this.saveRawBitmapToolStripMenuItem13.Size = new System.Drawing.Size(161, 22);
            this.saveRawBitmapToolStripMenuItem13.Text = "Save Raw Bitmap";
            this.saveRawBitmapToolStripMenuItem13.Click += new System.EventHandler(this.saveRawBitmapToolStripMenuItem13_Click);
            // 
            // savePCESpriteToolStripMenuItem
            // 
            this.savePCESpriteToolStripMenuItem.Name = "savePCESpriteToolStripMenuItem";
            this.savePCESpriteToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.savePCESpriteToolStripMenuItem.Text = "Save PCE Sprite";
            this.savePCESpriteToolStripMenuItem.Click += new System.EventHandler(this.savePCESpriteToolStripMenuItem_Click);
            // 
            // superNintendoSFCToolStripMenuItem
            // 
            this.superNintendoSFCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmapToolStripMenuItem15});
            this.superNintendoSFCToolStripMenuItem.Name = "superNintendoSFCToolStripMenuItem";
            this.superNintendoSFCToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.superNintendoSFCToolStripMenuItem.Text = "Super Nintendo/SFC";
            // 
            // saveRawBitmapToolStripMenuItem15
            // 
            this.saveRawBitmapToolStripMenuItem15.Name = "saveRawBitmapToolStripMenuItem15";
            this.saveRawBitmapToolStripMenuItem15.Size = new System.Drawing.Size(161, 22);
            this.saveRawBitmapToolStripMenuItem15.Text = "Save Raw Bitmap";
            this.saveRawBitmapToolStripMenuItem15.Click += new System.EventHandler(this.saveRawBitmapToolStripMenuItem15_Click);
            // 
            // vic20ToolStripMenuItem
            // 
            this.vic20ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmapToolStripMenuItem16});
            this.vic20ToolStripMenuItem.Name = "vic20ToolStripMenuItem";
            this.vic20ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.vic20ToolStripMenuItem.Text = "Vic 20";
            // 
            // saveRawBitmapToolStripMenuItem16
            // 
            this.saveRawBitmapToolStripMenuItem16.Name = "saveRawBitmapToolStripMenuItem16";
            this.saveRawBitmapToolStripMenuItem16.Size = new System.Drawing.Size(161, 22);
            this.saveRawBitmapToolStripMenuItem16.Text = "Save Raw Bitmap";
            this.saveRawBitmapToolStripMenuItem16.Click += new System.EventHandler(this.saveRawBitmapToolStripMenuItem16_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neoGeoToolStripMenuItem,
            this.atariSTToolStripMenuItem,
            this.AmigaToolStripMenuItem,
            this.x68000ToolStripMenuItem,
            this.megaDriveGenesisToolStripMenuItem,
            this.sinclairQLToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(67, 20);
            this.toolStripMenuItem1.Text = "* 68000 *";
            // 
            // neoGeoToolStripMenuItem
            // 
            this.neoGeoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFIXFontToolStripMenuItem,
            this.saveSpriteToolStripMenuItem});
            this.neoGeoToolStripMenuItem.Name = "neoGeoToolStripMenuItem";
            this.neoGeoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.neoGeoToolStripMenuItem.Text = "NeoGeo";
            // 
            // saveFIXFontToolStripMenuItem
            // 
            this.saveFIXFontToolStripMenuItem.Name = "saveFIXFontToolStripMenuItem";
            this.saveFIXFontToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saveFIXFontToolStripMenuItem.Text = "Save FIX Bitmap";
            this.saveFIXFontToolStripMenuItem.Click += new System.EventHandler(this.saveFIXFontToolStripMenuItem_Click);
            // 
            // saveSpriteToolStripMenuItem
            // 
            this.saveSpriteToolStripMenuItem.Name = "saveSpriteToolStripMenuItem";
            this.saveSpriteToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saveSpriteToolStripMenuItem.Text = "Save Sprite";
            this.saveSpriteToolStripMenuItem.Click += new System.EventHandler(this.saveSpriteToolStripMenuItem_Click);
            // 
            // atariSTToolStripMenuItem
            // 
            this.atariSTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmapToolStripMenuItem7});
            this.atariSTToolStripMenuItem.Name = "atariSTToolStripMenuItem";
            this.atariSTToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.atariSTToolStripMenuItem.Text = "Atari ST";
            // 
            // saveRawBitmapToolStripMenuItem7
            // 
            this.saveRawBitmapToolStripMenuItem7.Name = "saveRawBitmapToolStripMenuItem7";
            this.saveRawBitmapToolStripMenuItem7.Size = new System.Drawing.Size(161, 22);
            this.saveRawBitmapToolStripMenuItem7.Text = "Save Raw Bitmap";
            this.saveRawBitmapToolStripMenuItem7.Click += new System.EventHandler(this.saveRawBitmapToolStripMenuItem7_Click);
            // 
            // AmigaToolStripMenuItem
            // 
            this.AmigaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmapToolStripMenuItem8});
            this.AmigaToolStripMenuItem.Name = "AmigaToolStripMenuItem";
            this.AmigaToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.AmigaToolStripMenuItem.Text = "Amiga";
            // 
            // saveRawBitmapToolStripMenuItem8
            // 
            this.saveRawBitmapToolStripMenuItem8.Name = "saveRawBitmapToolStripMenuItem8";
            this.saveRawBitmapToolStripMenuItem8.Size = new System.Drawing.Size(153, 22);
            this.saveRawBitmapToolStripMenuItem8.Text = "SaveRawBitmap";
            this.saveRawBitmapToolStripMenuItem8.Click += new System.EventHandler(this.saveRawBitmapToolStripMenuItem8_Click);
            // 
            // x68000ToolStripMenuItem
            // 
            this.x68000ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmapToolStripMenuItem9});
            this.x68000ToolStripMenuItem.Name = "x68000ToolStripMenuItem";
            this.x68000ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.x68000ToolStripMenuItem.Text = "X68000";
            // 
            // saveRawBitmapToolStripMenuItem9
            // 
            this.saveRawBitmapToolStripMenuItem9.Name = "saveRawBitmapToolStripMenuItem9";
            this.saveRawBitmapToolStripMenuItem9.Size = new System.Drawing.Size(161, 22);
            this.saveRawBitmapToolStripMenuItem9.Text = "Save Raw Bitmap";
            this.saveRawBitmapToolStripMenuItem9.Click += new System.EventHandler(this.saveRawBitmapToolStripMenuItem9_Click);
            // 
            // megaDriveGenesisToolStripMenuItem
            // 
            this.megaDriveGenesisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawBitmapToolStripMenuItem10});
            this.megaDriveGenesisToolStripMenuItem.Name = "megaDriveGenesisToolStripMenuItem";
            this.megaDriveGenesisToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.megaDriveGenesisToolStripMenuItem.Text = "MegaDrive/Genesis";
            // 
            // saveRawBitmapToolStripMenuItem10
            // 
            this.saveRawBitmapToolStripMenuItem10.Name = "saveRawBitmapToolStripMenuItem10";
            this.saveRawBitmapToolStripMenuItem10.Size = new System.Drawing.Size(161, 22);
            this.saveRawBitmapToolStripMenuItem10.Text = "Save Raw Bitmap";
            this.saveRawBitmapToolStripMenuItem10.Click += new System.EventHandler(this.saveRawBitmapToolStripMenuItem10_Click);
            // 
            // sinclairQLToolStripMenuItem
            // 
            this.sinclairQLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.raw8colorBitmapToolStripMenuItem,
            this.raw4colorBitmapToolStripMenuItem});
            this.sinclairQLToolStripMenuItem.Name = "sinclairQLToolStripMenuItem";
            this.sinclairQLToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.sinclairQLToolStripMenuItem.Text = "Sinclair QL";
            // 
            // raw8colorBitmapToolStripMenuItem
            // 
            this.raw8colorBitmapToolStripMenuItem.Name = "raw8colorBitmapToolStripMenuItem";
            this.raw8colorBitmapToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.raw8colorBitmapToolStripMenuItem.Text = "Raw 8color Bitmap";
            this.raw8colorBitmapToolStripMenuItem.Click += new System.EventHandler(this.raw8colorBitmapToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // abToolStripMenuItem
            // 
            this.abToolStripMenuItem.Name = "abToolStripMenuItem";
            this.abToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.abToolStripMenuItem.Text = "About";
            this.abToolStripMenuItem.Click += new System.EventHandler(this.abToolStripMenuItem_Click);
            // 
            // pnlApplePal
            // 
            this.pnlApplePal.BackColor = System.Drawing.SystemColors.Control;
            this.pnlApplePal.Location = new System.Drawing.Point(590, 27);
            this.pnlApplePal.Name = "pnlApplePal";
            this.pnlApplePal.Size = new System.Drawing.Size(433, 48);
            this.pnlApplePal.TabIndex = 30;
            this.pnlApplePal.Visible = false;
            // 
            // bigfont
            // 
            this.bigfont.AutoSize = true;
            this.bigfont.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bigfont.Location = new System.Drawing.Point(783, 658);
            this.bigfont.Name = "bigfont";
            this.bigfont.Size = new System.Drawing.Size(14, 19);
            this.bigfont.TabIndex = 31;
            this.bigfont.Text = ".";
            this.bigfont.Visible = false;
            // 
            // raw4colorBitmapToolStripMenuItem
            // 
            this.raw4colorBitmapToolStripMenuItem.Name = "raw4colorBitmapToolStripMenuItem";
            this.raw4colorBitmapToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.raw4colorBitmapToolStripMenuItem.Text = "Raw 4color Bitmap";
            this.raw4colorBitmapToolStripMenuItem.Click += new System.EventHandler(this.raw4colorBitmapToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 741);
            this.Controls.Add(this.bigfont);
            this.Controls.Add(this.pnlNESpal);
            this.Controls.Add(this.pnlApplePal);
            this.Controls.Add(this.lblSpriteInfo);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.trkzoom);
            this.Controls.Add(this.pnlMSXpal);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.BtnAltPal);
            this.Controls.Add(this.pnlC64pal);
            this.Controls.Add(this.pnlZXPalette);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSetPal);
            this.Controls.Add(this.tabSpriteTools);
            this.Controls.Add(this.btnLastSprite);
            this.Controls.Add(this.btnNextBank);
            this.Controls.Add(this.btnNextSprite);
            this.Controls.Add(this.btnLastBank);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "AkuSprite Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkzoom)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabEditor.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpSpriteSize.ResumeLayout(false);
            this.grpSpriteSize.PerformLayout();
            this.GrpFrameOverlay.ResumeLayout(false);
            this.GrpFrameOverlay.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabNotes.ResumeLayout(false);
            this.tabNotes.PerformLayout();
            this.tabSpriteTools.ResumeLayout(false);
            this.tabSpriteOptions.ResumeLayout(false);
            this.tabSpriteOptions.PerformLayout();
            this.tabPixelPaint.ResumeLayout(false);
            this.tabPixelPaint.PerformLayout();
            this.tabZXPaint.ResumeLayout(false);
            this.tabZXPaint.PerformLayout();
            this.tabColorSwap.ResumeLayout(false);
            this.tabColorSwap.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.TrackBar trkzoom;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEditor;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoGuideNone;
        private System.Windows.Forms.RadioButton rdoGuide4_8_24;
        private System.Windows.Forms.RadioButton rdoGuide4_8_32;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox lstSprites;
        private System.Windows.Forms.Button btnSetPal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoDisplaySpeccy;
        private System.Windows.Forms.RadioButton rdoDisplayCPC;
        private System.Windows.Forms.RadioButton rdoDisplayMSX;
        private System.Windows.Forms.CheckBox chkHasDosHeader;
        private System.Windows.Forms.Timer tmrBackup;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnNextSprite;
        private System.Windows.Forms.Button btnLastSprite;
        private System.Windows.Forms.TextBox txtSpriteDataOffSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaxSpritesByOffset;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cPCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mSXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSpectrumScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSpectrumBinaryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveMSXASMPaletteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMSXBinaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pasteZXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canvasSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem loadCPCBinaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCPCBinaryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveCPCBinaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSpritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePaletteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToClipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fourColor2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertZXToolStripMenuItem1;
        private System.Windows.Forms.CheckBox chkStrongGrid;
        private System.Windows.Forms.ToolStripMenuItem saveSpectrumScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rLEASMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rLEASMToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rLEASMCOLORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bMPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMSXBitmapToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveMSXBitmapWithPaletteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveMSXBitmapSpritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rLEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildRLEASMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMSXRLEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spriteCompilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addOneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spriteCompilerToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem addOneToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem duplicateFromToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mSX16ColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cPC4ColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zX2ColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highVisToggleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reSaveSpritesToolStripMenuItem;
        private System.Windows.Forms.Button btnNextBank;
        private System.Windows.Forms.Button btnLastBank;
        private System.Windows.Forms.ToolStripMenuItem duplicateOffsetFromToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMSXRLEPaletteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMSXRLESpritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yInterlaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAllAttribsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSpectrumTilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pxShiftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackBorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelShiftRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelShiftDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelShiftUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveASMPaletteToolStripMenuItem;
        private System.Windows.Forms.GroupBox GrpFrameOverlay;
        private System.Windows.Forms.RadioButton rdoFrameNext;
        private System.Windows.Forms.RadioButton rdoFrameNone;
        private System.Windows.Forms.RadioButton rdoFrameLast;
        private System.Windows.Forms.ToolStripMenuItem overlayLastFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overlayNextFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeTilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileShiftXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackBorderTightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PaletteTint;
        private System.Windows.Forms.ToolStripMenuItem saveSpectrumFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem halfSizeFontToolStripMenuItem;
        private System.Windows.Forms.CheckBox ChkBackgroundTestDots;
        private System.Windows.Forms.ToolStripMenuItem saveCPCBinaryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sAMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eNTToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpSpriteSize;
        private System.Windows.Forms.RadioButton rdospr512;
        private System.Windows.Forms.RadioButton rdospr256;
        private System.Windows.Forms.ToolStripMenuItem SaveCPCRawBmp;
        private System.Windows.Forms.RadioButton rdoDisplayCPC0;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem saveRAWBitmapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmapToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmapToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveRAWBitmapToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmapToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem saveCPCZigTileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmapToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem saveRLEToolStripMenuItem;
        private System.Windows.Forms.RadioButton rdoCPCpairs;
        private System.Windows.Forms.RadioButton RdoTIquarter;
        private System.Windows.Forms.ToolStripMenuItem saveRAWMSX1BitmapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRawVdpTileBitmapToolStripMenuItem;
        private System.Windows.Forms.RadioButton rdoSpecDither;
        private System.Windows.Forms.RadioButton rdoCPCdither;
        private System.Windows.Forms.ToolStripMenuItem saveCPCSCRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmapToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem z80ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem neoGeoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFIXFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CpcSpriteCompilerClear;
        private System.Windows.Forms.ToolStripMenuItem CpcSpriteConvaddOneDiffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atariSTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmapToolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem AmigaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmapToolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem x68000ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmapToolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem atari5200800ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem megaDriveGenesisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmapToolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atariLynxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bBCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c64ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nESFamicomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pCEngineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem superNintendoSFCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vic20ToolStripMenuItem;
        private System.Windows.Forms.Button btnToolPixelPaint;
        private System.Windows.Forms.Button btnZXpaint2;
        private System.Windows.Forms.Button btnColorSwap2;
        private System.Windows.Forms.TabControl tabSpriteTools;
        private System.Windows.Forms.TabPage tabSpriteOptions;
        private System.Windows.Forms.Label lblSpriteInfo;
        private System.Windows.Forms.CheckBox chkFixedSize;
        private System.Windows.Forms.CheckBox chkAligned;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSpriteSettings;
        private System.Windows.Forms.TabPage tabPixelPaint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCheckMode;
        private System.Windows.Forms.TabPage tabZXPaint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboZxPaintMode;
        private System.Windows.Forms.TabPage tabColorSwap;
        private System.Windows.Forms.ComboBox cboColorConvertMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlZXPalette;
        private System.Windows.Forms.Button BtnAltPal;
        private System.Windows.Forms.Panel pnlC64pal;
        private System.Windows.Forms.Panel pnlNESpal;
        private System.Windows.Forms.Panel pnlMSXpal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboFillCheck;
        private System.Windows.Forms.ToolStripMenuItem cPC16ColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem colorpairsCPCENTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorditheredCPCENTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorditheredToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbo4colorDither;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem applyViewColorConversionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem rLEASMToolStripMenuItem2;
        private System.Windows.Forms.RadioButton rdoGuide7_14_28;
        private System.Windows.Forms.ToolStripMenuItem loadPaletteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPixelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmap2ColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmap4ColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmap4ColorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmap2ColorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmapToolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmapToolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmap4ColorToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmapToolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmapToolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmapToolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmapToolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem saveBMPMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadBMPMaToolStripMenuItem;
        private System.Windows.Forms.RadioButton rdoC64_4Color;
        private System.Windows.Forms.Panel pnlApplePal;
        private System.Windows.Forms.RadioButton rdoAppleColor;
        private System.Windows.Forms.Label bigfont;
        private System.Windows.Forms.TabPage tabNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.ToolStripMenuItem abToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recent1;
        private System.Windows.Forms.ToolStripMenuItem recent2;
        private System.Windows.Forms.ToolStripMenuItem recent3;
        private System.Windows.Forms.ToolStripMenuItem recent4;
        private System.Windows.Forms.ToolStripMenuItem recent5;
        private System.Windows.Forms.ToolStripMenuItem recent6;
        private System.Windows.Forms.ToolStripMenuItem recent7;
        private System.Windows.Forms.ToolStripMenuItem recent8;
        private System.Windows.Forms.ToolStripMenuItem recent9;
        private System.Windows.Forms.ToolStripMenuItem recent10;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBinarySpritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePCESpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSprite2ColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSprite4ColorToolStripMenuItem;
        private System.Windows.Forms.RadioButton rdoC64Sprite;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmap2ColorToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveRAWMSX1Raw16x16SpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem save16colorLinearSpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem save8colorLinearSpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem save16ColorRLESpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem save8ColorRLESpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem save4ColorRLESpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem save2ColorRLESpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem camputersLynxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRawBitmapToolStripMenuItem17;
        private System.Windows.Forms.RadioButton rdoHalfWidthFourColor;
        private System.Windows.Forms.RadioButton rdoVic20MultiColor;
        private System.Windows.Forms.ToolStripMenuItem saveRaw8x8TileBitmapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinclairQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raw8colorBitmapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSpriteToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtFixedFileSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem raw4colorBitmapToolStripMenuItem;
    }
}

