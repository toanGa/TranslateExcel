using NT.OfficeUtils;
using RavSoft.GoogleTranslator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT
{
    public partial class Form1 : Form
    {
        ExcelUtils inputFileXls;
        ExcelUtils outputFileXls;
        Translator translator;

        public Form1()
        {
            InitializeComponent();

            translator = new Translator();

            inputFileXls = new ExcelUtils();
            inputFileXls.ExcellFileName = @"E:\20190610_Testcase EVT - Copy 2.xlsx";
            inputFileXls.Open();

            outputFileXls = new ExcelUtils();
            outputFileXls.ExcellFileName = @"E:\20190610_Testcase EVT - Copy 2.xlsx";
            outputFileXls.OpenUI();

            comboBox1.DataSource = inputFileXls.AllSheets;
            comboBox1.Text = inputFileXls.AllSheets[0];

            string[] langSrc = Translator.Languages.ToArray();
            string[] langDst = Translator.Languages.ToArray();
            
            comboBoxLangSrc.DataSource = langSrc;
            comboBoxLangDst.DataSource = langDst;

            comboBoxLangSrc.Text = "Vietnamese"; 
            comboBoxLangDst.Text = "English";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int row;
            int col;
            int.TryParse(textBoxRow.Text, out row);
            int.TryParse(textBoxCol.Text, out col);
            int sheetRow = 0;
            int sheetCol = 0;
            string translateText;

            inputFileXls.SelectSheet(comboBox1.Text);
            outputFileXls.SelectSheet(comboBox1.Text);

            inputFileXls.GetRowCol(ref sheetRow, ref sheetCol);

            for(row = 1; row <= sheetRow; row++)
            {
                for(col = 1; col <= sheetCol; col++)
                {
                    string value = inputFileXls.CellValues(row, col);

                    textBoxDebug.Text = value;

                    translateText = translator.Translate(value, comboBoxLangSrc.Text, comboBoxLangDst.Text);

                    Thread.Sleep(5000);

                    outputFileXls.SetCellValues(row, col, translateText);
                }
            }

            outputFileXls.SaveAs(comboBox1.Text + DateTime.Now.ToString() + ".xlsx");

            //textBoxDebug.Text = translateText;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            inputFileXls.Close();
            outputFileXls.Close();
        }
    }
}
