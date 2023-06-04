using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using System.Windows.Forms;
using AjusteTributario.Modelos;
using System.IO;
using System.Text;

namespace AjusteTributario
{
    internal class AjusteDAO
    {
        private DataTable _Parametros;
        private static FbDataReader _FbDataReader;
        private static FbCommand _FbCommand;
        private static FbDataAdapter _Adaptador;
        private Conexao conexao = new Conexao();

        public AjusteDAO()
        {
            Parametros();
        }

        //Carrega os Parametros do banco de dados.
        public DataTable Parametros()
        {
            try
            {
                _FbCommand = new FbCommand();
                _FbCommand.Connection = conexao.ObterConexao();
                _FbCommand.CommandText = "SELECT FC99999.ARGUMENTO, FC99999.SUBARGUM, FC99999.PARAMETRO FROM FC99999 WHERE FC99999.ARGUMENTO IN ('STRIB', 'SITTRIBIPI', 'SITTRIBPIS', 'SITTRIBCOFINS', 'CICMS', 'CDPIS', 'CDCOFINS', 'CDIPI')";

                _Parametros = new DataTable();
                _Adaptador = new FbDataAdapter(_FbCommand);
                _Adaptador.Fill(_Parametros);

                conexao.CloseConnection();

                return _Parametros;
            }
            catch (Exception)
            {
                MessageBox.Show("Base de dados não disponível", "Falha!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public List<Produtos> BuscarDados(string setor)
        {
            List<Produtos> listaProduto = new List<Produtos>();
            Produtos produtos;
            _FbCommand = new FbCommand();
            _FbCommand.Connection = conexao.ObterConexao();

            if (setor.Equals("R"))
            {
                _FbCommand.CommandText = "Select CDPRO, DESCR, STRIB, CDICM, CDSITPIS, CDPIS, CDSITCOFINS, CDCOFINS, CDSITIPI, CDIPI, CLFISC, INDCIP, CDCEST, GRUPO " +
                    "FROM FC03000 where Grupo = 'R' AND inddel = 'N'";
            }
            if (setor.Equals("D"))
            {
                _FbCommand.CommandText = "Select CDPRO, DESCR, STRIB, CDICM, CDSITPIS, CDPIS, CDSITCOFINS, CDCOFINS, CDSITIPI, CDIPI, CLFISC, INDCIP, CDCEST, GRUPO " +
                    "FROM FC03000 where Grupo ='D' AND inddel = 'N'";
            }
            if (setor.Equals("A"))
            {
                _FbCommand.CommandText = "Select CDPRO, DESCR, STRIB, CDICM, CDSITPIS, CDPIS, CDSITCOFINS, CDCOFINS, CDSITIPI, CDIPI, CLFISC, INDCIP, CDCEST, GRUPO " +
                    "FROM FC03000 where Grupo IN ('R','D') AND inddel = 'N' ORDER BY GRUPO";
            }

            try
            {
                _FbDataReader = _FbCommand.ExecuteReader();

                while (_FbDataReader.Read())
                {
                    produtos = new Produtos();
                    produtos.codigo = _FbDataReader["CDPRO"].ToString();
                    produtos.produto = _FbDataReader["DESCR"].ToString();
                    produtos.grupo = _FbDataReader["GRUPO"].ToString();
                    produtos.pis = _FbDataReader["CDSITPIS"].ToString();
                    produtos.cofins = _FbDataReader["CDSITCOFINS"].ToString();
                    produtos.ipi = _FbDataReader["CDSITIPI"].ToString();
                    produtos.ncm = _FbDataReader["CLFISC"].ToString().Trim();


                    //Parametros não encontrados devem retornar uma consulta conforme o registro do banco
                    if (_FbDataReader["STRIB"].ToString().Trim() == "")
                    {
                        produtos.cst = _FbDataReader["STRIB"].ToString();
                    }
                    else
                    {
                        try { produtos.cst = _Parametros.Select("ARGUMENTO = 'STRIB' and SUBARGUM='" + _FbDataReader["STRIB"] + "'")[0].ItemArray[2].ToString(); }
                        catch (IndexOutOfRangeException) { produtos.cst = _FbDataReader["STRIB"].ToString(); }
                    }

                    if (_FbDataReader["CDICM"].ToString().Trim() == "")
                    {
                        produtos.aliquotaICMS = _FbDataReader["CDICM"].ToString();
                    }
                    else
                    {
                        try { produtos.aliquotaICMS = _Parametros.Select("ARGUMENTO = 'CICMS' and SUBARGUM='" + _FbDataReader["CDICM"] + "'")[0].ItemArray[2].ToString(); }
                        catch (IndexOutOfRangeException) { produtos.aliquotaICMS = _FbDataReader["CDICM"].ToString(); }
                    }

                    if (_FbDataReader["CDPIS"].ToString().Trim() == "")
                    {
                        produtos.aliquotaCOFINS = _FbDataReader["CDPIS"].ToString();
                    }
                    else
                    {
                        try { produtos.aliquotaPIS = _Parametros.Select("ARGUMENTO = 'CDPIS' and SUBARGUM='" + _FbDataReader["CDPIS"] + "'")[0].ItemArray[2].ToString(); }
                        catch (IndexOutOfRangeException) { produtos.aliquotaCOFINS = _FbDataReader["CDPIS"].ToString(); }
                    }

                    if (_FbDataReader["CDCOFINS"].ToString().Trim() == "")
                    {
                        produtos.aliquotaCOFINS = _FbDataReader["CDCOFINS"].ToString();
                    }
                    else
                    {
                        try { produtos.aliquotaCOFINS = _Parametros.Select("ARGUMENTO = 'CDCOFINS' and SUBARGUM='" + _FbDataReader["CDCOFINS"] + "'")[0].ItemArray[2].ToString(); }
                        catch (IndexOutOfRangeException) { produtos.aliquotaCOFINS = _FbDataReader["CDCOFINS"].ToString(); }
                    }

                    if (_FbDataReader["CDIPI"].ToString().Trim() == "")
                    {
                        produtos.aliquotaIPI = _FbDataReader["CDIPI"].ToString();
                    }
                    else
                    {
                        try { produtos.aliquotaIPI = _Parametros.Select("ARGUMENTO = 'CDIPI' AND SUBARGUM='" + _FbDataReader["CDIPI"] + "'")[0].ItemArray[2].ToString(); }
                        catch (IndexOutOfRangeException) { produtos.aliquotaIPI = _FbDataReader["CDIPI"].ToString(); }
                    }

                    switch (_FbDataReader["INDCIP"].ToString().ToLower())
                    {
                        case "n":
                            produtos.listaPisCofins = "Normal";
                            break;
                        case "s":
                            produtos.listaPisCofins = "Negativa";
                            break;
                        case "i":
                            produtos.listaPisCofins = "Isenta";
                            break;
                        default:
                            produtos.listaPisCofins = _FbDataReader["INDCIP"].ToString();
                            break;
                    }

                    listaProduto.Add(produtos);
                }
                _FbDataReader.Close();
                conexao.CloseConnection();
                return listaProduto;
            }
            catch (Exception)
            {

                return listaProduto;
            }
            
        }

        public List<ClassFiscal> BuscarNCM(string setor)
        {
            List<ClassFiscal> listaNCM = new List<ClassFiscal>();
            ClassFiscal ncm;
            _FbCommand = new FbCommand();
            _FbCommand.Connection = conexao.ObterConexao();


            if (setor.Equals("R"))
            {
                _FbCommand.CommandText = "SELECT CLFISC, MAX(STRIB) AS STRIB, MAX(CDICM) AS CDICM, MAX(CDSITPIS) AS CDSITPIS, MAX(CDPIS) AS CDPIS, " +
                    "MAX(CDSITCOFINS) AS CDSITCOFINS, MAX(CDCOFINS) AS CDCOFINS, MAX(CDSITIPI) AS CDSITIPI, MAX(CDIPI) AS CDIPI, MAX(INDCIP) AS INDCIP, MAX(CDCEST) AS CDCEST, GRUPO" +
                    " FROM FC03000 " +
                    "WHERE CLFISC !='' AND GRUPO = 'R'" +
                    "GROUP BY CLFISC, GRUPO " +
                    "ORDER BY GRUPO";
            }
            if (setor.Equals("D"))
            {
                _FbCommand.CommandText = "SELECT CLFISC, MAX(STRIB) AS STRIB, MAX(CDICM) AS CDICM, MAX(CDSITPIS) AS CDSITPIS, MAX(CDPIS) AS CDPIS, " +
                    "MAX(CDSITCOFINS) AS CDSITCOFINS, MAX(CDCOFINS) AS CDCOFINS, MAX(CDSITIPI) AS CDSITIPI, MAX(CDIPI) AS CDIPI, MAX(INDCIP) AS INDCIP, MAX(CDCEST) AS CDCEST, GRUPO" +
                    " FROM FC03000 " +
                    "WHERE CLFISC !='' AND GRUPO = 'D'" +
                    "GROUP BY CLFISC, GRUPO " +
                    "ORDER BY GRUPO";
            }

            if (setor.Equals("A"))
            {
                _FbCommand.CommandText = "SELECT CLFISC, MAX(STRIB) AS STRIB, MAX(CDICM) AS CDICM, MAX(CDSITPIS) AS CDSITPIS, MAX(CDPIS) AS CDPIS, " +
                    "MAX(CDSITCOFINS) AS CDSITCOFINS, MAX(CDCOFINS) AS CDCOFINS, MAX(CDSITIPI) AS CDSITIPI, MAX(CDIPI) AS CDIPI, MAX(INDCIP) AS INDCIP, MAX(CDCEST) AS CDCEST, GRUPO" +
                    " FROM FC03000 " +
                    "WHERE CLFISC !='' AND GRUPO in ('R','D')" +
                    "GROUP BY CLFISC, GRUPO " +
                    "ORDER BY GRUPO";
            }
            try
            {
                _FbDataReader = _FbCommand.ExecuteReader();

                while (_FbDataReader.Read())
                {
                    ncm = new ClassFiscal();

                    ncm.ncm = _FbDataReader["CLFISC"].ToString().Trim();
                    ncm.cst = _FbDataReader["STRIB"].ToString().Trim();
                    ncm.pis = _FbDataReader["CDSITPIS"].ToString();
                    ncm.cofins = _FbDataReader["CDSITCOFINS"].ToString();
                    ncm.ipi = _FbDataReader["CDSITIPI"].ToString();


                    //Parametros não encontrados devem retornar uma consulta conforme o registro do banco
                    if (_FbDataReader["STRIB"].ToString().Trim() == "")
                    {
                        ncm.cst = _FbDataReader["STRIB"].ToString();
                    }
                    else
                    {
                        try { ncm.cst = _Parametros.Select("ARGUMENTO = 'STRIB' and SUBARGUM='" + _FbDataReader["STRIB"] + "'")[0].ItemArray[2].ToString(); }
                        catch (IndexOutOfRangeException) { ncm.cst = _FbDataReader["STRIB"].ToString(); }
                    }

                    if (_FbDataReader["CDICM"].ToString().Trim() == "")
                    {
                        ncm.aliquotaICMS = _FbDataReader["CDICM"].ToString();
                    }
                    else
                    {
                        try { ncm.aliquotaICMS = _Parametros.Select("ARGUMENTO = 'CICMS' and SUBARGUM='" + _FbDataReader["CDICM"] + "'")[0].ItemArray[2].ToString(); }
                        catch (IndexOutOfRangeException) { ncm.aliquotaICMS = _FbDataReader["CDICM"].ToString(); }
                    }

                    if (_FbDataReader["CDPIS"].ToString().Trim() == "")
                    {
                        ncm.aliquotaCOFINS = _FbDataReader["CDPIS"].ToString();
                    }
                    else
                    {
                        try { ncm.aliquotaPIS = _Parametros.Select("ARGUMENTO = 'CDPIS' and SUBARGUM='" + _FbDataReader["CDPIS"] + "'")[0].ItemArray[2].ToString(); }
                        catch (IndexOutOfRangeException) { ncm.aliquotaCOFINS = _FbDataReader["CDPIS"].ToString(); }
                    }

                    if (_FbDataReader["CDCOFINS"].ToString().Trim() == "")
                    {
                        ncm.aliquotaCOFINS = _FbDataReader["CDCOFINS"].ToString();
                    }
                    else
                    {
                        try { ncm.aliquotaCOFINS = _Parametros.Select("ARGUMENTO = 'CDCOFINS' and SUBARGUM='" + _FbDataReader["CDCOFINS"] + "'")[0].ItemArray[2].ToString(); }
                        catch (IndexOutOfRangeException) { ncm.aliquotaCOFINS = _FbDataReader["CDCOFINS"].ToString(); }
                    }

                    if (_FbDataReader["CDIPI"].ToString().Trim() == "")
                    {
                        ncm.aliquotaIPI = _FbDataReader["CDIPI"].ToString();
                    }
                    else
                    {
                        try { ncm.aliquotaIPI = _Parametros.Select("ARGUMENTO = 'CDIPI' AND SUBARGUM='" + _FbDataReader["CDIPI"] + "'")[0].ItemArray[2].ToString(); }
                        catch (IndexOutOfRangeException) { ncm.aliquotaIPI = _FbDataReader["CDIPI"].ToString(); }
                    }

                    switch (_FbDataReader["GRUPO"].ToString().ToLower())
                    {
                        case "r":
                            ncm.grupo = "Revenda";
                            break;
                        case "d":
                            ncm.grupo = "Drogaria";
                            break;
                        default:
                            ncm.grupo = _FbDataReader["GRUPO"].ToString();
                            break;
                    }

                    switch (_FbDataReader["INDCIP"].ToString().ToLower())
                    {
                        case "n":
                            ncm.listaPisCofins = "Normal";
                            break;
                        case "s":
                            ncm.listaPisCofins = "Negativa";
                            break;
                        case "i":
                            ncm.listaPisCofins = "Isenta";
                            break;
                        default:
                            ncm.listaPisCofins = _FbDataReader["INDCIP"].ToString();
                            break;
                    }
                    listaNCM.Add(ncm);
                }
                _FbDataReader.Close();
                conexao.CloseConnection();
                return listaNCM;
            }
            catch (Exception)
            {
                return listaNCM;

            }
            
        }

        public void AtualizaProdutos(Produtos produto)
        {
            _FbCommand = new FbCommand();
            _FbCommand.Connection = conexao.ObterConexao();

            _FbCommand.CommandText = "update FC03000" +
             " set STRIB = @STRIB," +
             " CDICM = @CDICM," +
             " CDSITPIS = @CDSITPIS," +
             " CDPIS = @CDPIS," +
             " CDSITCOFINS = @CDSITCOFINS," +
             " CDCOFINS = @CDCOFINS," +
             " CDSITIPI = @CDSITIPI," +
             " CDIPI = @CDIPI," +
             " INDCIP = @INDCIP" +
            " where CDPRO = @CDPRO";

            //Se o codigo do produto for vazio, excecução pula essa linha
            if (produto.codigo.Trim() == "") { return; }
            _FbCommand.Parameters.Add("@CDPRO", SqlDbType.Int).Value = produto.codigo;

            //Se o campo da planilha for vazio, irá gravar no banco como vazio. Caso não tenha o parametro cadastrado não terá nenhuma reação no update e irá gerar log de erro.
            try
            {
                if (produto.cst.Trim() == "") { _FbCommand.Parameters.Add("@STRIB", SqlDbType.VarChar).Value = ""; }
                else { _FbCommand.Parameters.Add("@STRIB", SqlDbType.VarChar).Value = _Parametros.Select("ARGUMENTO = 'STRIB' and PARAMETRO=" + produto.cst)[0].ItemArray[1].ToString().Trim(); }
            }
            catch (Exception)
            {
                Log(produto.codigo, "CST");
                return;
            }
            try
            {
                if (produto.aliquotaICMS.Trim() == "") { _FbCommand.Parameters.Add("@CDICM", SqlDbType.VarChar).Value = ""; }
                else { _FbCommand.Parameters.Add("@CDICM", SqlDbType.VarChar).Value = _Parametros.Select("ARGUMENTO = 'CICMS' and PARAMETRO='" + produto.aliquotaICMS + "'")[0].ItemArray[1].ToString().Trim(); }
            }
            catch (Exception)
            {
                Log(produto.codigo, "ALIQUOTA ICMS");
                return;
            }
            try
            {
                if (produto.pis.Trim() == "") { _FbCommand.Parameters.Add("@CDSITPIS", SqlDbType.VarChar).Value = ""; }
                else { _FbCommand.Parameters.Add("@CDSITPIS", SqlDbType.VarChar).Value = _Parametros.Select("ARGUMENTO = 'SITTRIBPIS' and SUBARGUM=" + produto.pis)[0].ItemArray[1].ToString().Trim(); }
            }
            catch (Exception)
            {
                Log(produto.codigo, "PIS");
                return;
            }
            try
            {
                if (produto.aliquotaPIS.Trim() == "") { _FbCommand.Parameters.Add("@CDPIS", SqlDbType.VarChar).Value = ""; }
                else { _FbCommand.Parameters.Add("@CDPIS", SqlDbType.VarChar).Value = _Parametros.Select("ARGUMENTO = 'CDPIS' and PARAMETRO='" + produto.aliquotaPIS.Replace(",", ".") + "'")[0].ItemArray[1].ToString().Trim(); }
            }
            catch (Exception)
            {
                Log(produto.codigo, "ALIQUOTA PIS");
                return;
            }

            try
            {
                if (produto.cofins.Trim() == "") { _FbCommand.Parameters.Add("@CDSITCOFINS", SqlDbType.VarChar).Value = ""; }
                else { _FbCommand.Parameters.Add("@CDSITCOFINS", SqlDbType.VarChar).Value = _Parametros.Select("ARGUMENTO = 'SITTRIBCOFINS' and SUBARGUM=" + produto.cofins)[0].ItemArray[1].ToString().Trim(); }
            }
            catch (Exception)
            {
                Log(produto.codigo, "COFINS");
                return;
            }

            try
            {
                if (produto.aliquotaCOFINS.Trim() == "") { _FbCommand.Parameters.Add("@CDCOFINS", SqlDbType.VarChar).Value = ""; }
                else { _FbCommand.Parameters.Add("@CDCOFINS", SqlDbType.VarChar).Value = _Parametros.Select("ARGUMENTO = 'CDCOFINS' and PARAMETRO='" + produto.aliquotaCOFINS.Replace(",", ".") + "'")[0].ItemArray[1].ToString().Trim(); }
            }
            catch (Exception)
            {
                Log(produto.codigo, "ALIQUOTA COFINS");
                return;
            }

            try
            {
                if (produto.ipi.Trim() == "") { _FbCommand.Parameters.Add("@CDSITIPI", SqlDbType.VarChar).Value = ""; }
                else { _FbCommand.Parameters.Add("@CDSITIPI", SqlDbType.VarChar).Value = _Parametros.Select("ARGUMENTO = 'SITTRIBIPI' and SUBARGUM=" + produto.ipi)[0].ItemArray[1].ToString().Trim(); }
            }
            catch (Exception)
            {
                Log(produto.codigo, "IPI");
                return;
            }

            try
            {
                if (produto.aliquotaIPI.Trim() == "") { _FbCommand.Parameters.Add("@CDIPI", SqlDbType.VarChar).Value = ""; }
                else { _FbCommand.Parameters.Add("@CDIPI", SqlDbType.VarChar).Value = _Parametros.Select("ARGUMENTO = 'CDIPI' and PARAMETRO='" + produto.aliquotaIPI.Replace(",", ".") + "'")[0].ItemArray[1].ToString().Trim(); }
            }
            catch (Exception)
            {
                Log(produto.codigo, "ALIQUOTA IPI");
                return;
            }


            switch (produto.listaPisCofins.ToLower())
            {
                case "normal":
                    _FbCommand.Parameters.Add("@INDCIP", SqlDbType.VarChar).Value = "N";
                    break;
                case "negativa":
                    _FbCommand.Parameters.Add("@INDCIP", SqlDbType.VarChar).Value = "S";
                    break;
                case "isenta":
                    _FbCommand.Parameters.Add("@INDCIP", SqlDbType.VarChar).Value = "I";
                    break;
                case "":
                    _FbCommand.Parameters.Add("@INDCIP", SqlDbType.VarChar).Value = "";
                    break;
                default:
                    Log(produto.codigo, "LISTA PIS/COFINS");
                    return;
            }

            try
            {
                _FbCommand.ExecuteNonQuery();
            }
            catch (FbException) { }
            conexao.CloseConnection();
        }


        public void AtualizarNCM(ClassFiscal fiscal, string grupo)
        {
            _FbCommand = new FbCommand();
            _FbCommand.Connection = conexao.ObterConexao();

            _FbCommand.CommandText = "update FC03000" +
             " set STRIB = @STRIB," +
             " CDICM = @CDICM," +
             " CDSITPIS = @CDSITPIS," +
             " CDPIS = @CDPIS," +
             " CDSITCOFINS = @CDSITCOFINS," +
             " CDCOFINS = @CDCOFINS," +
             " CDSITIPI = @CDSITIPI," +
             " CDIPI = @CDIPI," +
             " INDCIP = @INDCIP" +
            " where CLFISC = @CLFISC AND GRUPO='" + grupo + "'";

            //Se o codigo do NCM for vazio, excecução pula essa linha
            if (fiscal.ncm.Trim() == "") { return; }

            //Se o campo da planilha for vazio, irá gravar no banco como vazio. Caso não tenha o parametro cadastrado não terá nenhuma ação no update.
            try
            {
                if (fiscal.cst.Trim() == "") { _FbCommand.Parameters.Add("@STRIB", SqlDbType.VarChar).Value = ""; }
                else { _FbCommand.Parameters.Add("@STRIB", SqlDbType.VarChar).Value = _Parametros.Select("ARGUMENTO = 'STRIB' and PARAMETRO=" + fiscal.cst)[0].ItemArray[1].ToString().Trim(); }
            }
            catch (Exception)
            {
                Log(fiscal.ncm, "CST");
                return;
            }

            try
            {
                if (fiscal.aliquotaICMS.Trim() == "") { _FbCommand.Parameters.Add("@CDICM", SqlDbType.VarChar).Value = ""; }
                else { _FbCommand.Parameters.Add("@CDICM", SqlDbType.VarChar).Value = _Parametros.Select("ARGUMENTO = 'CICMS' and PARAMETRO='" + fiscal.aliquotaICMS + "'")[0].ItemArray[1].ToString().Trim(); }

            }
            catch (Exception)
            {
                Log(fiscal.ncm, "ALIQUOTA ICMS");
                return;
            }

            try
            {
                if (fiscal.pis.Trim() == "") { _FbCommand.Parameters.Add("@CDSITPIS", SqlDbType.VarChar).Value = ""; }
                else { _FbCommand.Parameters.Add("@CDSITPIS", SqlDbType.VarChar).Value = _Parametros.Select("ARGUMENTO = 'SITTRIBPIS' and SUBARGUM=" + fiscal.pis)[0].ItemArray[1].ToString().Trim(); }
            }
            catch (Exception)
            {
                Log(fiscal.ncm, "PIS");
                return;
            }

            try
            {
                if (fiscal.aliquotaPIS.Trim() == "") { _FbCommand.Parameters.Add("@CDPIS", SqlDbType.VarChar).Value = ""; }
                else { _FbCommand.Parameters.Add("@CDPIS", SqlDbType.VarChar).Value = _Parametros.Select("ARGUMENTO = 'CDPIS' and PARAMETRO='" + fiscal.aliquotaPIS + "'")[0].ItemArray[1].ToString().Trim(); }

            }
            catch (Exception)
            {
                Log(fiscal.ncm, "ALIQUOTA PIS");
                return;
            }

            try
            {
                if (fiscal.cofins.Trim() == "") { _FbCommand.Parameters.Add("@CDSITCOFINS", SqlDbType.VarChar).Value = ""; }
                else { _FbCommand.Parameters.Add("@CDSITCOFINS", SqlDbType.VarChar).Value = _Parametros.Select("ARGUMENTO = 'SITTRIBCOFINS' and SUBARGUM=" + fiscal.cofins)[0].ItemArray[1].ToString().Trim(); }
            }
            catch (Exception)
            {
                Log(fiscal.ncm, "COFINS");
                return;
            }

            try
            {
                if (fiscal.aliquotaCOFINS.Trim() == "") { _FbCommand.Parameters.Add("@CDCOFINS", SqlDbType.VarChar).Value = ""; }
                else { _FbCommand.Parameters.Add("@CDCOFINS", SqlDbType.VarChar).Value = _Parametros.Select("ARGUMENTO = 'CDCOFINS' and PARAMETRO='" + fiscal.aliquotaCOFINS + "'")[0].ItemArray[1].ToString().Trim(); }
            }
            catch (Exception)
            {
                Log(fiscal.ncm, "ALIQUOTA COFINS");
                return;
            }

            try
            {
                if (fiscal.ipi.Trim() == "") { _FbCommand.Parameters.Add("@CDSITIPI", SqlDbType.VarChar).Value = ""; }
                else { _FbCommand.Parameters.Add("@CDSITIPI", SqlDbType.VarChar).Value = _Parametros.Select("ARGUMENTO = 'SITTRIBIPI' and SUBARGUM=" + fiscal.ipi)[0].ItemArray[1].ToString().Trim(); }
            }
            catch (Exception)
            {
                Log(fiscal.ncm, "IPI");
                return;
            }

            try
            {
                if (fiscal.aliquotaIPI.Trim() == "") { _FbCommand.Parameters.Add("@CDIPI", SqlDbType.VarChar).Value = ""; }
                else { _FbCommand.Parameters.Add("@CDIPI", SqlDbType.VarChar).Value = _Parametros.Select("ARGUMENTO = 'CDIPI' and PARAMETRO='" + fiscal.aliquotaIPI + "'")[0].ItemArray[1].ToString().Trim(); }

            }
            catch (Exception)
            {
                Log(fiscal.ncm, "ALIQUOTA IPI");
                return;
            }

            switch (fiscal.listaPisCofins.ToLower())
            {
                case "normal":
                    _FbCommand.Parameters.Add("@INDCIP", SqlDbType.VarChar).Value = "N";
                    break;
                case "negativa":
                    _FbCommand.Parameters.Add("@INDCIP", SqlDbType.VarChar).Value = "S";
                    break;
                case "isenta":
                    _FbCommand.Parameters.Add("@INDCIP", SqlDbType.VarChar).Value = "I";
                    break;
                case "":
                    _FbCommand.Parameters.Add("@INDCIP", SqlDbType.VarChar).Value = "";
                    break;
                default:
                    Log(fiscal.ncm, "LISTA PIS/COFINS");
                    return;
            }

            try
            {
                _FbCommand.ExecuteNonQuery();
            }
            catch (FbException) { }


            conexao.CloseConnection();
        }

        public void Log(string mensagem, string campo)
        {
            string caminhoLog = Application.StartupPath + @"\LogImportacao" + DateTime.Now.ToString("ddMMyyyyHHmm") + ".txt";

            StreamWriter arquivoLog = new StreamWriter(caminhoLog, true, Encoding.Default);
            arquivoLog.WriteLine("PRODUTO/NCM " + mensagem + " NÃO ATUALIZADO, VERIFIQUE O CAMPO : " + campo);
            arquivoLog.Dispose();
        }
    }
}
