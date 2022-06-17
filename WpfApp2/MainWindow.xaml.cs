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

namespace WpfApp2
{

    public partial class MainWindow : Window
    {
        public bool isokay { get; set; } = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        int num = 1;
        private void del()
        {
            foreach (var item in Messagepanel.Children)
            {
                if (item is Label txt){Messagepanel.Children.Remove(txt); return; }
            }
        }
        private void TextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            //if (isokay) { Txt_box.Text = "";Txt_box.Text = textBox.Text; }; 

            if (e.Key == Key.Enter&&isokay)
            {
                if (num == 13){del();num--;}
                Label label = new Label();
                label.Content = textBox.Text;
                label.Background = Brushes.Transparent;
                label.HorizontalAlignment = HorizontalAlignment.Right;
                label.VerticalAlignment = VerticalAlignment.Top;
                Messagepanel.Children.Add(label);num++;
                    Txt_box.Text = "";
                isokay = false;
            }
            else if(e.Key != Key.Enter) isokay = true;
  
        }

        private void Txt_box_MouseMove(object sender, MouseEventArgs e)
        {
            Txt_box.Text = "";
        }

        private void Txt_box_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("a");
            Txt_box.Text = "";
        }

        private void Txt_box_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Txt_box.Text.Length==0)
            {
                Txt_box.Text = "Write a message...";
            }
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (Txt_box.Text.Length == 0)
            {
                Txt_box.Text = "Write a message...";
            }
        }
    }
}
