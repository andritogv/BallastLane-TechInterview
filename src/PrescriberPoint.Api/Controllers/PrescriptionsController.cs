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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //ToDo: UserId should come from authentication
            var userId = 2002;

            var result = await _prescriptionService.GetPrescriptionsByUser(userId);

            return Ok(result);
        }

        [HttpGet("{prescriptionId}")]
        public async Task<IActionResult> Get(int prescriptionId)
        {
            var result = await _prescriptionService.GetPrescription(prescriptionId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePrescriptionRequest request)
        {
            //ToDo: UserId should come from authentication
            var userId = 2002;

            var newPrescription = new Prescription
            {
                UserId = userId,
                Name = request.Name,
                Description = request.Description
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
        public async Task<IActionResult> Put([FromBody] UpdatePrescriptionRequest request)
        {
            //ToDo: UserId should come from authentication
            var userId = 2002;

            var updatedPrescription = new Prescription
            {
                Id = request.Id,
                UserId = userId,
                Name = request.Name,
                Description = request.Description
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

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletePrescriptionRequest request)
        {
            if (await _prescriptionService.DeletePrescription(request.Id))
            {
                return Ok("Prescription successfully deleted.");
            }
            else
            {
                return BadRequest("Prescription could not be deleted.");
            }
        }
    }
}
