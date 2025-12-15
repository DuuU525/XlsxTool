using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace XlsxTools
{
    public class XlsxTool
    {
        static int Main(string[] args)
        {
            Console.WriteLine("start");
            CopyTableAllSheet2OneTable();
            // CompareTableValue();
            return 0;
        }

        #region Job1 汇总表
        /// <summary>
        /// 将表A内所有的sheet导入到汇总表的sheet(Name = A)
        /// </summary>
        /// <param name="pathIn"></param>
        /// <param name="pathOut"></param>
        /// <param name="map"></param>
        public static void CopyTableAllSheet2OneTable(string pathIn = "", string pathOut = "", Dictionary<int, int> map = null)
        {
            #region test
            // string pathInA = Path.Combine("H:\\Apps\\Project_Xlsx", "2_运作表2025.xlsx");
            // string pathOutC = Path.Combine("H:\\Apps\\Project_Xlsx", "result.xlsx");
            // Dictionary<int, int> columnMap = new Dictionary<int, int>();//表中列的映射关系
            // columnMap.Add(0, 2);
            // columnMap.Add(1, 4);
            // columnMap.Add(2, 6);
            // columnMap.Add(3, 1);
            //
            // pathIn = pathInA;
            // pathOut = pathOutC;
            // map = columnMap;
            #endregion

            Job1_Step1(pathIn, pathOut, map);
            MessageBox.Show($"完成汇总功能");
        }
        /// <summary>
        /// 读取原表
        /// </summary>
        private static void Job1_Step1(string pathInput, string pathOut, Dictionary<int, int> columnMap)
        {
            Dictionary<string, List<string>> dictA = new();
            ExcelUtils.ReadExcel(pathInput, ExcelUtils.ReadSheetType.All, idxKey: 0, dict: dictA);
            Dictionary<string, List<string>> dictWrite = new();
            foreach (var kv in dictA)
            {
                dictWrite[kv.Key] = GenerateColumnMap(columnMap, kv.Value);
            }
            string nameSheet = Path.GetFileNameWithoutExtension(pathInput);
            //写入汇总表
            ExcelUtils.WriteExcel(pathOut, nameSheet, dictWrite);         
        }
        
        /// <summary>
        /// 映射结果
        /// </summary>
        /// <param name="columnMap"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private static List<string> GenerateColumnMap(Dictionary<int, int> columnMap, List<string> list)
        {
            var maxColum = columnMap.Values.Max();
            string[] rsList = new string[maxColum + 1];
            foreach (var kvMap in columnMap)
            {
                if (list.Count > kvMap.Key)
                {
                    rsList[kvMap.Value] = list[kvMap.Key];
                } 
                else
                {
                    Console.Write($"原表数据映射 列数 不存在");
                }
            }

            return rsList.ToList();
        }
        #endregion

        #region Job2

        /// <summary>
        /// 对比表
        /// </summary>
        /// <param name="pathA"></param>
        /// <param name="pathB"></param>
        /// <param name="indexKey"></param>
        /// <param name="map"></param>
        public static void CompareTableValue(
                                            string pathA = "",  int indexKeyA = -1,
                                            string pathB = "", int indexKeyB = -1,
                                            Dictionary<int, int> map = null
                                            )
        {
            #region Test

            // pathA = Path.Combine("H:\\Apps\\XlsxTool\\Datas", "A.xlsx");
            // pathB = Path.Combine("H:\\Apps\\XlsxTool\\Datas", "result.xlsx");
            // indexKeyA = 0;
            // indexKeyB = 2;
            // map = new Dictionary<int, int>();//表中列的映射关系
            // map.Add(3, 1);
            // map.Add(1, 4);

            #endregion
            Dictionary<string, List<string>> dictA = new();
            ExcelUtils.ReadExcel(pathA, ExcelUtils.ReadSheetType.All, idxKey: indexKeyA, dict: dictA);
            
            Dictionary<string, List<string>> dictB = new();
            ExcelUtils.ReadExcel(pathB, ExcelUtils.ReadSheetType.All, idxKey: indexKeyB, dict: dictB);

            Dictionary<string, List<int>> dictWarmingB = new();
            Dictionary<string, List<int>> dictWarmingA = new();
            foreach (var kv in dictB)
            {
                var keyCompare = kv.Key.ToLower().Trim();
                var rsListB = kv.Value;
                if (!dictA.TryGetValue(keyCompare, out var rsListA)) continue;
                foreach (var kvMap in map)
                {
                    var idxA = kvMap.Key;
                    var idxB = kvMap.Value;
                    var valueB = string.Empty;
                    if (rsListB.Count > idxB)
                    {
                        valueB = rsListB[idxB].ToLower().Trim();
                    }
                    else
                    {
                        Console.Write($"原表数据映射B 列数 不存在");
                        continue;
                    }
                    if (rsListA.Count > idxA)
                    {
                        var valueA = rsListA[idxA].ToLower().Trim();
                        if (valueA.Equals(valueB)) continue; 
                        //记录有误的 key - 对应列数
                        if (dictWarmingB.TryGetValue(keyCompare, out var rsB) == false)
                        {
                            dictWarmingB.TryAdd(keyCompare, new());
                        }
                        dictWarmingB[keyCompare].Add(idxB);
                        
                        //记录有误的 key - 对应列数
                        if (dictWarmingA.TryGetValue(keyCompare, out var rsA) == false)
                        {
                            dictWarmingA.TryAdd(keyCompare, new());
                        }
                        dictWarmingA[keyCompare].Add(idxA);
                    }
                    else
                    {
                        Console.Write($"原表数据映射A 列数 不存在");
                    }
                }
            }
            
            
            ExcelUtils.WriteExcelColor(pathA, ExcelUtils.ReadSheetType.All, indexKeyA, dictWarmingA);
            ExcelUtils.WriteExcelColor(pathB, ExcelUtils.ReadSheetType.All, indexKeyB, dictWarmingB);
            Console.Write($"Finish Compare");
            MessageBox.Show($"完成对比功能");
        }


        #endregion
    }
}