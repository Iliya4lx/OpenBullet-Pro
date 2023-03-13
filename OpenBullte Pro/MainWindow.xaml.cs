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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenBullte_Pro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CheckUser();
        }

        #region Public Valus
        private bool IsOpenMenu = false;
        #endregion

        #region Title
        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton is MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaxi_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState is WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Main

        #endregion

        #region Tab Menu

        private async void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            await OpenMenu();
        }
        private async void TabMenuBackBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            await OpenMenu();
        }

        #endregion

        #region Public Method
        private async Task OpenMenu()
        {
            if (IsOpenMenu is false)
            {
                IsOpenMenu = true;

                TabMenuBackBorder.Visibility = Visibility.Visible;

                var A1 = new ThicknessAnimation()
                {
                    From = new Thickness(-250, 0, 0, 0),
                    To = new Thickness(0),
                    SpeedRatio = 5
                };

                var A2 = new DoubleAnimation()
                {
                    From = 0,
                    To = 0.2,
                    SpeedRatio = 5
                };

                TabMenuBorder.BeginAnimation(Border.MarginProperty, A1);
                TabMenuBackBorder.BeginAnimation(Border.OpacityProperty, A2);
            }
            else
            {
                IsOpenMenu = false;

                var A1 = new ThicknessAnimation()
                {
                    From = new Thickness(0),
                    To = new Thickness(-250, 0, 0, 0),
                    SpeedRatio = 4
                };

                var A2 = new DoubleAnimation()
                {
                    From = 0.2,
                    To = 0,
                    SpeedRatio = 4
                };

                TabMenuBorder.BeginAnimation(Border.MarginProperty, A1);
                TabMenuBackBorder.BeginAnimation(Border.OpacityProperty, A2);

                await Task.Delay(400);

                TabMenuBackBorder.Visibility = Visibility.Collapsed;
            }
        }
        private void CheckUser()
        {
            if(lblUserName.Text.Length > 10)
            {
                var NewUser = lblUserName.Text.Substring(0, 10) + "...";

                lblUserName.Text = NewUser;
            }
        }
        #endregion

    }
}
