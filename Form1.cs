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

namespace Project18_DashboardSuperStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;initial catalog=Db17Project20;integrated security=true");
        private void Form1_Load(object sender, EventArgs e)
        {
            #region Widgets     
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select Count(Distinct(Product_Name) )from superstore",sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lblProductCount.Text = reader[0].ToString();
            }
            sqlConnection.Close();
            
            
            sqlConnection.Open();
            SqlCommand commandCity = new SqlCommand("Select Count(Distinct(State) )from superstore ", sqlConnection);
            SqlDataReader readerCity = commandCity.ExecuteReader();
            while (readerCity.Read())
            {
                lblCityCount.Text = readerCity[0].ToString();
            }
            sqlConnection.Close();

            sqlConnection.Open();
            SqlCommand commandOrder= new SqlCommand("Select Sum(Quantity) from superstore ", sqlConnection);
            SqlDataReader readerOrder = commandOrder.ExecuteReader();
            while (readerOrder.Read())
            {
                lblOrderCount.Text = readerOrder[0].ToString();
            }
            sqlConnection.Close();

            sqlConnection.Open();
            SqlCommand commandTurkey = new SqlCommand("Select Sum(Quantity) from superstore where Country = 'Turkey' ", sqlConnection);
            SqlDataReader readerTurkey = commandTurkey.ExecuteReader();
            while (readerTurkey.Read())
            {
                lblOrderCountByTurkey.Text = readerTurkey[0].ToString();
            }
            sqlConnection.Close();

            #endregion

            #region Charts
            sqlConnection.Open();
            SqlCommand commandChart1 = new SqlCommand("Select top(7) Country ,Count(*) from superstore group by Country Order by Count(*) desc ", sqlConnection);
            SqlDataReader readerChart1 = commandChart1.ExecuteReader();
            while (readerChart1.Read())
            {
                chart1.Series["Series1"].Points.AddXY(readerChart1[0], readerChart1[1]);
            }
            sqlConnection.Close();


            //chart1.Series["Series1"].Points.AddXY("Paris", 23);
            //chart1.Series["Series1"].Points.AddXY("New York", 72);
            //chart1.Series["Series1"].Points.AddXY("London", 44);


            sqlConnection.Open();
            SqlCommand commandChart2 = new SqlCommand("Select top(5) Country ,Sum(Quantity) from superstore group by Country Order by Sum(Quantity) desc ", sqlConnection);
            SqlDataReader readerChart2 = commandChart2.ExecuteReader();
            while (readerChart2.Read())
            {
                chart2.Series["Series1"].Points.AddXY(readerChart2[0], readerChart2[1]);
            }
            sqlConnection.Close();


            //chart2.Series["Series1"].Points.AddXY("Milan", 53);
            //chart2.Series["Series1"].Points.AddXY("Paris", 23);
            //chart2.Series["Series1"].Points.AddXY("New York", 72);

            sqlConnection.Open();
            SqlCommand commandChart3 = new SqlCommand("Select Order_Priority,Count(*) from superstore group by Order_Priority Order by Order_Priority desc ", sqlConnection);
            SqlDataReader readerChart3 = commandChart3.ExecuteReader();
            while (readerChart3.Read())
            {
                chart3.Series["Series1"].Points.AddXY(readerChart3[0], readerChart3[1]);
            }
            sqlConnection.Close();
            //chart3.Series["Series1"].Points.AddXY("Milan", 53);
            //chart3.Series["Series1"].Points.AddXY("Paris", 23);
            //chart3.Series["Series1"].Points.AddXY("New York", 72);

            #endregion
        }
    }
}
