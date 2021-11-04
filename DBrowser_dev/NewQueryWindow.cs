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
    public partial class NewQueryWindow : Form
    {
        private MainWindow parentWindow;
        public SqlConnection connection;
        public string query;

        public bool exit = true;

        public NewQueryWindow()
        {
            InitializeComponent();
        }

        public NewQueryWindow(MainWindow window)
        {
            parentWindow = window;
            connection = parentWindow.connection;
            InitializeComponent();
        }

        public void ClearWindow()
        {
            fromListBox.Items.Clear();
            fromAddButton.Enabled = false;
            fromRemoveButton.Enabled = false;

            selectDistinctCheckBox.Checked = false;
            selectComboBox.Items.Clear();
            selectComboBox.ResetText();
            selectAddButton.Enabled = false;
            selectRemoveButton.Enabled = false;
            selectListBox.Items.Clear();
            selectUpButton.Enabled = false;
            selectDownButton.Enabled = false;

            functionComboBox.ResetText();
            functionComboBox.SelectedIndex = -1;
            functionFieldComboBox.Items.Clear();
            functionFieldComboBox.ResetText();
            functionAliasTextBox.Clear();
            functionFromLabel.ForeColor = SystemColors.GrayText;
            functionFromTextBox.Clear();
            functionFromTextBox.Enabled = false;
            functionToLabel.ForeColor = SystemColors.GrayText;
            functionToTextBox.Clear();
            functionToTextBox.Enabled = false;
            functionAddButton.Enabled = false;
            functionRemoveButton.Enabled = false;
            functionUpButton.Enabled = false;
            functionDownButton.Enabled = false;
            functionDataGridView.Rows.Clear();

            conditionsFieldComboBox.Enabled = true;
            conditionsFieldComboBox.Items.Clear();
            conditionsFieldComboBox.ResetText();
            conditionsOperatorComboBox.Enabled = true;
            conditionsOperatorComboBox.ResetText();
            conditionsOperatorComboBox.SelectedIndex = -1;
            conditionsOperatorHelpPictureBox.Visible = false;
            conditionsValueComboBox.ResetText();
            conditionsValueComboBox.SelectedIndex = -1;
            conditionsLogicalComboBox.ResetText();
            conditionsLogicalComboBox.SelectedIndex = -1;
            conditionsAddButton.Enabled = false;
            conditionsRemoveButton.Enabled = false;
            conditionsUpButton.Enabled = false;
            conditionsDownButton.Enabled = false;
            conditionsDataGridView.Rows.Clear();

            groupByFieldComboBox.Items.Clear();
            groupByFieldComboBox.ResetText();
            groupByFunctionComboBox.ResetText();
            groupByFunctionComboBox.SelectedIndex = -1;
            groupByOfFieldComboBox.Items.Clear();
            groupByOfFieldComboBox.ResetText();
            groupByOperatorComboBox.ResetText();
            groupByOperatorComboBox.SelectedIndex = -1;
            groupByValueComboBox.ResetText();
            groupByValueComboBox.SelectedIndex = -1;

            orderByFieldComboBox.Items.Clear();
            orderByFieldComboBox.ResetText();
            orderByOrderComboBox.ResetText();
            orderByOrderComboBox.SelectedIndex = -1;

            if (parentWindow.currentTableType != 2)
            {
                fromTypeComboBox.SelectedIndex = parentWindow.currentTableType;
            }
            else
            {
                fromTypeComboBox.SelectedIndex = 0;
            }

            if (parentWindow.currentTable != null)
            {
                fromComboBox.SelectedItem = parentWindow.currentTable;
            }
            else if (fromComboBox.Items.Count != 0)
            {
                fromComboBox.SelectedIndex = 0;
            }
            fromAddButton.Enabled = true;
        }

        public void ClearJoinWindow()
        {
            joinLeftTypeComboBox.ResetText();
            joinLeftComboBox.Items.Clear();
            joinLeftComboBox.ResetText();
            joinRightTypeComboBox.ResetText();
            joinRightComboBox.Items.Clear();
            joinRightComboBox.ResetText();

            joinSelectComboBox.Items.Clear();
            joinSelectComboBox.ResetText();
            joinAddButton.Enabled = false;
            joinRemoveButton.Enabled = false;
            joinUpButton.Enabled = false;
            joinDownButton.Enabled = false;
            joinSelectListBox.Items.Clear();

            joinConditionsFieldComboBox.Items.Clear();
            joinConditionsFieldComboBox.ResetText();
            joinConditionsOperatorComboBox.ResetText();
            joinConditionsOperatorComboBox.SelectedIndex = -1;
            joinConditionsValueComboBox.ResetText();
            joinConditionsValueComboBox.SelectedIndex = -1;

            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            joinLeftTypeComboBox.SelectedIndex = 0;
            joinRightTypeComboBox.SelectedIndex = 0;
        }

        private void NewQueryWindow_Load(object sender, EventArgs e)
        {
            ClearWindow();
            ClearJoinWindow();
        }

        public void UpdateFromComboBox()
        {
            fromComboBox.Items.Clear();
            fromComboBox.ResetText();

            string type;
            if (fromTypeComboBox.SelectedIndex == 2)
            {
                foreach (var query in parentWindow.queries)
                {
                    if (!fromListBox.Items.Contains(query.name))
                    {
                        fromComboBox.Items.Add(query.name);
                    }
                }
            }
            else
            {
                if (fromTypeComboBox.SelectedIndex == 0)
                {
                    type = "BASE TABLE";
                }
                else
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
                        if (!fromListBox.Items.Contains(table.ItemArray[2]))
                        {
                            fromComboBox.Items.Add(table.ItemArray[2]);
                        }
                    }
                }
            }
        }

        public void UpdateSelectComboBox()
        {
            selectComboBox.Items.Clear();
            if (fromListBox.Items.Count > 0)
            {
                selectComboBox.Items.Add("(Все)");
            }

            DataTable columns = connection.GetSchema("Columns");
            foreach (DataRow column in columns.Rows)
            {
                if (fromListBox.Items.Contains(column.ItemArray[2]))
                {
                    if (fromListBox.Items.Count == 1)
                    {
                        if (!selectListBox.Items.Contains(column.ItemArray[3]))
                        {
                            selectComboBox.Items.Add(column.ItemArray[3]);
                        }
                    }
                    else
                    {
                        string newItem = "[" + column.ItemArray[2] + "].[" + column.ItemArray[3] + "]";
                        if (!selectListBox.Items.Contains(newItem))
                        {
                            selectComboBox.Items.Add(newItem);
                        }
                    }
                }
            }

            //foreach (var query in parentWindow.queries)
            //{
            //    if (fromListBox.Items.Contains(query.name))
            //    {
            //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query.queryString, connection);
            //        DataTable dataTable = new DataTable();
            //        sqlDataAdapter.Fill(dataTable);

            //        foreach (DataColumn column in dataTable.Columns)
            //        {
            //            if (fromListBox.Items.Contains(dataTable.TableName))
            //            {
            //                if (fromListBox.Items.Count == 1)
            //                {
            //                    if (!selectListBox.Items.Contains(column.ColumnName))
            //                    {
            //                        selectComboBox.Items.Add(column.ColumnName);
            //                    }
            //                }
            //                else
            //                {
            //                    string newItem = "[" + dataTable.TableName + "].[" + column.ColumnName + "]";
            //                    if (!selectListBox.Items.Contains(newItem))
            //                    {
            //                        selectComboBox.Items.Add(newItem);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
        }

        public void UpdateFunctionFieldComboBox()
        {
            functionFieldComboBox.Items.Clear();

            DataTable columns = connection.GetSchema("Columns");
            foreach (DataRow column in columns.Rows)
            {
                if (fromListBox.Items.Contains(column.ItemArray[2]))
                {
                    if (fromListBox.Items.Count == 1)
                    {
                        functionFieldComboBox.Items.Add(column.ItemArray[3]);
                    }
                    else
                    {
                        functionFieldComboBox.Items.Add("[" + column.ItemArray[2] +
                            "].[" + column.ItemArray[3] + "]");
                    }
                }
            }
        }

        public void UpdateConditionsFieldComboBox()
        {
            conditionsFieldComboBox.Items.Clear();

            DataTable columns = connection.GetSchema("Columns");
            foreach (DataRow column in columns.Rows)
            {
                if (fromListBox.Items.Contains(column.ItemArray[2]))
                {
                    if (fromListBox.Items.Count == 1)
                    {
                        conditionsFieldComboBox.Items.Add(column.ItemArray[3]);
                    }
                    else
                    {
                        conditionsFieldComboBox.Items.Add("[" + column.ItemArray[2] +
                            "].[" + column.ItemArray[3] + "]");
                    }
                }
            }
        }

        public void UpdateGroupByFieldComboBox()
        {
            groupByFieldComboBox.Items.Clear();

            DataTable columns = connection.GetSchema("Columns");
            foreach (DataRow column in columns.Rows)
            {
                if (fromListBox.Items.Contains(column.ItemArray[2]))
                {
                    if (fromListBox.Items.Count == 1)
                    {
                        groupByFieldComboBox.Items.Add(column.ItemArray[3]);
                    }
                    else
                    {
                        groupByFieldComboBox.Items.Add("[" + column.ItemArray[2] +
                            "].[" + column.ItemArray[3] + "]");
                    }
                }
            }
        }

        public void UpdateGroupByOfFieldComboBox()
        {
            groupByOfFieldComboBox.Items.Clear();

            DataTable columns = connection.GetSchema("Columns");
            foreach (DataRow column in columns.Rows)
            {
                if (fromListBox.Items.Contains(column.ItemArray[2]))
                {
                    if (fromListBox.Items.Count == 1)
                    {
                        groupByOfFieldComboBox.Items.Add(column.ItemArray[3]);
                    }
                    else
                    {
                        groupByOfFieldComboBox.Items.Add("[" + column.ItemArray[2] +
                            "].[" + column.ItemArray[3] + "]");
                    }
                }
            }
        }

        public void UpdateOrderByFieldComboBox()
        {
            orderByFieldComboBox.Items.Clear();

            DataTable columns = connection.GetSchema("Columns");
            foreach (DataRow column in columns.Rows)
            {
                if (fromListBox.Items.Contains(column.ItemArray[2]))
                {
                    if (fromListBox.Items.Count == 1)
                    {
                        orderByFieldComboBox.Items.Add(column.ItemArray[3]);
                    }
                    else
                    {
                        orderByFieldComboBox.Items.Add("[" + column.ItemArray[2] +
                            "].[" + column.ItemArray[3] + "]");
                    }
                }
            }
        }

        public void UpdateJoinLeftComboBox()
        {
            joinLeftComboBox.Items.Clear();
            joinLeftComboBox.ResetText();

            string type;
            if (joinLeftTypeComboBox.SelectedIndex == 2)
            {
                foreach (var query in parentWindow.queries)
                {
                    if (!joinLeftComboBox.Items.Contains(query.name))
                    {
                        joinLeftComboBox.Items.Add(query.name);
                    }
                }
            }
            else
            {
                if (joinLeftTypeComboBox.SelectedIndex == 0)
                {
                    type = "BASE TABLE";
                }
                else
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
                        if (!joinLeftComboBox.Items.Contains(table.ItemArray[2]))
                        {
                            joinLeftComboBox.Items.Add(table.ItemArray[2]);
                        }
                    }
                }
            }
        }

        public void UpdateJoinRightComboBox()
        {
            joinRightComboBox.Items.Clear();
            joinRightComboBox.ResetText();

            string type;
            if (joinRightTypeComboBox.SelectedIndex == 2)
            {
                foreach (var query in parentWindow.queries)
                {
                    if (!joinRightComboBox.Items.Contains(query.name))
                    {
                        joinRightComboBox.Items.Add(query.name);
                    }
                }
            }
            else
            {
                if (joinRightTypeComboBox.SelectedIndex == 0)
                {
                    type = "BASE TABLE";
                }
                else
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
                        if (!joinRightComboBox.Items.Contains(table.ItemArray[2]))
                        {
                            joinRightComboBox.Items.Add(table.ItemArray[2]);
                        }
                    }
                }
            }
        }

        public void UpdateJoinSelectComboBox()
        {
            joinSelectComboBox.Items.Clear();
            if (joinLeftComboBox.SelectedIndex != -1 ||
                joinRightComboBox.SelectedIndex != -1)
            {
                joinSelectComboBox.Items.Add("(Все)");
            }

            DataTable columns = connection.GetSchema("Columns");

            if (joinLeftComboBox.SelectedItem != null)
            {
                foreach (DataRow column in columns.Rows)
                {
                    if (joinLeftComboBox.SelectedItem.ToString() == column.ItemArray[2].ToString())
                    {
                        string newItem = "[" + column.ItemArray[2] + "].[" + column.ItemArray[3] + "]";
                        if (!joinSelectListBox.Items.Contains(newItem))
                        {
                            joinSelectComboBox.Items.Add(newItem);
                        }
                    }
                }
            }

            if (joinRightComboBox.SelectedItem != null)
            {
                foreach (DataRow column in columns.Rows)
                {
                    if (joinRightComboBox.SelectedItem.ToString() == column.ItemArray[2].ToString())
                    {
                        string newItem = "[" + column.ItemArray[2] + "].[" + column.ItemArray[3] + "]";
                        if (!joinSelectListBox.Items.Contains(newItem))
                        {
                            joinSelectComboBox.Items.Add(newItem);
                        }
                    }
                }
            }

            if (joinSelectComboBox.SelectedIndex == -1)
            {
                if (joinSelectComboBox.Items.Count > 1)
                {
                    joinSelectComboBox.SelectedIndex = 1;
                }
            }
        }

        public void UpdateJoinConditionsFieldComboBox()
        {
            joinConditionsFieldComboBox.Items.Clear();
            if (joinLeftComboBox.SelectedIndex != -1 ||
                joinRightComboBox.SelectedIndex != -1)
            {
                joinConditionsFieldComboBox.Items.Add("(Все)");
            }

            DataTable columns = connection.GetSchema("Columns");

            if (joinLeftComboBox.SelectedItem != null)
            {
                foreach (DataRow column in columns.Rows)
                {
                    if (joinLeftComboBox.SelectedItem.ToString() == column.ItemArray[2].ToString())
                    {
                        string newItem = "[" + column.ItemArray[2] + "].[" + column.ItemArray[3] + "]";
                        joinConditionsFieldComboBox.Items.Add(newItem);
                    }
                }
            }

            if (joinRightComboBox.SelectedItem != null)
            {
                foreach (DataRow column in columns.Rows)
                {
                    if (joinRightComboBox.SelectedItem.ToString() == column.ItemArray[2].ToString())
                    {
                        string newItem = "[" + column.ItemArray[2] + "].[" + column.ItemArray[3] + "]";
                        joinConditionsFieldComboBox.Items.Add(newItem);
                    }
                }
            }

            if (joinConditionsFieldComboBox.SelectedIndex == -1)
            {
                if (joinConditionsFieldComboBox.Items.Count > 1)
                {
                    joinConditionsFieldComboBox.SelectedIndex = 1;
                }
            }
        }

        public void UpdateJoinConditionsValueComboBox()
        {
            joinConditionsValueComboBox.Items.Clear();
            if (joinLeftComboBox.SelectedIndex != -1 ||
                joinRightComboBox.SelectedIndex != -1)
            {
                joinConditionsValueComboBox.Items.Add("(Все)");
            }

            DataTable columns = connection.GetSchema("Columns");

            if (joinLeftComboBox.SelectedItem != null)
            {
                foreach (DataRow column in columns.Rows)
                {
                    if (joinLeftComboBox.SelectedItem.ToString() == column.ItemArray[2].ToString())
                    {
                        string newItem = "[" + column.ItemArray[2] + "].[" + column.ItemArray[3] + "]";
                        joinConditionsValueComboBox.Items.Add(newItem);
                    }
                }
            }

            if (joinRightComboBox.SelectedItem != null)
            {
                foreach (DataRow column in columns.Rows)
                {
                    if (joinRightComboBox.SelectedItem.ToString() == column.ItemArray[2].ToString())
                    {
                        string newItem = "[" + column.ItemArray[2] + "].[" + column.ItemArray[3] + "]";
                        joinConditionsValueComboBox.Items.Add(newItem);
                    }
                }
            }

            if (joinConditionsFieldComboBox.SelectedIndex == -1)
            {
                if (joinConditionsFieldComboBox.Items.Count > 1)
                {
                    joinConditionsFieldComboBox.SelectedIndex = 1;
                }
            }
        }

        private void NewQueryWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                DialogResult dialog = MessageBox.Show(
                    "Вы действительно хотите выйти из окна создания нового запроса?",
                    "Закрытие окна",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                    );

                if (dialog == DialogResult.Yes)
                {
                    e.Cancel = false;
                    if (Program.newQueryWindowDebugMode)
                    {
                        connection.Close();
                        Application.Exit();
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void fromTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFromComboBox();
        }

        private void fromAddButton_Click(object sender, EventArgs e)
        {
            if (fromComboBox.SelectedItem != null)
            {
                if (fromListBox.Items.Count == 1)
                {
                    for (int i = 0; i < selectListBox.Items.Count; ++i)
                    {
                        selectListBox.Items[i] = "[" + fromListBox.Items[0] +
                            "].[" + selectListBox.Items[i] + "]";
                    }
                }

                int selectedIndex = fromComboBox.SelectedIndex;

                fromListBox.Items.Add(fromComboBox.SelectedItem);

                UpdateFromComboBox();
                UpdateSelectComboBox();
                UpdateFunctionFieldComboBox();
                UpdateConditionsFieldComboBox();
                UpdateGroupByFieldComboBox();
                UpdateGroupByOfFieldComboBox();
                UpdateOrderByFieldComboBox();
                if (fromComboBox.Items.Count != 0)
                {
                    fromComboBox.SelectedIndex = fromComboBox.Items.Count == selectedIndex ? 
                        selectedIndex - 1 : selectedIndex;
                }
                else
                {
                    fromComboBox.ResetText();
                }

                fromListBox.SelectedIndex = fromListBox.Items.Count - 1;
                selectComboBox.SelectedIndex = 1;
                fromRemoveButton.Enabled = true;
            }
        }

        private void fromRemoveButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = fromListBox.SelectedIndex;
            var selectedItem = fromListBox.SelectedItem;
            if (selectedIndex != -1)
            {
                if (fromListBox.Items.Count > 1)
                {
                    for (int i = 0; i < selectListBox.Items.Count; ++i)
                    {
                        string item = selectListBox.Items[i].ToString();
                        string table, column;
                        table = item.Substring(1, item.IndexOf(']') - 1);
                        column = item.Substring(item.IndexOf('.') + 2, item.Length - item.IndexOf('.') - 3);

                        if (table == fromListBox.SelectedItem.ToString())
                        {
                            selectListBox.Items.RemoveAt(i);
                            --i;
                        }
                        else if (fromListBox.Items.Count == 2)
                        {
                            selectListBox.Items[i] = column;
                        }
                    }
                }
                else
                {
                    selectListBox.Items.Clear();
                }

                fromListBox.Items.RemoveAt(fromListBox.SelectedIndex);
                UpdateFromComboBox();
                UpdateSelectComboBox();
                UpdateFunctionFieldComboBox();
                UpdateConditionsFieldComboBox();
                UpdateGroupByFieldComboBox();
                UpdateGroupByOfFieldComboBox();
                UpdateOrderByFieldComboBox();
                fromListBox.SelectedIndex = fromListBox.Items.Count == 0 ? -1 :
                    selectedIndex == 0 ? 0 : selectedIndex - 1;
                fromComboBox.SelectedItem = selectedItem;
                if (fromListBox.Items.Count == 0)
                {
                    fromRemoveButton.Enabled = false;
                }
            }
        }

        private void selectAddButton_Click(object sender, EventArgs e)
        {
            if (selectComboBox.SelectedItem != null)
            {
                int selectedIndex = selectComboBox.SelectedIndex;

                if (selectComboBox.SelectedIndex == 0)
                {
                    for (int i = 1; i < selectComboBox.Items.Count; ++i)
                    {
                        selectListBox.Items.Add(selectComboBox.Items[i]);
                    }
                }
                else
                {
                    selectListBox.Items.Add(selectComboBox.SelectedItem);
                }

                UpdateSelectComboBox();
                if (selectComboBox.Items.Count > 1)
                {
                    selectComboBox.SelectedIndex = selectComboBox.Items.Count == selectedIndex ?
                        selectedIndex - 1 : selectedIndex;
                }
                else if (selectComboBox.Items.Count == 1)
                {
                    selectComboBox.Items.Clear();
                    selectComboBox.ResetText();
                }

                selectListBox.SelectedIndex = selectListBox.Items.Count - 1;
                selectRemoveButton.Enabled = true;
            }
        }

        private void selectRemoveButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = selectListBox.SelectedIndex;
            var selectedItem = selectListBox.SelectedItem;
            if (selectedIndex != -1)
            {
                selectListBox.Items.RemoveAt(selectListBox.SelectedIndex);
                UpdateSelectComboBox();
                selectListBox.SelectedIndex = selectListBox.Items.Count == 0 ? -1 :
                    selectedIndex == 0 ? 0 : selectedIndex - 1;

                if (selectListBox.Items.Count == 0)
                {
                    selectUpButton.Enabled = false;
                    selectDownButton.Enabled = false;
                }

                selectComboBox.SelectedItem = selectedItem;
                if (selectListBox.Items.Count == 0)
                {
                    selectRemoveButton.Enabled = false;
                }
            }
        }

        private void selectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectListBox.SelectedIndex == selectListBox.Items.Count - 1 &&
                selectListBox.Items.Count > 1)
            {
                selectUpButton.Enabled = true;
                selectDownButton.Enabled = false;
            }
            else if (selectListBox.SelectedIndex == 0 &&
                selectListBox.Items.Count > 1)
            {
                selectUpButton.Enabled = false;
                selectDownButton.Enabled = true;
            }
            else if (selectListBox.Items.Count > 1)
            {
                selectUpButton.Enabled = true;
                selectDownButton.Enabled = true;
            }
            else
            {
                selectUpButton.Enabled = false;
                selectDownButton.Enabled = false;
            }
        }

        private void selectUpButton_Click(object sender, EventArgs e)
        {
            selectListBox.Items.Insert(selectListBox.SelectedIndex - 1, selectListBox.SelectedItem);
            selectListBox.SelectedIndex -= 2;
            selectListBox.Items.RemoveAt(selectListBox.SelectedIndex + 2);
        }

        private void selectDownButton_Click(object sender, EventArgs e)
        {
            selectListBox.Items.Insert(selectListBox.SelectedIndex + 2, selectListBox.SelectedItem);
            selectListBox.SelectedIndex += 2;
            selectListBox.Items.RemoveAt(selectListBox.SelectedIndex - 2);
        }

        private void functionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (functionComboBox.SelectedIndex == 5)
            {
                functionFromLabel.ForeColor = SystemColors.GrayText;
                functionFromTextBox.Enabled = false;
                functionFromTextBox.ResetText();
                functionToLabel.ForeColor = SystemColors.ControlText;
                functionToTextBox.Enabled = true;
            }    
            else if (functionComboBox.SelectedIndex == 9)
            {
                functionFromLabel.ForeColor = SystemColors.ControlText;
                functionFromTextBox.Enabled = true;
                functionToLabel.ForeColor = SystemColors.ControlText;
                functionToTextBox.Enabled = true;
            }
            else
            {
                functionFromLabel.ForeColor = SystemColors.GrayText;
                functionFromTextBox.Enabled = false;
                functionFromTextBox.ResetText();
                functionToLabel.ForeColor = SystemColors.GrayText;
                functionToTextBox.Enabled = false;
                functionToTextBox.ResetText();
            }

            if (functionFieldComboBox.SelectedItem == null &&
                functionFieldComboBox.Items.Count != 0)
            {
                functionFieldComboBox.SelectedIndex = 0;
            }
            functionAddButton.Enabled = true;

            if (functionComboBox.SelectedIndex == 10)
            {
                functionFieldComboBox.SelectedIndex = -1;
                functionFieldComboBox.Enabled = false;
            }
            else
            {
                functionFieldComboBox.Enabled = true;
            }
        }

        private void functionAddButton_Click(object sender, EventArgs e)
        {
            if (functionComboBox.SelectedItem != null)
            {
                if (functionFieldComboBox.SelectedItem != null ||
                    functionComboBox.SelectedIndex == 10)
                {
                    functionDataGridView.Rows.Add(
                        functionComboBox.SelectedItem,
                        functionFieldComboBox.SelectedItem,
                        functionAliasTextBox.Text,
                        functionFromTextBox.Text,
                        functionToTextBox.Text,
                        functionDistinctCheckBox.Checked
                        );
                }

                if (functionDataGridView.Rows.Count > 1)
                {
                    functionDataGridView.CurrentCell = functionDataGridView.
                        Rows[functionDataGridView.CurrentRow.Index + 1].Cells[0];
                }
                functionRemoveButton.Enabled = true;
            }
        }

        private void functionRemoveButton_Click(object sender, EventArgs e)
        {
            if (functionDataGridView.RowCount != 0)
            {
                functionDataGridView.Rows.RemoveAt(functionDataGridView.CurrentRow.Index);

                if (functionDataGridView.RowCount != 0)
                {
                    if (functionDataGridView.CurrentRow.Index != 0 &&
                        functionDataGridView.CurrentRow.Index !=
                        functionDataGridView.RowCount - 1)
                    {
                        functionDataGridView.CurrentCell = functionDataGridView.
                            Rows[functionDataGridView.CurrentRow.Index - 1].Cells[0];
                    }
                }

                if (functionDataGridView.RowCount == 0)
                {
                    functionRemoveButton.Enabled = false;
                }
            }
        }

        private void functionDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (functionDataGridView.CurrentRow.Index == functionDataGridView.RowCount - 1 &&
                functionDataGridView.RowCount > 1)
            {
                functionUpButton.Enabled = true;
                functionDownButton.Enabled = false;
            }
            else if (functionDataGridView.CurrentRow.Index == 0 &&
                functionDataGridView.RowCount > 1)
            {
                functionUpButton.Enabled = false;
                functionDownButton.Enabled = true;
            }
            else if (functionDataGridView.RowCount > 1)
            {
                functionUpButton.Enabled = true;
                functionDownButton.Enabled = true;
            }
            else
            {
                functionUpButton.Enabled = false;
                functionDownButton.Enabled = false;
            }
        }

        private void functionUpButton_Click(object sender, EventArgs e)
        {
            int i = functionDataGridView.CurrentRow.Index;
            object
                cell11 = functionDataGridView.Rows[i].Cells[0].Value,
                cell12 = functionDataGridView.Rows[i].Cells[1].Value,
                cell13 = functionDataGridView.Rows[i].Cells[2].Value,
                cell14 = functionDataGridView.Rows[i].Cells[3].Value,
                cell15 = functionDataGridView.Rows[i].Cells[4].Value,
                cell16 = functionDataGridView.Rows[i].Cells[5].Value;
            functionDataGridView.Rows.Insert(functionDataGridView.CurrentRow.Index - 1,
                cell11, cell12, cell13, cell14, cell15, cell16);
            functionDataGridView.CurrentCell = functionDataGridView.
                            Rows[functionDataGridView.CurrentRow.Index - 2].Cells[0];
            functionDataGridView.Rows.RemoveAt(functionDataGridView.CurrentRow.Index + 2);
        }

        private void functionDownButton_Click(object sender, EventArgs e)
        {
            int i = functionDataGridView.CurrentRow.Index;
            object
                cell11 = functionDataGridView.Rows[i].Cells[0].Value,
                cell12 = functionDataGridView.Rows[i].Cells[1].Value,
                cell13 = functionDataGridView.Rows[i].Cells[2].Value,
                cell14 = functionDataGridView.Rows[i].Cells[3].Value,
                cell15 = functionDataGridView.Rows[i].Cells[4].Value,
                cell16 = functionDataGridView.Rows[i].Cells[5].Value;
            functionDataGridView.Rows.Insert(functionDataGridView.CurrentRow.Index + 2,
                cell11, cell12, cell13, cell14, cell15, cell16);
            functionDataGridView.CurrentCell = functionDataGridView.
                            Rows[functionDataGridView.CurrentRow.Index + 2].Cells[0];
            functionDataGridView.Rows.RemoveAt(functionDataGridView.CurrentRow.Index - 2);
        }

        private void conditionsOperatorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            conditionsFieldComboBox.Enabled = true;

            conditionsValueComboBox.Items.Clear();
            conditionsValueComboBox.Items.Add("Пустое (IS NULL)");
            conditionsValueComboBox.Items.Add("Истина (True)");
            conditionsValueComboBox.Items.Add("Ложь (False)");

            if (conditionsOperatorComboBox.SelectedIndex == 6 ||
                conditionsOperatorComboBox.SelectedIndex == 7)
            {
                conditionsOperatorHelpPictureBox.Visible = true;
                likeToolTip.Active = true;
                queryToolTip.Active = false;
            }
            else
            {
                conditionsOperatorHelpPictureBox.Visible = false;
                likeToolTip.Active = false;
                queryToolTip.Active = false;
            }

            if (conditionsFieldComboBox.SelectedItem == null &&
                conditionsLogicalComboBox.SelectedItem == null)
            {
                if (conditionsFieldComboBox.Items.Count != 0)
                {
                    conditionsFieldComboBox.SelectedIndex = 0;
                }
                conditionsLogicalComboBox.SelectedIndex = 0;
            }

            if (conditionsLogicalComboBox.SelectedIndex != -1)
            {
                if (conditionsOperatorComboBox.SelectedIndex == 8)
                {
                    if (conditionsValueComboBox.SelectedItem != null)
                    {
                        conditionsAddButton.Enabled = true;
                    }
                }
                else
                {
                    if (conditionsFieldComboBox.SelectedIndex != -1)
                    {
                        conditionsAddButton.Enabled = true;
                    }
                }
            }
        }

        private void conditionsFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conditionsOperatorComboBox.SelectedIndex == -1 &&
                conditionsLogicalComboBox.SelectedIndex == -1)
            {
                conditionsOperatorComboBox.SelectedIndex = 0;
                conditionsLogicalComboBox.SelectedIndex = 0;
            }

            if (conditionsLogicalComboBox.SelectedIndex != -1)
            {
                if (conditionsValueComboBox.SelectedIndex == 0)
                {
                    conditionsAddButton.Enabled = true;
                }
                else
                {
                    if (conditionsOperatorComboBox.SelectedIndex != -1)
                    {
                        conditionsAddButton.Enabled = true;
                    }
                }
            }
        }

        private void conditionsAddButton_Click(object sender, EventArgs e)
        {
            string value;
            if (queriesCheckBox.Checked)
            {
                value = "[Запрос]" + conditionsValueComboBox.Text;
            }
            else
            {
                value = conditionsValueComboBox.Text;
            }

            conditionsDataGridView.Rows.Add(
                conditionsFieldComboBox.SelectedItem,
                conditionsOperatorComboBox.SelectedItem,
                conditionsValueComboBox.Text,
                conditionsLogicalComboBox.SelectedItem
                );

            if (conditionsDataGridView.Rows.Count > 1)
            {
                conditionsDataGridView.CurrentCell = conditionsDataGridView.
                    Rows[conditionsDataGridView.CurrentRow.Index + 1].Cells[0];
            }
            conditionsRemoveButton.Enabled = true;
        }

        private void fromComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fromComboBox.SelectedIndex != -1)
            {
                fromAddButton.Enabled = true;
            }
            else
            {
                fromAddButton.Enabled = false;
            }
        }

        private void fromComboBox_TextChanged(object sender, EventArgs e)
        {
            fromAddButton.Enabled = false;
        }

        private void selectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectComboBox.SelectedIndex != -1)
            {
                selectAddButton.Enabled = true;
            }
            else
            {
                selectAddButton.Enabled = false;
            }
        }

        private void selectComboBox_TextChanged(object sender, EventArgs e)
        {
            selectAddButton.Enabled = false;
        }

        private void functionFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (functionComboBox.SelectedItem != null)
            {
                functionAddButton.Enabled = true;
            }
        }

        private void functionFromTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 57 || (e.KeyChar > 32 && e.KeyChar < 48))
            {
                e.Handled = true;
            }
        }

        private void functionToTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 57 || (e.KeyChar > 32 && e.KeyChar < 48))
            {
                e.Handled = true;
            }
        }

        private void conditionsValueComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            conditionsOperatorComboBox.Enabled = true;

            if (conditionsValueComboBox.SelectedIndex == 0)
            {
                conditionsOperatorComboBox.Enabled = false;
            }

            if (conditionsFieldComboBox.SelectedItem == null &&
                conditionsOperatorComboBox.SelectedItem == null &&
                conditionsLogicalComboBox.SelectedItem == null)
            {
                if (conditionsFieldComboBox.Items.Count != 0)
                {
                    conditionsFieldComboBox.SelectedIndex = 0;
                }
                conditionsOperatorComboBox.SelectedIndex = 0;
                conditionsLogicalComboBox.SelectedIndex = 0;
            }

            if (conditionsLogicalComboBox.SelectedIndex != -1)
            {
                if (conditionsValueComboBox.SelectedIndex == 0)
                {
                    if (conditionsFieldComboBox.SelectedIndex != -1)
                    {
                        conditionsAddButton.Enabled = true;
                    }
                }
                else
                {
                    if (conditionsOperatorComboBox.SelectedIndex == 8)
                    {
                        conditionsAddButton.Enabled = true;
                    }
                    else
                    {
                        if (conditionsFieldComboBox.SelectedIndex != -1 &&
                        conditionsOperatorComboBox.SelectedIndex != -1)
                        {
                            conditionsAddButton.Enabled = true;
                        }
                    }
                }
            }
        }

        private void conditionsLogicalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conditionsFieldComboBox.SelectedIndex == -1 &&
                conditionsOperatorComboBox.SelectedIndex == -1)
            {
                if (conditionsFieldComboBox.Items.Count != 0)
                {
                    conditionsFieldComboBox.SelectedIndex = 0;
                }
                conditionsOperatorComboBox.SelectedIndex = 0;
            }

            if (conditionsOperatorComboBox.SelectedIndex == 8)
            {
                if (conditionsValueComboBox.SelectedItem != null)
                {
                    conditionsAddButton.Enabled = true;
                }
            }
            else if (conditionsValueComboBox.SelectedIndex == 0)
            {
                if (conditionsFieldComboBox.SelectedIndex != -1)
                {
                    conditionsAddButton.Enabled = true;
                }
            }
            else 
            {
                if (conditionsFieldComboBox.SelectedIndex != -1 &&
                    conditionsOperatorComboBox.SelectedIndex != -1)
                {
                    conditionsAddButton.Enabled = true;
                }
            }
        }

        private void refreshWindowButton_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                    "Вы действительно хотите очистить все поля запроса?",
                    "Очистка окна",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                    );

            if (dialog == DialogResult.Yes)
            {
                ClearWindow();
            }
        }

        private void conditionsValueComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (conditionsOperatorComboBox.SelectedIndex < 6 &&
                conditionsOperatorComboBox.SelectedIndex >= 0)
            {
                if (e.KeyChar > 57 || (e.KeyChar > 32 && e.KeyChar < 48) &&
                    e.KeyChar != 44 && e.KeyChar != 45)
                {
                    e.Handled = true;
                }
            }
        }

        private void conditionsUpButton_Click(object sender, EventArgs e)
        {
            int i = conditionsDataGridView.CurrentRow.Index;
            object
                cell11 = conditionsDataGridView.Rows[i].Cells[0].Value,
                cell12 = conditionsDataGridView.Rows[i].Cells[1].Value,
                cell13 = conditionsDataGridView.Rows[i].Cells[2].Value,
                cell14 = conditionsDataGridView.Rows[i].Cells[3].Value;
            conditionsDataGridView.Rows.Insert(conditionsDataGridView.CurrentRow.Index - 1,
                cell11, cell12, cell13, cell14);
            conditionsDataGridView.CurrentCell = conditionsDataGridView.
                            Rows[conditionsDataGridView.CurrentRow.Index - 2].Cells[0];
            conditionsDataGridView.Rows.RemoveAt(conditionsDataGridView.CurrentRow.Index + 2);
        }

        private void conditionsDownButton_Click(object sender, EventArgs e)
        {
            int i = conditionsDataGridView.CurrentRow.Index;
            object
                cell11 = conditionsDataGridView.Rows[i].Cells[0].Value,
                cell12 = conditionsDataGridView.Rows[i].Cells[1].Value,
                cell13 = conditionsDataGridView.Rows[i].Cells[2].Value,
                cell14 = conditionsDataGridView.Rows[i].Cells[3].Value;
            conditionsDataGridView.Rows.Insert(conditionsDataGridView.CurrentRow.Index + 2,
                cell11, cell12, cell13, cell14);
            conditionsDataGridView.CurrentCell = conditionsDataGridView.
                            Rows[conditionsDataGridView.CurrentRow.Index + 2].Cells[0];
            conditionsDataGridView.Rows.RemoveAt(conditionsDataGridView.CurrentRow.Index - 2);
        }

        private void conditionsRemoveButton_Click(object sender, EventArgs e)
        {
            if (conditionsDataGridView.RowCount != 0)
            {
                conditionsDataGridView.Rows.RemoveAt(conditionsDataGridView.CurrentRow.Index);

                if (conditionsDataGridView.RowCount != 0)
                {
                    if (conditionsDataGridView.CurrentRow.Index != 0 &&
                        conditionsDataGridView.CurrentRow.Index !=
                        conditionsDataGridView.RowCount - 1)
                    {
                        conditionsDataGridView.CurrentCell = conditionsDataGridView.
                            Rows[conditionsDataGridView.CurrentRow.Index - 1].Cells[0];
                    }
                }

                if (conditionsDataGridView.RowCount == 0)
                {
                    conditionsRemoveButton.Enabled = false;
                }
            }
        }

        private void conditionsDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (conditionsDataGridView.CurrentRow.Index == conditionsDataGridView.RowCount - 1 &&
                    conditionsDataGridView.RowCount > 1)
            {
                conditionsUpButton.Enabled = true;
                conditionsDownButton.Enabled = false;
            }
            else if (conditionsDataGridView.CurrentRow.Index == 0 &&
                conditionsDataGridView.RowCount > 1)
            {
                conditionsUpButton.Enabled = false;
                conditionsDownButton.Enabled = true;
            }
            else if (conditionsDataGridView.RowCount > 1)
            {
                conditionsUpButton.Enabled = true;
                conditionsDownButton.Enabled = true;
            }
            else
            {
                conditionsUpButton.Enabled = false;
                conditionsDownButton.Enabled = false;
            }
        }

        private void conditionsOperatorComboBox_TextUpdate(object sender, EventArgs e)
        {
            conditionsFieldComboBox.Enabled = true;
        }

        private void conditionsValueComboBox_TextUpdate(object sender, EventArgs e)
        {
            conditionsOperatorComboBox.Enabled = true;
        }

        private void joinLeftTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateJoinLeftComboBox();
        }

        private void joinRightTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateJoinRightComboBox();
        }

        private void joinLeftComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateJoinSelectComboBox();
            UpdateJoinConditionsFieldComboBox();
            UpdateJoinConditionsValueComboBox();
            joinConditionsOperatorComboBox.SelectedIndex = 0;
        }

        private void joinRightComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateJoinSelectComboBox();
            UpdateJoinConditionsFieldComboBox();
            UpdateJoinConditionsValueComboBox();
            joinConditionsOperatorComboBox.SelectedIndex = 0;
        }

        private void joinSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (joinSelectComboBox.SelectedIndex != -1)
            {
                joinAddButton.Enabled = true;
            }
            else
            {
                joinAddButton.Enabled = false;
            }
        }

        private void joinAddButton_Click(object sender, EventArgs e)
        {
            if (joinSelectComboBox.SelectedItem != null)
            {
                int selectedIndex = joinSelectComboBox.SelectedIndex;

                if (joinSelectComboBox.SelectedIndex == 0)
                {
                    for (int i = 1; i < joinSelectComboBox.Items.Count; ++i)
                    {
                        joinSelectListBox.Items.Add(joinSelectComboBox.Items[i]);
                    }
                }
                else
                {
                    joinSelectListBox.Items.Add(joinSelectComboBox.SelectedItem);
                }

                UpdateJoinSelectComboBox();
                if (joinSelectComboBox.Items.Count > 1)
                {
                    joinSelectComboBox.SelectedIndex = joinSelectComboBox.Items.Count == selectedIndex ?
                        selectedIndex - 1 : selectedIndex;
                }
                else if (joinSelectComboBox.Items.Count == 1)
                {
                    joinSelectComboBox.Items.Clear();
                    joinSelectComboBox.ResetText();
                }

                joinSelectListBox.SelectedIndex = joinSelectListBox.Items.Count - 1;
                joinRemoveButton.Enabled = true;
            }
        }

        private void joinRemoveButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = joinSelectListBox.SelectedIndex;
            var selectedItem = joinSelectListBox.SelectedItem;
            if (selectedIndex != -1)
            {
                joinSelectListBox.Items.RemoveAt(joinSelectListBox.SelectedIndex);
                UpdateJoinSelectComboBox();
                joinSelectListBox.SelectedIndex = joinSelectListBox.Items.Count == 0 ? -1 :
                    selectedIndex == 0 ? 0 : selectedIndex - 1;

                if (joinSelectListBox.Items.Count == 0)
                {
                    joinUpButton.Enabled = false;
                    joinDownButton.Enabled = false;
                }

                joinSelectComboBox.SelectedItem = selectedItem;
                if (joinSelectListBox.Items.Count == 0)
                {
                    joinRemoveButton.Enabled = false;
                }
            }
        }

        private void joinSelectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (joinSelectListBox.SelectedIndex == joinSelectListBox.Items.Count - 1 &&
                    joinSelectListBox.Items.Count > 1)
            {
                joinUpButton.Enabled = true;
                joinDownButton.Enabled = false;
            }
            else if (joinSelectListBox.SelectedIndex == 0 &&
                joinSelectListBox.Items.Count > 1)
            {
                joinUpButton.Enabled = false;
                joinDownButton.Enabled = true;
            }
            else if (joinSelectListBox.Items.Count > 1)
            {
                joinUpButton.Enabled = true;
                joinDownButton.Enabled = true;
            }
            else
            {
                joinUpButton.Enabled = false;
                joinDownButton.Enabled = false;
            }
        }

        private void joinUpButton_Click(object sender, EventArgs e)
        {
            joinSelectListBox.Items.Insert(joinSelectListBox.SelectedIndex - 1, joinSelectListBox.SelectedItem);
            joinSelectListBox.SelectedIndex -= 2;
            joinSelectListBox.Items.RemoveAt(joinSelectListBox.SelectedIndex + 2);
        }

        private void joinDownButton_Click(object sender, EventArgs e)
        {
            joinSelectListBox.Items.Insert(joinSelectListBox.SelectedIndex + 2, joinSelectListBox.SelectedItem);
            joinSelectListBox.SelectedIndex += 2;
            joinSelectListBox.Items.RemoveAt(joinSelectListBox.SelectedIndex - 2);
        }

        private void joinRefreshWindowButton_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Вы действительно хотите очистить все поля запроса?",
                "Очистка окна",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (dialog == DialogResult.Yes)
            {
                ClearJoinWindow();
            }
        }

        private void BuildSelect()
        {
            query += "SELECT ";
            if (selectListBox.Items.Count != 0)
            {
                if (selectDistinctCheckBox.Checked)
                {
                    query += "DISTINCT ";
                }
                foreach (var item in selectListBox.Items)
                {
                    if (!item.ToString().Contains('['))
                    {
                        query += '[' + item.ToString() + "], ";
                    }
                    else
                    {
                        query += item.ToString() + ", ";
                    }
                }
                query = query.Remove(query.Length - 2, 2);
                query += "\r\n";
            }
        }

        private void BuildFunctions()
        {
            if (functionDataGridView.Rows.Count != 0)
            {
                if (selectListBox.Items.Count != 0)
                {
                    query = query.Remove(query.Length - 1, 1);
                    query += ", ";
                }

                for (int i = 0; i < functionDataGridView.Rows.Count; ++i)
                {
                    string function = functionDataGridView.Rows[i].Cells[0].Value.ToString().
                        Split('(').Last().Split(')').First();
                    query += function + "(";

                    if (function == "COUNT" || function == "AVG" || function == "MIN" ||
                        function == "MAX" || function == "SUM")
                    {
                        if (functionDataGridView.Rows[i].Cells[5].Value.ToString() == "True")
                        {
                            query += "DISTINCT ";
                        }

                        if (fromListBox.Items.Count == 1) query += "[";
                        query += functionDataGridView.Rows[i].Cells[1].Value;
                        if (fromListBox.Items.Count == 1) query += "]";
                        query += ")";
                    }
                    else if (function == "ROUND")
                    {
                        if (fromListBox.Items.Count == 1) query += "[";
                        query += functionDataGridView.Rows[i].Cells[1].Value;
                        if (fromListBox.Items.Count == 1) query += "]";

                        if (functionDataGridView.Rows[i].Cells[4].Value.ToString() != "")
                        {
                            query += ", " + functionDataGridView.Rows[i].Cells[4].Value;
                        }
                        else
                        {
                            query += ", 0";
                        }

                        query += ")";
                    }
                    else if (function == "UCASE" || function == "LCASE" || function == "LEN")
                    {
                        if (fromListBox.Items.Count == 1) query += "[";
                        query += functionDataGridView.Rows[i].Cells[1].Value;
                        if (fromListBox.Items.Count == 1) query += "]";
                        query += ")";
                    }
                    else if (function == "MID")
                    {
                        if (fromListBox.Items.Count == 1) query += "[";
                        query += functionDataGridView.Rows[i].Cells[1].Value;
                        if (fromListBox.Items.Count == 1) query += "]";

                        if (functionDataGridView.Rows[i].Cells[3].Value.ToString() != "")
                        {
                            query += ", " + functionDataGridView.Rows[i].Cells[3].Value;
                        }
                        else
                        {
                            query += ", 0";
                        }

                        if (functionDataGridView.Rows[i].Cells[4].Value.ToString() != "")
                        {
                            query += ", " + functionDataGridView.Rows[i].Cells[4].Value;
                        }
                        else
                        {
                            query += ", 0";
                        }

                        query += ")";
                    }
                    else if (function == "NOW")
                    {
                        query += ")";
                    }

                    if (functionDataGridView.Rows[i].Cells[2].Value.ToString() != "")
                    {
                        query += " AS [" + functionDataGridView.Rows[i].Cells[2].Value + ']';
                    }
                    query += ", ";
                }
                query = query.Remove(query.Length - 2, 2);
                query += "\r\n";
            }
        }

        private void BuildFrom()
        {
            query += "FROM ";
            foreach (var item in fromListBox.Items)
            {
                if (!item.ToString().Contains('['))
                {
                    query += '[' + item.ToString() + "], ";
                }
                else
                {
                    query += item.ToString() + ", ";
                }
            }
            query = query.Remove(query.Length - 2, 2);
            query += "\r\n";
        }

        private void BuildConditions()
        {
            if (conditionsDataGridView.Rows.Count != 0)
            {
                query += "WHERE ";
                string condition = "";

                for (int i = 0; i < conditionsDataGridView.Rows.Count; ++i)
                {
                    string @operator = conditionsDataGridView.Rows[i].Cells[1].Value.ToString().
                        Split('(').Last().Split(')').First();
                    string value = "";

                    if (@operator == "Query")
                    {
                        //
                    }
                    else
                    {
                        if (fromListBox.Items.Count == 1) condition += "[";
                        condition += conditionsDataGridView.Rows[i].Cells[0].Value;
                        if (fromListBox.Items.Count == 1) condition += "]";

                        if (conditionsValueComboBox.Items.Contains(conditionsDataGridView.Rows[i].Cells[2].Value.ToString()))
                        {
                            value = conditionsDataGridView.Rows[i].Cells[2].Value.ToString().
                                Split('(').Last().Split(')').First();
                        }

                        if (value == "IS NULL")
                        {
                            condition += " IS NULL";
                        }
                        else
                        {
                            if (@operator == "LIKE" || @operator == "NOT LIKE")
                            {
                                condition += ' ' + @operator + ' ';
                                condition += "'" + conditionsDataGridView.Rows[i].Cells[2].Value + "'";
                            }
                            else
                            {
                                if (value == "True" || value == "False")
                                {
                                    condition += ' ' + @operator + ' ';
                                    condition += ' ' + value;
                                }
                                else
                                {
                                    condition += ' ' + @operator + ' ';
                                    if (value.Contains("[Запрос]"))
                                    {

                                    }
                                    else
                                    {
                                        condition += conditionsDataGridView.Rows[i].Cells[2].Value;
                                        if (conditionsDataGridView.Rows[i].Cells[2].Value.ToString() == "")
                                        {
                                            condition += '0';
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (i != conditionsDataGridView.Rows.Count - 1)
                    {
                        switch (conditionsDataGridView.Rows[i].Cells[3].Value.ToString())
                        {
                            case "OR":
                                condition += " OR ";
                                break;
                            case "( ) OR":
                                condition = "(" + condition + ") OR ";
                                break;
                            case "AND":
                                condition += " AND ";
                                break;
                            case "( ) AND":
                                condition = "(" + condition + ") AND ";
                                break;
                        }
                    }
                }
                query += condition;
                query += "\r\n";
            }
        }

        private void BuildGroupBy()
        {
            if (groupByFieldComboBox.SelectedItem != null)
            {
                query += "GROUP BY ";
                if (fromListBox.Items.Count == 1) query += "[";
                query += groupByFieldComboBox.SelectedItem;
                if (fromListBox.Items.Count == 1) query += "]";
                query += "\r\n";

                if (groupByFunctionComboBox.SelectedItem != null &&
                    groupByOfFieldComboBox.SelectedItem != null &&
                    groupByOperatorComboBox.SelectedItem != null &&
                    groupByValueComboBox.Text != "")
                {
                    query += "HAVING ";

                    string function = groupByFunctionComboBox.SelectedItem.ToString().
                        Split('(').Last().Split(')').First();
                    query += function + "(";

                    if (fromListBox.Items.Count == 1) query += "[";
                    query += groupByOfFieldComboBox.SelectedItem;
                    if (fromListBox.Items.Count == 1) query += "]";
                    query += ")";
                    
                    string @operator = groupByOperatorComboBox.SelectedItem.ToString().
                        Split('(').Last().Split(')').First();

                    if (groupByValueComboBox.SelectedIndex == 0)
                    {
                        query += " IS NULL";
                    }
                    else
                    {
                        if (groupByValueComboBox.SelectedIndex == 1)
                        {
                            query += " " + @operator + " True";
                        }
                        else if (groupByValueComboBox.SelectedIndex == 2)
                        {
                            query += " " + @operator + " False";
                        }
                        else
                        {
                            query += " " + @operator + " " + groupByValueComboBox.Text;
                        }
                    }
                }
                query += "\r\n";
            }
        }

        private void BuildOrderBy()
        {
            if (orderByFieldComboBox.SelectedItem != null)
            {
                query += "ORDER BY ";

                if (fromListBox.Items.Count == 1) query += "[";
                query += orderByFieldComboBox.SelectedItem;
                if (fromListBox.Items.Count == 1) query += "]";

                if (orderByOrderComboBox.SelectedItem != null)
                {
                    if (orderByOrderComboBox.SelectedIndex == 0)
                    {
                        query += " ASC";
                    }
                    else
                    {
                        query += " DESC";
                    }
                }
            }
        }

        private void addQueryButton_Click(object sender, EventArgs e)
        {
            query = "";

            if (selectListBox.Items.Count != 0 ||
                functionDataGridView.Rows.Count != 0)
            {
                BuildSelect();
                BuildFunctions();
                BuildFrom();
                BuildConditions();
                BuildGroupBy();
                BuildOrderBy();

                if (Program.debugMode)
                {
                    parentWindow.parentWindow.debugWindow.ShowQueryString(query);
                }

                try
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                    parentWindow.queries.Add(new Query(query, "Запрос_" + (parentWindow.queries.Count + 1).ToString()));
                    parentWindow.currentTable = parentWindow.queries[parentWindow.queries.Count - 1].name;
                    parentWindow.currentTableType = 2;
                    parentWindow.UpdateDataViewQuery(query);
                    parentWindow.UpdateDataSources();
                    exit = false;
                    Close();
                }
                catch
                {
                    MessageBox.Show(
                        "Не удалось выполнить данный запрос.",
                        "Не удалось создать запрос",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                    parentWindow.queries.RemoveAt(parentWindow.queries.Count - 1);
                }
            }
            else
            {
                MessageBox.Show(
                    "Не выбраны поля для выборки данных.",
                    "Не удалось создать запрос",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
        }

        private void groupByFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupByFunctionComboBox.SelectedIndex = 0;
            groupByOfFieldComboBox.SelectedIndex = 0;
            groupByOperatorComboBox.SelectedIndex = 0;
        }

        private void orderByFieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            orderByOrderComboBox.SelectedIndex = 0;
        }

        private void BuildJoinSelect()
        {
            query += "SELECT ";
            foreach (var item in joinSelectListBox.Items)
            {
                query += item.ToString() + ", ";
            }
            query = query.Remove(query.Length - 2, 2);
            query += "\r\n";
        }

        private void BuildJoinFrom()
        {
            query += "FROM ";
            if (!joinLeftComboBox.SelectedItem.ToString().Contains('['))
            {
                query += '[' + joinLeftComboBox.SelectedItem.ToString() + ']';
            }
            else
            {
                query += joinLeftComboBox.SelectedItem.ToString();
            }
        }

        private void BuildJoinJoin()
        {
            if (radioButton1.Checked)
            {
                query += " INNER JOIN ";
            }
            else if (radioButton2.Checked)
            {
                query += " LEFT JOIN ";
            }
            else if (radioButton3.Checked)
            {
                query += " LEFT OUTER JOIN ";
            }
            else if (radioButton4.Checked)
            {
                query += " RIGHT JOIN ";
            }
            else if (radioButton5.Checked)
            {
                query += " RIGHT OUTER JOIN ";
            }
            else if (radioButton6.Checked)
            {
                query += " FULL OUTER JOIN ";
            }
            query += '[' + joinRightComboBox.SelectedItem.ToString() + "]\r\n";
        }

        private void BuildJoinOn()
        {
            query += "ON ";

            string @operator = joinConditionsOperatorComboBox.SelectedItem.ToString().
                Split('(').Last().Split(')').First();
            string value = "";

            if (@operator == "Query")
            {
                //
            }
            else
            {
                query += joinConditionsFieldComboBox.SelectedItem;

                if (joinConditionsValueComboBox.Items.Contains(joinConditionsValueComboBox.Text))
                {
                    value = joinConditionsValueComboBox.Text.
                        Split('(').Last().Split(')').First();
                }

                if (value == "IS NULL")
                {
                    query += " IS NULL";
                }
                else
                {
                    if (@operator == "LIKE" || @operator == "NOT LIKE")
                    {
                        query += ' ' + @operator + ' ';
                        query += "'" + joinConditionsValueComboBox.Text + "'";
                    }
                    else
                    {
                        if (value == "True" || value == "False")
                        {
                            query += ' ' + @operator + ' ';
                            query += ' ' + value;
                        }
                        else
                        {
                            query += ' ' + @operator + ' ';
                            query += joinConditionsValueComboBox.Text;
                            if (joinConditionsValueComboBox.Text == "")
                            {
                                query += '0';
                            }
                        }
                    }
                }
            }
            query += "\r\n";
        }

        private void joinAddQueryButton_Click(object sender, EventArgs e)
        {
            query = "";

            if (joinSelectListBox.Items.Count != 0 &&
                joinConditionsFieldComboBox.SelectedItem != null &&
                joinConditionsOperatorComboBox.SelectedItem != null)
            {
                BuildJoinSelect();
                BuildJoinFrom();
                BuildJoinJoin();
                BuildJoinOn();

                if (Program.debugMode)
                {
                    parentWindow.parentWindow.debugWindow.ShowQueryString(query);
                }

                try
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                    parentWindow.queries.Add(new Query(query, "Запрос_" + (parentWindow.queries.Count + 1).ToString()));
                    parentWindow.currentTable = parentWindow.queries[parentWindow.queries.Count - 1].name;
                    parentWindow.currentTableType = 2;
                    parentWindow.UpdateDataViewQuery(query);
                    parentWindow.UpdateDataSources();
                    exit = false;
                    Close();
                }
                catch
                {
                    MessageBox.Show(
                        "Не удалось выполнить данный запрос.",
                        "Не удалось создать запрос",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                    parentWindow.queries.RemoveAt(parentWindow.queries.Count - 1);
                }
            }
            else
            {
                MessageBox.Show(
                    "Не выбраны поля для выборки данных.",
                    "Не удалось создать запрос",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
        }

        private void queriesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (queriesCheckBox.Checked)
            {
                conditionsValueComboBox.Items.Clear();
                conditionsValueComboBox.ResetText();
                foreach (var query in parentWindow.queries)
                {
                    conditionsValueComboBox.Items.Add(query.name);
                }
            }
            else
            {
                conditionsValueComboBox.Items.Clear();
                conditionsValueComboBox.ResetText();
                conditionsValueComboBox.Items.Add("Пустое (IS NULL)");
                conditionsValueComboBox.Items.Add("Истина (True)");
                conditionsValueComboBox.Items.Add("Ложь (False)");
            }
        }
    }
}
