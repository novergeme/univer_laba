using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM_stat1
{
    public partial class Company : Form
    {
        
        public string SQLConnectBD { get; set; }
        public string comboBox1_select = "select * from Company_tab order by name_company";
        public string WhatSearch_namecompany = "name_company";
        public string save_VibCompany { get; set; }
        public string index_contact { get; set; }
        
        public string num_telS1 { get; set; }
        public string name_contS1 { get; set; }

        public string name_managerS1 { get; set; }
        public string surname_managerS1 { get; set; }

        public int set_call_cp { get; set; }
        public int sum_sale_cp { get; set; }

        public bool insert_or_update { get; set; }
        public string id_deal_buff { get; set; }
        public int id_cont_buff { get; set; }


        public int step1 { get; set; }
        public int step2 { get; set; }
        public int step3 { get; set; }

        public Company()
        {
            InitializeComponent();
            string Pr_SQLConnectBD = @"Data Source=DESKTOP-4LF6SGE\SQLEXPRESS;Initial Catalog=crmlite;Integrated Security=True";
            SQLConnectBD = Pr_SQLConnectBD;

            
            tabPagesInviz(1);
            SELECT_fun_sql_comboBox(comboBox1_select, WhatSearch_namecompany);

        }

        public void tabPagesInviz(int numVizPage)
        {
            switch (numVizPage)
            {
                case 1:
                    tabPage1.Parent = tabControl1;
                    tabPage2.Parent = null;
                    tabPage3.Parent = null;
                    tabPage4.Parent = null;
                    tabPage5.Parent = null;
                    break;

                case 2:
                    tabPage1.Parent = null;
                    tabPage2.Parent = tabControl1;
                    tabPage3.Parent = null;
                    tabPage4.Parent = null;
                    tabPage5.Parent = null;
                    break;

                case 3:
                    tabPage1.Parent = null;
                    tabPage2.Parent = null;
                    tabPage3.Parent = tabControl1;
                    tabPage4.Parent = null;
                    tabPage5.Parent = null;
                    break;

                case 4:
                    tabPage1.Parent = null;
                    tabPage2.Parent = null;
                    tabPage3.Parent = null;
                    tabPage4.Parent = tabControl1;
                    tabPage5.Parent = null;
                    break;

                case 5:
                    tabPage1.Parent = null;
                    tabPage2.Parent = null;
                    tabPage3.Parent = null;
                    tabPage4.Parent = null;
                    tabPage5.Parent = tabControl1;
                    break;
            }
        }
     
        //---All fun db---

        public void INSERT_fun_sql(string SQLfinder)
        {
            using (SqlConnection connection = new SqlConnection(SQLConnectBD))
            {
                SqlCommand command = new SqlCommand(SQLfinder, connection);
                connection.Open();
                int number = command.ExecuteNonQuery();
                connection.Close();
            }
        }
       
        public void SELECT_fun_sql_comboBox(string SQLfinder, string WhatSearch)
        {
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                object searhShow = reader[WhatSearch];
                try
                {
                    comboBox1.Items.Add(searhShow.ToString());
                    comboBox1.Text = searhShow.ToString();
                }
                catch { }

            }
            connection.Close();
        }

        public int SEARCH_select_id(string SQLfinder, string WhatSearch)
        {
            int return_id = 0;
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {

                object ID_search_tab = reader[WhatSearch];
                return_id = Convert.ToInt32(ID_search_tab);

            }
            reader.Close();
            connection.Close();
            return return_id;
        }

        public string SEARCH_select_STR(string SQLfinder, string WhatSearch)
        {
            string return_str ="error";
            
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {

                object ID_search_tab = reader[WhatSearch];
                return_str = Convert.ToString(ID_search_tab);
                
            }
            reader.Close();
            connection.Close();
            return return_str;
        }

        public int SEARCH_select_size(string SQLfinder)
        {
            int size = 0;
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();

            object size_obj = command.ExecuteScalar();
            size = Convert.ToInt32(size_obj);
            
            connection.Close();
            return size;
        }

        public void SELECT_target_manager(string SQLfinder)
        {
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[2]);
                object name = reader["set_call_tm"];
                object address = reader["sum_sale_tm"];

                toolStripTextBox1.Text = name.ToString();
                toolStripTextBox2.Text = address.ToString();

            }
            reader.Close();
            connection.Close();
        }

        public void SELECT_contacts_tab(string SQLfinder)
        {
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[3]);
                object num_tel = reader["num_tel_initial_contact"];
                object name_contact = reader["name_initial_contact"];
                object source_traff = reader["source_traf_initial_contact"];
                data[data.Count - 1][0] = num_tel.ToString();
                data[data.Count - 1][1] = name_contact.ToString();
                data[data.Count - 1][2] = source_traff.ToString();

            }
            reader.Close();
            connection.Close();
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        public void SELECT_contactsS1_tab(string SQLfinder)
        {
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[2]);
                
                object num_tel = reader["num_tel_initial_contact"];
                object name_contact = reader["name_initial_contact"];
                num_telS1 = num_tel.ToString();
                name_contS1 = name_contact.ToString();
            
            }
            reader.Close();
            connection.Close();
           
        }

        //public void SELECT_stepS1_tab(string SQLfinder)
        //{
        //    SqlConnection connection = new SqlConnection(SQLConnectBD);
        //    SqlCommand command = new SqlCommand(SQLfinder, connection);
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();

        //    List<string[]> data = new List<string[]>();
        //    while (reader.Read())
        //    {
        //        data.Add(new string[3]);
        //        object num_tel = reader["num_tel_initial_contact"];
        //        object name_contact = reader["name_initial_contact"];
        //        object traff_contact = reader["source_traf_initial_contact"];
        //        num_telS1 = num_tel.ToString();
        //        name_contS1 = name_contact.ToString();

        //    }
        //    reader.Close();
        //    connection.Close();

        //}

        public void SELECT_contact_view(string SQLfinder)
        {
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[4]);
                object id_con = reader["id_initial_contact"];
                object num_contact = reader["num_tel_initial_contact"];
                object name_contact = reader["name_initial_contact"];
                object traff_contact = reader["source_traf_initial_contact"];

                id_cont_buff = Convert.ToInt32(id_con.ToString());
                string conv = num_contact.ToString();
                numericUpDown4.Value = Convert.ToInt64(conv);
                textBox8.Text = name_contact.ToString();
                textBox10.Text = traff_contact.ToString();
                 
              
            }
            reader.Close();
            connection.Close();
        }

        public void SELECT_step_view(string SQLfinder)
        {
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                object id_contact = reader["id_initial_contact"];
                int id_ini_contact = Convert.ToInt32(id_contact);
                string select_finder_contacts = String.Format("SELECT * FROM Initial_contact_tab WHERE id_initial_contact = '{0}'", id_ini_contact);
                SELECT_contact_view(select_finder_contacts);
                
                    data.Add(new string[6]);
                    object name_prod = reader["name_product_deal"];
                    object date = reader["date_deal"];
                    object sum_d = reader["sum_deal"];
                    object set_call = reader["set_call_deal"];
                    object howSet = reader["how_step"];
                    
                    //data[data.Count - 1][0] = num_telS1;
                    //data[data.Count - 1][1] = name_contS1;
                    textBox11.Text = name_prod.ToString();
                    numericUpDown5.Value = Convert.ToInt64(sum_d.ToString());
                    numericUpDown3.Value = Convert.ToInt32(set_call.ToString());
                    comboBox2.Text = howSet.ToString();
            }
            reader.Close();
            connection.Close();
        }



        public void SELECT_step1_tab(string SQLfinder)
        {
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                object id_contact = reader["id_initial_contact"];
                int id_ini_contact = Convert.ToInt32(id_contact);
                string select_finder_contacts = String.Format("SELECT * FROM Initial_contact_tab WHERE id_initial_contact = '{0}'", id_ini_contact);
                SELECT_contactsS1_tab(select_finder_contacts);
                object howSet = reader["how_step"];
                int howSet_i = Convert.ToInt32(howSet);
                if (howSet_i == 1)
                {
                data.Add(new string[7]);
                object id = reader["id_deal"];
                object name_prod = reader["name_product_deal"];
                object date = reader["date_deal"];
                object sum_d = reader["sum_deal"];
                object set_call = reader["set_call_deal"];

                    data[data.Count - 1][0] = id.ToString();
                    data[data.Count - 1][1] = num_telS1;
                    data[data.Count - 1][2] = name_contS1;
                    data[data.Count - 1][3] = name_prod.ToString();
                    data[data.Count - 1][4] = date.ToString();
                    data[data.Count - 1][5] = sum_d.ToString();
                    data[data.Count - 1][6] = set_call.ToString();
                }
            }
            reader.Close();
            connection.Close();
            foreach (string[] s in data)
            dataGridView2.Rows.Add(s);
        }

        public void SELECT_step2_tab(string SQLfinder)
        {
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                object id_contact = reader["id_initial_contact"];
                int id_ini_contact = Convert.ToInt32(id_contact);
                string select_finder_contacts = String.Format("SELECT * FROM Initial_contact_tab WHERE id_initial_contact = '{0}'", id_ini_contact);
                SELECT_contactsS1_tab(select_finder_contacts);
                object howSet = reader["how_step"];
                int howSet_i = Convert.ToInt32(howSet);
                if (howSet_i == 2)
                {
                    data.Add(new string[7]);
                    object id = reader["id_deal"];
                    object name_prod = reader["name_product_deal"];
                    object date = reader["date_deal"];
                    object sum_d = reader["sum_deal"];
                    object set_call = reader["set_call_deal"];

                    data[data.Count - 1][0] = id.ToString();
                    data[data.Count - 1][1] = num_telS1;
                    data[data.Count - 1][2] = name_contS1;
                    data[data.Count - 1][3] = name_prod.ToString();
                    data[data.Count - 1][4] = date.ToString();
                    data[data.Count - 1][5] = sum_d.ToString();
                    data[data.Count - 1][6] = set_call.ToString();
                }
            }
            reader.Close();
            connection.Close();
            foreach (string[] s in data)
                dataGridView3.Rows.Add(s);
        }

        public void SELECT_step3_tab(string SQLfinder)
        {
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                object id_contact = reader["id_initial_contact"];
                int id_ini_contact = Convert.ToInt32(id_contact);
                string select_finder_contacts = String.Format("SELECT * FROM Initial_contact_tab WHERE id_initial_contact = '{0}'", id_ini_contact);
                SELECT_contactsS1_tab(select_finder_contacts);
                object howSet = reader["how_step"];
                int howSet_i = Convert.ToInt32(howSet);
                if (howSet_i == 3)
                {
                    data.Add(new string[7]);
                    object id = reader["id_deal"];
                    object name_prod = reader["name_product_deal"];
                    object date = reader["date_deal"];
                    object sum_d = reader["sum_deal"];
                    object set_call = reader["set_call_deal"];

                    data[data.Count - 1][0] = id.ToString();
                    data[data.Count - 1][1] = num_telS1;
                    data[data.Count - 1][2] = name_contS1;
                    data[data.Count - 1][3] = name_prod.ToString();
                    data[data.Count - 1][4] = date.ToString();
                    data[data.Count - 1][5] = sum_d.ToString();
                    data[data.Count - 1][6] = set_call.ToString();
                }
            }
            reader.Close();
            connection.Close();
            foreach (string[] s in data)
                dataGridView4.Rows.Add(s);
        }

        public void UPDATE_step(string SQLfinder)
        {
            using (SqlConnection connection = new SqlConnection(SQLConnectBD))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQLfinder, connection);
                int number = command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DELETE_set(string SQLfinder)
        {
           
            using (SqlConnection connection = new SqlConnection(SQLConnectBD))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQLfinder, connection);
                int number = command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void SELECT_sum(string SQLfinder)
        {
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            int a = 0;
            long b = 0;
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[2]);
                
                object sum_d = reader["sum_deal"];
                object set_call = reader["set_call_deal"];
               
                 b += Convert.ToInt64(sum_d.ToString());
                 a += Convert.ToInt32(set_call.ToString());
               
            }
            reader.Close();
            connection.Close();
            toolStripTextBox4.Text = b.ToString();
            toolStripTextBox3.Text = a.ToString();
        }

        public void SELECT_dateS1_tab(string SQLfinder)
        {
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[2]);

                object name_manager = reader["name_manager"];
                object surname_manager = reader["surname_manager"];
                name_managerS1 = name_manager.ToString();
                surname_managerS1 = surname_manager.ToString();

            }
            reader.Close();
            connection.Close();

        }

        public void SELECT_date_tab(string SQLfinder)
        {
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {

                object id_manager = reader["id_manager"];
                int id_ini_manager = Convert.ToInt32(id_manager);
                string select_finder_contacts = String.Format("SELECT * FROM Manager_tab WHERE id_manager = '{0}'", id_ini_manager);
                SELECT_dateS1_tab(select_finder_contacts);

                data.Add(new string[11]);
                object date_stat_manag = reader["date_stat_manag"];
                object set_call_mf = reader["set_call_mf"];
                object sum_sale_mf = reader["sum_sale_mf"];
                object indiv_targ_call = reader["indiv_targ_call"];
                object indiv_targ_sale = reader["indiv_targ_sale"];
                object win_deal = reader["win_deal"];
                object fail_deal = reader["fail_deal"];
                object no_touch = reader["no_touch"];
                object convers_man = reader["convers_man"];
                
                data[data.Count - 1][0] = name_managerS1;
                data[data.Count - 1][1] = surname_managerS1;
                data[data.Count - 1][2] = date_stat_manag.ToString();
                data[data.Count - 1][3] = set_call_mf.ToString();
                data[data.Count - 1][4] = sum_sale_mf.ToString();
                data[data.Count - 1][5] = indiv_targ_call.ToString();
                data[data.Count - 1][6] = indiv_targ_sale.ToString();
                data[data.Count - 1][7] = win_deal.ToString();
                data[data.Count - 1][8] = fail_deal.ToString();
                data[data.Count - 1][9] = no_touch.ToString();
                data[data.Count - 1][10] = convers_man.ToString();


            }
            reader.Close();
            connection.Close();
            foreach (string[] s in data)
                dataGridView5.Rows.Add(s);
        }

        public void SELECT_all_stat_man(string SQLfinder)
        {
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            step1 = 0;
            step2 = 0;
            step3 = 0;
            int buff = 0;
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[1]);

                object sum = reader["how_step"];
                 buff = Convert.ToInt32(sum.ToString());

                if (buff == 1)
                {
                    step1 += buff;
                }
                if (buff == 2)
                {
                    step2 += buff;
                }
                if (buff == 3)
                {
                    step3 += buff;
                }

            }
            reader.Close();
            connection.Close();
            
        }

        public void SELECT_all_stat_comp(string SQLfinder)
        {
            SqlConnection connection = new SqlConnection(SQLConnectBD);
            SqlCommand command = new SqlCommand(SQLfinder, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            set_call_cp = 0;
            sum_sale_cp = 0;
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[1]);

                object set_call_mf = reader["set_call_mf"];
                object sum_sale_mf = reader["sum_sale_mf"];

                set_call_cp += Convert.ToInt32(set_call_mf.ToString());
                sum_sale_cp += Convert.ToInt32(sum_sale_mf.ToString());

            }
            reader.Close();
            connection.Close();

        }
        //---All fun db---

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            save_VibCompany = comboBox1.SelectedItem.ToString();
            label11.Text = save_VibCompany;
            tabControl1.SelectedTab = tabPage2;
            tabPagesInviz(2);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Company_Load(object sender, EventArgs e)
        {
           
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            int sum_sale_target_c = (int)numericUpDown1.Value;
            int set_call_target_c = (int)numericUpDown2.Value;
            
                
            string what_search = "id_company";
            int id_comp = SEARCH_select_id(String.Format("SELECT * FROM Company_tab WHERE name_company='{0}'", save_VibCompany), what_search);

            int sum_manager = SEARCH_select_size(String.Format("SELECT COUNT(*) FROM Manager_tab WHERE id_company='{0}'", id_comp));

            int set_call_tm = set_call_target_c / sum_manager;
            int sum_sale_tm = sum_sale_target_c / sum_manager;

            INSERT_fun_sql(String.Format("INSERT INTO Target_tab (id_company, date_target_c, set_call_target_c, sum_sale_target_c, set_call_tm, sum_sale_tm) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')",
            id_comp, dateTimePicker1.Value.ToString("yyyy-MM-dd"), set_call_target_c, sum_sale_target_c, set_call_tm, sum_sale_tm));

            MessageBox.Show("Цель поставлена:" +" "+ set_call_tm + " "+ sum_sale_tm);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

     

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string what_search = "id_company";
            int id_comp = SEARCH_select_id(String.Format("SELECT * FROM Company_tab WHERE name_company='{0}'", save_VibCompany), what_search);
            INSERT_fun_sql(String.Format("INSERT INTO Manager_tab (id_company, login_manager, pass_manager, name_manager, surname_manager, gender_manager) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", id_comp, textBox1.Text, textBox7.Text, textBox3.Text, textBox5.Text, comboBox3.SelectedItem.ToString()));

            
            MessageBox.Show("Менеджер зарегистрирован");
        }


        private void butt_insert_company_Click_1(object sender, EventArgs e)
        {
            INSERT_fun_sql(String.Format("INSERT INTO Company_tab (name_company, pass_company) VALUES ('{0}','{1}')", tBox_reg_name_company.Text, tBox_reg_pass_company.Text));

            string what_search = "id_company";
            string default_name_funnel = "default";
            int id_search_now = SEARCH_select_id(String.Format("SELECT * FROM Company_tab WHERE name_company='{0}'", tBox_reg_name_company.Text), what_search);
            INSERT_fun_sql(String.Format("INSERT INTO Funnel_tab (id_company, name_funnel) VALUES ('{0}','{1}' )", id_search_now, default_name_funnel));

            MessageBox.Show("Компания добавлена");
            comboBox1.Items.Clear();
            SELECT_fun_sql_comboBox(comboBox1_select, WhatSearch_namecompany);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string what_search = "pass_manager";
            string pass_manager = SEARCH_select_STR(String.Format("SELECT * FROM Manager_tab WHERE login_manager='{0}'", textBox2.Text), what_search);

            if(textBox4.Text == pass_manager)
            {
            tabControl1.SelectedTab = tabPage4;
            tabPagesInviz(4);

            what_search = "id_company";
            int id_search_now = SEARCH_select_id(String.Format("SELECT * FROM Manager_tab WHERE login_manager='{0}'", textBox2.Text), what_search);

            what_search = "id_target_c";
            string nowDate = DateTime.Now.ToString("yyyy-MM-dd");
            string search_id_target = SEARCH_select_STR(String.Format("SELECT * FROM Target_tab WHERE date_target_c='{0}'", nowDate), what_search);
            string sql_open = String.Format("SELECT * FROM Target_tab WHERE id_target_c = '{0}'", search_id_target);
            SELECT_target_manager(sql_open);

                ///-------------contacts donwload
                what_search = "id_funnel";
                int id_search_funnel = SEARCH_select_id(String.Format("SELECT * FROM Funnel_tab WHERE id_company='{0}'", id_search_now), what_search);

                string select_finder_contacts = String.Format("SELECT * FROM Initial_contact_tab WHERE id_funnel = '{0}'", id_search_funnel);
                SELECT_contacts_tab(select_finder_contacts);
                ///-------------contacts download
                ///-------------Step donwload
                what_search = "id_manager";
                string id_search_manager = SEARCH_select_STR(String.Format("SELECT * FROM Manager_tab WHERE login_manager='{0}'", textBox2.Text), what_search);
                ///---------////ПОДГРУЗКА статистики менеджера
                SELECT_sum(String.Format("SELECT * FROM Deal_tab WHERE id_manager = '{0}'", id_search_manager));
                ///---------////ПОДГРУЗКА статистики менеджера
                string select_finder_step = String.Format("SELECT * FROM Deal_tab WHERE id_manager = '{0}'", id_search_manager);
                SELECT_step1_tab(select_finder_step);
                
                SELECT_step2_tab(select_finder_step);
                
                SELECT_step3_tab(select_finder_step);
                
                ///-------------Step donwload
            }
            else {
            MessageBox.Show("Неверный пароль!");  }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            string what_search = "pass_company";
            string pass_company = SEARCH_select_STR(String.Format("SELECT * FROM Company_tab WHERE name_company='{0}'", label11.Text), what_search);

            if (textBox9.Text == pass_company)
            {
                tabControl1.SelectedTab = tabPage3;
                tabPagesInviz(3);
            }
            else { MessageBox.Show("Неверный пароль!"); }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string what_search = "pass_company";
            string pass_company = SEARCH_select_STR(String.Format("SELECT * FROM Company_tab WHERE name_company='{0}'", label11.Text), what_search);

            if (textBox9.Text == pass_company)
            {
                tabControl1.SelectedTab = tabPage5;
                tabPagesInviz(5);
            }
            else { MessageBox.Show("Неверный пароль!"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
            tabPagesInviz(5);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string what_search = "id_company";
            int id_search_now = SEARCH_select_id(String.Format("SELECT * FROM Manager_tab WHERE login_manager='{0}'", textBox2.Text), what_search);

            what_search = "id_funnel";
            int id_search_now2 = SEARCH_select_id(String.Format("SELECT * FROM Funnel_tab WHERE id_company='{0}'", id_search_now), what_search);
            long num_tel = (long)numericUpDown4.Value;
            INSERT_fun_sql(String.Format("INSERT INTO Initial_contact_tab (id_funnel, num_tel_initial_contact, name_initial_contact, source_traf_initial_contact) VALUES ('{0}','{1}','{2}','{3}')", id_search_now2, num_tel, textBox8.Text, textBox10.Text));

            dataGridView1.Rows.Clear();
            string select_finder_contacts = String.Format("SELECT * FROM Initial_contact_tab WHERE id_funnel = '{0}'", id_search_now2);
            SELECT_contacts_tab(select_finder_contacts);

            textBox8.Clear();
            numericUpDown4.Value = 8;
            textBox10.Clear();
            MessageBox.Show("Контакт добавлен");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //-----Добавление на этап 1
            string what_search = "id_initial_contact";
            int id_search_contact = SEARCH_select_id(String.Format("SELECT * FROM Initial_contact_tab WHERE num_tel_initial_contact='{0}'", numericUpDown4.Value), what_search);

            string what_search2 = "id_manager";
            int id_search_manager = SEARCH_select_id(String.Format("SELECT * FROM Manager_tab WHERE login_manager='{0}'", textBox2.Text), what_search2);

            string nowDate = DateTime.Now.ToString("yyyy-MM-dd");
            int save_Vib_step = Convert.ToInt32(comboBox2.SelectedItem.ToString());

            if (insert_or_update == true)
            {
                INSERT_fun_sql(String.Format("INSERT INTO Deal_tab (id_initial_contact, id_manager, name_product_deal, date_deal, sum_deal, set_call_deal, how_step) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_search_contact, id_search_manager, textBox11.Text, nowDate, numericUpDown5.Value, numericUpDown3.Value, save_Vib_step));
            }
            else
            { 
                UPDATE_step(String.Format("UPDATE Deal_tab SET name_product_deal='{0}' WHERE id_deal='{1}'", textBox11.Text, id_deal_buff));
                UPDATE_step(String.Format("UPDATE Deal_tab SET sum_deal='{0}' WHERE id_deal='{1}'", numericUpDown5.Value, id_deal_buff));
                UPDATE_step(String.Format("UPDATE Deal_tab SET set_call_deal='{0}' WHERE id_deal='{1}'", numericUpDown3.Value, id_deal_buff));
                UPDATE_step(String.Format("UPDATE Deal_tab SET how_step='{0}' WHERE id_deal='{1}'", comboBox2.Text, id_deal_buff));
                UPDATE_step(String.Format("UPDATE Deal_tab SET date_deal='{0}' WHERE id_deal='{1}'", nowDate, id_deal_buff));

                UPDATE_step(String.Format("UPDATE Initial_contact_tab SET num_tel_initial_contact='{0}' WHERE id_initial_contact='{1}'", numericUpDown4.Value, id_cont_buff));
                UPDATE_step(String.Format("UPDATE Initial_contact_tab SET name_initial_contact='{0}' WHERE id_initial_contact='{1}'", textBox8.Text, id_cont_buff));
                UPDATE_step(String.Format("UPDATE Initial_contact_tab SET source_traf_initial_contact='{0}' WHERE id_initial_contact='{1}'", textBox10.Text, id_cont_buff));
            }
            //-----Добавление на этап 1

            //-----Обновление таблиц
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            string select_finder_step = String.Format("SELECT * FROM Deal_tab WHERE id_manager = '{0}'", id_search_manager);
            SELECT_step1_tab(select_finder_step);

            SELECT_step2_tab(select_finder_step);

            SELECT_step3_tab(select_finder_step);

            dataGridView1.Rows.Clear();
            what_search = "id_funnel";
            int id_search_now2 = SEARCH_select_id(String.Format("SELECT * FROM Initial_contact_tab WHERE id_initial_contact='{0}'", id_cont_buff), what_search);

            string select_finder_contacts = String.Format("SELECT * FROM Initial_contact_tab WHERE id_funnel = '{0}'", id_search_now2);
            SELECT_contacts_tab(select_finder_contacts);
            //-----stat manager
             SELECT_sum(String.Format("SELECT * FROM Deal_tab WHERE id_manager = '{0}'", id_search_manager));
            //-----stat manager
            //-----Обновление таблиц
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index_contact = e.RowIndex.ToString();
            }
            catch
            { }

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string num_tel = dataGridView1.CurrentCell.Value.ToString();
            SELECT_contact_view(String.Format("SELECT * FROM Initial_contact_tab WHERE num_tel_initial_contact = '{0}'", num_tel));
            insert_or_update = true;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (insert_or_update == false)
            {
                DELETE_set(String.Format("DELETE  FROM Deal_tab WHERE id_deal= '{0}'", id_deal_buff));

                dataGridView2.Rows.Clear();
                dataGridView3.Rows.Clear();
                dataGridView4.Rows.Clear();

                string what_search = "id_manager";
                int id_search_manager = SEARCH_select_id(String.Format("SELECT * FROM Manager_tab WHERE login_manager='{0}'", textBox2.Text), what_search);

                string select_finder_step = String.Format("SELECT * FROM Deal_tab WHERE id_manager = '{0}'", id_search_manager);
                SELECT_step1_tab(select_finder_step);

                SELECT_step2_tab(select_finder_step);

                SELECT_step3_tab(select_finder_step);
            }
            else
            {
                string what_search = "id_funnel";
                int id_search_now2 = SEARCH_select_id(String.Format("SELECT * FROM Initial_contact_tab WHERE id_initial_contact='{0}'", id_cont_buff), what_search);
                

                DELETE_set(String.Format("DELETE  FROM Initial_contact_tab WHERE id_initial_contact= '{0}'", id_cont_buff));

                dataGridView1.Rows.Clear();


                string select_finder_contacts = String.Format("SELECT * FROM Initial_contact_tab WHERE id_funnel = '{0}'", id_search_now2);
                SELECT_contacts_tab(select_finder_contacts);
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index_contact = e.RowIndex.ToString();
            }
            catch
            { }
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id_deal_buff = dataGridView2.CurrentCell.Value.ToString();
            SELECT_step_view(String.Format("SELECT * FROM Deal_tab WHERE id_deal = '{0}'", id_deal_buff));
            insert_or_update = false;
        }

        private void dataGridView3_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index_contact = e.RowIndex.ToString();
            }
            catch
            { }
        }

        private void dataGridView3_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id_deal_buff = dataGridView3.CurrentCell.Value.ToString();
            SELECT_step_view(String.Format("SELECT * FROM Deal_tab WHERE id_deal = '{0}'", id_deal_buff));
            insert_or_update = false;
        }

        private void dataGridView4_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index_contact = e.RowIndex.ToString();
            }
            catch
            { }
        }

        private void dataGridView4_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id_deal_buff = dataGridView4.CurrentCell.Value.ToString();
            SELECT_step_view(String.Format("SELECT * FROM Deal_tab WHERE id_deal = '{0}'", id_deal_buff));
            insert_or_update = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabPagesInviz(5);
            
            string what_search = "id_manager";
            int id_search_manager = SEARCH_select_id(String.Format("SELECT * FROM Manager_tab WHERE login_manager='{0}'", textBox2.Text), what_search);
            
            string nowDate = DateTime.Now.ToString("yyyy-MM-dd");
            
            SELECT_all_stat_man(String.Format("SELECT * FROM Deal_tab WHERE id_manager = '{0}'", id_search_manager));

            int convers_man = step2 / 2;
            int call = Convert.ToInt32(toolStripTextBox3.Text);
            int confin = convers_man * 100;
            int drob = confin / call;

            int id_search_manager2 = SEARCH_select_id(String.Format("SELECT * FROM Manager_stat_tab WHERE date_stat_manag='{0}'", nowDate), what_search);
            if (id_search_manager2 != id_search_manager)
            {
                INSERT_fun_sql(String.Format("INSERT INTO Manager_stat_tab (id_manager, date_stat_manag, set_call_mf, sum_sale_mf, indiv_targ_call, indiv_targ_sale, win_deal, fail_deal, no_touch, convers_man) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                    id_search_manager, nowDate, Convert.ToInt32(toolStripTextBox3.Text), Convert.ToInt32(toolStripTextBox4.Text), Convert.ToInt32(toolStripTextBox1.Text), Convert.ToInt32(toolStripTextBox2.Text), step2 / 2, step3 / 3, step1, drob));
            }
            else
            {
                UPDATE_step(String.Format("UPDATE Manager_stat_tab SET set_call_mf='{0}' WHERE id_manager='{1}'", Convert.ToInt32(toolStripTextBox3.Text), id_search_manager));
                UPDATE_step(String.Format("UPDATE Manager_stat_tab SET sum_sale_mf='{0}' WHERE id_manager='{1}'", Convert.ToInt32(toolStripTextBox4.Text), id_search_manager));
                UPDATE_step(String.Format("UPDATE Manager_stat_tab SET indiv_targ_call='{0}' WHERE id_manager='{1}'", Convert.ToInt32(toolStripTextBox1.Text), id_search_manager));
                UPDATE_step(String.Format("UPDATE Manager_stat_tab SET indiv_targ_sale='{0}' WHERE id_manager='{1}'", Convert.ToInt32(toolStripTextBox2.Text), id_search_manager));
                UPDATE_step(String.Format("UPDATE Manager_stat_tab SET win_deal='{0}' WHERE id_manager='{1}'", step2 / 2, id_search_manager));
                UPDATE_step(String.Format("UPDATE Manager_stat_tab SET fail_deal='{0}' WHERE id_manager='{1}'", step3 / 3, id_search_manager));
                UPDATE_step(String.Format("UPDATE Manager_stat_tab SET no_touch='{0}' WHERE id_manager='{1}'", step1, id_search_manager));
                UPDATE_step(String.Format("UPDATE Manager_stat_tab SET convers_man='{0}' WHERE id_manager='{1}'", drob, id_search_manager));
            }
            //------заполнение менеджеров
            SELECT_date_tab(String.Format("SELECT * FROM Manager_stat_tab WHERE date_stat_manag = '{0}'", nowDate));
            //------заполнение менеджеров

            SELECT_all_stat_comp(String.Format("SELECT * FROM Manager_stat_tab WHERE date_stat_manag = '{0}'", nowDate));

            string what_search_c = "id_company";
            int id_search_comp = SEARCH_select_id(String.Format("SELECT * FROM Manager_tab WHERE login_manager='{0}'", textBox2.Text), what_search_c);

            what_search_c = "id_funnel";
            int id_search_funnel = SEARCH_select_id(String.Format("SELECT * FROM Funnel_tab WHERE id_company='{0}'", id_search_comp), what_search_c);

            string what_search_set = "set_call_target_c";
            int call_taeget_comp = SEARCH_select_id(String.Format("SELECT * FROM Target_tab WHERE date_target_c='{0}'", nowDate), what_search_set);
            string what_search_sum = "sum_sale_target_c";
            int sum_taeget_comp = SEARCH_select_id(String.Format("SELECT * FROM Target_tab WHERE date_target_c='{0}'", nowDate), what_search_sum);

            int procent_sale = sum_sale_cp * 100;
            int procent_sale2 = procent_sale / sum_taeget_comp;

            textBox12.Text = sum_sale_cp.ToString();
            textBox13.Text = sum_taeget_comp.ToString();
            textBox14.Text = set_call_cp.ToString();
            textBox15.Text = call_taeget_comp.ToString();
            progressBar1.Value += procent_sale2;
            
            INSERT_fun_sql(String.Format("INSERT INTO Analytics_tab (id_funnel, date_analytics, sum_sale_target_fin, set_call_target_fin, percent_target_fin) VALUES ('{0}','{1}','{2}','{3}','{4}')", id_search_funnel, nowDate, sum_sale_cp, set_call_cp, procent_sale2));

            chart1.Series["Series1"].Points.AddXY("Контакты", 5000);
            chart1.Series["Series1"].Points.AddXY("Отказ от сделки", 4000);
            chart1.Series["Series1"].Points.AddXY("Принятие решения", 3000);
            chart1.Series["Series1"].Points.AddXY("Сделка выполнена", 2000);

            chart2.Series["Series1"].Points.AddXY("Холодные", 1000);
            chart2.Series["Series1"].Points.AddXY("Горячие", 10000);
            chart2.Series["Series1"].Points.AddXY("Теплые", 8000);
            chart2.Series["Series1"].Points.AddXY("Не ответившие", 3000);

            chart3.Series["Series1"].Points.AddXY("Понедельник", 10);
            chart3.Series["Series1"].Points.AddXY("Вторник", 100);
            chart3.Series["Series1"].Points.AddXY("Среда", 80);
            chart3.Series["Series1"].Points.AddXY("Четверг", 30);
            chart3.Series["Series1"].Points.AddXY("Пятница", 60);
            chart3.Series["Series1"].Points.AddXY("Суббота", 120);
            chart3.Series["Series1"].Points.AddXY("Воскресенье", 90);

            chart4.Series["Series1"].Points.AddXY("Вконтакте", 300);
            chart4.Series["Series1"].Points.AddXY("instagram", 600);
            chart4.Series["Series1"].Points.AddXY("Директ", 200);
            chart4.Series["Series1"].Points.AddXY("Adwords", 400);
            chart4.Series["Series1"].Points.AddXY("Сарафан", 1000);

            chart5.Series["Series1"].Points.AddXY("1", 30367);
            chart5.Series["Series1"].Points.AddXY("2", 27688);
            chart5.Series["Series1"].Points.AddXY("3", 40887);
            chart5.Series["Series1"].Points.AddXY("4", 60897);
            chart5.Series["Series1"].Points.AddXY("5", 15455);
            chart5.Series["Series1"].Points.AddXY("6", 35466);
            chart5.Series["Series1"].Points.AddXY("7", 28777);

            chart6.Series["Series1"].Points.AddXY("2016", 3650000);
            chart6.Series["Series1"].Points.AddXY("2017", 9125000);
            chart6.Series["Series1"].Points.AddXY("2018", 1150000);
        }

        private void button11_Click_1(object sender, EventArgs e)
        {

            //------заполнение менеджеров
            dataGridView5.Rows.Clear();
            string dateFrom = dateTimePicker2.Value.ToString("dd");
            string dateTo = dateTimePicker3.Value.ToString("dd");
            int dateFrom_i = Convert.ToInt32(dateFrom);
            int dateTo_i = Convert.ToInt32(dateTo);
            

            string dateYM = dateTimePicker2.Value.ToString("yyyy-MM-");
            dateTo_i++;


                do
                {

                    SELECT_date_tab(String.Format("SELECT * FROM Manager_stat_tab WHERE date_stat_manag = '{0}'", dateYM + dateFrom_i));
                    dateFrom_i++;

                } while (dateFrom_i != dateTo_i);
            //------заполнение менеджеров

            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabPagesInviz(4);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tabPagesInviz(2);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            tabPagesInviz(1);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tabPagesInviz(2);
        }

        public void dg1()
        {
           
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;

                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox6.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        public void dg2()
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                dataGridView2.Rows[i].Selected = false;

                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    if (dataGridView2.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView2.Rows[i].Cells[j].Value.ToString().Contains(textBox6.Text))
                        {
                            dataGridView2.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        public void dg3()
        {

            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                dataGridView3.Rows[i].Selected = false;

                for (int j = 0; j < dataGridView3.ColumnCount; j++)
                {
                    if (dataGridView3.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView3.Rows[i].Cells[j].Value.ToString().Contains(textBox6.Text))
                        {
                            dataGridView3.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        public void dg4()
        {

            for (int i = 0; i < dataGridView4.RowCount; i++)
            {
                dataGridView4.Rows[i].Selected = false;

                for (int j = 0; j < dataGridView4.ColumnCount; j++)
                {
                    if (dataGridView4.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView4.Rows[i].Cells[j].Value.ToString().Contains(textBox6.Text))
                        {
                            dataGridView4.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            dg1();
            dg2();
            dg3();
            dg4();

        }
    }
}
