using ExcelDataReader;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace AjusteTributario
{
    public class Importar
    {
        public DataTable Tabela()
        {
            DataTable dt = new DataTable();
            DataTableCollection tabela;

            using (OpenFileDialog abrir = new OpenFileDialog() { Filter = "Planilha|*.xlsx" })
            {
                if (abrir.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var stream = File.Open(abrir.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                });
                                tabela = result.Tables;
                                dt = tabela[0];
                            }
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Feche a planilha antes de importar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }            
            return dt;
        }
    }
}
