using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XSSF.Streaming;

namespace XlsxTools;
public class ExcelUtils
{
    public enum ReadSheetType
    {
        None,
        One,
        All
    }
    /// <summary>
    /// 读取表
    /// </summary>
    /// <param name="filePath">表路径</param>
    /// <param name="typeSheet">读取方式</param>
    /// <param name="idxSheet">读取分表index</param>
    /// <param name="idxKey">index列作为key</param>
    /// <param name="dict">读取结果</param>
    public static void ReadExcel(
                                string filePath, 
                                ReadSheetType typeSheet = ReadSheetType.None, 
                                int idxSheet = -1, 
                                int idxKey = 0,
                                Dictionary<string, List<string>> dict = null
                                )
    {
        using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        IWorkbook workbook = new XSSFWorkbook(fs); // .xlsx 使用 XSSFWorkbook
        List<int> sheetsIndx = new();
        switch (typeSheet)
        {
            case ReadSheetType.None:
                break;
            case ReadSheetType.One:
                sheetsIndx.Add(idxSheet);
                break;
            case ReadSheetType.All:
            {
                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    sheetsIndx.Add(i);
                }
            }
                break;
            default:
                break;
        }

        dict ??= new();
        dict.Clear();
        List<string> cellValues = new();
        for (int i = 0; i < sheetsIndx.Count; i++)
        {
            ISheet sheet = workbook.GetSheetAt(sheetsIndx[i]);
                
            // Console.WriteLine($"sheet[{sheet.SheetName}]");
            
            foreach (IRow row in sheet)//分表
            {
                if (row == null) continue;
                // if (row.RowNum == 0)
                // {
                //     continue;
                // }
                cellValues.Clear();
                for (int j = 0; j < row.LastCellNum; j++)//行（cell, cell）
                {
                    ICell cell = row.GetCell(j);
                    string value = cell?.ToString() ?? "";
                    // Console.Write(value + "\t");
                    value = value.ToLower().Trim();
                    cellValues.Add(value);
                }

                if (cellValues.Count > idxKey)
                {
                    dict.TryAdd(cellValues[idxKey], new List<string>(cellValues));   
                }
                    
                // Console.WriteLine();
            }
        }
        /*
        foreach (var kv in dict)
        {
            string strV = string.Empty;
            foreach (var v in kv.Value)
            {
                strV = string.IsNullOrEmpty(strV) ? v : $"{strV},{v}";
            }
            
            Console.WriteLine($"key[{kv.Key}] value[{strV}]");
        }
        */
    }
    
    public static void WriteExcel(string filePath, string nameSheet, Dictionary<string, List<string>> dict = null)
    {
        // XSSFColor customColor = new XSSFColor();
        // customColor.RGB = [255, 100, 100, 255];
        IWorkbook workbook = new XSSFWorkbook(); // 创建 .xlsx 工作簿

        #region Style
        ICellStyle style = workbook.CreateCellStyle();
        style.FillForegroundColor = IndexedColors.Yellow.Index; // 背景色
        style.FillPattern = FillPattern.SolidForeground;        // 填充模式
        #endregion

        ISheet sheet = workbook.GetSheet(nameSheet);
        Dictionary<string, List<string>> dictExist = new();
        if (sheet == null)
        {
            sheet = workbook.CreateSheet(nameSheet);
            dictExist.Clear();
        }
        else
        {
            ReadExcel(filePath, ReadSheetType.One, workbook.GetSheetIndex(nameSheet), 0, dictExist);
            foreach (var kv in dictExist)
            {
                if (dict.ContainsKey(kv.Key))
                {
                    dict.Remove(kv.Key);
                }
            }
        }
        // 创建标题行
        // IRow headerRow = sheet.CreateRow(0);
        // headerRow.CreateCell(0).SetCellValue("姓名");
        // headerRow.CreateCell(1).SetCellValue("年龄");
        // headerRow.CreateCell(2).SetCellValue("城市");

        // 创建数据行
        int idxWrite = 0;
        foreach (var kv in dict)
        {
            IRow dataRow = sheet.CreateRow(dictExist.Count + idxWrite);
            for (int i = 0; i < kv.Value.Count; i++)
            {
                dataRow.CreateCell(i).SetCellValue(kv.Value[i]);
            }
            idxWrite++;
        }
        // dataRow.CreateCell(0).SetCellValue("张三");
        // dataRow.GetCell(0).CellStyle = style;
        // dataRow.CreateCell(1).SetCellValue(28);
        // dataRow.CreateCell(2).SetCellValue("北京");

        // 自动列宽（可选）
        for (int i = 0; i < 3; i++)
            sheet.AutoSizeColumn(i);

        // 保存到文件
        using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        workbook.Write(fs);
    }
    
    public static void WriteLargeExcel(string filePath, int rowCount = 100_000)
    {
        // 保留100行在内存，其余写入临时文件
        var workbook = new SXSSFWorkbook(new XSSFWorkbook(), 100);
        ISheet sheet = workbook.CreateSheet("大数据");

        for (int i = 0; i < rowCount; i++)
        {
            IRow row = sheet.CreateRow(i);
            row.CreateCell(0).SetCellValue($"Name_{i}");
            row.CreateCell(1).SetCellValue(i);
            row.CreateCell(2).SetCellValue($"City_{i % 10}");
        }

        using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            workbook.Write(fs);
        }

        // 清理临时文件（可选）
        workbook.Dispose();
    }
    /// <summary>
    /// 写入标记颜色
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="typeSheet"></param>
    /// <param name="keyIdx"></param>
    /// <param name="dictWarming"></param>
    public static void WriteExcelColor(string filePath, ReadSheetType typeSheet, int keyIdx, Dictionary<string, List<int>> dictWarming)
    {
        var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        IWorkbook workbook = new XSSFWorkbook(fs); // .xlsx 使用 XSSFWorkbook
        
        #region Style
        ICellStyle style = workbook.CreateCellStyle();
        style.FillForegroundColor = IndexedColors.Red.Index; // 背景色
        style.FillPattern = FillPattern.SolidForeground;        // 填充模式
        #endregion

        for (int i = 0; i < workbook.NumberOfSheets; i++)
        {
            ISheet sheet = workbook.GetSheetAt(i);
            foreach (IRow row in sheet)//分表
            {
                if (row == null) continue;
                
                ICell cellKey = row.GetCell(keyIdx);
                string cellValue = cellKey?.ToString().ToLower().Trim();
                if (!dictWarming.TryGetValue(cellValue, out var rsList)) continue;
                
                for (int j = 0; j < rsList.Count; j++)
                {
                    var cellRs = row.GetCell(rsList[j]);
                    cellRs.CellStyle = style;
                }
            }
        }
        
        fs.Dispose();
        // 保存到文件
        using var fsWrite = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        workbook.Write(fsWrite);
    }
}