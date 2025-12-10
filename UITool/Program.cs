using XlsxToLua;
namespace UITool;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        // XlsxTool.CompareTableValue();
        // XlsxTool.CopyTableAllSheet2OneTable();
        Application.Run(new Form1());
    }
    
    
}