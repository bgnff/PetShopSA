using PetShop.Domain.Entities;
using PetShop.Infrastructure.IoC;

namespace PetShop.UI.Forms;

public partial class FrmCliente : Form
{
    private readonly Cliente? _clienteExistente;

    public bool IsSaved { get; private set; }

    public FrmCliente(Cliente? cliente = null)
    {
        _clienteExistente = cliente;
        InitializeComponent();
        PreencherDados();
    }

    private void PreencherDados()
    {
        if (_clienteExistente != null)
        {
            Text = $"Editar Cliente: {_clienteExistente.Nome}";
            lblTitle.Text = $"Editar: {_clienteExistente.Nome}";
            txtNome.Text = _clienteExistente.Nome;
            txtCPF.Text = _clienteExistente.CPF;
            txtTelefone.Text = _clienteExistente.Telefone;
            txtEmail.Text = _clienteExistente.Email;
            txtCEP.Text = _clienteExistente.CEP;
            txtRua.Text = _clienteExistente.Endereco;
            txtNumero.Text = _clienteExistente.Numero;
            txtComplemento.Text = _clienteExistente.Complemento;
            txtBairro.Text = _clienteExistente.Bairro;
            txtCidade.Text = _clienteExistente.Cidade;
        }
    }

    private void btnSalvar_Click(object? sender, EventArgs e)
    {
        Salvar();
    }

    private void btnCancelar_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    private void Salvar()
    {
        if (string.IsNullOrWhiteSpace(txtNome.Text))
        {
            MostrarErro("Informe o nome completo do cliente.");
            txtNome.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtCPF.Text))
        {
            MostrarErro("Informe o CPF do cliente.");
            txtCPF.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtTelefone.Text))
        {
            MostrarErro("Informe o telefone ou WhatsApp do cliente.");
            txtTelefone.Focus();
            return;
        }

        var repo = ServiceContainer.ClienteRepository;

        if (_clienteExistente == null)
        {
            var novo = new Cliente
            {
                Nome = txtNome.Text.Trim(),
                CPF = txtCPF.Text.Trim(),
                Telefone = txtTelefone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                CEP = txtCEP.Text.Trim(),
                Endereco = txtRua.Text.Trim(),
                Numero = txtNumero.Text.Trim(),
                Complemento = txtComplemento.Text.Trim(),
                Bairro = txtBairro.Text.Trim(),
                Cidade = string.IsNullOrWhiteSpace(txtCidade.Text) ? "São Paulo" : txtCidade.Text.Trim(),
                Ativo = true
            };
            repo.Add(novo);
        }
        else
        {
            _clienteExistente.Nome = txtNome.Text.Trim();
            _clienteExistente.CPF = txtCPF.Text.Trim();
            _clienteExistente.Telefone = txtTelefone.Text.Trim();
            _clienteExistente.Email = txtEmail.Text.Trim();
            _clienteExistente.CEP = txtCEP.Text.Trim();
            _clienteExistente.Endereco = txtRua.Text.Trim();
            _clienteExistente.Numero = txtNumero.Text.Trim();
            _clienteExistente.Complemento = txtComplemento.Text.Trim();
            _clienteExistente.Bairro = txtBairro.Text.Trim();
            _clienteExistente.Cidade = string.IsNullOrWhiteSpace(txtCidade.Text) ? "São Paulo" : txtCidade.Text.Trim();
            repo.Update(_clienteExistente);
        }

        IsSaved = true;
        DialogResult = DialogResult.OK;
    }

    private void MostrarErro(string msg)
    {
        lblError.Text = msg;
        lblError.Visible = true;
    }
}
