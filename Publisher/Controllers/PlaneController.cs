using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Publisher.Controllers
{
    [ApiController]
    [Route("api/plane")]
    public class PlaneController : Controller
    {
        [HttpPost]
        public IActionResult PostPlane(Plane plane)
        {
            PublishToRabbitQueue(JsonConvert.SerializeObject(plane));
            return Ok();
        }

        private void PublishToRabbitQueue(string planeJson)
        {
            var factory = new ConnectionFactory() { Endpoint = new AmqpTcpEndpoint("localhost", 5672), UserName = "user", Password = "bitnami" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("plane-queue", true, false, false, null);

            var body = Encoding.UTF8.GetBytes(planeJson);

            channel.BasicPublish(string.Empty, "plane-queue", null, body);
        }
    }
}
