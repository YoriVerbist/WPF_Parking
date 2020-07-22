using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.MobileControls;
namespace WpfAppParking.Model
{
    class ParkingDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["local"].ConnectionString;
        // openen connectie
        private static IDbConnection db = new SqlConnection(connectionString);

        public List<Parking> GetParkingen()
        {
            string sql = "Select * from Parking order by Naam";

            List<Parking> Parkingen = (List<Parking>)db.Query<Parking>(sql);

            return Parkingen;
        }
    }
}
