using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using Font = System.Drawing.Font;

namespace FlangeConnection1
{
    public partial class Form1 : Form
    {
        private float S; // толщина стенки фланца
        private float D; // внутрений диаметр
        private float P;
        private float S0; // меньшая толщина конической втулки фланца
        private float S1; // большая толщина втулки фланца
        private float Secvivalent; // эквивалентная толщина втулки фланца
        private float bp = (float)(15 / 1e3); // ширина прокладки
        private float tb = (float)(100 / 1e3); // шаг болтов
        private float p = 0.1F; // расчетное избыточное давление
        private float n = 8; // число болтов
        private float fб = 235* (float)Math.Pow(10, -6); // площидь поперечного сечения болта внутри
        private float Eб = 195* (float)Math.Pow(10, 9); // линейная податливость болта
        //private float ; // 

        public float Db { get; private set; }
        public float Df { get; private set; }
        public float Dp { get; private set; }
        public float Dcp { get; private set; }
        public float Qd { get; private set; }//Равнодействующая внутреннего давления
        public float Rn { get; private set; }//Реакция прокладки в рабочих условиях
        public float y; //Функция линейной податливости болта
        public float Qm; //Коэффициент линейного расширения
        public float Pб1_1; //Коэффициент линейного расширения
        public float Pб1_2; 
        public float Wбдоп20; //Допускаемое напряжение материала болтов
        public float Pб1; 
        public float Pб2;//Болтовая нагрузка в робочих условиях 

        private float be;

        public float ZbOrientir { get; private set; } // ориентировочное число болтов
        public float Zb { get; private set; } // окончательное число болтов

        private float h;
        private int betta = 1; // для плоских фланцев
        
       
        // шестигранная гайка с уменьшенным размером «под ключ» и плоская прокладка
        private float db = (float)(25 / 1e3); // диаметр болта
        private float alfa = (float)(40 / 1e3); // величина, зависящая от типа и размера гайки
        private float e1 = (float)(32 / 1e3); // назначают в зависимости от диаметра болтов и вида прокладки
        private float lyambda;
        private int paddingY = 20; // отступ по оси Y
        private int paddingX = 30; // отступ по оси Х
        private Calc calc;

        //безразмерные параметры фланцевого соединения
        private float j;
        private float K;
        private float psi1;
        private float psi2;
        private float omega;
        private double E = 2.15 * Math.Pow(10,11);
        // угловая податливость фланца
        private float Yf;
        // основные параметры прокладок
        private float m = 2.5F;
        private double hp = 0.003;
        private double q = 20 * Math.Pow(10, 6);
        private double qdop = 130 * Math.Pow(10, 6);
        private double Ep = 130 * Math.Pow(10, 6);
        private double Kp = 1;
        private double b = 12 * Math.Pow(10, -3);
        private double b0; // эффективная ширина прокладки
        private float Yp; // линейная податливость прокладки
        private double pi = 3.14;
        // основные параметры болтов
        private float lbo;
        private float lb;
        private double fb = 2.35 * Math.Pow(10, -4);
        private double Eb = 1.95 * Math.Pow(10, 11);
        private double yb;
        // коэффициент жесткости фланцевых соединений
        private float A;
        private float B1;
        private float B2;
        private float alf;
        //Коэффициенты линейного расширения
        public float alfaB = 11.6F * (float)Math.Pow(10, -6);
        public float alfaF = 15.3F*(float) Math.Pow(10, -6);
        public float tB = 62;
        public float tF = 65;
        public float nm = 2.8F; // коэффициент запаса прочности
        public float Wm = 65;//предел текучести материала болтов при 20 град


        public Form1()
        {
            InitializeComponent();

            calc = new Calc();

            SetControls();
            SetParams();
            CalcConstructionSize(S, D);
            CalcAdditionalSize(S, D);
            buCalc.Click += BuCalc_Click;
            buExit.Click += (s, e) => Application.Exit();
            buExport.Click += BuExport_Click;
        }

        private void BuExport_Click(object sender, EventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1252 = Encoding.GetEncoding(1252);

            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
            var fontParag = new iTextSharp.text.Font(baseFont, 20);
            var fontTitle = new iTextSharp.text.Font(baseFont, 24);

            Document doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);

