namespace TiendaDeMascotas
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ContraseñaLogin = new System.Windows.Forms.TextBox();
            this.IniciarSesion = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UsuarioLogin = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 100);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(117, 53);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Todo Mascotas";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 35;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(55, 147);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(55, 247);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Contraseña";
            // 
            // ContraseñaLogin
            // 
            this.ContraseñaLogin.Location = new System.Drawing.Point(60, 288);
            this.ContraseñaLogin.Name = "ContraseñaLogin";
            this.ContraseñaLogin.Size = new System.Drawing.Size(194, 26);
            this.ContraseñaLogin.TabIndex = 4;
            this.ContraseñaLogin.TextChanged += new System.EventHandler(this.ContraseñaLogin_TextChanged_1);
            // 
            // IniciarSesion
            // 
            this.IniciarSesion.ActiveBorderThickness = 1;
            this.IniciarSesion.ActiveCornerRadius = 20;
            this.IniciarSesion.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.IniciarSesion.ActiveForecolor = System.Drawing.Color.White;
            this.IniciarSesion.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.IniciarSesion.BackColor = System.Drawing.SystemColors.Control;
            this.IniciarSesion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("IniciarSesion.BackgroundImage")));
            this.IniciarSesion.ButtonText = "Iniciar Sesión";
            this.IniciarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IniciarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IniciarSesion.ForeColor = System.Drawing.Color.SeaGreen;
            this.IniciarSesion.IdleBorderThickness = 1;
            this.IniciarSesion.IdleCornerRadius = 20;
            this.IniciarSesion.IdleFillColor = System.Drawing.Color.Crimson;
            this.IniciarSesion.IdleForecolor = System.Drawing.Color.Navy;
            this.IniciarSesion.IdleLineColor = System.Drawing.Color.Crimson;
            this.IniciarSesion.Location = new System.Drawing.Point(74, 334);
            this.IniciarSesion.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.IniciarSesion.Name = "IniciarSesion";
            this.IniciarSesion.Size = new System.Drawing.Size(169, 39);
            this.IniciarSesion.TabIndex = 6;
            this.IniciarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.IniciarSesion.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Crimson;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 445);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 23);
            this.panel2.TabIndex = 8;
            // 
            // UsuarioLogin
            // 
            this.UsuarioLogin.Location = new System.Drawing.Point(60, 189);
            this.UsuarioLogin.Name = "UsuarioLogin";
            this.UsuarioLogin.Size = new System.Drawing.Size(194, 26);
            this.UsuarioLogin.TabIndex = 1;
            this.UsuarioLogin.TextChanged += new System.EventHandler(this.UsuarioLogin_TextChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 468);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.IniciarSesion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ContraseñaLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UsuarioLogin);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 IniciarSesion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ContraseñaLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox UsuarioLogin;
    }
}