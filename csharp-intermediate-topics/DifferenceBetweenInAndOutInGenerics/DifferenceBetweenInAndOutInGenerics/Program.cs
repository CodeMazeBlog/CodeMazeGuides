using DifferenceBetweenInAndOutInGenerics.Consumers;
using DifferenceBetweenInAndOutInGenerics.Messages;
using DifferenceBetweenInAndOutInGenerics.Producers;

IProducer<BaseMessage> producer = new Producer<SubMessage>();

var message = producer.Produce();

IConsumer<SubMessage> consumer = new Consumer<BaseMessage>();

var subMessage = new SubMessage();
consumer.Consume(subMessage);
