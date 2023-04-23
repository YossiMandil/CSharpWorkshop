using Microsoft.AspNetCore.Mvc;

namespace HashCodeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HashCodeController : ControllerBase
    {
        private readonly ILogger<HashCodeController> _logger;

        public HashCodeController(ILogger<HashCodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/fast")]
        public Task<int> Fast([FromHeader] object input, CancellationToken cancellationToken)
        {
            return Task.FromResult(input.GetHashCode());
        }

        [HttpGet("/medium")]
        public async Task<int> Medium([FromHeader] object input, CancellationToken cancellationToken)
        {
            await Task.Delay(100, cancellationToken);
            return input.GetHashCode();
        }

        [HttpGet("/slow")]
        public async Task<int> Slow([FromHeader] object input, [FromHeader] int seed, CancellationToken cancellationToken)
        {
            var timeToSleep = seed < 0 ? 3000 : new Random(seed).Next(3000, 7000);
            await Task.Delay(timeToSleep, cancellationToken);
            return input.GetHashCode();
        }
    }
}