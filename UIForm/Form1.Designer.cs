namespace UIForm;

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
        StartJob = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        ListTables = new System.Windows.Forms.CheckedListBox();
        BtnSelectTablesDirection = new System.Windows.Forms.Button();
        SelectCollectTable = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // StartJob
        // 
        StartJob.Location = new System.Drawing.Point(701, 408);
        StartJob.Name = "StartJob";
        StartJob.Size = new System.Drawing.Size(73, 30);
        StartJob.TabIndex = 0;
        StartJob.Text = "导出";
        StartJob.UseVisualStyleBackColor = true;
        StartJob.Visible = false;
        StartJob.Click += StartJob_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(24, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(96, 20);
        label1.TabIndex = 1;
        label1.Text = "所有原表";
        label1.Visible = false;
        // 
        // ListTables
        // 
        ListTables.FormattingEnabled = true;
        ListTables.Location = new System.Drawing.Point(24, 32);
        ListTables.Name = "ListTables";
        ListTables.Size = new System.Drawing.Size(243, 130);
        ListTables.TabIndex = 2;
        ListTables.Visible = false;
        // 
        // BtnSelectTablesDirection
        // 
        BtnSelectTablesDirection.Location = new System.Drawing.Point(126, 2);
        BtnSelectTablesDirection.Name = "BtnSelectTablesDirection";
        BtnSelectTablesDirection.Size = new System.Drawing.Size(140, 30);
        BtnSelectTablesDirection.TabIndex = 3;
        BtnSelectTablesDirection.Text = "选择项目运作表目录";
        BtnSelectTablesDirection.UseVisualStyleBackColor = true;
        BtnSelectTablesDirection.Visible = false;
        BtnSelectTablesDirection.Click += BtnSelectTablesDirection_Click;
        // 
        // SelectCollectTable
        // 
        SelectCollectTable.Location = new System.Drawing.Point(132, 175);
        SelectCollectTable.Name = "SelectCollectTable";
        SelectCollectTable.Size = new System.Drawing.Size(135, 25);
        SelectCollectTable.TabIndex = 4;
        SelectCollectTable.Text = "选择汇总表";
        SelectCollectTable.UseVisualStyleBackColor = true;
        SelectCollectTable.Visible = false;
        SelectCollectTable.Click += SelectCollectTable_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(SelectCollectTable);
        Controls.Add(BtnSelectTablesDirection);
        Controls.Add(ListTables);
        Controls.Add(label1);
        Controls.Add(StartJob);
        Location = new System.Drawing.Point(15, 15);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button StartJob;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckedListBox ListTables;
    private System.Windows.Forms.Button BtnSelectTablesDirection;
    private System.Windows.Forms.Button SelectCollectTable;

    #endregion
}