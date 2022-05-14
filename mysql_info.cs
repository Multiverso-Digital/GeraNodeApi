using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeraNodeApi
{
    public partial class mysql_info : Form
    {

        string path;
       // MySqlConnection mConn;
       // MySqlDataAdapter mAdapter;
       // DataSet mDataSet;

        public mysql_info()
        {

        }



        public mysql_info(string txtpath)
        {
            InitializeComponent();

            path = txtpath;
        }


        public static string ExecutarCMD(string comando)
        {
            using (Process processo = new Process())
            {
                processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");

                // Formata a string para passar como argumento para o cmd.exe
                processo.StartInfo.Arguments = string.Format("/c {0}", comando);

                processo.StartInfo.RedirectStandardOutput = true;
                processo.StartInfo.UseShellExecute = false;
                processo.StartInfo.CreateNoWindow = true;

                processo.Start();
                processo.WaitForExit();

                string saida = processo.StandardOutput.ReadToEnd();
                return saida;
            }
        }

        public bool TestaMysql(string host, string database, string user, string password, int port)
        {

            bool conectou = false;

            MySqlConnection conn = MySQLConector.GetDBConnection(host, port, database, user, password);


            //mConn = new MySqlConnection(" Persist Security Info=False;server="+host+";database="+database+";uid="+user+";pwd="+password+";port="+port+"");

            try
            {
                //abre a conexao

                conn.Open();

            }

            catch (System.Exception e)

            {

                MessageBox.Show(e.Message.ToString());
                conectou = false;
            }



            //verificva se a conexão esta aberta

            if (conn.State == ConnectionState.Open)

            {
                conectou = true;
                conn.Close();
            }

            return conectou;
         }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            tables_info ftinfo = new tables_info(path);
            ftinfo.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (txhost.Text.Length == 0)
            {

                MessageBox.Show("Host missing");
                return;
            }

            if (txusuario.Text.Length == 0)
            {

                MessageBox.Show("User missing");
                return;
            }



            if (txsenha.Text.Length == 0)
            {

                MessageBox.Show("Password missing");
                return;
            }

            if (txporta.Text.Length == 0)
            {

                MessageBox.Show("Port missing");
                return;
            }

            if (txdb.Text.Length == 0)
            {

                MessageBox.Show("Database missing");
                return;
            }



            MySQLParametros prj = new MySQLParametros();
            prj.Host = txhost.Text;
            prj.User = txusuario.Text;
            prj.Password = txsenha.Text;
            prj.Port = txporta.Text;
            prj.Database = txdb.Text;



            // later
            //string actual = keys.DecryptString(encr);


            Criptografia criptografia = new Criptografia(CryptProvider.RC2);  // escolhe o tipo de criptografia, neste caso escolhemos o RC2
            criptografia.Key = "AbreuRetto"; // chave
            prj.Password = criptografia.Encrypt(prj.Password);





            using (StreamReader r = new StreamReader(path + "\\project.json"))
            {
                string json = r.ReadToEnd();
                Projeto items = JsonConvert.DeserializeObject<Projeto>(json);
                string teste = Newtonsoft.Json.JsonConvert.SerializeObject(prj);

                File.WriteAllText(items.FolderPath + "\\mysqlconn.json", teste);
            }
            Directory.SetCurrentDirectory(path);
            string saida4 = ExecutarCMD("md db");

            string monta = memo_db.Text.Replace("@HOST", txhost.Text);
            string montax = monta.Replace("@USER", txusuario.Text);
            monta = montax.Replace("@PASSWORD", txsenha.Text);
            montax = monta.Replace("@DATABASE", txdb.Text);
            monta = montax.Replace("@PORT", txporta.Text);
            Directory.SetCurrentDirectory(path);
            File.WriteAllText(path + "\\db\\database.js", monta);

            Directory.SetCurrentDirectory(path);
            File.WriteAllText(path + "\\server.js", memo_server.Text);





            if (!TestaMysql(prj.Host, prj.Database, prj.User, txsenha.Text, Int32.Parse(prj.Port) ))
            {

                MessageBox.Show("Connection failed.");
                return;

            }  else

            {
                MessageBox.Show("Connection Successfully! Next to continue.");
            }

           


           



            bNext.Visible = true;
        }

        private void Mysql_info_Load(object sender, EventArgs e)
        {

        }
    }
}
