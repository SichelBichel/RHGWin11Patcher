using System.Runtime.InteropServices;
using System;
using System.Text;
using System.Diagnostics;
namespace Win11Patcher
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr AllocConsole();

        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hWndParent, IntPtr hWndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);



        public const int SW_MINIMIZE = 6;

        private const uint WM_SETICON = 0x0080;
        private const uint ICON_BIG = 1;
        private const uint ICON_SMALL = 0;

        private PWMHook _PWMHook;
        private Core _Core;



        //test

        public Form1()
        {
            InitializeComponent();
            _Core = new Core();
            _PWMHook = new PWMHook();


            AllocConsole();
            Console.Title = "W11P_CMD";



            ConsoleWriter consoleWriter = new ConsoleWriter(rtbConsole);
            Console.SetOut(consoleWriter);
            Console.SetError(consoleWriter);
            StartDelayedAction();

        }



        private async void StartDelayedAction()
        {

            await Task.Delay(500);

            MinimizeWindowsByTitle("W11P_CMD");

        }



        public static void MinimizeWindowsByTitle(string windowTitle)
        {
            IntPtr hWnd = IntPtr.Zero;

            do
            {
                hWnd = FindWindowEx(IntPtr.Zero, hWnd, null, windowTitle);

                if (hWnd != IntPtr.Zero)
                {
                    ShowWindow(hWnd, SW_MINIMIZE);
                }

            } while (hWnd != IntPtr.Zero);
        }



        private void ClearConsole()
        {
            Console.Clear();
            rtbConsole.Clear();
        }
        //alfsf


        private void UI_PatchContextmenu(object sender, EventArgs e)
        {
            _Core.SingleRegKey("add \"HKCU\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32\" /f /ve", "Context Menu");
        }

        private void UI_PatchExplorer(object sender, EventArgs e)
        {
            _Core.Explorer();
        }

        private void ButtonTestMessage(object sender, EventArgs e)
        {
            _Core.TestMessage();
        }



        //unsured
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Console retracted, Form initialized. Welcome to W11P");
        }

        private void UI_SoundMixer(object sender, EventArgs e)
        {
            _Core.SndVol();
        }

        private void UI_PatchTaskBar(object sender, EventArgs e)
        {
            _Core.TaskBar();
        }

        private void UI_ShowExtensions(object sender, EventArgs e)
        {
            _Core.ShowExtension();
        }

        private void UI_BypassEdge(object sender, EventArgs e)
        {
            _Core.InstallChrome();
        }

        private void UI_HIJACKPWM(object sender, EventArgs e)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Installing PWM Hook!");
                Console.ForegroundColor = ConsoleColor.White;
                // Hook installieren
                PWMHook.InstallHook();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Installation Completed!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void UI_DarkMOde(object sender, EventArgs e)
        {
            _Core.SetDarkmode();
        }

        private void UI_Apply(object sender, EventArgs e)
        {
            _Core.Apply();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UI_DisableRecall(object sender, EventArgs e)
        {
            _Core.DisableRecall();
        }

        private void UI_KillCopilot(object sender, EventArgs e)
        {
            _Core.KillCopilot();
        }

        private void UI_TEST(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("test");
            MinimizeWindowsByTitle("W11P_CMD");
        }

        private void UI_ClearConsole(object sender, EventArgs e)
        {
            ClearConsole();
        }
    }





    public class ConsoleWriter : TextWriter
    {
        private RichTextBox _output;
        private Dictionary<ConsoleColor, Color> _colorMap;

        public ConsoleWriter(RichTextBox output)
        {
            _output = output;

            _colorMap = new Dictionary<ConsoleColor, Color>
        {
            { ConsoleColor.Black, Color.Black },
            { ConsoleColor.DarkBlue, Color.DarkBlue },
            { ConsoleColor.DarkGreen, Color.DarkGreen },
            { ConsoleColor.DarkCyan, Color.DarkCyan },
            { ConsoleColor.DarkRed, Color.DarkRed },
            { ConsoleColor.DarkMagenta, Color.DarkMagenta },
            { ConsoleColor.DarkYellow, Color.Olive },
            { ConsoleColor.Gray, Color.Gray },
            { ConsoleColor.DarkGray, Color.DarkGray },
            { ConsoleColor.Blue, Color.Blue },
            { ConsoleColor.Green, Color.Green },
            { ConsoleColor.Cyan, Color.Cyan },
            { ConsoleColor.Red, Color.Red },
            { ConsoleColor.Magenta, Color.Magenta },
            { ConsoleColor.Yellow, Color.Yellow },
            { ConsoleColor.White, Color.White }
        };
        }



        public override void Write(char value)
        {
            WriteText(value.ToString(), Console.ForegroundColor);
        }

        public override void WriteLine(string value)
        {
            WriteText(value + Environment.NewLine, Console.ForegroundColor);
        }

        private void WriteText(string text, ConsoleColor consoleColor)
        {
            if (!_colorMap.TryGetValue(consoleColor, out Color color))
            {
                color = Color.White;
            }

            _output.Invoke((MethodInvoker)(() =>
            {
                _output.SelectionStart = _output.TextLength;
                _output.SelectionLength = 0;

                _output.SelectionColor = color;
                _output.AppendText(text);
                _output.SelectionColor = _output.ForeColor;
            }));
        }

        public override Encoding Encoding => Encoding.UTF8;
    } 
}