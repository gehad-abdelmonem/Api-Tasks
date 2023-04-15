using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task1.filters;
using task1.models;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public ILogger<CarController> logger;
        public CarController(ILogger<CarController> _logger)
        {
            logger= _logger;
        }
        public static List<Car> Cars = new List<Car>();


        // Add new entity->Post:api/car/v1
        [HttpPost]
        [Route("v1")]
        public ActionResult Add_v1(Car newCar)
        {
            newCar.id = Cars.Count + 1;
            newCar.type = "Gas";
            Cars.Add(newCar);
            logger.LogCritical("Add");
            return CreatedAtAction(
                actionName: nameof(GetById), routeValues: new { id = newCar.id },
                new GeneralResponse {Message= "Entity Has Been Add successfully" }
                );
        }
        // Add new entity->Post:api/car/v2
        [HttpPost]
        [Route("v2")]
        [ValidType]
        public ActionResult Add_v2(Car newCar)
        {
            newCar.id = Cars.Count + 1;
            Cars.Add(newCar);
            return CreatedAtAction(
                actionName: nameof(GetById), routeValues: new { id = newCar.id },
                new GeneralResponse { Message = "Entity Has Been Add successfully" }
                );
        }


        //Get All ->Get:api/car
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(Cars);
        }

        //Get By Id->Get:api/car/{id}
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id) 
        { 
            Car? selectedCar=Cars.FirstOrDefault(x => x.id==id);
            if(selectedCar!=null)
            {
                return Ok(selectedCar);
            }
            return NotFound();
        }

        //update->Put:api/car/id
        [HttpPut]
        [Route("{id}")]
        public ActionResult Put(Car carFromRequestBody,int id) 
        { 
            if(carFromRequestBody.id!=id) 
            { 
                return BadRequest();
            }
            Car? selectedCar=Cars.FirstOrDefault(x=>x.id==id);
            if(selectedCar!=null) 
            {
                selectedCar.name=carFromRequestBody.name;
                selectedCar.productionDate=carFromRequestBody.productionDate;
                return Ok(new GeneralResponse { Message = "successfully Updated" });
            }
            return NotFound();
        }

        //Delete-> Delete:api/car/{id}
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            Car? selectedCar=Cars.FirstOrDefault(x => x.id==id);
            if (selectedCar!=null)
            {
                Cars.Remove(selectedCar);
                return Ok(new GeneralResponse { Message= $"successfully deleted-->count:{Program.count}" });
            }
            return NotFound();
        }
        ////Get Count Of Requestes
        [HttpGet]
        [Route("c")]
        public ActionResult GetCount()
        {
            return Ok(new GeneralResponse { Message = $"count: {Program.count}" });
        }


    }
}
