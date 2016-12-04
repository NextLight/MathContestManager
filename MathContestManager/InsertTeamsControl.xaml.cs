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
    /// Interaction logic for InsertTeamsControl.xaml
    /// </summary>
    public partial class InsertTeamsControl : View
    {
        public InsertTeamsControl()
        {
            InitializeComponent();
        }
        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            itcTeams.Items.Add(new ContestTeam());
        }

        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Focus();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            btn.TryFindParent<ItemsControl>().Items.Remove(btn.DataContext);
        }

        private void btnAddItemTeam_Click(object sender, RoutedEventArgs e)
        {
            itcTeams.Items.Add(new ContestTeam());
        }

        private void btnInsertTeams_Click(object sender, RoutedEventArgs e)
        {
            OnViewFinished(itcTeams.Items.Cast<ContestTeam>());
        }
    }
}
