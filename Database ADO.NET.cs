using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_for_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtWork_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            databaseDataContext self = new databaseDataContext();
            var query = from P in self.CONSUMERs
                        where (P.IDNUM == txtWork.Text || txtWork.Text == "")
                        && (P.FNAME == textBox3.Text || textBox3.Text == "")
                        && (P.LNAME == textBox1.Text || textBox1.Text == "")
                        select P;

            dataGridView1.DataSource = query;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            databaseDataContext self = new databaseDataContext();

            if (txtWork.Text != "")
            {
                var hi = from p in self.CONSUMERs
                         where p.IDNUM == txtWork.Text
                         select p;
                if (hi.Count() != 0)
                {
                    var query = (from p in self.CONSUMERs
                                 where p.IDNUM == txtWork.Text
                                 select p
                               ).Single();
                    self.CONSUMERs.DeleteOnSubmit(query);
                    self.SubmitChanges();
                }
                else
                    MessageBox.Show("data doesn't exist");
            }
            else
                MessageBox.Show("please fill the id part or choose a row");
            var a = from P in self.CONSUMERs
                    select P;

            dataGridView1.DataSource = a;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            databaseDataContext self = new databaseDataContext();
            CONSUMER obj = new CONSUMER();
            if (txtWork.Text != "" && textBox3.Text != "" && textBox1.Text != "")
            {
                var query = from P in self.CONSUMERs
                            where (P.IDNUM == txtWork.Text)
                            select P;
                if (query.Count() == 0)
                {
                    obj.IDNUM = txtWork.Text;
                    obj.FNAME = textBox3.Text;
                    obj.LNAME = textBox1.Text;
                    self.CONSUMERs.InsertOnSubmit(obj);
                    self.SubmitChanges();
                }
                else
                    MessageBox.Show("already exists");
            }
            else
                MessageBox.Show("please fill all the text boxes");
            var a = from P in self.CONSUMERs
                    select P;

            dataGridView1.DataSource = a;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_SelectedIndexChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                txtWork.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            databaseDataContext self = new databaseDataContext();
            CONSUMER obj = new CONSUMER();
            // string x = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (txtWork.Text != "")
            {
                string x = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                var hi = from P in self.CONSUMERs
                         where (P.IDNUM == txtWork.Text && P.IDNUM != x)
                         select P;
                if (hi.Count() == 0)
                {
                    var query = (from P in self.CONSUMERs
                                 where (P.IDNUM == x)
                                 select P).Single();
                    self.CONSUMERs.DeleteOnSubmit(query);
                    self.SubmitChanges();
                    obj.IDNUM = txtWork.Text;
                    obj.FNAME = textBox3.Text;
                    obj.LNAME = textBox1.Text;
                    self.CONSUMERs.InsertOnSubmit(obj);
                    self.SubmitChanges();
                }
                else
                    MessageBox.Show("already exists");
            }
            else
                MessageBox.Show("choose a row");
            var a = from P in self.CONSUMERs
                    select P;

            dataGridView1.DataSource = a;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtWork.Text = "";
            textBox3.Text = "";
            textBox1.Text = "";
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            databaseDataContext self = new databaseDataContext();
            WORKER objw = new WORKER();
            COOK objc = new COOK();
            var a = (dynamic)null;

            if (textBox5.Text != "" && textBox4.Text != "" && textBox2.Text != "" && textBox6.Text != "")
            {
                if (comboBox2.Text == "Worker")
                {
                    var query = from P in self.WORKERs
                                where (P.PID == textBox5.Text)
                                select P;
                    if (query.Count() == 0)
                    {
                        objw.PID = textBox5.Text;
                        objw.WORK_HOUR = int.Parse(textBox4.Text);
                        objw.STEADY_SALARY = int.Parse(textBox2.Text);
                        objw.VIRTUAL_SALARY = int.Parse(textBox6.Text);
                        self.WORKERs.InsertOnSubmit(objw);
                        self.SubmitChanges();
                        a = from P in self.WORKERs
                            select P;
                    }
                    else
                        MessageBox.Show("already exists");
                }
                else
                {
                    var query = from P in self.COOKs
                                where (P.PID == textBox5.Text)
                                select P;
                    if (query.Count() == 0)
                    {
                        objc.PID = textBox5.Text;
                        objc.WORK_HOUR = int.Parse(textBox4.Text);
                        objc.STEADY_SALARY = int.Parse(textBox2.Text);
                        objc.VIRTUAL_SALARY = int.Parse(textBox6.Text);
                        self.COOKs.InsertOnSubmit(objc);
                        self.SubmitChanges();
                        a = from P in self.COOKs
                            select P;
                    }
                    else
                        MessageBox.Show("already exists");
                }
            }
            else
                MessageBox.Show("please fill all the text boxes");
            dataGridView2.DataSource = a;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            databaseDataContext self = new databaseDataContext();
            var query = (dynamic)null;
            if (comboBox2.Text == "Worker")
            {
                query = from P in self.WORKERs
                        where (P.PID == textBox5.Text || textBox5.Text == "")
                        && (Convert.ToString(P.WORK_HOUR) == textBox4.Text || textBox4.Text == "")
                        && (Convert.ToString(P.STEADY_SALARY) == textBox2.Text || textBox2.Text == "")
                        && (Convert.ToString(P.VIRTUAL_SALARY) == textBox6.Text || textBox6.Text == "")
                        select P;
            }
            else
            {
                query = from P in self.COOKs
                        where (P.PID == textBox5.Text || textBox5.Text == "")
                        && (Convert.ToString(P.WORK_HOUR) == textBox4.Text || textBox4.Text == "")
                        && (Convert.ToString(P.STEADY_SALARY) == textBox2.Text || textBox2.Text == "")
                        && (Convert.ToString(P.VIRTUAL_SALARY) == textBox6.Text || textBox6.Text == "")
                        select P;
            }

            dataGridView2.DataSource = query;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            databaseDataContext self = new databaseDataContext();
            var query = from P in self.FOOD_DISTRIBUTION_COMPANies
                        where (P.COID == textBox9.Text || textBox9.Text == "")
                        && (P.PNUM == textBox8.Text || textBox8.Text == "")
                        select P;

            dataGridView3.DataSource = query;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            databaseDataContext self = new databaseDataContext();

            if (textBox9.Text != "")
            {
                var hi = from p in self.FOOD_DISTRIBUTION_COMPANies
                         where p.COID == textBox9.Text
                         select p;
                if (hi.Count() != 0)
                {
                    var query = (from p in self.FOOD_DISTRIBUTION_COMPANies
                                 where p.COID == textBox9.Text
                                 select p
                               ).Single();
                    self.FOOD_DISTRIBUTION_COMPANies.DeleteOnSubmit(query);
                    self.SubmitChanges();
                }
                else
                    MessageBox.Show("data doesn't exist");
            }
            else
                MessageBox.Show("please fill the id part or choose a row");
            var a = from P in self.FOOD_DISTRIBUTION_COMPANies
                    select P;

            dataGridView3.DataSource = a;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            databaseDataContext self = new databaseDataContext();
            FOOD_DISTRIBUTION_COMPANY obj = new FOOD_DISTRIBUTION_COMPANY();
            if (textBox8.Text != "" && textBox9.Text != "")
            {
                var query = from P in self.FOOD_DISTRIBUTION_COMPANies
                            where (P.COID == textBox9.Text)
                            select P;
                if (query.Count() == 0)
                {
                    obj.COID = textBox9.Text;
                    obj.PNUM = textBox8.Text;
                    self.FOOD_DISTRIBUTION_COMPANies.InsertOnSubmit(obj);
                    self.SubmitChanges();
                }
                else
                    MessageBox.Show("already exists");
            }
            else
                MessageBox.Show("please fill all the text boxes");
            var a = from P in self.FOOD_DISTRIBUTION_COMPANies
                    select P;

            dataGridView3.DataSource = a;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            databaseDataContext self = new databaseDataContext();
            FOOD_DISTRIBUTION_COMPANY obj = new FOOD_DISTRIBUTION_COMPANY();
            if (textBox9.Text != "")
            {
                string x = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
                var hi = from P in self.FOOD_DISTRIBUTION_COMPANies
                         where (P.COID == textBox9.Text && P.COID != x)
                         select P;
                if (hi.Count() == 0)
                {
                    var query = (from P in self.FOOD_DISTRIBUTION_COMPANies
                                 where (P.COID == x)
                                 select P).Single();
                    self.FOOD_DISTRIBUTION_COMPANies.DeleteOnSubmit(query);
                    self.SubmitChanges();
                    obj.COID = textBox9.Text;
                    obj.PNUM = textBox8.Text;
                    self.FOOD_DISTRIBUTION_COMPANies.InsertOnSubmit(obj);
                    self.SubmitChanges();
                }
                else
                    MessageBox.Show("already exists");
            }
            else
                MessageBox.Show("choose a row");
            var a = from P in self.FOOD_DISTRIBUTION_COMPANies
                    select P;

            dataGridView3.DataSource = a;
        }

        private void dataGridView3_MouseClick_1(object sender, MouseEventArgs e)
        {
            try
            {
                textBox9.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
                textBox8.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox4.Text = "";
            textBox2.Text = "";
            textBox6.Text = "";
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox5.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                textBox4.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                textBox6.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch { }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            databaseDataContext self = new databaseDataContext();
            var a = (dynamic)null;
            if (textBox5.Text != "")
            {
                if (comboBox2.Text == "Worker")
                {
                    var hi = from p in self.WORKERs
                             where p.PID == textBox5.Text
                             select p;
                    if (hi.Count() != 0)
                    {
                        var query = (from p in self.WORKERs
                                     where p.PID == textBox5.Text
                                     select p
                                   ).Single();
                        self.WORKERs.DeleteOnSubmit(query);
                        self.SubmitChanges();
                        a = from P in self.WORKERs
                            select P;
                    }
                    else
                        MessageBox.Show("data doesn't exist");
                }
                else
                {
                    var bye = from p in self.COOKs
                              where p.PID == textBox5.Text
                              select p;
                    if (bye.Count() != 0)
                    {
                        var query = (from p in self.COOKs
                                     where p.PID == textBox5.Text
                                     select p
                                   ).Single();
                        self.COOKs.DeleteOnSubmit(query);
                        self.SubmitChanges();
                        a = from P in self.COOKs
                            select P;
                    }
                    else
                        MessageBox.Show("data doesn't exist");
                }
            }
            else
                MessageBox.Show("please fill the id part or choose a row");
            dataGridView2.DataSource = a;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            databaseDataContext self = new databaseDataContext();
            WORKER objw = new WORKER();
            COOK objc = new COOK();
            var a = (dynamic)null;
            if (textBox5.Text != "")
            {
                string x = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                if (comboBox2.Text == "Worker")
                {
                    var hi = from p in self.WORKERs
                             where p.PID == textBox5.Text && p.PID != x
                             select p;
                    if (hi.Count() == 0)
                    {
                        var query = (from p in self.WORKERs
                                     where p.PID == x
                                     select p
                                   ).Single();
                        self.WORKERs.DeleteOnSubmit(query);
                        self.SubmitChanges();
                        objw.PID = textBox5.Text;
                        objw.WORK_HOUR = int.Parse(textBox4.Text);
                        objw.STEADY_SALARY = int.Parse(textBox2.Text);
                        objw.VIRTUAL_SALARY = int.Parse(textBox6.Text);
                        self.WORKERs.InsertOnSubmit(objw);
                        self.SubmitChanges();
                        a = from P in self.WORKERs
                            select P;
                    }
                    else
                        MessageBox.Show("already exists");
                }
                else
                {
                    var bye = from p in self.COOKs
                              where p.PID == textBox5.Text && p.PID != x
                              select p;
                    if (bye.Count() == 0)
                    {
                        var query = (from p in self.COOKs
                                     where p.PID == x
                                     select p
                                   ).Single();
                        self.COOKs.DeleteOnSubmit(query);
                        self.SubmitChanges();
                        objc.PID = textBox5.Text;
                        objc.WORK_HOUR = int.Parse(textBox4.Text);
                        objc.STEADY_SALARY = int.Parse(textBox2.Text);
                        objc.VIRTUAL_SALARY = int.Parse(textBox6.Text);
                        self.COOKs.InsertOnSubmit(objc);
                        self.SubmitChanges();
                        a = from P in self.COOKs
                            select P;
                    }
                    else
                        MessageBox.Show("already exists");
                }
            }
            else
                MessageBox.Show("choose a row");
            dataGridView2.DataSource = a;
        }
    }
}
