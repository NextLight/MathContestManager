﻿using System;
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
        // Counter for buttons in InsertTeams listbox
        int AddLineTeamListBoxCounter = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void winMain_Loaded(object sender, RoutedEventArgs e)
        {
            // Set visibility for all grids
            grdStart.Visibility = Visibility.Visible;
            grdInsertTeams.Visibility = Visibility.Hidden;
            grdInsertProblems.Visibility = Visibility.Hidden;
        }

        private void btnCreateNewMatch_Click(object sender, RoutedEventArgs e)
        {
            // Hide the current grid and show grid to insert teams
            grdStart.Visibility = Visibility.Hidden;
            grdInsertTeams.Visibility = Visibility.Visible;

            // Insert the first element in team listbox
            AddLineTeamListBox();
        }

        private void AddLineTeamListBox()
        {

            if (lstInsertTeams.Items.Count == 0)
                lstInsertTeams.Items.Add(null);

            // Create grid to contain all controls in a line
            Grid grdTemp = new Grid() { HorizontalAlignment = HorizontalAlignment.Stretch, Margin = new Thickness(0) };

            // Create a textbox to insert the team name
            TextBox txtTemp = new TextBox() {HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10), Height = 40, Width = 100};
            TextFieldAssist.SetHint(txtTemp, "Team name");
            txtTemp.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;

            // Create new button to remove the line
            Button btnTemp = new Button(){IsTabStop = false,  Name = String.Format("btn{0}", AddLineTeamListBoxCounter), Content = "X", Margin = new Thickness(200, 0, 0, 0), HorizontalAlignment = HorizontalAlignment.Left};
            AddLineTeamListBoxCounter++;
            btnTemp.Click += btnRemoveTeamLine_Click;

            // Add controls to the grid
            grdTemp.Children.Add(txtTemp);
            grdTemp.Children.Add(btnTemp);

            // Put grid in the listbox
            lstInsertTeams.Items[lstInsertTeams.Items.Count - 1] = grdTemp;

            // Add button to create new line
            btnTemp = new Button() { IsDefault = true, Content = "New Team", HorizontalAlignment = HorizontalAlignment.Left, Margin = new Thickness(10) };
            btnTemp.Click += btnNewTeam_Click; 
            lstInsertTeams.Items.Add(btnTemp);

            // Scroll down
            scrInsertTeams.ScrollToEnd();

            // Focus the new textbox
            txtTemp.Focus();
        }

        void btnNewTeam_Click(object sender, EventArgs e)
        {
            AddLineTeamListBox();
        }

        void btnRemoveTeamLine_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            //TODO: use Linq

            for (int i = 0; i < lstInsertTeams.Items.Count; i++)
            {
                Grid tmp = (Grid)lstInsertTeams.Items[i];
                if (tmp.Children.Contains(btn))
                {
                    lstInsertTeams.Items.RemoveAt(i);
                    break;
                }
            }

        }
    }
}
