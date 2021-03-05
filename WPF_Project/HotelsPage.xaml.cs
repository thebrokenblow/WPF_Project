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
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {
        public HotelsPage()
        {
            InitializeComponent();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DGridHotels.SelectedItems.Cast<Hotel>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {hotelsForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    HotelsEntitiesFramework.GetContext().Hotel.RemoveRange(hotelsForRemoving);
                    HotelsEntitiesFramework.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridHotels.ItemsSource = HotelsEntitiesFramework.GetContext().Hotel.ToList(); //Обращаемся к списку отелей, через контекст
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e) 
        {
            //Menager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Hotel));
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Uri AddEditPage = new Uri("AddEditPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(AddEditPage); //Переход на страницу Добавляения записи об отеле
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                HotelsEntitiesFramework.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridHotels.ItemsSource = HotelsEntitiesFramework.GetContext().Hotel.ToList();
            }
        }
    }
}
