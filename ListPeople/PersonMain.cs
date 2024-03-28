using System;

using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

using System.Xml.Linq;

namespace ListPeople
{
    public partial class PersonMain : UserControl
    {
        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler DataSaved;

        private int _id;
        private string _name;
        private string _lastName;
        private string _otchestvo;
        private int _age;
        public PersonMain()
        {
            EditClicked += Edit_Click;
            DeleteClicked += Delete_Click;
            InitializeComponent();
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; txtId.Text = value.ToString(); }
        }
        public string Name1
        {
            get { return _name; }
            set { _name = value; txtName.Text = value; }
        }
        public string Name2
        {
            get { return _lastName; }
            set { _lastName = value; txtLastName.Text = value; }
        }
        public string Name3
        {
            get { return _otchestvo; }
            set { _otchestvo = value; txtOtchestvo.Text = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; txtAge.Text = value.ToString(); }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            using(PersonEdit personEdit = new PersonEdit())
            {
                personEdit.Id = Id;
                personEdit.Name1 = Name1;   
                personEdit.Name2 = Name2;
                    personEdit.Name3 = Name3;
                personEdit.Age = Age;

                DataSaved += PersonMain_Data_Saved;
                if (personEdit.ShowDialog() == DialogResult.OK)
                {
                    Id = personEdit.Id;
                    Name1 = personEdit.Name1;
                    Name2 = personEdit.Name2;
                    Name3 = personEdit.Name3;
                    Age = personEdit.Age;
                }
            }
        }
        private void PersonMain_Data_Saved(object sender, EventArgs e)
        {
            var personEdit = (PersonEdit)sender;
            Id = personEdit.Id;
            Name1 = personEdit.Name1;
            Name2 = personEdit.Name2;
            Name3 = personEdit?.Name3;
            Age = personEdit.Age;
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            Form1 form1 = this.FindForm() as Form1;
            if (form1 != null) 
            {
                form1._users.Remove(this);
                form1.Update();
                this.Parent.Controls.Remove(this);
            }
        }
    }
}
