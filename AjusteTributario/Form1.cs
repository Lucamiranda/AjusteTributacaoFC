using AjusteTributario.Modelos;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AjusteTributario
{
    public partial class Form1 : Form
    {
        CarregarGrid carregarGrid;
        string tabela;
        string grupo;
        bool tipo;
        public Form1()
        {
            InitializeComponent();
            rbRevenda.Checked = true;
            rbNCM.Checked = true;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            dgDados.DataSource = null;
            dgDados.Refresh();
            Importar importar = new Importar();
            dgDados.DataSource = importar.Tabela();
            tabela = dgDados.DataSource.ToString();
            btExportar.Enabled = false;
            btImportar.Enabled = true;

        }

        private void btExportar_Click(object sender, EventArgs e)
        {
            if (dgDados.Rows.Count == 0) return;
            Exportar exportar = new Exportar();
            exportar.Tabela(dgDados, tipo);
        }

        private void rbRevenda_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRevenda.Checked)
            {
                grupo = "R";
                dgDados.DataSource = null;
                progressoBarra.Value = 0;
                dgDados.Refresh();
            }
        }

        private void rbDrogaria_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDrogaria.Checked)
            {
                grupo = "D";
                dgDados.DataSource = null;
                progressoBarra.Value = 0;
                dgDados.Refresh();
            }
        }

        private void rbAmbos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAmbos.Checked)
            {
                grupo = "A";
                dgDados.DataSource = null;
                progressoBarra.Value = 0;
                dgDados.Refresh();
            }
        }

        private void rbNCM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNCM.Checked)
            {
                tipo = false;
                dgDados.DataSource = null;
                progressoBarra.Value = 0;
                dgDados.Refresh();
            }
        }

        private void rbProdutos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProdutos.Checked)
            {
                tipo = true;
                dgDados.DataSource = null;
                progressoBarra.Value = 0;
                dgDados.Refresh();
            }
        }

        private void btConsultar_Click(object sender, EventArgs e)
        {
            tabela = "";
            btImportar.Enabled = false;
            dgDados.DataSource = null;

            try
            {
                if (rbProdutos.Checked)
                {
                    btExportar.Enabled = true;
                    AjusteDAO dao = new AjusteDAO();
                    dgDados.DataSource = dao.BuscarDados(grupo);
                    carregarGrid = new CarregarGrid();
                    carregarGrid.CarregaGridProdutos(dgDados);
                }
                if (rbNCM.Checked)
                {

                    btExportar.Enabled = true;
                    AjusteDAO dao = new AjusteDAO();
                    dgDados.DataSource = dao.BuscarNCM(grupo);

                    carregarGrid = new CarregarGrid();
                    carregarGrid.CarregaGridNCM(dgDados);
                }
            }
            catch (FileNotFoundException)
            {
               MessageBox.Show("FirebirdSql.Data.FirebirdClient.dll - versão 5.12.1.0 não encontrada", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void  btImportar_Click(object sender, EventArgs e)
        {
            try
            {
                AjusteDAO dao = new AjusteDAO();

                if (dgDados.Rows.Count == 0) return;
                if (tabela.Equals("NCM-CST-PIS-COFINS"))
                {
                    ClassFiscal fiscal = new ClassFiscal();
                    try
                    {
                        progressoBarra.Value = 0;
                        progressoBarra.Maximum = dgDados.Rows.Count;
                        for (int i = 0; i <= dgDados.Rows.Count - 1; i++)
                        {
                            fiscal.ncm = dgDados.Rows[i].Cells[0].Value.ToString().Trim();
                            fiscal.cst = dgDados.Rows[i].Cells[1].Value.ToString().Trim();
                            fiscal.aliquotaICMS = dgDados.Rows[i].Cells[2].Value.ToString().Replace(",", ".").Trim();
                            fiscal.pis = dgDados.Rows[i].Cells[3].Value.ToString().Trim();
                            fiscal.aliquotaPIS = dgDados.Rows[i].Cells[4].Value.ToString().Replace(",", ".").Trim();
                            fiscal.cofins = dgDados.Rows[i].Cells[5].Value.ToString().Trim();
                            fiscal.aliquotaCOFINS = dgDados.Rows[i].Cells[6].Value.ToString().Replace(",", ".").Trim();
                            fiscal.ipi = dgDados.Rows[i].Cells[7].Value.ToString().Trim();
                            fiscal.aliquotaIPI = dgDados.Rows[i].Cells[8].Value.ToString().Replace(",", ".").Trim();
                            fiscal.cfop = "";
                            fiscal.listaPisCofins = dgDados.Rows[i].Cells[10].Value.ToString().ToLower().Trim();


                            switch (dgDados.Rows[i].Cells[11].Value.ToString().ToLower())
                            {
                                case "drogaria":
                                    grupo = "D";
                                    break;
                                case "revenda":
                                    grupo = "R";
                                    break;
                                default:
                                    break;
                            }
                            dao.AtualizarNCM(fiscal, grupo);
                            progressoBarra.Value = i + 1;
                        }
                        MessageBox.Show("Importação Realizada com sucesso", "Importação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception)
                    {
                        progressoBarra.Value = 0;

                    }
                }
                else if (tabela.Equals("CST-PIS-COFINS"))
                {
                    Produtos produtos = new Produtos();
                    try
                    {
                        progressoBarra.Value = 0;
                        progressoBarra.Maximum = dgDados.Rows.Count;
                        for (int i = 0; i <= dgDados.Rows.Count - 1; i++)
                        {
                            produtos.codigo = dgDados.Rows[i].Cells[0].Value.ToString().Trim();
                            produtos.produto = dgDados.Rows[i].Cells[1].Value.ToString().Trim();
                            produtos.grupo = dgDados.Rows[i].Cells[2].Value.ToString().Trim();
                            produtos.cst = dgDados.Rows[i].Cells[3].Value.ToString().Trim();
                            produtos.aliquotaICMS = dgDados.Rows[i].Cells[4].Value.ToString().Replace(",", ".").Trim();
                            produtos.pis = dgDados.Rows[i].Cells[5].Value.ToString().Trim();
                            produtos.aliquotaPIS = dgDados.Rows[i].Cells[6].Value.ToString().Replace(",", ".").Trim();
                            produtos.cofins = dgDados.Rows[i].Cells[7].Value.ToString().Trim();
                            produtos.aliquotaCOFINS = dgDados.Rows[i].Cells[8].Value.ToString().Replace(",", ".").Trim();
                            produtos.ipi = dgDados.Rows[i].Cells[9].Value.ToString().Trim();
                            produtos.aliquotaIPI = dgDados.Rows[i].Cells[10].Value.ToString().Replace(",", ".").Trim();
                            produtos.ncm = dgDados.Rows[i].Cells[11].Value.ToString().Trim();
                            produtos.cfop = "";
                            produtos.listaPisCofins = dgDados.Rows[i].Cells[13].Value.ToString().ToLower().Trim();
                            dao.AtualizaProdutos(produtos);
                            progressoBarra.Value = i + 1;
                        }
                        MessageBox.Show("Importação Realizada com sucesso", "Importação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception)
                    {
                        progressoBarra.Value = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Planilha Invalida!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("FirebirdSql.Data.FirebirdClient.dll - versão 5.12.1.0 não encontrada", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
