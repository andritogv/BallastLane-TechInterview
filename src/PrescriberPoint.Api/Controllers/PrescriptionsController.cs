using Microsoft.AspNetCore.Mvc;
using PrescriberPoint.Api.Contract;
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
        public async Task<IActionResult> Post([FromBody] CreatePrescriptionRequest prescription)
        {
            //ToDo: UserId should come from authentication
            var userId = 2002;

            var newPrescription = new Prescription
            {
                UserId = userId,
                Name = prescription.Name,
                Description = prescription.Description
            };

            if (await _prescriptionService.AddPrescription(newPrescription))
            {
                return Ok("Prescription successfully created.");
            }
            else
            {
                return BadRequest("Prescription could not be created.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePrescriptionRequest prescription)
        {
            //ToDo: UserId should come from authentication
            var userId = 2002;

            var updatedPrescription = new Prescription
            {
                Id = prescription.Id,
                UserId = userId,
                Name = prescription.Name,
                Description = prescription.Description
            };

            if (await _prescriptionService.UpdatePrescription(updatedPrescription))
            {
                return Ok("Prescription successfully updated.");
            }
            else
            {
                return BadRequest("Prescription could not be updated.");
            }

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
