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
        btnAimXlsx.Location = new System.Drawing.Point(471, 18);
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
        listBox1.Location = new System.Drawing.Point(473, 58);
        listBox1.Name = "listBox1";
        listBox1.Size = new System.Drawing.Size(318, 157);
        listBox1.TabIndex = 3;
        listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        // 
        // btnCollect
        // 
        btnCollect.Location = new System.Drawing.Point(31, 239);
        btnCollect.Name = "btnCollect";
        btnCollect.Size = new System.Drawing.Size(145, 42);
        btnCollect.TabIndex = 4;
        btnCollect.Text = "汇总功能";
        btnCollect.UseVisualStyleBackColor = true;
        btnCollect.Click += btnCollect_Click;
        // 
        // btnCompare
        // 
        btnCompare.Location = new System.Drawing.Point(280, 245);
        btnCompare.Name = "btnCompare";
        btnCompare.Size = new System.Drawing.Size(151, 35);
        btnCompare.TabIndex = 5;
        btnCompare.Text = "对比功能";
        btnCompare.UseVisualStyleBackColor = true;
        btnCompare.Click += btnCompare_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(btnCompare);
        Controls.Add(btnCollect);
        Controls.Add(listBox1);
        Controls.Add(CheckListXlsxes);
        Controls.Add(btnAimXlsx);
        Controls.Add(btnSelectPath);
        Text = "Form1";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btnCollect;
    private System.Windows.Forms.Button btnCompare;

    private System.Windows.Forms.ListBox listBox1;

    private System.Windows.Forms.Button btnSelectPath;
    private System.Windows.Forms.CheckedListBox CheckListXlsxes;

    private System.Windows.Forms.Button btnAimXlsx;

    #endregion
}