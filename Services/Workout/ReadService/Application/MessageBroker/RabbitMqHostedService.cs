using Microsoft.Extensions.Hosting;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text.Json;
using Domain.Models;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.MessageBroker;

public class RabbitMqHostedService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private IConnection? _connection;
    private IModel? _channel;

    public RabbitMqHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        var factory = new ConnectionFactory
        {
            HostName = "rabbitmq",
            Port = 5672
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.ExchangeDeclare("WorkoutCreated", ExchangeType.Fanout);
        _channel.ExchangeDeclare("ExerciseCreated", ExchangeType.Fanout);
        var queueNameWorkout = _channel.QueueDeclare().QueueName;
        var queueNameExercise = _channel.QueueDeclare().QueueName;
        _channel.QueueBind(queueNameWorkout, "WorkoutCreated", "");
        _channel.QueueBind(queueNameExercise, "ExerciseCreated", "");

        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += async (model, ea) =>
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var workoutRepository = scope.ServiceProvider.GetRequiredService<IWorkoutRepository>();
                var exerciseRepository = scope.ServiceProvider.GetRequiredService<IExerciseRepository>();
                Console.WriteLine(ea.Exchange);
                var message = ea.Body.ToArray();
                switch (ea.Exchange)
                {
                    case "WorkoutCreated":
                        var createdWorkout = JsonSerializer.Deserialize<Workout>(message);
                        if (createdWorkout != null)
                            await workoutRepository.CreateWorkout(createdWorkout, cancellationToken);
                        else
                            Console.WriteLine("Message received, but workout was null.");
                        
                        break;
                    case "WoroutDeleted":
                        var deletedWorkout = JsonSerializer.Deserialize<Workout>(message);
                        if (deletedWorkout != null)
                            await workoutRepository.DeleteWorkout(deletedWorkout.Id, cancellationToken);
                        else
                            Console.WriteLine("Message received, but workout was null.");
                        break;
                    case "ExerciseCreated":
                        var createdExercise = JsonSerializer.Deserialize<Exercise>(message);
                        if (createdExercise != null)
                            await exerciseRepository.CreateExercise(createdExercise, cancellationToken);
                        else
                            Console.WriteLine("Message received, but exercise was null.");

                        break;
                }
            }
        };

        _channel.BasicConsume(queueNameWorkout, true, consumer);
        _channel.BasicConsume(queueNameExercise, true, consumer);

        Console.WriteLine("Consuming messages...");
        return Task.CompletedTask;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Keep the task alive
        var tcs = new TaskCompletionSource();
        stoppingToken.Register(() => tcs.SetResult());
        return tcs.Task;
    }
}
