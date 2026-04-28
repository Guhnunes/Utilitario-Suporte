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
            this.btnSuporte = new System.Windows.Forms.Button();
            this.picLogoMenu = new System.Windows.Forms.PictureBox();
            this.pnlConteudo = new System.Windows.Forms.Panel();
            this.lblTituloMenu = new System.Windows.Forms.Label();
            this.pnlLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLateral
            // 
            this.pnlLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlLateral.Controls.Add(this.btnSuporte);
            this.pnlLateral.Controls.Add(this.picLogoMenu);
            this.pnlLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLateral.Location = new System.Drawing.Point(0, 0);
            this.pnlLateral.Name = "pnlLateral";
            this.pnlLateral.Size = new System.Drawing.Size(229, 598);
            this.pnlLateral.TabIndex = 0;
            // 
            // btnSuporte
            // 
            this.btnSuporte.FlatAppearance.BorderSize = 0;
            this.btnSuporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuporte.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSuporte.ForeColor = System.Drawing.Color.White;
            this.btnSuporte.Location = new System.Drawing.Point(0, 160);
            this.btnSuporte.Name = "btnSuporte";
            this.btnSuporte.Size = new System.Drawing.Size(229, 53);
            this.btnSuporte.TabIndex = 1;
            this.btnSuporte.Text = "Diretórios Fiscais";
            this.btnSuporte.UseVisualStyleBackColor = true;
            // 
            // picLogoMenu
            // 
            this.picLogoMenu.Image = global::UtilitariosSuporte.Properties.Resources.SBRlogo;
            this.picLogoMenu.Location = new System.Drawing.Point(29, 21);
            this.picLogoMenu.Name = "picLogoMenu";
            this.picLogoMenu.Size = new System.Drawing.Size(171, 107);
            this.picLogoMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoMenu.TabIndex = 0;
            this.picLogoMenu.TabStop = false;
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.BackColor = System.Drawing.Color.White;
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Location = new System.Drawing.Point(229, 0);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Size = new System.Drawing.Size(667, 598);
            this.pnlConteudo.TabIndex = 1;
            // 
            // lblTituloMenu
            // 
            this.lblTituloMenu.Location = new System.Drawing.Point(0, 0);
            this.lblTituloMenu.Name = "lblTituloMenu";
            this.lblTituloMenu.Size = new System.Drawing.Size(100, 23);
            this.lblTituloMenu.TabIndex = 0;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 598);
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
        private System.Windows.Forms.PictureBox picLogoMenu;
        private System.Windows.Forms.Label lblTituloMenu;
    }
}