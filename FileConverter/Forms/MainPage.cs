using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using System.Data.OleDb;
using FileConverter.Entities;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace FileConverter.Forms
{
    public partial class MainPage : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private List<Worksheet> Worksheets;
        private int MaxColumnCount;

        public MainPage()
        {
            InitializeComponent();

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green900, Primary.Green600, Primary.Green900, Accent.LightBlue200, TextShade.WHITE);

            Worksheets = new List<Worksheet>();
        }

        private void UploadExcelMaterialButton_Click(object sender, EventArgs e)
        {
            Worksheets = new List<Worksheet>();

            DialogResult result = UploadExcelOpenFileDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                ExcelDataPreviewMaterialMultiLineTextBox.Clear();
                WordSaveMaterialButton.Visible = !(UploadExcelMaterialButton.Visible = true);

                pictureBox1.Image = TabControlImageList.Images[0];
            }
        }

        private void UploadExcelOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog openFileDialog = (OpenFileDialog)sender;

            pictureBox1.Image = TabControlImageList.Images[1];
            WordSaveMaterialButton.Visible = !(UploadExcelMaterialButton.Visible = false);

            if (ReadSample(openFileDialog.FileName))
            {
                SetRichTextBoxContent();
            }
        }

        public string GetConnectionString(string path)
        {
            string result = string.Empty;

            if (path.EndsWith(".xlsx"))
            {
                //2007 Format
                result = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", path);
            }
            else
            {
                //2003 Format
                result = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", path);
            }
            return result;
        }

        public bool ReadSample(string filepath)
        {
            if (string.IsNullOrWhiteSpace(filepath)) return false;

            string connString = GetConnectionString(filepath);
            if (string.IsNullOrWhiteSpace(connString)) return false;

            string full = Path.GetFullPath(filepath);
            string file = Path.GetFileName(full);
            string dir = Path.GetDirectoryName(full);

            using (OleDbConnection con = new OleDbConnection(connString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    con.Close();

                    Worksheets = new List<Worksheet>();
                    for (int sheetIndex = 0; sheetIndex < dtExcelSchema.Rows.Count; sheetIndex++)
                    {
                        string sheet = dtExcelSchema.Rows[sheetIndex]["TABLE_NAME"].ToString();
                        if (string.IsNullOrWhiteSpace(sheet)) continue;

                        cmd.CommandText = "SELECT * From [" + sheet + "]";

                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        {
                            DataTable HeaderColumns = new DataTable();
                            da.SelectCommand = cmd;
                            da.Fill(HeaderColumns);

                            string columnName = "", header = "";
                            int titleRowIndex = 0;
                            Worksheet worksheet = new Worksheet() { 
                                fileName = file,
                                directoryName = dir,
                                fullPath = full,
                                name = sheet,
                                rowDataWithHeader = new Dictionary<int, List<string>>()
                            };

                            MaxColumnCount = Math.Max(MaxColumnCount, HeaderColumns.Columns.Count);

                            for (int rowIndex = titleRowIndex + 1; rowIndex < HeaderColumns.Rows.Count; rowIndex++)
                            {
                                DataRow row = HeaderColumns.Rows[rowIndex];
                                if (row == null) continue;

                                if (!worksheet.rowDataWithHeader.ContainsKey(rowIndex)) worksheet.rowDataWithHeader.Add(rowIndex, new List<string>());

                                for (int colIndex = 0; colIndex < HeaderColumns.Columns.Count; colIndex++)
                                {
                                    DataColumn column = HeaderColumns.Columns[colIndex];
                                    if (column == null) continue;

                                    columnName = HeaderColumns.Rows[rowIndex][column.ColumnName].ToString();

                                    string formatedData = string.Format($"{column.ToString()} : { columnName }");
                                    
                                    worksheet.rowDataWithHeader[rowIndex].Add(formatedData);
                                }
                            }

                            Worksheets.Add(worksheet);
                        }
                    }
                }
            }

            return Worksheets != null && Worksheets.Count > 0;
        }

        private void SetRichTextBoxContent()
        {
            try
            {
                if (Worksheets == null || Worksheets.Count < 1)
                {
                    WordSaveMaterialButton.Visible = !(UploadExcelMaterialButton.Visible = true);
                    return;
                }


                ExcelDataPreviewMaterialMultiLineTextBox.Clear();

                string text = "";
                for (int wIndex = 0; wIndex < Worksheets.Count; wIndex++)
                {
                    Worksheet worksheet = Worksheets.ElementAt(wIndex);
                    if (worksheet == null) continue;

                    text += string.Format($" \t{worksheet.fullPath}-{worksheet.name}\n");

                    foreach (KeyValuePair<int, List<string>> pair in worksheet.rowDataWithHeader)
                    {
                        text += string.Format($"\n{pair.Key}-)\n");

                        for (int dIndex = 0; dIndex < pair.Value.Count; dIndex++)
                        {
                            string data = pair.Value.ElementAt(dIndex);
                            if (string.IsNullOrWhiteSpace(data)) data = "";

                            text += string.Format($"\n{data}");
                        }

                        text += "\n";
                    }


                    text = string.Format(" \n" + text + "\n ");
                    ExcelDataPreviewMaterialMultiLineTextBox.Text += text;
                    text = "\n";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void WordSaveMaterialButton_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = @"All Files|*.txt;*.docx;*.doc;*.pdf*|Text File (.txt)|*.txt|Word File (.docx ,.doc)|*.docx;*.doc|PDF (.pdf)|*.pdf";
            saveFileDialog1.Title = "Word Dosyası Olarak Kaydet";
            saveFileDialog1.FilterIndex = 3;
            saveFileDialog1.RestoreDirectory = true;
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (var document = WordprocessingDocument.Create(saveFileDialog1.FileName, WordprocessingDocumentType.Document))
                {
                    document.AddMainDocumentPart();
                    Body body = new Body();

                    for (int wIndex = 0; wIndex < Worksheets.Count; wIndex++)
                    {
                        Worksheet worksheet = Worksheets.ElementAt(wIndex);
                        if (worksheet == null) continue;

                        Paragraph para = body.AppendChild(new Paragraph());
                        Run run = para.AppendChild(new Run());
                        run.AppendChild(new Text(string.Format($" \t{worksheet.fullPath}-{worksheet.name}\n")));

                        foreach (KeyValuePair<int, List<string>> pair in worksheet.rowDataWithHeader)
                        {
                            para = body.AppendChild(new Paragraph());
                            run = para.AppendChild(new Run());
                            run.AppendChild(new Text(string.Format($" \n ")));

                            for (int dIndex = 0; dIndex < pair.Value.Count; dIndex++)
                            {
                                string data = pair.Value.ElementAt(dIndex);
                                if (string.IsNullOrWhiteSpace(data)) data = "";

                                para = body.AppendChild(new Paragraph());
                                run = para.AppendChild(new Run());
                                run.AppendChild(new Text(string.Format($"\n{data}")));
                            }


                        }

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        run.AppendChild(new Text(string.Format($" \n ")));
                    }

                    document.MainDocumentPart.Document = new Document(body);
                }

                WordSaveMaterialButton.Visible = !(UploadExcelMaterialButton.Visible = true);

            }
            else
            {
                ExcelDataPreviewMaterialMultiLineTextBox.Clear();
                WordSaveMaterialButton.Visible = !(UploadExcelMaterialButton.Visible = true);

                pictureBox1.Image = TabControlImageList.Images[0];
            }
        }

    }
}
