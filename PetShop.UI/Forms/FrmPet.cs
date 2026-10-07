using PetShop.Domain.Entities;
using PetShop.Infrastructure.IoC;

namespace PetShop.UI.Forms;

public partial class FrmPet : Form
{
    private readonly Pet? _petExistente;
    private readonly int? _clienteIdPreselecionado;

    public bool IsSaved { get; private set; }

    public FrmPet(Pet? pet = null, int? clienteIdPreselecionado = null)
    {
        _petExistente = pet;
        _clienteIdPreselecionado = clienteIdPreselecionado;
        InitializeComponent();
        CarregarTutores();
        PreencherDados();
    }

    private void CarregarTutores()
    {
        var clientes = ServiceContainer.ClienteRepository.GetAll().Where(c => c.Ativo).ToList();
        cboTutor.DisplayMember = "Nome";
        cboTutor.ValueMember = "Id";
        cboTutor.DataSource = clientes;

        if (_clienteIdPreselecionado.HasValue)
        {
            cboTutor.SelectedValue = _clienteIdPreselecionado.Value;
        }
    }

    private void PreencherDados()
    {
        if (_petExistente != null)
        {
            Text = $"Editar Pet: {_petExistente.Nome}";
            lblTitle.Text = $"Editar: {_petExistente.Nome}";
            cboTutor.SelectedValue = _petExistente.ClienteId;
            txtNome.Text = _petExistente.Nome;
            cboEspecie.SelectedItem = _petExistente.Especie;
            txtRaca.Text = _petExistente.Raca;
            cboSexo.SelectedItem = _petExistente.Sexo;
            cboPorte.SelectedItem = _petExistente.Porte;
            numPeso.Value = _petExistente.Peso > 0 ? _petExistente.Peso : 5.0m;
            if (_petExistente.DataNascimento.HasValue)
                dtpNascimento.Value = _petExistente.DataNascimento.Value;
            txtObservacoes.Text = _petExistente.Observacoes;
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
            MostrarErro("Informe o nome do pet.");
            txtNome.Focus();
            return;
        }

        if (cboTutor.SelectedItem is not Cliente clienteSelecionado)
        {
            MostrarErro("Selecione o tutor responsável pelo pet.");
            return;
        }

        var repo = ServiceContainer.PetRepository;

        if (_petExistente == null)
        {
            var novo = new Pet
            {
                ClienteId = clienteSelecionado.Id,
                Nome = txtNome.Text.Trim(),
                Especie = cboEspecie.SelectedItem?.ToString() ?? "Cachorro",
                Raca = txtRaca.Text.Trim(),
                Sexo = cboSexo.SelectedItem?.ToString() ?? "Macho",
                Porte = cboPorte.SelectedItem?.ToString() ?? "Médio",
                Peso = numPeso.Value,
                DataNascimento = dtpNascimento.Value,
                Observacoes = txtObservacoes.Text.Trim(),
                Ativo = true
            };
            repo.Add(novo);
        }
        else
        {
            _petExistente.ClienteId = clienteSelecionado.Id;
            _petExistente.Nome = txtNome.Text.Trim();
            _petExistente.Especie = cboEspecie.SelectedItem?.ToString() ?? "Cachorro";
            _petExistente.Raca = txtRaca.Text.Trim();
            _petExistente.Sexo = cboSexo.SelectedItem?.ToString() ?? "Macho";
            _petExistente.Porte = cboPorte.SelectedItem?.ToString() ?? "Médio";
            _petExistente.Peso = numPeso.Value;
            _petExistente.DataNascimento = dtpNascimento.Value;
            _petExistente.Observacoes = txtObservacoes.Text.Trim();
            repo.Update(_petExistente);
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
