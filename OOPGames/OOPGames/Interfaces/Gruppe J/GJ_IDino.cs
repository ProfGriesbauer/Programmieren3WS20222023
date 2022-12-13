using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOPGames.Interfaces.Gruppe_J
{
    public abstract class GJ_IDinoGamePlayer : IHumanGamePlayer
    {
        public abstract string Name { get; }
        public abstract int PlayerNumber { get; set; }

        public abstract bool CanBeRuledBy(IGameRules rules);
        public abstract IGamePlayer Clone();

        public abstract GJ_DinoPlayMove GetMove(IMoveSelection selection, GJ_IDinoGameField field);

        public IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            return GetMove(selection, (GJ_IDinoGameField) field);
        }

        public abstract void SetPlayerNumber(int playerNumber);
    }

    public abstract class GJ_IDinoGameRules : IGameRules2
    {
        public abstract string Name { get; }
        public abstract IGameField CurrentField { get; }
        public abstract bool MovesPossible { get; }

        public abstract bool jumping { get; set; }


        public abstract int jumpSpeed { get; set; }

        public abstract int force { get; set; }

        public abstract int gameScore{ get; set; }


        public abstract int ObstacleSpeed { get; set; }

        public abstract int dinoYPosition { get; set; }

        public abstract int scoreNumber { get; set; }

        public abstract int CheckIfPLayerWon();
        public abstract void ClearField();
        public abstract void DoMove(GJ_DinoPlayMove move);

        public abstract void Jump();
        
        public void DoMove(IPlayMove move)
        {
            if (move is GJ_DinoPlayMove)
            {
                DoMove((GJ_DinoPlayMove) move);
            }
        }

        public abstract void StartedGameCall();
        public abstract void TickGameCall();
    }

    public interface GJ_IDinoGameField : IGameField
    {

        List<Obstacle> obstacles { get; set;  }

        int DinoYPos { get; set; }
        int DinoXPos { get; set; }
    }

    public abstract class GJ_IDinoPaintGame : IPaintGame2
    {
        public abstract string Name { get; }


        public abstract void PaintDinoGameField(Canvas canvas, GJ_IDinoGameField currentField);

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is GJ_IDinoGameField)
            {
                PaintDinoGameField(canvas, (GJ_IDinoGameField) currentField);
            }
        }


        public  void TickPaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is GJ_IDinoGameField)
            {
                PaintDinoGameField(canvas, (GJ_IDinoGameField) currentField);
            }
        }


    }

    public interface GJ_IDinoPlayMove : IPlayMove
    {
        
    }
}
