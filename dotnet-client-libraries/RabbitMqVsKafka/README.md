# RabbitMQ vs Kafka for .NET Developers

The sample for the Code Maze article [RabbitMQ vs Kafka for .NET Developers](https://code-maze.com/rabbitmq-vs-kafka-dotnet/).

## Run the demos

Start both brokers from this folder (Docker required):

```bash
docker compose up -d
```

Then run one demo at a time from the same folder:

```bash
dotnet run --project RabbitMqVsKafka -- rabbit
dotnet run --project RabbitMqVsKafka -- kafka
dotnet run --project RabbitMqVsKafka -- stream
```

The demos leave messages, topics and committed offsets behind, so reset both brokers before you run a demo a second time:

```bash
docker compose down -v
docker compose up -d
```

## Run the tests

The tests start their own brokers with Testcontainers, so they need Docker but not the Compose file:

```bash
dotnet test
```
