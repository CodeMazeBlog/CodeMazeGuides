using IndexersInCSharp;

//Single Dimensional Map
var sentence = new Sentence("Hello from Code Maze");
for (int i = 0; i < sentence.Length; i++)
{
    Console.WriteLine("Word {0} : {1}", i + 1, sentence[i]);
}

//Multi-Dimensional Map
var ticTacToe = new TicTacToe();
ticTacToe[0,0] = CellStatus.X;
Console.WriteLine(ticTacToe.ToString());

ticTacToe[9] = CellStatus.O;
Console.WriteLine(ticTacToe.ToString());