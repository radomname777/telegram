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
        public MainWindow()
        {
            InitializeComponent();
            Messagepanel.VerticalAlignment = VerticalAlignment.Bottom;
            num++;
        }

        int num = 1;
        private void del()
        {
            foreach (var item in Messagepanel.Children)
                if (item is Label txt){Messagepanel.Children.Remove(txt); return; }
        }
        private void TextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter&&isokay&& Txt_box.Text.Length!=0)
            {
                var textBox = sender as TextBox;
                if (num == 1){del();num--;}
                Label label = new Label();
                label.Content = textBox.Text;
                label.Background = Brushes.White;
                label.HorizontalAlignment = HorizontalAlignment.Right;
                label.VerticalAlignment = VerticalAlignment.Bottom;
                Messagepanel.Children.Add(label);num++;
                Txt_box.Text = "";
            }
            else if(!isokay) Txt_box.Text = "Write a message...";

        }
        private void Txt_box_MouseMove(object sender, MouseEventArgs e)
        {
            isokay = true;
            Txt_box.Text = "";
        }
        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (Txt_box.Text.Length == 0)Txt_box.Text = "Write a message...";
            isokay = false;
        }
        int num2 = 0;
        private List<Label> Search_Grid(Grid a, string data)
        {
            List<Label> list = new List<Label>();
            foreach (var item in a.Children)
            {
              //  MessageBox.Show(item.ToString());
                if (item is Label lbl)
                {
                    //   MessageBox.Show(lbl.Content.ToString());
                    if (lbl.FontSize == 18)
                    {
                      //  MessageBox.Show(lbl.Content.ToString());
                        string str = lbl.Content.ToString();
                        if (str.IndexOf(data) != -1)
                        {

                            num2++;
                            list.Add(lbl);
                           
                            // MessageBox.Show(num2.ToString());
                        }
                        else
                        {
                            // MessageBox.Show(str.IndexOf(data).ToString());
                        }

                    }
                    //else { }
                    //MessageBox.Show("a");
                }
            }
         

            return list;
        }
        private void Search_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            List<Label> list = new List<Label>();
            Grid a = new Grid();
            a = Usergrid;

            //Gogrid.Children.Remove(Usergrid);
            //Usergrid.Children.Clear();
            foreach (var item in Usergrid.Children)
            {
                if (item is Label l)
                {
                    Usergrid.Children.Remove(l);

                }
            }
            if (Search.Text.Length != 0)
            {

                list = Search_Grid(a, Search.Text);
            }
            foreach (var item in list)
            {
                if (item is Label l )
                {
                    Usergrid.Children.Add(l);
                }
            }
            Gogrid.Children.Add(Usergrid);
            //    foreach (var item in list)
            //    {
            //        MessageBox.Show(item.ToString());
            //        Usergrid.Children.Add(item);
            //    }
            //}
           // MessageBox.Show("a");
            //Thread.Sleep(1000);
            //Gogrid.Children.Add(a);
            //foreach (var item in Usergrid.Children)
            //{
            //    list.Add
            //}
        }
    }
}
