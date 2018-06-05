using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTemplatesTn;

namespace WebTemplatesTn.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<EstructuraTabla> info = new List<EstructuraTabla>();
            info.Add(new EstructuraTabla
            {
                NombreColumna = "",
                PrecisionNumerica = "",
                TamanioColumna = "",
                TipoDato = ""
            });
            

            //UtilidadesGenerador util = new UtilidadesGenerador();
            EstructuraTabla estructura = new EstructuraTabla();
            //http://tom-shelton.net/index.php/2009/02/21/exploring-sql-server-schema-information-with-adonet/                       
            SqlConnection conn = new SqlConnection();
            string esquemaBase = "dbo";
            conn.ConnectionString = "Data Source=CROMERO\\SQLEXPRESS;" + "Initial Catalog=ControlcBD;" + "User id=adminservertaxi;" + "Password=adm1ns3rv3rtaxi*;";
            try
            {
                conn.Open();
                // get the database information
                DataTable databases = conn.GetSchema(SqlClientMetaDataCollectionNames.Tables, new string[] { null, null, null, "BASE TABLE" }); //conn.GetSchema(SqlClientMetaDataCollectionNames.Databases);
                SqlCommand sqlCmd;
                string sql = null;

                foreach (DataRow table in databases.Rows)
                {                    
                    string tabla = string.Format("{0}.{1}", table["TABLE_SCHEMA"], table["TABLE_NAME"]);
                    tabla = tabla.Replace(esquemaBase+".", "");
                    if(tabla == "GenPersona")
                    {

                    }
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
                }
                Console.WriteLine();
                
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
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