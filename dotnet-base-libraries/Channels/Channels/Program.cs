// See https://aka.ms/new-console-template for more information
using System.Threading.Channels;

var unboundedChannel = Channel.CreateUnbounded<string>();
var boundedChannel = Channel.CreateBounded<string>(new BoundedChannelOptions(1)
{
    FullMode = BoundedChannelFullMode.Wait
});

var producer = new Producer(boundedChannel.Writer);
var consumer = new Consumer(boundedChannel.Reader);

_ = Task.Factory.StartNew(async () =>
{
    await producer.ProduceWorkAsync();
});


await consumer.ConsumeWorkAsync();