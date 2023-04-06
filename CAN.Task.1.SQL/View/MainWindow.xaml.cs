using CAN.Task._1.SQL.Core;
using CAN.Task._1.SQL.Model;
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
using CAN.Task._1.SQL.View;

namespace CAN.Task._1.SQL
{
    public partial class MainWindow : Window
    {
        public RegistrationEntities1 db = new RegistrationEntities1();
        public MainWindow()
        {
            InitializeComponent();
            DbModelContext.DB = new RegistrationEntities1();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DbModelContext.DB.Data.Add(new Datum()
                {
                    UserLogin = TbLogin.Text,
                    UserPassword = PbPassword.Password,
                    UserPhone = TbPhone.Text,
                    UserEmail = TbEmail.Text
                });
                DbModelContext.DB.SaveChanges();
                MessageBox.Show("Данные успешно сохранены",
                    "Системное сообщение",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Системное сообщение",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        private void Run_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new InfoWindow().Show();
            Close();
        }
    }
}
