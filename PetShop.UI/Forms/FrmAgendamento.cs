using PetShop.Domain.Entities;
using PetShop.Domain.Enums;
using PetShop.Infrastructure.IoC;

namespace PetShop.UI.Forms;

public partial class FrmAgendamento : Form
{
    private readonly Pet? _petPreselecionado;
    private decimal _valorServico = 50.00m;
    private decimal _valorFrete = 0.00m;

    public bool IsSaved { get; private set; }

    public FrmAgendamento(Pet? petPreselecionado = null)
    {
        _petPreselecionado = petPreselecionado;
        InitializeComponent();
        CarregarDadosIniciais();
    }

    private void CarregarDadosIniciais()
    {
        var clientes = ServiceContainer.ClienteRepository.GetAll().Where(c => c.Ativo).ToList();
        cboCliente.DisplayMember = "Nome";
        cboCliente.ValueMember = "Id";
        cboCliente.DataSource = clientes;

        var servicos = ServiceContainer.ServicoRepository.GetAll().Where(s => s.Ativo).ToList();
        cboServico.DisplayMember = "Nome";
        cboServico.ValueMember = "Id";
        cboServico.DataSource = servicos;

        cboHorario.SelectedIndex = 2; // 09:00

        if (_petPreselecionado != null)
        {
            cboCliente.SelectedValue = _petPreselecionado.ClienteId;
            CarregarPetsDoCliente();
            cboPet.SelectedValue = _petPreselecionado.Id;
        }

        AtualizarValorServico();
    }

    private void cboCliente_SelectedIndexChanged(object? sender, EventArgs e)
    {
        CarregarPetsDoCliente();
    }

    private void CarregarPetsDoCliente()
    {
        if (cboCliente.SelectedItem is Cliente cliente)
        {
            var pets = ServiceContainer.PetRepository.GetByClienteId(cliente.Id).Where(p => p.Ativo).ToList();
            cboPet.DisplayMember = "Nome";
            cboPet.ValueMember = "Id";
            cboPet.DataSource = pets;

            txtEndereco.Text = cliente.EnderecoCompleto;
        }
    }

    private void cboServico_SelectedIndexChanged(object? sender, EventArgs e)
    {
        AtualizarValorServico();
    }

    private void AtualizarValorServico()
    {
        if (cboServico.SelectedItem is Servico servico)
        {
            _valorServico = servico.Preco;
        }
        RecalcularTotais();
    }

    private void chkTaxiDog_CheckedChanged(object? sender, EventArgs e)
    {
        if (chkTaxiDog.Checked)
        {
            _valorFrete = ServiceContainer.FreteService.CalcularFrete(5.0m); // Padrão 5km = R$ 8,00
        }
        else
        {
            _valorFrete = 0.00m;
        }
        RecalcularTotais();
    }

    private void RecalcularTotais()
    {
        decimal total = ServiceContainer.PriceService.CalcularTotalAgendamento(_valorServico, _valorFrete);
        lblValorServico.Text = $"Serviço: R$ {_valorServico:N2}";
        lblValorFrete.Text = $"Frete: R$ {_valorFrete:N2}";
        lblValorTotal.Text = $"TOTAL: R$ {total:N2}";
    }

    private void btnCancelar_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    private void btnConfirmar_Click(object? sender, EventArgs e)
    {
        if (cboCliente.SelectedItem is not Cliente cliente)
        {
            lblError.Text = "Selecione o cliente.";
            lblError.Visible = true;
            return;
        }

        if (cboPet.SelectedItem is not Pet pet)
        {
            lblError.Text = "Selecione o pet a ser atendido.";
            lblError.Visible = true;
            return;
        }

        if (cboServico.SelectedItem is not Servico servico)
        {
            lblError.Text = "Selecione o serviço.";
            lblError.Visible = true;
            return;
        }

        decimal total = ServiceContainer.PriceService.CalcularTotalAgendamento(_valorServico, _valorFrete);

        var agendamento = new Agendamento
        {
            ClienteId = cliente.Id,
            PetId = pet.Id,
            ServicoId = servico.Id,
            Data = dtpData.Value.Date,
            Horario = cboHorario.SelectedItem?.ToString() ?? "09:00",
            ValorServico = _valorServico,
            ValorFrete = _valorFrete,
            ValorTotal = total,
            Status = StatusAgendamento.Confirmado,
            Observacao = txtObservacao.Text.Trim()
        };

        ServiceContainer.AgendamentoRepository.Add(agendamento);
        IsSaved = true;
        DialogResult = DialogResult.OK;
    }
}
