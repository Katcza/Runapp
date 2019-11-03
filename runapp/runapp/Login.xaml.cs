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
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;


namespace runapp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            
        }
        private void ShutdownButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridTheTittleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void MaxiButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

       
        private void SubmitButton(object sender, RoutedEventArgs e)
        {

            this.Close();
        }


        //BAZA DANYCH


        private void OK(object sender, RoutedEventArgs e)
        {

            string connectionString = "server=runapp.cba.pl;uid=runapp;pwd=Jenniferlopez2;database=runapp;";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            try
            {
                if (databaseConnection.State == ConnectionState.Closed)
                    databaseConnection.Open();
                string query = "SELECT COUNT(1) FROM users WHERE nick=@Username AND pass=@Pasword";
                MySqlCommand sqlCmd = new MySqlCommand(query,databaseConnection);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", textBoxFirstName.Text);
                sqlCmd.Parameters.AddWithValue("@Pasword", passwordBox.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    // Create a window
                    MainWindow window = new MainWindow();
                    window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nick or password wrong");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                databaseConnection.Close();

            }


        }
    }
}


