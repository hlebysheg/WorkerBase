using Microsoft.AspNetCore.Mvc;
using WorkerBase.Helpers;
using WorkerBase.models;
using WorkerBase.repository;
using WorkerBase.Validators;

namespace WorkerBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly ILogger<WorkerController> _logger;
        private _workerRep db;
        private IConfiguration _conf;
        public WorkerController(ApplicationContext context, IConfiguration config, ILogger<WorkerController>? log)
        {

            db = new _workerRep(context);
            _conf = config;
            _logger = log;
        }

        [HttpPost]
        [Route("create/worker")]
        public IActionResult CreateWorker([FromBody] WorkerToCreate worker)
        {
            if (WorkerValidator.isWorkerCorrect(worker))
            {
                return BadRequest("incorrect worker date");
            }

            Worker? response = db.create(worker);

            return Ok(response);
        }

        [HttpGet]
        [Route("get/workers")]
        public IActionResult getAll()
        {
            List<Worker>? response = db.getAll();

            return Ok(response);
        }

        [HttpPut]
        [Route("put/worker")]
        public IActionResult put(Worker wr)
        {
            if (WorkerValidator.isWorkerCorrect(wr))
            {
                return BadRequest("incorrect worker date");
            }

            Worker? response = db.update(wr);

            return Ok(response);
        }

        [HttpDelete]
        [Route("del/worker/{id}")]
        public IActionResult del(int id)
        {
            bool? isDel = db.delete(id);

            return Ok(isDel);
        }
    }
}