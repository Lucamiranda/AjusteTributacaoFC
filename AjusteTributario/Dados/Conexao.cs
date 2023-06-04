using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;


namespace AjusteTributario
{

    public class Conexao
    {
        private static string _FbConnectionString;
        private static FbConnection _FbConnection;
        public Conexao()
        {
            ObterConexao();
            Ini();
        }

        public void Ini()
        {
            string nomeServidor;
            string pathPar;
            string path = Application.StartupPath + @"\Alterdb.ini";
            InicializadorINI ini = new InicializadorINI(path);

            nomeServidor = ini.IniReadValue("SERVIDOR", "NOMESERVIDOR");
            pathPar = ini.IniReadValue("PATH", "PATHPAR");

            _FbConnectionString = @"User = SYSDBA; Password = masterkey; Database =" + nomeServidor + ":" + pathPar + "\\alterdb.ib";
        }
        public FbConnection ObterConexao()
        {
            try
            {
                _FbConnection = new FbConnection(_FbConnectionString);
                _FbConnection.Open();
                return _FbConnection;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public void CloseConnection()
        {
            if(_FbConnection.State == ConnectionState.Open)
            {
                _FbConnection.Close();
            }
        }
    }
}
