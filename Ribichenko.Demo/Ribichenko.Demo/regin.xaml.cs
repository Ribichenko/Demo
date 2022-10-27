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
    /// Логика взаимодействия для regin.xaml
    /// </summary>
    public partial class regin : Page
    {
        public MainWindow mainWindow; //ссылка на форму MainWindow
        public regin(MainWindow _mainWindow) //принимаем ссылку форму
        {
            InitializeComponent();
            mainWindow = _mainWindow; //запоминаем ссылку на форму
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.login); //переход на страницу авторизации
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            //проверка на заполняемость полей
            if (textBox_login.Text.Length > 0) // проверяем логин
            {
                if (password.Password.Length > 0) // проверяем пароль
                {
                    if (password_Copy.Password.Length > 0) // проверяем второй пароль
                    {


                    }
                    else
                    {
                        MessageBox.Show("Повторите пароль", "Пароль", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Укажите пароль", "Пароль", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Укажите логин", "Логин", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            if (textBox_login.Text.Length >= 3 && textBox_login.Text.Length <= 15)
            {
                for (int i = 0; i < textBox_login.Text.Length; i++) // перебираем символы
                {
                    if (textBox_login.Text[i] <= 'я' && textBox_login.Text[i] >= 'а' || textBox_login.Text[i] >= 'А' && textBox_login.Text[i] <= 'Я') // если русская раскладка
                    {
                        MessageBox.Show("Доступна только английская раскладка", "Логин", MessageBoxButton.OK, MessageBoxImage.Error); // выводим сообщение
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Минимум 3 символа и максимум 15", "Логин" , MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //далее проверка пароля
            //должно быть 6 или более символов;
            //допускается только английская раскладка;
            if (password.Password.Length >= 6)
            {
                for (int i = 0; i < password.Password.Length; i++) // перебираем символы
                {
                    if (password.Password[i] <= 'я' && password.Password[i] >= 'а' || password.Password[i] >= 'А' && password.Password[i] <= 'Я') // если русская раскладка
                    {
                        MessageBox.Show("Доступна только английская раскладка", "Пароль", MessageBoxButton.OK, MessageBoxImage.Error); // выводим сообщение
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Пароль слишком короткий, минимум 6 символов", "Пароль", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (password.Password == password_Copy.Password) // проверка на совпадение паролей
            {
                //SqlCommand cmd = new SqlCommand("INSERT INTO [users] ([login], [password]) VALUES (@login, @password)");
                DataTable dt_user = mainWindow.Select("INSERT INTO [dbo].[users] ([login], [password]) VALUES ('" + textBox_login.Text + "', '" + password.Password + "')"); //добавление новой записи в таблицу users
                MessageBox.Show("Пользователь успешно зарегистрирован", "Успешно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                mainWindow.OpenPage(MainWindow.pages.login); //переход на страницу авторизации
            }
            else MessageBox.Show("Пароли не совпадают", "Пароль", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
    }
}
