using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBrowser_dev
{
    public partial class DBConnectionWindow : Form
    {
        public DebugWindow debugWindow;

        public DataTable sourcesDataTable;
        public string connectionString;
        public SqlConnection connection;

        public bool connectionError = false;

        public DBConnectionWindow()
        {
            InitializeComponent();

            if (Program.debugMode)
            {
                debugWindow = new DebugWindow(this);
                debugWindow.Show();
            }

            if (Program.newQueryWindowDebugMode)
            {
                connection = new SqlConnection("Data Source=ROMAN; Initial Catalog=Песенный_конкурс; Integrated Security=True;");
                connection.Open();

                Hide();
                MainWindow mainWindow = new MainWindow(this);
                mainWindow.Show();
            }
        }

        public void ShowDatabaseConnectionFields()
        {
            gettingDataSourcesLabel.Visible = false;
            servernameLabel.Visible = true;
            databaseNameLabel.Visible = true;
            usernameLabel.Visible = true;
            passwordLabel.Visible = true;
            servernameComboBox.Visible = true;
            databaseNameComboBox.Visible = true;
            usernameTextBox.Visible = true;
            passwordTextBox.Visible = true;
        }

        private void DBConnectionWindow_Load(object sender, EventArgs e)
        {

        }

        private void DBConnectionWindow_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            sourcesDataTable = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
            ShowDatabaseConnectionFields();

            if (Program.debugMode)
            {
                debugWindow.debugListBox_dataSourcesUpdate();
            }

            foreach (DataRow row in sourcesDataTable.Rows)
            {
                servernameComboBox.Items.Add(row.ItemArray[0]);
            }
        }

        private void servernameComboBox_TextUpdate(object sender, EventArgs e)
        {
            servernameComboBox_Entered();
        }

        private void servernameComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            servernameComboBox_Entered();

            servernameComboBox.Text = servernameComboBox.SelectedItem.ToString();
            using (var connection = new SqlConnection("Data Source=" + servernameComboBox.Text + ";Integrated Security=True;"))
            {
                Application.DoEvents();

                try
                {
                    connection.Open();

                    DataTable databases = connection.GetSchema("Databases");
                    foreach (DataRow database in databases.Rows)
                    {
                        if (int.Parse(database.ItemArray[1].ToString()) > 4)
                        {
                            databaseNameComboBox.Items.Add(database.ItemArray[0]);
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message.ToString(),
                        ex.Source.ToString(),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
        }

        private void servernameComboBox_Entered()
        {
            databaseNameComboBox.Items.Clear();
            databaseNameLabel.ForeColor = SystemColors.ControlText;
            databaseNameComboBox.Enabled = true;
        }

        private void databaseNameComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            databaseNameComboBox_Selected();
        }

        private void databaseNameComboBox_TextUpdate(object sender, EventArgs e)
        {
            databaseNameComboBox_Selected();
        }

        private void databaseNameComboBox_Selected()
        {
            usernameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            usernameTextBox.Enabled = true;
            passwordLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            passwordTextBox.Enabled = true;
            connectButton.Enabled = true;
        }

        private void connectButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (connectionError)
            {
                connectionError = false;
                connectButton.Text = "Подключиться";
                ShowDatabaseConnectionFields();
            }
            else
            {
                connectButton.Enabled = false;

                connectionString = "";
                connectionString += "Data Source=\"" + servernameComboBox.Text + "\";";
                connectionString += "Initial Catalog=\"" + databaseNameComboBox.Text + "\";";
                connectionString += "User ID=\"" + usernameTextBox.Text + "\";";
                connectionString += "Password=\"" + passwordTextBox.Text + "\";";
                connectionString += "Integrated Security=True;";

                if (Program.debugMode)
                {
                    debugWindow.debugListBox_ShowConnectionString();
                }

                servernameLabel.Visible = false;
                servernameComboBox.Visible = false;
                databaseNameLabel.Visible = false;
                databaseNameComboBox.Visible = false;
                usernameLabel.Visible = false;
                usernameTextBox.Visible = false;
                passwordLabel.Visible = false;
                passwordTextBox.Visible = false;

                gettingDataSourcesLabel.Visible = true;
                gettingDataSourcesLabel.Text = "Подключение...";

                connection = new SqlConnection(connectionString);
                
                Application.DoEvents();
                try
                {
                    connection.Open();

                    Hide();
                    MainWindow mainWindow = new MainWindow(this);
                    mainWindow.Show();
                }
                catch
                {
                    connectionError = true;

                    gettingDataSourcesLabel.Text = "Ошибка! Не удалось выполнить подключение.";
                    gettingDataSourcesLabel.Text += "\n\nСервер: " + servernameComboBox.Text;
                    gettingDataSourcesLabel.Text += "\nБаза данных: " + databaseNameComboBox.Text;
                    gettingDataSourcesLabel.Text += "\nПользователь: " + usernameTextBox.Text;
                    gettingDataSourcesLabel.Text += "\nПароль: " + passwordTextBox.Text;
                    gettingDataSourcesLabel.Text += "\n\nПроверьте правильность введённых данных";
                    gettingDataSourcesLabel.Text += "\nи повторите попытку.";

                    connectButton.Enabled = true;
                    connectButton.Text = "Переподключиться";
                }
            }
        }
    }
}
