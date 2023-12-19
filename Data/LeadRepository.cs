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

        public LeadsEntity GetLeadById(int Id)
        {
            LeadsEntity leadsEntities = new LeadsEntity();

            SqlCommand cmd = new SqlCommand("GetLeadDetailsById", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param;
            cmd.Parameters.Add(new SqlParameter("@Id", Id));

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                leadsEntities = new LeadsEntity
                {
                    Id = Convert.ToInt32(dr["id"]),
                    LeadDate = Convert.ToDateTime(dr["LeadDate"]),
                    Name = dr["name"].ToString(),
                    EmailAddress = dr["EmailAddress"].ToString(),
                    Mobile = dr["Mobile"].ToString(),
                    LeadSource = dr["LeadSource"].ToString(),
                    LeadStatus = dr["LeadStatus"].ToString(),
                    NextFollowUpDate = Convert.ToDateTime(dr["NextFollowUpDate"]),

                };
            }

            return leadsEntities;


        }

        public bool AddLead(LeadsEntity leads)
         {
            SqlCommand cmd = new SqlCommand("AddLead",_connection);
            cmd.CommandType= System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LeadDate", leads.LeadDate);
            cmd.Parameters.AddWithValue("@Name", leads.Name);
            cmd.Parameters.AddWithValue("@EmailAddress", leads.EmailAddress);
            cmd.Parameters.AddWithValue("@Mobile", leads.Mobile);
            cmd.Parameters.AddWithValue("@LeadSource", leads.LeadSource);
            cmd.Parameters.AddWithValue("@LeadStatus", leads.LeadStatus);
            cmd.Parameters.AddWithValue("@NextFollowUpDate", leads.NextFollowUpDate);

            _connection.Open();

            int i = cmd.ExecuteNonQuery(); 
            _connection.Close();

            if (i >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public bool EditLeadDetails(int Id , LeadsEntity leads)
        {
            SqlCommand cmd = new SqlCommand("EditLead", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue ("@Id", leads.Id);
            cmd.Parameters.AddWithValue("@LeadDate", leads.LeadDate);
            cmd.Parameters.AddWithValue("@Name", leads.Name);
            cmd.Parameters.AddWithValue("@EmailAddress", leads.EmailAddress);
            cmd.Parameters.AddWithValue("@Mobile", leads.Mobile);
            cmd.Parameters.AddWithValue("@LeadSource", leads.LeadSource);
            cmd.Parameters.AddWithValue("@LeadStatus", leads.LeadStatus);
            cmd.Parameters.AddWithValue("@NextFollowUpDate", leads.NextFollowUpDate);

            _connection.Open();

            int i = cmd.ExecuteNonQuery();
            _connection.Close();

            if (i >= 1)
            {
                return true;
            }
            else { return false; }
        }


        public bool DeleteLeadDetails(int Id, LeadsEntity leads)
        {
            SqlCommand cmd = new SqlCommand("DeleteLeadDetails", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", leads.Id);
           

            _connection.Open();

            int i = cmd.ExecuteNonQuery();
            _connection.Close();

            if (i >= 1)
            {
                return true;
            }
            else { return false; }
        }
    }
}
