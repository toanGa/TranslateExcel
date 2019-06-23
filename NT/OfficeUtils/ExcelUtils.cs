using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NT.OfficeUtils
{
    class ExcelUtils
    {
        Application xlApp;
        Workbook xlWorkBook;
        Worksheet xlWorkSheet;
        private string mExcellFileName;
        private int mSheetCount = 0;

        public ExcelUtils()
        {

        }

        public string ExcellFileName
        {
            get
            {
                return mExcellFileName;
            }
            set
            {
                if(!IsOpen())
                {
                    mExcellFileName = value;
                }
            }
        }

        public string[] AllSheets
        {
            
            get
            {
                string[] alls = null;

                if (IsOpen())
                {
                    Sheets sheets = xlWorkBook.Worksheets;
                    mSheetCount = sheets.Count;

                    alls = new string[mSheetCount];
                    for (int i = 1; i <= mSheetCount; i++)
                    {
                        alls[i - 1] = sheets.get_Item(i).Name;
                    }
                }

                return alls;
            }
        }

        /// <summary>
        /// open Excell file for background
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            if (!IsOpen())
            {
                try
                {
                    xlApp = new Application();
                    xlWorkBook = xlApp.Workbooks.Open(mExcellFileName);
                    xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return true;
            }
            else
            {
                xlWorkBook = xlApp.Workbooks.Open(mExcellFileName);
                xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            }
            return true;
        }

        /// <summary>
        /// close excell application
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            if (IsOpen())
            {
                try
                {
                    xlWorkBook.Close();
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);

                    xlApp = null;
                }
                catch (Exception ex)
                {
                    //throw ex;
                }

                return true;
            }
            return true;
        }

        /// <summary>
        /// save data processing to file
        /// </summary>
        /// <returns></returns>
        public void Sysn()
        {
            xlWorkBook.Save();
        }

        public void SaveAs(string newFile)
        {
            xlWorkBook.SaveAs(newFile);
        }

        /// <summary>
        /// Select sheet to focusing
        /// </summary>
        /// <param name="SheetName"></param>
        /// <returns></returns>
        public bool SelectSheet(string SheetName)
        {
            string[] allSheets = this.AllSheets;
            int i;
            int idxSheet = -1;

            for (i = 0; i < allSheets.Length; i++)
            {
                if (allSheets[i] == SheetName)
                {
                    idxSheet = i + 1;
                    break;
                }
            }

            if(idxSheet > 0)
            {
                xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(idxSheet);
                return true;
            }
            return false;
        }

        public string CellValues(string SheetName, int row, int col)
        {
            Worksheet sheet = null;

            string[] allSheets = this.AllSheets;
            int i;
            int idxSheet = -1;
            for (i = 0; i < allSheets.Length; i++)
            {
                if (allSheets[i] == SheetName)
                {
                    idxSheet = i + 1;
                    break;
                }
            }
            if (idxSheet > 0)
            {
                sheet = (Worksheet)xlWorkBook.Worksheets.get_Item(idxSheet);

            }

            if(sheet != null)
            {
                return (sheet.Cells[row, col] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
            }
            else
            {
                return "NULL";
            }
        }

        public string CellValues(int row, int col)
        {
            Range range = (xlWorkSheet.Cells[row, col] as Microsoft.Office.Interop.Excel.Range);
            if(range.Value2 != null)
            {
                return range.Value2.ToString();
            }
            return "";
        }

        public void SetCellValues(int row, int col, object value)
        {
            xlWorkSheet.Cells[row, col] = value;
        }

        public void GetRowCol(string SheetName, ref int row, ref int col)
        {
            Worksheet sheet = null;

            string[] allSheets = this.AllSheets;
            int i;
            int idxSheet = -1;
            for (i = 0; i < allSheets.Length; i++)
            {
                if (allSheets[i] == SheetName)
                {
                    idxSheet = i + 1;
                    break;
                }
            }
            if (idxSheet > 0)
            {
                sheet = (Worksheet)xlWorkBook.Worksheets.get_Item(idxSheet);

            }

            if (sheet != null)
            {
                // Not merge cell
                row = 1;
                col = 1;
                // find col
                while(sheet.Cells[1, col].Value2 != null)
                {
                    col++;
                }
                
                col--;

                // find row
                while (sheet.Cells[row, 1].Value2 != null)
                {
                    row++;
                }
                row--;

            }
            else
            {
                row = 0;
                col = 0;
            }
        }

        public void GetRowCol(ref int row, ref int col)
        {
            Worksheet sheet = xlWorkSheet;

            // Not merge cell
            row = 1;
            col = 1;
            // find col
            while (sheet.Cells[1, col].Value2 != null)
            {
                col++;
            }

            col--;

            // find row
            while (sheet.Cells[row, 1].Value2 != null)
            {
                row++;
            }
            row--;
        }

        /// <summary>
        /// check excell app open or not
        /// </summary>
        /// <returns></returns>
        public bool IsOpen()
        {
            return (xlApp != null);
        }

        /// <summary>
        /// open file to view
        /// </summary>
        public void OpenUI()
        {
            if (!IsOpen())
            {
                try
                {
                    Open();
                    xlApp.Visible = true;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            else
            {
                xlWorkBook = xlApp.Workbooks.Open(mExcellFileName);
                xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlApp.Visible = true;
            }
        }
    }
}
