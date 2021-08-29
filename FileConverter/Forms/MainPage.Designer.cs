
namespace FileConverter.Forms
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.ExcelDataPreviewMaterialMultiLineTextBox = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.TabControlImageList = new System.Windows.Forms.ImageList(this.components);
            this.UploadExcelOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UploadExcelMaterialButton = new MaterialSkin.Controls.MaterialButton();
            this.WordSaveMaterialButton = new MaterialSkin.Controls.MaterialButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ExcelDataPreviewMaterialMultiLineTextBox
            // 
            this.ExcelDataPreviewMaterialMultiLineTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ExcelDataPreviewMaterialMultiLineTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ExcelDataPreviewMaterialMultiLineTextBox.Depth = 0;
            this.ExcelDataPreviewMaterialMultiLineTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExcelDataPreviewMaterialMultiLineTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ExcelDataPreviewMaterialMultiLineTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ExcelDataPreviewMaterialMultiLineTextBox.Location = new System.Drawing.Point(191, 64);
            this.ExcelDataPreviewMaterialMultiLineTextBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.ExcelDataPreviewMaterialMultiLineTextBox.Name = "ExcelDataPreviewMaterialMultiLineTextBox";
            this.ExcelDataPreviewMaterialMultiLineTextBox.ReadOnly = true;
            this.ExcelDataPreviewMaterialMultiLineTextBox.Size = new System.Drawing.Size(939, 597);
            this.ExcelDataPreviewMaterialMultiLineTextBox.TabIndex = 1;
            this.ExcelDataPreviewMaterialMultiLineTextBox.Text = "";
            // 
            // TabControlImageList
            // 
            this.TabControlImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TabControlImageList.ImageStream")));
            this.TabControlImageList.TransparentColor = System.Drawing.Color.White;
            this.TabControlImageList.Images.SetKeyName(0, "noFile.png");
            this.TabControlImageList.Images.SetKeyName(1, "excelIcon.png");
            // 
            // UploadExcelOpenFileDialog
            // 
            this.UploadExcelOpenFileDialog.DefaultExt = "xlsx";
            this.UploadExcelOpenFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            this.UploadExcelOpenFileDialog.RestoreDirectory = true;
            this.UploadExcelOpenFileDialog.Title = "Excel Dosyasını Seçiniz";
            this.UploadExcelOpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.UploadExcelOpenFileDialog_FileOk);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.UploadExcelMaterialButton);
            this.groupBox1.Controls.Add(this.WordSaveMaterialButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 64);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.groupBox1.Size = new System.Drawing.Size(188, 597);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // UploadExcelMaterialButton
            // 
            this.UploadExcelMaterialButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.UploadExcelMaterialButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.UploadExcelMaterialButton.Depth = 0;
            this.UploadExcelMaterialButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.UploadExcelMaterialButton.HighEmphasis = true;
            this.UploadExcelMaterialButton.Icon = null;
            this.UploadExcelMaterialButton.Location = new System.Drawing.Point(0, 75);
            this.UploadExcelMaterialButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.UploadExcelMaterialButton.MinimumSize = new System.Drawing.Size(100, 60);
            this.UploadExcelMaterialButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.UploadExcelMaterialButton.Name = "UploadExcelMaterialButton";
            this.UploadExcelMaterialButton.Size = new System.Drawing.Size(188, 60);
            this.UploadExcelMaterialButton.TabIndex = 1;
            this.UploadExcelMaterialButton.Text = "Excel Yükle";
            this.UploadExcelMaterialButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.UploadExcelMaterialButton.UseAccentColor = false;
            this.UploadExcelMaterialButton.UseVisualStyleBackColor = true;
            this.UploadExcelMaterialButton.Click += new System.EventHandler(this.UploadExcelMaterialButton_Click);
            // 
            // WordSaveMaterialButton
            // 
            this.WordSaveMaterialButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.WordSaveMaterialButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.WordSaveMaterialButton.Depth = 0;
            this.WordSaveMaterialButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.WordSaveMaterialButton.HighEmphasis = true;
            this.WordSaveMaterialButton.Icon = null;
            this.WordSaveMaterialButton.Location = new System.Drawing.Point(0, 15);
            this.WordSaveMaterialButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.WordSaveMaterialButton.MinimumSize = new System.Drawing.Size(100, 60);
            this.WordSaveMaterialButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.WordSaveMaterialButton.Name = "WordSaveMaterialButton";
            this.WordSaveMaterialButton.Size = new System.Drawing.Size(188, 60);
            this.WordSaveMaterialButton.TabIndex = 2;
            this.WordSaveMaterialButton.Text = "Dönüştür";
            this.WordSaveMaterialButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.WordSaveMaterialButton.UseAccentColor = false;
            this.WordSaveMaterialButton.UseVisualStyleBackColor = false;
            this.WordSaveMaterialButton.Visible = false;
            this.WordSaveMaterialButton.Click += new System.EventHandler(this.WordSaveMaterialButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::FileConverter.Properties.Resources.noFile;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(40, 253);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(100, 100);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(100, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1133, 664);
            this.Controls.Add(this.ExcelDataPreviewMaterialMultiLineTextBox);
            this.Controls.Add(this.groupBox1);
            this.DrawerUseColors = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPage";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Excel - Word Dönüştürücü";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList TabControlImageList;
        private System.Windows.Forms.OpenFileDialog UploadExcelOpenFileDialog;
        private MaterialSkin.Controls.MaterialMultiLineTextBox ExcelDataPreviewMaterialMultiLineTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialButton UploadExcelMaterialButton;
        private MaterialSkin.Controls.MaterialButton WordSaveMaterialButton;
    }
}