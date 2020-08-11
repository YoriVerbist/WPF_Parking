using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.MobileControls;
using WpfAppParking.Extensions;

namespace WpfAppParking.Model
{
    class ParkingDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["local"].ConnectionString;
        // openen connectie
        private static IDbConnection db = new SqlConnection(connectionString);

        public ObservableCollection<Parking> GetParkingen(Plaats plaats)
        {
            if (plaats == null)
            {
                plaats = new Plaats();
                plaats.ID = 0;
            }
            string sql = "Select * from Parking where Plaats_ID =@ID order by Naam";

            ObservableCollection<Parking> Parkingen = db.Query<Parking>(sql, new {plaats.ID}).ToObservableCollection();

            return Parkingen;
        }

        public void UpdateParking(Parking parking)
        {
            // Sql update statement
            string sql = "Update Parking set Plaats_ID = @Plaats_ID, Naam = @naam where ID = @ID";

            db.Execute(sql, new {parking.Plaats_ID, parking.Naam, parking.ID});
        }

        public void DeleteParking(Parking parking)
        {
            string sql = "Delete Parking where ID = @ID";

            db.Execute(sql, new {parking.ID});
        }

        public void InsertParking(Parking parking)
        {
            string sql = "Insert Parking(Naam, Plaats_ID) values(@Naam, @Plaats_ID)";

            db.Execute(sql, new {parking.Naam, parking.Plaats_ID});
        }
    }
}
