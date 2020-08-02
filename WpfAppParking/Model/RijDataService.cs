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
using WpfAppParking.Extensions;
using System.Collections.ObjectModel;

namespace WpfAppParking.Model
{
    class RijDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["local"].ConnectionString;
        //instellen connectie
        private static IDbConnection db = new SqlConnection(connectionString);

        public ObservableCollection<Rij> GetRijs()
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Rij";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen
            ObservableCollection<Rij> rijs = db.Query<Rij>(sql).ToObservableCollection();

            return rijs;
        }
        

        public void UpdateRij(Rij rij)
        {
            // SQL statement update 
            string sql = "Update Rij set Totale_plaatsen = @Totale_plaatsen, Bezette_plaatsen = @Bezette_plaatsen, Volzet=@Volzet where ID = @ID";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { rij.Totale_plaatsen, rij.Bezette_plaatsen, rij.Volzet, rij.ID});
        }

        public void DeleteRij(Rij rij)
        {
            // SQL statement delete 
            string sql = "Delete Rij where ID = @ID";
            string sqlPlaats = "Delete Plaats where Rij_Id = @ID";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sqlPlaats, new { rij.ID });
            db.Execute(sql, new { rij.ID });
        }

        public void InsertRij(Rij rij)
        {
            // SQL statement delete 
            string sql = "Insert Rij(Totale_plaatsen,Bezette_plaatsen,Volzet, Parking_ID) values(@Totale_plaatsen,@Bezette_plaatsen,@Volzet, @ParkingID)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { rij.Totale_plaatsen, rij.Bezette_plaatsen, rij.Volzet, rij.ParkingID });
        }
    }
}
