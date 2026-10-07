namespace PetShop.UI.Forms;

partial class FrmLogin
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
        splitTable = new TableLayoutPanel();
        leftPanel = new Panel();
        picHero = new PictureBox();
        lblFooterLeft = new Label();
        lblTagline = new Label();
        lblLogo = new Label();
        rightContainer = new Panel();
        lblWelcome = new Label();
        lblSubWelcome = new Label();
        lblUsuario = new Label();
        txtUsuario = new TextBox();
        lblSenha = new Label();
        txtSenha = new TextBox();
        chkLembrar = new CheckBox();
        lblError = new Label();
        btnEntrar = new Button();
        lblHint = new Label();
        splitTable.SuspendLayout();
        leftPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picHero).BeginInit();
        rightContainer.SuspendLayout();
        SuspendLayout();
        // 
        // splitTable
        // 
        splitTable.ColumnCount = 2;
        splitTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        splitTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        splitTable.Controls.Add(leftPanel, 0, 0);
        splitTable.Controls.Add(rightContainer, 1, 0);
        splitTable.Dock = DockStyle.Fill;
        splitTable.Location = new Point(0, 0);
        splitTable.Name = "splitTable";
        splitTable.RowCount = 1;
        splitTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        splitTable.Size = new Size(864, 521);
        splitTable.TabIndex = 0;
        // 
        // leftPanel
        // 
        leftPanel.BackColor = Color.FromArgb(232, 241, 235);
        leftPanel.Controls.Add(picHero);
        leftPanel.Controls.Add(lblFooterLeft);
        leftPanel.Controls.Add(lblTagline);
        leftPanel.Controls.Add(lblLogo);
        leftPanel.Dock = DockStyle.Fill;
        leftPanel.Location = new Point(0, 0);
        leftPanel.Margin = new Padding(0);
        leftPanel.Name = "leftPanel";
        leftPanel.Padding = new Padding(24);
        leftPanel.Size = new Size(414, 521);
        leftPanel.TabIndex = 0;
        // 
        // picHero
        // 
        picHero.Dock = DockStyle.Fill;
        picHero.Location = new Point(24, 109);
        picHero.Name = "picHero";
        picHero.Size = new Size(366, 363);
        picHero.SizeMode = PictureBoxSizeMode.Zoom;
        picHero.TabIndex = 2;
        picHero.TabStop = false;
        // 
        // lblFooterLeft
        // 
        lblFooterLeft.Dock = DockStyle.Bottom;
        lblFooterLeft.Font = new Font("Segoe UI", 8.5F);
        lblFooterLeft.ForeColor = Color.FromArgb(139, 153, 144);
        lblFooterLeft.Location = new Point(24, 472);
        lblFooterLeft.Name = "lblFooterLeft";
        lblFooterLeft.Size = new Size(366, 25);
        lblFooterLeft.TabIndex = 3;
        lblFooterLeft.Text = "v1.0 • .NET 8 WinForms • Database Ready";
        lblFooterLeft.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTagline
        // 
        lblTagline.Dock = DockStyle.Top;
        lblTagline.Font = new Font("Segoe UI", 10F);
        lblTagline.ForeColor = Color.FromArgb(107, 116, 109);
        lblTagline.Location = new Point(24, 64);
        lblTagline.Name = "lblTagline";
        lblTagline.Size = new Size(366, 45);
        lblTagline.TabIndex = 1;
        lblTagline.Text = "Gestão inteligente, acolhedora e completa para o cuidado dos pets.";
        // 
        // lblLogo
        // 
        lblLogo.Dock = DockStyle.Top;
        lblLogo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblLogo.ForeColor = Color.FromArgb(7, 59, 26);
        lblLogo.Location = new Point(24, 24);
        lblLogo.Name = "lblLogo";
        lblLogo.Size = new Size(366, 40);
        lblLogo.TabIndex = 0;
        lblLogo.Text = "🐾 PetShop Manager";
        lblLogo.Click += lblLogo_Click;
        // 
        // rightContainer
        // 
        rightContainer.BackColor = Color.White;
        rightContainer.Controls.Add(lblWelcome);
        rightContainer.Controls.Add(lblSubWelcome);
        rightContainer.Controls.Add(lblUsuario);
        rightContainer.Controls.Add(txtUsuario);
        rightContainer.Controls.Add(lblSenha);
        rightContainer.Controls.Add(txtSenha);
        rightContainer.Controls.Add(chkLembrar);
        rightContainer.Controls.Add(lblError);
        rightContainer.Controls.Add(btnEntrar);
        rightContainer.Controls.Add(lblHint);
        rightContainer.Dock = DockStyle.Fill;
        rightContainer.Location = new Point(414, 0);
        rightContainer.Margin = new Padding(0);
        rightContainer.Name = "rightContainer";
        rightContainer.Padding = new Padding(40);
        rightContainer.Size = new Size(450, 521);
        rightContainer.TabIndex = 1;
        // 
        // lblWelcome
        // 
        lblWelcome.AutoSize = true;
        lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblWelcome.ForeColor = Color.FromArgb(23, 32, 25);
        lblWelcome.Location = new Point(75, 40);
        lblWelcome.Name = "lblWelcome";
        lblWelcome.Size = new Size(274, 32);
        lblWelcome.TabIndex = 0;
        lblWelcome.Text = "Bem-vindo novamente";
        // 
        // lblSubWelcome
        // 
        lblSubWelcome.AutoSize = true;
        lblSubWelcome.Font = new Font("Segoe UI", 10F);
        lblSubWelcome.ForeColor = Color.FromArgb(107, 116, 109);
        lblSubWelcome.Location = new Point(61, 72);
        lblSubWelcome.Name = "lblSubWelcome";
        lblSubWelcome.Size = new Size(307, 19);
        lblSubWelcome.TabIndex = 1;
        lblSubWelcome.Text = "Acesse o sistema de gerenciamento do Pet Shop.";
        // 
        // lblUsuario
        // 
        lblUsuario.AutoSize = true;
        lblUsuario.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblUsuario.ForeColor = Color.FromArgb(23, 32, 25);
        lblUsuario.Location = new Point(42, 120);
        lblUsuario.Name = "lblUsuario";
        lblUsuario.Size = new Size(118, 17);
        lblUsuario.TabIndex = 2;
        lblUsuario.Text = "Usuário ou E-mail";
        // 
        // txtUsuario
        // 
        txtUsuario.BorderStyle = BorderStyle.FixedSingle;
        txtUsuario.Font = new Font("Segoe UI", 10.5F);
        txtUsuario.Location = new Point(42, 140);
        txtUsuario.Name = "txtUsuario";
        txtUsuario.Size = new Size(340, 26);
        txtUsuario.TabIndex = 3;
        txtUsuario.Text = "admin";
        // 
        // lblSenha
        // 
        lblSenha.AutoSize = true;
        lblSenha.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblSenha.ForeColor = Color.FromArgb(23, 32, 25);
        lblSenha.Location = new Point(42, 195);
        lblSenha.Name = "lblSenha";
        lblSenha.Size = new Size(45, 17);
        lblSenha.TabIndex = 4;
        lblSenha.Text = "Senha";
        // 
        // txtSenha
        // 
        txtSenha.BorderStyle = BorderStyle.FixedSingle;
        txtSenha.Font = new Font("Segoe UI", 10.5F);
        txtSenha.Location = new Point(42, 220);
        txtSenha.Name = "txtSenha";
        txtSenha.Size = new Size(340, 26);
        txtSenha.TabIndex = 5;
        txtSenha.Text = "admin123";
        txtSenha.UseSystemPasswordChar = true;
        // 
        // chkLembrar
        // 
        chkLembrar.AutoSize = true;
        chkLembrar.Checked = true;
        chkLembrar.CheckState = CheckState.Checked;
        chkLembrar.Font = new Font("Segoe UI", 9F);
        chkLembrar.ForeColor = Color.FromArgb(107, 116, 109);
        chkLembrar.Location = new Point(42, 265);
        chkLembrar.Name = "chkLembrar";
        chkLembrar.Size = new Size(112, 19);
        chkLembrar.TabIndex = 6;
        chkLembrar.Text = "Lembrar usuário";
        chkLembrar.UseVisualStyleBackColor = true;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblError.ForeColor = Color.FromArgb(220, 38, 38);
        lblError.Location = new Point(42, 295);
        lblError.Name = "lblError";
        lblError.Size = new Size(340, 20);
        lblError.TabIndex = 7;
        lblError.Text = "Usuário ou senha inválidos.";
        lblError.Visible = false;
        // 
        // btnEntrar
        // 
        btnEntrar.BackColor = Color.FromArgb(21, 107, 58);
        btnEntrar.Cursor = Cursors.Hand;
        btnEntrar.FlatAppearance.BorderSize = 0;
        btnEntrar.FlatStyle = FlatStyle.Flat;
        btnEntrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnEntrar.ForeColor = Color.White;
        btnEntrar.Location = new Point(42, 325);
        btnEntrar.Name = "btnEntrar";
        btnEntrar.Size = new Size(340, 44);
        btnEntrar.TabIndex = 8;
        btnEntrar.Text = "Entrar no Sistema";
        btnEntrar.UseVisualStyleBackColor = false;
        btnEntrar.Click += btnEntrar_Click;
        // 
        // lblHint
        // 
        lblHint.Font = new Font("Segoe UI", 8.5F);
        lblHint.ForeColor = Color.FromArgb(148, 163, 184);
        lblHint.Location = new Point(42, 385);
        lblHint.Name = "lblHint";
        lblHint.Size = new Size(340, 20);
        lblHint.TabIndex = 9;
        lblHint.Text = "Credenciais de Teste: admin / admin123";
        lblHint.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // FrmLogin
        // 
        AcceptButton = btnEntrar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(246, 247, 248);
        ClientSize = new Size(864, 521);
        Controls.Add(splitTable);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "PetShop Manager - Acesso ao Sistema";
        splitTable.ResumeLayout(false);
        leftPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)picHero).EndInit();
        rightContainer.ResumeLayout(false);
        rightContainer.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.TableLayoutPanel splitTable;
    private System.Windows.Forms.Panel leftPanel;
    private System.Windows.Forms.Label lblLogo;
    private System.Windows.Forms.Label lblTagline;
    private System.Windows.Forms.PictureBox picHero;
    private System.Windows.Forms.Label lblFooterLeft;
    private System.Windows.Forms.Panel rightContainer;
    private System.Windows.Forms.Label lblWelcome;
    private System.Windows.Forms.Label lblSubWelcome;
    private System.Windows.Forms.Label lblUsuario;
    private System.Windows.Forms.TextBox txtUsuario;
    private System.Windows.Forms.Label lblSenha;
    private System.Windows.Forms.TextBox txtSenha;
    private System.Windows.Forms.CheckBox chkLembrar;
    private System.Windows.Forms.Label lblError;
    private System.Windows.Forms.Button btnEntrar;
    private System.Windows.Forms.Label lblHint;
}
