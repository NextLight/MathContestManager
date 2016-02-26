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
using MahApps.Metro.Controls;

namespace MathContestManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set visibility for all grids
            grdStart.Visibility = Visibility.Visible;
            grdInsertTeams.Visibility = Visibility.Hidden;
            grdInsertProblems.Visibility = Visibility.Hidden;
        }

        private void btnCreateNewMatch_Click(object sender, RoutedEventArgs e)
        {
            //Hide the current grid and show grid to insert teams
            grdStart.Visibility = Visibility.Hidden;
            grdInsertTeams.Visibility = Visibility.Visible;
        }

    }
}
