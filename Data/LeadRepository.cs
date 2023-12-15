using CRMLeads.Models;
using System.Data;
using System.Data.SqlClient;
namespace CRMLeads.Data
{
    public class LeadRepository
    {
        private SqlConnection _connection;

        public LeadRepository() 
        {
            string connstr = "server=acceptagreement.com ; database=testDB_Jigar ; User Id=sa;Password=Fall1130836!";


                _connection = new SqlConnection(connstr);

        }
        public List<LeadsEntity> GetAllLeads()
        {
            List<LeadsEntity> leadsEntities = new List<LeadsEntity>();

            SqlCommand cmd = new SqlCommand("GetAllLeads", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                leadsEntities.Add(new LeadsEntity()
                {
                    Id = Convert.ToInt32(dr["id"]),
                    LeadDate = Convert.ToDateTime(dr["LeadDate"]),
                    Name = dr["name"].ToString(),
                    EmailAddress = dr["EmailAddress"].ToString(),
                    Mobile= dr["Mobile"].ToString(),
                    LeadSource= dr["LeadSource"].ToString(),
                    LeadStatus= dr["LeadStatus"].ToString(),
                    NextFollowUpDate = Convert.ToDateTime(dr["NextFollowUpDate"]),

                });
            }

            return leadsEntities;


        }
    }
}
