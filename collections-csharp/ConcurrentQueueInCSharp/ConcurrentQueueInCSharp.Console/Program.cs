var messageBus = new OrderMessageBus();

var producer1 = new Producer(messageBus, 10);
var producer2 = new Producer(messageBus, 10);
var producer3 = new Producer(messageBus, 10);

var consumer1 = new Consumer(messageBus);
var consumer2 = new Consumer(messageBus);
var consumer3 = new Consumer(messageBus);
            
Task.WaitAll(
    producer1.Produce(), producer2.Produce(), producer3.Produce(), 
    consumer1.Process(), consumer2.Process(), consumer3.Process());