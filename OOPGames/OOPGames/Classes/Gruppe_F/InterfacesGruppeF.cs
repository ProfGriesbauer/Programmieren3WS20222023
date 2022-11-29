using System;

namespace OOPGames
{
    public interface ITimeStamp
    {
        DateTime? LastUpdated { get; set; }
    }

    public interface IFieldSum
    {
        int? checkFieldSum { get;  }
    }
    public interface IFTicTacToeField : ITicTacToeField
    {
        int CurrentWinner { get;  set; }
    }
}
