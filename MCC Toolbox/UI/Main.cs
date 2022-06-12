namespace MCC_Toolbox
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message hotkey)
        {
            bool Visible = this.Visible;
            base.WndProc(ref hotkey);

            if (Visible && hotkey.Msg == 0x0312)
            {
                Settings.showDisplay = false;
                this.Visible = false;
                TopMost = false;
            }
            else
            {
                if (!Visible && hotkey.Msg == 0x0312)
                {
                    Settings.showDisplay = true;
                    this.Visible = true;
                    TopMost = true;
                    WindowState = FormWindowState.Normal;
                }
            }
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ControlPanel_MouseMove(object sender, MouseEventArgs mouse)
        {
            UI.MoveForm(Handle, mouse);
        }
        private void TitleLabel_MouseMove(object sender, MouseEventArgs mouse)
        {
            UI.MoveForm(Handle, mouse);
        }
        private void DarkModeBtn_Click(object sender, EventArgs e)
        {
            Colors.DarkMode();
        }
        private void LightModeBtn_Click(object sender, EventArgs e)
        {
            Colors.LightMode();
        }
        private void HotKeysComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UI.SetHotKey(HotkeysCheckBox, HotKeysComboBox, TitleLabel, Handle, this);
        }
        private void HotkeysCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UI.EnableHotKeys(HotkeysCheckBox, TitleLabel, HotKeysComboBox, Handle);
        }
        private void OpacitySlider_Scroll(object sender, EventArgs e)
        {
            UI.Opacity(this, OpacitySlider);
        }
        private void MainColorBtn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.ShowDialog();
            Properties.Settings.Default.main = colorDlg.Color;
            Properties.Settings.Default.Save();
        }
    }
}