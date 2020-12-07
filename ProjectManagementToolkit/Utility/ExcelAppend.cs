using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace ProjectManagementToolkit.Utility
{
    public class ExcelAppend
    {
        public enum DocumentType
        {
            AcceptanceRegister = 0,
            ChangeRegister,
            CommunicationsRegister,
            ExpenseRegister,
            IssueRegister,
            ProcurementRegister,
            QualityRegister,
            RiskRegister,
            TenderRegister,
            TimesheetRegister
        }

        public static bool ExportNotQualityRegister(int docType, DataGridView dataGridView)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.Filter = "Microsoft Excel 97-2003 Documents (*.xls)|*.xls";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialog.FileName;
                    Microsoft.Office.Interop.Excel.Application xlApp = null;
                    Workbook xlWorkbook = null;
                    Sheets xlSheets = null;
                    Worksheet xlSheet = null;

                    string templateFileName = "";
                    int templateStartingRow = -1;

                    switch (docType)
                    {
                        case (int) DocumentType.AcceptanceRegister:
                            templateFileName = "Acceptance Register.xls";
                            templateStartingRow = 10;
                            break;

                        case (int)DocumentType.ChangeRegister:
                            templateFileName = "Change Register.xls";
                            templateStartingRow = 8;
                            break;

                        case (int)DocumentType.CommunicationsRegister:
                            templateFileName = "Communications Register.xls";
                            templateStartingRow = 9;
                            break;

                        case (int)DocumentType.ExpenseRegister:
                            templateFileName = "Expense Register.xls";
                            templateStartingRow = 8;
                            break;

                        case (int)DocumentType.IssueRegister:
                            templateFileName = "Issue Register.xls";
                            templateStartingRow = 8;
                            break;

                        case (int)DocumentType.ProcurementRegister:
                            templateFileName = "Procurement Register.xls";
                            templateStartingRow = 9;
                            break;

                        case (int)DocumentType.QualityRegister:
                            templateFileName = "Quality Register.xls";
                            templateStartingRow = 10;
                            break;

                        case (int)DocumentType.RiskRegister:
                            templateFileName = "Risk Register.xls";
                            templateStartingRow = 8;
                            break;

                        case (int)DocumentType.TenderRegister:
                            templateFileName = "Tender Register.xls";
                            templateStartingRow = 9;
                            break;

                        case (int)DocumentType.TimesheetRegister:
                            templateFileName = "Timesheet Register.xls";
                            templateStartingRow = 8;
                            break;

                        default:
                            return false;
                    }

                    try
                    {
                        string tempString = System.Windows.Forms.Application.StartupPath;
                        tempString = tempString.Remove(tempString.LastIndexOf('\\'));
                        tempString = tempString.Remove(tempString.LastIndexOf('\\'));

                        templateFileName = $@"{tempString}\MPMM\Template Excel Sheets\" + templateFileName;

                        xlApp = new Microsoft.Office.Interop.Excel.Application();
                        xlWorkbook = xlApp.Workbooks.Open(templateFileName, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, true, XlPlatform.xlWindows, Type.Missing, false, false, Type.Missing, false, Type.Missing, Type.Missing);
                        xlSheets = xlWorkbook.Sheets as Sheets;
                        xlSheet = xlSheets[1];

                        int rowIndex = 0;

                        foreach (DataGridViewRow r in dataGridView.Rows)
                        {
                            if (!r.IsNewRow)
                            {
                                for (int x = 0; x < r.Cells.Count; x++)
                                {
                                    xlSheet.Cells[templateStartingRow + rowIndex, x + 2] = r.Cells[x].Value;
                                }
                            }

                            rowIndex++;
                        }

                        xlWorkbook.SaveAs(savePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        xlWorkbook.Close(true, Type.Missing, Type.Missing);
                        xlApp.Quit();
                        Marshal.ReleaseComObject(xlSheet);
                        Marshal.ReleaseComObject(xlWorkbook);
                        Marshal.ReleaseComObject(xlApp);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        MessageBox.Show("The document could not be exported.", "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
