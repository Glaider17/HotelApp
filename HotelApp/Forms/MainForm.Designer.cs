namespace HotelApp.Forms
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            ФайлToolStripMenuItem = new ToolStripMenuItem();
            exitMenuItem = new ToolStripMenuItem();
            гостиницаToolStripMenuItem = new ToolStripMenuItem();
            roomsMenuItem = new ToolStripMenuItem();
            guestsMenuItem = new ToolStripMenuItem();
            bookingsMenuItem = new ToolStripMenuItem();
            сервисToolStripMenuItem = new ToolStripMenuItem();
            servicesMenuItem = new ToolStripMenuItem();
            paymentsMenuItem = new ToolStripMenuItem();
            администрированиеToolStripMenuItem = new ToolStripMenuItem();
            logsMenuItem = new ToolStripMenuItem();
            actionLogsMenuItem = new ToolStripMenuItem();
            summaryPanel = new Panel();
            lblFreeRooms = new Label();
            lblCheckIns = new Label();
            lblCheckOuts = new Label();
            lblSearchBookings = new Label();
            txtSearchBooking = new TextBox();
            btnSearch = new Button();
            dgvRecentBookings = new DataGridView();
            menuStrip1.SuspendLayout();
            summaryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentBookings).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ФайлToolStripMenuItem, гостиницаToolStripMenuItem, сервисToolStripMenuItem, администрированиеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(936, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // ФайлToolStripMenuItem
            // 
            ФайлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitMenuItem });
            ФайлToolStripMenuItem.Name = "ФайлToolStripMenuItem";
            ФайлToolStripMenuItem.Size = new Size(48, 20);
            ФайлToolStripMenuItem.Text = "Файл";
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.Size = new Size(180, 22);
            exitMenuItem.Text = "Выход";
            exitMenuItem.Click += exitMenuItem_Click;
            // 
            // гостиницаToolStripMenuItem
            // 
            гостиницаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { roomsMenuItem, guestsMenuItem, bookingsMenuItem });
            гостиницаToolStripMenuItem.Name = "гостиницаToolStripMenuItem";
            гостиницаToolStripMenuItem.Size = new Size(77, 20);
            гостиницаToolStripMenuItem.Text = "Гостиница";
            // 
            // roomsMenuItem
            // 
            roomsMenuItem.Name = "roomsMenuItem";
            roomsMenuItem.Size = new Size(180, 22);
            roomsMenuItem.Text = "Номера";
            roomsMenuItem.Click += roomsMenuItem_Click;
            // 
            // guestsMenuItem
            // 
            guestsMenuItem.Name = "guestsMenuItem";
            guestsMenuItem.Size = new Size(180, 22);
            guestsMenuItem.Text = "Гости";
            guestsMenuItem.Click += guestsMenuItem_Click;
            // 
            // bookingsMenuItem
            // 
            bookingsMenuItem.Name = "bookingsMenuItem";
            bookingsMenuItem.Size = new Size(180, 22);
            bookingsMenuItem.Text = "Бронирования";
            bookingsMenuItem.Click += bookingsMenuItem_Click;
            // 
            // сервисToolStripMenuItem
            // 
            сервисToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { servicesMenuItem, paymentsMenuItem });
            сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            сервисToolStripMenuItem.Size = new Size(59, 20);
            сервисToolStripMenuItem.Text = "Сервис";
            // 
            // servicesMenuItem
            // 
            servicesMenuItem.Name = "servicesMenuItem";
            servicesMenuItem.Size = new Size(180, 22);
            servicesMenuItem.Text = "Услуги";
            servicesMenuItem.Click += servicesMenuItem_Click;
            // 
            // paymentsMenuItem
            // 
            paymentsMenuItem.Name = "paymentsMenuItem";
            paymentsMenuItem.Size = new Size(180, 22);
            paymentsMenuItem.Text = "Оплаты";
            paymentsMenuItem.Click += paymentsMenuItem_Click;
            // 
            // администрированиеToolStripMenuItem
            // 
            администрированиеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logsMenuItem, actionLogsMenuItem });
            администрированиеToolStripMenuItem.Name = "администрированиеToolStripMenuItem";
            администрированиеToolStripMenuItem.Size = new Size(134, 20);
            администрированиеToolStripMenuItem.Text = "Администрирование";
            // 
            // logsMenuItem
            // 
            logsMenuItem.Name = "logsMenuItem";
            logsMenuItem.Size = new Size(180, 22);
            logsMenuItem.Text = "Журнал входов";
            logsMenuItem.Click += logsMenuItem_Click;
            // 
            // actionLogsMenuItem
            // 
            actionLogsMenuItem.Name = "actionLogsMenuItem";
            actionLogsMenuItem.Size = new Size(180, 22);
            actionLogsMenuItem.Text = "Журнал действий";
            actionLogsMenuItem.Click += actionLogsMenuItem_Click;
            // 
            // summaryPanel
            // 
            summaryPanel.BorderStyle = BorderStyle.FixedSingle;
            summaryPanel.Controls.Add(lblFreeRooms);
            summaryPanel.Controls.Add(lblCheckIns);
            summaryPanel.Controls.Add(lblCheckOuts);
            summaryPanel.Location = new Point(20, 40);
            summaryPanel.Name = "summaryPanel";
            summaryPanel.Size = new Size(400, 120);
            summaryPanel.TabIndex = 1;
            // 
            // lblFreeRooms
            // 
            lblFreeRooms.AutoSize = true;
            lblFreeRooms.Location = new Point(10, 10);
            lblFreeRooms.Name = "lblFreeRooms";
            lblFreeRooms.Size = new Size(134, 15);
            lblFreeRooms.TabIndex = 2;
            lblFreeRooms.Text = "Свободных номеров: 0";
            // 
            // lblCheckIns
            // 
            lblCheckIns.AutoSize = true;
            lblCheckIns.Location = new Point(10, 45);
            lblCheckIns.Name = "lblCheckIns";
            lblCheckIns.Size = new Size(108, 15);
            lblCheckIns.TabIndex = 3;
            lblCheckIns.Text = "Заездов сегодня: 0";
            // 
            // lblCheckOuts
            // 
            lblCheckOuts.AutoSize = true;
            lblCheckOuts.Location = new Point(10, 80);
            lblCheckOuts.Name = "lblCheckOuts";
            lblCheckOuts.Size = new Size(111, 15);
            lblCheckOuts.TabIndex = 4;
            lblCheckOuts.Text = "Выездов сегодня: 0";
            // 
            // lblSearchBookings
            // 
            lblSearchBookings.AutoSize = true;
            lblSearchBookings.Location = new Point(450, 45);
            lblSearchBookings.Name = "lblSearchBookings";
            lblSearchBookings.Size = new Size(234, 15);
            lblSearchBookings.TabIndex = 2;
            lblSearchBookings.Text = "Поиск бронирований по фамилии гостя:";
            // 
            // txtSearchBooking
            // 
            txtSearchBooking.Location = new Point(680, 45);
            txtSearchBooking.Name = "txtSearchBooking";
            txtSearchBooking.Size = new Size(150, 23);
            txtSearchBooking.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(840, 44);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 28);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Искать";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvRecentBookings
            // 
            dgvRecentBookings.AllowUserToAddRows = false;
            dgvRecentBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecentBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecentBookings.Location = new Point(20, 180);
            dgvRecentBookings.Name = "dgvRecentBookings";
            dgvRecentBookings.ReadOnly = true;
            dgvRecentBookings.Size = new Size(900, 370);
            dgvRecentBookings.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 565);
            Controls.Add(dgvRecentBookings);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchBooking);
            Controls.Add(lblSearchBookings);
            Controls.Add(summaryPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            summaryPanel.ResumeLayout(false);
            summaryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentBookings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem ФайлToolStripMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem гостиницаToolStripMenuItem;
        private ToolStripMenuItem roomsMenuItem;
        private ToolStripMenuItem guestsMenuItem;
        private ToolStripMenuItem bookingsMenuItem;
        private ToolStripMenuItem сервисToolStripMenuItem;
        private ToolStripMenuItem servicesMenuItem;
        private ToolStripMenuItem paymentsMenuItem;
        private ToolStripMenuItem администрированиеToolStripMenuItem;
        private ToolStripMenuItem logsMenuItem;
        private ToolStripMenuItem actionLogsMenuItem;
        private Panel summaryPanel;
        private Label lblFreeRooms;
        private Label lblCheckIns;
        private Label lblCheckOuts;
        private Label lblSearchBookings;
        private TextBox txtSearchBooking;
        private Button btnSearch;
        private DataGridView dgvRecentBookings;
    }
}