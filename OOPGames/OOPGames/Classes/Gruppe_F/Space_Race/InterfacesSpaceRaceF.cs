using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOPGames
{
    public interface ISpaceRacePainterF : IPaintGame2
    {
        void paintMeteor(Canvas canvas, int xPos, int yPos, int rad);

        void clearCanvas(Canvas canvas);

        void paintTimeBar(Canvas canvas, float gametimer, float barheight);

        void paintShip(Canvas canvas, int xPos, int yPos, int width, int height, bool hasShield);
        void paintShield(Canvas canvas, int xPos, int yPos, int rad);
    }

    public interface ISpaceRaceRulesF : IGameRules2
    {
        int getArrayValueX(int i);
        int getArrayValueY(int i);
        int getArrayValueRAD(int i);
    }


    public interface ISpaceRaceFieldF : IGameField
    {

    }

    public interface ISpaceRaceHumanPlayerF : IGamePlayer
    {
        int PlayerScore { get; set; }

        int xPos { get; set; }
        int yPos { get; set; }
        int width { get; set; }
        int height { get; set; }
        int ySpeed { get; set; }
        bool hasShield { get; set; } 


        void move();
        void update();
        void respawn();
        bool checkCollision(int xPosm, int yPosm, int radm);
    }

    public interface IMeteor
    {
        int xPos { get; set; }
        
        int yPos { get; set; }
        
        int xSpeed { get; set; }
        
        int rad { get; set; }

        void create(int xPos, int yPos, int xSpeed, int rad);
        void update();
        void move();
        void respawn();
    }

    public interface ITimeBar
    {
        float barlength { get; set; }
        float barheight { get; set; }
    }

    public interface IShield
    {
        int xPos { get; set; }  
        int yPos { get; set; }
        int xSpeed { get; set; }
        int rad { get; set; }

        void create(int xPos, int yPos, int xSpeed, int rad);
        void update();
        void move();
        void respawn();

        bool checkCollision(int xPosS, int yPosS, int widthS, int heightS);
    }
}
