namespace CRMLeads.Models
{
    public class LeadsEntity
    {
        public int Id { get; set; }

        public DateTime LeadDate { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Mobile {  get; set; } 

        public string LeadSource { get; set; }

          
    }
}
