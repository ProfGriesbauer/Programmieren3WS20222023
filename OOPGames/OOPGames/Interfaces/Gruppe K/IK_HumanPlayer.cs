using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPGames.Classes.Gruppe_K.K_DrawObject;
using System.Windows.Media.Imaging;

namespace OOPGames.Interfaces.Gruppe_K
{
    interface IK_HumanPlayer: IHumanGamePlayer
    {
        String AngleID { get; set; }
        float Angle { get; set; }

       float getAngle();
        void setAngle(float angle);
        
    }
}
