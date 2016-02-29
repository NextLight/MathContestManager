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

        #region Create New Match
        private void btnCreateNewMatch_Click(object sender, RoutedEventArgs e)
        {
            // Hide the current grid and show grid to insert teams
            grdStart.Visibility = Visibility.Hidden;
            grdInsertTeams.Visibility = Visibility.Visible;

            // Insert the first element in team listbox
            AddLineTeamListBox();
        }

        #region Insert Teams Window
        private void AddLineTeamListBox()
        {
            ItemsControl itc = lstInsertTeams;
            string typeOfItem = "team";

            AddLineToItemsControl(itc, typeOfItem);
        }

        private void btnNewTeam_Click(object sender, EventArgs e)
        {
            AddLineTeamListBox();
        }

        private void btnRemoveTeamLine_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ItemsControl itc = lstInsertTeams;

            RemoveLineFromItemsControl(btn, itc);
        }

        private void btnInsertTeamsSubmit_Click(object sender, RoutedEventArgs e)
        {
            grdInsertTeams.Visibility = Visibility.Hidden;
            grdInsertProblems.Visibility = Visibility.Visible;

            AddLineProblemsListBox();
        }
        #endregion

        #region Insert Problems Window
        private void AddLineProblemsListBox()
        {
            ItemsControl itc = lstInsertProblems;
            string typeOfItem = "problem";

            AddLineToItemsControl(itc, typeOfItem);
        }

        private void btnRemoveProblemsLine_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ItemsControl itc = lstInsertProblems;

            RemoveLineFromItemsControl(btn, itc);
        }

        private void btnInsertProblemsSubmit_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        private static void RemoveLineFromItemsControl(Button btn, ItemsControl itc)
        {
            // Cast Items to List
            var lst = itc.Items.Cast<object>().ToList<object>();
            // Find index to remove
            int index = lst.FindIndex(x => ((StackPanel)x).Children.Contains(btn));
            // Remove the line
            itc.Items.RemoveAt(index);
        }

        private void AddLineToItemsControl(ItemsControl itc, string typeOfItem)
        {
            // Variables used to store control's text
            string newButtonText = "", textBox1Hint = "", textBox2Hint = "";

            if (itc.Items.Count == 0)
                itc.Items.Add(null);

            if (typeOfItem == "team")
            {
                newButtonText = "New team";
                textBox1Hint = "Team name";
            }
            else if (typeOfItem == "problem")
            {
                newButtonText = "New problem";
                textBox1Hint = "Problem solution";
                textBox2Hint = "Problem score";
            }

            // Create grid to contain all controls in a line
            StackPanel grdTemp = new StackPanel() { Orientation = Orientation.Horizontal, Margin = new Thickness(0) };

            // Create a textbox
            TextBox txtTemp1 = new TextBox()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10),
                Height = 40,
                Width = 100
            };
            TextFieldAssist.SetHint(txtTemp1, textBox1Hint);
            txtTemp1.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;

            // Create another textbox
            TextBox txtTemp2 = null;
            if (typeOfItem == "problem")
            {
                txtTemp2 = new TextBox()
                {
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(10),
                    Height = 40,
                    Width = 100
                };
                TextFieldAssist.SetHint(txtTemp2, textBox2Hint);
                txtTemp2.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            }

            // Create new button to remove the line
            Button btnTemp = new Button()
            {
                IsTabStop = false,
                Content = new PackIcon() { Kind = PackIconKind.Delete },
                Margin = new Thickness(10),
                HorizontalAlignment = HorizontalAlignment.Left
            };
            btnTemp.Click += btnRemoveTeamLine_Click;

            // Add controls to the grid
            grdTemp.Children.Add(txtTemp1);
            if (typeOfItem == "problem")
                grdTemp.Children.Add(txtTemp2);
            grdTemp.Children.Add(btnTemp);

            // Put grid in the listbox
            itc.Items[itc.Items.Count - 1] = grdTemp;

            // Add button to create new line
            btnTemp = new Button()
            {
                IsDefault = true,
                Content = newButtonText,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10)
            };
            btnTemp.Click += btnNewTeam_Click;
            itc.Items.Add(btnTemp);

            // Scroll down
            scrInsertTeams.ScrollToEnd();

            // Focus the new textbox
            txtTemp1.Focus();
        }
        #endregion
    }
}
