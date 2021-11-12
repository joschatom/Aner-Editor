using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Aner_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] Text = new string[]
        {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
        };
        int text_couter = 0;
        DispatcherTimer history_timer = new DispatcherTimer();
        object[] mata_histrory = new object[] { 
            null,
            null,
            null,
            null,
            null,
            null,
            null
        };
        string old;
        public MainWindow()
        {
            InitializeComponent();
            history_timer.Interval = TimeSpan.FromSeconds(6);
            history_timer.Tick += update_history;
            history.Foreground = history.Background;
            history_timer.Start();
        }

        private void update_history(object? sender, EventArgs e)
        {
            this.Text[this.text_couter] = editor.Text;
            if (text_couter == editor.Text.Length) text_couter = 0;

            if (text_couter == 0) {
                history.Text = "----HISORY-----";
                for (int i = 0; i < Text.Length; i++)
                {
                    Text[i] = "";
                }
                text_couter++;
            }
            else if (Text[text_couter] != "" && old != Text[text_couter])
            {
                history.Text += "\n" + Text[text_couter] + "\n***********************************";
                old = Text[text_couter];
                text_couter++;
            }
            
        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Text[this.text_couter] = editor.Text;
            if (text_couter == editor.Text.Length) text_couter = 0;
        }

        private void history_MouseEnter(object sender, MouseEventArgs e)
        {
            mata_histrory[0] = history.Height;
            mata_histrory[1] = history.Width;
            mata_histrory[2] = history.Margin;
            history.Foreground = Brushes.White;
            history.Height = editor.Height;
            history.Width = editor.Width;
            history.Margin = new Thickness(20, 20, 20, 20);
        }

        private void history_MouseLeave(object sender, MouseEventArgs e)
        {
            history.Foreground = history.Background;
            history.Height = (double)mata_histrory[0];
            history.Width = (double)mata_histrory[1];
            history.Margin = (Thickness)mata_histrory[2];
        }

        private void menu_file_save_Click(object sender, RoutedEventArgs e)
        {
            save save = new save(editor.Text);
            save.ShowDialog();
        }

        private void menu_file_saveas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menu_file_quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }
    }
}
