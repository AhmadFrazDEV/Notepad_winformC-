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
namespace Notepad
{
    public partial class notePadForm : Form
    {
        private OpenFileDialog openfileDio;
        private SaveFileDialog savefileDio;
        private FontDialog fontfileDio;


        public notePadForm()
        {
            InitializeComponent();
        }

        private void notePadForm_Load(object sender, EventArgs e)
        {
            
        }

        private void newFile()
        {
            try
            {
                if(!string.IsNullOrEmpty(this.txtbox.Text))
                {
                    MessageBox.Show("You have to Save this file First");
                }
                else
                {
                    this.txtbox.Text = string.Empty;
                }


            }
            catch(Exception ex)
            {

            }
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFile();
                Application.Exit();
            }
            catch(Exception ex)
            {

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveFile()
        {
            savefileDio = new SaveFileDialog();
            savefileDio.Filter = "Text File(*txt) | *.txt  ";
            try
            {
                if (!string.IsNullOrEmpty(txtbox.Text))
                {  
                    if (savefileDio.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(savefileDio.FileName, txtbox.Text);
                    }
                   
                }
                else
                {
                    MessageBox.Show("file is empty");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private  void openfile()
        {
            openfileDio = new OpenFileDialog();
             try
            {
                if (openfileDio.ShowDialog() == DialogResult.OK)
                {
                    txtbox.Text = File.ReadAllText(openfileDio.FileName);
                    this.Text = openfileDio.FileName;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error while opening the file");
            }
            finally
            {
                openfileDio = null;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openfile();
        }

        private void saveAs()
        {
            savefileDio = new SaveFileDialog();
            savefileDio.Filter = "Text File(*txt) | *.txt !All Files(*.*)| *.*  ";
            try
            {
                if (!string.IsNullOrEmpty(this.txtbox.Text))
                {


                    if (savefileDio.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(savefileDio.FileName, txtbox.Text);
                    }
                    else
                    {
                        MessageBox.Show("file is empty");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontfileDio = new FontDialog();
            try
            {
                if(!string.IsNullOrEmpty(txtbox.Text))
                {
                    if (fontfileDio.ShowDialog() == DialogResult.OK)
                    {
                        txtbox.Font = fontfileDio.Font;
                    }
                }
            }
            catch(Exception ex)
            { }
        }
    }
}
