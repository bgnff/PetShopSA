namespace PetShop.UI.Forms;

partial class FrmPet
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
        this.lblTutor = new System.Windows.Forms.Label();
        this.cboTutor = new System.Windows.Forms.ComboBox();
        this.lblNome = new System.Windows.Forms.Label();
        this.txtNome = new System.Windows.Forms.TextBox();
        this.lblEspecie = new System.Windows.Forms.Label();
        this.cboEspecie = new System.Windows.Forms.ComboBox();
        this.lblRaca = new System.Windows.Forms.Label();
        this.txtRaca = new System.Windows.Forms.TextBox();
        this.lblSexo = new System.Windows.Forms.Label();
        this.cboSexo = new System.Windows.Forms.ComboBox();
        this.lblPorte = new System.Windows.Forms.Label();
        this.cboPorte = new System.Windows.Forms.ComboBox();
        this.lblPeso = new System.Windows.Forms.Label();
        this.numPeso = new System.Windows.Forms.NumericUpDown();
        this.lblNasc = new System.Windows.Forms.Label();
        this.dtpNascimento = new System.Windows.Forms.DateTimePicker();
        this.lblObs = new System.Windows.Forms.Label();
        this.txtObservacoes = new System.Windows.Forms.TextBox();
        this.pnlHeader.SuspendLayout();
        this.pnlFooter.SuspendLayout();
        this.pnlBody.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numPeso)).BeginInit();
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
        this.pnlHeader.Size = new System.Drawing.Size(644, 75);
        this.pnlHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(25)))));
        this.lblTitle.Location = new System.Drawing.Point(24, 14);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(109, 30);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "Novo Pet";
        // 
        // lblSub
        // 
        this.lblSub.AutoSize = true;
        this.lblSub.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(116)))), ((int)(((byte)(109)))));
        this.lblSub.Location = new System.Drawing.Point(24, 46);
        this.lblSub.Name = "lblSub";
        this.lblSub.Size = new System.Drawing.Size(350, 15);
        this.lblSub.TabIndex = 1;
        this.lblSub.Text = "Vincule o tutor e informe as características e cuidados do pet.";
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
        this.pnlFooter.Size = new System.Drawing.Size(644, 65);
        this.pnlFooter.TabIndex = 2;
        // 
        // lblError
        // 
        this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
        this.lblError.Location = new System.Drawing.Point(24, 22);
        this.lblError.Name = "lblError";
        this.lblError.Size = new System.Drawing.Size(340, 20);
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
        this.btnCancelar.Location = new System.Drawing.Point(380, 14);
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
        this.btnSalvar.Location = new System.Drawing.Point(500, 14);
        this.btnSalvar.Name = "btnSalvar";
        this.btnSalvar.Size = new System.Drawing.Size(120, 38);
        this.btnSalvar.TabIndex = 2;
        this.btnSalvar.Text = "Salvar Pet";
        this.btnSalvar.UseVisualStyleBackColor = false;
        this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
        // 
        // pnlBody
        // 
        this.pnlBody.AutoScroll = true;
        this.pnlBody.Controls.Add(this.lblTutor);
        this.pnlBody.Controls.Add(this.cboTutor);
        this.pnlBody.Controls.Add(this.lblNome);
        this.pnlBody.Controls.Add(this.txtNome);
        this.pnlBody.Controls.Add(this.lblEspecie);
        this.pnlBody.Controls.Add(this.cboEspecie);
        this.pnlBody.Controls.Add(this.lblRaca);
        this.pnlBody.Controls.Add(this.txtRaca);
        this.pnlBody.Controls.Add(this.lblSexo);
        this.pnlBody.Controls.Add(this.cboSexo);
        this.pnlBody.Controls.Add(this.lblPorte);
        this.pnlBody.Controls.Add(this.cboPorte);
        this.pnlBody.Controls.Add(this.lblPeso);
        this.pnlBody.Controls.Add(this.numPeso);
        this.pnlBody.Controls.Add(this.lblNasc);
        this.pnlBody.Controls.Add(this.dtpNascimento);
        this.pnlBody.Controls.Add(this.lblObs);
        this.pnlBody.Controls.Add(this.txtObservacoes);
        this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlBody.Location = new System.Drawing.Point(0, 75);
        this.pnlBody.Name = "pnlBody";
        this.pnlBody.Padding = new System.Windows.Forms.Padding(24);
        this.pnlBody.Size = new System.Drawing.Size(644, 381);
        this.pnlBody.TabIndex = 1;
        // 
        // lblTutor
        // 
        this.lblTutor.AutoSize = true;
        this.lblTutor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblTutor.Location = new System.Drawing.Point(24, 16);
        this.lblTutor.Name = "lblTutor";
        this.lblTutor.Size = new System.Drawing.Size(113, 17);
        this.lblTutor.TabIndex = 0;
        this.lblTutor.Text = "Tutor (Cliente) *";
        // 
        // cboTutor
        // 
        this.cboTutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboTutor.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cboTutor.FormattingEnabled = true;
        this.cboTutor.Location = new System.Drawing.Point(24, 38);
        this.cboTutor.Name = "cboTutor";
        this.cboTutor.Size = new System.Drawing.Size(596, 25);
        this.cboTutor.TabIndex = 1;
        // 
        // lblNome
        // 
        this.lblNome.AutoSize = true;
        this.lblNome.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblNome.Location = new System.Drawing.Point(24, 76);
        this.lblNome.Name = "lblNome";
        this.lblNome.Size = new System.Drawing.Size(96, 17);
        this.lblNome.TabIndex = 2;
        this.lblNome.Text = "Nome do Pet *";
        // 
        // txtNome
        // 
        this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtNome.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtNome.Location = new System.Drawing.Point(24, 98);
        this.txtNome.Name = "txtNome";
        this.txtNome.Size = new System.Drawing.Size(285, 25);
        this.txtNome.TabIndex = 3;
        // 
        // lblEspecie
        // 
        this.lblEspecie.AutoSize = true;
        this.lblEspecie.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblEspecie.Location = new System.Drawing.Point(335, 76);
        this.lblEspecie.Name = "lblEspecie";
        this.lblEspecie.Size = new System.Drawing.Size(63, 17);
        this.lblEspecie.TabIndex = 4;
        this.lblEspecie.Text = "Espécie *";
        // 
        // cboEspecie
        // 
        this.cboEspecie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboEspecie.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cboEspecie.FormattingEnabled = true;
        this.cboEspecie.Items.AddRange(new object[] { "Cachorro", "Gato", "Pássaro", "Coelho", "Outro" });
        this.cboEspecie.Location = new System.Drawing.Point(335, 98);
        this.cboEspecie.Name = "cboEspecie";
        this.cboEspecie.Size = new System.Drawing.Size(285, 25);
        this.cboEspecie.TabIndex = 5;
        // 
        // lblRaca
        // 
        this.lblRaca.AutoSize = true;
        this.lblRaca.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblRaca.Location = new System.Drawing.Point(24, 136);
        this.lblRaca.Name = "lblRaca";
        this.lblRaca.Size = new System.Drawing.Size(37, 17);
        this.lblRaca.TabIndex = 6;
        this.lblRaca.Text = "Raça";
        // 
        // txtRaca
        // 
        this.txtRaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtRaca.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtRaca.Location = new System.Drawing.Point(24, 158);
        this.txtRaca.Name = "txtRaca";
        this.txtRaca.Size = new System.Drawing.Size(285, 25);
        this.txtRaca.TabIndex = 7;
        // 
        // lblSexo
        // 
        this.lblSexo.AutoSize = true;
        this.lblSexo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblSexo.Location = new System.Drawing.Point(335, 136);
        this.lblSexo.Name = "lblSexo";
        this.lblSexo.Size = new System.Drawing.Size(37, 17);
        this.lblSexo.TabIndex = 8;
        this.lblSexo.Text = "Sexo";
        // 
        // cboSexo
        // 
        this.cboSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboSexo.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cboSexo.FormattingEnabled = true;
        this.cboSexo.Items.AddRange(new object[] { "Macho", "Fêmea" });
        this.cboSexo.Location = new System.Drawing.Point(335, 158);
        this.cboSexo.Name = "cboSexo";
        this.cboSexo.Size = new System.Drawing.Size(285, 25);
        this.cboSexo.TabIndex = 9;
        // 
        // lblPorte
        // 
        this.lblPorte.AutoSize = true;
        this.lblPorte.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblPorte.Location = new System.Drawing.Point(24, 196);
        this.lblPorte.Name = "lblPorte";
        this.lblPorte.Size = new System.Drawing.Size(41, 17);
        this.lblPorte.TabIndex = 10;
        this.lblPorte.Text = "Porte";
        // 
        // cboPorte
        // 
        this.cboPorte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboPorte.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cboPorte.FormattingEnabled = true;
        this.cboPorte.Items.AddRange(new object[] { "Pequeno", "Médio", "Grande", "Gigante" });
        this.cboPorte.Location = new System.Drawing.Point(24, 218);
        this.cboPorte.Name = "cboPorte";
        this.cboPorte.Size = new System.Drawing.Size(285, 25);
        this.cboPorte.TabIndex = 11;
        // 
        // lblPeso
        // 
        this.lblPeso.AutoSize = true;
        this.lblPeso.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblPeso.Location = new System.Drawing.Point(335, 196);
        this.lblPeso.Name = "lblPeso";
        this.lblPeso.Size = new System.Drawing.Size(66, 17);
        this.lblPeso.TabIndex = 12;
        this.lblPeso.Text = "Peso (kg)";
        // 
        // numPeso
        // 
        this.numPeso.DecimalPlaces = 1;
        this.numPeso.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.numPeso.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        this.numPeso.Location = new System.Drawing.Point(335, 218);
        this.numPeso.Name = "numPeso";
        this.numPeso.Size = new System.Drawing.Size(285, 25);
        this.numPeso.TabIndex = 13;
        this.numPeso.Value = new decimal(new int[] { 50, 0, 0, 65536 });
        // 
        // lblNasc
        // 
        this.lblNasc.AutoSize = true;
        this.lblNasc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblNasc.Location = new System.Drawing.Point(24, 256);
        this.lblNasc.Name = "lblNasc";
        this.lblNasc.Size = new System.Drawing.Size(133, 17);
        this.lblNasc.TabIndex = 14;
        this.lblNasc.Text = "Data de Nascimento";
        // 
        // dtpNascimento
        // 
        this.dtpNascimento.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.dtpNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpNascimento.Location = new System.Drawing.Point(24, 278);
        this.dtpNascimento.Name = "dtpNascimento";
        this.dtpNascimento.Size = new System.Drawing.Size(285, 25);
        this.dtpNascimento.TabIndex = 15;
        // 
        // lblObs
        // 
        this.lblObs.AutoSize = true;
        this.lblObs.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblObs.Location = new System.Drawing.Point(24, 316);
        this.lblObs.Name = "lblObs";
        this.lblObs.Size = new System.Drawing.Size(147, 17);
        this.lblObs.TabIndex = 16;
        this.lblObs.Text = "Observações / Cuidados";
        // 
        // txtObservacoes
        // 
        this.txtObservacoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtObservacoes.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtObservacoes.Location = new System.Drawing.Point(24, 338);
        this.txtObservacoes.Name = "txtObservacoes";
        this.txtObservacoes.Size = new System.Drawing.Size(596, 25);
        this.txtObservacoes.TabIndex = 17;
        // 
        // FrmPet
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(644, 521);
        this.Controls.Add(this.pnlBody);
        this.Controls.Add(this.pnlFooter);
        this.Controls.Add(this.pnlHeader);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FrmPet";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Cadastrar Novo Pet";
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.pnlFooter.ResumeLayout(false);
        this.pnlBody.ResumeLayout(false);
        this.pnlBody.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numPeso)).EndInit();
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
    private System.Windows.Forms.Label lblTutor;
    private System.Windows.Forms.ComboBox cboTutor;
    private System.Windows.Forms.Label lblNome;
    private System.Windows.Forms.TextBox txtNome;
    private System.Windows.Forms.Label lblEspecie;
    private System.Windows.Forms.ComboBox cboEspecie;
    private System.Windows.Forms.Label lblRaca;
    private System.Windows.Forms.TextBox txtRaca;
    private System.Windows.Forms.Label lblSexo;
    private System.Windows.Forms.ComboBox cboSexo;
    private System.Windows.Forms.Label lblPorte;
    private System.Windows.Forms.ComboBox cboPorte;
    private System.Windows.Forms.Label lblPeso;
    private System.Windows.Forms.NumericUpDown numPeso;
    private System.Windows.Forms.Label lblNasc;
    private System.Windows.Forms.DateTimePicker dtpNascimento;
    private System.Windows.Forms.Label lblObs;
    private System.Windows.Forms.TextBox txtObservacoes;
}
