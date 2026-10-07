using System.Drawing;
using System.Windows.Forms;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.IoC;
using PetShop.UI.Controls;
using PetShop.UI.Helpers;

namespace PetShop.UI.Views;

public class UcAtendimentos : UserControl
{
    private DataGridView _dgv = null!;
    private ModernButton _btnHoje = null!;
    private ModernButton _btnSemana = null!;
    private ModernButton _btnMes = null!;
    private string _filtroAtual = "Hoje";

    public UcAtendimentos()
    {
        BuildUI();
        CarregarAtendimentos();
    }

    private void BuildUI()
    {
        Dock = DockStyle.Fill;
        BackColor = UITheme.BackgroundGray;
        Padding = new Padding(24, 20, 24, 24);

        // Cabeçalho
        var pnlHeader = new Panel
        {
            Dock = DockStyle.Top,
            Height = 70,
            BackColor = Color.Transparent
        };

        var lblTitle = new Label
        {
            Text = "Atendimentos em Andamento",
            Font = UITheme.FontTitleLarge,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(0, 0),
            AutoSize = true
        };

        var lblSub = new Label
        {
            Text = "Monitore o fluxo de banho, tosa e consultas veterinárias em execução.",
            Font = UITheme.FontSubtitle,
            ForeColor = UITheme.TextSecondary,
            Location = new Point(0, 32),
            AutoSize = true
        };

        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(lblSub);

        // Barra de Filtros
        var pnlFilters = new Panel
        {
            Dock = DockStyle.Top,
            Height = 52,
            BackColor = Color.Transparent
        };

        _btnHoje = new ModernButton
        {
            Text = "Hoje",
            Style = ModernButtonStyle.Primary,
            Size = new Size(80, 36),
            Location = new Point(0, 8),
            Font = UITheme.FontSmallBold
        };
        _btnHoje.Click += (s, e) => DefinirFiltro("Hoje");

        _btnSemana = new ModernButton
        {
            Text = "Esta Semana",
            Style = ModernButtonStyle.Outline,
            Size = new Size(110, 36),
            Location = new Point(90, 8),
            Font = UITheme.FontSmallBold
        };
        _btnSemana.Click += (s, e) => DefinirFiltro("Semana");

        _btnMes = new ModernButton
        {
            Text = "Este Mês",
            Style = ModernButtonStyle.Outline,
            Size = new Size(95, 36),
            Location = new Point(210, 8),
            Font = UITheme.FontSmallBold
        };
        _btnMes.Click += (s, e) => DefinirFiltro("Mês");

        pnlFilters.Controls.AddRange(new Control[] { _btnHoje, _btnSemana, _btnMes });

        // Tabela
        var cardTable = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(16)
        };

        _dgv = new DataGridView { Dock = DockStyle.Fill };
        UITheme.StyleDataGridView(_dgv);
        ConfigureGrid();

        cardTable.Controls.Add(_dgv);

