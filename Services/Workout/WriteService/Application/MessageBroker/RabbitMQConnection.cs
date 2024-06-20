using Application.Interfaces;
using RabbitMQ.Client;

namespace Application.MessageBroker;

public class RabbitMQConnection : IMessageBrokerConnection
{
    private readonly ConnectionFactory _factory;

    public RabbitMQConnection()
    {
        _factory = new ConnectionFactory
        {
            HostName = "rabbitmq",
            Port = 5672
        };
    }

    public IConnection CreateConnection()
    {
        return _factory.CreateConnection();
    }

    public IModel CreateChannel(IConnection connection)
    {
        return connection.CreateModel();
    }
}
