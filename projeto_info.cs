using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Computador\HKEY_CLASSES_ROOT\Applications\Code.exe\shell\open\command


namespace GeraNodeApi
{
    public partial class projeto_info : Form
    {

        string comando;
        public projeto_info()
        {
            InitializeComponent();
        }

        public bool verificaregistro()
        {
            bool achou = false;
            //opening the subkey  
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"Applications\Code.exe\shell\open\command\");

            //if it does exist, retrieve the stored values  
            if (key != null)
            {
                achou = true;
                key.Close();
            }

            return achou;
        }



        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {


           
            mysql_info fmysql = new mysql_info(txpath.Text);
            fmysql.ShowDialog();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {



            if (!verificaregistro()){
                MessageBox.Show("Visual Studio Code Editor not found. Please install it!");
                MessageBox.Show("link: https://code.visualstudio.com/download");              

            };



            if (txpath.Text.Length == 0)
            {

                MessageBox.Show("Folder path missing");
                return;
            }

            if (txnome.Text.Length == 0)
            {

                MessageBox.Show("Project name missing");
                return;
            }



            if (txversao.Text.Length == 0)
            {

                MessageBox.Show("Version missing");
                return;
            }

            if (txautor.Text.Length == 0)
            {

                MessageBox.Show("Author missing");
                return;
            }



            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(txpath.Text))
                {
                    DirectoryInfo di = Directory.CreateDirectory(txpath.Text);
                    //Console.WriteLine("That path exists already.");

                }

                // Try to create the directory.
                
                //Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(txpath.Text));

                // Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally { }






            Projeto prj = new Projeto();
            prj.Author = txautor.Text;
            prj.Name = txnome.Text;
            prj.FolderPath = txpath.Text;
            prj.Version = txversao.Text;
            string teste = Newtonsoft.Json.JsonConvert.SerializeObject(prj);

            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = 0;

            Directory.SetCurrentDirectory(txpath.Text);
      
            
            /*
            memo_node.Clear();
            memo_node.AppendText("npm init -y "+Environment.NewLine);
            File.WriteAllText(txpath.Text + "\\inicia_script.bat", memo_node.Text);

            memo_node.Clear();
            memo_node.AppendText("npm i --save node express cookie-parser morgan debug http-errors cors http " + Environment.NewLine);
            File.WriteAllText(txpath.Text + "\\node_script.bat", memo_node.Text);           

            memo_node.Clear();
            memo_node.AppendText("npm install express -generator -g " + Environment.NewLine);
            File.WriteAllText(txpath.Text + "\\express_script.bat", memo_node.Text);

            memo_node.Clear();
            memo_node.AppendText("express - f ");
            File.WriteAllText(txpath.Text + "\\express2_script.bat", memo_node.Text);

            memo_node.Clear();
            memo_node.AppendText("npm install -S mysql2 " + Environment.NewLine);
            File.WriteAllText(txpath.Text + "\\mysql_script.bat", memo_node.Text);

            memo_node.Clear();
            memo_node.AppendText("npm install " + Environment.NewLine);

            File.WriteAllText(txpath.Text + "\\npminstall_script.bat", memo_node.Text);

            memo_node.Clear();
            memo_node.AppendText("inicia_script.bat" + Environment.NewLine);
            memo_node.AppendText("node_script.bat" + Environment.NewLine);
            memo_node.AppendText("express_script.bat" + Environment.NewLine);
            memo_node.AppendText("express2_script.bat" + Environment.NewLine);
            memo_node.AppendText("mysql_script.bat" + Environment.NewLine);
            memo_node.AppendText("npminstall_script.bat" + Environment.NewLine);
            File.WriteAllText(txpath.Text + "\\tudo_script.bat", memo_node.Text);


           

    */
            File.WriteAllText(prj.FolderPath + "\\project.json", teste);


            progressBar1.Visible = true;
            

            string monta = memo_node.Text.Replace("@prj", txnome.Text);
            string montax = monta.Replace("@author", txautor.Text);
            monta = montax.Replace("@author", txautor.Text);
            montax = monta.Replace("@version", txversao.Text);

            File.WriteAllText(prj.FolderPath + "\\package.json", montax);

            comando = "npm install";

            backgroundWorker1.RunWorkerAsync();


           


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txpath.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (Process processo = new Process())
            {
                processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");
                this.backgroundWorker1.ReportProgress(1);


                processo.StartInfo.Arguments = string.Format("/c {0}", comando);
                this.backgroundWorker1.ReportProgress(2);


                processo.StartInfo.UseShellExecute = false;
                this.backgroundWorker1.ReportProgress(3);
                processo.StartInfo.CreateNoWindow = true;
                this.backgroundWorker1.ReportProgress(4);
                processo.StartInfo.RedirectStandardError = true;
                this.backgroundWorker1.ReportProgress(5);
                processo.StartInfo.RedirectStandardOutput = true;
                this.backgroundWorker1.ReportProgress(6);
                var stdOutput = new StringBuilder();
                this.backgroundWorker1.ReportProgress(7);
                processo.OutputDataReceived += (sender2, args) => stdOutput.AppendLine(args.Data); // Use AppendLine rather than Append since args.Data is one line of output, not including the newline character.
                this.backgroundWorker1.ReportProgress(8);

                string stdError = null;
                try
                {
                    processo.Start();
                    this.backgroundWorker1.ReportProgress(9);
                    processo.BeginOutputReadLine();
                    this.backgroundWorker1.ReportProgress(10);
                    stdError = processo.StandardError.ReadToEnd();
                    this.backgroundWorker1.ReportProgress(11);
                    processo.WaitForExit();
                    this.backgroundWorker1.ReportProgress(12);
                }
                catch (Exception ex)
                {
                    throw new Exception("OS error while executing : " + ex.Message, ex);
                }

                if (processo.ExitCode == 0)
                {
                    //return stdOutput.ToString();
                }
                else
                {
                    var message = new StringBuilder();

                    if (!string.IsNullOrEmpty(stdError))
                    {
                        message.AppendLine(stdError);
                    }

                    if (stdOutput.Length != 0)
                    {
                        message.AppendLine("Std output:");
                        message.AppendLine(stdOutput.ToString());
                    }

                    throw new Exception(" finished with exit code = " + processo.ExitCode + ": " + message);
                }
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label4.Text = comando;
            label4.Refresh();
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Data saved sucessufull! Next do continue...");
            bNext.Visible = true;
            progressBar1.Value = 0;
            label4.Text = "NODE dependencies installed sucessifuly. Click Next button";
            label4.Refresh();

            progressBar1.Visible = false;

        }

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Memo_node_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
