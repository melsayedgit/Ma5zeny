using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;


namespace Ma5zeny
{
    public partial class Dashboard : MaterialForm
    {
     
        public Dashboard()
        {
            InitializeComponent();

        }


        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppManager.LoginForm.Close();
            
        }

        //initing the views 
        private void Dashboard_Load(object sender, EventArgs e)
        {

            updateWarehouseView();
            updateItemView();



        }
        #region updateviews
        void updateWarehouseView()
        {

           var  WarehouseView = from wr in AppManager.entities.Warehouses
                            select new 
                            {
                                wr.Name,
                                wr.Address,
                                wr.Manger_id
                            };
            listBox1.Items.Clear();
            foreach (var wr in WarehouseView)
            {
                listBox1.Items.Add( "Name:"+ wr.Name +",Address:"+ wr.Address+",Manger_id:" +wr.Manger_id );
            }
            
        }

        void updateItemView()
        {

            var view = from wr in AppManager.entities.Iteams
                                select new
                                {
                                    wr.BarCode,
                                    wr.Name  
                                };
            listBox2.Items.Clear();
            foreach (var wr in view)
            {
                listBox2.Items.Add("BarCode:" + wr.BarCode + ",Name:" + wr.Name );
            }

        }
        #endregion

        #region Warehouse


        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
  

           
            try
            {
                Warehouse temp = new Warehouse();
                temp.Name = textBox1.Text;
                temp.Address = textBox2.Text;

                if (temp.Name == "")
                {
                    MessageBox.Show("You Didn't enter Warehouse Name","Error");
                }
                else
                {
                    temp.Manger_id = int.Parse(textBox3.Text);
                    AppManager.entities.Warehouses.Add(temp);
                    AppManager.entities.SaveChanges();
                    updateWarehouseView();


                }
                
            }
            catch (Exception)
            {
              
                MessageBox.Show("Conflicting Data","Error");
            }

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            Warehouse temp = AppManager.entities.Warehouses.Find(textBox1.Text);
            if (temp != null)
            {

                try
                {
                    if (temp.Name == "")
                    {
                        MessageBox.Show( "You Didn't enter Warehouse Name","Error");
                    }
                    else
                    {
                        
                        AppManager.entities.Warehouses.Remove(temp);
                        temp.Name = textBox1.Text;
                        temp.Address = textBox2.Text;
                        temp.Manger_id = int.Parse(textBox3.Text);
                        AppManager.entities.Warehouses.Add(temp);
                        AppManager.entities.SaveChanges();
                        updateWarehouseView();



                    }

                }
                catch (Exception)
                {

                    MessageBox.Show("Conflicting Data", "Error");
                }
            }

            else
            {
                MessageBox.Show( "Could not find WareHouse ","Error");
            }
        }
        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            Warehouse temp = AppManager.entities.Warehouses.Find(textBox1.Text);
            if (temp != null)
            {

                try
                {
                    if (temp.Name == "")
                    {
                        MessageBox.Show("You Didn't enter Warehouse Name", "Error");
                    }
                    else
                    {

                        AppManager.entities.Warehouses.Remove(temp);
                        AppManager.entities.SaveChanges();
                        updateWarehouseView();



                    }

                }
                catch (Exception)
                {

                    MessageBox.Show("Conflicting Data", "Error");
                }
            }

            else
            {
                MessageBox.Show("Could not find WareHouse ", "Error");
            }
        }
        #endregion Warehouse

        #region Items 

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {

            try
            {
                var temp = new Iteam();
                temp.BarCode = int.Parse(textBox6.Text);
                temp.Name = textBox5.Text;

                if (temp.Name == "")
                {
                    MessageBox.Show("You Didn't enter Item Name", "Error");
                }
                else
                {

                    AppManager.entities.Iteams.Add(temp);
                    AppManager.entities.SaveChanges();
                    updateItemView();


                }

            }
            catch (Exception)
            {

                MessageBox.Show("Conflicting Data", "Error");
            }
        }
        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {

            try
            {
                var temp = AppManager.entities.Iteams.Find(int.Parse(textBox6.Text));


                if (temp.Name == "")
                {
                    MessageBox.Show("You Didn't enter Item Name", "Error");
                }
                else
                {
                    AppManager.entities.Iteams.Remove(temp);
                    temp.BarCode = int.Parse(textBox6.Text);
                    temp.Name = textBox5.Text;
                    AppManager.entities.Iteams.Add(temp);
                    AppManager.entities.SaveChanges();
                    updateItemView();


                }

            }
            catch (Exception)
            {

                MessageBox.Show("Conflicting Data", "Error");
            }
        }

  
  

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            try
            {
                var temp = AppManager.entities.Iteams.Find(int.Parse(textBox6.Text));


                if (temp.Name == "")
                {
                    MessageBox.Show("You Didn't enter Item Name", "Error");
                }
                else
                {
                    AppManager.entities.Iteams.Remove(temp);
                    AppManager.entities.SaveChanges();
                    updateItemView();


                }

            }
            catch (Exception)
            {

                MessageBox.Show("Conflicting Data", "Error");
            }
        }
        #endregion


    }



}
