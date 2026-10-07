namespace PetShop.UI.Forms;

partial class FrmCliente
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
        this.pnlHeader = new System.Windows.Forms.Panel();
        this.lblTitle = new System.Windows.Forms.Label();
        this.lblSub = new System.Windows.Forms.Label();
        this.pnlFooter = new System.Windows.Forms.Panel();
        this.lblError = new System.Windows.Forms.Label();
        this.btnCancelar = new System.Windows.Forms.Button();
        this.btnSalvar = new System.Windows.Forms.Button();
        this.pnlBody = new System.Windows.Forms.Panel();
        this.lblNome = new System.Windows.Forms.Label();
        this.txtNome = new System.Windows.Forms.TextBox();
        this.lblCPF = new System.Windows.Forms.Label();
        this.txtCPF = new System.Windows.Forms.TextBox();
        this.lblTelefone = new System.Windows.Forms.Label();
        this.txtTelefone = new System.Windows.Forms.TextBox();
        this.lblEmail = new System.Windows.Forms.Label();
        this.txtEmail = new System.Windows.Forms.TextBox();
        this.lblCEP = new System.Windows.Forms.Label();
        this.txtCEP = new System.Windows.Forms.TextBox();
        this.lblRua = new System.Windows.Forms.Label();
        this.txtRua = new System.Windows.Forms.TextBox();
        this.lblNumero = new System.Windows.Forms.Label();
        this.txtNumero = new System.Windows.Forms.TextBox();
        this.lblComplemento = new System.Windows.Forms.Label();
        this.txtComplemento = new System.Windows.Forms.TextBox();
        this.lblBairro = new System.Windows.Forms.Label();
        this.txtBairro = new System.Windows.Forms.TextBox();
        this.lblCidade = new System.Windows.Forms.Label();
        this.txtCidade = new System.Windows.Forms.TextBox();
        this.pnlHeader.SuspendLayout();
        this.pnlFooter.SuspendLayout();
        this.pnlBody.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlHeader
        // 
        this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
        this.pnlHeader.Controls.Add(this.lblTitle);
        this.pnlHeader.Controls.Add(this.lblSub);
        this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlHeader.Location = new System.Drawing.Point(0, 0);
        this.pnlHeader.Name = "pnlHeader";
        this.pnlHeader.Size = new System.Drawing.Size(664, 75);
        this.pnlHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(25)))));
        this.lblTitle.Location = new System.Drawing.Point(24, 14);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(151, 30);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "Novo Cliente";
        // 
        // lblSub
        // 
        this.lblSub.AutoSize = true;
        this.lblSub.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(116)))), ((int)(((byte)(109)))));
        this.lblSub.Location = new System.Drawing.Point(24, 46);
        this.lblSub.Name = "lblSub";
        this.lblSub.Size = new System.Drawing.Size(315, 15);
        this.lblSub.TabIndex = 1;
        this.lblSub.Text = "Preencha os dados cadastrais e de endereço do cliente.";
        // 
        // pnlFooter
        // 
        this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
        this.pnlFooter.Controls.Add(this.lblError);
        this.pnlFooter.Controls.Add(this.btnCancelar);
        this.pnlFooter.Controls.Add(this.btnSalvar);
        this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlFooter.Location = new System.Drawing.Point(0, 456);
        this.pnlFooter.Name = "pnlFooter";
        this.pnlFooter.Size = new System.Drawing.Size(664, 65);
        this.pnlFooter.TabIndex = 2;
        // 
        // lblError
        // 
        this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
        this.lblError.Location = new System.Drawing.Point(24, 22);
        this.lblError.Name = "lblError";
        this.lblError.Size = new System.Drawing.Size(350, 20);
        this.lblError.TabIndex = 0;
        this.lblError.Visible = false;
        // 
        // btnCancelar
        // 
        this.btnCancelar.BackColor = System.Drawing.Color.White;
        this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
        this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.btnCancelar.Location = new System.Drawing.Point(400, 14);
        this.btnCancelar.Name = "btnCancelar";
        this.btnCancelar.Size = new System.Drawing.Size(110, 38);
        this.btnCancelar.TabIndex = 1;
        this.btnCancelar.Text = "Cancelar";
        this.btnCancelar.UseVisualStyleBackColor = false;
        this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
        // 
        // btnSalvar
        // 
        this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(107)))), ((int)(((byte)(58)))));
        this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnSalvar.FlatAppearance.BorderSize = 0;
        this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnSalvar.ForeColor = System.Drawing.Color.White;
        this.btnSalvar.Location = new System.Drawing.Point(520, 14);
        this.btnSalvar.Name = "btnSalvar";
        this.btnSalvar.Size = new System.Drawing.Size(120, 38);
        this.btnSalvar.TabIndex = 2;
        this.btnSalvar.Text = "Salvar Cliente";
        this.btnSalvar.UseVisualStyleBackColor = false;
        this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
        // 
        // pnlBody
        // 
        this.pnlBody.AutoScroll = true;
        this.pnlBody.Controls.Add(this.lblNome);
        this.pnlBody.Controls.Add(this.txtNome);
        this.pnlBody.Controls.Add(this.lblCPF);
        this.pnlBody.Controls.Add(this.txtCPF);
        this.pnlBody.Controls.Add(this.lblTelefone);
        this.pnlBody.Controls.Add(this.txtTelefone);
        this.pnlBody.Controls.Add(this.lblEmail);
        this.pnlBody.Controls.Add(this.txtEmail);
        this.pnlBody.Controls.Add(this.lblCEP);
        this.pnlBody.Controls.Add(this.txtCEP);
        this.pnlBody.Controls.Add(this.lblRua);
        this.pnlBody.Controls.Add(this.txtRua);
        this.pnlBody.Controls.Add(this.lblNumero);
        this.pnlBody.Controls.Add(this.txtNumero);
        this.pnlBody.Controls.Add(this.lblComplemento);
        this.pnlBody.Controls.Add(this.txtComplemento);
        this.pnlBody.Controls.Add(this.lblBairro);
        this.pnlBody.Controls.Add(this.txtBairro);
        this.pnlBody.Controls.Add(this.lblCidade);
        this.pnlBody.Controls.Add(this.txtCidade);
        this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlBody.Location = new System.Drawing.Point(0, 75);
        this.pnlBody.Name = "pnlBody";
        this.pnlBody.Padding = new System.Windows.Forms.Padding(24);
        this.pnlBody.Size = new System.Drawing.Size(664, 381);
        this.pnlBody.TabIndex = 1;
        // 
        // lblNome
        // 
        this.lblNome.AutoSize = true;
        this.lblNome.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblNome.Location = new System.Drawing.Point(24, 16);
        this.lblNome.Name = "lblNome";
        this.lblNome.Size = new System.Drawing.Size(120, 17);
        this.lblNome.TabIndex = 0;
        this.lblNome.Text = "Nome Completo *";
        // 
        // txtNome
        // 
        this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtNome.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtNome.Location = new System.Drawing.Point(24, 38);
        this.txtNome.Name = "txtNome";
        this.txtNome.Size = new System.Drawing.Size(616, 25);
        this.txtNome.TabIndex = 1;
        // 
        // lblCPF
        // 
        this.lblCPF.AutoSize = true;
        this.lblCPF.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblCPF.Location = new System.Drawing.Point(24, 76);
        this.lblCPF.Name = "lblCPF";
        this.lblCPF.Size = new System.Drawing.Size(41, 17);
        this.lblCPF.TabIndex = 2;
        this.lblCPF.Text = "CPF *";
        // 
        // txtCPF
        // 
        this.txtCPF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtCPF.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtCPF.Location = new System.Drawing.Point(24, 98);
        this.txtCPF.Name = "txtCPF";
        this.txtCPF.Size = new System.Drawing.Size(295, 25);
        this.txtCPF.TabIndex = 3;
        // 
        // lblTelefone
        // 
        this.lblTelefone.AutoSize = true;
        this.lblTelefone.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblTelefone.Location = new System.Drawing.Point(345, 76);
        this.lblTelefone.Name = "lblTelefone";
        this.lblTelefone.Size = new System.Drawing.Size(155, 17);
        this.lblTelefone.TabIndex = 4;
        this.lblTelefone.Text = "Telefone / WhatsApp *";
        // 
        // txtTelefone
        // 
        this.txtTelefone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtTelefone.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtTelefone.Location = new System.Drawing.Point(345, 98);
        this.txtTelefone.Name = "txtTelefone";
        this.txtTelefone.Size = new System.Drawing.Size(295, 25);
        this.txtTelefone.TabIndex = 5;
        // 
        // lblEmail
        // 
        this.lblEmail.AutoSize = true;
        this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblEmail.Location = new System.Drawing.Point(24, 136);
        this.lblEmail.Name = "lblEmail";
        this.lblEmail.Size = new System.Drawing.Size(47, 17);
        this.lblEmail.TabIndex = 6;
        this.lblEmail.Text = "E-mail";
        // 
        // txtEmail
        // 
        this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtEmail.Location = new System.Drawing.Point(24, 158);
        this.txtEmail.Name = "txtEmail";
        this.txtEmail.Size = new System.Drawing.Size(295, 25);
        this.txtEmail.TabIndex = 7;
        // 
        // lblCEP
        // 
        this.lblCEP.AutoSize = true;
        this.lblCEP.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblCEP.Location = new System.Drawing.Point(345, 136);
        this.lblCEP.Name = "lblCEP";
        this.lblCEP.Size = new System.Drawing.Size(31, 17);
        this.lblCEP.TabIndex = 8;
        this.lblCEP.Text = "CEP";
        // 
        // txtCEP
        // 
        this.txtCEP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtCEP.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtCEP.Location = new System.Drawing.Point(345, 158);
        this.txtCEP.Name = "txtCEP";
        this.txtCEP.Size = new System.Drawing.Size(295, 25);
        this.txtCEP.TabIndex = 9;
        // 
        // lblRua
        // 
        this.lblRua.AutoSize = true;
        this.lblRua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblRua.Location = new System.Drawing.Point(24, 196);
        this.lblRua.Name = "lblRua";
        this.lblRua.Size = new System.Drawing.Size(126, 17);
        this.lblRua.TabIndex = 10;
        this.lblRua.Text = "Rua / Logradouro";
        // 
        // txtRua
        // 
        this.txtRua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtRua.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtRua.Location = new System.Drawing.Point(24, 218);
        this.txtRua.Name = "txtRua";
        this.txtRua.Size = new System.Drawing.Size(430, 25);
        this.txtRua.TabIndex = 11;
        // 
        // lblNumero
        // 
        this.lblNumero.AutoSize = true;
        this.lblNumero.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblNumero.Location = new System.Drawing.Point(470, 196);
        this.lblNumero.Name = "lblNumero";
        this.lblNumero.Size = new System.Drawing.Size(58, 17);
        this.lblNumero.TabIndex = 12;
        this.lblNumero.Text = "Número";
        // 
        // txtNumero
        // 
        this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtNumero.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtNumero.Location = new System.Drawing.Point(470, 218);
        this.txtNumero.Name = "txtNumero";
        this.txtNumero.Size = new System.Drawing.Size(170, 25);
        this.txtNumero.TabIndex = 13;
        // 
        // lblComplemento
        // 
        this.lblComplemento.AutoSize = true;
        this.lblComplemento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblComplemento.Location = new System.Drawing.Point(24, 256);
        this.lblComplemento.Name = "lblComplemento";
        this.lblComplemento.Size = new System.Drawing.Size(95, 17);
        this.lblComplemento.TabIndex = 14;
        this.lblComplemento.Text = "Complemento";
        // 
        // txtComplemento
        // 
        this.txtComplemento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtComplemento.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtComplemento.Location = new System.Drawing.Point(24, 278);
        this.txtComplemento.Name = "txtComplemento";
        this.txtComplemento.Size = new System.Drawing.Size(185, 25);
        this.txtComplemento.TabIndex = 15;
        // 
        // lblBairro
        // 
        this.lblBairro.AutoSize = true;
        this.lblBairro.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblBairro.Location = new System.Drawing.Point(225, 256);
        this.lblBairro.Name = "lblBairro";
        this.lblBairro.Size = new System.Drawing.Size(46, 17);
        this.lblBairro.TabIndex = 16;
        this.lblBairro.Text = "Bairro";
        // 
        // txtBairro
        // 
        this.txtBairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtBairro.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtBairro.Location = new System.Drawing.Point(225, 278);
        this.txtBairro.Name = "txtBairro";
        this.txtBairro.Size = new System.Drawing.Size(195, 25);
        this.txtBairro.TabIndex = 17;
        // 
        // lblCidade
        // 
        this.lblCidade.AutoSize = true;
        this.lblCidade.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblCidade.Location = new System.Drawing.Point(436, 256);
        this.lblCidade.Name = "lblCidade";
        this.lblCidade.Size = new System.Drawing.Size(51, 17);
        this.lblCidade.TabIndex = 18;
        this.lblCidade.Text = "Cidade";
        // 
        // txtCidade
        // 
        this.txtCidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtCidade.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtCidade.Location = new System.Drawing.Point(436, 278);
        this.txtCidade.Name = "txtCidade";
        this.txtCidade.Size = new System.Drawing.Size(204, 25);
        this.txtCidade.TabIndex = 19;
        // 
        // FrmCliente
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(664, 521);
        this.Controls.Add(this.pnlBody);
        this.Controls.Add(this.pnlFooter);
        this.Controls.Add(this.pnlHeader);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FrmCliente";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Cadastrar Novo Cliente";
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.pnlFooter.ResumeLayout(false);
        this.pnlBody.ResumeLayout(false);
        this.pnlBody.PerformLayout();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblSub;
    private System.Windows.Forms.Panel pnlFooter;
    private System.Windows.Forms.Label lblError;
    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.Button btnSalvar;
    private System.Windows.Forms.Panel pnlBody;
    private System.Windows.Forms.Label lblNome;
    private System.Windows.Forms.TextBox txtNome;
    private System.Windows.Forms.Label lblCPF;
    private System.Windows.Forms.TextBox txtCPF;
    private System.Windows.Forms.Label lblTelefone;
    private System.Windows.Forms.TextBox txtTelefone;
    private System.Windows.Forms.Label lblEmail;
    private System.Windows.Forms.TextBox txtEmail;
    private System.Windows.Forms.Label lblCEP;
    private System.Windows.Forms.TextBox txtCEP;
    private System.Windows.Forms.Label lblRua;
    private System.Windows.Forms.TextBox txtRua;
    private System.Windows.Forms.Label lblNumero;
    private System.Windows.Forms.TextBox txtNumero;
    private System.Windows.Forms.Label lblComplemento;
    private System.Windows.Forms.TextBox txtComplemento;
    private System.Windows.Forms.Label lblBairro;
    private System.Windows.Forms.TextBox txtBairro;
    private System.Windows.Forms.Label lblCidade;
    private System.Windows.Forms.TextBox txtCidade;
}
