namespace GeraNodeApi
{
    partial class table_fields
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(table_fields));
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bNext = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TVArqs = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imglst1 = new System.Windows.Forms.ImageList(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.LBSelecionadas = new System.Windows.Forms.ListBox();
            this.memo_node = new System.Windows.Forms.TextBox();
            this.memo_mostra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PB = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.memo_classes = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(643, 451);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 23);
            this.button4.TabIndex = 53;
            this.button4.Text = "Back";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(15, 451);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 52;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // bNext
            // 
            this.bNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bNext.ForeColor = System.Drawing.Color.White;
            this.bNext.Location = new System.Drawing.Point(750, 451);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(88, 23);
            this.bNext.TabIndex = 51;
            this.bNext.Text = "Next";
            this.bNext.UseVisualStyleBackColor = true;
            this.bNext.Visible = false;
            this.bNext.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(297, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(278, 20);
            this.label4.TabIndex = 61;
            this.label4.Text = "MySQL - NODE CRUD API Generator";
            // 
            // TVArqs
            // 
            this.TVArqs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.TVArqs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TVArqs.ContextMenuStrip = this.contextMenuStrip1;
            this.TVArqs.ForeColor = System.Drawing.SystemColors.Window;
            this.TVArqs.Location = new System.Drawing.Point(301, 62);
            this.TVArqs.Name = "TVArqs";
            this.TVArqs.Size = new System.Drawing.Size(537, 342);
            this.TVArqs.StateImageList = this.imglst1;
            this.TVArqs.TabIndex = 62;
            this.TVArqs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TVArqs_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 26);
            this.contextMenuStrip1.Text = "Menu";
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1_Opening);
            this.contextMenuStrip1.Click += new System.EventHandler(this.ContextMenuStrip1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.toolStripMenuItem1.Text = "Mostrar";
            // 
            // imglst1
            // 
            this.imglst1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglst1.ImageStream")));
            this.imglst1.TransparentColor = System.Drawing.Color.White;
            this.imglst1.Images.SetKeyName(0, "ico_folder.png");
            this.imglst1.Images.SetKeyName(1, "ico_file.png");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(13, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Selected tables";
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(16, 407);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(269, 23);
            this.button3.TabIndex = 64;
            this.button3.Text = "NODE CRUD API Generate";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click_1);
            // 
            // LBSelecionadas
            // 
            this.LBSelecionadas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.LBSelecionadas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBSelecionadas.ForeColor = System.Drawing.Color.White;
            this.LBSelecionadas.FormattingEnabled = true;
            this.LBSelecionadas.Location = new System.Drawing.Point(16, 61);
            this.LBSelecionadas.Name = "LBSelecionadas";
            this.LBSelecionadas.Size = new System.Drawing.Size(269, 340);
            this.LBSelecionadas.TabIndex = 65;
            // 
            // memo_node
            // 
            this.memo_node.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.memo_node.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.memo_node.Location = new System.Drawing.Point(301, 65);
            this.memo_node.Multiline = true;
            this.memo_node.Name = "memo_node";
            this.memo_node.Size = new System.Drawing.Size(322, 340);
            this.memo_node.TabIndex = 66;
            // 
            // memo_mostra
            // 
            this.memo_mostra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.memo_mostra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.memo_mostra.ForeColor = System.Drawing.Color.White;
            this.memo_mostra.Location = new System.Drawing.Point(301, 65);
            this.memo_mostra.Multiline = true;
            this.memo_mostra.Name = "memo_mostra";
            this.memo_mostra.Size = new System.Drawing.Size(322, 340);
            this.memo_mostra.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(298, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "Generated CRUD API Folder";
            // 
            // PB
            // 
            this.PB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(129)))), ((int)(((byte)(13)))));
            this.PB.Location = new System.Drawing.Point(300, 407);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(538, 23);
            this.PB.TabIndex = 71;
            this.PB.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(298, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 72;
            this.label3.Visible = false;
            // 
            // memo_classes
            // 
            this.memo_classes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.memo_classes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.memo_classes.ForeColor = System.Drawing.Color.White;
            this.memo_classes.Location = new System.Drawing.Point(301, 65);
            this.memo_classes.Multiline = true;
            this.memo_classes.Name = "memo_classes";
            this.memo_classes.Size = new System.Drawing.Size(322, 340);
            this.memo_classes.TabIndex = 70;
            this.memo_classes.Visible = false;
            // 
            // table_fields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BackgroundImage = global::GeraNodeApi.Properties.Resources.logo_transparente_100;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(869, 482);
            this.Controls.Add(this.TVArqs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.memo_mostra);
            this.Controls.Add(this.memo_node);
            this.Controls.Add(this.LBSelecionadas);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bNext);
            this.Controls.Add(this.memo_classes);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "table_fields";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NODE CRUD API Generator";
            this.Shown += new System.EventHandler(this.Table_fields_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView TVArqs;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox LBSelecionadas;
        private System.Windows.Forms.TextBox memo_node;
        private System.Windows.Forms.TextBox memo_mostra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar PB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox memo_classes;
        private System.Windows.Forms.ImageList imglst1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}