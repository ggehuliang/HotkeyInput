using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Shortcut;
using static System.Windows.Clipboard;
using System.Configuration;
using System.Reflection;

namespace HotkeyInput
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBox1.Text = ConfigurationManager.AppSettings["text1"];
            textBox2.Text = ConfigurationManager.AppSettings["text2"];
            textBox3.Text = ConfigurationManager.AppSettings["text3"];
            textBox4.Text = ConfigurationManager.AppSettings["text4"];
            textBox5.Text = ConfigurationManager.AppSettings["text5"];
            textBox6.Text = ConfigurationManager.AppSettings["text6"];
            try
            {
                checkBox.IsChecked = bool.Parse(ConfigurationManager.AppSettings["tabafterinput"]);
                checkBox2.IsChecked = bool.Parse(ConfigurationManager.AppSettings["topmost"]);
            }
            catch
            {
                checkBox.IsChecked = true;
                checkBox2.IsChecked = false;
            }
            RegHotkeys();
        }
        private void RegHotkeys()
        {
            _hotkeyBinder.Bind(Modifiers.Control, Keys.D1).To(HotkeyCallback1);
            _hotkeyBinder.Bind(Modifiers.Control, Keys.D2).To(HotkeyCallback2);
            _hotkeyBinder.Bind(Modifiers.Control, Keys.D3).To(HotkeyCallback3);
            _hotkeyBinder.Bind(Modifiers.Control, Keys.D4).To(HotkeyCallback4);
            _hotkeyBinder.Bind(Modifiers.Control, Keys.D5).To(HotkeyCallback5);
            _hotkeyBinder.Bind(Modifiers.Control, Keys.D6).To(HotkeyCallback6);
        }
        // Declare and instantiate the HotkeyBinder.
        private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();

        // Declare the callback that you would like Shortcut to invoke when 
        // the specified system-wide hotkey is pressed.
        public const int KEYEVENTF_KEYUP = 2;
        private void HotkeyCallback1()
        {
            System.Windows.Clipboard.SetText(textBox1.Text);
            keybd_event(Keys.ControlKey, 0, 0, 0);
            keybd_event(Keys.A, 0, 0, 0);
            keybd_event(Keys.V, 0, 0, 0);
            keybd_event(Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
            if (checkBox.IsChecked==true) { keybd_event(Keys.Tab, 0, 0, 0); }
            keybd_event(Keys.ControlKey, 0, 0, 0);
        }
        private void HotkeyCallback2()
        {
            System.Windows.Clipboard.SetText(textBox2.Text);
            keybd_event(Keys.ControlKey, 0, 0, 0);
            keybd_event(Keys.A, 0, 0, 0);
            keybd_event(Keys.V, 0, 0, 0);
            keybd_event(Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
            if (checkBox.IsChecked == true) { keybd_event(Keys.Tab, 0, 0, 0); }
            keybd_event(Keys.ControlKey, 0, 0, 0);
        }
        private void HotkeyCallback3()
        {
            System.Windows.Clipboard.SetText(textBox3.Text);
            keybd_event(Keys.ControlKey, 0, 0, 0);
            keybd_event(Keys.A, 0, 0, 0);
            keybd_event(Keys.V, 0, 0, 0);
            keybd_event(Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
            if (checkBox.IsChecked == true) { keybd_event(Keys.Tab, 0, 0, 0); }
            keybd_event(Keys.ControlKey, 0, 0, 0);
        }
        private void HotkeyCallback4()
        {
            System.Windows.Clipboard.SetText(textBox4.Text);
            keybd_event(Keys.ControlKey, 0, 0, 0);
            keybd_event(Keys.A, 0, 0, 0);
            keybd_event(Keys.V, 0, 0, 0);
            keybd_event(Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
            if (checkBox.IsChecked == true) { keybd_event(Keys.Tab, 0, 0, 0); }
            keybd_event(Keys.ControlKey, 0, 0, 0);
        }
        private void HotkeyCallback5()
        {
            System.Windows.Clipboard.SetText(textBox5.Text);
            keybd_event(Keys.ControlKey, 0, 0, 0);
            keybd_event(Keys.A, 0, 0, 0);
            keybd_event(Keys.V, 0, 0, 0);
            keybd_event(Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
            if (checkBox.IsChecked == true) { keybd_event(Keys.Tab, 0, 0, 0); }
            keybd_event(Keys.ControlKey, 0, 0, 0);
        }
        private void HotkeyCallback6()
        {
            System.Windows.Clipboard.SetText(textBox6.Text);
            keybd_event(Keys.ControlKey, 0, 0, 0);
            keybd_event(Keys.A, 0, 0, 0);
            keybd_event(Keys.V, 0, 0, 0);
            keybd_event(Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
            if (checkBox.IsChecked == true) { keybd_event(Keys.Tab, 0, 0, 0); }
            keybd_event(Keys.ControlKey, 0, 0, 0);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["text1"].Value = textBox1.Text;
                cfa.AppSettings.Settings["text2"].Value = textBox2.Text;
                cfa.AppSettings.Settings["text3"].Value = textBox3.Text;
                cfa.AppSettings.Settings["text4"].Value = textBox4.Text;
                cfa.AppSettings.Settings["text5"].Value = textBox5.Text;
                cfa.AppSettings.Settings["text6"].Value = textBox6.Text;
                if (checkBox.IsChecked == true) { cfa.AppSettings.Settings["tabafterinput"].Value = "True"; } else { cfa.AppSettings.Settings["tabafterinput"].Value = "False"; }
                if (checkBox2.IsChecked == true) { cfa.AppSettings.Settings["topmost"].Value = "True"; } else { cfa.AppSettings.Settings["topmost"].Value = "False"; }
                cfa.Save(); ConfigurationManager.RefreshSection("appSettings");

                ConfigurationManager.RefreshSection("appSettings");
                System.Windows.MessageBox.Show("保存成功！");
            }
            catch
            {
                string name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".1.config";
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.Stream stream = assembly.GetManifestResourceStream(name);
                stream.Position = 0;
                StreamReader reader = new StreamReader(stream);
                string text = reader.ReadToEnd();
                string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "HotkeyInput.exe.config";
                FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                fs.SetLength(0);
                sw.Write(text);
                sw.Close();
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["text1"].Value = textBox1.Text;
                cfa.AppSettings.Settings["text2"].Value = textBox2.Text;
                cfa.AppSettings.Settings["text3"].Value = textBox3.Text;
                cfa.AppSettings.Settings["text4"].Value = textBox4.Text;
                cfa.AppSettings.Settings["text5"].Value = textBox5.Text;
                cfa.AppSettings.Settings["text6"].Value = textBox6.Text;
                if (checkBox.IsChecked == true) { cfa.AppSettings.Settings["tabafterinput"].Value = "True"; } else { cfa.AppSettings.Settings["tabafterinput"].Value = "False"; }
                if (checkBox2.IsChecked == true) { cfa.AppSettings.Settings["topmost"].Value = "True"; } else { cfa.AppSettings.Settings["topmost"].Value = "False"; }
                cfa.Save(); ConfigurationManager.RefreshSection("appSettings");

                ConfigurationManager.RefreshSection("appSettings");
                System.Windows.MessageBox.Show("保存成功！");
            }
        }

        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        private void checkBox2_OnClick(object sender, RoutedEventArgs e)
        {
            if (checkBox2.IsChecked == true)
            {
                mainWindow.Topmost = true;

            }
            else
            {
                mainWindow.Topmost = false;
            }

        }

        private void label1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://wkkun.tech");
        }
    }
}
