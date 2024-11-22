namespace TicTacToeApp;

public class Board
{
    public Board()
    {
        BoardState = new char[9];
        Array.Fill(BoardState, ' ');
    }

    public char[] BoardState { get; }

    public override string ToString()
    {
        var printable = BoardState.Select((v, i) => v == ' ' ? (i + 1).ToString()[0] : v).ToList();
        var currentBoard = $"""
                            _{printable[0]}_|_{printable[1]}_|_{printable[2]}_
                            _{printable[3]}_|_{printable[4]}_|_{printable[5]}_
                             {printable[6]} | {printable[7]} | {printable[8]} 
                            """;
        return currentBoard;
    }
}