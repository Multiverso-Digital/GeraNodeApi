namespace GeraNodeApi
{
    partial class tables_info
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
            this.LBOrigem = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LBDestino = new System.Windows.Forms.CheckedListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bNext = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.CBOrigem = new System.Windows.Forms.CheckBox();
            this.CBDestino = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LBOrigem
            // 
            this.LBOrigem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.LBOrigem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBOrigem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LBOrigem.ForeColor = System.Drawing.Color.White;
            this.LBOrigem.FormattingEnabled = true;
            this.LBOrigem.Location = new System.Drawing.Point(8, 41);
            this.LBOrigem.Name = "LBOrigem";
            this.LBOrigem.Size = new System.Drawing.Size(224, 362);
            this.LBOrigem.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tables";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(350, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Selected tables";
            // 
            // LBDestino
            // 
            this.LBDestino.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.LBDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBDestino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LBDestino.ForeColor = System.Drawing.Color.White;
            this.LBDestino.FormattingEnabled = true;
            this.LBDestino.Location = new System.Drawing.Point(353, 41);
            this.LBDestino.Name = "LBDestino";
            this.LBDestino.Size = new System.Drawing.Size(227, 362);
            this.LBDestino.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(399, 415);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 23);
            this.button4.TabIndex = 48;
            this.button4.Text = "Back";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(8, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 47;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // bNext
            // 
            this.bNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bNext.ForeColor = System.Drawing.Color.White;
            this.bNext.Location = new System.Drawing.Point(493, 415);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(88, 23);
            this.bNext.TabIndex = 46;
            this.bNext.Text = "Next";
            this.bNext.UseVisualStyleBackColor = true;
            this.bNext.Visible = false;
            this.bNext.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(272, 190);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(41, 23);
            this.button3.TabIndex = 49;
            this.button3.Text = ">";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(272, 238);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(41, 23);
            this.button5.TabIndex = 50;
            this.button5.Text = "<";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // CBOrigem
            // 
            this.CBOrigem.AutoSize = true;
            this.CBOrigem.Checked = true;
            this.CBOrigem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBOrigem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBOrigem.ForeColor = System.Drawing.Color.White;
            this.CBOrigem.Location = new System.Drawing.Point(201, 22);
            this.CBOrigem.Name = "CBOrigem";
            this.CBOrigem.Size = new System.Drawing.Size(37, 17);
            this.CBOrigem.TabIndex = 51;
            this.CBOrigem.Text = "All";
            this.CBOrigem.UseVisualStyleBackColor = true;
            this.CBOrigem.Click += new System.EventHandler(this.CBOrigem_Click);
            // 
            // CBDestino
            // 
            this.CBDestino.AutoSize = true;
            this.CBDestino.Checked = true;
            this.CBDestino.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBDestino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBDestino.ForeColor = System.Drawing.Color.White;
            this.CBDestino.Location = new System.Drawing.Point(545, 20);
            this.CBDestino.Name = "CBDestino";
            this.CBDestino.Size = new System.Drawing.Size(37, 17);
            this.CBDestino.TabIndex = 52;
            this.CBDestino.Text = "All";
            this.CBDestino.UseVisualStyleBackColor = true;
            this.CBDestino.Click += new System.EventHandler(this.CBDestino_Click);
            // 
            // tables_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(592, 450);
            this.Controls.Add(this.CBDestino);
            this.Controls.Add(this.CBOrigem);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bNext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LBDestino);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBOrigem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "tables_info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tables found";
            this.Shown += new System.EventHandler(this.Tables_info_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox LBOrigem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox LBDestino;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox CBOrigem;
        private System.Windows.Forms.CheckBox CBDestino;
    }
}