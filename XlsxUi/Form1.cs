using System;
using System.Text;
using XlsxTools;

namespace XlsxUi;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    #region 原始数据

    /// <summary>
    /// 所有数据源表
    /// key: name
    /// value: path
    /// </summary>
    private static Dictionary<string, string> dicXlsxInCheckBox = new();
    /// <summary>
    /// 展示的xlsxes列表改变
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CheckListXlsxes_SelectedIndexChanged(object sender, EventArgs e)
    {
        // 收集所有勾选的文件名
        foreach (var item in CheckListXlsxes.CheckedItems)
        {
            string nameXlsx = item.ToString();
            if (dicXlsxInCheckBox.TryGetValue(nameXlsx, out var pathIn))
            {
                Console.WriteLine(pathIn);
                // XlsxTool.CopyTableAllSheet2OneTable(pathIn, pathCollectTable);
            }
        }
    }
    /// <summary>
    /// 点击选择xlsxes文件夹路径
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void btnSelectPath_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
        {
            // 设置文件夹选择对话框标题
            folderDialog.Description = "请选择包含 XLSX 文件的文件夹";
                
            // 点击确定按钮
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = folderDialog.SelectedPath;
                // 清空之前的列表
                CheckListXlsxes.Items.Clear();
                dicXlsxInCheckBox.Clear();
                // 筛选扩展名为 .xlsx 的文件（不区分大小写）
                string[] xlsxFiles = Directory.GetFiles(selectedPath, "*.xlsx", SearchOption.TopDirectoryOnly);
                // 将文件名（不含路径）添加到 CheckedListBox
                foreach (string file in xlsxFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file); // 只获取文件名（如 "test.xlsx"）
                    if (fileName.StartsWith("~"))
                    {
                        continue;
                    }
                    dicXlsxInCheckBox.Add(fileName, file);
                    CheckListXlsxes.Items.Add(fileName);
                }
            }
        }
    }
    

    #endregion

    #region 导入目标文件
    
    private string pathAimXlsx;
    private Dictionary<string, string> dicAimXlsx = new();
    private void btnAimXlsx_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
        {
            // 设置文件夹选择对话框标题
            folderDialog.Description = "请选择包含 XLSX 文件的文件夹";
                
            // 点击确定按钮
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = folderDialog.SelectedPath;
                // 清空之前的列表
                listBox1.Items.Clear();
                dicAimXlsx.Clear();
                // 筛选扩展名为 .xlsx 的文件（不区分大小写）
                string[] xlsxFiles = Directory.GetFiles(selectedPath, "*.xlsx", SearchOption.TopDirectoryOnly);
                // 将文件名（不含路径）添加到 CheckedListBox
                foreach (string file in xlsxFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file); // 只获取文件名（如 "test.xlsx"）
                    if (fileName.StartsWith("~"))
                    {
                        continue;
                    }
                    dicAimXlsx.Add(fileName, file);
                    listBox1.Items.Add(fileName);
                }
            }
        }
    }
    /// <summary>
    /// 单选列表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var fileName = listBox1.Items[listBox1.SelectedIndex].ToString();
        Console.WriteLine(dicAimXlsx[fileName]);
    }
    #endregion
    /// <summary>
    /// 汇总功能
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void btnCollect_Click(object sender, EventArgs e)
    {
        //选中的元数据
        foreach (var tChecked in CheckListXlsxes.CheckedItems)
        {
            Console.WriteLine($"Meta:" + tChecked.ToString() + $"   {dicXlsxInCheckBox[tChecked.ToString()]}");
        }
        var fileName = listBox1.Items[listBox1.SelectedIndex].ToString();
        Console.WriteLine($"Aim:" + fileName.ToString());
    }
    /// <summary>
    /// 对比功能
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void btnCompare_Click(object sender, EventArgs e)
    {
        
    }

}