using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Data.SqlClient;
using System.Text;

var connectionFactory = new ConnectionFactory()
{
    Endpoint = new AmqpTcpEndpoint("localhost", 5672),
    UserName = "user",
    Password = "bitnami"
};

using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare("plane-queue", true, false, false, null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, e) =>
{
    var body = e.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine(message);
    SendToDb(message);
    Console.WriteLine("Send to db!");
};

channel.BasicConsume("plane-queue", true, consumer);
Console.ReadLine();

void SendToDb(string plane)
{
    const string connectionString = @"Server=localhost,51433;Database=PlaneDb;User Id=sa;Password=yourStrong(!)Password;Trusted_Connection=false;TrustServerCertificate=True";
    var cmdText = @$"INSERT INTO Planes VALUES('{Guid.NewGuid()}', '{plane}');";
    using var sqlConnection = new SqlConnection(connectionString);
    var command = new SqlCommand(cmdText, sqlConnection);
    command.Connection.Open();
    command.ExecuteNonQuery();
}
