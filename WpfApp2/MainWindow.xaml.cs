using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public bool isokay2 { get; set; } = true;
        List<Grid> gr0 = new List<Grid> { };
        public MainWindow()
        {
            InitializeComponent();
            AddFolder();
            Messagepanel.VerticalAlignment = VerticalAlignment.Bottom;
            num++;
        }
        int num = 1;
        private void del()
        {
            foreach (var item in Messagepanel.Children)
                if (item is Label txt) { Messagepanel.Children.Remove(txt); return; }
        }
        private void TextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Txt_box.Text.Length != 0)
            {
                Txt_box.IsReadOnly = true;
                var textBox = sender as TextBox;
                Label label = new Label();
                if (num == 1) { del(); num--; }
                if (isokay2)
                {
                    Label label2 = new Label();
                    label2.Content = DateTime.Now;
                    label2.Background = Brushes.Yellow;
                    label2.HorizontalAlignment = HorizontalAlignment.Center;
                    label2.VerticalAlignment = VerticalAlignment.Bottom;
                    Messagepanel.Children.Add(label2); num++;
                    if (num == 1) { del(); num--; }
                }
                label.Content = textBox.Text;
                label.Background = Brushes.White;
                label.HorizontalAlignment = HorizontalAlignment.Right;
                label.VerticalAlignment = VerticalAlignment.Bottom;
                Messagepanel.Children.Add(label); num++;
                Txt_box.Text = "";
                isokay2 = false;
                MessageBox.Show("SENT", DateTime.Now.ToString());
            }
           
        }
        private void Txt_box_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.IsReadOnly = false;
                txt.Text = "";
            }
        }
        private void AddFolder()
        {
            foreach (var item in Usergrid.Children)
            {
                if (item is Grid grids)
                    gr0.Add(grids);
            }
        }
        List<Grid> gr1 = new List<Grid> { };
        private bool IsOkay(string text, Grid gri)
        {
            if (Search.Text.Length != 0 && text.IndexOf(Search.Text) != -1)
            {
                gr1.Add(gri);
                return true;
            }
            return false;
        }
        private void beraber()
        {
            Usergrid.Children.Clear();
            foreach (var item in gr0)
            {
                Usergrid.Children.Add(item);
            }
        }
        private void Search_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                if (Search.Text.Length==0)
                {
                    beraber();
                    return;
                }
                gr1.Clear();
                bool boolen = false;
                int nums = 0;
                foreach (Grid item in gr0)
                {
                    foreach (var items in item.Children)
                    {
                        if (items is Label lbl)
                        {
                            if (lbl.FontSize == 18 && IsOkay(lbl.Content.ToString(), item)) {
                                boolen = true; nums++; }
                        }
                    }
                }
                if (boolen)
                {
                    Usergrid.Children.Clear();
                    foreach (var item in gr1)
                    {
                        Usergrid.Children.Add(item);
                        num--;
                    }
                }

            }
        }
        private void Search_MouseLeave(object sender, MouseEventArgs e)
        {
            var TB = sender as TextBox;
            if (TB.Text.Length==0)
            {
                if (TB.Name == "Search") { TB.Text = "Username";beraber();}
                else TB.Text = "Write a message...";
            }
        }
    }
}
