using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListPeople
{
    public partial class Form1 : Form
    {
        public List<PersonMain> _users = new List<PersonMain>();

        private Button addUserButton = new Button()
        {
            Text = "Добавить",
            Dock = DockStyle.Fill
        };
        private Label totalUsersLbl = new Label()
        {
            Text = "Всего записей:",
            Anchor = AnchorStyles.Left
        };
        private TextBox totalUsersTB = new TextBox()
        {
            Anchor = AnchorStyles.Left
        };
        private Label sumAgeLbl = new Label()
        {
            Text = "Сумма лет:",
            Anchor = AnchorStyles.Left
        };
        private TextBox sumAgeTB = new TextBox()
        {
            Anchor = AnchorStyles.Left
        };
        private FlowLayoutPanel userPanel = new FlowLayoutPanel()
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            BackColor = Color.Black
        };
        public Form1()
        {
            addUserButton.Click += AddUser_Click;
            this.Load += Form1_Load;

            InitializeComponent();
        }
        private void AddUser_Click(object sender, EventArgs e)
        {
            PersonMain prc = new PersonMain();
            int count = _users.Count;
            _users.Add(prc);
            prc.BackColor = Color.Green;
            userPanel.Controls.Add(_users[count]);
            UpdateMainFormValues();
            this.PerformLayout();
        }

        public void UpdateMainFormValues()
        {
            int totalUsers = _users.Count;
            int totalAge = 0;
            foreach (var control in _users)
            {
                totalAge += control.Age;
            }
            totalUsersTB.Text = totalUsers.ToString();
            sumAgeTB.Text = totalAge.ToString();
        }

        private void PersonMain_DeleteClicked(object sender, EventArgs e)
        {
            var userControlToRemove = (PersonMain)sender;
            userControlToRemove.DeleteClicked -= PersonMain_DeleteClicked;
            userPanel.Controls.Remove(userControlToRemove);
            _users.Remove(userControlToRemove);
            UpdateMainFormValues(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var table = new TableLayoutPanel();
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 70));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            table.Controls.Add(addUserButton, 0, 0);
            table.SetRowSpan(addUserButton, 2);
            table.Controls.Add(totalUsersLbl, 1, 0);
            table.Controls.Add(totalUsersTB, 2, 0);
            table.Controls.Add(sumAgeLbl, 1, 1);
            table.Controls.Add(sumAgeTB, 2, 1);
            table.Controls.Add(userPanel, 0, 2);
            table.SetColumnSpan(userPanel, 3);
            table.Dock = DockStyle.Fill;
            UpdateMainFormValues();
            Controls.Add(table);
            foreach (var userControl in _users)
            {
                userControl.DeleteClicked += PersonMain_DeleteClicked;
            }
        }
    }
}
