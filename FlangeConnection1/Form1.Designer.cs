
namespace FlangeConnection1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.paTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.laTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.paParams = new Guna.UI2.WinForms.Guna2Panel();
            this.buCalc = new Guna.UI2.WinForms.Guna2Button();
            this.tbD = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbS = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbP = new Guna.UI2.WinForms.Guna2TextBox();
            this.laS = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.laP = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.laD = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.laParams = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.paResults = new Guna.UI2.WinForms.Guna2Panel();
            this.richTB = new System.Windows.Forms.RichTextBox();
            this.laRaschet = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.buExit = new Guna.UI2.WinForms.Guna2Button();
            this.paTitle.SuspendLayout();
            this.paParams.SuspendLayout();
            this.paResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // paTitle
            // 
            this.paTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.paTitle.Controls.Add(this.buExit);
            this.paTitle.Controls.Add(this.laTitle);
            this.paTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.paTitle.Location = new System.Drawing.Point(0, 0);
            this.paTitle.Name = "paTitle";
            this.paTitle.ShadowDecoration.Parent = this.paTitle;
            this.paTitle.Size = new System.Drawing.Size(800, 77);
            this.paTitle.TabIndex = 0;
            // 
            // laTitle
            // 
            this.laTitle.BackColor = System.Drawing.Color.Transparent;
            this.laTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laTitle.ForeColor = System.Drawing.Color.White;
            this.laTitle.Location = new System.Drawing.Point(177, 21);
            this.laTitle.Name = "laTitle";
            this.laTitle.Size = new System.Drawing.Size(467, 33);
            this.laTitle.TabIndex = 0;
            this.laTitle.Text = "Расчет плоского приварного фланца";
            // 
            // paParams
            // 
            this.paParams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(226)))), ((int)(((byte)(240)))));
            this.paParams.BorderColor = System.Drawing.Color.Black;
            this.paParams.BorderThickness = 1;
            this.paParams.Controls.Add(this.buCalc);
            this.paParams.Controls.Add(this.tbD);
            this.paParams.Controls.Add(this.tbS);
            this.paParams.Controls.Add(this.tbP);
            this.paParams.Controls.Add(this.laS);
            this.paParams.Controls.Add(this.laP);
            this.paParams.Controls.Add(this.laD);
            this.paParams.Controls.Add(this.laParams);
            this.paParams.Location = new System.Drawing.Point(29, 83);
            this.paParams.Name = "paParams";
            this.paParams.ShadowDecoration.Parent = this.paParams;
            this.paParams.Size = new System.Drawing.Size(379, 373);
            this.paParams.TabIndex = 1;
            // 
            // buCalc
            // 
            this.buCalc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.buCalc.CheckedState.Parent = this.buCalc;
            this.buCalc.CustomImages.Parent = this.buCalc;
            this.buCalc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.buCalc.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buCalc.ForeColor = System.Drawing.Color.White;
            this.buCalc.HoverState.Parent = this.buCalc;
            this.buCalc.Location = new System.Drawing.Point(92, 310);
            this.buCalc.Name = "buCalc";
            this.buCalc.ShadowDecoration.Parent = this.buCalc;
            this.buCalc.Size = new System.Drawing.Size(180, 45);
            this.buCalc.TabIndex = 2;
            this.buCalc.Text = "Расчет";
            // 
            // tbD
            // 
            this.tbD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbD.DefaultText = "400";
            this.tbD.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbD.DisabledState.Parent = this.tbD;
            this.tbD.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbD.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbD.FocusedState.Parent = this.tbD;
            this.tbD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbD.ForeColor = System.Drawing.Color.Black;
            this.tbD.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbD.HoverState.Parent = this.tbD;
            this.tbD.Location = new System.Drawing.Point(277, 68);
            this.tbD.Name = "tbD";
            this.tbD.PasswordChar = '\0';
            this.tbD.PlaceholderText = "";
            this.tbD.SelectedText = "";
            this.tbD.SelectionStart = 3;
            this.tbD.ShadowDecoration.Parent = this.tbD;
            this.tbD.Size = new System.Drawing.Size(97, 36);
            this.tbD.TabIndex = 1;
            // 
            // tbS
            // 
            this.tbS.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbS.DefaultText = "12";
            this.tbS.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbS.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbS.DisabledState.Parent = this.tbS;
            this.tbS.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbS.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbS.FocusedState.Parent = this.tbS;
            this.tbS.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbS.ForeColor = System.Drawing.Color.Black;
            this.tbS.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbS.HoverState.Parent = this.tbS;
            this.tbS.Location = new System.Drawing.Point(277, 175);
            this.tbS.Name = "tbS";
            this.tbS.PasswordChar = '\0';
            this.tbS.PlaceholderText = "";
            this.tbS.SelectedText = "";
            this.tbS.SelectionStart = 2;
            this.tbS.ShadowDecoration.Parent = this.tbS;
            this.tbS.Size = new System.Drawing.Size(97, 36);
            this.tbS.TabIndex = 1;
            // 
            // tbP
            // 
            this.tbP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbP.DefaultText = "";
            this.tbP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbP.DisabledState.Parent = this.tbP;
            this.tbP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbP.FocusedState.Parent = this.tbP;
            this.tbP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbP.HoverState.Parent = this.tbP;
            this.tbP.Location = new System.Drawing.Point(277, 120);
            this.tbP.Name = "tbP";
            this.tbP.PasswordChar = '\0';
            this.tbP.PlaceholderText = "";
            this.tbP.SelectedText = "";
            this.tbP.ShadowDecoration.Parent = this.tbP;
            this.tbP.Size = new System.Drawing.Size(97, 36);
            this.tbP.TabIndex = 1;
            // 
            // laS
            // 
            this.laS.BackColor = System.Drawing.Color.Transparent;
            this.laS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laS.Location = new System.Drawing.Point(14, 182);
            this.laS.Name = "laS";
            this.laS.Size = new System.Drawing.Size(243, 22);
            this.laS.TabIndex = 0;
            this.laS.Text = "Толщина стенки фланца S (мм)";
            // 
            // laP
            // 
            this.laP.BackColor = System.Drawing.Color.Transparent;
            this.laP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laP.Location = new System.Drawing.Point(14, 128);
            this.laP.Name = "laP";
            this.laP.Size = new System.Drawing.Size(238, 22);
            this.laP.TabIndex = 0;
            this.laP.Text = "Внутреннее давление среды P";
            // 
            // laD
            // 
            this.laD.BackColor = System.Drawing.Color.Transparent;
            this.laD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laD.Location = new System.Drawing.Point(14, 74);
            this.laD.Name = "laD";
            this.laD.Size = new System.Drawing.Size(216, 22);
            this.laD.TabIndex = 0;
            this.laD.Text = "Внутренний диаметр D (мм)";
            // 
            // laParams
            // 
            this.laParams.BackColor = System.Drawing.Color.Transparent;
            this.laParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laParams.Location = new System.Drawing.Point(124, 15);
            this.laParams.Name = "laParams";
            this.laParams.Size = new System.Drawing.Size(148, 33);
            this.laParams.TabIndex = 0;
            this.laParams.Text = "Параметры";
            // 
            // paResults
            // 
            this.paResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(226)))), ((int)(((byte)(240)))));
            this.paResults.BorderColor = System.Drawing.Color.Black;
            this.paResults.Controls.Add(this.richTB);
            this.paResults.Controls.Add(this.laRaschet);
            this.paResults.Location = new System.Drawing.Point(444, 111);
            this.paResults.Name = "paResults";
            this.paResults.ShadowDecoration.Parent = this.paResults;
            this.paResults.Size = new System.Drawing.Size(356, 339);
            this.paResults.TabIndex = 2;
            // 
            // richTB
            // 
            this.richTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTB.Location = new System.Drawing.Point(51, 68);
            this.richTB.Name = "richTB";
            this.richTB.Size = new System.Drawing.Size(357, 287);
            this.richTB.TabIndex = 0;
            this.richTB.Text = "";
            // 
            // laRaschet
            // 
            this.laRaschet.BackColor = System.Drawing.Color.Transparent;
            this.laRaschet.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laRaschet.Location = new System.Drawing.Point(222, 15);
            this.laRaschet.Name = "laRaschet";
            this.laRaschet.Size = new System.Drawing.Size(110, 33);
            this.laRaschet.TabIndex = 0;
            this.laRaschet.Text = "Расчеты";
            // 
            // buExit
            // 
            this.buExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buExit.CheckedState.Parent = this.buExit;
            this.buExit.CustomImages.Parent = this.buExit;
            this.buExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.buExit.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.buExit.ForeColor = System.Drawing.Color.White;
            this.buExit.HoverState.ForeColor = System.Drawing.Color.Red;
            this.buExit.HoverState.Parent = this.buExit;
            this.buExit.Location = new System.Drawing.Point(763, 0);
            this.buExit.Name = "buExit";
            this.buExit.ShadowDecoration.Parent = this.buExit;
            this.buExit.Size = new System.Drawing.Size(37, 31);
            this.buExit.TabIndex = 1;
            this.buExit.Text = "X";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.paResults);
            this.Controls.Add(this.paParams);
            this.Controls.Add(this.paTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.paTitle.ResumeLayout(false);
            this.paTitle.PerformLayout();
            this.paParams.ResumeLayout(false);
            this.paParams.PerformLayout();
            this.paResults.ResumeLayout(false);
            this.paResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel paTitle;
        private Guna.UI2.WinForms.Guna2Panel paParams;
        private Guna.UI2.WinForms.Guna2TextBox tbD;
        private Guna.UI2.WinForms.Guna2TextBox tbP;
        private Guna.UI2.WinForms.Guna2HtmlLabel laP;
        private Guna.UI2.WinForms.Guna2HtmlLabel laD;
        private Guna.UI2.WinForms.Guna2HtmlLabel laParams;
        private Guna.UI2.WinForms.Guna2Panel paResults;
        private Guna.UI2.WinForms.Guna2TextBox tbS;
        private Guna.UI2.WinForms.Guna2HtmlLabel laS;
        private Guna.UI2.WinForms.Guna2HtmlLabel laTitle;
        private System.Windows.Forms.RichTextBox richTB;
        private Guna.UI2.WinForms.Guna2HtmlLabel laRaschet;
        private Guna.UI2.WinForms.Guna2Button buCalc;
        private Guna.UI2.WinForms.Guna2Button buExit;
    }
}

