using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win11Patcher
{
    internal class Core
    {
        //ToDo:  SetExplorerTo DieserPC / -




        //Context

        public void SingleRegKey(string key, string function)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Debug.WriteLine($"Patching {function}...");
                Console.WriteLine($"Patching {function}...");
                Process process = new Process();
                process.StartInfo.FileName = "reg.exe";
                process.StartInfo.Arguments = key;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (!string.IsNullOrEmpty(errors))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errors);
                    Debug.WriteLine(errors);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(output);
                    Debug.WriteLine(output);
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Reg Injection Failed @{function}: " + ex.Message);
                Debug.WriteLine("ERROR: Reg Injection Failed @{function}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }





        //Explorer
        public void Explorer()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Patching Explorer...");
                Debug.WriteLine("Patching Explorer...");
                Console.ForegroundColor = ConsoleColor.White;

                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\CLSID\{2aa9162e-c906-4dd9-ad0b-3d24a8eef5a0}", "", "CLSID_ItemsViewAdapter");
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\CLSID\{2aa9162e-c906-4dd9-ad0b-3d24a8eef5a0}\InProcServer32", "", @"C:\Windows\System32\Windows.UI.FileExplorer.dll_");
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\CLSID\{2aa9162e-c906-4dd9-ad0b-3d24a8eef5a0}\InProcServer32", "ThreadingModel", "Apartment");

                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\CLSID\{6480100b-5a83-4d1e-9f69-8ae5a88e9a33}", "", "File Explorer Xaml Island View Adapter");
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\CLSID\{6480100b-5a83-4d1e-9f69-8ae5a88e9a33}\InProcServer32", "", @"C:\Windows\System32\Windows.UI.FileExplorer.dll_");
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Classes\CLSID\{6480100b-5a83-4d1e-9f69-8ae5a88e9a33}\InProcServer32", "ThreadingModel", "Apartment");

                byte[] hexData = new byte[]
               {
                    0x13, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x20, 0x00, 0x00, 0x00, 0x10, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01,
                    0x00, 0x00, 0x00, 0x01, 0x07, 0x00, 0x00, 0x5e, 0x01, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
               };
                string registryKey = @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Toolbar\ShellBrowser";
                Registry.SetValue(registryKey, "ITBar7Layout", hexData, RegistryValueKind.Binary);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Reg Injection Successful. Explorer Restored!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR (@EXP) Reg Injection Failed: " + ex.Message);
                Debug.WriteLine("ERROR (@EXP) Reg Injection Failed");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        public void TaskBar()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Repositioning Taskbar...");
                Debug.WriteLine("Patching Taskbar...");
                Console.ForegroundColor = ConsoleColor.White;


                string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
                string registryKeyName = "TaskbarAl";

                using (RegistryKey registry = Registry.CurrentUser.OpenSubKey(registryPath, writable: true))
                {
                    if (registry == null)
                    {
                        Console.WriteLine("Fehler: Der Registrierungspfad existiert nicht.");
                        return;
                    }

                    registry.SetValue(registryKeyName, 0, RegistryValueKind.DWord);

                    Console.WriteLine("Taskleisten-Position wurde erfolgreich geändert (links).");
                }


                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarDa", 0);

                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowTaskViewButton", 0);



                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Reg Injection Successful. Taskbar Moved!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR (@TSB) Reg Injection Failed: " + ex.Message);
                Debug.WriteLine("ERROR (@TSB) Reg Injection Failed");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }




        //SNDVOL

        public void SndVol()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Patching Soundmixer...");
                Debug.WriteLine("Patching Soundmixer...");
                Console.ForegroundColor = ConsoleColor.White;

                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Multimedia\Audio", "UseLegacyVolumeControl", 1);
                Thread.Sleep(50);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Legacy Soundmixer Restored!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }




        //Extension
        public void ShowExtension()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Enabling Extensions...");

                string registryKeyPath = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
                string valueName = "HideFileExt";
                Registry.SetValue(registryKeyPath, valueName, 0);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Extensions Enabled!");
                Console.ForegroundColor = ConsoleColor.White;

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        //BypassEdge

        public void InstallChrome()
        {
            string searchQuery = "chrome download"; // Deine Suchanfrage
            string googleSearchUrl = $"https://www.google.com/search?q={Uri.EscapeDataString(searchQuery)}";

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Accessing Chrome...");

                string downloadUrl = "https://dl.google.com/chrome/install/latest/chrome_installer.exe";
                string tempPath = Path.Combine(Path.GetTempPath(), "chrome_installer.exe");

                using (WebClient client = new WebClient())
                {
                    Console.WriteLine("Downloading Chrome...");
                    client.DownloadFile(downloadUrl, tempPath);
                }

                Console.WriteLine("Installing Chrome...");
                Process process = new Process();
                process.StartInfo.FileName = tempPath;
                process.StartInfo.Arguments = "/silent /install";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.WaitForExit();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Installation Completed!");
                Console.ForegroundColor = ConsoleColor.White;

                File.Delete(tempPath);


            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }



        //Apply AKA restart EXP

        public void Apply()
        {
            try
            {
                Process[] processes = Process.GetProcessesByName("explorer");

                foreach (var process in processes)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(process.Id);
                    process.Kill();
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Explorer Restarted!");

                Process.Start("explorer.exe");

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }




        //Darkmode

        public void SetDarkmode()
        {
            try
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Setting to Darkmode...");
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "SystemUsesLightTheme", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 0, RegistryValueKind.DWord);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Darkmode Set!");
                Console.ForegroundColor = ConsoleColor.White;

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }






        //Recall

        public void DisableRecall()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "CMD.EXE",
                    Arguments = "/c Dism /online /Get-Featureinfo /Featurename:Recall",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    if (output.Contains("Status : Aktiviert") || output.Contains("State : Enabled"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Disabling Recall...");

                        ProcessStartInfo disablePsi = new ProcessStartInfo
                        {
                            FileName = "CMD.EXE",
                            Arguments = "/c Dism /online /Disable-Feature /Featurename:Recall",
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        using (Process disableProcess = Process.Start(disablePsi))
                        {
                            string disableOutput = disableProcess.StandardOutput.ReadToEnd();
                            disableProcess.WaitForExit();
                            Console.WriteLine(disableOutput);
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Recall is not active!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        //OneDrive

        public void KillOneDrive()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Starting OneDrive removal...");
            Console.ForegroundColor = ConsoleColor.White;

            // Stoppe OneDrive, falls es läuft
            try
            {
                Console.WriteLine("Killing OneDrive processes...");
                Process.Start(new ProcessStartInfo
                {
                    FileName = "taskkill",
                    Arguments = "/f /im OneDrive.exe",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                })?.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error killing OneDrive: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            // Deinstalliere OneDrive über die Windows Setup
            try
            {
                Console.WriteLine("Uninstalling OneDrive...");
                string systemRoot = Environment.GetEnvironmentVariable("SystemRoot");
                string setupPath = Path.Combine(systemRoot, "System32", "OneDriveSetup.exe");

                if (File.Exists(setupPath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = setupPath,
                        Arguments = "/uninstall",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true
                    })?.WaitForExit();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("OneDriveSetup.exe not found.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error uninstalling OneDrive: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            // Entferne OneDrive aus der Registrierung
            try
            {
                Console.WriteLine("Removing OneDrive registry entries...");
                string[] regPaths =
                {
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\{018D5C66-4533-4307-9B53-224DE2ED1FE6}",
            @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\{018D5C66-4533-4307-9B53-224DE2ED1FE6}",
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\OneDrive",
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons"
        };

                foreach (var path in regPaths)
                {
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(path, writable: true))
                    {
                        if (key != null)
                        {
                            key.DeleteSubKeyTree("", false);
                            Console.WriteLine($"Removed registry key: {path}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error removing registry keys: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            // Entferne Taskleisten- und Startmenü-Verknüpfungen
            try
            {
                Console.WriteLine("Removing OneDrive from Taskbar and Start Menu...");

                // Taskbar shortcuts
                string taskbarPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData", "Roaming", "Microsoft", "Internet Explorer", "Quick Launch", "User Pinned", "TaskBar");
                string taskbarShortcut = Path.Combine(taskbarPath, "OneDrive.lnk");
                if (File.Exists(taskbarShortcut))
                {
                    File.Delete(taskbarShortcut);
                    Console.WriteLine("OneDrive Taskbar shortcut removed.");
                }

                // Start Menu shortcuts
                string startMenuPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData", "Roaming", "Microsoft", "Windows", "Start Menu", "Programs");
                string[] startMenuShortcuts = Directory.GetFiles(startMenuPath, "*OneDrive*.lnk");
                foreach (var shortcut in startMenuShortcuts)
                {
                    File.Delete(shortcut);
                    Console.WriteLine($"Removed Start Menu shortcut: {shortcut}");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error removing OneDrive shortcuts: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            // Entferne OneDrive aus Autostart
            try
            {
                Console.WriteLine("Removing OneDrive from Autostart...");
                string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string oneDriveRegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(oneDriveRegistryPath, writable: true))
                {
                    if (key != null)
                    {
                        key.DeleteValue("OneDrive", false);
                        Console.WriteLine("OneDrive removed from Autostart.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error removing OneDrive from Autostart: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            // Entferne OneDrive-Daten im Benutzerprofil, wenn gewünscht
            string oneDriveFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "OneDrive");
            try
            {
                if (Directory.Exists(oneDriveFolder))
                {
                    // Nur löschen, wenn du möchtest, dass der OneDrive-Ordner auch gelöscht wird:
                    // Directory.Delete(oneDriveFolder, recursive: true);
                    Console.WriteLine("OneDrive folder remains intact.");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error handling OneDrive folder: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("OneDrive successfully removed.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    







        //Edge
        public void EdgeRipper()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ripping out Edge...");
            Console.ForegroundColor = ConsoleColor.White;

            string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            string edgeInstallerPath = Path.Combine(programFiles, "Microsoft", "Edge", "Application");

            if (!Directory.Exists(edgeInstallerPath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Edge seems not to be installed.");
                return;
            }

            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Running PowerShell command to remove Edge...");

                Process powerShellProcess = new Process();
                powerShellProcess.StartInfo.FileName = "powershell.exe";
                powerShellProcess.StartInfo.Arguments = "-Command \"Get-AppxPackage *Microsoft.MicrosoftEdge* | Remove-AppxPackage\"";
                powerShellProcess.StartInfo.Verb = "runas"; 
                powerShellProcess.StartInfo.UseShellExecute = false;
                powerShellProcess.StartInfo.CreateNoWindow = true;
                powerShellProcess.Start();
                powerShellProcess.WaitForExit();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("PowerShell uninstallation executed.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error during PowerShell uninstallation: " + ex.Message);
            }

            try
            {
                string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string edgeDataPath = Path.Combine(userProfile, "AppData", "Local", "Microsoft", "Edge");

                if (Directory.Exists(edgeDataPath))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Deleting Edge data folder...");

                    Directory.Delete(edgeDataPath, true);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Edge data deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error during Edge data deletion: " + ex.Message);
            }

            try
            {
                string edgeProgramFolder = Path.Combine(programFiles, "Microsoft", "Edge");

                if (Directory.Exists(edgeProgramFolder))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Deleting Edge installation folder...");

                    Directory.Delete(edgeProgramFolder, true);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Edge installation folder deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error during Edge installation folder deletion: " + ex.Message);
            }

            try
            {
                string webView2Path = Path.Combine(programFiles, "Microsoft", "EdgeWebView2");

                if (Directory.Exists(webView2Path))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Deleting Edge WebView2 folder...");

                    Directory.Delete(webView2Path, true);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Edge WebView2 folder deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error during WebView2 folder deletion: " + ex.Message);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Edge should be fully removed after a restart. Please restart your system.");
            RemoveEdgeShortcuts();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void RemoveEdgeShortcuts()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Removing Edge Shortcuts...");
            Console.ForegroundColor = ConsoleColor.White;

            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            string desktopFolder = Path.Combine(userProfile, "Desktop");
            string edgeDesktopShortcut = Path.Combine(desktopFolder, "Microsoft Edge.lnk");

            if (File.Exists(edgeDesktopShortcut))
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Deleting Edge desktop shortcut...");
                    File.Delete(edgeDesktopShortcut);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Edge desktop shortcut deleted.");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error deleting desktop shortcut: " + ex.Message);
                }
            }

            string startMenuFolder = Path.Combine(userProfile, "AppData", "Roaming", "Microsoft", "Windows", "Start Menu", "Programs");
            string[] startMenuShortcuts = Directory.GetFiles(startMenuFolder, "*Microsoft Edge*.lnk");

            foreach (var shortcut in startMenuShortcuts)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Deleting Edge start menu shortcut: {Path.GetFileName(shortcut)}...");
                    File.Delete(shortcut);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Edge start menu shortcut deleted.");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error deleting start menu shortcut {Path.GetFileName(shortcut)}: " + ex.Message);
                }
            }

            string taskbarFolder = Path.Combine(userProfile, "AppData", "Roaming", "Microsoft", "Internet Explorer", "Quick Launch", "User Pinned", "TaskBar");
            string edgeTaskbarShortcut = Path.Combine(taskbarFolder, "Microsoft Edge.lnk");

            if (File.Exists(edgeTaskbarShortcut))
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Deleting Edge taskbar shortcut...");
                    File.Delete(edgeTaskbarShortcut);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Edge taskbar shortcut deleted.");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error deleting taskbar shortcut: " + ex.Message);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Edge shortcuts have been removed.");
            Console.ForegroundColor = ConsoleColor.White;
        }





        //CoPilot

        public void KillCopilot()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Setting Registry-keys...");
                string[] registryPaths =
                {
                @"SOFTWARE\Policies\Microsoft\Windows\WindowsCopilot",
                @"SOFTWARE\Policies\Microsoft\Windows\WindowsAI",
                @"SOFTWARE\Policies\Microsoft\Windows\Explorer",
                @"SOFTWARE\Policies\Microsoft\Edge",
                @"SOFTWARE\Microsoft\Windows\Shell\Copilot\BingChat"
            };

                string[,] registryValues =
                {
                { "TurnOffWindowsCopilot", "1" },
                { "DisableAIDataAnalysis", "1" },
                { "DisableSearchBoxSuggestions", "1" },
                { "CopilotCDPPageContext", "0" },
                { "CopilotPageContext", "0" },
                { "HubsSidebarEnabled", "0" },
                { "IsUserEligible", "0" }
            };

                foreach (var path in registryPaths)
                {
                    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(path))
                    {
                        for (int i = 0; i < registryValues.GetLength(0); i++)
                        {
                            key?.SetValue(registryValues[i, 0], int.Parse(registryValues[i, 1]), RegistryValueKind.DWord);
                        }
                    }
                }
                Console.WriteLine("Registry set.");

                Console.WriteLine("Removing AI Apps...");
                string[] appPackages =
                {
                "MicrosoftWindows.Client.Photon",
                "MicrosoftWindows.Client.AIX",
                "MicrosoftWindows.Client.CoPilot",
                "Microsoft.Windows.Ai.Copilot.Provider",
                "Microsoft.Copilot",
                "Microsoft.MicrosoftOfficeHub"
            };

                foreach (var app in appPackages)
                {
                    Process.Start("powershell", $"-Command \"Get-AppxPackage *{app}* | Remove-AppxPackage -AllUsers\"")?.WaitForExit();
                    Process.Start("powershell", $"-Command \"Get-AppxProvisionedPackage -Online | Where-Object PackageName -like '*{app}*' | Remove-AppxProvisionedPackage -Online\"")?.WaitForExit();
                }
                Console.WriteLine("Apps removed.");

                Console.WriteLine("Removing AI Data...");
                string[] paths =
                {
                @"C:\Windows\SystemApps\MicrosoftWindows.Client.Copilot*",
                @"C:\Windows\SystemApps\MicrosoftWindows.Client.AIX*",
                @"C:\Windows\SystemApps\MicrosoftWindows.Client.Photon*",
                @"C:\Program Files\WindowsApps\MicrosoftWindows.Client.Copilot*",
                @"C:\Program Files\WindowsApps\MicrosoftWindows.Client.AIX*",
                @"C:\Program Files\WindowsApps\MicrosoftWindows.Client.Photon*",
                @"C:\Windows\InboxApps\Copilot*"
            };

                foreach (var path in paths)
                {
                    Process.Start("powershell", $"-Command \"Remove-Item -Path '{path}' -Force -Recurse -ErrorAction SilentlyContinue\"")?.WaitForExit();
                }
                Console.WriteLine("Data Removed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        //Firefox

        public void InstallFirefox()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                string downloadUrl = "https://download.mozilla.org/?product=firefox-latest&os=win&lang=en-US"; 
                string tempPath = Path.Combine(Path.GetTempPath(), "firefox_installer.exe");

                using (WebClient client = new WebClient())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Downloading Firefox...");
                    client.DownloadFile(downloadUrl, tempPath);
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Installing Firefox...");
                Process process = new Process();
                process.StartInfo.FileName = tempPath;
                process.StartInfo.Arguments = "/silent /install"; 
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.WaitForExit();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Installation Completed!");
                Console.ForegroundColor = ConsoleColor.White;

                File.Delete(tempPath); 

            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }





        //StopAutoUpdates

        public void StopUpdates()
        {

                try
                {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Trying to Disable AutoUpdates");
                RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU");
                    key.SetValue("NoAutoUpdate", 1, RegistryValueKind.DWord);
                    key.SetValue("AUOptions", 1, RegistryValueKind.DWord);
                    key.Close();
                Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("AutoUpdates Blocked via Registry");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error @AutoUpdate-Registry: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                }
            try
            {
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.WriteLine("Trying to Block AutoReboot");
                RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate");
                key.SetValue("DoNotConnectToWindowsUpdateInternetLocations", 1, RegistryValueKind.DWord);
                key.SetValue("DisableWindowsUpdateAccess", 1, RegistryValueKind.DWord);
                key.Close();
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("Blocked AutoReboot.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Error @setting Reboot Blocker: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }



        }






        //CortanaRipper


        public void CortanaRipper()
        {
            try
            {
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.WriteLine("Trying to Disable Cortana...");
                RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Windows Search");
                key.SetValue("AllowCortana", 0, RegistryValueKind.DWord);
                key.Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Disabled Cortana");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }


            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Trying to Remove Cortana...");
                Process p = new Process();
                p.StartInfo.FileName = "powershell";
                p.StartInfo.Arguments = "-Command \"Get-AppxPackage -AllUsers *Microsoft.549981C3F5F10* | Remove-AppxPackage\"";
                p.StartInfo.Verb = "runas";
                p.StartInfo.UseShellExecute = true;
                p.Start();
                p.WaitForExit();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Removed Cortana Core");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }


            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Trying to erase Cortana Tasks...");
                Process.Start("powershell", "-Command \"Get-ScheduledTask -TaskName 'Cortana*' | Disable-ScheduledTask\"");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Removed Cortana Tasks.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }

        }

                    //Test
                   
            public void TestMessage()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("TestMessage");
                Debug.WriteLine("TestMessage");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ERROR (@TestMessage)");
                Debug.WriteLine("ERROR (@TestMessage)");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
