namespace TicTacToeApp;

public class GameManager
{
    private Board _board = new();
    private Player _playerX = new('X');
    private Player _playerO = new('O');
    private bool _isPlayerXNext = true;
    
    public bool MakeMoveAt(Player player, int i)
    {
        if (_board.BoardState[i] != ' ')
            return false;

        _board.BoardState[i] = player.Symbol;
            
        return true;
    }

    public bool IsBoardFull()
    {
        return _board.BoardState.All(n => n != ' ');
    }

    public void PlayRound()
    {
        
    }

    public bool IsWinner(Player player)
    {
        var combinations = new int[,]
        {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 },
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 0, 4, 8 },
            { 2, 4, 6 }
        };

        for (var i = 0; i < combinations.GetLength(0); i++)
        {
            if (_board.BoardState[combinations[i, 0]] == player.Symbol &&
                _board.BoardState[combinations[i, 0]] == _board.BoardState[combinations[i, 1]] &&
                _board.BoardState[combinations[i, 0]] == _board.BoardState[combinations[i, 2]])
            {
                return true;
            }
        }

        return false;
    }

    public void Start()
    {
        UserInterface.AnnounceStart();
        _board = new Board();
        while (!IsBoardFull())
        {
            UserInterface.PrintBoard(_board);
            var currentPlayer = _isPlayerXNext ? _playerX : _playerO;
            bool legalMove;
            do
            {
                var move = UserInterface.GetMove(currentPlayer);
                legalMove = MakeMoveAt(currentPlayer, move);
                if (!legalMove)
                    UserInterface.AnnounceIllegalMove(currentPlayer);
            } while (!legalMove);
            
            if (IsWinner(currentPlayer))
            {
                UserInterface.AnnounceWinner(currentPlayer);
                break;
            }
            _isPlayerXNext = !_isPlayerXNext;
        }

        UserInterface.PrintBoard(_board);
        UserInterface.DisplayEndGame();
    }
}