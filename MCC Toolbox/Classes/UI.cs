public class UI
{
    public static void Status(Label input, Form form, string text)
    {
        input.Text = text;
        int x = (form.Size.Width - input.Size.Width) / 2;
        input.Location = new Point(x, input.Location.Y);
    }
    public static void Opacity(Form form, TrackBar slider)
    {
        form.Opacity = slider.Value / (double)100;
    }
    public static void EnableHotKeys(CheckBox hotkeys, Label label, ComboBox comboBox, IntPtr hWnd)
    {
        if (hotkeys.Checked)
        {
            comboBox.Enabled = true;
            label.Enabled = true;
            label.Visible = true;
            PopulateHotkeys(comboBox);
            return;
        }

        Native.UnregisterHotKey(hWnd, 0);
        label.Enabled = false;
        label.Visible = false;
        comboBox.DataSource = null;
        comboBox.Enabled = false;
    }
    public static void SetHotKey(CheckBox hotkeys, ComboBox combobox, Label label, IntPtr hWnd, Form form)
    {
        Native.UnregisterHotKey(hWnd, 0);
        Status(label, form, label.Text = "Press " + combobox.Text + " To Show/Hide Menu!");

        if (combobox.Text == "DELETE")
            Native.RegisterHotKey(hWnd, 0, 0, Keys.Delete.GetHashCode());

        if (combobox.Text == "INSERT")
            Native.RegisterHotKey(hWnd, 0, 0, Keys.Insert.GetHashCode());

        if (combobox.Text == "HOME")
            Native.RegisterHotKey(hWnd, 0, 0, Keys.Home.GetHashCode());
    }
    public static void MoveForm(IntPtr hWnd, MouseEventArgs mouse)
    {
        if (mouse.Button == MouseButtons.Left)
        {
            Native.ReleaseCapture();
            Native.SendMessage(hWnd, Native.WM_NCLBUTTONDOWN, Native.HT_CAPTION, 0);
        }
    }
    public static void PopulateHotkeys(ComboBox comboBox)
    {
        var hotkeys = new List<string>()
        {
            "DELETE",
            "INSERT",
            "HOME"
        };
        comboBox.DataSource = hotkeys;
    }
}

