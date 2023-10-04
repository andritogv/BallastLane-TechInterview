using Microsoft.AspNetCore.Mvc;
using PrescriberPoint.Business.Prescriptions;
using PrescriberPoint.Domain;

namespace PrescriberPoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userId = 1;
            // userId should come from authenticated user

            var prescriptions = _prescriptionService.GetPrescriptionsByUser(userId);

            return Ok(prescriptions);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] Prescription prescription)
        {
        }

        [HttpPut]
        public void Put(int id, [FromBody] Prescription prescription)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
