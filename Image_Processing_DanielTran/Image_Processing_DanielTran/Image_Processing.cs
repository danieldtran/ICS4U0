using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Image_Processing_DanielTran
{
    public partial class formImageProcess : Form
    {
        public formImageProcess()
        {
            InitializeComponent();
        }

        Bitmap bitmapImage;
        Color[,] ImageArray = new Color[320, 240];
        Color[,] ImageArray2 = new Color[320, 240];

        private void SetBitmapFromArray()
        {
            for (int row = 0; row < 320; row++)
            {
                for (int col = 0; col < 240; col++)
                {
                    bitmapImage.SetPixel(row, col, ImageArray[row, col]);
                }
            }
        }

        private void SetArrayFromBitmap()
        {
            try
            {
                for (int row = 0; row < 320; row++)
                {
                    for (int col = 0; col < 240; col++)
                    {
                        ImageArray[row, col] = bitmapImage.GetPixel(row, col);
                        //makes another array of the original image
                        //ImageArray2 will always be the original image
                        ImageArray2[row, col] = bitmapImage.GetPixel(row, col);
                    }
                }
            }
            catch
            {
                return;
            }
        }

        public void ResetArray()
        {
            //current array becomes original image
            for (int row = 0; row < 320; row++)
            {
                for (int col = 0; col < 240; col++)
                {
                    ImageArray[row, col] = ImageArray2[row, col];
                }
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                Stream myStream = null;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                //   openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
                openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.Title = "Image Browser";


                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        Image newImage = Image.FromStream(myStream);
                        bitmapImage = new Bitmap(newImage, 320, 240);
                        picImage.Image = bitmapImage;
                        myStream.Close();
                    }
                }

                SetArrayFromBitmap();
            }
            catch
            {
                MessageBox.Show("Please select a valid image");
            }
        }

        private void btnTransform_Click(object sender, EventArgs e)
        {
            int iWidth = 320;
            int iHeight = 240;
            
            if (cbFilter.Text == "Extract Red")
            {
                if (bitmapImage == null)
                    return;
                for (int i = 0; i < iWidth; i++)
                {
                    for (int j = 0; j < iHeight; j++)
                    {
                        Color col = ImageArray[i, j];
                        // The sample code extracts the red channel of a pixel and assign the color only to red channel
                        Byte bRed;
                        bRed = col.R;

                        Color newColor = Color.FromArgb(255, bRed, 0, 0);
                        ImageArray[i, j] = newColor;
                    }
                }
                SetBitmapFromArray();
                picImage.Image = bitmapImage;
            }
            else if (cbFilter.Text == "Extract Green")
            {
                if (bitmapImage == null)
                    return;
                for (int i = 0; i < iWidth; i++)
                {
                    for (int j = 0; j < iHeight; j++)
                    {
                        Color col = ImageArray[i, j];
                        // The sample code extracts the green channel of a pixel and assign the color only to green channel
                        byte bGreen;
                        bGreen = col.G;

                        Color newColor = Color.FromArgb(255, 0, bGreen, 0);
                        ImageArray[i, j] = newColor;
                    }
                }
                SetBitmapFromArray();
                picImage.Image = bitmapImage;
            }
            else if (cbFilter.Text == "Extract Blue")
            {
                if (bitmapImage == null)
                    return;
                for (int i = 0; i < iWidth; i++)
                {
                    for (int j = 0; j < iHeight; j++)
                    {
                        Color col = ImageArray[i, j];
                        // The sample code extracts the blue channel of a pixel and assign the color only to blue channel
                        byte bBlue;
                        bBlue = col.B;

                        Color newColor = Color.FromArgb(255, 0, 0, bBlue);
                        ImageArray[i, j] = newColor;
                    }
                }
                SetBitmapFromArray();
                picImage.Image = bitmapImage;
            }
            else if (cbFilter.Text == "Negative")
            {
                if (bitmapImage == null)
                    return;
                for (int i = 0; i < iWidth; i++)
                {
                    for (int j = 0; j < iHeight; j++)
                    {
                        Color col = ImageArray[i, j];

                        Color newColor = Color.FromArgb(255, 255 - col.R, 255 - col.G, 255 - col.B);
                        ImageArray[i, j] = newColor;
                    }
                }
                SetBitmapFromArray();
                picImage.Image = bitmapImage;
            }
            else if (cbFilter.Text == "Lighten")
            {
                if (bitmapImage == null)
                    return;
                int iRed, iGreen, iBlue;
                for (int i = 0; i < iWidth; i++)
                {
                    for (int j = 0; j < iHeight; j++)
                    {
                        Color col = ImageArray[i, j];
                        //multiplies the rgb values by an amount such that the brightess the user can go is 255
                        iGreen = (int)Math.Min(255, col.G + 255 * 0.05);
                        iBlue = (int)Math.Min(255, col.B + 255 * 0.05);
                        iRed = (int)Math.Min(255, col.R + 255 * 0.05);

                        Color newColor = Color.FromArgb(255, iRed, iGreen, iBlue);
                        ImageArray[i, j] = newColor;
                    }
                }
                SetBitmapFromArray();
                picImage.Image = bitmapImage;
            }
            else if (cbFilter.Text == "Darken")
            {
                if (bitmapImage == null)
                    return;
                int iRed, iGreen, iBlue;
                for (int i = 0; i < iWidth; i++)
                {
                    for (int j = 0; j < iHeight; j++)
                    {
                        Color col = ImageArray[i, j];
                        //mulitplies the rgb values by an amount such that the user can not darken further than 0
                        iGreen = (int)Math.Max(0, col.G - 255 * 0.05);
                        iBlue = (int)Math.Max(0, col.B - 255 * 0.05);
                        iRed = (int)Math.Max(0, col.R - 255 * 0.05);

                        Color newColor = Color.FromArgb(255, iRed, iGreen, iBlue);
                        ImageArray[i, j] = newColor;
                    }
                }
                SetBitmapFromArray();
                picImage.Image = bitmapImage;
            }
            else if (cbFilter.Text == "Sunset Effect")
            {
                if (bitmapImage == null)
                    return;
                int iRed, iGreen, iBlue;
                for (int i = 0; i < iWidth; i++)
                {
                    for (int j = 0; j < iHeight; j++)
                    {
                        Color col = ImageArray[i, j];

                        iRed = col.R;
                        iGreen = col.G;
                        iBlue = col.B;
                        //add more red
                        iRed = (int)Math.Min(255, col.R + 255 * 0.05);
                        //extract blue
                        iBlue = (int)Math.Max(0, col.B - 255 * 0.05);
                        Color newColor = Color.FromArgb(255, iRed, iGreen, iBlue);
                        ImageArray[i, j] = newColor;
                    }
                }
                SetBitmapFromArray();
                picImage.Image = bitmapImage;
            }
            else if (cbFilter.Text == "Grayscale")
            {
                if (bitmapImage == null)
                    return;
                for (int i = 0; i < iWidth; i++)
                {
                    for (int j = 0; j < iHeight; j++)
                    {
                        Color col = ImageArray[i, j];
                        //average the red, green, and blue values
                        int Gray = (col.R + col.G + col.B) / 3;
                        //display the average of red, green, and blue
                        Color newColor = Color.FromArgb(255, Gray, Gray, Gray);
                        ImageArray[i, j] = newColor;
                    }
                }
                SetBitmapFromArray();
                picImage.Image = bitmapImage;
            }
            else if (cbFilter.Text == "Polarize")
            {
                if (bitmapImage == null)
                    return;
                int iRedAvg = 0, iGreenAvg = 0, iBlueAvg = 0;
                int iRed, iGreen, iBlue;
                for (int i = 0; i < iWidth; i++)
                {
                    for (int j = 0; j < iHeight; j++)
                    {
                        Color col = ImageArray[i, j];
                        // get the sum of each red, green, blue value
                        iRedAvg += col.R;
                        iGreenAvg += col.G;
                        iBlueAvg += col.B;

                    }
                }
                // divide by number of pixels
                iRedAvg /= (320 * 240);
                iGreenAvg /= (320 * 240);
                iBlueAvg /= (320 * 240);
                for (int i = 0; i < iWidth; i++)
                {
                    for (int j = 0; j < iHeight; j++)
                    {
                        Color col = ImageArray[i, j];
                        iRed = col.R;
                        iGreen = col.G;
                        iBlue = col.B;
                        //compare the averages to the current values
                        //if the current value is higher than the average, change to 255
                        //if the curent value is less than the average, change to 0
                        //compare red
                        if (iRed > iRedAvg)
                        {
                            iRed = 255;
                        }
                        else
                        {
                            iRed = 0;
                        }
                        //compare green
                        if (iGreen > iGreenAvg)
                        {
                            iGreen = 255;
                        }
                        else
                        {
                            iGreen = 0;
                        }
                        //compare blue
                        if (iBlue > iBlueAvg)
                        {
                            iBlue = 255;
                        }
                        else
                        {
                            iBlue = 0;
                        }
                        Color newColor = Color.FromArgb(255, iRed, iGreen, iBlue);
                        ImageArray[i, j] = newColor;
                    }
                }
                SetBitmapFromArray();
                picImage.Image = bitmapImage;
            }
            else if (cbFilter.Text == "Flip Horizontally")
            {
                if (bitmapImage == null)
                    return;
                //go to half of the width of the picture in order to reflect
                //take each pixel and swap horizontally
                for (int i = 0; i < iWidth / 2; i++)
                {
                    for (int j = 0; j < iHeight; j++)
                    {
                        Color temp = ImageArray[i, j];
                        ImageArray[i, j] = ImageArray[iWidth - 1 - i, j];
                        ImageArray[iWidth - 1 - i, j] = temp;
                    }
                }
                SetBitmapFromArray();
                picImage.Image = bitmapImage;
            }
            else if (cbFilter.Text == "Flip Vertically")
            {
                if (bitmapImage == null)
                    return;
                for (int i = 0; i < iWidth; i++)
                {
                    //go to half of height of the picture in order to reflect
                    //take each pixel and swap vertically
                    for (int j = 0; j < iHeight / 2; j++)
                    {
                        Color temp = ImageArray[i, j];
                        ImageArray[i, j] = ImageArray[i, iHeight - 1 - j];
                        ImageArray[i, iHeight - 1 - j] = temp;
                    }
                }
                SetBitmapFromArray();
                picImage.Image = bitmapImage;
            }
            else if (cbFilter.Text == "Rotate 180 degrees")
            {
                if (bitmapImage == null)
                    return;
                //perform both flips
                //first flip horizontally
                for (int i = 0; i < iWidth / 2; i++)
                {
                    for (int j = 0; j < iHeight; j++)
                    {
                        Color temp = ImageArray[i, j];
                        ImageArray[i, j] = ImageArray[iWidth - 1 - i, j];
                        ImageArray[iWidth - 1 - i, j] = temp;
                    }
                }
                //flip vertically
                for (int i = 0; i < iWidth; i++)
                {
                    for (int j = 0; j < iHeight / 2; j++)
                    {
                        Color temp = ImageArray[i, j];
                        ImageArray[i, j] = ImageArray[i, iHeight - 1 - j];
                        ImageArray[i, iHeight - 1 - j] = temp;
                    }
                }
                SetBitmapFromArray();
                picImage.Image = bitmapImage;
            }
            else if (cbFilter.Text == "Switch top left and bottom right")
            {
                if (bitmapImage == null)
                    return;
                for (int i = 0; i < iWidth / 2; i++)
                {
                    for (int j = 0; j < iHeight / 2; j++)
                    {
                        Color col = ImageArray[i, j];
                        //swap the pixels in the top left and bottom right quadrants
                        ImageArray[i, j] = ImageArray[iWidth / 2 + i, iHeight / 2 + j];
                        ImageArray[iWidth / 2 + i, iHeight / 2 + j] = col;
                    }
                }
                SetBitmapFromArray();
                picImage.Image = bitmapImage;
            }
            else if (cbFilter.Text == "Pixellate")
            {
                if (bitmapImage == null)
                    return;
                //makes 4x4 blocks
                int iBlocks = 4;
                //every block x block
                for (int i = 0; i < iWidth; i += iBlocks)
                {
                    for (int j = 0; j < iHeight; j += iBlocks)
                    {
                        //col represents the top left corner
                        Color col = ImageArray[i, j];
                        //makes every pixel within the block pixel the same colour as the top left corrner
                        for (int k = 0; k < iBlocks; k++)
                        {
                            for (int l = 0; l < iBlocks; l++)
                            {
                                ImageArray[i + k, j + l] = col;
                            }
                        }
                    }
                }
                SetBitmapFromArray();
                picImage.Image = bitmapImage;
            }
            else if (cbFilter.Text == "Sort")
            {
                if (bitmapImage == null)
                    return;
                int iAvg, iAvg2;
                //go through every pixel
                for (int i = 0; i < iWidth; i++)
                {
                    for (int j = 0; j < iHeight; j++)
                    {
                        Color col = ImageArray[i, j];
                        iAvg = (col.R + col.G + col.B) / 3;
                        //insertion sort loop
                        int k;
                        for (k = i - 1; k >= 0; k--)
                        {
                            Color col2 = ImageArray[k, j];
                            iAvg2 = (col2.R + col2.G + col2.B) / 3;
                            //compare the average values and sort
                            if (iAvg < iAvg2)
                            {
                                ImageArray[k + 1, j] = ImageArray[k, j];
                            }
                            else
                                break;
                        }
                        //sort darkest to lightest
                        ImageArray[k + 1, j] = col;
                    }
                }
                SetBitmapFromArray();
                picImage.Image = bitmapImage;
            }
            else if (cbFilter.Text == "Tile")
            {
                if (bitmapImage == null)
                    return;
                Color[,] tempArray = new Color[320, 240];
                //make a temporary array that is tthe current array
                for (int i = 0; i < iWidth; i++)
                {
                    for (int j = 0; j < iHeight; j++)
                    {
                        tempArray[i, j] = ImageArray[i, j];
                    }
                }
                //make the first quadrant which is the a miniature version of the original picture
                //every 2x2 pixel of the original image is 1x1 in the miniature picturer
                //in the the top left quadrant
                //a and b represent the miniature picture's dimensions
                int a = 0, b = 0;
                for (int i = 0; i < iWidth; i += 2)
                {
                    for (int j = 0; j < iHeight; j += 2)
                    {
                        ImageArray[a, b] = tempArray[i, j];
                        //going down the column
                        b += 1;
                    }
                    //once the column finishes, it breaks the loop and moves to the next column
                    a += 1;
                    //restarts from top to bottom
                    b = 0;
                }
                //flip horizontally
                for (int i = 0; i < iWidth / 2; i++)
                {
                    for (int j = 0; j < iHeight / 2; j++)
                    {
                        ImageArray[iWidth - 1 - i, j] = ImageArray[i, j];

                    }
                }
                //flip vertically
                for (int i = 0; i < iWidth / 2; i++)
                {
                    for (int j = 0; j < iHeight / 2; j++)
                    {
                        ImageArray[i, iHeight - 1 - j] = ImageArray[i, j];

                    }
                }
                //rotate 180 degrees
                for (int i = 0; i < iWidth / 2; i++)
                {
                    for (int j = 0; j < iHeight / 2; j++)
                    {
                        ImageArray[iWidth - 1 - i, iHeight - 1 - j] = ImageArray[i, j];

                    }
                }
                SetBitmapFromArray();
                picImage.Image = bitmapImage;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (bitmapImage == null)
                return;
            //current image becomes the original image
            ResetArray();
            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Images (*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bitmapImage.Save(sfd.FileName);
                    MessageBox.Show("Image saved succesfully");
                }
            }
            catch
            {
                MessageBox.Show("Image was not save");//if could not save for any reason
            }
        }
    }
}
