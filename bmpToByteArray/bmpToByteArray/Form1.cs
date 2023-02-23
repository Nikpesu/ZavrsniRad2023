using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace bmpToByteArray
{
    public partial class Form1 : Form
    {
        string programDirectory;
        string pixelColorStringValue = "";
        public Form1()
        {

            InitializeComponent();
            programDirectory = Directory.GetCurrentDirectory();
            try { Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + @"\input"); }
            catch{ }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            
            try
            {
                comboBox1.Items.Clear();
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
                foreach (string file in files)
                    comboBox1.Items.Add(file); 
            }catch(Exception ex) { richTextBox1.Text = DateTime.Now.ToString() + " => " + ex.Message + "\n" + richTextBox1.Text; } 
            
        }
        
        private void Process_Click(object sender, EventArgs e)
        {
            try
            {
                
                int SUSY = comboBox1.SelectedIndex;
            //comboBox1.GetItemText(comboBox1.SelectedIndex)
                Bitmap myBitmap = new Bitmap(Convert.ToString(comboBox1.Text), true);
                pixelColorStringValue = myBitmap.Height + "x" + myBitmap.Width;
                for (int x = 0; x < myBitmap.Width; x++)
                {
                    for (int y = 0; y < myBitmap.Height; y++)
                    {
                        // Get the color of a pixel within myBitmap.
                        Color pixelColor = myBitmap.GetPixel(x, y);
                         pixelColorStringValue +=
                            Start.Text +
                            pixelColor.R.ToString("D3") + Separator.Text +
                            pixelColor.G.ToString("D3") + Separator.Text +
                            pixelColor.B.ToString("D3") + End.Text;
                        

                        if (y < myBitmap.Height - 1) pixelColorStringValue += EOL.Text;
                    }
                    textBox1.Text = pixelColorStringValue;
                    if (x < myBitmap.Width - 1) pixelColorStringValue += EOL.Text;
                }
                richTextBox1.Text = DateTime.Now.ToString() + " => " + "Sucess!" + "\n\n" + richTextBox1.Text;
                textBox1.Text= pixelColorStringValue;
                myBitmap.Dispose();
            }
            catch (Exception ex) { richTextBox1.Text = DateTime.Now.ToString() + " => " + ex.Message + "\n" + richTextBox1.Text; }

        }

        private void export_Click(object sender, EventArgs e)
        {

            try{
                if (!Directory.Exists(programDirectory + @"\export\"))
                {
                    Directory.CreateDirectory(programDirectory + @"\export\");
                }
                if(pixelColorStringValue != "")
                {
                    File.WriteAllText(programDirectory + @"\export\" + DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".txt", pixelColorStringValue);
                    richTextBox1.Text = DateTime.Now.ToString() + " => " + "Exported! (" + programDirectory + @"\export\" + DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".txt" + ")\n\n" + richTextBox1.Text;
                } else richTextBox1.Text = DateTime.Now.ToString() + " => " + "Nothing to export!" + "\n" + richTextBox1.Text;

            }
            catch(Exception ex) { richTextBox1.Text = DateTime.Now.ToString() + " => " + ex.Message + "\n" + richTextBox1.Text; }


        }

        private void browse_click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Choose image";
                openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() ;
                openFileDialog1.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    comboBox1.SelectedText= openFileDialog1.FileName;
                    comboBox1.Text = openFileDialog1.FileName;
                    comboBox1_DropDown(sender, e);
                    Directory.SetCurrentDirectory(Directory.GetParent(openFileDialog1.FileName).ToString());
                    
                }
            
                //Process_Click( sender,  e);
            }
            catch (Exception ex) { richTextBox1.Text = DateTime.Now.ToString() + " => " + ex.Message + "\n" + richTextBox1.Text; }
        }

        private void clearDebug_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void clearOutput_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            pixelColorStringValue = "";
        }

        private void openExportFolder_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(programDirectory + @"\export\"))
                {
                    Directory.CreateDirectory(programDirectory + @"\export\");
                }
                System.Diagnostics.Process.Start("explorer.exe", programDirectory + @"\export\");
            }
            catch (Exception ex) { richTextBox1.Text = DateTime.Now.ToString() + " => " + ex.Message + "\n" + richTextBox1.Text; }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            textBox1.Width = this.Width - 169;
            textBox1.Height = this.Height - 254;
            comboBox1.Width = this.Width - 169;
            Point sus = new Point(this.Width - 115, this.Height - 174);
            clearOutput.Location = sus;
            sus.Y = this.Height - 106;
            clearDebug.Location = sus;
            richTextBox1.Width = this.Width - 269;
            sus.Y = this.Height - 180;
            sus.X = richTextBox1.Location.X;
            richTextBox1.Location = sus;
            sus.Y = this.Height - 196;
            label2.Location = sus;
            sus.Y = this.Height - 274;
            sus.X = flowLayoutPanel1.Location.X;
            flowLayoutPanel1.Location = sus;

        }

        private void processToFIle_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(programDirectory + @"\export\"))
            {
                Directory.CreateDirectory(programDirectory + @"\export\");
            }
             
            try
            {
                TextWriter writer = new StreamWriter(programDirectory + @"\export\" + DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".txt", true);

                pixelColorStringValue = "";
                int SUSY = comboBox1.SelectedIndex;
                //comboBox1.GetItemText(comboBox1.SelectedIndex)
                Bitmap myBitmap = new Bitmap(Convert.ToString(comboBox1.Text), true);
                writer.Write(myBitmap.Height + "x" + myBitmap.Width);

                for (int x = 0; x < myBitmap.Width; x++)
                {
                    for (int y = 0; y < myBitmap.Height; y++)
                    {
                        // Get the color of a pixel within myBitmap.
                        Color pixelColor = myBitmap.GetPixel(x, y);
                        pixelColorStringValue =
                           Start.Text +
                           pixelColor.R.ToString("D3") + Separator.Text +
                           pixelColor.G.ToString("D3") + Separator.Text +
                           pixelColor.B.ToString("D3") + End.Text;
                        writer.Write(pixelColorStringValue);

                        if (y < myBitmap.Height - 1) writer.Write(EOL.Text);
                    }
                    textBox1.Text = ((x-1.0)/myBitmap.Width*100.0).ToString()+"%";
                    if (x < myBitmap.Width - 1) writer.Write(EOL.Text);
                }
                textBox1.Text = "100%";
                richTextBox1.Text = DateTime.Now.ToString() + " => " + "Sucess!" + "\n\n" + richTextBox1.Text;
                richTextBox1.Text = DateTime.Now.ToString() + " => " + "Exported! (" + programDirectory + @"\export\" + DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".txt" + ")\n\n" + richTextBox1.Text;
                writer.Close();
                myBitmap.Dispose();
            }
            catch (Exception ex) { richTextBox1.Text = DateTime.Now.ToString() + " => " + ex.Message + "\n" + richTextBox1.Text; }
        }

        private void ProcessToBoolArray_Click(object sender, EventArgs e)
        {
            try
            {

                int SUSY = comboBox1.SelectedIndex;
                //comboBox1.GetItemText(comboBox1.SelectedIndex)
                Bitmap myBitmap = new Bitmap(Convert.ToString(comboBox1.Text), true);
                pixelColorStringValue = "{";
                for (int x = 0; x < myBitmap.Width; x++)
                {
                    pixelColorStringValue += "{";
                    for (int y = 0; y < myBitmap.Height; y++)
                    {
                        // Get the color of a pixel within myBitmap.
                        Color pixelColor = myBitmap.GetPixel(x, y);
                        pixelColorStringValue += (pixelColor.R>0|| pixelColor.G>0 || pixelColor.B>0 ? "0" : "1");

                        pixelColorStringValue += (y +1< myBitmap.Height ? "," : "");
                    }
                    pixelColorStringValue += "}";
                    pixelColorStringValue += (x+1 < myBitmap.Width ? "," : "");
                    textBox1.Text = pixelColorStringValue;

                }
                pixelColorStringValue += "}";
                richTextBox1.Text = DateTime.Now.ToString() + " => " + "Sucess!" + "\n\n" + richTextBox1.Text;
                textBox1.Text = pixelColorStringValue;
                myBitmap.Dispose();

            }
            catch (Exception ex) { richTextBox1.Text = DateTime.Now.ToString() + " => " + ex.Message + "\n" + richTextBox1.Text; }
        }
    }
}
