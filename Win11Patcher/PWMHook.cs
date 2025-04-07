using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Win11Patcher
{

    public class PWMHook
    {

        public static void InstallHook()
        {
            string installerUrl = "https://github.com/oberrich/win11-toggle-rounded-corners/releases/download/v1.2/win11-toggle-rounded-corners-setup.exe";
            string tempInstallerPath = Path.Combine(Path.GetTempPath(), "win11-toggle-rounded-corners-setup.exe");

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Downloading Hook installer...");
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(installerUrl, tempInstallerPath);
                }

                Console.WriteLine("Installing hook...");
                Process installerProcess = new Process();
                installerProcess.StartInfo.FileName = tempInstallerPath;
                installerProcess.StartInfo.Arguments = "/silent";
                installerProcess.StartInfo.UseShellExecute = false;
                installerProcess.StartInfo.CreateNoWindow = true;
                installerProcess.Start();
                installerProcess.WaitForExit();
                Console.WriteLine("Installation complete.");


                Console.WriteLine("Adding to autostart...");
                string autostartKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
                string autostartKeyName = "Win11ToggleRoundedCorners";
                string autostartExecutablePath = @"C:\Program Files\Win11ToggleRoundedCorners\Win11ToggleRoundedCorners.exe";


                Registry.SetValue(@"HKEY_CURRENT_USER\" + autostartKeyPath, autostartKeyName, autostartExecutablePath);

                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("Corners Restored!");

                Console.ForegroundColor = ConsoleColor.White;
                File.Delete(tempInstallerPath);
                Console.WriteLine("Cleaned up temporary files.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }
}
