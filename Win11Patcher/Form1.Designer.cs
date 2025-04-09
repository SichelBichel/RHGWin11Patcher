namespace Win11Patcher
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            buttonContextMenu = new Button();
            buttonExplorer = new Button();
            buttonTaskBar = new Button();
            buttonShowExtensions = new Button();
            buttonBypassEdge = new Button();
            buttonPWM = new Button();
            buttonApply = new Button();
            rtbConsole = new RichTextBox();
            buttonDisableRecall = new Button();
            buttonKillCopilot = new Button();
            pictureBox1 = new PictureBox();
            buttonClearConsole = new Button();
            buttonDarkMode = new Button();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            button3 = new Button();
            linkLabel1 = new LinkLabel();
            button4 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // buttonContextMenu
            // 
            buttonContextMenu.Location = new Point(27, 202);
            buttonContextMenu.Name = "buttonContextMenu";
            buttonContextMenu.Size = new Size(146, 40);
            buttonContextMenu.TabIndex = 0;
            buttonContextMenu.Text = "Patch Context Menu";
            buttonContextMenu.UseVisualStyleBackColor = true;
            buttonContextMenu.Click += UI_PatchContextmenu;
            // 
            // buttonExplorer
            // 
            buttonExplorer.Location = new Point(27, 248);
            buttonExplorer.Name = "buttonExplorer";
            buttonExplorer.Size = new Size(146, 40);
            buttonExplorer.TabIndex = 2;
            buttonExplorer.Text = "Patch Explorer";
            buttonExplorer.UseVisualStyleBackColor = true;
            buttonExplorer.Click += UI_PatchExplorer;
            // 
            // buttonTaskBar
            // 
            buttonTaskBar.Location = new Point(27, 294);
            buttonTaskBar.Name = "buttonTaskBar";
            buttonTaskBar.Size = new Size(146, 40);
            buttonTaskBar.TabIndex = 4;
            buttonTaskBar.Text = "Patch TaskBar";
            buttonTaskBar.UseVisualStyleBackColor = true;
            buttonTaskBar.Click += UI_PatchTaskBar;
            // 
            // buttonShowExtensions
            // 
            buttonShowExtensions.Location = new Point(27, 340);
            buttonShowExtensions.Name = "buttonShowExtensions";
            buttonShowExtensions.Size = new Size(146, 40);
            buttonShowExtensions.TabIndex = 5;
            buttonShowExtensions.Text = "Show Extensions";
            buttonShowExtensions.UseVisualStyleBackColor = true;
            buttonShowExtensions.Click += UI_ShowExtensions;
            // 
            // buttonBypassEdge
            // 
            buttonBypassEdge.Location = new Point(27, 478);
            buttonBypassEdge.Name = "buttonBypassEdge";
            buttonBypassEdge.Size = new Size(146, 40);
            buttonBypassEdge.TabIndex = 6;
            buttonBypassEdge.Text = "Install Chrome";
            buttonBypassEdge.UseVisualStyleBackColor = true;
            buttonBypassEdge.Click += UI_BypassEdge;
            // 
            // buttonPWM
            // 
            buttonPWM.Location = new Point(179, 294);
            buttonPWM.Name = "buttonPWM";
            buttonPWM.Size = new Size(146, 40);
            buttonPWM.TabIndex = 7;
            buttonPWM.Text = "Restore Corners";
            buttonPWM.UseVisualStyleBackColor = true;
            buttonPWM.Click += UI_HIJACKPWM;
            // 
            // buttonApply
            // 
            buttonApply.BackColor = Color.Yellow;
            buttonApply.Location = new Point(27, 156);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(146, 40);
            buttonApply.TabIndex = 8;
            buttonApply.Text = "Restart Explorer";
            buttonApply.UseVisualStyleBackColor = false;
            buttonApply.Click += UI_Apply;
            // 
            // rtbConsole
            // 
            rtbConsole.BackColor = SystemColors.ControlText;
            rtbConsole.Location = new Point(380, 38);
            rtbConsole.Name = "rtbConsole";
            rtbConsole.ReadOnly = true;
            rtbConsole.Size = new Size(631, 498);
            rtbConsole.TabIndex = 12;
            rtbConsole.Text = "";
            // 
            // buttonDisableRecall
            // 
            buttonDisableRecall.Location = new Point(179, 248);
            buttonDisableRecall.Name = "buttonDisableRecall";
            buttonDisableRecall.Size = new Size(146, 40);
            buttonDisableRecall.TabIndex = 13;
            buttonDisableRecall.Text = "Disable Recall";
            buttonDisableRecall.UseVisualStyleBackColor = true;
            buttonDisableRecall.Click += UI_DisableRecall;
            // 
            // buttonKillCopilot
            // 
            buttonKillCopilot.Location = new Point(179, 340);
            buttonKillCopilot.Name = "buttonKillCopilot";
            buttonKillCopilot.Size = new Size(146, 40);
            buttonKillCopilot.TabIndex = 14;
            buttonKillCopilot.Text = "Remove CoPilot";
            buttonKillCopilot.UseVisualStyleBackColor = true;
            buttonKillCopilot.Click += UI_KillCopilot;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = RHGWin11Patcher.Properties.Resources.ReHoGaBanner3_0_Transparent;
            pictureBox1.Image = RHGWin11Patcher.Properties.Resources.ReHoGaBanner3_0_Transparent;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(27, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(298, 126);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // buttonClearConsole
            // 
            buttonClearConsole.BackColor = Color.LawnGreen;
            buttonClearConsole.Location = new Point(179, 156);
            buttonClearConsole.Name = "buttonClearConsole";
            buttonClearConsole.Size = new Size(146, 40);
            buttonClearConsole.TabIndex = 17;
            buttonClearConsole.Text = "Clear Console";
            buttonClearConsole.UseVisualStyleBackColor = false;
            buttonClearConsole.Click += UI_ClearConsole;
            // 
            // buttonDarkMode
            // 
            buttonDarkMode.Location = new Point(27, 386);
            buttonDarkMode.Name = "buttonDarkMode";
            buttonDarkMode.Size = new Size(146, 40);
            buttonDarkMode.TabIndex = 9;
            buttonDarkMode.Text = "Dark Mode";
            buttonDarkMode.UseVisualStyleBackColor = true;
            buttonDarkMode.Click += UI_DarkMOde;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 6);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 20;
            label1.Text = "V 1.1.3";
            // 
            // button1
            // 
            button1.Location = new Point(179, 432);
            button1.Name = "button1";
            button1.Size = new Size(146, 40);
            button1.TabIndex = 21;
            button1.Text = "Remove OneDrive";
            button1.UseVisualStyleBackColor = true;
            button1.Click += UI_KillOneDrive;
            // 
            // button2
            // 
            button2.Location = new Point(179, 386);
            button2.Name = "button2";
            button2.Size = new Size(146, 40);
            button2.TabIndex = 22;
            button2.Text = "Remove Edge";
            button2.UseVisualStyleBackColor = true;
            button2.Click += UI_EdgeRipper;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(380, 20);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 23;
            label2.Text = "Output:";
            label2.Click += label2_Click;
            // 
            // button3
            // 
            button3.ImageAlign = ContentAlignment.MiddleRight;
            button3.Location = new Point(27, 432);
            button3.Name = "button3";
            button3.Size = new Size(146, 40);
            button3.TabIndex = 24;
            button3.Text = "Install Firefox";
            button3.UseVisualStyleBackColor = true;
            button3.Click += UI_InstallFirefox;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(27, 524);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(290, 15);
            linkLabel1.TabIndex = 26;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://rehoga-interactive.com/windows-11-patcher/";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            linkLabel1.Click += UI_OpenWebsite;
            // 
            // button4
            // 
            button4.Location = new Point(179, 202);
            button4.Name = "button4";
            button4.Size = new Size(146, 40);
            button4.TabIndex = 27;
            button4.Text = "Disable Autoupdates";
            button4.UseVisualStyleBackColor = true;
            button4.Click += UI_StopUpdates;
            // 
            // button5
            // 
            button5.Location = new Point(179, 478);
            button5.Name = "button5";
            button5.Size = new Size(146, 40);
            button5.TabIndex = 28;
            button5.Text = "Remove Cortana";
            button5.UseVisualStyleBackColor = true;
            button5.Click += UI_KillCortana;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 552);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(linkLabel1);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(buttonClearConsole);
            Controls.Add(pictureBox1);
            Controls.Add(buttonKillCopilot);
            Controls.Add(buttonDisableRecall);
            Controls.Add(rtbConsole);
            Controls.Add(buttonDarkMode);
            Controls.Add(buttonApply);
            Controls.Add(buttonPWM);
            Controls.Add(buttonBypassEdge);
            Controls.Add(buttonShowExtensions);
            Controls.Add(buttonTaskBar);
            Controls.Add(buttonExplorer);
            Controls.Add(buttonContextMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Windows 11 Patcher";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonContextMenu;
        private Button buttonExplorer;
        private Button buttonTaskBar;
        private Button buttonShowExtensions;
        private Button buttonBypassEdge;
        private Button buttonPWM;
        private Button buttonApply;
        private RichTextBox rtbConsole;
        private Button buttonDisableRecall;
        private Button buttonKillCopilot;
        private PictureBox pictureBox1;
        private Button buttonClearConsole;
        private Button buttonDarkMode;
        private Label label1;
        private Button button1;
        private Button button2;
        private Label label2;
        private Button button3;
        private LinkLabel linkLabel1;
        private Button button4;
        private Button button5;
    }
}
