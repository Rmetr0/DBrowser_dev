
namespace DBrowser_dev
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переподключитьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьЗапросToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьЗапросToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инструментыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьИсточникиДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьПредставлениеДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьВсёToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.запросToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.queryTextButton = new System.Windows.Forms.Button();
            this.dataViewTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.chooseDataSourceButton = new System.Windows.Forms.Button();
            this.refreshDataSourcesButton = new System.Windows.Forms.Button();
            this.refreshDataViewButton = new System.Windows.Forms.Button();
            this.newQueryLowButton = new System.Windows.Forms.Button();
            this.dataViewLabel = new System.Windows.Forms.Label();
            this.dataSourcesLabel = new System.Windows.Forms.Label();
            this.dataSourcesComboBox = new System.Windows.Forms.ComboBox();
            this.dataSourcesListBox = new System.Windows.Forms.ListBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.aboutButton = new System.Windows.Forms.Button();
            this.loadQueryButton = new System.Windows.Forms.Button();
            this.refreshTabButton = new System.Windows.Forms.Button();
            this.saveQueryButton = new System.Windows.Forms.Button();
            this.newQueryButton = new System.Windows.Forms.Button();
            this.closeTabButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.инструментыToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.переподключитьсяToolStripMenuItem,
            this.toolStripSeparator3,
            this.сохранитьЗапросToolStripMenuItem,
            this.загрузитьЗапросToolStripMenuItem,
            this.toolStripSeparator2,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // переподключитьсяToolStripMenuItem
            // 
            this.переподключитьсяToolStripMenuItem.Name = "переподключитьсяToolStripMenuItem";
            this.переподключитьсяToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.переподключитьсяToolStripMenuItem.Text = "Переподключиться...";
            this.переподключитьсяToolStripMenuItem.Click += new System.EventHandler(this.переподключитьсяToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
            // 
            // сохранитьЗапросToolStripMenuItem
            // 
            this.сохранитьЗапросToolStripMenuItem.Enabled = false;
            this.сохранитьЗапросToolStripMenuItem.Name = "сохранитьЗапросToolStripMenuItem";
            this.сохранитьЗапросToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.сохранитьЗапросToolStripMenuItem.Text = "Сохранить запрос";
            this.сохранитьЗапросToolStripMenuItem.Click += new System.EventHandler(this.сохранитьЗапросToolStripMenuItem_Click);
            // 
            // загрузитьЗапросToolStripMenuItem
            // 
            this.загрузитьЗапросToolStripMenuItem.Name = "загрузитьЗапросToolStripMenuItem";
            this.загрузитьЗапросToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.загрузитьЗапросToolStripMenuItem.Text = "Открыть запрос...";
            this.загрузитьЗапросToolStripMenuItem.Click += new System.EventHandler(this.загрузитьЗапросToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // инструментыToolStripMenuItem
            // 
            this.инструментыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьToolStripMenuItem,
            this.обновитьВсёToolStripMenuItem,
            this.toolStripSeparator1,
            this.запросToolStripMenuItem});
            this.инструментыToolStripMenuItem.Name = "инструментыToolStripMenuItem";
            this.инструментыToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.инструментыToolStripMenuItem.Text = "Инструменты";
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьИсточникиДанныхToolStripMenuItem,
            this.обновитьПредставлениеДанныхToolStripMenuItem});
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.обновитьToolStripMenuItem.Text = "Обновить...";
            // 
            // обновитьИсточникиДанныхToolStripMenuItem
            // 
            this.обновитьИсточникиДанныхToolStripMenuItem.Name = "обновитьИсточникиДанныхToolStripMenuItem";
            this.обновитьИсточникиДанныхToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.обновитьИсточникиДанныхToolStripMenuItem.Text = "Обновить источники данных";
            this.обновитьИсточникиДанныхToolStripMenuItem.Click += new System.EventHandler(this.обновитьИсточникиДанныхToolStripMenuItem_Click);
            // 
            // обновитьПредставлениеДанныхToolStripMenuItem
            // 
            this.обновитьПредставлениеДанныхToolStripMenuItem.Name = "обновитьПредставлениеДанныхToolStripMenuItem";
            this.обновитьПредставлениеДанныхToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.обновитьПредставлениеДанныхToolStripMenuItem.Text = "Обновить представление данных";
            this.обновитьПредставлениеДанныхToolStripMenuItem.Click += new System.EventHandler(this.обновитьПредставлениеДанныхToolStripMenuItem_Click);
            // 
            // обновитьВсёToolStripMenuItem
            // 
            this.обновитьВсёToolStripMenuItem.Name = "обновитьВсёToolStripMenuItem";
            this.обновитьВсёToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.обновитьВсёToolStripMenuItem.Text = "Обновить всё";
            this.обновитьВсёToolStripMenuItem.Click += new System.EventHandler(this.обновитьВсёToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // запросToolStripMenuItem
            // 
            this.запросToolStripMenuItem.Name = "запросToolStripMenuItem";
            this.запросToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.запросToolStripMenuItem.Text = "Запрос...";
            this.запросToolStripMenuItem.Click += new System.EventHandler(this.запросToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage1.Controls.Add(this.queryTextButton);
            this.tabPage1.Controls.Add(this.dataViewTextBox);
            this.tabPage1.Controls.Add(this.dataGridView);
            this.tabPage1.Controls.Add(this.chooseDataSourceButton);
            this.tabPage1.Controls.Add(this.refreshDataSourcesButton);
            this.tabPage1.Controls.Add(this.refreshDataViewButton);
            this.tabPage1.Controls.Add(this.newQueryLowButton);
            this.tabPage1.Controls.Add(this.dataViewLabel);
            this.tabPage1.Controls.Add(this.dataSourcesLabel);
            this.tabPage1.Controls.Add(this.dataSourcesComboBox);
            this.tabPage1.Controls.Add(this.dataSourcesListBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Таблицы";
            // 
            // queryTextButton
            // 
            this.queryTextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.queryTextButton.Enabled = false;
            this.queryTextButton.Location = new System.Drawing.Point(328, 325);
            this.queryTextButton.Name = "queryTextButton";
            this.queryTextButton.Size = new System.Drawing.Size(95, 23);
            this.queryTextButton.TabIndex = 13;
            this.queryTextButton.Text = "Текст запроса";
            this.queryTextButton.UseVisualStyleBackColor = true;
            this.queryTextButton.Click += new System.EventHandler(this.queryTextButton_Click);
            // 
            // dataViewTextBox
            // 
            this.dataViewTextBox.Location = new System.Drawing.Point(460, 41);
            this.dataViewTextBox.Name = "dataViewTextBox";
            this.dataViewTextBox.ReadOnly = true;
            this.dataViewTextBox.Size = new System.Drawing.Size(169, 20);
            this.dataViewTextBox.TabIndex = 12;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Enabled = false;
            this.dataGridView.Location = new System.Drawing.Point(328, 67);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(441, 252);
            this.dataGridView.TabIndex = 11;
            // 
            // chooseDataSourceButton
            // 
            this.chooseDataSourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chooseDataSourceButton.Location = new System.Drawing.Point(122, 325);
            this.chooseDataSourceButton.Name = "chooseDataSourceButton";
            this.chooseDataSourceButton.Size = new System.Drawing.Size(88, 23);
            this.chooseDataSourceButton.TabIndex = 10;
            this.chooseDataSourceButton.Text = "Выбрать";
            this.chooseDataSourceButton.UseVisualStyleBackColor = true;
            this.chooseDataSourceButton.Click += new System.EventHandler(this.chooseDataSourceButton_Click);
            // 
            // refreshDataSourcesButton
            // 
            this.refreshDataSourcesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refreshDataSourcesButton.Location = new System.Drawing.Point(28, 325);
            this.refreshDataSourcesButton.Name = "refreshDataSourcesButton";
            this.refreshDataSourcesButton.Size = new System.Drawing.Size(88, 23);
            this.refreshDataSourcesButton.TabIndex = 9;
            this.refreshDataSourcesButton.Text = "Обновить";
            this.refreshDataSourcesButton.UseVisualStyleBackColor = true;
            this.refreshDataSourcesButton.Click += new System.EventHandler(this.refreshDataSourcesButton_Click);
            // 
            // refreshDataViewButton
            // 
            this.refreshDataViewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshDataViewButton.Enabled = false;
            this.refreshDataViewButton.Location = new System.Drawing.Point(587, 325);
            this.refreshDataViewButton.Name = "refreshDataViewButton";
            this.refreshDataViewButton.Size = new System.Drawing.Size(88, 23);
            this.refreshDataViewButton.TabIndex = 8;
            this.refreshDataViewButton.Text = "Обновить";
            this.refreshDataViewButton.UseVisualStyleBackColor = true;
            this.refreshDataViewButton.Click += new System.EventHandler(this.refreshDataViewsButton_Click);
            // 
            // newQueryLowButton
            // 
            this.newQueryLowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newQueryLowButton.Enabled = false;
            this.newQueryLowButton.Location = new System.Drawing.Point(681, 325);
            this.newQueryLowButton.Name = "newQueryLowButton";
            this.newQueryLowButton.Size = new System.Drawing.Size(88, 23);
            this.newQueryLowButton.TabIndex = 7;
            this.newQueryLowButton.Text = "Запрос...";
            this.newQueryLowButton.UseVisualStyleBackColor = true;
            this.newQueryLowButton.Click += new System.EventHandler(this.newQueryLowButton_Click);
            // 
            // dataViewLabel
            // 
            this.dataViewLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataViewLabel.AutoSize = true;
            this.dataViewLabel.Enabled = false;
            this.dataViewLabel.Location = new System.Drawing.Point(325, 44);
            this.dataViewLabel.Name = "dataViewLabel";
            this.dataViewLabel.Size = new System.Drawing.Size(129, 13);
            this.dataViewLabel.TabIndex = 6;
            this.dataViewLabel.Text = "Представление данных:";
            // 
            // dataSourcesLabel
            // 
            this.dataSourcesLabel.AutoSize = true;
            this.dataSourcesLabel.Location = new System.Drawing.Point(25, 44);
            this.dataSourcesLabel.Name = "dataSourcesLabel";
            this.dataSourcesLabel.Size = new System.Drawing.Size(104, 13);
            this.dataSourcesLabel.TabIndex = 3;
            this.dataSourcesLabel.Text = "Источники данных:";
            // 
            // dataSourcesComboBox
            // 
            this.dataSourcesComboBox.FormattingEnabled = true;
            this.dataSourcesComboBox.Items.AddRange(new object[] {
            "Таблицы",
            "Представления",
            "Запросы"});
            this.dataSourcesComboBox.Location = new System.Drawing.Point(131, 41);
            this.dataSourcesComboBox.Name = "dataSourcesComboBox";
            this.dataSourcesComboBox.Size = new System.Drawing.Size(121, 21);
            this.dataSourcesComboBox.TabIndex = 2;
            this.dataSourcesComboBox.SelectedIndexChanged += new System.EventHandler(this.tablesComboBox_SelectedIndexChanged);
            // 
            // dataSourcesListBox
            // 
            this.dataSourcesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataSourcesListBox.FormattingEnabled = true;
            this.dataSourcesListBox.Location = new System.Drawing.Point(28, 68);
            this.dataSourcesListBox.Name = "dataSourcesListBox";
            this.dataSourcesListBox.Size = new System.Drawing.Size(224, 251);
            this.dataSourcesListBox.TabIndex = 1;
            this.dataSourcesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataSourcesListBox_MouseDoubleClick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 426);
            this.tabControl.TabIndex = 1;
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutButton.BackColor = System.Drawing.SystemColors.Control;
            this.aboutButton.BackgroundImage = global::DBrowser_dev.Properties.Resources.info;
            this.aboutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.ForeColor = System.Drawing.SystemColors.Control;
            this.aboutButton.Location = new System.Drawing.Point(646, 0);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(23, 23);
            this.aboutButton.TabIndex = 6;
            this.toolTip.SetToolTip(this.aboutButton, "О программе");
            this.aboutButton.UseVisualStyleBackColor = false;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // loadQueryButton
            // 
            this.loadQueryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadQueryButton.BackColor = System.Drawing.SystemColors.Control;
            this.loadQueryButton.BackgroundImage = global::DBrowser_dev.Properties.Resources.load;
            this.loadQueryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.loadQueryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadQueryButton.ForeColor = System.Drawing.SystemColors.Control;
            this.loadQueryButton.Location = new System.Drawing.Point(675, 0);
            this.loadQueryButton.Name = "loadQueryButton";
            this.loadQueryButton.Size = new System.Drawing.Size(23, 23);
            this.loadQueryButton.TabIndex = 4;
            this.toolTip.SetToolTip(this.loadQueryButton, "Открыть запрос...");
            this.loadQueryButton.UseVisualStyleBackColor = false;
            this.loadQueryButton.Click += new System.EventHandler(this.loadQueryButton_Click);
            // 
            // refreshTabButton
            // 
            this.refreshTabButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshTabButton.BackColor = System.Drawing.SystemColors.Control;
            this.refreshTabButton.BackgroundImage = global::DBrowser_dev.Properties.Resources.refresh;
            this.refreshTabButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.refreshTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshTabButton.ForeColor = System.Drawing.SystemColors.Control;
            this.refreshTabButton.Location = new System.Drawing.Point(750, 0);
            this.refreshTabButton.Name = "refreshTabButton";
            this.refreshTabButton.Size = new System.Drawing.Size(23, 23);
            this.refreshTabButton.TabIndex = 2;
            this.toolTip.SetToolTip(this.refreshTabButton, "Обновить вкладку");
            this.refreshTabButton.UseVisualStyleBackColor = false;
            this.refreshTabButton.Click += new System.EventHandler(this.refreshTabButton_Click);
            // 
            // saveQueryButton
            // 
            this.saveQueryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveQueryButton.BackColor = System.Drawing.SystemColors.Control;
            this.saveQueryButton.BackgroundImage = global::DBrowser_dev.Properties.Resources.save3;
            this.saveQueryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveQueryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveQueryButton.ForeColor = System.Drawing.SystemColors.Control;
            this.saveQueryButton.Location = new System.Drawing.Point(698, 0);
            this.saveQueryButton.Name = "saveQueryButton";
            this.saveQueryButton.Size = new System.Drawing.Size(23, 23);
            this.saveQueryButton.TabIndex = 3;
            this.toolTip.SetToolTip(this.saveQueryButton, "Сохранить запрос");
            this.saveQueryButton.UseVisualStyleBackColor = false;
            this.saveQueryButton.Click += new System.EventHandler(this.saveQueryButton_Click);
            // 
            // newQueryButton
            // 
            this.newQueryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newQueryButton.BackColor = System.Drawing.SystemColors.Control;
            this.newQueryButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("newQueryButton.BackgroundImage")));
            this.newQueryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.newQueryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newQueryButton.ForeColor = System.Drawing.SystemColors.Control;
            this.newQueryButton.Location = new System.Drawing.Point(727, 0);
            this.newQueryButton.Name = "newQueryButton";
            this.newQueryButton.Size = new System.Drawing.Size(23, 23);
            this.newQueryButton.TabIndex = 5;
            this.toolTip.SetToolTip(this.newQueryButton, "Новый запрос...");
            this.newQueryButton.UseVisualStyleBackColor = false;
            this.newQueryButton.Click += new System.EventHandler(this.newQueryButton_Click);
            // 
            // closeTabButton
            // 
            this.closeTabButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeTabButton.BackColor = System.Drawing.SystemColors.Control;
            this.closeTabButton.BackgroundImage = global::DBrowser_dev.Properties.Resources.delete;
            this.closeTabButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.closeTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeTabButton.ForeColor = System.Drawing.SystemColors.Control;
            this.closeTabButton.Location = new System.Drawing.Point(773, 0);
            this.closeTabButton.Name = "closeTabButton";
            this.closeTabButton.Size = new System.Drawing.Size(23, 23);
            this.closeTabButton.TabIndex = 0;
            this.toolTip.SetToolTip(this.closeTabButton, "Закрыть запрос");
            this.closeTabButton.UseVisualStyleBackColor = false;
            this.closeTabButton.Click += new System.EventHandler(this.closeTabButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.loadQueryButton);
            this.Controls.Add(this.refreshTabButton);
            this.Controls.Add(this.saveQueryButton);
            this.Controls.Add(this.newQueryButton);
            this.Controls.Add(this.closeTabButton);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(675, 350);
            this.Name = "MainWindow";
            this.Text = "DBrowser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инструментыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переподключитьсяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem сохранитьЗапросToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьЗапросToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Button closeTabButton;
        private System.Windows.Forms.Button refreshTabButton;
        private System.Windows.Forms.Button saveQueryButton;
        private System.Windows.Forms.Button loadQueryButton;
        private System.Windows.Forms.Button newQueryButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.ToolStripMenuItem обновитьИсточникиДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьПредставлениеДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьВсёToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem запросToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button queryTextButton;
        private System.Windows.Forms.TextBox dataViewTextBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button chooseDataSourceButton;
        private System.Windows.Forms.Button refreshDataSourcesButton;
        private System.Windows.Forms.Button refreshDataViewButton;
        private System.Windows.Forms.Button newQueryLowButton;
        private System.Windows.Forms.Label dataViewLabel;
        private System.Windows.Forms.Label dataSourcesLabel;
        private System.Windows.Forms.ComboBox dataSourcesComboBox;
        private System.Windows.Forms.ListBox dataSourcesListBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}