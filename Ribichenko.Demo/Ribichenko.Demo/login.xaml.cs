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

namespace Ribichenko.Demo
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class login : Page
    {
        public MainWindow mainWindow; //ссылка на форму MainWindow
        public login(MainWindow _mainWindow) //принимаем ссылку форму
        {
            InitializeComponent();

            mainWindow = _mainWindow; //запоминаем ссылку на форму
        }

        private void enter_Click(object sender, RoutedEventArgs e) //функция входа
        {
            if (textBox_login.Text.Length > 0) // проверяем введён ли логин     
            {
                if (password.Password.Length > 0) // проверяем введён ли пароль         
                {             // ищем в базе данных пользователя с такими данными         
                    DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[users] WHERE [login] = '" + textBox_login.Text + "' AND [password] = '" + password.Password + "'");
                    if (dt_user.Rows.Count > 0) // если такая запись существует       
                    {
                        MessageBox.Show("Пользователь авторизовался", "Успешно", MessageBoxButton.OK, MessageBoxImage.Asterisk); // говорим, что авторизовался
                        NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                    }
                    else MessageBox.Show("Пользователя не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); // выводим ошибку  
                }
                else MessageBox.Show("Введите пароль", "Пароль", MessageBoxButton.OK, MessageBoxImage.Error); // выводим ошибку    
            }
            else MessageBox.Show("Введите логин", "Логин", MessageBoxButton.OK, MessageBoxImage.Error); // выводим ошибку 
        }

        // функция открытия регистрации 
        private void regin_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.regin);
        }
    }
}
