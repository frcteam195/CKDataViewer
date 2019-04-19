namespace CKDataViewer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.itemSelectionPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cmdClearChartItems = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdSaveImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemSelectionPanel
            // 
            this.itemSelectionPanel.AutoSize = true;
            this.itemSelectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemSelectionPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.itemSelectionPanel.Location = new System.Drawing.Point(0, 0);
            this.itemSelectionPanel.MinimumSize = new System.Drawing.Size(200, 200);
            this.itemSelectionPanel.Name = "itemSelectionPanel";
            this.itemSelectionPanel.Padding = new System.Windows.Forms.Padding(10);
            this.itemSelectionPanel.Size = new System.Drawing.Size(200, 853);
            this.itemSelectionPanel.TabIndex = 0;
            // 
            // dataChart
            // 
            this.dataChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataChart.Location = new System.Drawing.Point(0, 0);
            this.dataChart.Name = "dataChart";
            this.dataChart.Size = new System.Drawing.Size(1054, 953);
            this.dataChart.TabIndex = 1;
            this.dataChart.Text = "dataChart";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.cmdClearChartItems, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmdSaveImage, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 853);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // cmdClearChartItems
            // 
            this.cmdClearChartItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdClearChartItems.Location = new System.Drawing.Point(3, 3);
            this.cmdClearChartItems.Name = "cmdClearChartItems";
            this.cmdClearChartItems.Size = new System.Drawing.Size(94, 94);
            this.cmdClearChartItems.TabIndex = 1;
            this.cmdClearChartItems.Text = "Clear Items";
            this.cmdClearChartItems.UseVisualStyleBackColor = true;
            this.cmdClearChartItems.Click += new System.EventHandler(this.CmdClearChartItems_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.itemSelectionPanel);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 953);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataChart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1054, 953);
            this.panel2.TabIndex = 3;
            // 
            // cmdSaveImage
            // 
            this.cmdSaveImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdSaveImage.Location = new System.Drawing.Point(103, 3);
            this.cmdSaveImage.Name = "cmdSaveImage";
            this.cmdSaveImage.Size = new System.Drawing.Size(94, 94);
            this.cmdSaveImage.TabIndex = 2;
            this.cmdSaveImage.Text = "Save Image";
            this.cmdSaveImage.UseVisualStyleBackColor = true;
            this.cmdSaveImage.Click += new System.EventHandler(this.CmdSaveImage_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 953);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CKDataViewer";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel itemSelectionPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button cmdClearChartItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdSaveImage;
    }
}

