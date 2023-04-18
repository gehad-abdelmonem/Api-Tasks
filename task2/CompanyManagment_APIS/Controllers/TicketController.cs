using CompanyManagement.BL.Dtos.Tickets;
using CompanyManagement.BL.Managers.Tickets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagment_APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        public ITicketsManager ticketManager;
        public TicketController(ITicketsManager _ticketManager)
        {
            ticketManager = _ticketManager;
        }
        //Get All
        [HttpGet]
        public ActionResult<List<TicketsReadDtos>> GetAll()
        {
            List<TicketsReadDtos> Tickets = ticketManager.GetAll();
            if (Tickets == null)
            {
                return NotFound();
            }
            return Tickets;
        }
        //Get By Id
        [HttpGet]
        [Route("{id}")]
        public ActionResult <TicketsReadDtos> GetById(int id)
        {
            TicketsReadDtos ticket= ticketManager.GetById(id);
            if(ticket==null)
            {
                return NotFound();
            }
            return ticket;
        }
        //delete
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
           bool result= ticketManager.Delete(id);
            if(result==false)
            {
                return NotFound();
            }
            return Ok("Element Deleted Successfully");
        }
        [HttpPost]
        public ActionResult Add(TicketAddDeto ticket)
        {
            ticketManager.Add(ticket);
            return Ok("Entity Has Been Added Successfully");
        }
        
    }
}
