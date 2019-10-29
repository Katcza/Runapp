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
        int i;
        void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (i == 1)
            {
                // Create a window
                Window2 window = new Window2();

                // Open a window
                window.Show();
            }

            if (i == 0)
            {
                // Create a window
                MainWindow window = new MainWindow();

                // Open a window
                window.Show();
            }

        }
        private void SubmitButton(object sender, RoutedEventArgs e)
        {
            i = 0;

            this.Close();                  

        }
        private void LoginButton(object sender, RoutedEventArgs e)
        {
            i = 1;

            this.Close();

        }

    }
}
