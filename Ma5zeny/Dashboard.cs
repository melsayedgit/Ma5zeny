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
            updateSuppliersView();
            updateCustomersView();



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

        void updateSuppliersView()
        {

            var supplierview = from sp in AppManager.entities.Suppliers
                                select new
                                {
                                    sp.ID,
                                    sp.Name,
                                    sp.Phone_,
                                    sp.FAX,
                                    sp.Email,
                                    sp.Website
                                };
            listBox3.Items.Clear();
            foreach (var sp in supplierview)
            {
                listBox3.Items.Add("Id:" + sp.ID + ",Name:" + sp.Name 
                    + ",phone:" + sp.Phone_+ ",fax:"+sp.FAX
                    +",email:"+sp.Email+"website:"+sp.Website);
            }

        }

        void updateCustomersView()
        {

            var Customersrview = from sp in AppManager.entities.Customers
                                 select new
                                 {
                                     sp.ID,
                                     sp.Name,
                                     sp.Phone,
                                     sp.FAX,
                                     sp.Email,
                                     sp.Website
                                 };
            listBox4.Items.Clear();
            foreach (var sp in Customersrview)
            {
                listBox4.Items.Add("Id:" + sp.ID + ",Name:" + sp.Name
                    + ",phone:" + sp.Phone + ",fax:" + sp.FAX
                    + ",email:" + sp.Email + "website:" + sp.Website);
            }

        }
            void updateBuyingView()
            {

                var BuyingView = from inv in AppManager.entities.Buying_Invoice
                                     select new
                                     {
                                         inv.Order_number,
                                         inv.Buying_Date,
                                         inv.producing_Date,
                                         inv.expiry_count_days,
                                         inv.Warehouse,
                                         inv.Supplier_D
                                     };
                listBox4.Items.Clear();
                foreach (var inv in BuyingView)
                {
                    listBox4.Items.Add("Order number:" + inv.Order_number + ",Buying_Date:" + inv.Buying_Date
                        + ",producing_Date:" + inv.producing_Date + ",expiry_days:" + inv.expiry_count_days
                        + ",Warehouse:" + inv.Warehouse + "Supplier_D:" + inv.Supplier_D);
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

        #region Suplier
        private void materialRaisedButton9_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier temp = new Supplier();
                temp.ID = int.Parse(textBox9.Text);
                temp.Name = textBox8.Text;
                temp.Phone_ = int.Parse(textBox7.Text);
                temp.FAX = int.Parse(textBox4.Text);
                temp.Email = textBox10.Text;
                temp.Website = textBox11.Text;
                AppManager.entities.Suppliers.Add(temp);
                    AppManager.entities.SaveChanges();
                updateSuppliersView();



            }
            catch (Exception)
            {

                MessageBox.Show("Conflicting Data", "Error");
            }
        }

        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {
            try
            {

                Supplier temp = AppManager.entities.Suppliers.Find(int.Parse(textBox9.Text));
                AppManager.entities.Suppliers.Remove(temp);
                temp.ID = int.Parse(textBox9.Text);
                temp.Name = textBox8.Text;
                temp.Phone_ = int.Parse(textBox7.Text);
                temp.FAX = int.Parse(textBox4.Text);
                temp.Email = textBox10.Text;
                temp.Website = textBox11.Text;
                AppManager.entities.Suppliers.Add(temp);
                AppManager.entities.SaveChanges();
                updateSuppliersView();


            }
            catch (Exception)
            {

                MessageBox.Show("Conflicting Data", "Error");
            }
        }

        private void materialRaisedButton7_Click(object sender, EventArgs e)
        {
            try
            {

                Supplier temp = AppManager.entities.Suppliers.Find(int.Parse(textBox9.Text));
                AppManager.entities.Suppliers.Remove(temp);
                AppManager.entities.SaveChanges();
                updateSuppliersView();



            }
            catch (Exception)
            {

                MessageBox.Show("Conflicting Data", "Error");
            }
        }
        #endregion

        #region Customer
        private void materialRaisedButton12_Click(object sender, EventArgs e)
        {
            try
            {
                Customer temp = new Customer();
                temp.ID = int.Parse(textBox12.Text);
                temp.Name = textBox17.Text;
                temp.Phone = int.Parse(textBox16.Text);
                temp.FAX = int.Parse(textBox15.Text);
                temp.Email = textBox14.Text;
                temp.Website = textBox13.Text;
                AppManager.entities.Customers.Add(temp);
                AppManager.entities.SaveChanges();
                updateCustomersView();



            }
            catch (Exception)
            {

                MessageBox.Show("Conflicting Data", "Error");
            }
        }

        private void materialRaisedButton11_Click(object sender, EventArgs e)
        {
            try
            {
                Customer temp = AppManager.entities.Customers.Find(int.Parse(textBox12.Text));
                AppManager.entities.Customers.Remove(temp);
                temp.ID = int.Parse(textBox12.Text);
                temp.Name = textBox17.Text;
                temp.Phone = int.Parse(textBox16.Text);
                temp.FAX = int.Parse(textBox15.Text);
                temp.Email = textBox14.Text;
                temp.Website = textBox13.Text;
                AppManager.entities.Customers.Add(temp);
                AppManager.entities.SaveChanges();
                updateCustomersView();



            }
            catch (Exception)
            {

                MessageBox.Show("Conflicting Data", "Error");
            }
        }

        private void materialRaisedButton10_Click(object sender, EventArgs e)
        {
            try
            {
                Customer temp = AppManager.entities.Customers.Find(int.Parse(textBox12.Text));
                AppManager.entities.SaveChanges();
                updateCustomersView();



            }
            catch (Exception)
            {

                MessageBox.Show("Conflicting Data", "Error");
            }

        }


        #endregion

        #region Buying invoices
        private void materialRaisedButton15_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton14_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton13_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }





}
