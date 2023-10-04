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

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var result = await _prescriptionService.GetPrescriptionsByUser(userId);

            return Ok(result);
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
