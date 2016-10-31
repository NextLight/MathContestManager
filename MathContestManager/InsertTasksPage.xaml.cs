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
    /// Logica di interazione per InsertTasksPage.xaml
    /// </summary>
    public partial class InsertTasksPage : Page
    {
        MainWindow parentWindow;

        public InsertTasksPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            parentWindow = Window.GetWindow(this) as MainWindow;
            itcTasks.Items.Add(new Solution());
        }

        private void btnAddItemTask_Click(object sender, RoutedEventArgs e)
        {
            itcTasks.Items.Add(new Solution());
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
            Task.SetValues(itcTasks.Items.Cast<Solution>(), 10);

            // Create an instance for tasks in every team
            List<Task> tmpList = new Task[itcTasks.Items.Count].Select((x, i) => new Task(i)).ToList();
            parentWindow.cm.Teams = parentWindow.cm.Teams.Select((x, i) => new Team() { Name = x.Name, Tasks = tmpList.ToList() }).ToList(); //TODO: try to do this in a better way

            new RankingWindow(parentWindow.cm).Show();
        }
    }
}
