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
        public int CalcFinallyn(float zb)      // число болтов кратное 4 
        {
            zb = Convert.ToInt32(Math.Ceiling(zb));
            while (zb % 4 != 0)
                zb++;
            return (int)zb;
        }

        // ориентировочное число болтов
        public float Calcn(float db, float tb)
        {
            return (float)(Math.PI * db / tb);
        }

        // эффективная ширина прокладки
        public float Calcbe(float bp)
        {
            if (bp <= 15)
                return (float)(0.5 * bp);
            else
                return (float)(0.6 * Math.Sqrt(bp));
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

        //безразмерные параметры фланцевого соединения
        // определение j
        internal float CalcJ(float h, float secvivalent)
        {
            return (float)(h / secvivalent);
        }
        // определение K
        internal float CalcK(float df, float d)
        {
            return (float)(df / d);
        }

        // определение ψ1 
        internal float CalcPsi1(float k)
        {
            return (float)(1.28 * Math.Log10(k));
        }

        // определение ψ2
        internal float CalcPsi2(float k)
        {
            return (float)((k+1)/(k-1));
        }

        // определение ω
        internal float CalcOmega(float lyambda, float psi1, float j)
        {
            return (float)(1/(1 + 0.9 * lyambda * (1 + psi1 + Math.Pow(j,2))));
        }

        // определение Yф (!!!проверить формулу)
        internal float CaclYf(float omega, float lyambda, float psi2, float h, double E)
        {
            return (float)((1 - omega *(1 + 0.9 * lyambda))*psi2 / Math.Pow(h,3) * E / Math.Pow(10,16));
        }

        // основные параметры прокладок
        // эффективная ширина прокладки при b ≤ 1,5 см
        internal double CaclB0(double b)
        {
            return (double)(b /2 );
        }

        // линейная податливость прокладки (проверить расчет!!!)
        internal float CalcYp(double hp, double kp, double ep, double b, float dcp, double pi)
        {
            return (float)(hp * kp /(ep*b*dcp*pi)* Math.Pow(10,9));
        }

        // основные параметры болтов
        // расчётная длина болта
        internal float CalcLbo(float h, double hp)
        {
            return (float)(2 * h + hp);
        }

        internal float CalcLb(float lbo, float d)
        {
            return (float)(lbo + 1.25 * d);
        }

        // линейная податливость болтов (проверить расчет!!!)
        internal double CalcYb(float lb, double eb, double fb, float n)
        {
            return (float)(lb / (eb * fb * n) * Math.Pow(10, 9));
        }

        // коэффициент жесткости фланцевых соединений при стыковке одинаковых фланцев Yf1 = Yf и Yf2 = Yf
        internal float CalcA(float yp, double yb, float yf, float db, float dcp)
        {
            return (float)(1/(yp + yb + 1/4 * (yf + yf) * Math.Pow((db - dcp),2)));
        }

        internal float CalcB1(float yf, float db, float d, float secvivalent)
        {
            return (float)(yf * (db - d - secvivalent));
        }

        internal float CalcB2(float b1)
        {
            return (float)(b1);
        }

        internal float CalcAlf(float a, double yb, float b1, float b2, float db, float dcp)
        {
            return (float)(a * (yb + 1/4 * (b1 + b2) * (db -dcp)));
        }
        //Равнодействующая внутреннего давления
        internal float CalcQd(float Dcp,  float p)
        {
            return (float)(0.758* Dcp*Dcp*p* Math.Pow(10, 6));
        }
        //Реакция прокладки в рабочих условиях!!!
        internal float CalcRn(float Dcp, double b0, float p, double m)
        {
            return (float)(p*2* Math.PI*Dcp*b0*m* Math.Pow(10, 6)); 
        }
        //функция линейной податливости болтов
        internal float Calcy(float A, double yb)
        {
            return (float)(yb*A);
        }
        //Коэффициент линейного расширения
        internal float CalcQm(float y, float n, float fб, float Eб, float alfaB, float alfaF, float tB, float tF)
        {
            return (float)(y*n*fб*Eб*(alfaF*tF-alfaB*tB));
        }
        //Болтовая нагрузка
        internal float CalcPб1_1(float Dcp, double b0, double q)
        {
            return (float)(Math.PI*Dcp*b0*q);
        }
        internal float CalcPб1_2(float Wбдоп20, float fб, float n)
        {
            return (float)(0.4*Wбдоп20*n*fб);
        }
        //Допускаемое напрядения материала болтов
        internal float CalcWбдоп20(float nт, float Wm)
        {
            return (float)((Wm* Math.Pow(10, 6)) /nт);
        }
        
        internal float CalcPб1(float Pб1_2, float Pб1_1)
        {
            if(Pб1_2> Pб1_1)
            {
                return Pб1_2;
            }
            else { return Pб1_1; }
        }
        //Болтовая нагрузка в рабочих условиях
        internal float CalcPб2(float Pб1, float alfa, float Qd, float Rn, float Qm)
        {
            return (float)(Pб1+alfa*Qd+Rn+Qm);
        }
        internal float CalcM01(float Pб1, float Db, float Dcp)
        {
            return (float)(Pб1 * (Db - Dcp) / 2);
        }
        internal float CalcQбдопt(float qt, float nт)
        {
            return (float)(qt/nт* Math.Pow(10, 6));
        }
        internal float CalcM02(float qt, float nт)
        {
            return (float)(qt / nт * Math.Pow(10, 6));
        }
        internal float CalcM0(float M01, float M02)
        {
            if (M01 > M02)
            {
                return M01;
            }
            else { return M02; }
        }
        internal float CalcQб1(float Pб1, float n, float fб)
        {
            return (float)(Pб1 / (n * fб));
        }
        //Условия прочности
        //σ.б1 ≤ σ.бдоп20
        public string CalcConditionA(float qб1, float Wбдоп20)
        {
            if (qб1 <= Wбдоп20)
            {
                return  "выполняется";
            } else
            {
                return "не выполняется";
            }
        }
        internal float CalcQб2(float Pб2, float n, float fб)
        {
            return (float)(Pб2 / (n * fб));
        }
        //σ.б2≤σ.бдопt
        public string CalcConditionB(float qб2, float qбдопt)
        {
            if (qб2 <= qбдопt)
            {
                return "выполняется";
            }
            else
            {
                return "не выполняется";
            }
        }
        //Крутящий момент на ключе при затяжке болтов
        internal float CalcMкр(float Pб1, float bd, float n, float ss)
        {
            return (float)(ss * Pб1 * bd / n);
        }
    }
}
