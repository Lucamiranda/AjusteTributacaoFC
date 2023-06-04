using System.Windows.Forms;

namespace AjusteTributario
{
    internal class CarregarGrid
    {
        //Layout DataGrid da aba Produtos
        public void CarregaGridProdutos(DataGridView dg)
        {
            dg.ReadOnly = true;
            dg.Columns[0].HeaderText = "CÓDIGO";
            dg.Columns[0].Width = 60;

            dg.Columns[1].HeaderText = "PRODUTO";
            dg.Columns[1].Width = 250;

            dg.Columns[2].HeaderText = "GRUPO";
            dg.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[2].Width = 50;

            dg.Columns[3].HeaderText = "CST";
            dg.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[3].Width = 50;

            dg.Columns[4].HeaderText = "ALÍQUOTA ICMS";
            dg.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[4].Width = 80;

            dg.Columns[5].HeaderText = "PIS";
            dg.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[5].Width = 50;

            dg.Columns[6].HeaderText = "ALÍQUOTA PIS";
            dg.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[6].Width = 80;

            dg.Columns[7].HeaderText = "COFINS";
            dg.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[7].Width = 50;

            dg.Columns[8].HeaderText = "ALÍQUOTA COFINS";
            dg.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[8].Width = 80;

            dg.Columns[9].HeaderText = "IPI";
            dg.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[9].Width = 50;

            dg.Columns[10].HeaderText = "ALÍQUOTA IPI";
            dg.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[10].Width = 80;

            dg.Columns[11].HeaderText = "NCM";
            dg.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[11].Width = 80;

            dg.Columns[12].HeaderText = "CFOP";
            dg.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[12].Width = 80;

            dg.Columns[13].HeaderText = "LISTA PIS/COFINS";
            dg.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[13].Width = 100;
        }

        //Layout DataGrid da aba NCM
        public void CarregaGridNCM(DataGridView dg)
        {
            dg.ReadOnly = true;
            dg.Columns[0].HeaderText = "NCM";
            dg.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[0].Width = 80;

            dg.Columns[1].HeaderText = "CST";
            dg.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[1].Width = 50;

            dg.Columns[2].HeaderText = "ALÍQUOTA ICMS";
            dg.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[2].Width = 50;

            dg.Columns[3].HeaderText = "PIS";
            dg.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[3].Width = 50;

            dg.Columns[4].HeaderText = "ALÍQUOTA PIS";
            dg.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[4].Width = 50;

            dg.Columns[5].HeaderText = "COFINS";
            dg.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[5].Width = 50;

            dg.Columns[6].HeaderText = "ALÍQUOTA COFINS";
            dg.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[6].Width = 50;

            dg.Columns[7].HeaderText = "IPI";
            dg.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[7].Width = 50;

            dg.Columns[8].HeaderText = "ALÍQUOTA IPI";
            dg.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[8].Width = 50;

            dg.Columns[9].HeaderText = "CFOP";
            dg.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[9].Width = 50;

            dg.Columns[10].HeaderText = "LISTA PIS/COFINS";
            dg.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[10].Width = 80;

            dg.Columns[11].HeaderText = "GRUPO";
            dg.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dg.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg.Columns[11].Width = 80;
        }
    }
}
