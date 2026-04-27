namespace UtilitariosSuporte.Features.Menu
{
    partial class FormMenu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlLateral = new System.Windows.Forms.Panel();
            this.pnlConteudo = new System.Windows.Forms.Panel();
            this.btnSuporte = new System.Windows.Forms.Button();
            this.btnConfiguracoes = new System.Windows.Forms.Button();
            this.picLogoMenu = new System.Windows.Forms.PictureBox();
            this.lblTituloMenu = new System.Windows.Forms.Label();
            this.pnlLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLateral (Barra de Navegação)
            // 
            this.pnlLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlLateral.Controls.Add(this.btnConfiguracoes);
            this.pnlLateral.Controls.Add(this.btnSuporte);
            this.pnlLateral.Controls.Add(this.picLogoMenu);
            this.pnlLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLateral.Location = new System.Drawing.Point(0, 0);
            this.pnlLateral.Name = "pnlLateral";
            this.pnlLateral.Size = new System.Drawing.Size(200, 561);
            this.pnlLateral.TabIndex = 0;
            // 
            // picLogoMenu
            // 
            this.picLogoMenu.Image = global::UtilitariosSuporte.Properties.Resources.SBRlogo;
            this.picLogoMenu.Location = new System.Drawing.Point(25, 20);
            this.picLogoMenu.Name = "picLogoMenu";
            this.picLogoMenu.Size = new System.Drawing.Size(150, 100);
            this.picLogoMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoMenu.TabIndex = 0;
            this.picLogoMenu.TabStop = false;
            // 
            // btnSuporte
            // 
            this.btnSuporte.FlatAppearance.BorderSize = 0;
            this.btnSuporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuporte.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSuporte.ForeColor = System.Drawing.Color.White;
            this.btnSuporte.Location = new System.Drawing.Point(0, 150);
            this.btnSuporte.Name = "btnSuporte";
            this.btnSuporte.Size = new System.Drawing.Size(200, 50);
            this.btnSuporte.TabIndex = 1;
            this.btnSuporte.Text = "SUPORTE";
            this.btnSuporte.UseVisualStyleBackColor = true;
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.FlatAppearance.BorderSize = 0;
            this.btnConfiguracoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracoes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConfiguracoes.ForeColor = System.Drawing.Color.White;
            this.btnConfiguracoes.Location = new System.Drawing.Point(0, 200);
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Size = new System.Drawing.Size(200, 50);
            this.btnConfiguracoes.TabIndex = 2;
            this.btnConfiguracoes.Text = "CONFIGURAÇÕES";
            this.btnConfiguracoes.UseVisualStyleBackColor = true;
            // 
            // pnlConteudo (Área onde as telas vão abrir)
            // 
            this.pnlConteudo.BackColor = System.Drawing.Color.White;
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Location = new System.Drawing.Point(200, 0);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Size = new System.Drawing.Size(584, 561);
            this.pnlConteudo.TabIndex = 1;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pnlConteudo);
            this.Controls.Add(this.pnlLateral);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Utilitário Suporte SBR - Menu";
            this.pnlLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogoMenu)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlLateral;
        private System.Windows.Forms.Panel pnlConteudo;
        private System.Windows.Forms.Button btnSuporte;
        private System.Windows.Forms.Button btnConfiguracoes;
        private System.Windows.Forms.PictureBox picLogoMenu;
        private System.Windows.Forms.Label lblTituloMenu;
    }
}