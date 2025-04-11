namespace Win11Patcher
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            MessageBox.Show("Please read carefully: \n\n- All actions are IRREVERSIBLE! \n- Internet access is required for Certain actions \n- Do NEVER use this tool on ANY other OS than Windows 11!! \n- Some patches might be reverted with a Windows update", "Windows 11 Patcher", MessageBoxButtons.OK, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}