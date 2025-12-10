using XlsxTools;
namespace UIForm;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    
    private void StartJob_Click(object sender, EventArgs e)
    {
        // 收集所有勾选的文件名
        foreach (var item in ListTables.CheckedItems)
        {
            string nameXlsx = item.ToString();
            if (dicXlsxInCheckBox.TryGetValue(nameXlsx, out var pathIn))
            {
                Console.Write(pathIn);
                // XlsxTool.CopyTableAllSheet2OneTable(pathIn, pathCollectTable);
            }
        }
    }

    private void BtnSelectTablesDirection_Click(object sender, EventArgs e)
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
                ListTables.Items.Clear();
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
                    ListTables.Items.Add(fileName);
                }
            }
        }
    }
    
    /// <summary>
    /// 所有数据源表
    /// key: name
    /// value: path
    /// </summary>
    private static Dictionary<string, string> dicXlsxInCheckBox = new();
    
    /// <summary>
    /// 汇总的表的路径
    /// </summary>
    private static string pathCollectTable;
    /// <summary>
    /// 选择汇总的表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void SelectCollectTable_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new ())
        {
            // 设置文件夹选择对话框标题
            openFileDialog.Title = "请选择汇总到的 XLSX";
            openFileDialog.Filter = "文本文件 (*.xlsx)|*.xlsx|所有文件 (*.*)|*.*"; // 仅显示 xlsx 文件
            openFileDialog.FilterIndex = 1; // 默认选中「文本文件」筛选器
            openFileDialog.Multiselect = false; // 允许选择多个文件（需单文件则设为 false）
            openFileDialog.RestoreDirectory = true; // 关闭对话框后保留上次选择的目录
            // 点击确定按钮
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathCollectTable = openFileDialog.FileName;
            }
        }
    }
}