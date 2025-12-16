namespace XlsxUi;

partial class Form1
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        btnSelectPath = new System.Windows.Forms.Button();
        btnAimXlsx = new System.Windows.Forms.Button();
        CheckListXlsxes = new System.Windows.Forms.CheckedListBox();
        listBox1 = new System.Windows.Forms.ListBox();
        btnCollect = new System.Windows.Forms.Button();
        btnCompare = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        tbOldKey = new System.Windows.Forms.TextBox();
        tbAimKey = new System.Windows.Forms.TextBox();
        tbOldColums = new System.Windows.Forms.TextBox();
        tbAimColums = new System.Windows.Forms.TextBox();
        SuspendLayout();
        // 
        // btnSelectPath
        // 
        btnSelectPath.Location = new System.Drawing.Point(30, 15);
        btnSelectPath.Name = "btnSelectPath";
        btnSelectPath.Size = new System.Drawing.Size(147, 34);
        btnSelectPath.TabIndex = 0;
        btnSelectPath.Text = "选择原数据Xlsx文件夹";
        btnSelectPath.UseVisualStyleBackColor = true;
        btnSelectPath.Click += btnSelectPath_Click;
        // 
        // btnAimXlsx
        // 
        btnAimXlsx.Location = new System.Drawing.Point(411, 19);
        btnAimXlsx.Name = "btnAimXlsx";
        btnAimXlsx.Size = new System.Drawing.Size(169, 30);
        btnAimXlsx.TabIndex = 1;
        btnAimXlsx.Text = "选择目标Xlsx文件夹";
        btnAimXlsx.UseVisualStyleBackColor = true;
        btnAimXlsx.Click += btnAimXlsx_Click;
        // 
        // CheckListXlsxes
        // 
        CheckListXlsxes.FormattingEnabled = true;
        CheckListXlsxes.Location = new System.Drawing.Point(30, 55);
        CheckListXlsxes.Name = "CheckListXlsxes";
        CheckListXlsxes.Size = new System.Drawing.Size(348, 166);
        CheckListXlsxes.TabIndex = 2;
        CheckListXlsxes.SelectedIndexChanged += CheckListXlsxes_SelectedIndexChanged;
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.ItemHeight = 17;
        listBox1.Location = new System.Drawing.Point(411, 58);
        listBox1.Name = "listBox1";
        listBox1.Size = new System.Drawing.Size(380, 157);
        listBox1.TabIndex = 3;
        listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        // 
        // btnCollect
        // 
        btnCollect.Location = new System.Drawing.Point(473, 396);
        btnCollect.Name = "btnCollect";
        btnCollect.Size = new System.Drawing.Size(145, 42);
        btnCollect.TabIndex = 4;
        btnCollect.Text = "汇总功能";
        btnCollect.UseVisualStyleBackColor = true;
        btnCollect.Click += btnCollect_Click;
        // 
        // btnCompare
        // 
        btnCompare.Location = new System.Drawing.Point(651, 396);
        btnCompare.Name = "btnCompare";
        btnCompare.Size = new System.Drawing.Size(140, 42);
        btnCompare.TabIndex = 5;
        btnCompare.Text = "对比功能";
        btnCompare.UseVisualStyleBackColor = true;
        btnCompare.Click += btnCompare_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(32, 224);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(346, 22);
        label1.TabIndex = 6;
        label1.Text = "Key(原表key所在列序号: A-0，B-1 只填序号0)";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(30, 274);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(345, 29);
        label2.TabIndex = 7;
        label2.Text = "原表列序号(序列0,序列2：只填0,2)";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(417, 227);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(373, 18);
        label3.TabIndex = 8;
        label3.Text = "Key(目标表key所在列序号: A-0，B-1 只填序号1)";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(411, 275);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(372, 28);
        label4.TabIndex = 9;
        label4.Text = "目标表列序号(序列1,序列3：小数点隔开只填1,3)";
        // 
        // tbOldKey
        // 
        tbOldKey.Location = new System.Drawing.Point(30, 248);
        tbOldKey.Name = "tbOldKey";
        tbOldKey.Size = new System.Drawing.Size(71, 23);
        tbOldKey.TabIndex = 10;
        // 
        // tbAimKey
        // 
        tbAimKey.Location = new System.Drawing.Point(411, 248);
        tbAimKey.Name = "tbAimKey";
        tbAimKey.Size = new System.Drawing.Size(67, 23);
        tbAimKey.TabIndex = 11;
        // 
        // tbOldColums
        // 
        tbOldColums.Location = new System.Drawing.Point(30, 306);
        tbOldColums.Name = "tbOldColums";
        tbOldColums.Size = new System.Drawing.Size(347, 23);
        tbOldColums.TabIndex = 12;
        // 
        // tbAimColums
        // 
        tbAimColums.Location = new System.Drawing.Point(410, 306);
        tbAimColums.Name = "tbAimColums";
        tbAimColums.Size = new System.Drawing.Size(381, 23);
        tbAimColums.TabIndex = 13;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(tbAimColums);
        Controls.Add(tbOldColums);
        Controls.Add(tbAimKey);
        Controls.Add(tbOldKey);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(btnCompare);
        Controls.Add(btnCollect);
        Controls.Add(listBox1);
        Controls.Add(CheckListXlsxes);
        Controls.Add(btnAimXlsx);
        Controls.Add(btnSelectPath);
        Text = "Xlsx Tool";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox tbOldKey;
    private System.Windows.Forms.TextBox tbAimKey;
    private System.Windows.Forms.TextBox tbOldColums;
    private System.Windows.Forms.TextBox tbAimColums;

    private System.Windows.Forms.Button btnCollect;
    private System.Windows.Forms.Button btnCompare;

    private System.Windows.Forms.ListBox listBox1;

    private System.Windows.Forms.Button btnSelectPath;
    private System.Windows.Forms.CheckedListBox CheckListXlsxes;

    private System.Windows.Forms.Button btnAimXlsx;

    #endregion
}