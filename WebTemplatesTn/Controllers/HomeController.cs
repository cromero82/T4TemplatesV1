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
            //http://tom-shelton.net/index.php/2009/02/21/exploring-sql-server-schema-information-with-adonet/                       
            SqlConnection conn = new SqlConnection();
            string esquemaBase = "dbo";
            conn.ConnectionString = "Data Source=CROMERO\\SQLEXPRESS;" + "Initial Catalog=ControlcBD;" + "User id=adminservertaxi;" + "Password=adm1ns3rv3rtaxi*;";
            try
            {
                conn.Open();
                // get the database information
                DataTable databases = conn.GetSchema(SqlClientMetaDataCollectionNames.Tables, new string[] { null, null, null, "BASE TABLE" }); //conn.GetSchema(SqlClientMetaDataCollectionNames.Databases);
                // print out the connections
                //foreach (DataColumn column in databases.Columns)
                //{
                //    Console.Write("{0,-25}", column.ColumnName);
                //}
                SqlCommand sqlCmd;
                string sql = null;

                foreach (DataRow table in databases.Rows)
                {
                    Console.WriteLine(string.Format("{0}.{1}", table["TABLE_SCHEMA"], table["TABLE_NAME"]));
                    string tabla = string.Format("{0}.{1}", table["TABLE_SCHEMA"], table["TABLE_NAME"]);
                    tabla = tabla.Replace(esquemaBase+".", "");
                    sql = "Select * from " + tabla;

                    sqlCmd = new SqlCommand(sql, conn);
                    SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                    DataTable schemaTable = sqlReader.GetSchemaTable();

                    foreach (DataRow row in schemaTable.Rows)
                    {
                        foreach (DataColumn column in schemaTable.Columns)
                        {
                            Console.WriteLine(string.Format("{0} = {1}", column.ColumnName, row[column]));
                        }
                    }
                    sqlReader.Close();
                    sqlCmd.Dispose();

                    Console.WriteLine(tabla);                    
                    //string.Format("{0}.{1}", table["TABLE_SCHEMA"], table["TABLE_NAME"])
                    //"dbo.Tdepartamentos"
                }
                Console.WriteLine();
                // print out the rows...
                //foreach (DataRow database in databases.Rows)
                //{
                //    //database.ItemArray[0]
                //    //for (int i = 0; i < database.ItemArray.Length; i++)
                //    //{
                //    //    Console.Write("{0,-25}", database.ItemArray[i]);
                //    //}
                //    Console.WriteLine();
                //}
                conn.Close();
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