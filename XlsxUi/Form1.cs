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
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            // 设置文件夹选择对话框标题
            openFileDialog.Title = "请选择一个 Excel 文件以确定文件夹";
            openFileDialog.Filter = "Excel 文件 (*.xls;*.xlsx)|*.xls;*.xlsx|所有文件 (*.*)|*.*";
            openFileDialog.CheckFileExists = false; // 允许用户不选具体文件（但我们要的是文件夹）
            openFileDialog.CheckPathExists = true;
            openFileDialog.ValidateNames = false;   // 关键：允许输入无效文件名（如只选文件夹）
            openFileDialog.FileName = "选中此文件夹"; // 虚拟文件名，提示用户
            // 点击确定按钮
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = Path.GetDirectoryName(openFileDialog.FileName);
                // 清空之前的列表
                CheckListXlsxes.Items.Clear();
                dicXlsxInCheckBox.Clear();
                // 筛选扩展名为 .xlsx 的文件（不区分大小写）
                string[] xlsxFiles = Directory.GetFiles(selectedPath, "*.*", SearchOption.AllDirectories)
                    .Where(f => new[] { ".xls", ".xlsx" }.Contains(Path.GetExtension(f).ToLower()))
                    .ToArray();
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
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            // 设置文件夹选择对话框标题
            openFileDialog.Title = "请选择一个 Excel 文件以确定文件夹";
            openFileDialog.Filter = "Excel 文件 (*.xls;*.xlsx)|*.xls;*.xlsx|所有文件 (*.*)|*.*";
            openFileDialog.CheckFileExists = false; // 允许用户不选具体文件（但我们要的是文件夹）
            openFileDialog.CheckPathExists = true;
            openFileDialog.ValidateNames = false;   // 关键：允许输入无效文件名（如只选文件夹）
            openFileDialog.FileName = "选中此文件夹"; // 虚拟文件名，提示用户
            // 点击确定按钮
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = Path.GetDirectoryName(openFileDialog.FileName);
                // 清空之前的列表
                listBox1.Items.Clear();
                dicAimXlsx.Clear();
                // 筛选扩展名为 .xlsx 的文件（不区分大小写）
                string[] xlsxFiles = Directory.GetFiles(selectedPath, "*.*", SearchOption.AllDirectories)
                    .Where(f => new[] { ".xls", ".xlsx" }.Contains(Path.GetExtension(f).ToLower()))
                    .ToArray();
                    //Directory.GetFiles(selectedPath, "*.xlsx|*.xls", SearchOption.TopDirectoryOnly);
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

        if (CheckUsable() == false)
        {
            return;
        }
        try
        {
            var keyMap = GetKeyAndDicColums();
            var pathAim = dicAimXlsx[listBox1.Items[listBox1.SelectedIndex].ToString()];
            //选中的元数据
            foreach (var tChecked in CheckListXlsxes.CheckedItems)
            {
                var pathOld = dicXlsxInCheckBox[tChecked.ToString()];
                XlsxTool.CopyTableAllSheet2OneTable(pathOld, pathAim, keyMap.dicMap);
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.ToString());
        }
    }
    /// <summary>
    /// 检测可用性
    /// </summary>
    /// <returns></returns>
    private bool CheckUsable()
    {
        if (CheckListXlsxes.CheckedItems.Count <= 0)
        {
            MessageBox.Show($"左侧 还未选择原数据xlsx文件");
            return false;
        }
        if (listBox1.SelectedIndex == -1)
        {
            MessageBox.Show($"右侧 还未选择目标xlsx文件");
            return false;
        }


        if (int.TryParse(tbOldKey.Text, out var rsO) == false)
        {
            MessageBox.Show($"左侧 原表key必须填入列序号");
            return false;
        }
        if (int.TryParse(tbAimKey.Text, out var rsA) == false)
        {
            MessageBox.Show($"右侧 目标key必须填入列序号");
            return false;
        }

        if (string.IsNullOrEmpty(tbOldColums.Text) || string.IsNullOrEmpty(tbAimColums.Text))
        {
            MessageBox.Show($"请确保映射的列序号不为空");
            return false;
        }
        return true;
    }
    /// <summary>
    /// 对比功能
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void btnCompare_Click(object sender, EventArgs e)
    {
        try
        {
            var keyMap = GetKeyAndDicColums();
            var pathOld = dicXlsxInCheckBox[CheckListXlsxes.CheckedItems[0].ToString()];
            var pathAim = dicAimXlsx[listBox1.Items[listBox1.SelectedIndex].ToString()];
            XlsxTool.CompareTableValue(pathOld, keyMap.keyOld, pathAim, keyMap.keyAim, keyMap.dicMap);
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.ToString());
        }
    }

    private (int keyOld, int keyAim, Dictionary<int, int> dicMap) GetKeyAndDicColums()
    {
        Dictionary<int, int> dicMap = new();
        if (tbOldColums.Text.Contains(".") == false || tbAimColums.Text.Contains(".") == false)
        {
            dicMap.Add(int.Parse(tbOldColums.Text), int.Parse(tbAimColums.Text));
        }
        else
        {
            var columsOld = tbOldColums.Text.Split('.');
            var columsAim = tbAimColums.Text.Split('.');
            for (int i = 0; i < columsOld.Length; i++)
            {
                if (int.TryParse(columsOld[i], out var rsOld))
                {
                    if (columsAim.Length > i && int.TryParse(columsAim[i], out var rsAim))
                    {
                        dicMap.Add(rsOld, rsAim);
                    }
                }
            }
        }
        return (int.Parse(tbOldKey.Text), int.Parse(tbAimKey.Text), dicMap);
    }
}