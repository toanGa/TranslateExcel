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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int row;
            int col;
            int.TryParse(textBoxRow.Text, out row);
            int.TryParse(textBoxCol.Text, out col);
            int sheetRow = 0;
            int sheetCol = 0;
            int sheetIndex;
            string translateText;
            string[] AllSheets = inputFileXls.AllSheets;
            int NumSheets = AllSheets.Length;

            for(sheetIndex = 3; sheetIndex <= NumSheets; sheetIndex++)
            {
                // output and input focus on sheet
                inputFileXls.SelectSheet(AllSheets[sheetIndex - 1]);
                outputFileXls.SelectSheet(AllSheets[sheetIndex - 1]);

                // Get row and col of sheet
                inputFileXls.GetRowCol(ref sheetRow, ref sheetCol);

                for (row = 1; row <= sheetRow; row++)
                {
                    for (col = 1; col <= sheetCol; col++)
                    {
                        string value = inputFileXls.CellValues(row, col);

                        translateText = translator.Translate(value, comboBoxLangSrc.Text, comboBoxLangDst.Text);

                        textBoxDebug.Text = translateText;

                        outputFileXls.SetCellValues(row, col, translateText);

                        Thread.Sleep(3000);
                    }
                }
            }
            
            
            
            outputFileXls.SaveAs("Translated Testcase.xlsx");
            MessageBox.Show("Translate done");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            inputFileXls.Close();
            outputFileXls.Close();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            translator = new Translator();

            inputFileXls = new ExcelUtils();
            inputFileXls.ExcellFileName = textBoxFileName.Text;
            inputFileXls.Open();

            outputFileXls = new ExcelUtils();
            outputFileXls.ExcellFileName = textBoxFileName.Text;
            outputFileXls.Open();

            comboBox1.DataSource = inputFileXls.AllSheets;
            comboBox1.Text = inputFileXls.AllSheets[0];

            string[] langSrc = Translator.Languages.ToArray();
            string[] langDst = Translator.Languages.ToArray();

            comboBoxLangSrc.DataSource = langSrc;
            comboBoxLangDst.DataSource = langDst;

            comboBoxLangSrc.Text = "Vietnamese";
            comboBoxLangDst.Text = "English";
        }
    }
}
