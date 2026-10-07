namespace PetShop.UI.Forms;

partial class FrmProduto
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
        this.lblSKU = new System.Windows.Forms.Label();
        this.txtSKU = new System.Windows.Forms.TextBox();
        this.lblCat = new System.Windows.Forms.Label();
        this.cboCategoria = new System.Windows.Forms.ComboBox();
        this.lblMarca = new System.Windows.Forms.Label();
        this.txtMarca = new System.Windows.Forms.TextBox();
        this.lblPreco = new System.Windows.Forms.Label();
        this.numPreco = new System.Windows.Forms.NumericUpDown();
        this.lblQtd = new System.Windows.Forms.Label();
        this.numQtd = new System.Windows.Forms.NumericUpDown();
        this.lblMin = new System.Windows.Forms.Label();
        this.numEstoqueMin = new System.Windows.Forms.NumericUpDown();
        this.lblDesc = new System.Windows.Forms.Label();
        this.txtDescricao = new System.Windows.Forms.TextBox();
        this.pnlHeader.SuspendLayout();
        this.pnlFooter.SuspendLayout();
        this.pnlBody.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numPreco)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numQtd)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numEstoqueMin)).BeginInit();
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
        this.lblTitle.Size = new System.Drawing.Size(161, 30);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "Novo Produto";
        // 
        // lblSub
        // 
        this.lblSub.AutoSize = true;
        this.lblSub.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(116)))), ((int)(((byte)(109)))));
        this.lblSub.Location = new System.Drawing.Point(24, 46);
        this.lblSub.Name = "lblSub";
        this.lblSub.Size = new System.Drawing.Size(430, 15);
        this.lblSub.TabIndex = 1;
        this.lblSub.Text = "Informe os detalhes do produto, categoria, precificação e níveis de estoque.";
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
        this.btnSalvar.Text = "Salvar Produto";
        this.btnSalvar.UseVisualStyleBackColor = false;
        this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
        // 
        // pnlBody
        // 
        this.pnlBody.AutoScroll = true;
        this.pnlBody.Controls.Add(this.lblNome);
        this.pnlBody.Controls.Add(this.txtNome);
        this.pnlBody.Controls.Add(this.lblSKU);
        this.pnlBody.Controls.Add(this.txtSKU);
        this.pnlBody.Controls.Add(this.lblCat);
        this.pnlBody.Controls.Add(this.cboCategoria);
        this.pnlBody.Controls.Add(this.lblMarca);
        this.pnlBody.Controls.Add(this.txtMarca);
        this.pnlBody.Controls.Add(this.lblPreco);
        this.pnlBody.Controls.Add(this.numPreco);
        this.pnlBody.Controls.Add(this.lblQtd);
        this.pnlBody.Controls.Add(this.numQtd);
        this.pnlBody.Controls.Add(this.lblMin);
        this.pnlBody.Controls.Add(this.numEstoqueMin);
        this.pnlBody.Controls.Add(this.lblDesc);
        this.pnlBody.Controls.Add(this.txtDescricao);
        this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlBody.Location = new System.Drawing.Point(0, 75);
        this.pnlBody.Name = "pnlBody";
        this.pnlBody.Padding = new System.Windows.Forms.Padding(24);
        this.pnlBody.Size = new System.Drawing.Size(644, 381);
        this.pnlBody.TabIndex = 1;
        // 
        // lblNome
        // 
        this.lblNome.AutoSize = true;
        this.lblNome.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblNome.Location = new System.Drawing.Point(24, 16);
        this.lblNome.Name = "lblNome";
        this.lblNome.Size = new System.Drawing.Size(126, 17);
        this.lblNome.TabIndex = 0;
        this.lblNome.Text = "Nome do Produto *";
        // 
        // txtNome
        // 
        this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtNome.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtNome.Location = new System.Drawing.Point(24, 38);
        this.txtNome.Name = "txtNome";
        this.txtNome.Size = new System.Drawing.Size(596, 25);
        this.txtNome.TabIndex = 1;
        // 
        // lblSKU
        // 
        this.lblSKU.AutoSize = true;
        this.lblSKU.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblSKU.Location = new System.Drawing.Point(24, 76);
        this.lblSKU.Name = "lblSKU";
        this.lblSKU.Size = new System.Drawing.Size(150, 17);
        this.lblSKU.TabIndex = 2;
        this.lblSKU.Text = "Código SKU / Barras *";
        // 
        // txtSKU
        // 
        this.txtSKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtSKU.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtSKU.Location = new System.Drawing.Point(24, 98);
        this.txtSKU.Name = "txtSKU";
        this.txtSKU.Size = new System.Drawing.Size(285, 25);
        this.txtSKU.TabIndex = 3;
        // 
        // lblCat
        // 
        this.lblCat.AutoSize = true;
        this.lblCat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblCat.Location = new System.Drawing.Point(335, 76);
        this.lblCat.Name = "lblCat";
        this.lblCat.Size = new System.Drawing.Size(77, 17);
        this.lblCat.TabIndex = 4;
        this.lblCat.Text = "Categoria *";
        // 
        // cboCategoria
        // 
        this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboCategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cboCategoria.FormattingEnabled = true;
        this.cboCategoria.Location = new System.Drawing.Point(335, 98);
        this.cboCategoria.Name = "cboCategoria";
        this.cboCategoria.Size = new System.Drawing.Size(285, 25);
        this.cboCategoria.TabIndex = 5;
        // 
        // lblMarca
        // 
        this.lblMarca.AutoSize = true;
        this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblMarca.Location = new System.Drawing.Point(24, 136);
        this.lblMarca.Name = "lblMarca";
        this.lblMarca.Size = new System.Drawing.Size(130, 17);
        this.lblMarca.TabIndex = 6;
        this.lblMarca.Text = "Marca / Fabricante";
        // 
        // txtMarca
        // 
        this.txtMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtMarca.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtMarca.Location = new System.Drawing.Point(24, 158);
        this.txtMarca.Name = "txtMarca";
        this.txtMarca.Size = new System.Drawing.Size(285, 25);
        this.txtMarca.TabIndex = 7;
        // 
        // lblPreco
        // 
        this.lblPreco.AutoSize = true;
        this.lblPreco.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblPreco.Location = new System.Drawing.Point(335, 136);
        this.lblPreco.Name = "lblPreco";
        this.lblPreco.Size = new System.Drawing.Size(155, 17);
        this.lblPreco.TabIndex = 8;
        this.lblPreco.Text = "Preço de Venda (R$) *";
        // 
        // numPreco
        // 
        this.numPreco.DecimalPlaces = 2;
        this.numPreco.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.numPreco.Location = new System.Drawing.Point(335, 158);
        this.numPreco.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        this.numPreco.Name = "numPreco";
        this.numPreco.Size = new System.Drawing.Size(285, 25);
        this.numPreco.TabIndex = 9;
        this.numPreco.Value = new decimal(new int[] { 2990, 0, 0, 131072 });
        // 
        // lblQtd
        // 
        this.lblQtd.AutoSize = true;
        this.lblQtd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblQtd.Location = new System.Drawing.Point(24, 196);
        this.lblQtd.Name = "lblQtd";
        this.lblQtd.Size = new System.Drawing.Size(164, 17);
        this.lblQtd.TabIndex = 10;
        this.lblQtd.Text = "Quantidade em Estoque *";
        // 
        // numQtd
        // 
        this.numQtd.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.numQtd.Location = new System.Drawing.Point(24, 218);
        this.numQtd.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
        this.numQtd.Name = "numQtd";
        this.numQtd.Size = new System.Drawing.Size(285, 25);
        this.numQtd.TabIndex = 11;
        this.numQtd.Value = new decimal(new int[] { 10, 0, 0, 0 });
        // 
        // lblMin
        // 
        this.lblMin.AutoSize = true;
        this.lblMin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblMin.Location = new System.Drawing.Point(335, 196);
        this.lblMin.Name = "lblMin";
        this.lblMin.Size = new System.Drawing.Size(176, 17);
        this.lblMin.TabIndex = 12;
        this.lblMin.Text = "Estoque Mínimo de Alerta *";
        // 
        // numEstoqueMin
        // 
        this.numEstoqueMin.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.numEstoqueMin.Location = new System.Drawing.Point(335, 218);
        this.numEstoqueMin.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        this.numEstoqueMin.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        this.numEstoqueMin.Name = "numEstoqueMin";
        this.numEstoqueMin.Size = new System.Drawing.Size(285, 25);
        this.numEstoqueMin.TabIndex = 13;
        this.numEstoqueMin.Value = new decimal(new int[] { 5, 0, 0, 0 });
        // 
        // lblDesc
        // 
        this.lblDesc.AutoSize = true;
        this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblDesc.Location = new System.Drawing.Point(24, 256);
        this.lblDesc.Name = "lblDesc";
        this.lblDesc.Size = new System.Drawing.Size(130, 17);
        this.lblDesc.TabIndex = 14;
        this.lblDesc.Text = "Descrição Detalhada";
        // 
        // txtDescricao
        // 
        this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtDescricao.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtDescricao.Location = new System.Drawing.Point(24, 278);
        this.txtDescricao.Multiline = true;
        this.txtDescricao.Name = "txtDescricao";
        this.txtDescricao.Size = new System.Drawing.Size(596, 60);
        this.txtDescricao.TabIndex = 15;
        // 
        // FrmProduto
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
        this.Name = "FrmProduto";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Cadastrar Novo Produto";
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.pnlFooter.ResumeLayout(false);
        this.pnlBody.ResumeLayout(false);
        this.pnlBody.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numPreco)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numQtd)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numEstoqueMin)).EndInit();
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
    private System.Windows.Forms.Label lblSKU;
    private System.Windows.Forms.TextBox txtSKU;
    private System.Windows.Forms.Label lblCat;
    private System.Windows.Forms.ComboBox cboCategoria;
    private System.Windows.Forms.Label lblMarca;
    private System.Windows.Forms.TextBox txtMarca;
    private System.Windows.Forms.Label lblPreco;
    private System.Windows.Forms.NumericUpDown numPreco;
    private System.Windows.Forms.Label lblQtd;
    private System.Windows.Forms.NumericUpDown numQtd;
    private System.Windows.Forms.Label lblMin;
    private System.Windows.Forms.NumericUpDown numEstoqueMin;
    private System.Windows.Forms.Label lblDesc;
    private System.Windows.Forms.TextBox txtDescricao;
}
