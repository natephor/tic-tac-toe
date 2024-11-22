namespace TicTacToeApp;

public static class UserInterface
{
    public static int GetMove(Player player)
    {
        int move;
        string? input;
        do
        {
            Console.Write($"Player {player.Symbol} make your move: ");
            input = Console.ReadLine();
        } while (!int.TryParse(input, out move) && move is < 1 or > 9);

        return move - 1;
    }

    public static void AnnounceIllegalMove(Player player)
    {
        Console.WriteLine($"Cannot complete this move. {player.Symbol} try again.");
    }

    public static void AnnounceWinner(Player player)
    {
        Console.WriteLine("\nDing ding ding! We have a winner!");
        Console.WriteLine($"Player {player.Symbol} wins! Congratulations!");
    }

    public static void DisplayEndGame()
    {
        Console.WriteLine("Thank you for playing.");
    }

    public static void PrintBoard(Board board)
    {
        Console.WriteLine($"\n{board}\n");
    }

    public static void AnnounceStart()
    {
        Console.WriteLine("Welcome to Tic-Tac-Toe!");
    }
}