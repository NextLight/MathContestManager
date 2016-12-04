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
    /// Logica di interazione per InsertTasksControl.xaml
    /// </summary>
    public partial class InsertTasksControl : UserControl
    {
        MainWindow parentWindow;

        public InsertTasksControl()
        {
            InitializeComponent();
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            parentWindow = Window.GetWindow(this) as MainWindow;
            itcTasks.Items.Add(new ContestTask());
        }

        private void btnAddItemTask_Click(object sender, RoutedEventArgs e)
        {
            itcTasks.Items.Add(new ContestTask());
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

        private void btnInsertTasks_Click(object sender, RoutedEventArgs e)
        {
            parentWindow.cm.Tasks = itcTasks.Items.Cast<ContestTask>() ;

            new RankingWindow(parentWindow.cm).Show();
        }
    }
}
