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
using System.Data;
using System.Data.SqlClient;

namespace Ribichenko.Demo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OpenPage(pages.login);
        }
        public enum pages
        {
            login,
            regin
        }
        public void OpenPage(pages pages) //функция открытия окон
        {
            if (pages == pages.login) //если форма открытия логин
            {
                frame.Navigate(new login(this)); //открываем форму логин
            } 
            else if (pages == pages.regin)
            {
                frame.Navigate(new regin(this));
            }
        }
        public DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase"); //создаем таблицу в приложении
            SqlConnection sqlConnection = new SqlConnection(@"server=DESKTOP-JKM5QPN\STP;Trusted_Connection=Yes;DataBase=Rib;");
            sqlConnection.Open(); //открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand(); //создаем команду
            sqlCommand.CommandText = selectSQL; //присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); //создаем обработчик
            sqlDataAdapter.Update(dataTable);
            sqlDataAdapter.Fill(dataTable); //возвращаем таблицу с результатом
            return dataTable;
        }
    }
}
