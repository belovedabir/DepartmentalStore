using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepartmentalStoreApp
{
    public partial class DepartmentalUI : Form
    {
        public DepartmentalUI()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source = DESKTOP-T099P76\SQLEXPRESS; Initial Catalog = DepartmentalStoreDB; Integrated Security=True";
        private void totalButton_Click(object sender, EventArgs e)
        {
            string customerName = customerNameTextBox.Text;
            int riceRate = 0;
            int eggRate = 0;
            int milkRate = 0;
            int biscuitRate = 0;
            int chocolateRate = 0;
            int iceCreamRate = 0;
            int dalRate = 0;
            int sugarRate = 0;
            int oilRate = 0;
            int flourRate = 0;
            int totalAmount = 0;

            int rice = 0;
            int egg = 0;
            int milk = 0;
            int biscuit = 0;
            int chocolate = 0;
            int iceCream = 0;
            int dal = 0;
            int sugar = 0;
            int oil = 0;
            int flour = 0;

            rice = Convert.ToInt32(riceTextBox.Text);
            egg = Convert.ToInt32(eggTextBox.Text);
            milk = Convert.ToInt32(milkTextBox.Text);
            biscuit = Convert.ToInt32(biscuitTextBox.Text);
            chocolate = Convert.ToInt32(chocolateTextBox.Text);
            iceCream = Convert.ToInt32(iceCreamTextbox.Text);
            dal = Convert.ToInt32(dalTextBox.Text);
            sugar = Convert.ToInt32(sugarTextBox.Text);
            oil = Convert.ToInt32(oilTextBox.Text);
            flour = Convert.ToInt32(flourTextBox.Text);

            if(customerName== "")
            {
                MessageBox.Show("Please provide Customer Name");
            }

            else
            {
                if (rice != 0)
                {
                    riceRate = rice * 50;
                }

                if (rice == 0)
                {
                    rice = 0;
                }

                if (egg != 0)
                {
                    eggRate = egg * 8;
                }

                if (egg == 0)
                {
                    egg = 0;
                }

                if (milk != 0)
                {
                    milkRate = milk * 70;
                }

                if (milk == 0)
                {
                    milk = 0;
                }

                if (biscuit != 0)
                {
                    biscuitRate = biscuit * 100;
                }

                if (biscuit == 0)
                {
                    biscuit = 0;
                }

                if (chocolate != 0)
                {
                    chocolateRate = chocolate * 30;
                }

                if (chocolate == 0)
                {
                    chocolate = 0;
                }

                if (iceCream != 0)
                {
                    iceCreamRate = iceCream * 35;
                }

                if (iceCream == 0)
                {
                    iceCream = 0;
                }

                if (dal != 0)
                {
                    dalRate = dal * 65;
                }

                if (dal == 0)
                {
                    dal = 0;
                }

                if (sugar != 0)
                {
                    sugarRate = sugar * 55;
                }

                if (sugar == 0)
                {
                    sugar = 0;
                }

                if (oil != 0)
                {
                    oilRate = oil * 120;
                }

                if (oil == 0)
                {
                    oil = 0;
                }

                if (flour != 0)
                {
                    flourRate = flour * 45;
                }

                if (flour == 0)
                {
                    flour = 0;
                }

                totalAmount = riceRate + eggRate + milkRate + biscuitRate + chocolateRate + iceCreamRate + dalRate + sugarRate + oilRate + flourRate;

                SaveData(customerName, rice, egg, milk, biscuit, chocolate, iceCream, dal, sugar, oil, flour, totalAmount);

                MessageBox.Show("Customer Name : " + customerName + "\n\nRice : " + rice + " kg\n" + "Egg : " + egg + " piece\n" + " Milk : " + milk + " litter\n" + "Biscuit : " + biscuit + " packet\n" + "Chocolate : " + chocolate + " piece\n" + "Ice Cream : " + iceCream + " piece\n" + "Dal : " + dal + " kg\n" + "Sugar : " + sugar + " kg\n" + "Oil : " + oil + " litter\n" + "Flour : " + flour + " kg\n" + "Total Amount : " + totalAmount + " Tk");

                ClearField();
            }
        }

        private bool SaveData(string customerName, int rice, int egg, int milk, int biscuit, int chocolate, int iceCream,int dal, int sugar, int oil, int flour, int totalAmount)
        {
            string sqlString = string.Format(@"INSERT INTO [dbo].[ProductItem]
                                           ([CustomerName]
                                           ,[Rice]
                                           ,[Egg]
                                           ,[Milk]
                                           ,[Biscuit]
                                           ,[Chocolate]
                                            ,[IceCream]
                                            ,[Dal]
                                            ,[Sugar]
                                            ,[Oil]
                                            ,[Flour]
                                            ,[TotalAmount])
                                     VALUES
                                           ('{0}'
                                           ,'{1} Kg'
                                           ,'{2} piece'
                                           ,'{3} litter'
                                           ,'{4} packet'
                                            ,'{5} piece'
                                            ,'{6} piece'
                                            ,'{7} Kg'
                                            ,'{8} Kg'
                                            ,'{9} litter'
                                            ,'{10} Kg'
                                            ,'{11} Tk')", customerName, rice, egg, milk, biscuit,chocolate,iceCream,dal,sugar,oil,flour,totalAmount);

            int value = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = sqlString;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    conn.Open();

                    value = cmd.ExecuteNonQuery();
                }
            }
            if (value > 0)
            {
                return true;
            }
            else
                return false;
        }

        private void ClearField()
        {
            customerNameTextBox.Text = "";
            riceTextBox.Text = "";
            eggTextBox.Text = "";
            milkTextBox.Text = "";
            biscuitTextBox.Text = "";
            customerNameTextBox.Text = "";
            dalTextBox.Text = "";
            sugarTextBox.Text = "";
            oilTextBox.Text = "";
            flourTextBox.Text = "";
            iceCreamTextbox.Text = "";
        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowAllInformation showAllInformation = new ShowAllInformation();
            showAllInformation.Show();
        }
   }
}
