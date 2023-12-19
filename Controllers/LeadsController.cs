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

        public IActionResult EditLead(int Id)
        {
            LeadsEntity leads = new LeadsEntity();

            LeadRepository leadRepository = new LeadRepository();

            leads = leadRepository.GetLeadById(Id);

            return View(leads);
        }   

        public IActionResult EditLeadDetails(int Id , LeadsEntity leadDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LeadRepository _DbLead = new LeadRepository();
                    if (_DbLead.EditLeadDetails(Id , leadDetails))
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AddLead()
        {
            return View();
        }

        public ActionResult DeleteLead(int Id)
        {
            LeadsEntity leads = new LeadsEntity();

            LeadRepository leadRepository = new LeadRepository();

            leads = leadRepository.GetLeadById(Id);

            return View(leads); 

        }

        public IActionResult DeleteLeadDetails(int Id, LeadsEntity leadDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LeadRepository _DbLead = new LeadRepository();
                    if (_DbLead.DeleteLeadDetails(Id, leadDetails))
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        public ActionResult AddNewLead(LeadsEntity LeadDetails)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    LeadRepository _DbLead = new LeadRepository();
                    if(_DbLead.AddLead(LeadDetails))
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
