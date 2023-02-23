namespace bmpToByteArray
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Process = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.export = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Browse = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.clearDebug = new System.Windows.Forms.Button();
            this.clearOutput = new System.Windows.Forms.Button();
            this.openExportFolder = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.processToFIle = new System.Windows.Forms.Button();
            this.ProcessToBoolArray = new System.Windows.Forms.Button();
            this.EOL = new System.Windows.Forms.TextBox();
            this.Start = new System.Windows.Forms.TextBox();
            this.Separator = new System.Windows.Forms.TextBox();
            this.End = new System.Windows.Forms.TextBox();
            this.EOLlabel = new System.Windows.Forms.Label();
            this.SeparatorLabel = new System.Windows.Forms.Label();
            this.StartLabel = new System.Windows.Forms.Label();
            this.EndLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(149, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(1000, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            // 
            // Process
            // 
            this.Process.Location = new System.Drawing.Point(3, 119);
            this.Process.Name = "Process";
            this.Process.Size = new System.Drawing.Size(58, 52);
            this.Process.TabIndex = 2;
            this.Process.Text = "Process";
            this.Process.UseVisualStyleBackColor = true;
            this.Process.Click += new System.EventHandler(this.Process_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(149, 55);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1000, 292);
            this.textBox1.TabIndex = 3;
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(3, 3);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(128, 52);
            this.export.TabIndex = 5;
            this.export.Text = "Export";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Processed to rgb";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Debug output";
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(9, 12);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(137, 21);
            this.Browse.TabIndex = 8;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.browse_click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(149, 366);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(900, 131);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // clearDebug
            // 
            this.clearDebug.Location = new System.Drawing.Point(1054, 440);
            this.clearDebug.Name = "clearDebug";
            this.clearDebug.Size = new System.Drawing.Size(90, 52);
            this.clearDebug.TabIndex = 10;
            this.clearDebug.Text = "Clear Debug";
            this.clearDebug.UseVisualStyleBackColor = true;
            this.clearDebug.Click += new System.EventHandler(this.clearDebug_Click);
            // 
            // clearOutput
            // 
            this.clearOutput.Location = new System.Drawing.Point(1054, 372);
            this.clearOutput.Name = "clearOutput";
            this.clearOutput.Size = new System.Drawing.Size(90, 52);
            this.clearOutput.TabIndex = 11;
            this.clearOutput.Text = "Clear Output";
            this.clearOutput.UseVisualStyleBackColor = true;
            this.clearOutput.Click += new System.EventHandler(this.clearOutput_Click);
            // 
            // openExportFolder
            // 
            this.openExportFolder.Location = new System.Drawing.Point(3, 61);
            this.openExportFolder.Name = "openExportFolder";
            this.openExportFolder.Size = new System.Drawing.Size(128, 52);
            this.openExportFolder.TabIndex = 12;
            this.openExportFolder.Text = "Open Export Folder";
            this.openExportFolder.UseVisualStyleBackColor = true;
            this.openExportFolder.Click += new System.EventHandler(this.openExportFolder_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.export);
            this.flowLayoutPanel1.Controls.Add(this.openExportFolder);
            this.flowLayoutPanel1.Controls.Add(this.Process);
            this.flowLayoutPanel1.Controls.Add(this.processToFIle);
            this.flowLayoutPanel1.Controls.Add(this.ProcessToBoolArray);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 274);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(137, 223);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // processToFIle
            // 
            this.processToFIle.Location = new System.Drawing.Point(67, 119);
            this.processToFIle.Name = "processToFIle";
            this.processToFIle.Size = new System.Drawing.Size(64, 52);
            this.processToFIle.TabIndex = 13;
            this.processToFIle.Text = "Process Directly to file";
            this.processToFIle.UseVisualStyleBackColor = true;
            this.processToFIle.Click += new System.EventHandler(this.processToFIle_Click);
            // 
            // ProcessToBoolArray
            // 
            this.ProcessToBoolArray.Location = new System.Drawing.Point(3, 177);
            this.ProcessToBoolArray.Name = "ProcessToBoolArray";
            this.ProcessToBoolArray.Size = new System.Drawing.Size(128, 41);
            this.ProcessToBoolArray.TabIndex = 14;
            this.ProcessToBoolArray.Text = "ProcessToBoolArray";
            this.ProcessToBoolArray.UseVisualStyleBackColor = true;
            this.ProcessToBoolArray.Click += new System.EventHandler(this.ProcessToBoolArray_Click);
            // 
            // EOL
            // 
            this.EOL.Location = new System.Drawing.Point(61, 39);
            this.EOL.Name = "EOL";
            this.EOL.Size = new System.Drawing.Size(85, 20);
            this.EOL.TabIndex = 14;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(61, 91);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(85, 20);
            this.Start.TabIndex = 15;
            this.Start.Text = ",";
            // 
            // Separator
            // 
            this.Separator.Location = new System.Drawing.Point(61, 65);
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(85, 20);
            this.Separator.TabIndex = 16;
            this.Separator.Text = ",";
            // 
            // End
            // 
            this.End.Location = new System.Drawing.Point(61, 117);
            this.End.Name = "End";
            this.End.Size = new System.Drawing.Size(85, 20);
            this.End.TabIndex = 17;
            // 
            // EOLlabel
            // 
            this.EOLlabel.AutoSize = true;
            this.EOLlabel.Location = new System.Drawing.Point(6, 42);
            this.EOLlabel.Name = "EOLlabel";
            this.EOLlabel.Size = new System.Drawing.Size(28, 13);
            this.EOLlabel.TabIndex = 18;
            this.EOLlabel.Text = "EOL";
            // 
            // SeparatorLabel
            // 
            this.SeparatorLabel.AutoSize = true;
            this.SeparatorLabel.Location = new System.Drawing.Point(6, 68);
            this.SeparatorLabel.Name = "SeparatorLabel";
            this.SeparatorLabel.Size = new System.Drawing.Size(53, 13);
            this.SeparatorLabel.TabIndex = 19;
            this.SeparatorLabel.Text = "Separator";
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Location = new System.Drawing.Point(6, 94);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(29, 13);
            this.StartLabel.TabIndex = 20;
            this.StartLabel.Text = "Start";
            // 
            // EndLabel
            // 
            this.EndLabel.AutoSize = true;
            this.EndLabel.Location = new System.Drawing.Point(6, 120);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(26, 13);
            this.EndLabel.TabIndex = 21;
            this.EndLabel.Text = "End";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 143);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(134, 23);
            this.progressBar1.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 507);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.EndLabel);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.SeparatorLabel);
            this.Controls.Add(this.EOLlabel);
            this.Controls.Add(this.End);
            this.Controls.Add(this.Separator);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.EOL);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.clearOutput);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.clearDebug);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "Form1";
            this.Text = "Photo to rgb converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Process;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button clearDebug;
        private System.Windows.Forms.Button clearOutput;
        private System.Windows.Forms.Button openExportFolder;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox EOL;
        private System.Windows.Forms.TextBox Start;
        private System.Windows.Forms.TextBox Separator;
        private System.Windows.Forms.TextBox End;
        private System.Windows.Forms.Label EOLlabel;
        private System.Windows.Forms.Label SeparatorLabel;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.Button processToFIle;
        private System.Windows.Forms.Button ProcessToBoolArray;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