        // Rodapé de Ações
        var pnlFooter = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 50,
            BackColor = Color.Transparent,
            Padding = new Padding(0, 8, 0, 0)
        };

        var btnFinalizar = new ModernButton
        {
            Text = "Finalizar Atendimento",
            Style = ModernButtonStyle.Primary,
            Size = new Size(180, 36),
            Location = new Point(0, 8),
            Font = UITheme.FontSmallBold
        };
        btnFinalizar.Click += (s, e) => FinalizarSelecionado();

        var btnVisualizar = new ModernButton
        {
            Text = "Ver Observações",
            Style = ModernButtonStyle.Outline,
            Size = new Size(150, 36),
            Location = new Point(190, 8),
            Font = UITheme.FontSmallBold
        };
        btnVisualizar.Click += (s, e) => VerObservacoes();

        pnlFooter.Controls.AddRange(new Control[] { btnFinalizar, btnVisualizar });

        Controls.Add(cardTable);
        Controls.Add(pnlFooter);
        Controls.Add(pnlFilters);
        Controls.Add(pnlHeader);
    }

    private void ConfigureGrid()
    {
        _dgv.Columns.Add("Id", "ID");
        _dgv.Columns.Add("Pet", "Pet");
        _dgv.Columns.Add("Cliente", "Tutor");
        _dgv.Columns.Add("Servico", "Serviço");
        _dgv.Columns.Add("Funcionario", "Profissional");
        _dgv.Columns.Add("Data", "Início");
        _dgv.Columns.Add("Valor", "Valor");
        _dgv.Columns.Add("Status", "Status");

        _dgv.Columns["Id"].Width = 50;
        _dgv.Columns["Pet"].Width = 110;
        _dgv.Columns["Cliente"].Width = 150;
        _dgv.Columns["Servico"].Width = 140;
        _dgv.Columns["Funcionario"].Width = 150;
        _dgv.Columns["Data"].Width = 130;
        _dgv.Columns["Valor"].Width = 90;
        _dgv.Columns["Status"].Width = 130;

        _dgv.CellFormatting += (s, e) =>
        {
            if (e.ColumnIndex == _dgv.Columns["Status"]?.Index && e.Value != null)
            {
                string status = e.Value?.ToString() ?? "";
                if (status == "Em Atendimento")
                {
                    e.CellStyle.ForeColor = UITheme.InfoBlue;
                    e.CellStyle.BackColor = UITheme.InfoBg;
                }
                else
                {
                    e.CellStyle.ForeColor = UITheme.PrimaryGreen;
                    e.CellStyle.BackColor = UITheme.LightGreen;
                }
            }
        };
    }

    private void DefinirFiltro(string filtro)
    {
        _filtroAtual = filtro;
        _btnHoje.Style = filtro == "Hoje" ? ModernButtonStyle.Primary : ModernButtonStyle.Outline;
        _btnSemana.Style = filtro == "Semana" ? ModernButtonStyle.Primary : ModernButtonStyle.Outline;
        _btnMes.Style = filtro == "Mês" ? ModernButtonStyle.Primary : ModernButtonStyle.Outline;
        CarregarAtendimentos();
    }

    public void CarregarAtendimentos()
    {
        var repo = ServiceContainer.AtendimentoRepository;
        var todos = repo.GetAll();

        IEnumerable<Atendimento> filtrados = _filtroAtual switch
        {
            "Hoje" => todos.Where(a => a.DataInicio.Date == DateTime.Today),
            "Semana" => todos.Where(a => a.DataInicio.Date >= DateTime.Today.AddDays(-7)),
            _ => todos.Where(a => a.DataInicio.Month == DateTime.Today.Month && a.DataInicio.Year == DateTime.Today.Year)
        };

        _dgv.Rows.Clear();
        foreach (var a in filtrados)
        {
            _dgv.Rows.Add(
                a.Id,
                a.Pet?.Nome ?? "Pet",
                a.Cliente?.Nome ?? "Tutor",
                a.Servico?.Nome ?? "Serviço",
                a.Funcionario?.Nome ?? "Equipe",
                a.DataInicio.ToString("dd/MM HH:mm"),
                $"R$ {a.Valor:N2}",
                a.Status
            );
        }
    }

    private void FinalizarSelecionado()
    {
        if (_dgv.SelectedRows.Count == 0)
        {
            MessageBox.Show("Selecione um atendimento na tabela.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        int id = Convert.ToInt32(_dgv.SelectedRows[0].Cells["Id"].Value);
        var repo = ServiceContainer.AtendimentoRepository;
        var at = repo.GetById(id);

        if (at != null)
        {
            at.Status = "Finalizado";
            at.DataFim = DateTime.Now;
            repo.Update(at);

            // Atualiza também o agendamento associado se houver
            if (at.AgendamentoId.HasValue)
            {
                var agRepo = ServiceContainer.AgendamentoRepository;
                var ag = agRepo.GetById(at.AgendamentoId.Value);
                if (ag != null)
                {
                    ag.Status = Domain.Enums.StatusAgendamento.Finalizado;
                    agRepo.Update(ag);
                }
            }

            CarregarAtendimentos();
            MessageBox.Show("Atendimento marcado como finalizado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void VerObservacoes()
    {
        if (_dgv.SelectedRows.Count == 0) return;
        int id = Convert.ToInt32(_dgv.SelectedRows[0].Cells["Id"].Value);
        var at = ServiceContainer.AtendimentoRepository.GetById(id);
        if (at != null)
        {
            MessageBox.Show(string.IsNullOrWhiteSpace(at.Observacoes) ? "Nenhuma observação registrada." : at.Observacoes,
                $"Observações - {at.Pet?.Nome}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
