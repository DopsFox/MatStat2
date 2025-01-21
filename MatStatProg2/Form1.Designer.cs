namespace MatStatProg2
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.panelDelete = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonWork = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSaveData = new System.Windows.Forms.Button();
            this.panelSave = new System.Windows.Forms.Panel();
            this.textBoxXdata = new System.Windows.Forms.TextBox();
            this.textBoxYdata = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chartYhisto = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartXhisto = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.відкритиФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonHisto2 = new System.Windows.Forms.Button();
            this.buttonCorr = new System.Windows.Forms.Button();
            this.chartCorr = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartHisto2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartYhisto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartXhisto)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCorr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHisto2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1491, 683);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxData);
            this.tabPage1.Controls.Add(this.panelDelete);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panelSave);
            this.tabPage1.Controls.Add(this.textBoxXdata);
            this.tabPage1.Controls.Add(this.textBoxYdata);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.chartYhisto);
            this.tabPage1.Controls.Add(this.chartXhisto);
            this.tabPage1.Controls.Add(this.menuStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1483, 657);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "X та Y";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBoxData
            // 
            this.textBoxData.Location = new System.Drawing.Point(117, 157);
            this.textBoxData.Multiline = true;
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.Size = new System.Drawing.Size(288, 230);
            this.textBoxData.TabIndex = 10;
            // 
            // panelDelete
            // 
            this.panelDelete.Location = new System.Drawing.Point(7, 214);
            this.panelDelete.Name = "panelDelete";
            this.panelDelete.Size = new System.Drawing.Size(104, 177);
            this.panelDelete.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonWork);
            this.panel2.Controls.Add(this.buttonDelete);
            this.panel2.Controls.Add(this.buttonSaveData);
            this.panel2.Location = new System.Drawing.Point(117, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 120);
            this.panel2.TabIndex = 8;
            // 
            // buttonWork
            // 
            this.buttonWork.Location = new System.Drawing.Point(4, 63);
            this.buttonWork.Name = "buttonWork";
            this.buttonWork.Size = new System.Drawing.Size(75, 23);
            this.buttonWork.TabIndex = 9;
            this.buttonWork.Text = "Робота ";
            this.buttonWork.UseVisualStyleBackColor = true;
            this.buttonWork.Click += new System.EventHandler(this.buttonWork_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(4, 33);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Видалити";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSaveData
            // 
            this.buttonSaveData.Location = new System.Drawing.Point(3, 3);
            this.buttonSaveData.Name = "buttonSaveData";
            this.buttonSaveData.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveData.TabIndex = 7;
            this.buttonSaveData.Text = "Зберегти ";
            this.buttonSaveData.UseVisualStyleBackColor = true;
            this.buttonSaveData.Click += new System.EventHandler(this.buttonSaveData_Click);
            // 
            // panelSave
            // 
            this.panelSave.Location = new System.Drawing.Point(7, 31);
            this.panelSave.Name = "panelSave";
            this.panelSave.Size = new System.Drawing.Size(104, 177);
            this.panelSave.TabIndex = 6;
            // 
            // textBoxXdata
            // 
            this.textBoxXdata.Location = new System.Drawing.Point(411, 32);
            this.textBoxXdata.Multiline = true;
            this.textBoxXdata.Name = "textBoxXdata";
            this.textBoxXdata.Size = new System.Drawing.Size(231, 356);
            this.textBoxXdata.TabIndex = 5;
            // 
            // textBoxYdata
            // 
            this.textBoxYdata.Location = new System.Drawing.Point(648, 31);
            this.textBoxYdata.Multiline = true;
            this.textBoxYdata.Name = "textBoxYdata";
            this.textBoxYdata.Size = new System.Drawing.Size(224, 356);
            this.textBoxYdata.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 405);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(865, 246);
            this.dataGridView1.TabIndex = 3;
            // 
            // chartYhisto
            // 
            chartArea7.Name = "ChartArea1";
            this.chartYhisto.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chartYhisto.Legends.Add(legend7);
            this.chartYhisto.Location = new System.Drawing.Point(895, 367);
            this.chartYhisto.Name = "chartYhisto";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chartYhisto.Series.Add(series7);
            this.chartYhisto.Size = new System.Drawing.Size(582, 281);
            this.chartYhisto.TabIndex = 2;
            this.chartYhisto.Text = "chart2";
            // 
            // chartXhisto
            // 
            chartArea8.Name = "ChartArea1";
            this.chartXhisto.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chartXhisto.Legends.Add(legend8);
            this.chartXhisto.Location = new System.Drawing.Point(895, 30);
            this.chartXhisto.Name = "chartXhisto";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chartXhisto.Series.Add(series8);
            this.chartXhisto.Size = new System.Drawing.Size(582, 331);
            this.chartXhisto.TabIndex = 1;
            this.chartXhisto.Text = "chart1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.відкритиФайлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1477, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // відкритиФайлToolStripMenuItem
            // 
            this.відкритиФайлToolStripMenuItem.Name = "відкритиФайлToolStripMenuItem";
            this.відкритиФайлToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.відкритиФайлToolStripMenuItem.Text = "Відкрити файл";
            this.відкритиФайлToolStripMenuItem.Click += new System.EventHandler(this.відкритиФайлToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chartHisto2);
            this.tabPage2.Controls.Add(this.chartCorr);
            this.tabPage2.Controls.Add(this.buttonCorr);
            this.tabPage2.Controls.Add(this.buttonHisto2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1483, 657);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Кореляція";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonHisto2
            // 
            this.buttonHisto2.Location = new System.Drawing.Point(18, 7);
            this.buttonHisto2.Name = "buttonHisto2";
            this.buttonHisto2.Size = new System.Drawing.Size(75, 23);
            this.buttonHisto2.TabIndex = 0;
            this.buttonHisto2.Text = "Histo2";
            this.buttonHisto2.UseVisualStyleBackColor = true;
            this.buttonHisto2.Click += new System.EventHandler(this.buttonHisto2_Click);
            // 
            // buttonCorr
            // 
            this.buttonCorr.Location = new System.Drawing.Point(18, 37);
            this.buttonCorr.Name = "buttonCorr";
            this.buttonCorr.Size = new System.Drawing.Size(75, 23);
            this.buttonCorr.TabIndex = 1;
            this.buttonCorr.Text = "Corr";
            this.buttonCorr.UseVisualStyleBackColor = true;
            this.buttonCorr.Click += new System.EventHandler(this.buttonCorr_Click);
            // 
            // chartCorr
            // 
            chartArea6.Name = "ChartArea1";
            this.chartCorr.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartCorr.Legends.Add(legend6);
            this.chartCorr.Location = new System.Drawing.Point(1005, 7);
            this.chartCorr.Name = "chartCorr";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartCorr.Series.Add(series6);
            this.chartCorr.Size = new System.Drawing.Size(472, 439);
            this.chartCorr.TabIndex = 2;
            this.chartCorr.Text = "chart1";
            // 
            // chartHisto2
            // 
            chartArea5.Name = "ChartArea1";
            this.chartHisto2.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartHisto2.Legends.Add(legend5);
            this.chartHisto2.Location = new System.Drawing.Point(527, 7);
            this.chartHisto2.Name = "chartHisto2";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartHisto2.Series.Add(series5);
            this.chartHisto2.Size = new System.Drawing.Size(472, 439);
            this.chartHisto2.TabIndex = 3;
            this.chartHisto2.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1508, 699);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartYhisto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartXhisto)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCorr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHisto2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBoxYdata;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartYhisto;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartXhisto;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem відкритиФайлToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxXdata;
        private System.Windows.Forms.Button buttonSaveData;
        private System.Windows.Forms.Panel panelSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelDelete;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.Button buttonWork;
        private System.Windows.Forms.Button buttonCorr;
        private System.Windows.Forms.Button buttonHisto2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHisto2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCorr;
    }
}

