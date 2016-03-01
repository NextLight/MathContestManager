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
using MaterialDesignThemes.Wpf;

namespace MathContestManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Team[] teams;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void winMain_Loaded(object sender, RoutedEventArgs e)
        {
            grdStart.Visibility = Visibility.Visible;
            grdInsertTeams.Visibility = Visibility.Hidden;
            grdInsertTasks.Visibility = Visibility.Hidden;
        }
        
        private void btnCreateNewMatch_Click(object sender, RoutedEventArgs e)
        {
            grdStart.Visibility = Visibility.Hidden;
            grdInsertTeams.Visibility = Visibility.Visible;

            itcTeams.Items.Add(new Team());
        }

        private void btnInsertTeams_Click(object sender, RoutedEventArgs e)
        {
            teams = itcTeams.Items.Cast<Team>().ToArray();

            grdInsertTeams.Visibility = Visibility.Hidden;
            grdInsertTasks.Visibility = Visibility.Visible;

            itcTasks.Items.Add(new Solution());
        }

        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            ((TextBox) sender).Focus();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button) sender;
            btn.TryFindParent<ItemsControl>().Items.Remove(btn.DataContext);
        }

        private void btnAddItemTeam_Click(object sender, RoutedEventArgs e)
        {
            itcTeams.Items.Add(new Team());
        }

        private void btnAddItemTask_Click(object sender, RoutedEventArgs e)
        {
            itcTasks.Items.Add(new Solution());
        }

        private void btnInsertTasks_Click(object sender, RoutedEventArgs e)
        {
            Task.SetValues(itcTasks.Items.Cast<Solution>(), 10);
            // TODO: implement ranking DataGrid/ListView
        }
    }
}
