using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DBrowser_dev
{
    public partial class DebugWindow : Form
    {
        private DBConnectionWindow parentWindow;

        public DebugWindow()
        {
            InitializeComponent();
        }

        public DebugWindow(DBConnectionWindow window)
        {
            parentWindow = window;
            InitializeComponent();
        }

        public void ShowQueryString(string query)
        {
            debugTextBox.Clear();
            debugTextBox.Text = query;
        }

        public void debugListBox_dataSourcesUpdate()
        {
            debugTextBox.Clear();
            foreach (DataRow row in parentWindow.sourcesDataTable.Rows)
            {
                var servername = row.ItemArray[0];
                debugTextBox.Text = servername.ToString();
            }
        }

        public void debugListBox_ShowConnectionString()
        {
            debugTextBox.Clear();
            debugTextBox.Text = parentWindow.connectionString;
        }
    }
}
