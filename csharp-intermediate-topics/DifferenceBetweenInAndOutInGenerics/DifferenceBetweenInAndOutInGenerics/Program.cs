using DifferenceBetweenInAndOutInGenerics.Consumers;
using DifferenceBetweenInAndOutInGenerics.MessageEditor;
using DifferenceBetweenInAndOutInGenerics.Messages;
using DifferenceBetweenInAndOutInGenerics.Producers;

// Invariance (<T>)
var message = new SubMessage();

IMessageEditor<SubMessage> messageEditor = new MessageEditor<SubMessage>();

var editedCopy = messageEditor.EditAndCopyOriginalMessage(message);

//IMessageEditor<BaseMessage> messageEditor2 = new MessageEditor<SubMessage>(); // won't compile
//IMessageEditor<SubMessage> messageEditor3 = new MessageEditor<BaseMessage>(); // won't compile

// Covariance (<out T>)
IProducer<BaseMessage> producer = new Producer<SubMessage>();
var producedCovariantMessage = producer.Produce();

// Contravariance (<in T>)
var subMessage = new SubMessage();
IConsumer<SubMessage> consumer = new Consumer<BaseMessage>();
consumer.Consume(subMessage);