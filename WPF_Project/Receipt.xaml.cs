using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace WPF_Project
{
    /// <summary>
    /// Логика взаимодействия для Receipt.xaml
    /// </summary>
    public partial class Receipt : Page
    {
        public Receipt()
        {
            InitializeComponent();
            using (var context = new CourseProjectEntitiesDataBase())
            {
                nameOfUser.Text = context.Users.Where(x => x.id == InfoOfUsers.userInfo.id).Select(x => x.name).FirstOrDefault()?.ToString(); ;
                surnameOfUsers.Text = context.Users.Where(x => x.id == InfoOfUsers.userInfo.id).Select(x => x.surname).FirstOrDefault()?.ToString(); ;
                emailOfUsers.Text = context.Users.Where(x => x.id == InfoOfUsers.userInfo.id).Select(x => x.email).FirstOrDefault()?.ToString();
                phoneOfUsers.Text = context.Users.Where(x => x.id == InfoOfUsers.userInfo.id).Select(x => x.phoneNumber).FirstOrDefault()?.ToString();
            }
            dateOfBegin.Text = informationAboutHotel.dataBegin.ToString("M");
            dateOfEnd.Text = informationAboutHotel.dataEnd.ToString("M");
            numberOfAdults.Text = informationAboutHotel.countOfAdults.ToString();
            numberOfChildren.Text = informationAboutHotel.countOfChildren.ToString();
            numberOfRomms.Text = informationAboutHotel.countOfRooms.ToString();
            adressOfHotel.Text = "Adress Of Hotel: " + InfoOfHotel.address;
            nameOfHotel.Text = "Name Of Hotel: " + InfoOfHotel.name;
            phoneOfHotel.Text = "Phone: " + InfoOfHotel.phone;
            countOfStars.Text = "Stars: " + InfoOfHotel.stars.ToString();
            country.Text = "Contry: " + informationAboutHotel.Country;
            city.Text = "City: " + informationAboutHotel.City;
            typeOfRoom.Text = InfoTypeOfRoom.name;
            pricePerDay.Text = InfoTypeOfRoom.price.ToString(".00", CultureInfo.InvariantCulture);
            finalPrice.Text = (informationAboutHotel.countOfRooms * InfoTypeOfRoom.price * System.Convert.ToDecimal(((informationAboutHotel.dataEnd - 
                informationAboutHotel.dataBegin).TotalDays))).
                ToString(".00", CultureInfo.InvariantCulture);
            date.Text = informationAboutHotel.dataBegin.ToString("M") + informationAboutHotel.dataEnd.ToString("M");
            totalPrice.Text = (informationAboutHotel.countOfRooms * InfoTypeOfRoom.price * System.Convert.ToDecimal(((informationAboutHotel.dataEnd -
                informationAboutHotel.dataBegin).TotalDays))).
                ToString(".00", CultureInfo.InvariantCulture);
        }
    }
}