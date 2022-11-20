using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4
{
    public partial class Form1 : Form
    {
        Customer customer = new Customer();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)                              //Insert buttonn
        {
            customer.CompanyName = textBox2.Text;
            customer.ContactName = textBox3.Text;
            customer.Phone = textBox4.Text;

            var success = customer.InsertEmployee(customer);
            dataGridView1.DataSource = customer.GetCustomer();
            if (success)
            {
                ClearControls();
                MessageBox.Show("Data added successfully");
            }
            else
            {
                MessageBox.Show("Error occured!!!!!! Please try again... ");
            }
        }

        private void ClearControls()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button4_Click(object sender, EventArgs e)                          //update button
        {
            customer.CompanyID = textBox1.Text;
            customer.CompanyName = textBox2.Text;
            customer.ContactName = textBox3.Text;
            customer.Phone = textBox4.Text;

            var success = customer.UpdateEmployee(customer);
            dataGridView1.DataSource = customer.GetCustomer();
            if (success)
            {
                ClearControls();
                MessageBox.Show("Data updated successfully");

            }
            else
            {
                MessageBox.Show("Error occured!!!! Please try again...\n Did you select any ID???");
            }
        }

        private void button3_Click(object sender, EventArgs e)                          //delete button
        {
            customer.CompanyID = textBox1.Text;
            var success = customer.DeleteEmployee(customer);
            dataGridView1.DataSource = customer.GetCustomer();
            if (success)
            {
                ClearControls();
                MessageBox.Show("Data deleted successfully");

            }
            else
            {
                MessageBox.Show("Error occured!!!! Please try again... \n Did you select/write any ID???");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)         //load data into fields
        {
            var index = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)                    //show button
        {
            dataGridView1.DataSource = customer.GetCustomer();
        }
    }
}
