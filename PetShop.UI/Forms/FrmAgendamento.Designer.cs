namespace PetShop.UI.Forms;

partial class FrmAgendamento
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
        this.btnConfirmar = new System.Windows.Forms.Button();
        this.pnlBody = new System.Windows.Forms.Panel();
        this.lblCli = new System.Windows.Forms.Label();
        this.cboCliente = new System.Windows.Forms.ComboBox();
        this.lblPet = new System.Windows.Forms.Label();
        this.cboPet = new System.Windows.Forms.ComboBox();
        this.lblServ = new System.Windows.Forms.Label();
        this.cboServico = new System.Windows.Forms.ComboBox();
        this.lblHorario = new System.Windows.Forms.Label();
        this.cboHorario = new System.Windows.Forms.ComboBox();
        this.lblData = new System.Windows.Forms.Label();
        this.dtpData = new System.Windows.Forms.DateTimePicker();
        this.chkTaxiDog = new System.Windows.Forms.CheckBox();
        this.lblEnd = new System.Windows.Forms.Label();
        this.txtEndereco = new System.Windows.Forms.TextBox();
        this.lblObs = new System.Windows.Forms.Label();
        this.txtObservacao = new System.Windows.Forms.TextBox();
        this.cardValores = new System.Windows.Forms.Panel();
        this.lblValorServico = new System.Windows.Forms.Label();
        this.lblValorFrete = new System.Windows.Forms.Label();
        this.lblValorTotal = new System.Windows.Forms.Label();
        this.pnlHeader.SuspendLayout();
        this.pnlFooter.SuspendLayout();
        this.pnlBody.SuspendLayout();
        this.cardValores.SuspendLayout();
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
        this.lblTitle.Size = new System.Drawing.Size(248, 30);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "Agendar Atendimento";
        // 
        // lblSub
        // 
        this.lblSub.AutoSize = true;
        this.lblSub.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(116)))), ((int)(((byte)(109)))));
        this.lblSub.Location = new System.Drawing.Point(24, 46);
        this.lblSub.Name = "lblSub";
        this.lblSub.Size = new System.Drawing.Size(425, 15);
        this.lblSub.TabIndex = 1;
        this.lblSub.Text = "Selecione o tutor, o pet, o serviço desejado e os dados de transporte.";
        // 
        // pnlFooter
        // 
        this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
        this.pnlFooter.Controls.Add(this.lblError);
        this.pnlFooter.Controls.Add(this.btnCancelar);
        this.pnlFooter.Controls.Add(this.btnConfirmar);
        this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlFooter.Location = new System.Drawing.Point(0, 516);
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
        this.lblError.Size = new System.Drawing.Size(320, 20);
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
        this.btnCancelar.Location = new System.Drawing.Point(360, 14);
        this.btnCancelar.Name = "btnCancelar";
        this.btnCancelar.Size = new System.Drawing.Size(100, 38);
        this.btnCancelar.TabIndex = 1;
        this.btnCancelar.Text = "Cancelar";
        this.btnCancelar.UseVisualStyleBackColor = false;
        this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
        // 
        // btnConfirmar
        // 
        this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(107)))), ((int)(((byte)(58)))));
        this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnConfirmar.FlatAppearance.BorderSize = 0;
        this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnConfirmar.ForeColor = System.Drawing.Color.White;
        this.btnConfirmar.Location = new System.Drawing.Point(470, 14);
        this.btnConfirmar.Name = "btnConfirmar";
        this.btnConfirmar.Size = new System.Drawing.Size(170, 38);
        this.btnConfirmar.TabIndex = 2;
        this.btnConfirmar.Text = "Confirmar Agendamento";
        this.btnConfirmar.UseVisualStyleBackColor = false;
        this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
        // 
        // pnlBody
        // 
        this.pnlBody.AutoScroll = true;
        this.pnlBody.Controls.Add(this.lblCli);
        this.pnlBody.Controls.Add(this.cboCliente);
        this.pnlBody.Controls.Add(this.lblPet);
        this.pnlBody.Controls.Add(this.cboPet);
        this.pnlBody.Controls.Add(this.lblServ);
        this.pnlBody.Controls.Add(this.cboServico);
        this.pnlBody.Controls.Add(this.lblHorario);
        this.pnlBody.Controls.Add(this.cboHorario);
        this.pnlBody.Controls.Add(this.lblData);
        this.pnlBody.Controls.Add(this.dtpData);
        this.pnlBody.Controls.Add(this.chkTaxiDog);
        this.pnlBody.Controls.Add(this.lblEnd);
        this.pnlBody.Controls.Add(this.txtEndereco);
        this.pnlBody.Controls.Add(this.lblObs);
        this.pnlBody.Controls.Add(this.txtObservacao);
        this.pnlBody.Controls.Add(this.cardValores);
        this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlBody.Location = new System.Drawing.Point(0, 75);
        this.pnlBody.Name = "pnlBody";
        this.pnlBody.Padding = new System.Windows.Forms.Padding(24);
        this.pnlBody.Size = new System.Drawing.Size(664, 441);
        this.pnlBody.TabIndex = 1;
        // 
        // lblCli
        // 
        this.lblCli.AutoSize = true;
        this.lblCli.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblCli.Location = new System.Drawing.Point(24, 16);
        this.lblCli.Name = "lblCli";
        this.lblCli.Size = new System.Drawing.Size(116, 17);
        this.lblCli.TabIndex = 0;
        this.lblCli.Text = "Cliente / Tutor *";
        // 
        // cboCliente
        // 
        this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cboCliente.FormattingEnabled = true;
        this.cboCliente.Location = new System.Drawing.Point(24, 38);
        this.cboCliente.Name = "cboCliente";
        this.cboCliente.Size = new System.Drawing.Size(285, 25);
        this.cboCliente.TabIndex = 1;
        this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
        // 
        // lblPet
        // 
        this.lblPet.AutoSize = true;
        this.lblPet.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblPet.Location = new System.Drawing.Point(335, 16);
        this.lblPet.Name = "lblPet";
        this.lblPet.Size = new System.Drawing.Size(41, 17);
        this.lblPet.TabIndex = 2;
        this.lblPet.Text = "Pet *";
        // 
        // cboPet
        // 
        this.cboPet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboPet.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cboPet.FormattingEnabled = true;
        this.cboPet.Location = new System.Drawing.Point(335, 38);
        this.cboPet.Name = "cboPet";
        this.cboPet.Size = new System.Drawing.Size(285, 25);
        this.cboPet.TabIndex = 3;
        // 
        // lblServ
        // 
        this.lblServ.AutoSize = true;
        this.lblServ.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblServ.Location = new System.Drawing.Point(24, 76);
        this.lblServ.Name = "lblServ";
        this.lblServ.Size = new System.Drawing.Size(126, 17);
        this.lblServ.TabIndex = 4;
        this.lblServ.Text = "Serviço Desejado *";
        // 
        // cboServico
        // 
        this.cboServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboServico.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cboServico.FormattingEnabled = true;
        this.cboServico.Location = new System.Drawing.Point(24, 98);
        this.cboServico.Name = "cboServico";
        this.cboServico.Size = new System.Drawing.Size(285, 25);
        this.cboServico.TabIndex = 5;
        this.cboServico.SelectedIndexChanged += new System.EventHandler(this.cboServico_SelectedIndexChanged);
        // 
        // lblHorario
        // 
        this.lblHorario.AutoSize = true;
        this.lblHorario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblHorario.Location = new System.Drawing.Point(335, 76);
        this.lblHorario.Name = "lblHorario";
        this.lblHorario.Size = new System.Drawing.Size(68, 17);
        this.lblHorario.TabIndex = 6;
        this.lblHorario.Text = "Horário *";
        // 
        // cboHorario
        // 
        this.cboHorario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboHorario.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cboHorario.FormattingEnabled = true;
        this.cboHorario.Items.AddRange(new object[] {
            "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00",
            "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00"});
        this.cboHorario.Location = new System.Drawing.Point(335, 98);
        this.cboHorario.Name = "cboHorario";
        this.cboHorario.Size = new System.Drawing.Size(285, 25);
        this.cboHorario.TabIndex = 7;
        // 
        // lblData
        // 
        this.lblData.AutoSize = true;
        this.lblData.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblData.Location = new System.Drawing.Point(24, 136);
        this.lblData.Name = "lblData";
        this.lblData.Size = new System.Drawing.Size(163, 17);
        this.lblData.TabIndex = 8;
        this.lblData.Text = "Data do Agendamento *";
        // 
        // dtpData
        // 
        this.dtpData.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpData.Location = new System.Drawing.Point(24, 158);
        this.dtpData.Name = "dtpData";
        this.dtpData.Size = new System.Drawing.Size(285, 25);
        this.dtpData.TabIndex = 9;
        // 
        // chkTaxiDog
        // 
        this.chkTaxiDog.AutoSize = true;
        this.chkTaxiDog.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.chkTaxiDog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(26)))));
        this.chkTaxiDog.Location = new System.Drawing.Point(24, 200);
        this.chkTaxiDog.Name = "chkTaxiDog";
        this.chkTaxiDog.Size = new System.Drawing.Size(420, 21);
        this.chkTaxiDog.TabIndex = 10;
        this.chkTaxiDog.Text = "Incluir Taxi Dog (Transporte / Frete de Busca e Entrega do Pet)";
        this.chkTaxiDog.UseVisualStyleBackColor = true;
        this.chkTaxiDog.CheckedChanged += new System.EventHandler(this.chkTaxiDog_CheckedChanged);
        // 
        // lblEnd
        // 
        this.lblEnd.AutoSize = true;
        this.lblEnd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblEnd.Location = new System.Drawing.Point(24, 230);
        this.lblEnd.Name = "lblEnd";
        this.lblEnd.Size = new System.Drawing.Size(130, 17);
        this.lblEnd.TabIndex = 11;
        this.lblEnd.Text = "Endereço de Busca:";
        // 
        // txtEndereco
        // 
        this.txtEndereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtEndereco.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtEndereco.Location = new System.Drawing.Point(24, 252);
        this.txtEndereco.Name = "txtEndereco";
        this.txtEndereco.Size = new System.Drawing.Size(596, 25);
        this.txtEndereco.TabIndex = 12;
        // 
        // lblObs
        // 
        this.lblObs.AutoSize = true;
        this.lblObs.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblObs.Location = new System.Drawing.Point(24, 290);
        this.lblObs.Name = "lblObs";
        this.lblObs.Size = new System.Drawing.Size(157, 17);
        this.lblObs.TabIndex = 13;
        this.lblObs.Text = "Observações Adicionais";
        // 
        // txtObservacao
        // 
        this.txtObservacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtObservacao.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtObservacao.Location = new System.Drawing.Point(24, 312);
        this.txtObservacao.Name = "txtObservacao";
        this.txtObservacao.Size = new System.Drawing.Size(596, 25);
        this.txtObservacao.TabIndex = 14;
        // 
        // cardValores
        // 
        this.cardValores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
        this.cardValores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.cardValores.Controls.Add(this.lblValorServico);
        this.cardValores.Controls.Add(this.lblValorFrete);
        this.cardValores.Controls.Add(this.lblValorTotal);
        this.cardValores.Location = new System.Drawing.Point(24, 350);
        this.cardValores.Name = "cardValores";
        this.cardValores.Size = new System.Drawing.Size(596, 60);
        this.cardValores.TabIndex = 15;
        // 
        // lblValorServico
        // 
        this.lblValorServico.AutoSize = true;
        this.lblValorServico.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblValorServico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(26)))));
        this.lblValorServico.Location = new System.Drawing.Point(14, 20);
        this.lblValorServico.Name = "lblValorServico";
        this.lblValorServico.Size = new System.Drawing.Size(107, 17);
        this.lblValorServico.TabIndex = 0;
        this.lblValorServico.Text = "Serviço: R$ 0,00";
        // 
        // lblValorFrete
        // 
        this.lblValorFrete.AutoSize = true;
        this.lblValorFrete.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblValorFrete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(26)))));
        this.lblValorFrete.Location = new System.Drawing.Point(180, 20);
        this.lblValorFrete.Name = "lblValorFrete";
        this.lblValorFrete.Size = new System.Drawing.Size(130, 17);
        this.lblValorFrete.TabIndex = 1;
        this.lblValorFrete.Text = "Frete / Táxi: R$ 0,00";
        // 
        // lblValorTotal
        // 
        this.lblValorTotal.AutoSize = true;
        this.lblValorTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblValorTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(107)))), ((int)(((byte)(58)))));
        this.lblValorTotal.Location = new System.Drawing.Point(380, 15);
        this.lblValorTotal.Name = "lblValorTotal";
        this.lblValorTotal.Size = new System.Drawing.Size(147, 25);
        this.lblValorTotal.TabIndex = 2;
        this.lblValorTotal.Text = "TOTAL: R$ 0,00";
        // 
        // FrmAgendamento
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(664, 581);
        this.Controls.Add(this.pnlBody);
        this.Controls.Add(this.pnlFooter);
        this.Controls.Add(this.pnlHeader);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FrmAgendamento";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Novo Agendamento de Serviço";
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.pnlFooter.ResumeLayout(false);
        this.pnlBody.ResumeLayout(false);
        this.pnlBody.PerformLayout();
        this.cardValores.ResumeLayout(false);
        this.cardValores.PerformLayout();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblSub;
    private System.Windows.Forms.Panel pnlFooter;
    private System.Windows.Forms.Label lblError;
    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.Button btnConfirmar;
    private System.Windows.Forms.Panel pnlBody;
    private System.Windows.Forms.Label lblCli;
    private System.Windows.Forms.ComboBox cboCliente;
    private System.Windows.Forms.Label lblPet;
    private System.Windows.Forms.ComboBox cboPet;
    private System.Windows.Forms.Label lblServ;
    private System.Windows.Forms.ComboBox cboServico;
    private System.Windows.Forms.Label lblHorario;
    private System.Windows.Forms.ComboBox cboHorario;
    private System.Windows.Forms.Label lblData;
    private System.Windows.Forms.DateTimePicker dtpData;
    private System.Windows.Forms.CheckBox chkTaxiDog;
    private System.Windows.Forms.Label lblEnd;
    private System.Windows.Forms.TextBox txtEndereco;
    private System.Windows.Forms.Label lblObs;
    private System.Windows.Forms.TextBox txtObservacao;
    private System.Windows.Forms.Panel cardValores;
    private System.Windows.Forms.Label lblValorServico;
    private System.Windows.Forms.Label lblValorFrete;
    private System.Windows.Forms.Label lblValorTotal;
}
