using System.Drawing;
using System.Windows.Forms;
using PetShop.Domain.Entities;
using PetShop.Domain.Enums;
using PetShop.Infrastructure.IoC;
using PetShop.UI.Controls;
using PetShop.UI.Forms;
using PetShop.UI.Helpers;

namespace PetShop.UI.Views;

public class UcAgenda : UserControl
{
    private DateTime _dataSelecionada = DateTime.Today;
    private Label _lblDataExibida = null!;
    private DataGridView _dgv = null!;
    private ModernButton _btnModoDia = null!;
    private ModernButton _btnModoSemana = null!;
    private ModernButton _btnModoMes = null!;
    private string _modoVisualizacao = "Dia";

    public UcAgenda()
    {
        BuildUI();
        CarregarAgendamentos();
    }

    private void BuildUI()
    {
        Dock = DockStyle.Fill;
        BackColor = UITheme.BackgroundGray;
        Padding = new Padding(24, 20, 24, 24);

        // Cabeçalho Principal
        var pnlHeader = new Panel
        {
            Dock = DockStyle.Top,
            Height = 70,
            BackColor = Color.Transparent
        };

        var lblTitle = new Label
        {
            Text = "Agenda de Serviços",
            Font = UITheme.FontTitleLarge,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(0, 0),
            AutoSize = true
        };

        var lblSub = new Label
        {
            Text = "Consulte horários marcados, organize a equipe e realize novos agendamentos.",
            Font = UITheme.FontSubtitle,
            ForeColor = UITheme.TextSecondary,
            Location = new Point(0, 32),
            AutoSize = true
        };

        var btnNovo = new ModernButton
        {
            Text = "+ Novo Agendamento",
            Style = ModernButtonStyle.Primary,
            Size = new Size(180, 42),
            Location = new Point(pnlHeader.Width - 190, 10),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Font = UITheme.FontBodyBold
        };
        btnNovo.Click += (s, e) => AbrirNovoAgendamento();

        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(lblSub);
        pnlHeader.Controls.Add(btnNovo);

        // Barra de Ferramentas / Navegação de Datas e Modos
        var pnlToolbar = new Panel
        {
            Dock = DockStyle.Top,
            Height = 56,
            BackColor = Color.Transparent
        };

        // Botões Anterior / Hoje / Próximo
        var btnPrev = new ModernButton
        {
            Text = "◀",
            Style = ModernButtonStyle.Outline,
            Size = new Size(42, 38),
            Location = new Point(0, 8),
            Font = UITheme.FontSmallBold
        };
        btnPrev.Click += (s, e) => NavegarData(-1);

        _lblDataExibida = new Label
        {
            Text = _dataSelecionada.ToString("dddd, dd 'de' MMMM 'de' yyyy"),
            Font = UITheme.FontTitle,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(50, 12),
            AutoSize = true
        };

        var btnNext = new ModernButton
        {
            Text = "▶",
            Style = ModernButtonStyle.Outline,
            Size = new Size(42, 38),
            Location = new Point(360, 8),
            Font = UITheme.FontSmallBold
        };
        btnNext.Click += (s, e) => NavegarData(1);

        var btnHoje = new ModernButton
        {
            Text = "Hoje",
            Style = ModernButtonStyle.Secondary,
            Size = new Size(70, 38),
            Location = new Point(410, 8),
            Font = UITheme.FontSmallBold
        };
        btnHoje.Click += (s, e) => { _dataSelecionada = DateTime.Today; AtualizarDataLabel(); CarregarAgendamentos(); };

        // Toggle Dia / Semana / Mês na direita
        _btnModoDia = new ModernButton
        {
            Text = "Dia",
            Style = ModernButtonStyle.Primary,
            Size = new Size(70, 36),
            Location = new Point(pnlToolbar.Width - 230, 8),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Font = UITheme.FontSmallBold
        };
        _btnModoDia.Click += (s, e) => DefinirModo("Dia");

        _btnModoSemana = new ModernButton
        {
            Text = "Semana",
            Style = ModernButtonStyle.Outline,
            Size = new Size(75, 36),
            Location = new Point(pnlToolbar.Width - 152, 8),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Font = UITheme.FontSmallBold
        };
        _btnModoSemana.Click += (s, e) => DefinirModo("Semana");

        _btnModoMes = new ModernButton
        {
            Text = "Mês",
            Style = ModernButtonStyle.Outline,
            Size = new Size(70, 36),
            Location = new Point(pnlToolbar.Width - 72, 8),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Font = UITheme.FontSmallBold
        };
        _btnModoMes.Click += (s, e) => DefinirModo("Mês");

        pnlToolbar.Controls.AddRange(new Control[] { btnPrev, _lblDataExibida, btnNext, btnHoje, _btnModoDia, _btnModoSemana, _btnModoMes });

        // Tabela de Agendamentos
        var cardTable = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(16)
        };

