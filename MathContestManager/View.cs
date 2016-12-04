using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MathContestManager
{
    public class ViewFinishedEventArgs : EventArgs
    {
        public object Data { get; private set; }

        public ViewFinishedEventArgs(object data)
        {
            Data = data;
        }
    }

    public class View : UserControl
    {
        public delegate void ViewFinishedEventHandler(object sender, ViewFinishedEventArgs e);
        public event ViewFinishedEventHandler ViewFinished;

        public void OnViewFinished(object data)
        {
            ViewFinished?.Invoke(this, new ViewFinishedEventArgs(data));
        }
    }
}
