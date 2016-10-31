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

namespace MathContestManager
{
    /// <summary>
    /// Logica di interazione per StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        MainWindow parentWindow;

        public StartPage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            parentWindow = (MainWindow)Window.GetWindow(this);
        }

        private void btnCreateNewMatch_Click(object sender, RoutedEventArgs e)
        {
            parentWindow.frmContainer.Navigate(new InsertTeamsPage());
        }

    }
}
