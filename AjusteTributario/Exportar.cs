using AjusteTributario.Modelos;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AjusteTributario
{
    public class Exportar
    {
        public void Tabela(DataGridView grid, bool tipo)
        {
            using (FolderBrowserDialog pastaSalvar = new FolderBrowserDialog())
            {
                if (pastaSalvar.ShowDialog() == DialogResult.OK)
                {
                    string path = pastaSalvar.SelectedPath;
                    try
                    {
                        using (var xLWorkbook = new XLWorkbook())
                        {

                            if (tipo.Equals(true))
                            {
                                var worksheets = xLWorkbook.Worksheets.Add("CST-PIS-COFINS");
                                worksheets.Columns().Style.NumberFormat.Format = "@";

                                worksheets.Cell(1,1).InsertTable((IEnumerable<Produtos>)grid.DataSource);
                                worksheets.Cell(1, 1).Value = "CODIGO";
                                worksheets.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.Red;
                                worksheets.Cell(1, 2).Value = "DESCRIÇÃO";
                                worksheets.Cell(1, 2).Style.Fill.BackgroundColor = XLColor.Red;
                                worksheets.Cell(1, 3).Value = "GRUPO";
                                worksheets.Cell(1, 3).Style.Fill.BackgroundColor = XLColor.Red;
                                worksheets.Cell(1, 4).Value = "CST";
                                worksheets.Cell(1, 5).Value = "ALIQUOTA ICMS";
                                worksheets.Cell(1, 6).Value = "PIS";
                                worksheets.Cell(1, 7).Value = "ALIQUOTA PIS";
                                worksheets.Cell(1, 8).Value = "COFINS";
                                worksheets.Cell(1, 9).Value = "ALIQUOTA COFINS";
                                worksheets.Cell(1, 10).Value = "IPI";
                                worksheets.Cell(1, 11).Value = "ALIQUOTA IPI";
                                worksheets.Cell(1, 12).Value = "NCM";
                                worksheets.Cell(1, 12).Style.Fill.BackgroundColor = XLColor.Red;
                                worksheets.Cell(1, 13).Value = "CFOP";
                                worksheets.Cell(1, 14).Value = "LISTA PIS/COFINS";
                                worksheets.Columns().AdjustToContents();
                                xLWorkbook.SaveAs(path + @"\CST-PIS-COFINS.xlsx");
                            }
                            if (tipo.Equals(false))
                            {
                                var worksheets = xLWorkbook.Worksheets.Add("NCM-CST-PIS-COFINS");
                                worksheets.Columns().Style.NumberFormat.Format = "@";

                                worksheets.Cell("A1").InsertTable((IEnumerable<ClassFiscal>)grid.DataSource);
                                worksheets.Cell(1, 1).Value = "NCM";
                                worksheets.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.Red;
                                worksheets.Cell(1, 2).Value = "CST";
                                worksheets.Cell(1, 3).Value = "ALIQUOTA ICMS";
                                worksheets.Cell(1, 4).Value = "PIS";
                                worksheets.Cell(1, 5).Value = "ALIQUOTA PIS";
                                worksheets.Cell(1, 6).Value = "COFINS";
                                worksheets.Cell(1, 7).Value = "ALIQUOTA COFINS";
                                worksheets.Cell(1, 8).Value = "IPI";
                                worksheets.Cell(1, 9).Value = "ALIQUOTA IPI";
                                worksheets.Cell(1, 10).Value = "CFOP";
                                worksheets.Cell(1, 11).Value = "LISTA PIS/COFINS";
                                worksheets.Cell(1, 12).Value = "REVENDA";
                                worksheets.Cell(1, 12).Style.Fill.BackgroundColor = XLColor.Red;
                                worksheets.Columns().AdjustToContents();
                                xLWorkbook.SaveAs(path + @"\NCM-CST-PIS-COFINS.xlsx");
                            }
                        }
                        MessageBox.Show("Planilha salva", "Exportação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
    }
}
