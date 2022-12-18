using System;

namespace OOPGames
{
    public interface ITimeStamp
    {
        DateTime? LastUpdated { get; set; }
    }

    public interface IFieldSum
    {
        int? CheckFieldSum();
    }
    public interface IFTicTacToeField : ITicTacToeField
    {
        int CurrentWinner { get;  set; }
        int Thickness { get; set; }

    }
    
    public interface IGameRulesF : IGameRules2
    {
       void TickGameCall(IGamePlayer currentPlayer);
       int Thickness { get; set; }
    }

    public interface IComputerPlayerTTTF
    {

    }
}
