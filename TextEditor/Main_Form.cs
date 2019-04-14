using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName,
                        RichTextBoxStreamType.RichText); //пытаемся загрузить текст как RTF
                }
                catch (System.ArgumentException ex)
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName,
                        RichTextBoxStreamType.PlainText); //пытаемся загрузить текст как обычный
                }
                this.Text = openFileDialog1.FileName; //устанавливаем в заголовок окна имя откр-го файла
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
                this.Text = saveFileDialog1.FileName; //отображает имя сохр-го файла
            }
        }

        private void qToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //изменения в док-е будут утеряны
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo(); //отменить
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo(); //вперёд (повторить)
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut(); //вырезать
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy(); //копировать
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste(); //вставить
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font; //шрифт
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color; //цвет
            }

        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left; //выравнивание по левому боку
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right; //выравнивание по правому боку
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center; //выравнивание по центру
        }
        //проверка стилей       
        private void CheckMenuFontCharacterStyle()
        {
            if (richTextBox1.SelectionFont.Bold == true)
                boldToolStripMenuItem.Checked = true;
            else boldToolStripMenuItem.Checked = false;

            if (richTextBox1.SelectionFont.Italic == true)
                italicToolStripMenuItem.Checked = true;
            else italicToolStripMenuItem.Checked = false;

            if (richTextBox1.SelectionFont.Underline == true)
                underlineToolStripMenuItem.Checked = true;
            else underlineToolStripMenuItem.Checked = false;

            if (richTextBox1.SelectionFont.Strikeout == true)
                strikeoutToolStripMenuItem.Checked = true;
            else strikeoutToolStripMenuItem.Checked = false;
        }
        //жирный текст
        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Bold == true)
                    newFontStyle = FontStyle.Regular;
                else
                    newFontStyle = FontStyle.Bold;

                richTextBox1.SelectionFont = new Font(
                    currentFont.FontFamily, currentFont.Size, newFontStyle);

                CheckMenuFontCharacterStyle();
            }
        }
        //курсив
        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                CheckMenuFontCharacterStyle();

                if (richTextBox1.SelectionFont.Italic == true)
                    newFontStyle = FontStyle.Regular;
                else
                    newFontStyle = FontStyle.Italic;

                richTextBox1.SelectionFont = new Font(
                    currentFont.FontFamily, currentFont.Size, newFontStyle);

                CheckMenuFontCharacterStyle();
            }
        }
        //зачёркивание
        private void strikeoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Strikeout == true)
                    newFontStyle = FontStyle.Regular;
                else
                    newFontStyle = FontStyle.Strikeout;

                richTextBox1.SelectionFont = new Font(
                    currentFont.FontFamily, currentFont.Size, newFontStyle);

                CheckMenuFontCharacterStyle();
            }
        }
        //подчёркивание
        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                CheckMenuFontCharacterStyle();

                if (richTextBox1.SelectionFont.Underline == true)
                    newFontStyle = FontStyle.Regular;
                else
                    newFontStyle = FontStyle.Underline;

                richTextBox1.SelectionFont = new Font(
                    currentFont.FontFamily, currentFont.Size, newFontStyle);

                CheckMenuFontCharacterStyle();
            }
        }
        //о программе
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Новый текстовый редактор!", "О программе", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) //помощь
        {
            Form1 HelpProgram = new Form1();
            HelpProgram.Show();
        }

        private void insertPictureToolStripMenuItem_Click(object sender, EventArgs e) //вставка картинки 
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Images | *.png;*.jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(dialog.FileName);
                Clipboard.SetImage(image);
                richTextBox1.Paste();
            }
        }
    }
}
