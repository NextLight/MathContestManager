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
    /// Interaction logic for StartControl.xaml
    /// </summary>
    public partial class StartControl : View
    {
        public StartControl()
        {
            InitializeComponent();
        }

        private void btnCreateNewContest_Click(object sender, RoutedEventArgs e)
        {
            OnViewFinished("create");
        }
    }
}
