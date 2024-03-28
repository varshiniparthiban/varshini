namespace DMMKeySight
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
            this.mInfoLabel = new System.Windows.Forms.Label();
            this.mValueRichTextBox = new System.Windows.Forms.RichTextBox();
            this.mDCVoltageBtn = new System.Windows.Forms.Button();
            this.mACVoltageBtn = new System.Windows.Forms.Button();
            this.mOhmBtn = new System.Windows.Forms.Button();
            this.mDCCurrentBtn = new System.Windows.Forms.Button();
            this.mACCurrentBtn = new System.Windows.Forms.Button();
            this.mRangeDropdown = new System.Windows.Forms.ComboBox();
            this.mResolutionDropdown = new System.Windows.Forms.ComboBox();
            this.mOhmRangeDropdown = new System.Windows.Forms.ComboBox();
            this.mDCIRangeDropdown = new System.Windows.Forms.ComboBox();
            this.mContinuityBtn = new System.Windows.Forms.Button();
            this.mFrequencyBtn = new System.Windows.Forms.Button();
            this.mTemperatureBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mSampleIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.mSampleCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.mStartAcquisitionBtn = new System.Windows.Forms.Button();
            this.mDisplayBtn = new System.Windows.Forms.Button();
            this.mStopAcquisitionBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mSampleIntervalNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSampleCountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mInfoLabel
            // 
            this.mInfoLabel.AutoSize = true;
            this.mInfoLabel.Location = new System.Drawing.Point(12, 425);
            this.mInfoLabel.Name = "mInfoLabel";
            this.mInfoLabel.Size = new System.Drawing.Size(28, 16);
            this.mInfoLabel.TabIndex = 0;
            this.mInfoLabel.Text = "Info";
            // 
            // mValueRichTextBox
            // 
            this.mValueRichTextBox.Location = new System.Drawing.Point(26, 25);
            this.mValueRichTextBox.Name = "mValueRichTextBox";
            this.mValueRichTextBox.Size = new System.Drawing.Size(746, 89);
            this.mValueRichTextBox.TabIndex = 1;
            this.mValueRichTextBox.Text = "";
            // 
            // mDCVoltageBtn
            // 
            this.mDCVoltageBtn.Location = new System.Drawing.Point(26, 190);
            this.mDCVoltageBtn.Name = "mDCVoltageBtn";
            this.mDCVoltageBtn.Size = new System.Drawing.Size(75, 23);
            this.mDCVoltageBtn.TabIndex = 2;
            this.mDCVoltageBtn.Text = "DCV";
            this.mDCVoltageBtn.UseVisualStyleBackColor = true;
            this.mDCVoltageBtn.Click += new System.EventHandler(this.mDCVoltageBtn_Click);
            // 
            // mACVoltageBtn
            // 
            this.mACVoltageBtn.Location = new System.Drawing.Point(107, 190);
            this.mACVoltageBtn.Name = "mACVoltageBtn";
            this.mACVoltageBtn.Size = new System.Drawing.Size(75, 23);
            this.mACVoltageBtn.TabIndex = 3;
            this.mACVoltageBtn.Text = "ACV";
            this.mACVoltageBtn.UseVisualStyleBackColor = true;
            this.mACVoltageBtn.Click += new System.EventHandler(this.mACVoltageBtn_Click);
            // 
            // mOhmBtn
            // 
            this.mOhmBtn.Location = new System.Drawing.Point(188, 190);
            this.mOhmBtn.Name = "mOhmBtn";
            this.mOhmBtn.Size = new System.Drawing.Size(75, 23);
            this.mOhmBtn.TabIndex = 4;
            this.mOhmBtn.Text = "Ohm";
            this.mOhmBtn.UseVisualStyleBackColor = true;
            this.mOhmBtn.Click += new System.EventHandler(this.mOhmBtn_Click);
            // 
            // mDCCurrentBtn
            // 
            this.mDCCurrentBtn.Location = new System.Drawing.Point(269, 190);
            this.mDCCurrentBtn.Name = "mDCCurrentBtn";
            this.mDCCurrentBtn.Size = new System.Drawing.Size(75, 23);
            this.mDCCurrentBtn.TabIndex = 5;
            this.mDCCurrentBtn.Text = "DCI";
            this.mDCCurrentBtn.UseVisualStyleBackColor = true;
            this.mDCCurrentBtn.Click += new System.EventHandler(this.mDCCurrentBtn_Click);
            // 
            // mACCurrentBtn
            // 
            this.mACCurrentBtn.Location = new System.Drawing.Point(365, 190);
            this.mACCurrentBtn.Name = "mACCurrentBtn";
            this.mACCurrentBtn.Size = new System.Drawing.Size(75, 23);
            this.mACCurrentBtn.TabIndex = 6;
            this.mACCurrentBtn.Text = "ACI";
            this.mACCurrentBtn.UseVisualStyleBackColor = true;
            this.mACCurrentBtn.Click += new System.EventHandler(this.mACCurrentBtn_Click);
            // 
            // mRangeDropdown
            // 
            this.mRangeDropdown.FormattingEnabled = true;
            this.mRangeDropdown.Items.AddRange(new object[] {
            "0.1 V",
            "1 V",
            "10 V",
            "100 V",
            "750 V"});
            this.mRangeDropdown.Location = new System.Drawing.Point(27, 144);
            this.mRangeDropdown.Name = "mRangeDropdown";
            this.mRangeDropdown.Size = new System.Drawing.Size(121, 24);
            this.mRangeDropdown.TabIndex = 7;
            this.mRangeDropdown.Text = "Voltage Range";
            // 
            // mResolutionDropdown
            // 
            this.mResolutionDropdown.FormattingEnabled = true;
            this.mResolutionDropdown.Items.AddRange(new object[] {
            "SLOW",
            "MEDIUM",
            "FAST"});
            this.mResolutionDropdown.Location = new System.Drawing.Point(166, 144);
            this.mResolutionDropdown.Name = "mResolutionDropdown";
            this.mResolutionDropdown.Size = new System.Drawing.Size(138, 24);
            this.mResolutionDropdown.TabIndex = 8;
            this.mResolutionDropdown.Text = "Select Resolution";
            // 
            // mOhmRangeDropdown
            // 
            this.mOhmRangeDropdown.FormattingEnabled = true;
            this.mOhmRangeDropdown.Items.AddRange(new object[] {
            "100 Ω",
            "1 kΩ",
            "10 kΩ",
            "100 kΩ",
            "1 MΩ",
            "10 MΩ",
            "100 MΩ"});
            this.mOhmRangeDropdown.Location = new System.Drawing.Point(319, 144);
            this.mOhmRangeDropdown.Name = "mOhmRangeDropdown";
            this.mOhmRangeDropdown.Size = new System.Drawing.Size(121, 24);
            this.mOhmRangeDropdown.TabIndex = 9;
            this.mOhmRangeDropdown.Text = "Select ohm";
            // 
            // mDCIRangeDropdown
            // 
            this.mDCIRangeDropdown.FormattingEnabled = true;
            this.mDCIRangeDropdown.Items.AddRange(new object[] {
            "0.01 A",
            "0.1 A",
            "1 A",
            "3 A"});
            this.mDCIRangeDropdown.Location = new System.Drawing.Point(462, 144);
            this.mDCIRangeDropdown.Name = "mDCIRangeDropdown";
            this.mDCIRangeDropdown.Size = new System.Drawing.Size(121, 24);
            this.mDCIRangeDropdown.TabIndex = 10;
            this.mDCIRangeDropdown.Text = "Current Range";
            // 
            // mContinuityBtn
            // 
            this.mContinuityBtn.Location = new System.Drawing.Point(485, 190);
            this.mContinuityBtn.Name = "mContinuityBtn";
            this.mContinuityBtn.Size = new System.Drawing.Size(86, 23);
            this.mContinuityBtn.TabIndex = 11;
            this.mContinuityBtn.Text = "Continuity";
            this.mContinuityBtn.UseVisualStyleBackColor = true;
            this.mContinuityBtn.Click += new System.EventHandler(this.mContinuityBtn_Click);
            // 
            // mFrequencyBtn
            // 
            this.mFrequencyBtn.Location = new System.Drawing.Point(577, 190);
            this.mFrequencyBtn.Name = "mFrequencyBtn";
            this.mFrequencyBtn.Size = new System.Drawing.Size(88, 23);
            this.mFrequencyBtn.TabIndex = 12;
            this.mFrequencyBtn.Text = "Frequency";
            this.mFrequencyBtn.UseVisualStyleBackColor = true;
            this.mFrequencyBtn.Click += new System.EventHandler(this.mFrequencyBtn_Click);
            // 
            // mTemperatureBtn
            // 
            this.mTemperatureBtn.Location = new System.Drawing.Point(671, 190);
            this.mTemperatureBtn.Name = "mTemperatureBtn";
            this.mTemperatureBtn.Size = new System.Drawing.Size(101, 23);
            this.mTemperatureBtn.TabIndex = 13;
            this.mTemperatureBtn.Text = "Temperature";
            this.mTemperatureBtn.UseVisualStyleBackColor = true;
            this.mTemperatureBtn.Click += new System.EventHandler(this.mTemperatureBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Sample Interval";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Sample Count";
            // 
            // mSampleIntervalNumericUpDown
            // 
            this.mSampleIntervalNumericUpDown.Location = new System.Drawing.Point(175, 315);
            this.mSampleIntervalNumericUpDown.Name = "mSampleIntervalNumericUpDown";
            this.mSampleIntervalNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.mSampleIntervalNumericUpDown.TabIndex = 18;
            // 
            // mSampleCountNumericUpDown
            // 
            this.mSampleCountNumericUpDown.Location = new System.Drawing.Point(175, 257);
            this.mSampleCountNumericUpDown.Name = "mSampleCountNumericUpDown";
            this.mSampleCountNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.mSampleCountNumericUpDown.TabIndex = 16;
            this.mSampleCountNumericUpDown.ValueChanged += new System.EventHandler(this.mSampleCountNumericUpDown_ValueChanged);
            // 
            // mStartAcquisitionBtn
            // 
            this.mStartAcquisitionBtn.Location = new System.Drawing.Point(387, 249);
            this.mStartAcquisitionBtn.Name = "mStartAcquisitionBtn";
            this.mStartAcquisitionBtn.Size = new System.Drawing.Size(95, 60);
            this.mStartAcquisitionBtn.TabIndex = 23;
            this.mStartAcquisitionBtn.Text = "Start Acquisition";
            this.mStartAcquisitionBtn.UseVisualStyleBackColor = true;
            this.mStartAcquisitionBtn.Click += new System.EventHandler(this.mStartAcquisitionBtn_Click);
            // 
            // mDisplayBtn
            // 
            this.mDisplayBtn.Location = new System.Drawing.Point(652, 261);
            this.mDisplayBtn.Name = "mDisplayBtn";
            this.mDisplayBtn.Size = new System.Drawing.Size(75, 37);
            this.mDisplayBtn.TabIndex = 23;
            this.mDisplayBtn.Text = "Display";
            this.mDisplayBtn.UseVisualStyleBackColor = true;
            this.mDisplayBtn.Click += new System.EventHandler(this.mDisplayBtn_Click);
            // 
            // mStopAcquisitionBtn
            // 
            this.mStopAcquisitionBtn.Location = new System.Drawing.Point(512, 249);
            this.mStopAcquisitionBtn.Name = "mStopAcquisitionBtn";
            this.mStopAcquisitionBtn.Size = new System.Drawing.Size(95, 60);
            this.mStopAcquisitionBtn.TabIndex = 23;
            this.mStopAcquisitionBtn.Text = "Stop Acquisition";
            this.mStopAcquisitionBtn.UseVisualStyleBackColor = true;
            this.mStopAcquisitionBtn.Click += new System.EventHandler(this.mStopAcquisitionBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mDisplayBtn);
            this.Controls.Add(this.mStopAcquisitionBtn);
            this.Controls.Add(this.mStartAcquisitionBtn);
            this.Controls.Add(this.mTemperatureBtn);
            this.Controls.Add(this.mSampleIntervalNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mFrequencyBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mSampleCountNumericUpDown);
            this.Controls.Add(this.mContinuityBtn);
            this.Controls.Add(this.mDCIRangeDropdown);
            this.Controls.Add(this.mOhmRangeDropdown);
            this.Controls.Add(this.mResolutionDropdown);
            this.Controls.Add(this.mRangeDropdown);
            this.Controls.Add(this.mACCurrentBtn);
            this.Controls.Add(this.mDCCurrentBtn);
            this.Controls.Add(this.mOhmBtn);
            this.Controls.Add(this.mACVoltageBtn);
            this.Controls.Add(this.mDCVoltageBtn);
            this.Controls.Add(this.mValueRichTextBox);
            this.Controls.Add(this.mInfoLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mSampleIntervalNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSampleCountNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label mInfoLabel;
		private System.Windows.Forms.RichTextBox mValueRichTextBox;
		private System.Windows.Forms.Button mDCVoltageBtn;
		private System.Windows.Forms.Button mACVoltageBtn;
		private System.Windows.Forms.Button mOhmBtn;
		private System.Windows.Forms.Button mDCCurrentBtn;
		private System.Windows.Forms.Button mACCurrentBtn;
		private System.Windows.Forms.ComboBox mRangeDropdown;
		private System.Windows.Forms.ComboBox mResolutionDropdown;
		private System.Windows.Forms.ComboBox mOhmRangeDropdown;
		private System.Windows.Forms.ComboBox mDCIRangeDropdown;
		private System.Windows.Forms.Button mContinuityBtn;
		private System.Windows.Forms.Button mFrequencyBtn;
		private System.Windows.Forms.Button mTemperatureBtn;
		private System.Windows.Forms.NumericUpDown mSampleIntervalNumericUpDown;
		private System.Windows.Forms.NumericUpDown mSampleCountNumericUpDown;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button mStartAcquisitionBtn;
        private System.Windows.Forms.Button mDisplayBtn;
        private System.Windows.Forms.Button mStopAcquisitionBtn;
    }
}

