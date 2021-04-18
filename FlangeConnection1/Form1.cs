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

        public float Db { get; private set; }
        public float Df { get; private set; }
        public float Dp { get; private set; }
        public float Dcp { get; private set; }

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

        public Form1()
        {
            InitializeComponent();

            SetControls();
            SetParams();
            CalcConstructionSize(S, D);
            buCalc.Click += BuCalc_Click;
            buExit.Click += (s, e) => Application.Exit();
        }

        // выполнить расчет
        private void BuCalc_Click(object sender, EventArgs e)
        {
            SetParams();
            CalcConstructionSize(S, D);
            CreateReport();
        }

        // размещение элементов на форме
        private void SetControls()
        {
            // заголовок
            paTitle.BackColor = Color.FromArgb(23, 24, 28);
            laTitle.ForeColor = Color.White;
            laTitle.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - laTitle.Width / 2, paddingY);
            // левая панель
            paParams.Size = new Size(Screen.PrimaryScreen.Bounds.Width/3, Screen.PrimaryScreen.Bounds.Height - paTitle.Height);
            paParams.BackColor = Color.FromName("#f5f7ff");
            paParams.Location = new Point(0, paTitle.Height);
            laParams.Location = new Point(paParams.Width / 2 - laParams.Width / 2, paddingY);
            laD.Location = new Point(paddingX, laParams.Location.Y + paddingY*2 + laParams.Height);
            laP.Location = new Point(paddingX, laD.Location.Y + paddingY*2 + laD.Height);
            laS.Location = new Point(paddingX, laP.Location.Y + paddingY*2 + laP.Height);
            tbD.Location = new Point(paParams.Width - tbD.Width - paddingX, laParams.Location.Y + paddingY * 2 + laParams.Height - tbD.Height/8);
            tbP.Location = new Point(paParams.Width - tbD.Width - paddingX, laD.Location.Y + paddingY * 2 + laD.Height - tbD.Height / 8);
            tbS.Location = new Point(paParams.Width - tbD.Width - paddingX, laP.Location.Y + paddingY * 2 + laP.Height - tbD.Height / 8);
            buCalc.Location = new Point(paParams.Width / 2 - buCalc.Width / 2, paParams.Height - buCalc.Height - paddingY);
            // правая панель
            paResults.Size = new Size(Screen.PrimaryScreen.Bounds.Width / 3 * 2, paParams.Height);
            paResults.Dock = DockStyle.Right;
            paResults.BackColor = Color.FromName("#f5f7ff");
            laRaschet.Location = new Point(paResults.Width / 2 - laRaschet.Width / 2, paddingY);
            richTB.Size = new Size(Screen.PrimaryScreen.Bounds.Width / 2, paParams.Height / 4 * 3);
            richTB.Location = new Point(paResults.Width / 2 - richTB.Width / 2, laRaschet.Location.Y + laRaschet.Height + paddingY);
        }

        // выполнение расчетов
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
            richTB.AppendText("Определение конструктивных размеров\n");
            SelectRichText(richTB, "Определение конструктивных размеров");
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
            //P = Convert.ToInt32(tbP.Text);
            D = (float)(Convert.ToInt32(tbD.Text) / 1e3);
        }


        // определение конструктивных размеров фланца
        private void CalcConstructionSize(float s, float d)
        {
            // меньшая толщина конической втулки фланца
            S0 = CalcS0(S);
            if (S0 == -1)
            {
                MessageBox.Show("Введите другое значение толщины стенки");
            }

            S1 = betta * S0;
            Secvivalent = S0;

            // диаметр болтовой окружности
            Db = CalcDb(d, S0, db);

            // наружный диаметр фланца
            Df = CalcDf(Db, alfa);

            // наружный диаметр прокладки
            Dp = CalcDp(Db, e1);

            // средний диаметр прокладки
            Dcp = CalcDcp(Dp, bp);

            // эффективная ширина прокладки
            be = Calcbe(bp);

            // ориентировочное число болтов
            ZbOrientir = CalcZb(Db, tb);

            // окончательное число болтов
            Zb = CalcFinallyZb(ZbOrientir);

            // определение коэффициента лямбда
            lyambda = CalcLyambda();

            // ориентировочная толщина фланца
            h = Calch(lyambda, Secvivalent, d);

        }

        // определение коэффициента лямбда
        private float CalcLyambda()
        {
            return (float)0.5;
        }

        // ориентировочная толщина фланца
        private float Calch(float lyambda, float secvivalent, float d)
        {
            return (float)(lyambda * Math.Sqrt(d * secvivalent));
        }

        // окончательное число болтов
        private int CalcFinallyZb(float zb)
        {
            zb = Convert.ToInt32(Math.Ceiling(zb));
            while (zb % 4 != 0)
                zb++;
            return (int)zb;
        }

        // ориентировочное число болтов
        private float CalcZb(float db, float tb)
        {
            return (float)(Math.PI * db / tb);
        }

        // эффективная ширина прокладки
        private float Calcbe(float bp)
        {
            return (float)(0.5 * bp);
        }

        // средний диаметр прокладки
        private float CalcDcp(float dp, float bp)
        {
            return dp - bp;
        }

        // наружный диаметр прокладки
        private float CalcDp(float db, float e1)
        {
            return db - e1;
        }

        // наружный диаметр фланца
        private float CalcDf(float db, float alfa)
        {
            return db + alfa;
        }

        // диаметр болтовой окружности
        private float CalcDb(float d, float s0, float db)
        {
            return (float)(Math.Ceiling((d + 2 * (2 * s0 + db + 0.006))*1e2)/1e2);
        }


        // меньшая толщина конической втулки фланца
        private float CalcS0(float s)
        {
            if ((float)(s * 1.35) - s <= 0.005)
            {
                return (float)(Math.Round(s * 1.35 * 1e3)/1e3);
            }
            else
                return -1;
        }
    }
}