        _dgv = new DataGridView { Dock = DockStyle.Fill };
        UITheme.StyleDataGridView(_dgv);
        ConfigureGrid();

        cardTable.Controls.Add(_dgv);

        // Rodapé de Ações de Status
        var pnlFooter = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 50,
            BackColor = Color.Transparent,
            Padding = new Padding(0, 8, 0, 0)
        };

        var btnIniciar = new ModernButton
        {
            Text = "Iniciar Atendimento",
            Style = ModernButtonStyle.Accent,
            Size = new Size(160, 36),
            Location = new Point(0, 8),
            Font = UITheme.FontSmallBold
        };
        btnIniciar.Click += (s, e) => AlterarStatusSelecionado(StatusAgendamento.EmAtendimento);

        var btnFinalizar = new ModernButton
        {
            Text = "Concluir / Finalizar",
            Style = ModernButtonStyle.Primary,
            Size = new Size(160, 36),
            Location = new Point(170, 8),
            Font = UITheme.FontSmallBold
        };
        btnFinalizar.Click += (s, e) => AlterarStatusSelecionado(StatusAgendamento.Finalizado);

        var btnCancelar = new ModernButton
        {
            Text = "Cancelar Agendamento",
            Style = ModernButtonStyle.Outline,
            Size = new Size(160, 36),
            Location = new Point(340, 8),
            Font = UITheme.FontSmallBold
        };
        btnCancelar.Click += (s, e) => AlterarStatusSelecionado(StatusAgendamento.Cancelado);

        pnlFooter.Controls.AddRange(new Control[] { btnIniciar, btnFinalizar, btnCancelar });

        Controls.Add(cardTable);
        Controls.Add(pnlFooter);
        Controls.Add(pnlToolbar);
        Controls.Add(pnlHeader);
    }

    private void ConfigureGrid()
    {
        _dgv.Columns.Add("Id", "ID");
        _dgv.Columns.Add("Data", "Data");
        _dgv.Columns.Add("Horario", "Horário");
        _dgv.Columns.Add("Pet", "Pet");
        _dgv.Columns.Add("Cliente", "Cliente");
        _dgv.Columns.Add("Servico", "Serviço");
        _dgv.Columns.Add("Valor", "Total");
        _dgv.Columns.Add("Transporte", "Taxi Dog");
        _dgv.Columns.Add("Status", "Status");

        _dgv.Columns["Id"].Width = 50;
        _dgv.Columns["Data"].Width = 90;
        _dgv.Columns["Horario"].Width = 80;
        _dgv.Columns["Pet"].Width = 110;
        _dgv.Columns["Cliente"].Width = 160;
        _dgv.Columns["Servico"].Width = 150;
        _dgv.Columns["Valor"].Width = 95;
        _dgv.Columns["Transporte"].Width = 90;
        _dgv.Columns["Status"].Width = 130;

        _dgv.CellFormatting += (s, e) =>
        {
            if (e.ColumnIndex == _dgv.Columns["Status"]?.Index && e.Value != null)
            {
                string status = e.Value?.ToString() ?? "";
                if (status == "Confirmado")
                {
                    e.CellStyle.ForeColor = UITheme.PrimaryGreen;
                    e.CellStyle.BackColor = UITheme.LightGreen;
                }
                else if (status == "EmAtendimento")
                {
                    e.CellStyle.ForeColor = UITheme.InfoBlue;
                    e.CellStyle.BackColor = UITheme.InfoBg;
                }
                else if (status == "Pendente")
                {
                    e.CellStyle.ForeColor = UITheme.WarningYellow;
                    e.CellStyle.BackColor = UITheme.WarningBg;
                }
                else if (status == "Cancelado")
                {
                    e.CellStyle.ForeColor = UITheme.DangerRed;
                    e.CellStyle.BackColor = UITheme.DangerBg;
                }
                else // Finalizado
                {
                    e.CellStyle.ForeColor = ColorTranslator.FromHtml("#475569");
                    e.CellStyle.BackColor = ColorTranslator.FromHtml("#F1F5F9");
                }
            }
        };
    }

    private void DefinirModo(string modo)
    {
        _modoVisualizacao = modo;
        _btnModoDia.Style = modo == "Dia" ? ModernButtonStyle.Primary : ModernButtonStyle.Outline;
        _btnModoSemana.Style = modo == "Semana" ? ModernButtonStyle.Primary : ModernButtonStyle.Outline;
        _btnModoMes.Style = modo == "Mês" ? ModernButtonStyle.Primary : ModernButtonStyle.Outline;
        CarregarAgendamentos();
    }

    private void NavegarData(int dias)
    {
        if (_modoVisualizacao == "Dia")
            _dataSelecionada = _dataSelecionada.AddDays(dias);
        else if (_modoVisualizacao == "Semana")
            _dataSelecionada = _dataSelecionada.AddDays(dias * 7);
        else
            _dataSelecionada = _dataSelecionada.AddMonths(dias);

        AtualizarDataLabel();
        CarregarAgendamentos();
    }

    private void AtualizarDataLabel()
    {
        _lblDataExibida.Text = _dataSelecionada.ToString("dddd, dd 'de' MMMM 'de' yyyy");
    }

    public void CarregarAgendamentos()
    {
        var repo = ServiceContainer.AgendamentoRepository;
        IEnumerable<Agendamento> agendamentos;

        if (_modoVisualizacao == "Dia")
        {
            agendamentos = repo.GetByData(_dataSelecionada);
        }
        else if (_modoVisualizacao == "Semana")
        {
            var inicioSemana = _dataSelecionada.AddDays(-(int)_dataSelecionada.DayOfWeek);
            var fimSemana = inicioSemana.AddDays(7);
            agendamentos = repo.GetAll().Where(a => a.Data.Date >= inicioSemana.Date && a.Data.Date <= fimSemana.Date);
        }
        else
        {
            agendamentos = repo.GetAll().Where(a => a.Data.Month == _dataSelecionada.Month && a.Data.Year == _dataSelecionada.Year);
        }

        _dgv.Rows.Clear();
        foreach (var a in agendamentos)
        {
            _dgv.Rows.Add(
                a.Id,
                a.Data.ToString("dd/MM/yyyy"),
                a.Horario,
                a.Pet?.Nome ?? "Pet",
                a.Cliente?.Nome ?? "Cliente",
                a.Servico?.Nome ?? "Serviço",
                $"R$ {a.ValorTotal:N2}",
                a.ValorFrete > 0 ? "Sim" : "Não",
                a.Status.ToString()
            );
        }
    }

    private void AlterarStatusSelecionado(StatusAgendamento novoStatus)
    {
        if (_dgv.SelectedRows.Count == 0)
        {
            MessageBox.Show("Selecione um agendamento na tabela para alterar o status.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        int id = Convert.ToInt32(_dgv.SelectedRows[0].Cells["Id"].Value);
        var repo = ServiceContainer.AgendamentoRepository;
        var agendamento = repo.GetById(id);

        if (agendamento != null)
        {
            agendamento.Status = novoStatus;
            repo.Update(agendamento);

            // Se alterado para EmAtendimento, cria o registro em Atendimentos caso não exista
            if (novoStatus == StatusAgendamento.EmAtendimento)
            {
                var atRepo = ServiceContainer.AtendimentoRepository;
                atRepo.Add(new Atendimento
                {
                    AgendamentoId = agendamento.Id,
                    ClienteId = agendamento.ClienteId,
                    PetId = agendamento.PetId,
                    ServicoId = agendamento.ServicoId,
                    FuncionarioId = ServiceContainer.AuthenticationService.CurrentUser?.Id ?? 1,
                    DataInicio = DateTime.Now,
                    Valor = agendamento.ValorTotal,
                    Status = "Em Atendimento",
                    Observacoes = $"Atendimento iniciado para {agendamento.Pet?.Nome}."
                });
            }

            CarregarAgendamentos();
        }
    }

    private void AbrirNovoAgendamento()
    {
        using var modal = new FrmAgendamento();
        if (modal.ShowDialog() == DialogResult.OK)
        {
            CarregarAgendamentos();
        }
    }
}
