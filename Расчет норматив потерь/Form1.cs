using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Drawing.Printing;

namespace Расчет_норматив_потерь
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        private string Query;
        private string Put;
        private bool tip = false;

        private double Molnaya_dolya = 0.996;
        private double Botuomskiy_Soderjanie_Condensata_pri_GDI_DKI = 2.45;
        private double Hakinskyi_Soderjanie_Condensata_pri_GDI_DKI = 2.25;
        private double Talahskyi_Soderjanie_Condensata_pri_GDI_DKI = 2.15;
       
        private double Last_temperature = 267.15;
        private double Last_press =0.1013;

        private double Concentracia_salt = 4.6;
        private double Koeff_Sechenova = 0.07;
        private double Rastvorimost_start = 1.715;
        private double Rastvorimost_end = 0.002;

        private double Value_probkootbornika = 0.0004;

        private double M = 18.555;
        private double p = 0.772;
        
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            Copybd();
        }

        private void Copybd()
        {
            Put=Environment.CurrentDirectory;
            Put += "\\";
            Put += "Database1.mdf";
            
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Технические параметры скважины")
            {
                Query = "SELECT * FROM Table_1";
                tip = true;
                LoadData();
                dataGridView1.Rows[0].Cells[0].Value = "Мольная доля вещества в добываемой продукции";
                dataGridView1.Rows[1].Cells[0].Value = "Содержание конденсата в добываемой продукции";
                dataGridView1.Rows[2].Cells[0].Value = "Концентрация солей в добываемой продукции";
                dataGridView1.Rows[3].Cells[0].Value = "Коэфицент Сеченова";
                dataGridView1.Rows[4].Cells[0].Value = "Растворимость природного газа в дистиллированной воде при атмосферном давлении";
                dataGridView1.Rows[5].Cells[0].Value = "Объем пробкоотборника";

                dataGridView1.Rows[0].Cells[1].Value = Molnaya_dolya;
                dataGridView1.Rows[1].Cells[1].Value = Botuomskiy_Soderjanie_Condensata_pri_GDI_DKI;
                dataGridView1.Rows[2].Cells[1].Value = Concentracia_salt;
                dataGridView1.Rows[3].Cells[1].Value = Koeff_Sechenova;
                dataGridView1.Rows[4].Cells[1].Value = Rastvorimost_end;
                dataGridView1.Rows[5].Cells[1].Value = Value_probkootbornika;






            }

            if (comboBox1.SelectedItem.ToString() == "Технологические потери природного газа и конденсата при первичных ГДИ и ГКИ скважин")
            {
                Query = "SELECT * FROM technological_losses_of_natural_gas_and_condensate_at_primary_GDI_and_GKI_wells";
                tip = true;
                LoadData();
                for (int i = 0; i < 4; i++)
                {
                    dataGridView1.Rows[5].Cells[i].ReadOnly = true;
                    dataGridView1.Rows[6].Cells[i].ReadOnly = true;
                }
                dataGridView1.Rows[0].Cells[0].ReadOnly = true;
                dataGridView1.Rows[1].Cells[0].ReadOnly = true;
                dataGridView1.Rows[2].Cells[0].ReadOnly = true;
                dataGridView1.Rows[3].Cells[0].ReadOnly = true;
                dataGridView1.Rows[4].Cells[0].ReadOnly = true;

                dataGridView1.Rows[5].Cells[1].Value = Molnaya_dolya;
                dataGridView1.Rows[5].Cells[2].Value = Molnaya_dolya;
                dataGridView1.Rows[5].Cells[3].Value = Molnaya_dolya;

                dataGridView1.Rows[6].Cells[1].Value = Botuomskiy_Soderjanie_Condensata_pri_GDI_DKI;
                dataGridView1.Rows[6].Cells[2].Value = Hakinskyi_Soderjanie_Condensata_pri_GDI_DKI;
                dataGridView1.Rows[6].Cells[3].Value = Talahskyi_Soderjanie_Condensata_pri_GDI_DKI;
            }

            if (comboBox1.SelectedItem.ToString() == "Технологические потери природного газа и конденсата при текущих ГДИ и ГКИ скважин")
            {
                Query = "SELECT * FROM Technological_losses_of_natural_gas_and_condensate_at_the_current_GDI_and_GKI_wells";
                tip = true;
                LoadData();
                for (int i = 0; i < 4; i++)
                {
                    dataGridView1.Rows[5].Cells[i].ReadOnly = true;
                    dataGridView1.Rows[6].Cells[i].ReadOnly = true;
                }
                dataGridView1.Rows[0].Cells[0].ReadOnly = true;
                dataGridView1.Rows[1].Cells[0].ReadOnly = true;
                dataGridView1.Rows[2].Cells[0].ReadOnly = true;
                dataGridView1.Rows[3].Cells[0].ReadOnly = true;
                dataGridView1.Rows[4].Cells[0].ReadOnly = true;

                dataGridView1.Rows[5].Cells[1].Value = Molnaya_dolya;
                dataGridView1.Rows[5].Cells[2].Value = Molnaya_dolya;
                dataGridView1.Rows[5].Cells[3].Value = Molnaya_dolya;

                dataGridView1.Rows[6].Cells[1].Value = Botuomskiy_Soderjanie_Condensata_pri_GDI_DKI;
                dataGridView1.Rows[6].Cells[2].Value = Hakinskyi_Soderjanie_Condensata_pri_GDI_DKI;
                dataGridView1.Rows[6].Cells[3].Value = Talahskyi_Soderjanie_Condensata_pri_GDI_DKI;

            }
               
            if (comboBox1.SelectedItem.ToString() == "Технологические потери природного газа и конденсата при опорожнении технологического оборудования и трубопроводов перед проведением ремонтных работ")
            {
                Query = "SELECT * FROM Technological_losses_of_natural_gas_during_emptying_before_carrying_out_repair_work";
                tip = true;
                LoadData();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].ReadOnly = true;

                    dataGridView1.Rows[i].Cells[5].ReadOnly = true;

                    dataGridView1.Rows[i].Cells[7].ReadOnly = true;

                    dataGridView1.Rows[i].Cells[8].Value = Molnaya_dolya;
                    dataGridView1.Rows[i].Cells[8].ReadOnly = true;

                    dataGridView1.Rows[i].Cells[10].Value = Botuomskiy_Soderjanie_Condensata_pri_GDI_DKI;
                    dataGridView1.Rows[i].Cells[10].ReadOnly = true;


                    double V = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                    double P = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                    double T = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    double Z = (P * V) / ((p*V*8.31*T)/M);
                    dataGridView1.Rows[i].Cells[6].Value = Z;
                }


            }
                
            if(comboBox1.SelectedItem.ToString() == "Технологические потери природного газа и конденсата при дегазации и выветривании пластовой и конденсатной воды")
            {
                Query = "SELECT* FROM Technological_losses_of_natural_gas_during_degassing_and_weathering_of_reservoir_and_condensation_water";
                tip = true;
                LoadData();
                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].ReadOnly = true;

                }
                dataGridView1.Rows[2].Cells[1].ReadOnly = true;
                dataGridView1.Rows[2].Cells[1].Value = Rastvorimost_end;

                dataGridView1.Rows[3].Cells[1].ReadOnly = true;
                dataGridView1.Rows[3].Cells[1].Value = Rastvorimost_start;

                dataGridView1.Rows[4].Cells[1].ReadOnly = true;
                dataGridView1.Rows[4].Cells[1].Value = Koeff_Sechenova ;
                
                dataGridView1.Rows[5].Cells[1].ReadOnly = true;
                dataGridView1.Rows[5].Cells[1].Value = Concentracia_salt;

                dataGridView1.Rows[6].Cells[1].Value=Molnaya_dolya;
                dataGridView1.Rows[6].Cells[1].ReadOnly = true;
                
            }
               
            if (comboBox1.SelectedItem.ToString() == "Технологические потери природного газа при вводе в скважины, трубопроводы и технологические линии химических реагентов")
            {
                Query = "SELECT* FROM Technological_losses_of_natural_gas_during_the_introduction_of_chemical_reagents_into_wells_and_production_lines";
                tip = true;
                LoadData();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].ReadOnly = true;

                }
                
                dataGridView1.Rows[4].Cells[1].ReadOnly = true;
                dataGridView1.Rows[4].Cells[1].Value =Molnaya_dolya;
                dataGridView1.Rows[7].Cells[1].ReadOnly = true;
            }
               
            if (comboBox1.SelectedItem.ToString() == "Технологические потери природного газа при отборе проб")
            {
                Query = "SELECT* FROM Technological_losses_of_natural_gas_during_sampling";
                tip = true;
                LoadData();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].ReadOnly = true;

                }
                dataGridView1.Rows[0].Cells[1].ReadOnly = true;
                dataGridView1.Rows[0].Cells[1].Value = Molnaya_dolya;

                dataGridView1.Rows[6].Cells[1].ReadOnly = true;
                

            }
                
            if (comboBox1.SelectedItem.ToString() == "Технологические потери прирoдного газа при обслуживании предохранительных клапанов")
            {
                Query = "SELECT* FROM Technological_losses_safety_valves";
                tip = true;
                LoadData();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].ReadOnly = true;

                }
                dataGridView1.Rows[1].Cells[1].ReadOnly = true;
                dataGridView1.Rows[6].Cells[1].ReadOnly = true;
                dataGridView1.Rows[6].Cells[1].Value = Molnaya_dolya;
            }
                
            if (comboBox1.SelectedItem.ToString() == "Технологические потери природного газа и конденсата при уносе с жидкостью")
            {
                Query = "SELECT* FROM Technological_losses_of_natural_gas_and_condensate_during_entrainment_with_liquid";
                tip = true;
                LoadData();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].ReadOnly = true;

                }
                dataGridView1.Rows[1].Cells[1].ReadOnly = true;
                dataGridView1.Rows[1].Cells[1].Value = Rastvorimost_end;

                dataGridView1.Rows[2].Cells[1].ReadOnly = true;
                dataGridView1.Rows[2].Cells[1].Value = Koeff_Sechenova;

                dataGridView1.Rows[4].Cells[1].ReadOnly = true;
                dataGridView1.Rows[0].Cells[1].Value = Molnaya_dolya;
            }
                
            if (comboBox1.SelectedItem.ToString() == "Технологические потери газового конденсата при отборе проб")
            {
                Query = "SELECT* FROM Technological_losses_of_gas_condensate_during_sampling_";
                tip = true;
                LoadData();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].ReadOnly = true;

                }
                dataGridView1.Rows[1].Cells[1].ReadOnly = true;
                dataGridView1.Rows[0].Cells[1].Value = Value_probkootbornika;
            }
                
            if (comboBox1.SelectedItem.ToString() == "Технологические потери природного газа и конденсата при опорожнении обвязок скважин")
            {
                Query = "SELECT* FROM Technological_losses_emptying_of_equipment_and_pipelines_before_repair_work";
                tip = true;
                LoadData();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].ReadOnly = true;

                    dataGridView1.Rows[i].Cells[4].ReadOnly = true;

                    dataGridView1.Rows[i].Cells[5].ReadOnly = true;

                    dataGridView1.Rows[i].Cells[7].ReadOnly = true;

                    dataGridView1.Rows[i].Cells[8].Value = Molnaya_dolya;
                    dataGridView1.Rows[i].Cells[8].ReadOnly = true;

                    dataGridView1.Rows[i].Cells[10].Value = Botuomskiy_Soderjanie_Condensata_pri_GDI_DKI;
                    dataGridView1.Rows[i].Cells[10].ReadOnly = true;
                }
            }
                
            

        }

        private void LoadData()

        {
            

            try
            {
                
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+Put+";Integrated Security=True");

               // ЕСТЬ QUERY  В НЕГО ПРОПИСАТЬ ЗАПРОСЫ ЗАРЕНЕЕ И ПРИ ВЫБОРЕ В СПИСКЕ ВИДА ПОТЕРЬ, ПОДСОВЫВАТЬ В QUERY ЦЕЛЫЙ SQL ЗАПРОС


                SqlDataAdapter adapter = new SqlDataAdapter(Query, connection);
                
                DataTable table = new DataTable();
                connection.Open();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
           
            // LoadData();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  LoadData();
            // tip = true;
            try
            {
                Molnaya_dolya = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value);
                Botuomskiy_Soderjanie_Condensata_pri_GDI_DKI = Convert.ToDouble(dataGridView1.Rows[1].Cells[1].Value);
                Concentracia_salt = Convert.ToDouble(dataGridView1.Rows[2].Cells[1].Value);
                Koeff_Sechenova = Convert.ToDouble(dataGridView1.Rows[3].Cells[1].Value);
                Rastvorimost_end = Convert.ToDouble(dataGridView1.Rows[4].Cells[1].Value);
                Value_probkootbornika = Convert.ToDouble(dataGridView1.Rows[5].Cells[1].Value);
            } catch(Exception ep)
            {
                MessageBox.Show(ep.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            if (tip == true)
            {
                if (comboBox1.SelectedItem.ToString() == "Технологические потери природного газа и конденсата при первичных ГДИ и ГКИ скважин")
                {
                    // MessageBox.Show(dataGridView1.Rows[0].Cells[3].Value.ToString());

                    for (int j = 1; j < 4; j++)
                    {
                        double kol_skw = Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value.ToString());
                        double sred_deb = Convert.ToDouble(dataGridView1.Rows[1].Cells[j].Value.ToString());
                        double kol_rej = Convert.ToDouble(dataGridView1.Rows[2].Cells[j].Value.ToString());
                        double time_rej = Convert.ToDouble(dataGridView1.Rows[3].Cells[j].Value.ToString());
                        double kol_isled = Convert.ToDouble(dataGridView1.Rows[4].Cells[j].Value.ToString());
                        double mol_dol = Convert.ToDouble(dataGridView1.Rows[5].Cells[j].Value.ToString());
                        double kol_conden = Convert.ToDouble(dataGridView1.Rows[6].Cells[j].Value.ToString());
                        double lost_gas = kol_skw * sred_deb * kol_rej * time_rej * kol_isled * mol_dol;
                        double lost_condensat = lost_gas * kol_conden * Math.Pow(10, -6);
                        if (j == 1)
                            MessageBox.Show(comboBox1.SelectedItem.ToString() + ":" + '\n' + "Потери газа: " + lost_gas + " м.куб." + '\n' + "Потери конденсата: " + lost_condensat + " м.куб.", "Ботуобинский горизонт");
                        if (j == 2)
                            MessageBox.Show(comboBox1.SelectedItem.ToString() + ":" + '\n' + "Потери газа: " + lost_gas + " м.куб." + '\n' + "Потери конденсата: " + lost_condensat + " м.куб.", "Хамакинский горизонт");
                        if (j == 3)
                            MessageBox.Show(comboBox1.SelectedItem.ToString() + ":" + '\n' + "Потери газа: " + lost_gas + " м.куб." + '\n' + "Потери конденсата: " + lost_condensat + " м.куб.", "Талахский горизонт");
                    }

                }

                if (comboBox1.SelectedItem.ToString() == "Технологические потери природного газа и конденсата при текущих ГДИ и ГКИ скважин")
                {
                    for (int j = 1; j < 4; j++)
                    {
                        double kol_skw = Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value.ToString());
                        double sred_deb = Convert.ToDouble(dataGridView1.Rows[1].Cells[j].Value.ToString());
                        double kol_rej = Convert.ToDouble(dataGridView1.Rows[2].Cells[j].Value.ToString());
                        double time_rej = Convert.ToDouble(dataGridView1.Rows[3].Cells[j].Value.ToString());
                        double kol_isled = Convert.ToDouble(dataGridView1.Rows[4].Cells[j].Value.ToString());
                        double mol_dol = Convert.ToDouble(dataGridView1.Rows[5].Cells[j].Value.ToString());
                        double kol_conden = Convert.ToDouble(dataGridView1.Rows[6].Cells[j].Value.ToString());
                        double lost_gas = kol_skw * sred_deb * kol_rej * time_rej * kol_isled * mol_dol;
                        double lost_condensat = lost_gas * kol_conden * Math.Pow(10, -6);
                        if (j == 1)
                            MessageBox.Show(comboBox1.SelectedItem.ToString() + ":" + '\n' + "Потери газа: " + lost_gas + " м.куб." + '\n' + "Потери конденсата: " + lost_condensat + " м.куб.", "Ботуобинский горизонт");
                        if (j == 2)
                            MessageBox.Show(comboBox1.SelectedItem.ToString() + ":" + '\n' + "Потери газа: " + lost_gas + " м.куб." + '\n' + "Потери конденсата: " + lost_condensat + " м.куб.", "Хамакинский горизонт");
                        if (j == 3)
                            MessageBox.Show(comboBox1.SelectedItem.ToString() + ":" + '\n' + "Потери газа: " + lost_gas + " м.куб." + '\n' + "Потери конденсата: " + lost_condensat + " м.куб.", "Талахский горизонт");
                    }
                }

                if (comboBox1.SelectedItem.ToString() == "Технологические потери природного газа и конденсата при опорожнении технологического оборудования и трубопроводов перед проведением ремонтных работ")
                {
                    double lost_ga = 0;
                   double lost_condensat = 0;
                    for (int j = 0; j < 18; j++)
                    {
                        double V = Convert.ToDouble(dataGridView1.Rows[j].Cells[1].Value.ToString());
                        double Pn = Convert.ToDouble(dataGridView1.Rows[j].Cells[2].Value.ToString());
                        double Tn = Convert.ToDouble(dataGridView1.Rows[j].Cells[3].Value.ToString());
                        double Pk = Convert.ToDouble(dataGridView1.Rows[j].Cells[4].Value.ToString());
                        double Tk = Convert.ToDouble(dataGridView1.Rows[j].Cells[5].Value.ToString());
                        double Zn = Convert.ToDouble(dataGridView1.Rows[j].Cells[6].Value.ToString());
                        double Zk = Convert.ToDouble(dataGridView1.Rows[j].Cells[7].Value.ToString());
                        double Xi = Convert.ToDouble(dataGridView1.Rows[j].Cells[8].Value.ToString());
                        double N = Convert.ToDouble(dataGridView1.Rows[j].Cells[9].Value.ToString());
                        double gk = Convert.ToDouble(dataGridView1.Rows[j].Cells[10].Value.ToString());
                        lost_ga += Convert.ToInt32(2893 * V * (((Pn) / (Tn * Zn)) + ((Pk) / (Tk * Zk))) * Xi * N);
                        lost_condensat +=Convert.ToInt32( lost_ga * gk);
                    }
                    MessageBox.Show(comboBox1.SelectedItem.ToString() + ":" + '\n' + "Потери газа: " + lost_ga + " м.куб." + '\n' + "Потери конденсата: " + lost_condensat + " м.куб.");
                   // SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Put + ";Integrated Security=True");
                    
                   // using (SqlCommand command = new SqlCommand("INSERT INTO Table VALUES (@id,@ent,@ed,@time)", connection))
                   // {
                   //     command.Parameters.AddWithValue("@id", comboBox1.SelectedItem.ToString());
                   //     command.Parameters.AddWithValue("@ent", lost_ga.ToString());
                   //     command.Parameters.AddWithValue("@ed", lost_condensat.ToString());
                   //     command.Parameters.AddWithValue("@time", DateTime.Now.ToString());
//
                   // }
                  //  connection.Open();
                       
                    
                   // connection.Close();
                }

                if (comboBox1.SelectedItem.ToString() == "Технологические потери природного газа и конденсата при дегазации и выветривании пластовой и конденсатной воды")
                {
                    double lost = 0;
                    double Q = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value.ToString());
                    double T_App = Convert.ToDouble(dataGridView1.Rows[1].Cells[1].Value.ToString());
                    double rast_n = Convert.ToDouble(dataGridView1.Rows[2].Cells[1].Value.ToString());
                    double rast_k = Convert.ToDouble(dataGridView1.Rows[3].Cells[1].Value.ToString());
                    double K_sech = Convert.ToDouble(dataGridView1.Rows[4].Cells[1].Value.ToString());
                    double konc_salt = Convert.ToDouble(dataGridView1.Rows[5].Cells[1].Value.ToString());
                    double M = Convert.ToDouble(dataGridView1.Rows[6].Cells[1].Value.ToString());
                    double time = Convert.ToDouble(dataGridView1.Rows[7].Cells[1].Value.ToString());
                    lost = konc_salt * (rast_k - rast_n) * time * M * Math.Pow(10, (-K_sech * konc_salt)) / 1000;
                    MessageBox.Show(comboBox1.SelectedItem.ToString() + ":" + '\n' + "Потери газа: " + lost + " м.куб.");
                }

                if (comboBox1.SelectedItem.ToString() == "Технологические потери природного газа при вводе в скважины, трубопроводы и технологические линии химических реагентов")
                {
                    double V = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value.ToString());
                    double P_work = Convert.ToDouble(dataGridView1.Rows[1].Cells[1].Value.ToString());
                    double T = Convert.ToDouble(dataGridView1.Rows[2].Cells[1].Value.ToString());
                    double Z = Convert.ToDouble(dataGridView1.Rows[3].Cells[1].Value.ToString());
                    double M = Convert.ToDouble(dataGridView1.Rows[4].Cells[1].Value.ToString());
                    double K = Convert.ToDouble(dataGridView1.Rows[5].Cells[1].Value.ToString());
                    double N = Convert.ToDouble(dataGridView1.Rows[6].Cells[1].Value.ToString());
                    double time = Convert.ToDouble(dataGridView1.Rows[7].Cells[1].Value.ToString());
                    double lost = (2893 * V * P_work * M * K * N) / (T * Z * 1000);
                    MessageBox.Show(comboBox1.SelectedItem.ToString() + ":" + '\n' + "Потери газа: " + lost + " м.куб.");
                }

                if (comboBox1.SelectedItem.ToString() == "Технологические потери природного газа при отборе проб")
                {
                    double V = Convert.ToDouble(dataGridView1.Rows[1].Cells[1].Value.ToString());
                    double P_work = Convert.ToDouble(dataGridView1.Rows[2].Cells[1].Value.ToString());
                    double T = Convert.ToDouble(dataGridView1.Rows[3].Cells[1].Value.ToString());
                    double Z = Convert.ToDouble(dataGridView1.Rows[4].Cells[1].Value.ToString());
                    double Ni = Convert.ToDouble(dataGridView1.Rows[5].Cells[1].Value.ToString());
                    double loss = (2893 * V * P_work * 31 * Ni) / (T * Z);
                    MessageBox.Show(comboBox1.SelectedItem.ToString() + ":" + '\n' + "Потери газа: " + loss + " м.куб.");
                }

                if (comboBox1.SelectedItem.ToString() == "Технологические потери прирoдного газа при обслуживании предохранительных клапанов")
                {
                    double S = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value.ToString());
                    double Koef = Convert.ToDouble(dataGridView1.Rows[1].Cells[1].Value.ToString());
                    double P = Convert.ToDouble(dataGridView1.Rows[2].Cells[1].Value.ToString());
                    double T = Convert.ToDouble(dataGridView1.Rows[3].Cells[1].Value.ToString());
                    double Z = Convert.ToDouble(dataGridView1.Rows[4].Cells[1].Value.ToString());
                    double t = Convert.ToDouble(dataGridView1.Rows[5].Cells[1].Value.ToString());
                    double M = Convert.ToDouble(dataGridView1.Rows[6].Cells[1].Value.ToString());
                    double n = Convert.ToDouble(dataGridView1.Rows[7].Cells[1].Value.ToString());
                    double lost = 37300 * S * Koef * P * t * M * n * Math.Sqrt((Z / T));
                    MessageBox.Show(comboBox1.SelectedItem.ToString() + ":" + '\n' + "Потери газа: " + lost + " м.куб.");
                }

                if (comboBox1.SelectedItem.ToString() == "Технологические потери природного газа и конденсата при уносе с жидкостью")
                {
                    double V = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value.ToString());
                    double r = Convert.ToDouble(dataGridView1.Rows[1].Cells[1].Value.ToString());
                    double k = Convert.ToDouble(dataGridView1.Rows[2].Cells[1].Value.ToString());
                    double c = Convert.ToDouble(dataGridView1.Rows[3].Cells[1].Value.ToString());
                    double Xk = Convert.ToDouble(dataGridView1.Rows[4].Cells[1].Value.ToString());
                    double Gk = Convert.ToDouble(dataGridView1.Rows[5].Cells[1].Value.ToString());
                    double t = Convert.ToDouble(dataGridView1.Rows[6].Cells[1].Value.ToString());
                    double lost_gas = V * r * Xk * Math.Pow(10, (-k * c));
                    double lost_conden = V * Gk * t * Math.Pow(10, -6);
                    MessageBox.Show(comboBox1.SelectedItem.ToString() + ":" + '\n' + "Потери газа: " + lost_gas + " м.куб." + '\n' + "Потери конденсата: " + lost_conden + " м.куб.");
                }

                if (comboBox1.SelectedItem.ToString() == "Технологические потери газового конденсата при отборе проб")
                {
                    double V = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value.ToString());
                    double r = Convert.ToDouble(dataGridView1.Rows[1].Cells[1].Value.ToString());
                    double k = Convert.ToDouble(dataGridView1.Rows[2].Cells[1].Value.ToString());
                    double c = Convert.ToDouble(dataGridView1.Rows[3].Cells[1].Value.ToString());
                    double Xk = Convert.ToDouble(dataGridView1.Rows[4].Cells[1].Value.ToString());
                    double lost = V * Xk * c * Math.Pow(10, -3) * 4;
                    MessageBox.Show(comboBox1.SelectedItem.ToString() + ":" + '\n' + "Потери газового конденсата: " + lost + " м.куб.");
                }

                if (comboBox1.SelectedItem.ToString() == "Технологические потери природного газа и конденсата при опорожнении обвязок скважин")
                {
                    double lost_ga = 0;
                    double lost_condensat = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        double V = Convert.ToDouble(dataGridView1.Rows[j].Cells[1].Value.ToString());
                        double Pn = Convert.ToDouble(dataGridView1.Rows[j].Cells[2].Value.ToString());
                        double Tn = Convert.ToDouble(dataGridView1.Rows[j].Cells[3].Value.ToString());
                        double Pk = Convert.ToDouble(dataGridView1.Rows[j].Cells[4].Value.ToString());
                        double Tk = Convert.ToDouble(dataGridView1.Rows[j].Cells[5].Value.ToString());
                        double Zn = Convert.ToDouble(dataGridView1.Rows[j].Cells[6].Value.ToString());
                        double Zk = Convert.ToDouble(dataGridView1.Rows[j].Cells[7].Value.ToString());
                        double Xi = Convert.ToDouble(dataGridView1.Rows[j].Cells[8].Value.ToString());
                        double N = Convert.ToDouble(dataGridView1.Rows[j].Cells[9].Value.ToString());
                        double gk = Convert.ToDouble(dataGridView1.Rows[j].Cells[10].Value.ToString());
                        lost_ga += 2893 * V * (((Pn) / (Tn * Zn)) - ((Pk) / (Tk * Zk))) * Xi * N;
                        lost_condensat += lost_ga * gk;
                    }
                    MessageBox.Show(comboBox1.SelectedItem.ToString() + ":" + '\n' + "Потери газа: " + lost_ga + " м.куб." + '\n' + "Потери конденсата: " + lost_condensat + " м.куб.");
                }
            }
            else
            {
                MessageBox.Show("Прежде чем посчитать потери, нажмите кнопку 'Oбновить'", "Ошибка!");
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

            Bitmap bmp = new Bitmap(dataGridView1.Size.Width+10000 , dataGridView1.Size.Height +500);
            dataGridView1.DrawToBitmap(bmp, dataGridView1.Bounds);
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            string txt = comboBox1.SelectedItem.ToString() + '\n' + '\n';
            e.Graphics.DrawString(txt, new Font("Times New Roman", 16), Brushes.Black, 10,20);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintPageHandler;
            printDocument.PrintPage += printDocument1_PrintPage;
            System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print();


        }
    }
}
