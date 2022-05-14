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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeraNodeApi
{
  
    public partial class table_fields : Form
    {

        string path;
        MySQLParametros items;
        MySqlConnection conn;
        Projeto itemsprj;

        List<Tables> tablenames = new List<Tables>();

        List<Tables> tablework = new List<Tables>();

        List<string> classes = new List<string>();

        public table_fields(string txtpath)
        {
            InitializeComponent();

            path = txtpath;

            using (StreamReader r = new StreamReader(path + "\\tables.json"))
            {
                string json = r.ReadToEnd();


                List<Tables> items = JsonConvert.DeserializeObject<List<Tables>>(json);  
                
                foreach (Tables item in items)
                {
                   LBSelecionadas.Items.Add(item.name.ToString());
                }
                
            }

            

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



        public static string ExecutarCMD(string comando)
        {
            using (Process processo = new Process())
            {
                processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");
               

                // Formata a string para passar como argumento para o cmd.exe
                processo.StartInfo.Arguments = string.Format("/c {0}", comando);

                processo.StartInfo.RedirectStandardOutput = true;
                processo.StartInfo.UseShellExecute = false;
                processo.StartInfo.Verb = "runas";
                processo.StartInfo.CreateNoWindow = false;

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


        private void Button1_Click(object sender, EventArgs e)
        {
            node_depende Fnd = new node_depende(path);
            Fnd.ShowDialog();
        }

        public void PegaCampos()
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

                for (int i = 0; i < LBSelecionadas.Items.Count; i++)
                {
                    string tabela = LBSelecionadas.Items[i].ToString();

                    string query = "show COLUMNS from " + tabela + "";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    Tables tb = new Tables();
                    tb.name = tabela;

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        

                        while (reader.Read())
                        {
                            //Tablenames.Add(reader.GetString(0));

                            Campos ca = new Campos();
                            ca.Nome = reader.GetString(0);
                            ca.Tipo = reader.GetString(1);
                            ca.ChavePrimaria = reader.GetString(3);
                            ca.Selecionou = true;
                            tb.camposApi.Add(ca);
                            

                        }
                        tablenames.Add(tb);

                    }
                }

                using (StreamReader r = new StreamReader(path + "\\project.json"))
                {
                    string json = r.ReadToEnd();
                    itemsprj = JsonConvert.DeserializeObject<Projeto>(json);
                    string teste = Newtonsoft.Json.JsonConvert.SerializeObject(tablenames);
                    File.WriteAllText(itemsprj.FolderPath + "\\tables_fields.json", teste);

                }


                ExecutaNode();



            }




        }

        public void ExecutaNode()
        {
            



     





        }



        private void CBTables_Click(object sender, EventArgs e)
        {
           
        }

        private void Button3_Click(object sender, EventArgs e)
        {
           

           
        }

        private void Button5_Click(object sender, EventArgs e)
        {
           
        }

        private void Table_fields_Shown(object sender, EventArgs e)
        {
            PegaCampos();
        }


        public void VerificaDependencia()
        {

            if (Directory.Exists(path+"\\routes"))
            {
                return;
            }


            memo_node.Clear();
            memo_node.AppendText("@echo on" + System.Environment.NewLine);
            memo_node.AppendText("cls" + System.Environment.NewLine);
            memo_node.AppendText("npm init -y" + System.Environment.NewLine);

           // memo_node.AppendText("npm i --save node express cookie-parser morgan debug http-errors cors http" + System.Environment.NewLine);
           // File.WriteAllText(path + "\\node_script.bat", memo_node.Text);
            memo_node.Update();
            memo_mostra.AppendText(memo_node.Text);



            memo_node.Clear();
            memo_node.AppendText("@echo on" + System.Environment.NewLine);
            memo_node.AppendText("cls" + System.Environment.NewLine);
            //memo_node.AppendText("npm i --save node express cookie-parser morgan debug http-errors cors http mysql");
            //memo_node.AppendText("npm install express -generator -g" + System.Environment.NewLine);
            memo_node.AppendText("express -f" + System.Environment.NewLine);       

            //File.WriteAllText(path + "\\express_script.bat", memo_node.Text);
            memo_node.Update();
            memo_mostra.AppendText(memo_node.Text);

            memo_node.Clear();
            memo_node.AppendText("@echo on" + System.Environment.NewLine);
            memo_node.AppendText("cls" + System.Environment.NewLine);
            // memo_node.AppendText("npm install express -generator -g" + System.Environment.NewLine);
            memo_node.AppendText("express -f" + System.Environment.NewLine);

            //File.WriteAllText(path + "\\expressf_script.bat", memo_node.Text);
            memo_node.Update();
            memo_mostra.AppendText(memo_node.Text);





            memo_node.Clear();
            memo_node.AppendText("@echo on" + System.Environment.NewLine);
            memo_node.AppendText("cls" + System.Environment.NewLine);
            memo_node.AppendText("npm install -S mysql2" + System.Environment.NewLine);

            memo_node.AppendText("npm install" + System.Environment.NewLine);

            //File.WriteAllText(path + "\\mysql_script.bat", memo_node.Text);
            memo_node.Update();
            memo_mostra.AppendText(memo_node.Text);
            memo_mostra.Update();





          //  Directory.SetCurrentDirectory(path);
          //  string saida = ExecutarCMD("node_script.bat");



            //Directory.SetCurrentDirectory(path);
            //string saida2 = ExecutarCMD("express_script.bat");

            /*
            Directory.SetCurrentDirectory(path);
            string saida8 = ExecutarCMD("expressf_script.bat");

            Directory.SetCurrentDirectory(path);
            string saida3 = ExecutarCMD("mysql_script.bat");

            */
            Directory.SetCurrentDirectory(path);
            string saida4 = ExecutarCMD("md db & md api & md domain");

            Thread.Sleep(10000);
            Directory.SetCurrentDirectory(path);
            string saida5 = ExecutarCMD("express -f");

            /*
            Directory.SetCurrentDirectory(path);
            string saida5 = ExecutarCMD("md api");

            Directory.SetCurrentDirectory(path);
            string saida6 = ExecutarCMD("md domain");
            */
        }


        public void GerarClasses()
        {

            VerificaDependencia();


            using (StreamReader r = new StreamReader(path + "\\tables_fields.json"))
            {
                string json = r.ReadToEnd();
                tablenames = JsonConvert.DeserializeObject<List<Tables>>(json);                

            }
            MontaClassesTabelas();

            CarregaDadosPasta(path);

            TVArqs.ExpandAll();



        }

        public void MontaClassesTabelas()
        {
            int conta = 0;
            label3.Visible = true;
            foreach (Tables item in tablenames)
            {
                PB.Maximum = tablenames.Count;
                Application.DoEvents();
                conta = conta + 1;
                PB.Value = conta;
                PB.Refresh();
                label3.Text = "Generating CRUD API table  "+item.name;
                label3.Refresh();

                string campos = null;
                string campossemchave = null;
                string campochave = null;
                string campoupdatex = null;
                classes.Add("class " + item.name + " {");

                foreach (Campos campo in item.camposApi)
                {
                    Application.DoEvents();
                    campos = campos + campo.Nome + ",";
                    if (campo.ChavePrimaria != "PRI")
                    {
                        campossemchave = campossemchave + campo.Nome + ",";
                        campoupdatex = campoupdatex + " " + campo.Nome + " = \"${this.x" + campo.Nome + "}\",";
                    }
                    else
                    {
                        campochave = campo.Nome;
                    }
                }

                string monta = campos.Substring(0, campos.Length - 1);
                string montasemchave = campossemchave.Substring(0, campossemchave.Length - 1);
                string campoupdate = campoupdatex.Substring(0, campoupdatex.Length - 1);



                classes.Add("constructor( " + montasemchave + " ){");

                foreach (Campos campo in item.camposApi)
                {
                    Application.DoEvents();
                    if (campo.Nome != campochave)
                    {

                        classes.Add("this.x" + campo.Nome + " =" + campo.Nome + "; ");
                    } else
                    {
                        classes.Add("this.x" + campo.Nome + " = 0; ");
                    }



                }
                classes.Add("}");


                //adiciona 
                classes.Add("getAdd" + item.name + "SQL() {");

                //classes.Add(" VALUES(`\\");

                string insertsx = null;
                foreach (Campos campo in item.camposApi)
                {
                    Application.DoEvents();
                    if (campo.ChavePrimaria != "PRI")
                    {
                        insertsx = insertsx + "\"${this.x" + campo.Nome + "}\",";

                    }
                }

                string inserts = insertsx.Substring(0, insertsx.Length - 1);


                classes.Add("let sql = `INSERT INTO " + item.name + "(" + montasemchave + ") VALUES(" + inserts + ")`;");

                //classes.Add("VALUES(`"+inserts+"`");


                classes.Add("return sql;");
                classes.Add("}");



                classes.Add(" ");

                //get ID
                classes.Add("get" + item.name + "ByIdSQL(x" + campochave + ") {");
                classes.Add("let sql = `SELECT * FROM " + item.name + " WHERE " + campochave + " = ${x" + campochave + "}`;");
                classes.Add("return sql;");
                classes.Add("}");
                classes.Add(" ");

                //delete
                classes.Add("delete" + item.name + "ByIdSQL(x" + campochave + ") {");
                classes.Add(" let sql = `DELETE FROM " + item.name + " WHERE " + campochave + " = ${x" + campochave + "}`;");
                classes.Add("return sql;");
                classes.Add("}");
                classes.Add(" ");

                //get All
                classes.Add("getAll" + item.name + "SQL() {");
                classes.Add("let sql = `SELECT * FROM " + item.name + "`;");
                classes.Add("return sql;");
                classes.Add("}");
                classes.Add(" ");

                //update
                classes.Add("update" + item.name + "SQL(x" + campochave + ") {");
                classes.Add("let sql = `UPDATE " + item.name + " SET " + campoupdate + " WHERE " + campochave + " = ${x" + campochave + "}`;");
                classes.Add("return sql;");
                classes.Add("}");
                classes.Add(" ");



                classes.Add("}");

                classes.Add("module.exports = " + item.name + ";");

                memo_classes.Clear();

                foreach (string k in classes)
                {
                    Application.DoEvents();
                    memo_classes.AppendText(k + System.Environment.NewLine);
                }



                File.WriteAllText(path + "\\domain\\" + item.name + ".js", memo_classes.Text);
                classes.Clear();

                MontaApi();

            }

            PB.Value = 0;
            PB.Visible = false;
            label3.Visible = false;



        }



        public void MontaApi()
        {
            //Monta as APIs

            foreach (Tables item in tablenames)
            {
                Application.DoEvents();
                classes.Clear();
                classes.Add("const express = require(\"express\");");
                classes.Add("const db = require( \"../db/database\");");
                classes.Add("const "+ item.name + " = require( \"../domain/" + item.name+"\");");
                classes.Add("const router = express.Router();");


                //Listar
                classes.Add("");
                classes.Add("router.get(\"/\", (req, res, next) => {");
                classes.Add("  db.query("+ item.name + ".getAll"+ item.name + "SQL(), (err, data)=> {");
                classes.Add("    if(!err) {");
                classes.Add("       res.status(200).json({");
                classes.Add("       message:\"" + item.name + " listed.\",");
                classes.Add("       productId:data");
                classes.Add("       });");
                classes.Add("    }");
                classes.Add("  });");
                classes.Add("});");


                //Adicionar
                string insertsx = null;
                string chave = null;
                foreach (Campos campo in item.camposApi)
                {
                    Application.DoEvents();
                    if (campo.ChavePrimaria != "PRI")
                    {
                        insertsx = insertsx + "req.body."+ campo.Nome + ",";

                    } else
                    {
                        chave = campo.Nome;

                    }
                }
                string inserts = insertsx.Substring(0, insertsx.Length - 1);


                


                //Consultar
                classes.Add("");
                classes.Add("router.get(\"/:"+ chave +"\", (req, res, next) => {");
                classes.Add("let pid = req.params."+chave+";");
                classes.Add("  db.query(" + item.name + ".get" + item.name + "ByIdSQL(pid), (err, data)=> {");
                classes.Add("    if(!err) {");
                classes.Add("       if(data && data.length > 0) {");
                classes.Add("        res.status(200).json({");
                classes.Add("        message:\"" + chave + " found.\",");
                classes.Add("        "+ item.name + ": data");
                classes.Add("       });");
                classes.Add("          } else {");
                classes.Add("        res.status(200).json({");
                classes.Add("        message:\"" + chave + " notfound.\"");
                classes.Add("       });");
                classes.Add("    }");
                classes.Add("    }");
                classes.Add("  });");
                classes.Add("});");


                //Deletar
                classes.Add("");
                classes.Add("router.post(\"/delete\" , (req, res, next) => {");
                classes.Add("let pid = req.body." + chave + ";");
                classes.Add("  db.query(" + item.name + ".delete" + item.name + "ByIdSQL(pid), (err, data)=> {");
                classes.Add("    if(!err) {");
                classes.Add("       if(data && data.affectedRows > 0) {");
                classes.Add("        res.status(200).json({");
                classes.Add("        message:\"" + chave + " deleted.\",");
                classes.Add("        affectedRows: data.affectedRows");
                classes.Add("       });");
                classes.Add("          } else {");
                classes.Add("        res.status(200).json({");
                classes.Add("        message:\"" + chave + " notfound.\"");
                classes.Add("       });");
                classes.Add("    }");
                classes.Add("    }");
                classes.Add("  });");
                classes.Add("});");



                classes.Add("");
                classes.Add("router.post(\"/add\", (req, res, next) => {");
                // classes.Add("let x"+ item.name + " = new "+ item.name + "("+inserts+");");
                classes.Add("  db.query(new " + item.name + "(" + inserts + ").getAdd" + item.name + "SQL(), (err, data)=> {");
                classes.Add("    if(!err) {");
                classes.Add("       res.status(200).json({");
                classes.Add("       message:\"" + item.name + " added.\",");
                classes.Add("       productId: data.insertId");
                classes.Add("       });");
                classes.Add("    }");
                classes.Add("  });");
                classes.Add("});");




                classes.Add("");
                classes.Add("router.post(\"/update\", (req, res, next) => {");
                //classes.Add("let x" + item.name + " = new " + item.name + "(" + inserts + ");");
                classes.Add("let pid = req.body." + chave + ";");
                classes.Add("  db.query(new " + item.name + "(" + inserts + ").update" + item.name + "SQL(pid), (err, data)=> {");
                classes.Add("    if(!err) {");
                classes.Add("       res.status(200).json({");
                classes.Add("       message:\"" + item.name + " updated.\"");
                classes.Add("       });");
                classes.Add("    }");
                classes.Add("  });");
                classes.Add("});");

                classes.Add("module.exports = router;");


                memo_classes.Clear();

                foreach (string k in classes)
                {
                    Application.DoEvents();
                    memo_classes.AppendText(k + System.Environment.NewLine);
                }



                File.WriteAllText(path + "\\api\\" + item.name + ".js", memo_classes.Text);
                classes.Clear();

                MontaAPP();

            }
        }

        public void MontaAPP()
        {
            //Monta a APP


            classes.Clear();
            classes.Add("const express = require( \"express\");");
            classes.Add("const bodyparser = require( \"body-parser\");");
            classes.Add("const cors = require( \"cors\");");
            




            foreach (Tables item in tablenames)
            {
                Application.DoEvents();
                classes.Add("const " + item.name + " = require( \"./api/" + item.name +"\"); ");


            }

            classes.Add("const app = express();");
            classes.Add("app.use(cors());");
            classes.Add("app.use(bodyparser.json());");
            classes.Add("app.use(bodyparser.urlencoded({ extended: false}));");
            classes.Add("");

            foreach (Tables item in tablenames)
            {
                Application.DoEvents();

                classes.Add("app.use(\"/" + item.name +"\"," + item.name +" );");


            }

            classes.Add("app.use((req,res,next)=> {");
            classes.Add("     const err = new Error(\"Not Found\");");
            classes.Add("     err.status = 404;");
            classes.Add("     next(err);");
            classes.Add("});");


            classes.Add("app.use((err,req, res, next) => {");
            classes.Add("    res.status(err.status || 501);");
            classes.Add("    res.json({");
            classes.Add("       error: {");
            classes.Add("        code: err.status || 501,");
            classes.Add("        message: err.message");
            classes.Add("     }");
            classes.Add("  });");
            classes.Add(" });");

            classes.Add("module.exports = app;");

            memo_classes.Clear();

            foreach (string k in classes)
            {
                Application.DoEvents();
                memo_classes.AppendText(k + System.Environment.NewLine);
            }



            File.WriteAllText(path + "\\app.js" , memo_classes.Text);
            classes.Clear();


        }
        private void Button3_Click_1(object sender, EventArgs e)
        {
            PB.Visible = true;
            GerarClasses();
            PB.Visible = false;
            bNext.Visible = true;

        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ContextMenuStrip1_Click(object sender, EventArgs e)
        {
            
        }

        private void TVArqs_AfterSelect(object sender, TreeViewEventArgs e)
        {
           string pathx = path +"\\"+ e.Node.Text;

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
