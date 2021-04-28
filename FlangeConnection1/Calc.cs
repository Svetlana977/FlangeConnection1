using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlangeConnection1
{
   public class Calc
    {
        // определение коэффициента лямбда
        public float CalcLyambda()
        {
            return (float)0.5;
        }

        // ориентировочная толщина фланца
        public float Calch(float lyambda, float secvivalent, float d)
        {
            return (float)(lyambda * Math.Sqrt(d * secvivalent));
        }

        // окончательное число болтов
        public int CalcFinallyZb(float zb)      // число болтов кратное 4 
        {
            zb = Convert.ToInt32(Math.Ceiling(zb));
            while (zb % 4 != 0)
                zb++;
            return (int)zb;
        }

        // ориентировочное число болтов
        public float CalcZb(float db, float tb)
        {
            return (float)(Math.PI * db / tb);
        }

        // эффективная ширина прокладки
        public float Calcbe(float bp)
        {
            return (float)(0.5 * bp);
        }

        // средний диаметр прокладки
        public float CalcDcp(float dp, float bp)
        {
            return dp - bp;
        }

        // наружный диаметр прокладки
        public float CalcDp(float db, float e1)
        {
            return db - e1;
        }

        // наружный диаметр фланца
        public float CalcDf(float db, float alfa)
        {
            return db + alfa;
        }

        // диаметр болтовой окружности
        public float CalcDb(float d, float s0, float db)
        {
            return (float)(Math.Ceiling((d + 2 * (2 * s0 + db + 0.006)) * 1e2) / 1e2);
        }


        // меньшая толщина конической втулки фланца
        public float CalcS0(float s)
        {
            if ((float)(s * 1.35) - s <= 0.005)
            {
                return (float)(Math.Round(s * 1.35 * 1e3) / 1e3);
            }
            else
                return -1;
        }
    }
}
