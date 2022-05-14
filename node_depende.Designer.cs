namespace GeraNodeApi
{
    partial class node_depende
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
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(node_depende));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TVArqs = new System.Windows.Forms.TreeView();
            this.imglst1 = new System.Windows.Forms.ImageList(this.components);
            this.bNext = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(26, 571);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(322, 13);
            label2.TabIndex = 65;
            label2.Text = "copyright 2019 - Developed by abreu@abreuretto.com  version 1.7";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(563, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Congratulations!";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(26, 62);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(508, 502);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // TVArqs
            // 
            this.TVArqs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.TVArqs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TVArqs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TVArqs.ForeColor = System.Drawing.SystemColors.Window;
            this.TVArqs.ImageIndex = 0;
            this.TVArqs.ImageList = this.imglst1;
            this.TVArqs.Location = new System.Drawing.Point(558, 62);
            this.TVArqs.Name = "TVArqs";
            this.TVArqs.SelectedImageIndex = 0;
            this.TVArqs.Size = new System.Drawing.Size(596, 502);
            this.TVArqs.TabIndex = 63;
            this.TVArqs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TVArqs_AfterSelect);
            // 
            // imglst1
            // 
            this.imglst1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglst1.ImageStream")));
            this.imglst1.TransparentColor = System.Drawing.Color.White;
            this.imglst1.Images.SetKeyName(0, "ico_folder.png");
            this.imglst1.Images.SetKeyName(1, "ico_file.png");
            // 
            // bNext
            // 
            this.bNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bNext.ForeColor = System.Drawing.Color.White;
            this.bNext.Location = new System.Drawing.Point(1066, 586);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(88, 23);
            this.bNext.TabIndex = 64;
            this.bNext.Text = "Close";
            this.bNext.UseVisualStyleBackColor = true;
            this.bNext.Click += new System.EventHandler(this.BNext_Click);
            // 
            // node_depende
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.BackgroundImage = global::GeraNodeApi.Properties.Resources.logo_transparente_100;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1199, 621);
            this.Controls.Add(label2);
            this.Controls.Add(this.bNext);
            this.Controls.Add(this.TVArqs);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "node_depende";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "End process";
            this.Shown += new System.EventHandler(this.Node_depende_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TreeView TVArqs;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.ImageList imglst1;
    }
}