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
using System.Drawing;



namespace runapp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
       
        public Window1()
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(Window1_Closing);
        }
        private void ShutdownButton1_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridTheTittleBar1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void MaxiButton1_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState  = WindowState.Maximized;
            }
        }

        private void MinButton1_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        int i = 0;
        void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (i == 0)
            {
                // Create a window
                Window2 window = new Window2();

                // Open a window
                window.Show();
            }



        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {

            this.Close();

        }


        // radiobutton gender
        string gender = "F";
        private void rbFemale_Checkchange(object sender, RoutedEventArgs e)
        {

            gender = "F";
        }

        private void rbMale_Checkchange(object sender, RoutedEventArgs e)
        {

            gender = "M";
        }

        //BAZA DANYCH



        private void SubmitButton(object sender, RoutedEventArgs e)
        {
            i = 1;
            
            if ((String.IsNullOrEmpty(passwordBox.Password)) || (String.IsNullOrEmpty(textBoxFirstName.Text)))
            {
                MessageBox.Show("Empty");

            }
            else
            {
                string connectionString = "server=runapp.cba.pl;uid=runapp;pwd=Jenniferlopez2;database=runapp;";

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);

                try
                {

                    if (databaseConnection.State == ConnectionState.Closed)
                        databaseConnection.Open();
                    string result = "SELECT COUNT(1) FROM users WHERE nick=@Username ";
                    MySqlCommand sqlCmd = new MySqlCommand(result, databaseConnection);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@Username", textBoxFirstName.Text);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

                    if (count == 1)
                    {
                        MessageBox.Show("Nick already exist");
                    }
                    else
                    {

                        string query = "INSERT INTO `users` (`nick` , `pass`,`sex`) VALUES (@Username, @Pasword,'"+ gender+"' )";
                        MySqlCommand sqlCmdq = new MySqlCommand(query, databaseConnection);
                        sqlCmdq.CommandType = CommandType.Text;
                        sqlCmdq.Parameters.AddWithValue("@Username", textBoxFirstName.Text);
                        sqlCmdq.Parameters.AddWithValue("@Pasword", passwordBox.Password);
                        int countq = Convert.ToInt32(sqlCmdq.ExecuteScalar());


                        // Create a window
                        MainWindow window = new MainWindow();
                        window.Show();
                        this.Close();



                    }
                }
            


            catch (Exception ex)
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
}
