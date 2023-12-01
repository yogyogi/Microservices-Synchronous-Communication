using Microsoft.AspNetCore.Mvc;
using ProcessCenter.Client;
using ProcessCenter.Entity;
using ProcessCenter.Infrastructure;
using static ProcessCenter.Infrastructure.Dtos;

namespace ProcessCenter.Controllers
{
    [ApiController]
    [Route("process")]
    public class ProcessController : ControllerBase
    {
        private readonly IRepository<Process> repository;
        private readonly OrderClient orderClient;
        public ProcessController(IRepository<Process> repository, OrderClient orderClient)
        {
            this.repository = repository;
            this.orderClient = orderClient;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcessDto>>> GetAsync(Guid droneId)
        {
            if (droneId == Guid.Empty)
            {
                return BadRequest();
            }

            var orders = await orderClient.GetOrderAsync();
            var processEntities = await repository.GetAllAsync(a => a.DroneId == droneId);

            var commonEntities = processEntities.Join(orders, a => a.OrderId, b => b.Id, (a, b) => new { OrderId = b.Id, b.Address, b.Quantity, ProcessId = a.Id, a.DroneId, a.Status, a.AcquiredDate });

            List<ProcessDto> processDtoList = new List<ProcessDto>();

            foreach (var ce in commonEntities)
            {
                Process p = new Process();
                p.Id = ce.ProcessId; p.DroneId = ce.DroneId; p.OrderId = ce.OrderId; p.Status = ce.Status; p.AcquiredDate = ce.AcquiredDate;
                processDtoList.Add(p.AsDto(ce.Address, ce.Quantity));
            }

            return Ok(processDtoList);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(GrantOrderDto grantOrderDto)
        {
            var process = await repository.GetAsync(a => a.DroneId == grantOrderDto.DroneId && a.OrderId == grantOrderDto.OrderId);
            if (process == null)
            {
                process = new Process
                {
                    DroneId = grantOrderDto.DroneId,
                    OrderId = grantOrderDto.OrderId,
                    Status = grantOrderDto.Status,
                    AcquiredDate = DateTimeOffset.UtcNow
                };

                await repository.CreateAsync(process);
            }
            else
            {
                process.Status = grantOrderDto.Status;
                await repository.UpdateAsync(process);
            }
            return Ok();
        }
    }
}
