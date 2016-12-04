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
        public ContestManager cm = new ContestManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void winMain_Loaded(object sender, RoutedEventArgs e)
        {
            ccMain.Content = new StartControl();
            ((View)ccMain.Content).ViewFinished += StartControl_ViewFinished;
        }

        private void StartControl_ViewFinished(object sender, ViewFinishedEventArgs e)
        {
            if((string)e.Data == "create")
            {
                ccMain.Content = new InsertTeamsControl();
                ((View)ccMain.Content).ViewFinished += InsertTeams_ViewFinished;
            }
        }
        private void InsertTeams_ViewFinished(object sender, ViewFinishedEventArgs e)
        {
            cm.Teams = (IEnumerable<ContestTeam>)e.Data;
            ccMain.Content = new InsertTasksControl();
            ((View)ccMain.Content).ViewFinished += InsertTasks_ViewFinished;
        }

        private void InsertTasks_ViewFinished(object sender, ViewFinishedEventArgs e)
        {
            cm.Tasks = (IEnumerable<ContestTask>)e.Data;
            new RankingWindow(cm).Show();
        }
    }
}
