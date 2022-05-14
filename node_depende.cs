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

namespace GeraNodeApi
{
    public partial class node_depende : Form
    {

        string path = null;

        public node_depende(string pathx)
        {
            InitializeComponent();
            path = pathx;
            CarregaDadosPasta(path);
        }

       
        private void CarregaDadosPasta(string diretorio)
        {
            DirectoryInfo diretorioInfo = new DirectoryInfo(diretorio);
            //Define o valor máximo do ProgressBar
            TreeNode tds = TVArqs.Nodes.Add(diretorioInfo.Name);
            tds.Tag = diretorioInfo.FullName;

            tds.StateImageIndex = 0;
            //carrega os arquivos e as subpastas
            CarregaArquivos(diretorio, tds);
            CarregaSubDiretorios(diretorio, tds);
        }

        private void CarregaArquivos(string diretorio, TreeNode tnd)
        {
            string[] arquivos = Directory.GetFiles(diretorio, "*.*");

            // Percorre os arquivos
            foreach (string arq in arquivos)
            {
                FileInfo arquivo = new FileInfo(arq);
                TreeNode tds = tnd.Nodes.Add(arquivo.Name);
                tds.Tag = arquivo.FullName;
                tds.StateImageIndex = 1;

            }
        }

        private void CarregaSubDiretorios(string dir, TreeNode td)
        {
            // Pega todos os subdiretorios
            string[] subdiretorioEntradas = Directory.GetDirectories(dir);
            // Percorre os subdiretorios a ver se existem outras subpasts
            foreach (string subdiretorio in subdiretorioEntradas)
            {
                DirectoryInfo diretorio = new DirectoryInfo(subdiretorio);
                TreeNode tds = td.Nodes.Add(diretorio.Name);
                tds.StateImageIndex = 0;
                tds.Tag = diretorio.FullName;
                CarregaArquivos(subdiretorio, tds);
                CarregaSubDiretorios(subdiretorio, tds);

            }
        }


        private void Node_depende_Shown(object sender, EventArgs e)
        {
            // Application.EnableVisualStyles();

            bNext.Focus();
           
        }

        private void BNext_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TVArqs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string pathx = path + "\\" + e.Node.Text;

            string decima = e.Node.FullPath;

            FileInfo f = new FileInfo(path);
            string drive = Path.GetPathRoot(f.FullName);
            string full = drive + decima;



            Directory.SetCurrentDirectory(path);
            Process fileopener = new Process();
            fileopener.StartInfo.CreateNoWindow = false;
            fileopener.StartInfo.FileName = "code";
            fileopener.StartInfo.Arguments = full;
            fileopener.Start();
        }
    }
}
