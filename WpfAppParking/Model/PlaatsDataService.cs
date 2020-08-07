using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using WpfAppParking.Extensions;

namespace WpfAppParking.Model
{
    class PlaatsDataService
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["local"].ConnectionString;
        
        private static IDbConnection db = new SqlConnection(connectionString);

        public ObservableCollection<Plaats> getPlaatsen()
        {
            string sql = "Select * from Plaats order by Naam";

            ObservableCollection<Plaats> plaatsen = db.Query<Plaats>(sql).ToObservableCollection();

            return plaatsen;
        }

        public void UpdatePlaats(Plaats plaats)
        {
            string sql = "Update Plaats set Naam = @Naam where ID = @ID";
            db.Execute(sql, new {plaats.Naam, plaats.ID});
        }

        public void DeletePlaats(Plaats plaats)
        {
            string sql = "Delete Plaats where ID = @ID";

            db.Execute(sql, new {plaats.ID});
        }

        public void InsertPlaats(Plaats plaats)
        {
            string sql = "Insert Plaats(Naam) values(@ID)";
            db.Execute(sql, new {plaats.Naam});
        }
    }
}