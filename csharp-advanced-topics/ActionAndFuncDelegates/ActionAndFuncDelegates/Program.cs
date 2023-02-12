using ActionAndFuncDelegates;

var funcsDemo = new FuncsDemo(SentenceHolder.Sentence);
funcsDemo.WordsLengths();
funcsDemo.WordsLetterLocations('a');
funcsDemo.WordsHashCodes();

var actionDemo = new ActionsDemo(SentenceHolder.Sentence);
actionDemo.WordsLengths();
actionDemo.WordsLetterLocations('a');
actionDemo.WordsHashCodes();