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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Hotel currentHotel = new Hotel();
        public AddEditPage()
        {
            InitializeComponent();
            DataContext = currentHotel;
            ComboCountry.ItemsSource = HotelsEntitiesFramework.GetContext().Сountry.ToList();
            ComboCity.ItemsSource = HotelsEntitiesFramework.GetContext().City.ToList();
        }
        /// <summary>
        /// Логика взаимодействия обработки события нажатия на кнопку сохранения изменений
        /// </summary>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentHotel.nameOfHotel))
            {
                textBoxNameOfHotel.ToolTip = "Enter The Name Of The Hotel"; //ToolTip - подсказка при наведении на поле   
                var backgroundColor = new BrushConverter(); //создание объекта на основе BrushConverter и выделением под него память 
                textBoxNameOfHotel.Background = (Brush)backgroundColor.ConvertFrom("#ff5e5b"); //изменение задего фона при неправельных введённых данных
            }
            else
            {
                textBoxNameOfHotel.Background = Brushes.Transparent; //Transparent - очищение заднего фона текстового блока
                textBoxNameOfHotel.ToolTip = null; //очищаем подсказку
                if (currentHotel.countOfStars < 1 || currentHotel.countOfStars > 5)
                {
                    textBoxCountOfStars.ToolTip = "Enter The Number Of Stars 1 to 5";
                    var backgroundColor = new BrushConverter();
                    textBoxCountOfStars.Background = (Brush)backgroundColor.ConvertFrom("#ff5e5b");
                }
                else
                {
                    textBoxCountOfStars.Background = Brushes.Transparent;
                    textBoxCountOfStars.ToolTip = null;
                    if (string.IsNullOrWhiteSpace(currentHotel.address))
                    {
                        textBoxAddressOfHotel.ToolTip = "Enter The Address Of The Hotel";
                        var backgroundColor = new BrushConverter();
                        textBoxAddressOfHotel.Background = (Brush)backgroundColor.ConvertFrom("#ff5e5b");
                    }
                    else
                    {
                        textBoxAddressOfHotel.Background = Brushes.Transparent;
                        textBoxAddressOfHotel.ToolTip = null;
                        if (string.IsNullOrWhiteSpace(currentHotel.phoneNumber))
                        {
                            textBoxPhoneNumber.ToolTip = "Enter The Hotel's Phone Number";
                            var backgroundColor = new BrushConverter();
                            textBoxPhoneNumber.Background = (Brush)backgroundColor.ConvertFrom("#ff5e5b");
                        }
                        else
                        {
                            textBoxPhoneNumber.Background = Brushes.Transparent;
                            textBoxPhoneNumber.ToolTip = null;
                            if (string.IsNullOrWhiteSpace(currentHotel.hotelDescription))
                            {
                                textBoxHotelDescription.ToolTip = "Enter A Description Of The Hotel";
                                var backgroundColor = new BrushConverter();
                                textBoxHotelDescription.Background = (Brush)backgroundColor.ConvertFrom("#ff5e5b");
                            }
                            else
                            {
                                textBoxHotelDescription.Background = Brushes.Transparent;
                                textBoxHotelDescription.ToolTip = null;
                                HotelsEntitiesFramework.GetContext().Hotel.Add(currentHotel);
                                try
                                {
                                    HotelsEntitiesFramework.GetContext().SaveChanges();
                                    MessageBox.Show("Informations Saved");
                                    Uri AddEditPage = new Uri("HotelsPage.xaml", UriKind.Relative);
                                    this.NavigationService.Navigate(AddEditPage); //Переход на страницу списка информации об отелях
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.ToString());
                                }
                            }
                        }
                    }
                }
            }
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Uri AddEditPage = new Uri("HotelsPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(AddEditPage);  //Переход на страницу списка информации об отелях
        }
    }
}