namespace CKPIDTuner
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.cmdClearIAccum = new System.Windows.Forms.Button();
            this.cmdApply = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.numSetpoint = new System.Windows.Forms.NumericUpDown();
            this.numMaxIAccum = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numIZone = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numRamp = new System.Windows.Forms.NumericUpDown();
            this.txtIAccum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAverageDev = new System.Windows.Forms.TextBox();
            this.numVel = new System.Windows.Forms.NumericUpDown();
            this.txtDeviation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtActualVal = new System.Windows.Forms.TextBox();
            this.numAccel = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSysName = new System.Windows.Forms.TextBox();
            this.txtDesiredVal = new System.Windows.Forms.TextBox();
            this.numkF = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numkD = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numkI = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numkP = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSetpoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxIAccum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRamp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numkF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numkD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numkI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numkP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdConnect);
            this.groupBox1.Controls.Add(this.cmdClearIAccum);
            this.groupBox1.Controls.Add(this.cmdApply);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.numSetpoint);
            this.groupBox1.Controls.Add(this.numMaxIAccum);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.numIZone);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.numRamp);
            this.groupBox1.Controls.Add(this.txtIAccum);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtAverageDev);
            this.groupBox1.Controls.Add(this.numVel);
            this.groupBox1.Controls.Add(this.txtDeviation);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtActualVal);
            this.groupBox1.Controls.Add(this.numAccel);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSysName);
            this.groupBox1.Controls.Add(this.txtDesiredVal);
            this.groupBox1.Controls.Add(this.numkF);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numkD);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numkI);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numkP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(168, 625);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gain Tuning";
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(6, 588);
            this.cmdConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(159, 31);
            this.cmdConnect.TabIndex = 18;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // cmdClearIAccum
            // 
            this.cmdClearIAccum.Location = new System.Drawing.Point(6, 428);
            this.cmdClearIAccum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdClearIAccum.Name = "cmdClearIAccum";
            this.cmdClearIAccum.Size = new System.Drawing.Size(159, 31);
            this.cmdClearIAccum.TabIndex = 17;
            this.cmdClearIAccum.Text = "Clear I Accumulator";
            this.cmdClearIAccum.UseVisualStyleBackColor = true;
            this.cmdClearIAccum.Click += new System.EventHandler(this.cmdClearIAccum_Click);
            // 
            // cmdApply
            // 
            this.cmdApply.Location = new System.Drawing.Point(6, 228);
            this.cmdApply.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(159, 31);
            this.cmdApply.TabIndex = 10;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 393);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "I Accumulator:";
            // 
            // numSetpoint
            // 
            this.numSetpoint.DecimalPlaces = 6;
            this.numSetpoint.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numSetpoint.Location = new System.Drawing.Point(86, 196);
            this.numSetpoint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numSetpoint.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.numSetpoint.Minimum = new decimal(new int[] {
            276447232,
            23283,
            0,
            -2147483648});
            this.numSetpoint.Name = "numSetpoint";
            this.numSetpoint.Size = new System.Drawing.Size(78, 20);
            this.numSetpoint.TabIndex = 9;
            this.numSetpoint.ValueChanged += new System.EventHandler(this.numSetpoint_ValueChanged);
            // 
            // numMaxIAccum
            // 
            this.numMaxIAccum.DecimalPlaces = 6;
            this.numMaxIAccum.Location = new System.Drawing.Point(86, 176);
            this.numMaxIAccum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numMaxIAccum.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.numMaxIAccum.Name = "numMaxIAccum";
            this.numMaxIAccum.Size = new System.Drawing.Size(78, 20);
            this.numMaxIAccum.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 373);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Average Dev:";
            // 
            // numIZone
            // 
            this.numIZone.DecimalPlaces = 6;
            this.numIZone.Location = new System.Drawing.Point(86, 157);
            this.numIZone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numIZone.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.numIZone.Name = "numIZone";
            this.numIZone.Size = new System.Drawing.Size(78, 20);
            this.numIZone.TabIndex = 7;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 197);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Setpoint:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 354);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Deviation:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 177);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Max I Accum:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 335);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Actual Value:";
            // 
            // numRamp
            // 
            this.numRamp.DecimalPlaces = 6;
            this.numRamp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numRamp.Location = new System.Drawing.Point(86, 138);
            this.numRamp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numRamp.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.numRamp.Name = "numRamp";
            this.numRamp.Size = new System.Drawing.Size(78, 20);
            this.numRamp.TabIndex = 6;
            // 
            // txtIAccum
            // 
            this.txtIAccum.Location = new System.Drawing.Point(82, 391);
            this.txtIAccum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIAccum.Name = "txtIAccum";
            this.txtIAccum.ReadOnly = true;
            this.txtIAccum.Size = new System.Drawing.Size(85, 20);
            this.txtIAccum.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 158);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "I Zone:";
            // 
            // txtAverageDev
            // 
            this.txtAverageDev.Location = new System.Drawing.Point(82, 372);
            this.txtAverageDev.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAverageDev.Name = "txtAverageDev";
            this.txtAverageDev.ReadOnly = true;
            this.txtAverageDev.Size = new System.Drawing.Size(85, 20);
            this.txtAverageDev.TabIndex = 15;
            // 
            // numVel
            // 
            this.numVel.DecimalPlaces = 6;
            this.numVel.Location = new System.Drawing.Point(86, 119);
            this.numVel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numVel.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.numVel.Name = "numVel";
            this.numVel.Size = new System.Drawing.Size(78, 20);
            this.numVel.TabIndex = 5;
            // 
            // txtDeviation
            // 
            this.txtDeviation.Location = new System.Drawing.Point(82, 353);
            this.txtDeviation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDeviation.Name = "txtDeviation";
            this.txtDeviation.ReadOnly = true;
            this.txtDeviation.Size = new System.Drawing.Size(85, 20);
            this.txtDeviation.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 139);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ramp Rate:";
            // 
            // txtActualVal
            // 
            this.txtActualVal.Location = new System.Drawing.Point(82, 333);
            this.txtActualVal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtActualVal.Name = "txtActualVal";
            this.txtActualVal.ReadOnly = true;
            this.txtActualVal.Size = new System.Drawing.Size(85, 20);
            this.txtActualVal.TabIndex = 13;
            // 
            // numAccel
            // 
            this.numAccel.DecimalPlaces = 6;
            this.numAccel.Location = new System.Drawing.Point(86, 99);
            this.numAccel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numAccel.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.numAccel.Name = "numAccel";
            this.numAccel.Size = new System.Drawing.Size(78, 20);
            this.numAccel.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 296);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "System Name:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 316);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Desired Value:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 120);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cruise Velocity:";
            // 
            // txtSysName
            // 
            this.txtSysName.Location = new System.Drawing.Point(82, 295);
            this.txtSysName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSysName.Name = "txtSysName";
            this.txtSysName.ReadOnly = true;
            this.txtSysName.Size = new System.Drawing.Size(85, 20);
            this.txtSysName.TabIndex = 11;
            // 
            // txtDesiredVal
            // 
            this.txtDesiredVal.Location = new System.Drawing.Point(82, 314);
            this.txtDesiredVal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDesiredVal.Name = "txtDesiredVal";
            this.txtDesiredVal.ReadOnly = true;
            this.txtDesiredVal.Size = new System.Drawing.Size(85, 20);
            this.txtDesiredVal.TabIndex = 12;
            // 
            // numkF
            // 
            this.numkF.DecimalPlaces = 6;
            this.numkF.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numkF.Location = new System.Drawing.Point(86, 80);
            this.numkF.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numkF.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.numkF.Name = "numkF";
            this.numkF.Size = new System.Drawing.Size(78, 20);
            this.numkF.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Acceleration:";
            // 
            // numkD
            // 
            this.numkD.DecimalPlaces = 6;
            this.numkD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numkD.Location = new System.Drawing.Point(86, 61);
            this.numkD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numkD.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.numkD.Name = "numkD";
            this.numkD.Size = new System.Drawing.Size(78, 20);
            this.numkD.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "F Gain:";
            // 
            // numkI
            // 
            this.numkI.DecimalPlaces = 6;
            this.numkI.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numkI.Location = new System.Drawing.Point(86, 42);
            this.numkI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numkI.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.numkI.Name = "numkI";
            this.numkI.Size = new System.Drawing.Size(78, 20);
            this.numkI.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "D Gain:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "I Gain:";
            // 
            // numkP
            // 
            this.numkP.DecimalPlaces = 6;
            this.numkP.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numkP.Location = new System.Drawing.Point(86, 22);
            this.numkP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numkP.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.numkP.Name = "numkP";
            this.numkP.Size = new System.Drawing.Size(78, 20);
            this.numkP.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "P Gain:";
            // 
            // dataChart
            // 
            chartArea1.Name = "ChartArea1";
            this.dataChart.ChartAreas.Add(chartArea1);
            this.dataChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.dataChart.Legends.Add(legend1);
            this.dataChart.Location = new System.Drawing.Point(168, 0);
            this.dataChart.Name = "dataChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.dataChart.Series.Add(series1);
            this.dataChart.Size = new System.Drawing.Size(1061, 625);
            this.dataChart.TabIndex = 2;
            this.dataChart.Text = "chart1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 625);
            this.Controls.Add(this.dataChart);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PID Tuner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSetpoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxIAccum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRamp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numkF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numkD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numkI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numkP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numkP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numkI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numkD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numMaxIAccum;
        private System.Windows.Forms.NumericUpDown numIZone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numRamp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numVel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numAccel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numkF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDesiredVal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAverageDev;
        private System.Windows.Forms.TextBox txtDeviation;
        private System.Windows.Forms.TextBox txtActualVal;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtIAccum;
        private System.Windows.Forms.Button cmdClearIAccum;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSysName;
        private System.Windows.Forms.NumericUpDown numSetpoint;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
    }
}

