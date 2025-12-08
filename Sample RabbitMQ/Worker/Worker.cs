using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = await factory.CreateConnectionAsync();
using var chanel = await connection.CreateChannelAsync();

await chanel.QueueDeclareAsync(
    queue: "newQueue",
    durable: true,
    exclusive: false,
    autoDelete: false,
    arguments: null
    );

// Fair dispatch: aiuta che nessun lavoratore sia sovraccaricato di lavoro, perche un lavoratore non ricevera un nuovo messaggio finche non avra processato e fatto l'ack di quello corrente.
await chanel.BasicQosAsync(prefetchSize: 0, prefetchCount: 1, global: false);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new AsyncEventingBasicConsumer(chanel);
consumer.ReceivedAsync += async (model, ea) =>
{
    byte[] body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received {message}");

    int dots = message.Split('.').Length - 1;
    await Task.Delay(dots * 1000);

    Console.WriteLine(" [x] Done");

    // here channel could also be accessed as ((AsyncEventingBasicConsumer)sender).Channel
    await chanel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
};

await chanel.BasicConsumeAsync(queue: "newQueue", autoAck: false, consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();