using Inventory_Sanchez;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace frmAddProduct
{
    public partial class frmAddProduct : Form
    {
        private string _ProductName, _Category, _MfgDate, _ExpDate, _Description;
        private double _SellPrice;
        private int _Quantity;
        BindingSource ProductsBS;
        BindingList<ProductClass> ListOfProducts;

        public frmAddProduct()
        {
            InitializeComponent();
            ProductsBS = new BindingSource();
            ListOfProducts = new BindingList<ProductClass>();
            ProductsBS.DataSource = ListOfProducts;
            gridViewProductList.DataSource = ProductsBS;
            gridViewProductList.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory =
            {
                "Beverages", "Bread/Bakery", "Canned/Jarred Goods", "Dairy", "Frozen Goods", "Meat", "Personal Care", "Other"
            };
            foreach (string LPC in ListOfProductCategory)
            {
                cbCategory.Items.Add(LPC);
            }
        }

        public string Product_Name(string name)
        {
            try
            {
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    throw new StringFormatException("Invalid product name.");
                }
                return name;
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Product_Name OverflowException Message: " + ex.Message);
                return name;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Product_Name ArgumentException Message: " + ex.Message);
                return name;
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Product_Name IndexOutOfRangeException Message: " + ex.Message);
                return name;
            }
            catch (StringFormatException ex)
            {
                MessageBox.Show("Product_Name StringFormatException Message: " + ex.Message);
                return name;
            }
            finally
            {

            }
        }
        public int Quantity(string qty)
        {
            try
            {
                if (Regex.IsMatch(qty, @"^[0-9]+$"))
                {
                    _Quantity = Int32.Parse(qty);
                    return _Quantity;
                }
                else
                {
                    throw new NumberFormatException("Invalid quantity.");
                }
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Quantity OverflowException Message: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Quantity ArgumentNullException Message: " + ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Quantity IndexOutOfRangeException Message: " + ex.Message);
            }
            catch (NumberFormatException ex)
            {
                MessageBox.Show("Quantity NumberFormatException Message: " + ex.Message);
            }
            finally
            {

            }
            return 0;
        }

        public double SellingPrice(string price)
        {
            try
            {
                if (!Regex.IsMatch(price, @"^(\d*\.)?\d+$"))
                {
                    throw new CurrencyFormatException("Invalid selling price.");
                }
                return Convert.ToDouble(price);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("SellingPrice OverflowException Message: " + ex.Message);
                return 0.0;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("SellingPrice ArgumentNullException Message: " + ex.Message);
                return 0.0;
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("SellingPrice IndexOutOfRangeException Message: " + ex.Message);
                return 0.0;
            }
            catch (CurrencyFormatException ex)
            {
                MessageBox.Show("SellingPrice CurrencyFormatException Message: " + ex.Message);
                return 0.0;
            }
            finally
            {

            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Quantity(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);
                ListOfProducts.Add(new ProductClass(_ProductName, _Category, _MfgDate, _ExpDate, _SellPrice, _Quantity, _Description));
                ProductsBS.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
            }
        }
    }
}