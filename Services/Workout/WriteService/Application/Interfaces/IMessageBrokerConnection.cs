using RabbitMQ.Client;

namespace Application.Interfaces;

public interface IMessageBrokerConnection
{
    IConnection CreateConnection();
    IModel CreateChannel(IConnection connection);
}