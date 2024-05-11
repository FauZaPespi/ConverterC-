using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageConverter
{
    /// <summary>
    /// Auteur: FauZaPespi
    /// Date: 11/05/2024
    /// Website: https://discord.palms.lol
    /// Fichier: Form1.cs
    /// Objectif: Faire un programme pour convertir juste comme ca flm de tous ces mecs...
    /// </summary>
    public partial class Main : Form
    {
        /// <summary>
        /// Methode de main t con ou quoi ?
        /// </summary>
        public Main()
        {
            InitializeComponent();
            comboBoxFormat.Items.AddRange(new string[] { "ICO", "PNG", "JPG", "GIF" });
            comboBoxFormat.SelectedIndex = 0;  
        }
        /// <summary>
        /// Methode pour ouvrir le dialog etc ta crampter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.gif)|*.bmp;*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.gif|All files (*.*)|*.*";
            openFileDialog1.Title = "Select an Image";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
        /// <summary>
        /// Pour convertir en ico parce que sinon ca fait de la merde vu que les .ico c compliquer comme un casse tete ce mec
        /// </summary>
        /// <param name="image"></param>
        /// <param name="filePath"></param>
        /// <param name="size"></param>
        private void ConvertToIcon(Image image, string filePath, int size)
        {
            using (Bitmap squareBitmap = new Bitmap(size, size))
            using (Graphics g = Graphics.FromImage(squareBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, size, size);
                using (Icon icon = Icon.FromHandle(squareBitmap.GetHicon()))
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        icon.Save(fs);
                    }
                }
            }
        }

        /// <summary>
        /// Methode pour le boutton qui converti ca mere !!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please select an image first.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "output";

            switch (comboBoxFormat.SelectedItem.ToString())
            {
                case "ICO":
                    saveFileDialog.Filter = "Icon files (*.ico)|*.ico";
                    break;
                case "PNG":
                    saveFileDialog.Filter = "PNG files (*.png)|*.png";
                    break;
                case "JPG":
                    saveFileDialog.Filter = "JPEG files (*.jpg)|*.jpg";
                    break;
                case "GIF":
                    saveFileDialog.Filter = "GIF files (*.gif)|*.gif";
                    break;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Save the image in the selected format
                switch (comboBoxFormat.SelectedItem.ToString())
                {
                    case "ICO":
                        ConvertToIcon(pictureBox1.Image, saveFileDialog.FileName, 256);
                        break;
                    case "PNG":
                        pictureBox1.Image.Save(saveFileDialog.FileName, ImageFormat.Png);
                        break;
                    case "JPG":
                        pictureBox1.Image.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                        break;
                    case "GIF":
                        pictureBox1.Image.Save(saveFileDialog.FileName, ImageFormat.Gif);
                        break;
                }
                MessageBox.Show("Image saved successfully.");
            }
        }

        private void lblPalms_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.palms.lol");
        }

        #region truc de merde c juste pour le link pour faire un effet de hover
        /// <summary>
        /// Truc pour quand ca entre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblPalms_MouseEnter(object sender, EventArgs e)
        {
            lblPalms.ForeColor = Color.SeaGreen;
        }
        /// <summary>
        /// Truc pour quand ca sort fdp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblPalms_MouseLeave(object sender, EventArgs e)
        {
            lblPalms.ForeColor = Color.LightSeaGreen;
        }
        #endregion
    }
}

/// Si tu skid t'es gay


