var messageBus = new OrderMessageBus();

var producer1 = new Producer(messageBus, 10);
var producer2 = new Producer(messageBus, 10);
var producer3 = new Producer(messageBus, 10);

var cancellation = new CancellationTokenSource();

var consumer1 = new Consumer(messageBus);
var consumer2 = new Consumer(messageBus);
var consumer3 = new Consumer(messageBus);

var consumers = Task.WhenAll(
    consumer1.Process(cancellation.Token),
    consumer2.Process(cancellation.Token),
    consumer3.Process(cancellation.Token));

await Task.WhenAll(producer1.Produce(), producer2.Produce(), producer3.Produce());

while (messageBus.Count > 0)
{
    await Task.Delay(50);
}

await cancellation.CancelAsync();
await consumers;
