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
        public bool isokay { get; set; } = false;
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
            if (e.Key == Key.Enter && isokay && Txt_box.Text.Length != 0)
            {
                var textBox = sender as TextBox;
                if (num == 1) { del(); num--; }
                Label label = new Label();
                label.Content = textBox.Text;
                label.Background = Brushes.White;
                label.HorizontalAlignment = HorizontalAlignment.Right;
                label.VerticalAlignment = VerticalAlignment.Bottom;
                Messagepanel.Children.Add(label); num++;
                Txt_box.Text = "";
            }
            else if (!isokay) Txt_box.Text = "Write a message...";

        }
        private void Txt_box_MouseMove(object sender, MouseEventArgs e)
        {
            isokay = true;
            Txt_box.Text = "";
        }
        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (Txt_box.Text.Length == 0) Txt_box.Text = "Write a message...";
            isokay = false;
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
    }
}
