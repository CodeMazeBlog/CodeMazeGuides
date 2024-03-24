using DifferenceBetweenInAndOutInGenerics.Consumers;
using DifferenceBetweenInAndOutInGenerics.MessageEditor;
using DifferenceBetweenInAndOutInGenerics.Messages;
using DifferenceBetweenInAndOutInGenerics.Producers;

// Invariance
var message = new SubMessage();

IMessageEdditor<SubMessage> messageEditor = new MessageEdditor<SubMessage>();

var editedCopy = messageEditor.EditAndCopyOriginalMessage(message);

//IMessageEdditor<BaseMessage> messageEditor2 = new MessageEdditor<SubMessage>(); // won't compile
//IMessageEdditor<SubMessage> messageEditor3 = new MessageEdditor<BaseMessage>(); // won't compile

// Covariance
IProducer<BaseMessage> producer = new Producer<SubMessage>();
var producedCovariantMessage = producer.Produce();

// Contravariance
var subMessage = new SubMessage();
IConsumer<SubMessage> consumer = new Consumer<BaseMessage>();
consumer.Consume(subMessage);