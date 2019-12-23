using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenMOO2Viewer
{
    // a flag used to specify which update function is called from the general update()
    public enum UpdateType
    {
        LBX = 1,
        BLOCK = 2,
        PALETTES = 3,
        FRAME = 4
    };

    public partial class mainForm : Form
    {
        private const string defaultConfigFileName = "config.ini";

        private LBXReader lbxReader;
        private string currentLBXFileName;
        private int currentLBXBlock;

        private Palette[] palettes;
        private int currentPaletteIndex;
        private Palette lockedInternalPalette;

        private Image currentImage;
        private int currentImageFrame;
        private int imageZoomFactor;
        private readonly Bitmap blankWhiteBitmap;

        public mainForm()
        {
            InitializeComponent();

            blankWhiteBitmap = new Bitmap(640, 480);
            Graphics g = Graphics.FromImage(blankWhiteBitmap);
            g.Clear(Color.White);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            //blockViewTabControl.SelectedTab = tabPage2;

            // load config file, if it exists
            if (File.Exists(defaultConfigFileName))
                loadConfigFromFile(defaultConfigFileName);
            // else set the root of the folder dialog to My Computer
            else
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;

            // initialize a few controls
            currentLBXFileName = "";
            errorLabel.Visible = false;

            // 1 LBXReader used form-wide
            lbxReader = new LBXReader();

            // create the Bitmaps for the palette boxes and clear 'em white
            externalPalettePictureBox.Image = new Bitmap(162, 162);
            internalPalettePictureBox.Image = new Bitmap(162, 162);
            mixedPalettePictureBox.Image = new Bitmap(162, 162);
            Graphics g = Graphics.FromImage(externalPalettePictureBox.Image);
            g.Clear(Color.White);
            g = Graphics.FromImage(internalPalettePictureBox.Image);
            g.Clear(Color.White);
            g = Graphics.FromImage(mixedPalettePictureBox.Image);
            g.Clear(Color.White);

            internalPaletteLockButton.Enabled = false;
            // load up some palettes
            loadPalettes();
            loadFonts();
        }

        private void loadPalettes()
        {
            if (gameFolderPathTextBox.Text.Length > 0 && Directory.Exists(gameFolderPathTextBox.Text))
            {
                // populate the list box with the font .LBX files and the first several blocks.
                // all of the game fonts are stored here
                palettesListBox.Items.Clear();
                //palettesListBox.Items.Add("FONTS.LBX:000");
                palettesListBox.Items.Add("FONTS.LBX:001");
                palettesListBox.Items.Add("FONTS.LBX:002");
                palettesListBox.Items.Add("FONTS.LBX:003");
                palettesListBox.Items.Add("FONTS.LBX:004");
                palettesListBox.Items.Add("FONTS.LBX:005");

                palettesListBox.Items.Add("IFONTS.LBX:000");
                palettesListBox.Items.Add("IFONTS.LBX:001");
                palettesListBox.Items.Add("IFONTS.LBX:002");
                palettesListBox.Items.Add("IFONTS.LBX:003");
                palettesListBox.Items.Add("IFONTS.LBX:004");

                // a Palette[] holds the actual Palette objects
                palettes = new Palette[palettesListBox.Items.Count];
                LBXBlock block = new LBXBlock();

                // load those
                for (int i = 0; i < palettes.Length; ++i)
                {
                    // create new palette, then parse out the filename from the block index
                    palettes[i] = new Palette();
                    string listItem = (string)palettesListBox.Items[i];
                    string fontFileName = listItem.Substring(0, listItem.IndexOf(":"));
                    int blockIndex = Int32.Parse(listItem.Substring(listItem.IndexOf(":") + 1, listItem.Length - listItem.IndexOf(":") - 1));

                    lbxReader.close();
                    lbxReader.open(gameFolderPathTextBox.Text + "\\" + fontFileName);
                    lbxReader.read(block, blockIndex);

                    palettes[i].load(block);
                }
                lbxReader.close();

                // set the second font as the current, which should also trigger the event to
                // update currentPaletteIndex and redraw the palette view image
                palettesListBox.SetSelected(2, true);
            }
        }

        private void gameFolderPathBrowseButton_Click(object sender, EventArgs e)
        {
            if (gameFolderPathTextBox.Text.Length > 0 && Directory.Exists(gameFolderPathTextBox.Text))
                folderBrowserDialog1.SelectedPath = gameFolderPathTextBox.Text;
            
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                gameFolderPathTextBox.Text = folderBrowserDialog1.SelectedPath;
                populateLbxFileList();
            }
        }

        private void populateLbxFileList()
        {
            if (gameFolderPathTextBox.Text.Length > 0 && Directory.Exists(gameFolderPathTextBox.Text))
            {
                // clear listbox
                lbxFilesListBox.Items.Clear();

                // prevent control redraw until update is done
                lbxFilesListBox.BeginUpdate();

                // retrieve list of LBX files
                string[] lbxFiles = Directory.GetFiles(gameFolderPathTextBox.Text, "*.lbx");

                foreach (string lbxFilePath in lbxFiles)
                {
                    int slashPos, fileNameLength;
                    slashPos = lbxFilePath.LastIndexOf("\\");
                    fileNameLength = lbxFilePath.Length - slashPos - 1;
                    string lbxFileName = lbxFilePath.Substring(slashPos + 1, fileNameLength);
                    lbxFilesListBox.Items.Add(lbxFileName);
                }

                lbxFilesListBox.EndUpdate();
            }
        }

        private void lbxFileListRefreshButton_Click(object sender, EventArgs e)
        {
            populateLbxFileList();
        }

        private void loadConfigFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                StreamReader fileIn = new StreamReader(filePath);
                string line;

                while ((line = fileIn.ReadLine()) != null)
                {
                    string key, val;
                    int delimPos;

                    // break up 'key=value'
                    delimPos = line.IndexOf('=');
                    if (delimPos != -1 && delimPos != (line.Length - 1))
                    {
                        key = line.Substring(0, delimPos);
                        val = line.Substring(delimPos + 1, line.Length - delimPos - 1);

                        if (key == "game_folder")
                        {
                            if (Directory.Exists(val))
                            {
                                gameFolderPathTextBox.Text = val;
                                populateLbxFileList();
                            }
                        }
                    }
                }

                fileIn.Close();
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            writeConfigToFile(defaultConfigFileName);
        }

        private void writeConfigToFile(string filePath)
        {
            if (gameFolderPathTextBox.Text.Length > 0)
            {
                StreamWriter fileOut = new StreamWriter(filePath, false);

                string game_folder = "game_folder=" + gameFolderPathTextBox.Text;
                fileOut.WriteLine(game_folder);
                fileOut.Close();
            }
        }

        private void gameFolderPathTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (Directory.Exists(gameFolderPathTextBox.Text))
                    populateLbxFileList();
        }

        private void lbxFilesListBox_DoubleClick(object sender, EventArgs e)
        {
            // if the selection changed, update
            if (lbxFilesListBox.SelectedItem.ToString() != currentLBXFileLabel.Text)
            {
                currentLBXFileName = currentLBXFileLabel.Text = lbxFilesListBox.SelectedItem.ToString();
                update(UpdateType.LBX);
            }
        }

        /// <summary>
        /// General update handler that takes an UpdateType type and calls a specific updater and handles all exceptions thrown along the way.
        /// </summary>
        private void update(UpdateType type)
        {
            try
            {
                switch (type)
                {
                    case UpdateType.LBX:
                        updateLBX();
                        break;
                    case UpdateType.BLOCK:
                        updateBlock();
                        break;
                    case UpdateType.PALETTES:
                        updatePalettes();
                        break;
                    case UpdateType.FRAME:
                        updateFrame();
                        break;
                }

                errorLabel.Visible = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                errorLabel.Visible = true;
                errorLabel.Text = e.Message;
            }
        }

        /// <summary>
        /// Whoa, does this work?
        /// <para>paratextwee?</para>
        /// </summary>
        private void updateLBX()
        {
            LBXBlock block = new LBXBlock();

            // load new LBX
            lbxReader.close();
            lbxReader.open(gameFolderPathTextBox.Text + "\\" + currentLBXFileName);
            currentLBXBlock = 0;

            // update LBX file size label
            long size = lbxReader.getFileSize();
            if (size < 1048576)
            {
                float kbCount = (float)size / 1024.0f;
                currentLBXFileSizeLabel.Text = String.Format("{0:G4} KB", kbCount);
            }
            else
            {
                float mbCount = (float)size / 1048576.0f;
                currentLBXFileSizeLabel.Text = String.Format("{0:G4} MB", mbCount);
            }

            // enable or disable arrows accordingly
            if (lbxReader.getBlockCount() <= 1)
            {
                prevLBXBlockButton.Enabled = false;
                nextLBXBlockButton.Enabled = false;
            }
            else
            {
                prevLBXBlockButton.Enabled = false;
                nextLBXBlockButton.Enabled = true;
            }

            updateBlock();
        }

        private void updateBlock()
        {
            LBXBlock block = new LBXBlock();

            // make sure an LBX file is loaded first (avoids crash on startup)
            if (currentLBXFileName.Length > 0)
            {
                // update block counter label
                currentLBXBlockLabel.Text = currentLBXBlock.ToString() + " / " + (lbxReader.getBlockCount() - 1).ToString();
                lbxReader.read(block, currentLBXBlock);

                if (block.data != null)
                {
                    // load new block as an image
                    currentImage = new Image();
                    currentImage.setExternalPalette(palettes[currentPaletteIndex]);
                    currentImage.load(block);
                    currentImageFrame = 0;

                    // update image header display with whatever was read
                    imageHeaderWidthTextBox.Text = String.Format("{0:X2} {1:X2} ({2})", currentImage.getWidth() & 0xFF, (currentImage.getWidth() & 0xFF00) >> 8, currentImage.getWidth());
                    imageHeaderHeightTextBox.Text = String.Format("{0:X2} {1:X2} ({2})", currentImage.getHeight() & 0xFF, (currentImage.getHeight() & 0xFF00) >> 8, currentImage.getHeight());
                    imageHeaderZeroTextBox.Text = String.Format("{0:X2} {1:X2}", currentImage.getHeader().zero & 0xFF, (currentImage.getHeader().zero & 0xFF00) >> 8);
                    imageHeaderFrameCountTextBox.Text = String.Format("{0:X2} {1:X2} ({2})", currentImage.getHeader().frameCount & 0xFF, (currentImage.getHeader().frameCount & 0xFF00) >> 8, currentImage.getHeader().frameCount);
                    imageHeaderFrameDelayTextBox.Text = String.Format("{0:X2} {1:X2} ({2})", currentImage.getHeader().frameDelay & 0xFF, (currentImage.getHeader().frameDelay & 0xFF00) >> 8, currentImage.getHeader().frameDelay);
                    imageHeaderFlagsTextBox.Text = formatImageFlagsString(currentImage.getHeader().flags);

                    // if there's an internal palette currently locked, render with that
                    if (internalPaletteLockButton.Checked)
                        currentImage.render(lockedInternalPalette);
                    else
                    {
                        currentImage.render();
                        if (currentImage.getInternalPalette() != null)
                            internalPaletteLockButton.Enabled = true;
                        else
                            internalPaletteLockButton.Enabled = false;
                    }
                    updatePalettes();

                    // enable/disable the next/prev frame buttons as appropriate
                    if (currentImage.getHeader().frameCount <= 1)
                    {
                        prevImageFrameButton.Enabled = false;
                        nextImageFrameButton.Enabled = false;
                    }
                    else
                    {
                        prevImageFrameButton.Enabled = false;
                        nextImageFrameButton.Enabled = true;
                    }

                    // update the track bar with an appropriate number of zoom levels:
                    // computed as either log_2(640 / width) or log_2(480 / height) depending on which is greater;
                    // determine this via the aspect ratio
                    float ar = (float)currentImage.getWidth() / (float)currentImage.getHeight();
                    float range;

                    // if the image is tall and skinny, use the height
                    if (ar < (4.0f / 3.0f))
                        range = 480.0f / (float)currentImage.getHeight();
                    else
                        range = 640.0f / (float)currentImage.getWidth();

                    // add 1 tick mark for the stretch-to-fit option at the end
                    int tickCount = (int)Math.Floor(Math.Log(range, 2.0)) + 1;

                    // snap the old trackbar value to the new range
                    if (imageZoomTrackBar.Value > tickCount)
                        imageZoomTrackBar.Value = tickCount;

                    imageZoomTrackBar.Minimum = 0;  // start at 2^0 or 1x zoom
                    imageZoomTrackBar.Maximum = tickCount;
                    imageZoomTrackBar.TickFrequency = 1;
                    //imageZoomTrackBar.Value = 0;
                    imageZoomTrackBar_ValueChanged(null, null);
                }
            }
        }

        private void updatePalettes()
        {
            Graphics g;
            Palette mp;

            // draw the current external palette
            palettes[currentPaletteIndex].drawPalette((Bitmap)externalPalettePictureBox.Image, 10);
            externalPalettePictureBox.Refresh();

            // if there's a currently locked internal palette, draw that
            if (lockedInternalPalette != null)
            {
                lockedInternalPalette.drawPalette((Bitmap)internalPalettePictureBox.Image, 10);

                // then merge the two palettes into Palette mp
                mp = new Palette(palettes[currentPaletteIndex]);
                mp.merge(lockedInternalPalette);
            }
            // else draw the image's internal palette, if it exists
            else
            {
                if (currentImage.getInternalPalette() != null)
                {
                    currentImage.getInternalPalette().drawPalette((Bitmap)internalPalettePictureBox.Image, 10);

                    // and get its mixed palette
                    mp = currentImage.getMixedPalette();
                }
                else
                {
                    g = Graphics.FromImage(internalPalettePictureBox.Image);
                    g.Clear(Color.White);

                    // set mixed palette to the current external palette
                    mp = palettes[currentPaletteIndex];
                }
            }
            internalPalettePictureBox.Refresh();

            // draw mixed palette
            mp.drawPalette((Bitmap)mixedPalettePictureBox.Image, 10);
            mixedPalettePictureBox.Refresh();

            // if any of the palettes have changed, redraw the frame view
            updateFrame();
        }

        private void updateFrame()
        {
            // update frame counter label
            currentImageFrameLabel.Text = currentImageFrame.ToString() + " / " + (currentImage.getHeader().frameCount - 1).ToString();

            // update frame size and offset
            currentImageFrameSizeTextBox.Text = currentImage.getFrames()[currentImageFrame].size.ToString();
            currentImageFrameOffsetTextBox.Text = String.Format("{0:X8}", currentImage.getFrames()[currentImageFrame].offset);

             // if the image was parsed properly, update the picturebox with it
            if (currentImage.getFrames() != null)
            {
                Bitmap b = currentImage.getFrames()[currentImageFrame].bitmap;
                if (b != null)
                    imagePictureBox.Image = b;//.Clone(new Rectangle(0, 0, image.getWidth(), image.getHeight()), b.PixelFormat);
                else
                    imagePictureBox.Image = blankWhiteBitmap;
            }
            else
                imagePictureBox.Image = blankWhiteBitmap;
            imagePictureBox.Refresh();
        }

        private string formatImageFlagsString(ushort flags)
        {
            string result = "";
            // convert a ushort to binary with spaces between nibbles:
            // 0000 0000 0000 0000
            for (ushort b = 0; b < 16; ++b)
            {
                if ((flags & (1 << (15 - b))) != 0)
                    result = result + "1";
                else
                    result = result + "0";
                if (((b + 1) % 4) == 0 && b > 0)
                    result = result + " ";
            }

            return result;
        }

        private void imagePictureBox_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(imagePictureBox.ClientRectangle.ToString());
        }

        private void prevLBXBlockButton_Click(object sender, EventArgs e)
        {
            if (currentLBXBlock > 0)
            {
                if (ModifierKeys == Keys.Shift)
                    currentLBXBlock -= 10;
                else
                    currentLBXBlock--;

                if (currentLBXBlock < 0)
                    currentLBXBlock = 0;
                update(UpdateType.BLOCK);

                // if we've hit the beginning, disable prev button
                if (currentLBXBlock == 0)
                    prevLBXBlockButton.Enabled = false;
                // if we've just left the end, re-enable the next button
                if (currentLBXBlock == (lbxReader.getBlockCount() - 2))
                    nextLBXBlockButton.Enabled = true;
            }
        }

        private void nextLBXBlockButton_Click(object sender, EventArgs e)
        {
            if (currentLBXBlock < (lbxReader.getBlockCount() - 1))
            {
                // hold shift for 10x speed!
                if (ModifierKeys == Keys.Shift)
                    currentLBXBlock += 10;
                else
                    currentLBXBlock++;

                // if we overshoot the end, snap back
                if (currentLBXBlock >= (lbxReader.getBlockCount() - 1))
                    currentLBXBlock = lbxReader.getBlockCount() - 1;

                // update!
                update(UpdateType.BLOCK);

                // if we've hit the end, disable the next button
                if (currentLBXBlock == (lbxReader.getBlockCount() - 1))
                    nextLBXBlockButton.Enabled = false;
                // if we've just left the beginning, re-enable the prev button
                if (currentLBXBlock == 1)
                    prevLBXBlockButton.Enabled = true;
            }
        }

        private void prevImageFrameButton_Click(object sender, EventArgs e)
        {
            if (currentImageFrame > 0)
            {
                currentImageFrame--;
                update(UpdateType.FRAME);

                if (currentImageFrame == 0)
                    prevImageFrameButton.Enabled = false;
                if (currentImageFrame == (currentImage.getHeader().frameCount - 2))
                    nextImageFrameButton.Enabled = true;
            }
        }

        private void nextImageFrameButton_Click(object sender, EventArgs e)
        {
            if (currentImageFrame < (currentImage.getHeader().frameCount - 1))
            {
                currentImageFrame++;
                update(UpdateType.FRAME);

                if (currentImageFrame == (currentImage.getHeader().frameCount - 1))
                    nextImageFrameButton.Enabled = false;
                if (currentImageFrame == 1)
                    prevImageFrameButton.Enabled = true;
            }
        }

        private void imagePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (imagePictureBox.Image != null)
            {
                Rectangle r;

                // zoom factor of -1 means fit-to-window, otherwise it's a power of 2
                if (imageZoomFactor != -1)
                    r = new Rectangle(0, 0, imagePictureBox.Image.Width * imageZoomFactor, imagePictureBox.Image.Height * imageZoomFactor);
                else
                {
                    float ar = (float)imagePictureBox.Image.Width / (float)imagePictureBox.Image.Height;
                    float scale;
                    float sw, sh;

                    // scale to fit the window but keep the aspect ratio
                    if (ar < (4.0f / 3.0f))
                        scale = 480.0f / (float)imagePictureBox.Image.Height;
                    else
                        scale = 640.0f / (float)imagePictureBox.Image.Width;

                    sw = (float)imagePictureBox.Image.Width * scale;
                    sh = (float)imagePictureBox.Image.Height * scale;

                    r = new Rectangle(0, 0, (int)sw, (int)sh);
                }

                // draw images with nearest-neighbor sampling, not the default of bilinear
                e.Graphics.Clear(Color.White);
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(imagePictureBox.Image, r, 0, 0, imagePictureBox.Image.Width, imagePictureBox.Image.Height, GraphicsUnit.Pixel);
            }
            else
            {
                e.Graphics.Clear(Color.White);
            }
        }

        private void stretchImageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            imagePictureBox.Refresh();
        }

        private void palettesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPaletteIndex = palettesListBox.SelectedIndex;
            
            // update the current image, if present
            if (currentImage != null)
            {
                currentImage.setExternalPalette(palettes[currentPaletteIndex]);

                if (internalPaletteLockButton.Checked)
                    currentImage.render(lockedInternalPalette);
                else
                    currentImage.render();

                update(UpdateType.PALETTES);
            }
        }

        private void internalPaletteLockButton_CheckedChanged(object sender, EventArgs e)
        {
            if (internalPaletteLockButton.Checked)
            {
                internalPaletteLockButton.Text = "Unlock";
                lockedInternalPalette = new Palette(currentImage.getInternalPalette());
            }
            else
            {
                internalPaletteLockButton.Text = "Lock";
                lockedInternalPalette = null;

                if (currentImage != null)
                {
                    if (currentImage.getInternalPalette() != null)
                        internalPaletteLockButton.Enabled = true;
                    else
                        internalPaletteLockButton.Enabled = false;

                    // redraw the image with its own internal palette
                    currentImage.render();
                }

                update(UpdateType.PALETTES);
            }
        }

        private void zoom1XRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void imageZoomTrackBar_ValueChanged(object sender, EventArgs e)
        {
            // the tick mark represents a power of 2 magnification;
            // the final mark is stretch-to-fit, which is represented by -1
            if (imageZoomTrackBar.Value < imageZoomTrackBar.Maximum)
            {
                imageZoomFactor = (int)Math.Pow(2.0, imageZoomTrackBar.Value);
                imageZoomFactorLabel.Text = "x" + imageZoomFactor;
            }
            else
            {
                imageZoomFactor = -1;
                imageZoomFactorLabel.Text = "max";
            }

            imagePictureBox.Refresh();
        }

        private void loadFonts()
        {
            fontsListBox.BeginUpdate();

            fontsListBox.Items.Clear();
            fontsListBox.Items.Add("FONTS.LBX 0");
            fontsListBox.Items.Add("FONTS.LBX 1");
            fontsListBox.Items.Add("FONTS.LBX 2");
            fontsListBox.Items.Add("FONTS.LBX 3");
            fontsListBox.Items.Add("FONTS.LBX 4");
            fontsListBox.Items.Add("FONTS.LBX 5");

            fontsListBox.Items.Add("IFONTS.LBX 0");
            fontsListBox.Items.Add("IFONTS.LBX 1");
            fontsListBox.Items.Add("IFONTS.LBX 2");
            fontsListBox.Items.Add("IFONTS.LBX 3");
            fontsListBox.Items.Add("IFONTS.LBX 4");
            fontsListBox.Items.Add("IFONTS.LBX 5");

            fontsListBox.SelectedIndex = 0;

            fontsListBox.EndUpdate();

            //Font f = new Font();
        }

        //private void testButton_Click(object sender, EventArgs e)
        //{
        //    LBXBlock block = new LBXBlock();

        //    lbxReader.close();
        //    lbxReader.open(gameFolderPathTextBox.Text + "\\FONTS.LBX");

        //    Palette pal = new Palette();
        //    lbxReader.read(block, 0);
        //    pal.load(block);

        //    // read fonts from index 0
        //    lbxReader.read(block, 0);

        //    byte[,] glyphWidths = new byte[6, 256];
        //    uint[,] glyphOffsets = new uint[6, 256];

        //    BinaryReader data = new BinaryReader(new MemoryStream(block.data));
        //    data.BaseStream.Position = 0x59C;

        //    // read glyph widths for the 6 fonts
        //    for (int i = 0; i < 6; ++i)
        //    {
        //        for (int j = 0; j < 256; ++j)
        //        {
        //            glyphWidths[i, j] = data.ReadByte();
        //        }
        //    }

        //    // read the glyph offsets
        //    for (int i = 0; i < 6; ++i)
        //    {
        //        for (int j = 0; j < 256; ++j)
        //        {
        //            glyphOffsets[i, j] = data.ReadUInt32();
        //        }
        //    }

            
        //    Bitmap result = new Bitmap(640, 480);
        //    uint glyphDataLength;
        //    int gx, gy, cx, cy, ci;
        //    byte val;
        //    Color color;

        //    int fontIndex = 0;// Int32.Parse(fontIndexTextBox.Text);

        //    // attempt to draw the first 10 glyphs
        //    for (int i = 0; i < 128; ++i)
        //    {
        //        data.BaseStream.Position = glyphOffsets[fontIndex, i] + 0x239C;

        //        glyphDataLength = glyphOffsets[fontIndex, i + 1] - glyphOffsets[fontIndex, i];

        //        // starting coords of glyph, arrange the 96 chars in a 12x8 grid
        //        gx = ((i - 0) % 16) * 25 + 10;
        //        gy = ((i - 0) / 16) * 25 + 10;

        //        cx = gx;
        //        cy = gy;

        //        try
        //        {
        //            while ((data.BaseStream.Position - 0x239C - glyphOffsets[fontIndex, i]) < glyphDataLength)
        //            {
        //                val = data.ReadByte();

        //                // 0x00-0x7f: color of next pixel
        //                if (val <= 0x7F)
        //                {
        //                    color = Color.FromArgb((int)pal[val]);
        //                    //ci = 
        //                    //color = Color.FromArgb(255, ci);
        //                    if (cx > 0 && cx < 640 && cy > 0 && cy < 480)
        //                        result.SetPixel(cx, cy, color);
        //                    cx++;
        //                }
        //                // 0x80: skip to beginning of next line
        //                else if (val == 0x80)
        //                {
        //                    cx = gx;
        //                    cy++;
        //                }
        //                // 0x8n: skip n pixels
        //                else
        //                {
        //                    cx += (val & 0x0F);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            //
        //        }
        //    }
             

        //    pictureBox1.Image = result;
        //    pictureBox1.Refresh();
        //}

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Rectangle r = new Rectangle(0, 0, pictureBox1.ClientRectangle.Width, pictureBox1.ClientRectangle.Height);
                // draw images with nearest-neighbor sampling, not the default of bilinear
                //e.Graphics.Clear(Color.White);
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(pictureBox1.Image, r, 0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height, GraphicsUnit.Pixel);
            }
            else
            {
                e.Graphics.Clear(Color.White);
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            LBXBlock block = new LBXBlock();

            // FONTS.LBX and IFONTS.LBX both contain palettes and fonts
            lbxReader.close();
            lbxReader.open(gameFolderPathTextBox.Text + "\\" + "FONTS.LBX");

            // load a palette to use
            lbxReader.read(block, 1);
            Palette pal = new Palette();
            // force the last palette entry to white
            block.data[0xFF * 4 + 0] = 0xFF;
            block.data[0xFF * 4 + 1] = 0x33;
            block.data[0xFF * 4 + 2] = 0x33;
            block.data[0xFF * 4 + 3] = 0x33;
            pal.load(block);

            lbxReader.close();
            lbxReader.open(gameFolderPathTextBox.Text + "\\" + "IFONTS.LBX");

            lbxReader.read(block, 0);
            Font font = new Font();

            // FONT THING
            font.load(block, 5);
            
            font.palette = pal;

            Bitmap b = new Bitmap(640, 480);
            Graphics gg = Graphics.FromImage(b);
            gg.Clear(Color.White);

            /*
            for (int g = 32; g < 128; ++g)
            {
                int x = (g % 16) * (font.maxGlyphWidth + 1) + 1;
                int y = (g / 16) * (font.maxGlyphHeight + 1) + 1;
                font.renderGlyph((byte)g, b, x, y);
            }
            */
             
            font.renderString("Hello, Xus. :)", b, 10, 10);
            font.renderString(@"This seems to be working more or less? 2 + 2 = 4 (usually) \o/ :P", b, 10, 200);
            pictureBox1.Image = b;
            pictureBox1.Refresh();

            string colorList = "";

            for (int i = 0; i < 128; ++i)
            {
                if (font.glyphColors[i] > 0)
                    colorList = colorList + i.ToString() + " ";
            }
            fontColorsListTextBox.Text = colorList;

            lbxReader.close();
        }   
    }
}
