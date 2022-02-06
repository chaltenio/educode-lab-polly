using Microsoft.AspNetCore.Mvc;
using RequestService.Policies;

namespace RequestService.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public RequestController(ClientPolicy clientPolicy, IHttpClientFactory clientFactory)
        {   
            _clientFactory = clientFactory;
        }

        // GET api/request
        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {
            //var client = new HttpClient(); (replaced by _clientFactory)
            var client = _clientFactory.CreateClient("Test");

            var response = await client.GetAsync("http://localhost:5010/api/response/25");

            //var response = await _clientPolicy.ImmediateHttpRetry.ExecuteAsync(
            //var response = await _clientPolicy.LinearHttpRetry.ExecuteAsync(    
            //var response = await _clientPolicy.ExponentialHttpRetry.ExecuteAsync(
            //    () => client.GetAsync("http://localhost:5010/api/response/25"));

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> ResponseService returned SUCCESS!");
                return Ok();
            }

            Console.WriteLine("--> ResponseService returned FAILURE!");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}