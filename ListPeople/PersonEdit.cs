using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ListPeople
{
    public partial class PersonEdit : Form
    {
        public event EventHandler DataSaved;
        public Form1 Form;

        private int _id;
        private string _name;
        private string _lastName;
        private string _otchestvo;
        private int _age;
        public PersonEdit()
        {
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
        private void Save_Click(object sender, EventArgs e)
        {
            Id = int.Parse(txtId.Text);
            Name1 = txtName.Text;
            Name2 = txtLastName.Text;
            Name3 = txtOtchestvo.Text;
            Age = int.Parse(txtAge.Text);

            DataSaved?.Invoke(this, EventArgs.Empty);

            Form1 form = new Form1();
            form.UpdateMainFormValues();
            Close();

        }
    }
}
