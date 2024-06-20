using Domain.Models;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using Application.Interfaces;

namespace Application.MessageBroker.Messages;

public class ExerciseCreatedMessage
{
    private readonly IMessageBrokerConnection _messageBrokerConnection;

    public ExerciseCreatedMessage(IMessageBrokerConnection messageBrokerConnection)
    {
        _messageBrokerConnection = messageBrokerConnection;
    }

    public void SendMessage(Exercise exercise)
    {
        using var connection = _messageBrokerConnection.CreateConnection();
        using var channel = _messageBrokerConnection.CreateChannel(connection);

        channel.ExchangeDeclare("ExerciseCreated", ExchangeType.Fanout);
        string message = JsonSerializer.Serialize(exercise);
        var encodedMessage = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish("ExerciseCreated", "", null, encodedMessage);
        Console.WriteLine($"Message sent: {message}");
    }
}
