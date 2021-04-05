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

namespace WPF_Project
{
    /// <summary>
    /// Логика взаимодействия для Page.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            DateTime date = DateTime.Now;
            Calendar.DisplayDateStart = date;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var f = Calendar.SelectedDates.OrderBy(k => k).First();
            var l = Calendar.SelectedDates.OrderBy(k => k).Last();
            MessageBox.Show(f.ToString() + ':' + l.ToString());
        }
    }
}
