using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeraNodeApi
{
    public partial class tables_info : Form
    {
        string path;
        MySQLParametros items;
        MySqlConnection conn;
        List<Tables> Tablenames = new List<Tables>();

        public tables_info(string txtpath)
        {
            InitializeComponent();
            path = txtpath;
        }

        public void MarcaLBOrigem(CheckBox cb)
        {
            for (int a = 0; a < LBOrigem.Items.Count; a++)
                LBOrigem.SetItemChecked(a, cb.Checked);

        }

        public void MarcaLBDestino(CheckBox cb)
        {
            for (int a = 0; a < LBDestino.Items.Count; a++)
                LBDestino.SetItemChecked(a, cb.Checked);

        }





        public void PegaMysqlParametros()
        {

            using (StreamReader r = new StreamReader(path + "\\mysqlconn.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<MySQLParametros>(json);            


            }

            Criptografia criptografia = new Criptografia(CryptProvider.RC2);
            criptografia.Key = "AbreuRetto";
            string passw = criptografia.Decrypt(items.Password);


            conn = MySQLConector.GetDBConnection(items.Host, Int32.Parse(items.Port), items.Database, items.User, passw);

            try
            {
              
                conn.Open();

            }

            catch (System.Exception e)

            {

                MessageBox.Show(e.Message.ToString());
                
            }



            //verificva se a conexão esta aberta

            if (conn.State == ConnectionState.Open)

            {

                string query = "show tables from " + items.Database + "";
                MySqlCommand command = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Tablenames.Add(reader.GetString(0));
                        LBOrigem.Items.Add(reader.GetString(0));
                        

                    }

                    for (int a = 0; a < LBOrigem.Items.Count; a++)
                        LBOrigem.SetItemChecked(a, true);
                }

            }

        }


        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < LBDestino.CheckedItems.Count; a++)
            {
                Tables tb = new Tables();
                tb.name = LBDestino.Items[a].ToString();
                Tablenames.Add(tb);
            }

             using (StreamReader r = new StreamReader(path + "\\project.json"))
            {
                string json = r.ReadToEnd();
                Projeto items = JsonConvert.DeserializeObject<Projeto>(json);
                string teste = Newtonsoft.Json.JsonConvert.SerializeObject(Tablenames);

                File.WriteAllText(items.FolderPath + "\\tables.json", teste);
            }
            



            table_fields Ftf = new table_fields(path);
            Ftf.ShowDialog();
        }

        private void Tables_info_Shown(object sender, EventArgs e)
        {
            PegaMysqlParametros();
        }

        private void CBOrigem_Click(object sender, EventArgs e)
        {
            MarcaLBOrigem(CBOrigem);
        }

        private void CBDestino_Click(object sender, EventArgs e)
        {
            MarcaLBDestino(CBDestino);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < LBOrigem.CheckedItems.Count; a++)
            {
                
                    LBDestino.Items.Add(LBOrigem.Items[a]);
                    LBDestino.SetItemChecked(a, true); 
                    //LBOrigem.Items.RemoveAt(a);
                
            }

            while (LBOrigem.CheckedItems.Count > 0)
            {
                LBOrigem.Items.RemoveAt(LBOrigem.CheckedIndices[0]);
            }

            CBDestino.Checked = false;

            if (LBDestino.Items.Count > 0)
            {
                bNext.Visible = true;
            }
            else
            {
                bNext.Visible = false;
            }

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < LBDestino.CheckedItems.Count; a++)
            {
               
                    LBOrigem.Items.Add(LBDestino.Items[a]);
                    LBOrigem.SetItemChecked(a, false);
                   // LBDestino.Items.RemoveAt(a);

                

            }

            CBOrigem.Checked = false;

            while (LBDestino.CheckedItems.Count > 0)
            {
                LBDestino.Items.RemoveAt(LBDestino.CheckedIndices[0]);
            }

            if (LBDestino.Items.Count > 0)
            {
                bNext.Visible = true;
            }
            else
            {
                bNext.Visible = false;
            }
        }
    }
}
