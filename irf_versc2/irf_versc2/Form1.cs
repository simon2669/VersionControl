using irf_versc2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace irf_versc2
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.LastName; // label1
            label2.Text = Resource1.FirstName; // label2
            button1.Text = Resource1.Add; // button1


            // listbox1
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                LastName = textBox1.Text,
                FirstName = textBox2.Text
            };
            users.Add(u);
        }
    }
}
