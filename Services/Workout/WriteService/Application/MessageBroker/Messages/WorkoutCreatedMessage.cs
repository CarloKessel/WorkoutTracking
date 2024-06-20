using System.Text;
using System.Text.Json;
using Application.Interfaces;
using Domain.Models;
using RabbitMQ.Client;

namespace Application.MessageBroker.Messages;

public class WorkoutCreatedMessage
{
    private readonly IMessageBrokerConnection _messageBrokerConnection;

    public WorkoutCreatedMessage(IMessageBrokerConnection messageBrokerConnection)
    {
        _messageBrokerConnection = messageBrokerConnection;
    }

    public void SendMessage(Workout workout)
    {
        using var connection = _messageBrokerConnection.CreateConnection();
        using var channel = _messageBrokerConnection.CreateChannel(connection);

        channel.ExchangeDeclare("WorkoutCreated", ExchangeType.Fanout);
        string message = JsonSerializer.Serialize(workout);
        var encodedMessage = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish("WorkoutCreated", "", null, encodedMessage);
        Console.WriteLine($"Message sent: {message}");
    }
}
