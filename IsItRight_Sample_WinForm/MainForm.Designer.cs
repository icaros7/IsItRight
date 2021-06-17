
namespace IsItRight_Sample_WinForm
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.apiTextBox = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.authBtn = new System.Windows.Forms.Button();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.allRadio = new System.Windows.Forms.RadioButton();
            this.femaleRadio = new System.Windows.Forms.RadioButton();
            this.maleRadio = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.age13 = new System.Windows.Forms.CheckBox();
            this.age12 = new System.Windows.Forms.CheckBox();
            this.age11 = new System.Windows.Forms.CheckBox();
            this.age10 = new System.Windows.Forms.CheckBox();
            this.age9 = new System.Windows.Forms.CheckBox();
            this.age8 = new System.Windows.Forms.CheckBox();
            this.age7 = new System.Windows.Forms.CheckBox();
            this.age6 = new System.Windows.Forms.CheckBox();
            this.age5 = new System.Windows.Forms.CheckBox();
            this.age4 = new System.Windows.Forms.CheckBox();
            this.age3 = new System.Windows.Forms.CheckBox();
            this.age2 = new System.Windows.Forms.CheckBox();
            this.age1 = new System.Windows.Forms.CheckBox();
            this.age0 = new System.Windows.Forms.CheckBox();
            this.dateF = new System.Windows.Forms.DateTimePicker();
            this.dateT = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timeT = new System.Windows.Forms.ComboBox();
            this.timeF = new System.Windows.Forms.ComboBox();
            this.pivotChart = new System.Windows.Forms.CheckBox();
            this.dataExportBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // apiTextBox
            // 
            this.apiTextBox.Location = new System.Drawing.Point(12, 12);
            this.apiTextBox.Name = "apiTextBox";
            this.apiTextBox.PlaceholderText = "열린데이터 광장 API키";
            this.apiTextBox.Size = new System.Drawing.Size(167, 23);
            this.apiTextBox.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(304, 15);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(88, 15);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "API키 발급하기";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // authBtn
            // 
            this.authBtn.Location = new System.Drawing.Point(186, 12);
            this.authBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.authBtn.Name = "authBtn";
            this.authBtn.Size = new System.Drawing.Size(101, 41);
            this.authBtn.TabIndex = 3;
            this.authBtn.Text = "API 키 확인";
            this.authBtn.UseVisualStyleBackColor = true;
            this.authBtn.Click += new System.EventHandler(this.authBtn_Click);
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(12, 35);
            this.locationTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.PlaceholderText = "행정동 코드: 기본값 명동";
            this.locationTextBox.Size = new System.Drawing.Size(167, 23);
            this.locationTextBox.TabIndex = 2;
            this.locationTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.locationTextBox_KeyPress);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(292, 36);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(97, 15);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "행정동 코드 확인";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.allRadio);
            this.groupBox1.Controls.Add(this.femaleRadio);
            this.groupBox1.Controls.Add(this.maleRadio);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(187, 178);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Size = new System.Drawing.Size(209, 42);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "성별";
            // 
            // allRadio
            // 
            this.allRadio.AutoSize = true;
            this.allRadio.Location = new System.Drawing.Point(77, 18);
            this.allRadio.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.allRadio.Name = "allRadio";
            this.allRadio.Size = new System.Drawing.Size(49, 19);
            this.allRadio.TabIndex = 2;
            this.allRadio.TabStop = true;
            this.allRadio.Text = "모두";
            this.allRadio.UseVisualStyleBackColor = true;
            this.allRadio.CheckedChanged += new System.EventHandler(this.allRadio_CheckedChanged);
            // 
            // femaleRadio
            // 
            this.femaleRadio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.femaleRadio.AutoSize = true;
            this.femaleRadio.Location = new System.Drawing.Point(156, 18);
            this.femaleRadio.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.femaleRadio.Name = "femaleRadio";
            this.femaleRadio.Size = new System.Drawing.Size(49, 19);
            this.femaleRadio.TabIndex = 1;
            this.femaleRadio.Text = "여성";
            this.femaleRadio.UseVisualStyleBackColor = true;
            this.femaleRadio.CheckedChanged += new System.EventHandler(this.femaleRadio_CheckedChanged);
            // 
            // maleRadio
            // 
            this.maleRadio.AutoSize = true;
            this.maleRadio.Checked = true;
            this.maleRadio.Location = new System.Drawing.Point(4, 18);
            this.maleRadio.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.maleRadio.Name = "maleRadio";
            this.maleRadio.Size = new System.Drawing.Size(49, 19);
            this.maleRadio.TabIndex = 0;
            this.maleRadio.TabStop = true;
            this.maleRadio.Text = "남성";
            this.maleRadio.UseVisualStyleBackColor = true;
            this.maleRadio.CheckedChanged += new System.EventHandler(this.maleRadio_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.age13);
            this.groupBox2.Controls.Add(this.age12);
            this.groupBox2.Controls.Add(this.age11);
            this.groupBox2.Controls.Add(this.age10);
            this.groupBox2.Controls.Add(this.age9);
            this.groupBox2.Controls.Add(this.age8);
            this.groupBox2.Controls.Add(this.age7);
            this.groupBox2.Controls.Add(this.age6);
            this.groupBox2.Controls.Add(this.age5);
            this.groupBox2.Controls.Add(this.age4);
            this.groupBox2.Controls.Add(this.age3);
            this.groupBox2.Controls.Add(this.age2);
            this.groupBox2.Controls.Add(this.age1);
            this.groupBox2.Controls.Add(this.age0);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(12, 61);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox2.Size = new System.Drawing.Size(165, 159);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "검색 나이대";
            // 
            // age13
            // 
            this.age13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.age13.AutoSize = true;
            this.age13.Location = new System.Drawing.Point(93, 136);
            this.age13.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.age13.Name = "age13";
            this.age13.Size = new System.Drawing.Size(65, 19);
            this.age13.TabIndex = 13;
            this.age13.Text = "70 이상";
            this.age13.UseVisualStyleBackColor = true;
            this.age13.CheckedChanged += new System.EventHandler(this.age13_CheckedChanged);
            // 
            // age12
            // 
            this.age12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.age12.AutoSize = true;
            this.age12.Location = new System.Drawing.Point(94, 117);
            this.age12.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.age12.Name = "age12";
            this.age12.Size = new System.Drawing.Size(64, 19);
            this.age12.TabIndex = 12;
            this.age12.Text = "65 ~ 69";
            this.age12.UseVisualStyleBackColor = true;
            this.age12.CheckedChanged += new System.EventHandler(this.age12_CheckedChanged);
            // 
            // age11
            // 
            this.age11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.age11.AutoSize = true;
            this.age11.Location = new System.Drawing.Point(94, 97);
            this.age11.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.age11.Name = "age11";
            this.age11.Size = new System.Drawing.Size(64, 19);
            this.age11.TabIndex = 11;
            this.age11.Text = "60 ~ 64";
            this.age11.UseVisualStyleBackColor = true;
            this.age11.CheckedChanged += new System.EventHandler(this.age11_CheckedChanged);
            // 
            // age10
            // 
            this.age10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.age10.AutoSize = true;
            this.age10.Location = new System.Drawing.Point(94, 77);
            this.age10.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.age10.Name = "age10";
            this.age10.Size = new System.Drawing.Size(64, 19);
            this.age10.TabIndex = 10;
            this.age10.Text = "55 ~ 59";
            this.age10.UseVisualStyleBackColor = true;
            this.age10.CheckedChanged += new System.EventHandler(this.age10_CheckedChanged);
            // 
            // age9
            // 
            this.age9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.age9.AutoSize = true;
            this.age9.Location = new System.Drawing.Point(94, 58);
            this.age9.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.age9.Name = "age9";
            this.age9.Size = new System.Drawing.Size(64, 19);
            this.age9.TabIndex = 9;
            this.age9.Text = "50 ~ 54";
            this.age9.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.age9.UseVisualStyleBackColor = true;
            this.age9.CheckedChanged += new System.EventHandler(this.age9_CheckedChanged);
            // 
            // age8
            // 
            this.age8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.age8.AutoSize = true;
            this.age8.Location = new System.Drawing.Point(94, 38);
            this.age8.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.age8.Name = "age8";
            this.age8.Size = new System.Drawing.Size(64, 19);
            this.age8.TabIndex = 8;
            this.age8.Text = "45 ~ 49";
            this.age8.UseVisualStyleBackColor = true;
            this.age8.CheckedChanged += new System.EventHandler(this.age8_CheckedChanged);
            // 
            // age7
            // 
            this.age7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.age7.AutoSize = true;
            this.age7.Location = new System.Drawing.Point(94, 18);
            this.age7.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.age7.Name = "age7";
            this.age7.Size = new System.Drawing.Size(64, 19);
            this.age7.TabIndex = 7;
            this.age7.Text = "40 ~ 44";
            this.age7.UseVisualStyleBackColor = true;
            this.age7.CheckedChanged += new System.EventHandler(this.age7_CheckedChanged);
            // 
            // age6
            // 
            this.age6.AutoSize = true;
            this.age6.Location = new System.Drawing.Point(4, 136);
            this.age6.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.age6.Name = "age6";
            this.age6.Size = new System.Drawing.Size(64, 19);
            this.age6.TabIndex = 6;
            this.age6.Text = "35 ~ 39";
            this.age6.UseVisualStyleBackColor = true;
            this.age6.CheckedChanged += new System.EventHandler(this.age6_CheckedChanged);
            // 
            // age5
            // 
            this.age5.AutoSize = true;
            this.age5.Location = new System.Drawing.Point(4, 117);
            this.age5.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.age5.Name = "age5";
            this.age5.Size = new System.Drawing.Size(64, 19);
            this.age5.TabIndex = 5;
            this.age5.Text = "30 ~ 34";
            this.age5.UseVisualStyleBackColor = true;
            this.age5.CheckedChanged += new System.EventHandler(this.age5_CheckedChanged);
            // 
            // age4
            // 
            this.age4.AutoSize = true;
            this.age4.Location = new System.Drawing.Point(4, 97);
            this.age4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.age4.Name = "age4";
            this.age4.Size = new System.Drawing.Size(64, 19);
            this.age4.TabIndex = 4;
            this.age4.Text = "25 ~ 29";
            this.age4.UseVisualStyleBackColor = true;
            this.age4.CheckedChanged += new System.EventHandler(this.age4_CheckedChanged);
            // 
            // age3
            // 
            this.age3.AutoSize = true;
            this.age3.Location = new System.Drawing.Point(4, 77);
            this.age3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.age3.Name = "age3";
            this.age3.Size = new System.Drawing.Size(64, 19);
            this.age3.TabIndex = 3;
            this.age3.Text = "20 ~ 24";
            this.age3.UseVisualStyleBackColor = true;
            this.age3.CheckedChanged += new System.EventHandler(this.age3_CheckedChanged);
            // 
            // age2
            // 
            this.age2.AutoSize = true;
            this.age2.Location = new System.Drawing.Point(4, 58);
            this.age2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.age2.Name = "age2";
            this.age2.Size = new System.Drawing.Size(64, 19);
            this.age2.TabIndex = 2;
            this.age2.Text = "15 ~ 19";
            this.age2.UseVisualStyleBackColor = true;
            this.age2.CheckedChanged += new System.EventHandler(this.age2_CheckedChanged);
            // 
            // age1
            // 
            this.age1.AutoSize = true;
            this.age1.Location = new System.Drawing.Point(4, 38);
            this.age1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.age1.Name = "age1";
            this.age1.Size = new System.Drawing.Size(64, 19);
            this.age1.TabIndex = 1;
            this.age1.Text = "10 ~ 14";
            this.age1.UseVisualStyleBackColor = true;
            this.age1.CheckedChanged += new System.EventHandler(this.age1_CheckedChanged);
            // 
            // age0
            // 
            this.age0.AutoSize = true;
            this.age0.Location = new System.Drawing.Point(4, 18);
            this.age0.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.age0.Name = "age0";
            this.age0.Size = new System.Drawing.Size(52, 19);
            this.age0.TabIndex = 0;
            this.age0.Text = "0 ~ 9";
            this.age0.UseVisualStyleBackColor = true;
            this.age0.CheckedChanged += new System.EventHandler(this.age0_CheckedChanged);
            // 
            // dateF
            // 
            this.dateF.Location = new System.Drawing.Point(40, 18);
            this.dateF.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dateF.Name = "dateF";
            this.dateF.Size = new System.Drawing.Size(168, 23);
            this.dateF.TabIndex = 9;
            this.dateF.ValueChanged += new System.EventHandler(this.dateF_ValueChanged);
            // 
            // dateT
            // 
            this.dateT.Location = new System.Drawing.Point(40, 39);
            this.dateT.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dateT.Name = "dateT";
            this.dateT.Size = new System.Drawing.Size(168, 23);
            this.dateT.TabIndex = 10;
            this.dateT.ValueChanged += new System.EventHandler(this.dateT_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dateT);
            this.groupBox3.Controls.Add(this.dateF);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(187, 61);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox3.Size = new System.Drawing.Size(209, 65);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "날짜";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "종료:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "시작:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.timeT);
            this.groupBox4.Controls.Add(this.timeF);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(187, 129);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox4.Size = new System.Drawing.Size(209, 46);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "시간대";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "~";
            // 
            // timeT
            // 
            this.timeT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeT.FormattingEnabled = true;
            this.timeT.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.timeT.Location = new System.Drawing.Point(132, 18);
            this.timeT.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.timeT.Name = "timeT";
            this.timeT.Size = new System.Drawing.Size(76, 23);
            this.timeT.TabIndex = 1;
            this.timeT.SelectedIndexChanged += new System.EventHandler(this.timeT_SelectedIndexChanged);
            // 
            // timeF
            // 
            this.timeF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeF.FormattingEnabled = true;
            this.timeF.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.timeF.Location = new System.Drawing.Point(4, 18);
            this.timeF.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.timeF.Name = "timeF";
            this.timeF.Size = new System.Drawing.Size(76, 23);
            this.timeF.TabIndex = 0;
            this.timeF.SelectedIndexChanged += new System.EventHandler(this.timeF_SelectedIndexChanged);
            // 
            // pivotChart
            // 
            this.pivotChart.AutoSize = true;
            this.pivotChart.Checked = true;
            this.pivotChart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pivotChart.Enabled = false;
            this.pivotChart.Location = new System.Drawing.Point(16, 229);
            this.pivotChart.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pivotChart.Name = "pivotChart";
            this.pivotChart.Size = new System.Drawing.Size(104, 19);
            this.pivotChart.TabIndex = 13;
            this.pivotChart.Text = "피벗 차트 생성";
            this.pivotChart.UseVisualStyleBackColor = true;
            // 
            // dataExportBtn
            // 
            this.dataExportBtn.Enabled = false;
            this.dataExportBtn.Location = new System.Drawing.Point(187, 222);
            this.dataExportBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dataExportBtn.Name = "dataExportBtn";
            this.dataExportBtn.Size = new System.Drawing.Size(120, 51);
            this.dataExportBtn.TabIndex = 15;
            this.dataExportBtn.Text = "데이터 추출";
            this.dataExportBtn.UseVisualStyleBackColor = true;
            this.dataExportBtn.Click += new System.EventHandler(this.dataExportBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(312, 222);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(84, 51);
            this.exitBtn.TabIndex = 16;
            this.exitBtn.Text = "종료";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 282);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.dataExportBtn);
            this.Controls.Add(this.pivotChart);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.authBtn);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.apiTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Is It Right Sample Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox apiTextBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button authBtn;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton femaleRadio;
        private System.Windows.Forms.RadioButton maleRadio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox age0;
        private System.Windows.Forms.CheckBox age1;
        private System.Windows.Forms.CheckBox age6;
        private System.Windows.Forms.CheckBox age5;
        private System.Windows.Forms.CheckBox age4;
        private System.Windows.Forms.CheckBox age3;
        private System.Windows.Forms.CheckBox age2;
        private System.Windows.Forms.CheckBox age12;
        private System.Windows.Forms.CheckBox age11;
        private System.Windows.Forms.CheckBox age10;
        private System.Windows.Forms.CheckBox age9;
        private System.Windows.Forms.CheckBox age8;
        private System.Windows.Forms.CheckBox age7;
        private System.Windows.Forms.CheckBox age13;
        private System.Windows.Forms.DateTimePicker dateF;
        private System.Windows.Forms.DateTimePicker dateT;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox timeT;
        private System.Windows.Forms.ComboBox timeF;
        private System.Windows.Forms.CheckBox pivotChart;
        private System.Windows.Forms.Button dataExportBtn;
        private System.Windows.Forms.RadioButton allRadio;
        private System.Windows.Forms.Button exitBtn;
    }
}

