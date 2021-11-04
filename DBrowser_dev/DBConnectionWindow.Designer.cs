
namespace DBrowser_dev
{
    partial class DBConnectionWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBConnectionWindow));
            this.servernameComboBox = new System.Windows.Forms.ComboBox();
            this.servernameLabel = new System.Windows.Forms.Label();
            this.databaseNameLabel = new System.Windows.Forms.Label();
            this.databaseNameComboBox = new System.Windows.Forms.ComboBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.gettingDataSourcesLabel = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // servernameComboBox
            // 
            this.servernameComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.servernameComboBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.servernameComboBox.DropDownWidth = 150;
            this.servernameComboBox.FormattingEnabled = true;
            this.servernameComboBox.Location = new System.Drawing.Point(147, 23);
            this.servernameComboBox.Name = "servernameComboBox";
            this.servernameComboBox.Size = new System.Drawing.Size(121, 21);
            this.servernameComboBox.TabIndex = 0;
            this.servernameComboBox.Visible = false;
            this.servernameComboBox.SelectionChangeCommitted += new System.EventHandler(this.servernameComboBox_SelectionChangeCommitted);
            this.servernameComboBox.TextUpdate += new System.EventHandler(this.servernameComboBox_TextUpdate);
            // 
            // servernameLabel
            // 
            this.servernameLabel.AutoSize = true;
            this.servernameLabel.Location = new System.Drawing.Point(12, 26);
            this.servernameLabel.Name = "servernameLabel";
            this.servernameLabel.Size = new System.Drawing.Size(105, 13);
            this.servernameLabel.TabIndex = 1;
            this.servernameLabel.Text = "Название сервера:";
            this.servernameLabel.Visible = false;
            // 
            // databaseNameLabel
            // 
            this.databaseNameLabel.AutoSize = true;
            this.databaseNameLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.databaseNameLabel.Location = new System.Drawing.Point(12, 53);
            this.databaseNameLabel.Name = "databaseNameLabel";
            this.databaseNameLabel.Size = new System.Drawing.Size(129, 13);
            this.databaseNameLabel.TabIndex = 3;
            this.databaseNameLabel.Text = "Название базы данных:";
            this.databaseNameLabel.Visible = false;
            // 
            // databaseNameComboBox
            // 
            this.databaseNameComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.databaseNameComboBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.databaseNameComboBox.DropDownWidth = 150;
            this.databaseNameComboBox.Enabled = false;
            this.databaseNameComboBox.FormattingEnabled = true;
            this.databaseNameComboBox.Location = new System.Drawing.Point(147, 50);
            this.databaseNameComboBox.Name = "databaseNameComboBox";
            this.databaseNameComboBox.Size = new System.Drawing.Size(121, 21);
            this.databaseNameComboBox.TabIndex = 2;
            this.databaseNameComboBox.Visible = false;
            this.databaseNameComboBox.SelectionChangeCommitted += new System.EventHandler(this.databaseNameComboBox_SelectionChangeCommitted);
            this.databaseNameComboBox.TextUpdate += new System.EventHandler(this.databaseNameComboBox_TextUpdate);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.usernameTextBox.Enabled = false;
            this.usernameTextBox.Location = new System.Drawing.Point(147, 77);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.usernameTextBox.TabIndex = 4;
            this.usernameTextBox.Visible = false;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.usernameLabel.Location = new System.Drawing.Point(12, 80);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(106, 13);
            this.usernameLabel.TabIndex = 5;
            this.usernameLabel.Text = "Имя пользователя:";
            this.usernameLabel.Visible = false;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.passwordLabel.Location = new System.Drawing.Point(12, 106);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(48, 13);
            this.passwordLabel.TabIndex = 7;
            this.passwordLabel.Text = "Пароль:";
            this.passwordLabel.Visible = false;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordTextBox.Enabled = false;
            this.passwordTextBox.Location = new System.Drawing.Point(147, 103);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 6;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.Visible = false;
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.connectButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.connectButton.Enabled = false;
            this.connectButton.Location = new System.Drawing.Point(287, 124);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(113, 23);
            this.connectButton.TabIndex = 9;
            this.connectButton.Text = "Подключиться";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.connectButton_MouseClick);
            // 
            // gettingDataSourcesLabel
            // 
            this.gettingDataSourcesLabel.AutoSize = true;
            this.gettingDataSourcesLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gettingDataSourcesLabel.Location = new System.Drawing.Point(13, 26);
            this.gettingDataSourcesLabel.Name = "gettingDataSourcesLabel";
            this.gettingDataSourcesLabel.Size = new System.Drawing.Size(160, 13);
            this.gettingDataSourcesLabel.TabIndex = 10;
            this.gettingDataSourcesLabel.Text = "Получение списка серверов...";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoPictureBox.Image = global::DBrowser_dev.Properties.Resources.dbrowser;
            this.logoPictureBox.Location = new System.Drawing.Point(305, 12);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(85, 85);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 8;
            this.logoPictureBox.TabStop = false;
            // 
            // DBConnectionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(412, 159);
            this.Controls.Add(this.gettingDataSourcesLabel);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.databaseNameLabel);
            this.Controls.Add(this.databaseNameComboBox);
            this.Controls.Add(this.servernameLabel);
            this.Controls.Add(this.servernameComboBox);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DBConnectionWindow";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подключение к базе данных";
            this.Load += new System.EventHandler(this.DBConnectionWindow_Load);
            this.Shown += new System.EventHandler(this.DBConnectionWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox servernameComboBox;
        private System.Windows.Forms.Label servernameLabel;
        private System.Windows.Forms.Label databaseNameLabel;
        private System.Windows.Forms.ComboBox databaseNameComboBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label gettingDataSourcesLabel;
    }
}