            //string pdfFilePath = @"D:/";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pdfFilePath = saveFileDialog1.FileName + ".pdf";

                var fs = new FileStream(pdfFilePath, FileMode.Create);

                doc.NewPage();
                var writer = PdfWriter.GetInstance(doc, fs);

                doc.Open();
                doc.NewPage();

                using (var stream = new FileStream("Test.pdf", FileMode.Create))
                {
                    PdfWriter.GetInstance(doc, stream);
                    doc.Open();

                    doc.Add(new Paragraph($"{richTB.Text}", font));

                    doc.Close();
                }
            }

            

            MessageBox.Show("OK");
        }

        // выполнить расчет
        private void BuCalc_Click(object sender, EventArgs e)
        {
            SetParams();
            CalcConstructionSize(S, D);
            CalcAdditionalSize(S, D);
            CreateReport();
        }

        // размещение элементов на форме
        private void SetControls()
        {
            // создание верхней панели
            paTitle.Dock = DockStyle.Top;
            paTitle.BackColor = Color.FromArgb(23, 24, 28);

            // заголовок
            laTitle.ForeColor = Color.White;
            laTitle.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - laTitle.Width / 2, paddingY);
            
            // левая панель
            //paParams.BackColor = Color.FromName("#f5f7ff");
            paParams.Dock = DockStyle.Left;
            paParams.Width = Screen.PrimaryScreen.Bounds.Width / 3;

            //laParams.AutoSize = false;
            //laParams.Size = new Size(180, 40);
            laParams.Location = new Point(paParams.Width / 2 - laParams.Width / 2, paddingY);

            //laD.AutoSize = false;
            //laD.Size = new Size(274,27);
            laD.Location = new Point(paddingX, laParams.Location.Y + paddingY*2 + laParams.Height);

            //laP.AutoSize = false;
            //laP.Size = new Size(287, 27);
            laP.Location = new Point(paddingX, laD.Location.Y + paddingY*2 + laD.Height);

            //laS.AutoSize = false;
            //laS.Size = new Size(308, 27);
            laS.Location = new Point(paddingX, laP.Location.Y + paddingY*2 + laP.Height);
            tbD.Location = new Point(paParams.Width - tbD.Width - paddingX, laParams.Location.Y + paddingY * 2 + laParams.Height - tbD.Height/8);
            tbP.Location = new Point(paParams.Width - tbD.Width - paddingX, laD.Location.Y + paddingY * 2 + laD.Height - tbD.Height / 8);
            tbS.Location = new Point(paParams.Width - tbD.Width - paddingX, laP.Location.Y + paddingY * 2 + laP.Height - tbD.Height / 8);
            
            buCalc.Location = new Point(paParams.Width / 2 - buCalc.Width / 2, paParams.Height - buCalc.Height - paddingY);

            // правая панель
            paResults.Size = new Size(Screen.PrimaryScreen.Bounds.Width / 3 * 2, paParams.Height);
            paResults.Dock = DockStyle.Right;
            //paResults.BackColor = Color.FromName("#f5f7ff");

            //laRaschet.AutoSize = false;
            //laRaschet.Size = new Size(135, 40);
            laRaschet.Location = new Point(paResults.Width / 2 - laRaschet.Width / 2, paddingY);

            
            richTB.Size = new Size(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height - paTitle.Height - laRaschet.Height - paddingY * 4 - buExport.Height);
            richTB.Location = new Point(paResults.Width / 2 - richTB.Width / 2, laRaschet.Location.Y + laRaschet.Height + paddingY);

            buExport.Location = new Point(paResults.Width / 2 - buExport.Width / 2, richTB.Location.Y + richTB.Height + paddingY);
        }

        // определение конструктивных размеров
        private void CreateReport()
        {
            // очищение richTextBox
            richTB.Clear();
            // базовые стили текста
            richTB.Font = new Font("SegoeUI", 12);
            richTB.AppendText("Расчет фланцевого соединения\n");
            // выделение заголовка и изменение положения и размера
            SelectRichText(richTB, "Расчет фланцевого соединения");
            richTB.SelectionFont = new Font("", 16);
            richTB.SelectionAlignment = HorizontalAlignment.Center;
            // выделение подзаголовка, задание стилей
            richTB.AppendText("1. Определение конструктивных размеров\n");
            SelectRichText(richTB, "1. Определение конструктивных размеров");
            richTB.SelectionFont = new Font("", 12, FontStyle.Underline);
            // добавление расчета в richTextBox
            richTB.AppendText($"Меньшая толщина конической втулки фланца: S₀ = {S0} м\n");
            // добавление строки текста с определенным стилем
            richTB.AppendText($"При этом должно выполняться условие: S₀ - S ≤ 0,005 м\n");
            SelectRichText(richTB ,"При этом должно выполняться условие");
            richTB.SelectionFont = new Font("", 10, FontStyle.Italic);

            richTB.AppendText($"Для плоских фланцев β = 1\n");
            richTB.AppendText($"Большую толщину втулки фланца принимаем: S₁ = S₀ = {S1} м\n");
            richTB.AppendText($"Определим эквивалентную толщину втулки фланца: Sэ");
            // подстрочный знак
            BottomIndex(1);

            richTB.AppendText($" = S₀ = {Secvivalent} м\n");
            richTB.AppendText($"Диаметр болтовой окружности: Dб");
            BottomIndex(1);
            richTB.AppendText($" ≥ {(float)(D + 2 * (2 * S0 + db + 0.006))} м\n");
            richTB.AppendText($"Принимаем Dб");
            BottomIndex(1);
            richTB.AppendText($": = {Db} м\n");
            richTB.AppendText($"Наружный диаметр фланца Dф");
            BottomIndex(1);
            richTB.AppendText($": = {Df} м\n");
            richTB.AppendText($"Наружный диаметр прокладки Dп");
            BottomIndex(1);
            richTB.AppendText($": = {Dp} мм\n");
            richTB.AppendText($"Средний диаметр прокладки (примем ширину прокладки bп");
            BottomIndex(1);
            richTB.AppendText($" = {bp} м):\n");
            richTB.AppendText($"Dсп");
            BottomIndex(2);
            richTB.AppendText($" = {Dcp} м\n");
            richTB.AppendText($"Эффективная ширина прокладки bе");
            BottomIndex(1);
            richTB.AppendText($": = {be} м\n");
            richTB.AppendText($"Ориентировочное число болтов (шпилек), примем tб");
            BottomIndex(1);
            richTB.AppendText($" = {tb} м: Zб");
            BottomIndex(1);
            richTB.AppendText($" = {ZbOrientir}\n");
            richTB.AppendText($"Окончательное число болтов: Zб");
            BottomIndex(1);
            richTB.AppendText($" = {Zb} шт.\n");
            richTB.AppendText($"Ориентировочная толщина фланца: h = {h} м\n");



            // расчет вспомогательных величин
            richTB.AppendText("2. Расчет вспомогательных величин\n");
            SelectRichText(richTB, "2. Расчет вспомогательных величин");
            richTB.SelectionFont = new Font("", 12, FontStyle.Underline);

            // основные параметры фланцевого соединения
            richTB.AppendText("2.1 Основные параметры фланцевого соединения\n");
            SelectRichText(richTB, "2.1 Основные параметры фланцевого соединения");
            richTB.SelectionFont = new Font("", 12, FontStyle.Regular);

            richTB.AppendText("Безразмерные параметры:\n");
            richTB.AppendText($"λ = {lyambda}\n");
            richTB.AppendText($"j = {j}\n");
            richTB.AppendText($"K = {K}\n");
            richTB.AppendText($"ψ1 = {psi1}\n");
            richTB.AppendText($"ψ2 = {psi2}\n");
            richTB.AppendText($"ω = {omega}\n");
            richTB.AppendText($"Модуль продольной упругости: E = {E} Па\n");
            richTB.AppendText($"Угловая податливость фланца: Yф = {Yf}\n");

            // основные параметры прокладок
            richTB.AppendText("2.2 Основные параметры прокладок\n");
            SelectRichText(richTB, "2.2 Основные параметры прокладок");
            richTB.SelectionFont = new Font("", 12, FontStyle.Regular);

            richTB.AppendText("Эффективная ширина прокладки при b ≤ 1,5 см\n");
            richTB.AppendText($"b = {b0}\n");;
            richTB.AppendText($"Выбираем прокладку из картона асбестового по ГОСТ 2850-75 при толщине\n" + $"hп = {hp} M\n");
            richTB.AppendText($"Коэффициент m = {m}\n");
            richTB.AppendText($"Минимальное удельное давление q = {q} Па\n");
            richTB.AppendText($"Допускаемое удельное давление qдоп = {qdop} Па\n");
            richTB.AppendText($"Модуль упругости Eп = {Ep}\n");
            richTB.AppendText($"Коэффициент обжатия прокладки: Кп = {Kp}\n");
            richTB.AppendText($"Линейная податливость прокладки: Yп = {Yp}\n");

            // основные параметры болтов
            richTB.AppendText("2.3 Основные параметры болтов\n");
            SelectRichText(richTB, "2.3 Основные параметры болтов");
            richTB.SelectionFont = new Font("", 12, FontStyle.Regular);

            richTB.AppendText($"Расчётная длина болта: lбo = {lbo} М, где lб = {lb} М\n");
            richTB.AppendText("Площадь поперечного сечения болта M20 по внутреннему диаметру резьбы:\n"+ $"fб = {fb} м^2\n");
            richTB.AppendText("Линейная податливость болтов:\n" + $"Eб = {Eb} Па\n" + $"yб = {yb}\n");

            // коэффициент жесткости фланцевых соединений
            richTB.AppendText("2.4 Коэффициент жесткости фланцевых соединений\n");
            SelectRichText(richTB, "2.4 Коэффициент жесткости фланцевых соединений");
            richTB.SelectionFont = new Font("", 12, FontStyle.Regular);


            richTB.AppendText($"A = {A}\n");
            richTB.AppendText($"B1 = {B1}\n" + $"B2 = {B2}\n");
            richTB.AppendText($"При стыковке одинаковых фланцев коэффициент жесткости фланцевых соединений α = {alf}\n");




            //Расчет 3
            richTB.AppendText("3. Расчет фланца, работающего под внутренним давлением\n");
            SelectRichText(richTB, "3. Расчет фланца, работающего под внутренним давлением");
            richTB.SelectionFont = new Font("", 12, FontStyle.Underline);

            //1. Определение нагрузок, действующих на фланец.
            richTB.AppendText("3.1. Определение нагрузок, действующих на фланец\n");
            SelectRichText(richTB, "3.1. Определение нагрузок, действующих на фланец");
            //равнодействующая внутреннего давления
            richTB.AppendText($"Равнодействующая внутреннего давления Qd = {Qd} H\n");
            richTB.AppendText($"Реакция прокладки в рабочих условиях Rn = {Rn} H\n");
            richTB.AppendText($"Кэффициенты линейного расширения Qm = {Qm} Н\n");
            richTB.AppendText($"Болтовая нагрузка в условиях монтажа до подачи внутреннего давления Pб1_1 = {Pб1_1} Н\n");
            richTB.AppendText($"Коэффициент запаса прочности для болтов  \n");
            richTB.AppendText($"Wбдоп20 = {Wбдоп20} Па\n");
            richTB.AppendText($" Pб1_2 = {Pб1_2} H\n");
            richTB.AppendText($"Pб = {Pб1} H\n");
            richTB.AppendText($"Предел текучести материала болтов при 20 град.\n");
            richTB.AppendText($"Допускаемое напряжение материала болтов\n");
            richTB.AppendText($"Болтовая нагрузка в рабочих условиях Pб2 = {Pб2} Н\n");
            richTB.AppendText($"Приведенный изгибающий момент\n");
            richTB.AppendText($"Предел текучести материала болтов при 62 град.\n");
            richTB.AppendText($"Допускаемое напряжение болтов\n");
        }

       

            // подстрочный знак
        private void BottomIndex(int v)
        {
            richTB.Select(richTB.TextLength - v, v);
            richTB.SelectionCharOffset = -8;
            richTB.Select(richTB.TextLength, 0);
            richTB.SelectionCharOffset = 0;
        }

        // выбор текста для форматирования
        private void SelectRichText(RichTextBox rch, string target)
        {
            int pos = rch.Text.IndexOf(target);
            if (pos < 0)
            {
                // Не найдено. Выберите ничего.
                rch.Select(0, 0);
            }
            else
            {
                // Найден текст. Выберите его.
                rch.Select(pos, target.Length);
            }
        }

        // считывание введенных параметров
        private void SetParams()
        {
            S = (float)(Convert.ToInt32(tbS.Text) / 1e3);
            P = (float)Convert.ToDouble(tbP.Text);
            D = (float)(Convert.ToInt32(tbD.Text) / 1e3);
        }


        // определение конструктивных размеров фланца
        private void CalcConstructionSize(float s, float d)
        {
            // меньшая толщина конической втулки фланца
            S0 = calc.CalcS0(S);
            if (S0 == -1)
            {
                MessageBox.Show("Введите другое значение толщины стенки");
            }

            S1 = betta * S0;
            Secvivalent = S0;

            // диаметр болтовой окружности
            Db = calc.CalcDb(d, S0, db);

            // наружный диаметр фланца
            Df = calc.CalcDf(Db, alfa);

            // наружный диаметр прокладки
            Dp = calc.CalcDp(Db, e1);

            // средний диаметр прокладки
            Dcp = calc.CalcDcp(Dp, bp);

            // эффективная ширина прокладки
            be = calc.Calcbe(bp);

            // ориентировочное число болтов
            ZbOrientir = calc.CalcZb(Db, tb);

            // окончательное число болтов
            Zb = calc.CalcFinallyZb(ZbOrientir);

            // определение коэффициента лямбда
            lyambda = calc.CalcLyambda();

            // ориентировочная толщина фланца
            h = calc.Calch(lyambda, Secvivalent, d);

            

        }

        // расчет вспомогательных величин
        private void CalcAdditionalSize(float s, float d)
        {
            // основные параметры фланцевого соединения
            // безразмерные параметры
            j = calc.CalcJ(h, Secvivalent);

            K = calc.CalcK(Df, D);

            psi1 = calc.CalcPsi1(K);

            psi2 = calc.CalcPsi2(K);

            omega = calc.CalcOmega(lyambda, psi1, j);
            // угловая податливость фланца
            Yf = calc.CaclYf(omega, lyambda, psi2, h, E);

            // основные параметры прокладок
            // эффективная ширина прокладки при b ≤ 1,5 см
            b0 = calc.CaclB0(b);
            // линейная податливость прокладки
            Yp = calc.CalcYp(hp, Kp, Ep, b, Dcp, pi);


            // основные параметры болтов
            // расчётная длина болта
            lbo = calc.CalcLbo(h, hp);
            lb = calc.CalcLb(lb, D);
            // линейная податливость болтов
            yb = calc.CalcYb(lb,Eb,fb,n);

            // коэффициент жесткости фланцевых соединений при стыковке одинаковых фланцев Yf1 = Yf2 = Yf и D1 = D2 = D, B1 = B2
            A = calc.CalcA(Yp, yb, Yf, Db, Dcp);
            B1 = calc.CalcB1(Yf, Db, D, Secvivalent);
            B2 = calc.CalcB2(B1);
            alf = calc.CalcAlf(A, yb, B1, B2, Db, Dcp);

            //равнодействующая внутреннего давоения 
            Qd = calc.CalcQd(Dcp, p);

            //Реакция прокладки в рабочих условиях
            Rn = calc.CalcRn(Dcp,m,p,b0);

            y = calc.Calcy(A, yb);
            Qm = calc.CalcQm(y,n,fб,Eб,alfaB,alfaF,tB,tF);
            Pб1_1 = calc.CalcPб1_1(Dcp,b0,q);
            Pб1_2 = calc.CalcPб1_1(n,fb, Wбдоп20);
            Wбдоп20 = calc.CalcWбдоп20(nm,Wm);
            Pб1 = calc.CalcPб1(Pб1_2, Pб1_1);
            Pб2 = calc.CalcPб2(alfa, Qd,Rn,Qm, Pб1);
        }

    }
}
