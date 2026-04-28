namespace UtilitariosSuporte.Features.CaminhoFiscal
{
    partial class FormDirFiscal
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

        #region Código gerado pelo Windows Form Designer

        private void InitializeComponent()
        {
            this.lblTituloInfo = new System.Windows.Forms.Label();
            this.txtDirNFe = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtDirMDFe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirCTe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTituloInfo
            // 
            this.lblTituloInfo.AutoSize = true;
            this.lblTituloInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloInfo.Location = new System.Drawing.Point(30, 30);
            this.lblTituloInfo.Name = "lblTituloInfo";
            this.lblTituloInfo.Size = new System.Drawing.Size(149, 28);
            this.lblTituloInfo.TabIndex = 0;
            this.lblTituloInfo.Text = "Diretório NF-e";
            // 
            // txtDirNFe
            // 
            this.txtDirNFe.BackColor = System.Drawing.Color.White;
            this.txtDirNFe.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirNFe.Location = new System.Drawing.Point(34, 65);
            this.txtDirNFe.Name = "txtDirNFe";
            this.txtDirNFe.Size = new System.Drawing.Size(500, 32);
            this.txtDirNFe.TabIndex = 1;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(35, 453);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(120, 35);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "SALVAR";
            this.btnSalvar.UseVisualStyleBackColor = false;
            // 
            // txtDirMDFe
            // 
            this.txtDirMDFe.BackColor = System.Drawing.Color.White;
            this.txtDirMDFe.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirMDFe.Location = new System.Drawing.Point(34, 141);
            this.txtDirMDFe.Name = "txtDirMDFe";
            this.txtDirMDFe.Size = new System.Drawing.Size(500, 32);
            this.txtDirMDFe.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Diretório MDF-e";
            // 
            // txtDirCTe
            // 
            this.txtDirCTe.BackColor = System.Drawing.Color.White;
            this.txtDirCTe.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirCTe.Location = new System.Drawing.Point(35, 219);
            this.txtDirCTe.Name = "txtDirCTe";
            this.txtDirCTe.Size = new System.Drawing.Size(500, 32);
            this.txtDirCTe.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Diretório CT-e";
            // 
            // FormSuporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.txtDirCTe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDirMDFe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtDirNFe);
            this.Controls.Add(this.lblTituloInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSuporte";
            this.Text = "FormSuporte";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloInfo;
        private System.Windows.Forms.TextBox txtDirNFe;
        private System.Windows.Forms.Button btnSalvar; // Botão adicionado
        private System.Windows.Forms.TextBox txtDirMDFe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirCTe;
        private System.Windows.Forms.Label label2;
    }
}