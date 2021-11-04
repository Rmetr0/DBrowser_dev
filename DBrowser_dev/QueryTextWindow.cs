using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBrowser_dev
{
    public partial class QueryTextWindow : Form
    {
        public MainWindow parentWindow;

        public QueryTextWindow()
        {
            InitializeComponent();
        }

        public QueryTextWindow(MainWindow window)
        {
            parentWindow = window;
            InitializeComponent();
        }

        public void ShowQueryText(string query)
        {
            queryTextBox.Clear();
            queryTextBox.Text = query;
        }
    }
}
