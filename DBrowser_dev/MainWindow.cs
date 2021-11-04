using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBrowser_dev
{
    public partial class MainWindow : Form
    {
        public DBConnectionWindow parentWindow;
        public SqlConnection connection;
        public string currentQuery;
        public string currentTable;
        public int currentTableType;
        public List<Query> queries = new List<Query>();

        private bool exit = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(DBConnectionWindow window)
        {
            parentWindow = window;
            connection = parentWindow.connection;
            InitializeComponent();

            if (Program.newQueryWindowDebugMode)
            {
                NewQueryWindow newQueryWindow = new NewQueryWindow(this);
                newQueryWindow.ShowDialog();
            }
        }

        public void ShowAboutMessageBox()
        {
            string aboutText = "DBrowser\n\nЯчменев Роман, 2021";

            DialogResult dialog = MessageBox.Show(
                    aboutText,
                    "О программе",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
        }

        public void UpdateDataSources()
        {
            dataSourcesListBox.Items.Clear();

            if (dataSourcesComboBox.SelectedIndex == 2)
            {
                foreach (var query in queries)
                {
                    if (!query.saved)
                    {
                        dataSourcesListBox.Items.Add(query.name + " *");
                    }
                    else
                    {
                        dataSourcesListBox.Items.Add(query.name);
                    }
                }
            }
            else
            {
                string type = "";
                if (dataSourcesComboBox.SelectedIndex == 0)
                {
                    type = "BASE TABLE";
                }
                else if (dataSourcesComboBox.SelectedIndex == 1)
                {
                    type = "VIEW";
                }

                DataTable tables = connection.GetSchema("Tables");
                foreach (DataRow table in tables.Rows)
                {
                    if (table.ItemArray[3].ToString() == type &&
                        table.ItemArray[2].ToString() != "sysdiagrams" &&
                        table.ItemArray[2].ToString() != "dtproperties")
                    {
                        dataSourcesListBox.Items.Add(table.ItemArray[2]);
                    }
                }
            }
        }

        public void ClearDataView()
        {
            DataTable dataTable = new DataTable();
            dataGridView.DataSource = dataTable;
        }

        public void UpdateDataView()
        {
            if (currentTableType == 0 ||
                currentTableType == 1)
            {
                UpdateDataViewTable();
            }
            else if (currentTableType == 2)
            {
                UpdateDataViewQuery(currentQuery);
            }
        }

        public void UpdateDataViewTable()
        {
            dataViewLabel.Enabled = true;
            dataGridView.Enabled = true;
            refreshDataViewButton.Enabled = true;
            newQueryLowButton.Enabled = true;
            queryTextButton.Enabled = false;
            dataViewTextBox.Text = currentTable;
            
            currentQuery = "SELECT TOP(1000) * FROM [" + currentTable + "]";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(currentQuery, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView.DataSource = dataTable;
        }

        public void UpdateDataViewQuery(string query)
        {
            dataViewLabel.Enabled = true;
            dataGridView.Enabled = true;
            refreshDataViewButton.Enabled = true;
            newQueryLowButton.Enabled = true;
            queryTextButton.Enabled = true;
            dataViewTextBox.Text = currentTable;
            dataSourcesComboBox.SelectedIndex = currentTableType;

            currentQuery = query;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(currentQuery, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView.DataSource = dataTable;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                DialogResult dialog = MessageBox.Show(
                    "Вы действительно хотите выйти из программы?",
                    "Завершение программы",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                    );

                if (dialog == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            connection.Close();

            if (exit)
            {
                Application.Exit();
            }
        }

        private void переподключитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit = false;
            Close();
            parentWindow.Show();
            parentWindow.ShowDatabaseConnectionFields();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            dataSourcesComboBox.SelectedIndex = 0;
        }

        private void tablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataSources();
        }

        private void refreshDataSourcesButton_Click(object sender, EventArgs e)
        {
            UpdateDataSources();
        }

        private void chooseDataSourceButton_Click(object sender, EventArgs e)
        {
            currentTable = dataSourcesListBox.SelectedItem.ToString();
            currentTableType = dataSourcesComboBox.SelectedIndex;
            UpdateDataView();
        }

        private void dataSourcesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataSourcesListBox.IndexFromPoint(e.Location) != 
                System.Windows.Forms.ListBox.NoMatches)
            {
                currentTable = dataSourcesListBox.SelectedItem.ToString();
                currentTableType = dataSourcesComboBox.SelectedIndex;
                UpdateDataView();
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutMessageBox();
        }

        private void refreshDataViewsButton_Click(object sender, EventArgs e)
        {
            UpdateDataView();
        }

        private void closeTabButton_Click(object sender, EventArgs e)
        {
            Query deleteQuery = null;
            foreach (var query in queries)
            {
                if (query.queryString == currentQuery)
                {
                    deleteQuery = query;
                }
            }

            if (deleteQuery != null)
            {
                DialogResult dialog;
                if (!deleteQuery.saved)
                {
                    dialog = MessageBox.Show(
                        "Вы действительно хотите закрыть запрос, не сохранив его?",
                        "Закрытие запроса",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                        );
                }
                else
                {
                    dialog = MessageBox.Show(
                        "Вы действительно хотите закрыть запрос?",
                        "Очистка окна",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                        );
                }


                if (dialog == DialogResult.Yes)
                {
                    queries.Remove(deleteQuery);
                    currentTable = "";
                    currentQuery = "";
                    UpdateDataSources();
                    ClearDataView();
                }
            }
            else
            {
                UpdateDataSources();
                ClearDataView();
            }
        }

        private void refreshTabButton_Click(object sender, EventArgs e)
        {
            UpdateDataSources();
            UpdateDataView();
        }

        private void newQueryButton_Click(object sender, EventArgs e)
        {
            NewQueryWindow newQueryWindow = new NewQueryWindow(this);
            newQueryWindow.ShowDialog();
        }

        private void SaveQuery()
        {
            saveFileDialog.Filter = "Файлы запросов SQL(*.sql)|*.sql|Все файлы(*.*)|*.*";
            saveFileDialog.FileName = currentTable;

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, currentQuery);
                MessageBox.Show(
                    "Запрос сохранён.",
                    "Сохранение файла",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(
                    "Ошибка сохранения запроса.",
                    "Сохранение файла",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            string newQueryName = Path.GetFileName(saveFileDialog.FileName);
            newQueryName = newQueryName.Substring(0, newQueryName.Length - 4);

            foreach (var query in queries)
            {
                if (query.name == currentTable)
                {
                    query.name = currentTable = newQueryName;
                    query.saved = true;
                }
            }
            UpdateDataSources();
            UpdateDataView();
        }

        private void LoadQuery()
        {
            openFileDialog.Filter = "Файлы запросов SQL(*.sql)|*.sql|Все файлы(*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                currentQuery = System.IO.File.ReadAllText(openFileDialog.FileName);
                MessageBox.Show(
                    "Запрос загружен.",
                    "Открытие файла",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                if (Program.debugMode)
                {
                    parentWindow.debugWindow.ShowQueryString(currentQuery);
                }

                try
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(currentQuery, connection);
                    string newQueryName = Path.GetFileName(openFileDialog.FileName);
                    queries.Add(new Query(currentQuery, newQueryName.Substring(0, newQueryName.Length - 4)));
                    queries[queries.Count - 1].saved = true;
                    currentTable = queries[queries.Count - 1].name;
                    currentTableType = 2;
                    UpdateDataViewQuery(currentQuery);
                    UpdateDataSources();
                }
                catch
                {
                    MessageBox.Show(
                        "Не удалось выполнить данный запрос.",
                        "Не удалось открыть запрос",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                    queries.RemoveAt(queries.Count - 1);
                    currentQuery = "";
                }
            }
            catch
            {
                MessageBox.Show(
                    "Ошибка загрузки запроса.",
                    "Открытие файла",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void saveQueryButton_Click(object sender, EventArgs e)
        {
            SaveQuery();
        }

        private void loadQueryButton_Click(object sender, EventArgs e)
        {
            LoadQuery();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            ShowAboutMessageBox();
        }

        private void сохранитьЗапросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveQuery();
        }

        private void загрузитьЗапросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadQuery();
        }

        private void обновитьИсточникиДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataSources();
        }

        private void обновитьПредставлениеДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataView();
        }

        private void обновитьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataSources();
            UpdateDataView();
        }

        private void запросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewQueryWindow newQueryWindow = new NewQueryWindow(this);
            newQueryWindow.ShowDialog();
        }

        private void newQueryLowButton_Click(object sender, EventArgs e)
        {
            NewQueryWindow newQueryWindow = new NewQueryWindow(this);
            newQueryWindow.ShowDialog();
        }

        private void queryTextButton_Click(object sender, EventArgs e)
        {
            QueryTextWindow queryTextWindow = new QueryTextWindow(this);
            queryTextWindow.Show();
            queryTextWindow.ShowQueryText(currentQuery);
        }
    }
}
