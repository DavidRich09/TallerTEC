using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Data_base;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {

        private JsonManager jsonManager = new JsonManager();

        [HttpGet]
        [Route("requestWorker")]
        public dynamic RequesteWorker()
        {
            return new
            {
                id = "1",
                correo = "google@gmail.com",
                edad = "19"
            };
        }


        [HttpPost]
        [Route("saveWorker")]
        public dynamic SaveWorker(Worker worker)
        {
            worker.idNumber = 5;

            jsonManager.SaveWorker (worker);

            return new
            {
                success = true,
                message = "worker saved",
                result = worker
            };
        }


    }
}
