using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace OOPGames.Classes.Gruppe_K
{
    interface K_GameObject
    {
    }

    class K_Status:K_GameObject
    {
        double _GameTime;
        int _Score;
        int _TurnCounter;
        K_GameObject _ActivePlayer;
    }

    class K_GameField:K_GameObject
    {
        int[] _field=new int[400*800];
    }

    abstract class K_DrawObject: K_GameObject
    {
        int _xPos;
        int _yPos;
        float _Rotation;
        RenderTargetBitmap _Image;
    }

    class K_Player: K_DrawObject
    {
        float _DriveRange;
        float _ShootAngle;
        float _ShootForce;
        float _Health;
    }

    class K_Projectile: K_DrawObject
    {
        float _xSpeed;
        float _ySpeed;
        float _Damage;
        float _DamageRadius;
        int _DamageType;
    }

    class K_Target: K_DrawObject
    {
        float _Radius;
    }


}
