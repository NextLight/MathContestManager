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
using System.Data;

namespace MathContestManager
{
    /// <summary>
    /// Logica di interazione per RankingWindow.xaml
    /// </summary>
    public partial class RankingWindow : MetroWindow
    {
        private ContestManager _cm;

        private DataTable rankingTable;

        public RankingWindow(ContestManager cm)
        {
            InitializeComponent();
            _cm = cm;
            rankingTable = new DataTable();

            DataColumn[] dc = _cm.Tasks.Select((x, i) => new DataColumn(i.ToString(), typeof(int))).ToArray<DataColumn>();
            rankingTable.Columns.AddRange(dc);

            foreach (ContestTeam team in _cm.Teams)
            {
                // Create new row with same structure of the table
                DataRow row = rankingTable.NewRow();

                // Create the row with scores
                row.ItemArray = team.Tasks.Select(x => x.CurrentScore).Cast<object>().ToArray();

                // Add row to the table
                rankingTable.Rows.Add(row);

                //TODO: add row header
            }
            
            dgRankingGrid.DataContext = rankingTable.DefaultView;
        }
    }
}
