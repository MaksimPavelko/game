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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace TextEditionPavelko
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //Проверяем был ли выбран файл
            {
                richTextBox.Clear(); //Очищаем richTextBox
                openFileDialog1.Filter = "Text Files (*.txt)|*.txt"; //Указываем что нас интересуют только текстовые файлы
                string fileName = openFileDialog1.FileName; //получаем наименование файл и путь к нему.
                richTextBox.Text = File.ReadAllText(fileName, Encoding.GetEncoding(1251)); //Передаем содержимое файла в richTextBox
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt";//Задаем доступные расширения
            saveFileDialog1.DefaultExt = ".txt"; //Задаем расширение по умолчанию 3
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) //Проверяем подтверждение сохранения информации.
            {
                var name = saveFileDialog1.FileName; //Задаем имя файлу
                File.WriteAllText(name, richTextBox.Text, Encoding.GetEncoding(1251)); //Записываем в файл содержимое textBox с кодировкой 1251
            }
              richTextBox.Clear();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectedText != "")
                richTextBox.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionLength > 0)

                richTextBox.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                
                if (richTextBox.SelectionLength > 0)
                {
                    
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)

                        richTextBox.SelectionStart = richTextBox.SelectionStart + richTextBox.SelectionLength;
                }

                richTextBox.Paste();
            }
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "";
            richTextBox.Clear();
        }

        private void CutButton_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectedText != "")
                richTextBox.Cut();
        }

        private void Copybutton_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionLength > 0)

                richTextBox.Copy();
        }

        private void Pastebutton_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {

                if (richTextBox.SelectionLength > 0)
                {

                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)

                        richTextBox.SelectionStart = richTextBox.SelectionStart + richTextBox.SelectionLength;
                }

                richTextBox.Paste();
            }
        }

        private void Clearbutton_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "";
            richTextBox.Clear();
        }

        private void Selectbutton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(richTextBox.Text))
            {
                richTextBox.Select();
                richTextBox.SelectAll();
            }
        }

        private void alignmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Select();
            richTextBox.SelectAll();
            richTextBox.SelectionAlignment = HorizontalAlignment.Center;

            richTextBox.DeselectAll();

        }

        private void LeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void RightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionAlignment = HorizontalAlignment.Right;
        }
    }
}
