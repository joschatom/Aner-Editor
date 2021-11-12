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
using System.Windows.Shapes;
using System.IO;

namespace Aner_Editor
{
    /// <summary>
    /// Interaktionslogik für save.xaml
    /// </summary>
    public partial class save : Window
    {
        string Text { get; set; }
        public save(string text)
        {
            InitializeComponent();
            this.Text = text;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(PATH.Text + FILE.Text, this.Text);
            this.Close();
        }
    }
}
