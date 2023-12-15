using CRMLeads.Data;
using CRMLeads.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRMLeads.Controllers
{
    public class LeadsController : Controller
    {
        public IActionResult Index()
        {
            List<LeadsEntity> leads = new List<LeadsEntity>();

            LeadRepository leadRepository = new LeadRepository();

            leads=leadRepository.GetAllLeads();

            return View(leads);
        }
    }
}
