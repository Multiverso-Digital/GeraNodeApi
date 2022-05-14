using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeraNodeApi
{
    public class Projeto
    {

        private string name;
        private string author;
        private string version;
        private string folderPath;



        public String Name { get => name; set => name = value; }
        public String Author { get => author; set => author = value; }
        public String Version { get => version; set => version = value; }
        public String FolderPath { get => folderPath; set => folderPath = value; }

        public const String NpmInit = "npm i --save node express cookie-parser morgan debug http-errors cors";
        public const String NpmIExpress = "npm install express -generator -g";
        public const String NpmExpress = "express -f";
        public const String NpmMysql = "npm install -S mysql2";
        public const String NpmInstall = "npm install";
       
        
        public Projeto()
        {

            //MessageBox.Show("Objeto Criado com sucesso!");
        }

        ~Projeto()
        {

        }







    }
}
