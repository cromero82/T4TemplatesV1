using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTemplatesTn.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // var conexion = ConfigurationManager.ConnectionStrings["ControlcBDEntities"].ToString();
            SqlConnection conn = new SqlConnection();
            //var cadenaConexion = "Data Source=CROMERO/SQLEXPRESS;" + "Initial Catalog=ControlcBD;" + "User id=adminservertaxi;" + "Password=adm1ns3rv3rtaxi*;";
            conn.ConnectionString = "Data Source=CROMERO\\SQLEXPRESS;" + "Initial Catalog=ControlcBD;" + "User id=adminservertaxi;" + "Password=adm1ns3rv3rtaxi*;";
            try
            {
                conn.Open();
                // get the database information
                DataTable databases = conn.GetSchema(SqlClientMetaDataCollectionNames.Databases);
                // print out the connections
                foreach (DataColumn column in databases.Columns)
                {
                    Console.Write("{0,-25}", column.ColumnName);
                }
                Console.WriteLine();
                // print out the rows...
                foreach (DataRow database in databases.Rows)
                {
                    //database.ItemArray[0]
                    //for (int i = 0; i < database.ItemArray.Length; i++)
                    //{
                    //    Console.Write("{0,-25}", database.ItemArray[i]);
                    //}
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            //using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ControlcBDEntities"].ToString()))
            //{
            //    cnn.Open();
            //    //string query = @"select TOTAL_PUNTOS from RESULTADOS where ID_ENCUESTA= 1";
            //    //SqlCommand cmd = new SqlCommand(query, cnn);
            //    //string a = Convert.ToString(cmd.ExecuteScalar());
            //    cnn.Close();
            //}
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}