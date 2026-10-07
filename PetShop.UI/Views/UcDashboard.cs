using System.Drawing;
using System.Windows.Forms;
using PetShop.Domain.Entities;
using PetShop.Domain.Enums;
using PetShop.Infrastructure.IoC;
using PetShop.UI.Controls;
using PetShop.UI.Helpers;

namespace PetShop.UI.Views;

public class UcDashboard : UserControl
{
    private Action<string>? _navigateCallback;
    private DataGridView _dgvAgendaHoje = null!;
    private DataGridView _dgvEstoqueBaixo = null!;
    private DataGridView _dgvUltimasVendas = null!;
    private SimpleChartControl _chartVendas = null!;

    public UcDashboard(Action<string>? navigateCallback = null)
    {
        _navigateCallback = navigateCallback;
        BuildUI();
        LoadDashboardData();
    }

    private void BuildUI()
    {
        Dock = DockStyle.Fill;
        BackColor = UITheme.BackgroundGray;
        AutoScroll = true;
        Padding = new Padding(24, 20, 24, 24);

        // Painel Principal Vertical
        var mainLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            ColumnCount = 1,
            RowCount = 4,
            BackColor = Color.Transparent
        };
        mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Cabeçalho da página
        mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Linha de KPI Cards
        mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Linha 1: Agenda + Gráfico
        mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Linha 2: Estoque Baixo + Vendas Recentes

        // 1. Cabeçalho da página
        var headerPanel = new Panel
        {
            Dock = DockStyle.Top,
            Height = 55,
            BackColor = Color.Transparent
        };
        var lblTitle = new Label
        {
            Text = "Visão Geral do Pet Shop",
            Font = UITheme.FontTitleLarge,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(0, 0),
            AutoSize = true
        };
        var lblSubtitle = new Label
        {
            Text = "Acompanhe métricas em tempo real, atendimentos e movimentações do dia.",
            Font = UITheme.FontSubtitle,
            ForeColor = UITheme.TextSecondary,
            Location = new Point(0, 30),
            AutoSize = true
        };
        headerPanel.Controls.Add(lblTitle);
        headerPanel.Controls.Add(lblSubtitle);
        mainLayout.Controls.Add(headerPanel, 0, 0);

        // 2. Linha de KPI Cards
        var kpiFlow = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            WrapContents = true,
            BackColor = Color.Transparent,
            Margin = new Padding(0, 10, 0, 16)
        };

        var kpiAtendimentos = new KpiCard
        {
            Title = "Atendimentos Hoje",
            Value = "18",
            IndicatorText = "+12% hoje",
            IsPositiveIndicator = true,
            IconText = "✂️",
            IconBgColor = UITheme.LightGreen,
            IconFgColor = UITheme.PrimaryGreen,
            Margin = new Padding(0, 0, 14, 12)
        };

        var kpiAgendamentos = new KpiCard
        {
            Title = "Agendamentos",
            Value = "24",
            IndicatorText = "5 agendados",
            IsPositiveIndicator = true,
            IconText = "📅",
            IconBgColor = UITheme.InfoBg,
            IconFgColor = UITheme.InfoBlue,
            Margin = new Padding(0, 0, 14, 12)
        };

        var kpiPedidos = new KpiCard
        {
            Title = "Pedidos Hoje",
            Value = "12",
            IndicatorText = "+8% hoje",
            IsPositiveIndicator = true,
            IconText = "🛍️",
            IconBgColor = Color.FromArgb(243, 232, 255),
            IconFgColor = Color.FromArgb(147, 51, 234),
            Margin = new Padding(0, 0, 14, 12)
        };

        var kpiFaturamento = new KpiCard
        {
            Title = "Faturamento Hoje",
            Value = "R$ 3.420,00",
            IndicatorText = "+15% vs ontem",
            IsPositiveIndicator = true,
            IconText = "💰",
            IconBgColor = Color.FromArgb(254, 243, 199),
            IconFgColor = UITheme.AccentOrange,
            Margin = new Padding(0, 0, 14, 12)
        };

        var kpiEstoque = new KpiCard
        {
            Title = "Estoque Baixo",
            Value = "3 produtos",
            IndicatorText = "Atenção necessária",
            IsPositiveIndicator = false,
            IconText = "⚠️",
            IconBgColor = UITheme.DangerBg,
            IconFgColor = UITheme.DangerRed,
            Margin = new Padding(0, 0, 0, 12)
        };

        kpiFlow.Controls.AddRange(new Control[] { kpiAtendimentos, kpiAgendamentos, kpiPedidos, kpiFaturamento, kpiEstoque });
        mainLayout.Controls.Add(kpiFlow, 0, 1);

        // 3. Linha 1: Agenda de Hoje (Esquerda) + Gráfico de Vendas (Direita)
        var row1 = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 310,
            ColumnCount = 2,
            RowCount = 1,
            BackColor = Color.Transparent,
            Margin = new Padding(0, 0, 0, 16)
        };
        row1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
        row1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));

        // Card Agenda de Hoje
        var cardAgenda = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 0, 8, 0),
            Padding = new Padding(16)
        };
        var pnlAgendaHeader = new Panel { Dock = DockStyle.Top, Height = 40, BackColor = Color.Transparent };
        var lblAgendaTitle = new Label
        {
            Text = "Agenda de Hoje",
            Font = UITheme.FontTitle,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(0, 4),
            AutoSize = true
        };
        var btnVerAgenda = new ModernButton
        {
            Text = "Ver Agenda Completa →",
            Style = ModernButtonStyle.Ghost,
            ForeColor = UITheme.PrimaryGreen,
            Size = new Size(180, 32),
            Location = new Point(cardAgenda.Width - 190, 2),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Font = UITheme.FontSmallBold
        };
        btnVerAgenda.Click += (s, e) => _navigateCallback?.Invoke("Agenda");

        pnlAgendaHeader.Controls.Add(lblAgendaTitle);
        pnlAgendaHeader.Controls.Add(btnVerAgenda);

        _dgvAgendaHoje = new DataGridView { Dock = DockStyle.Fill };
        UITheme.StyleDataGridView(_dgvAgendaHoje);
        ConfigureGridAgenda();

        cardAgenda.Controls.Add(_dgvAgendaHoje);
        cardAgenda.Controls.Add(pnlAgendaHeader);

        // Gráfico de Vendas
        _chartVendas = new SimpleChartControl
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(8, 0, 0, 0)
        };

        row1.Controls.Add(cardAgenda, 0, 0);
        row1.Controls.Add(_chartVendas, 1, 0);
        mainLayout.Controls.Add(row1, 0, 2);

        // 4. Linha 2: Estoque Baixo (Esquerda) + Últimas Vendas (Direita)
        var row2 = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 260,
            ColumnCount = 2,
            RowCount = 1,
            BackColor = Color.Transparent
        };
        row2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        row2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

        // Card Estoque Baixo
        var cardEstoque = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 0, 8, 0),
            Padding = new Padding(16)
        };
        var pnlEstoqueHeader = new Panel { Dock = DockStyle.Top, Height = 36, BackColor = Color.Transparent };
        var lblEstoqueTitle = new Label
        {
            Text = "⚠️ Estoque Crítico",
            Font = UITheme.FontTitle,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(0, 2),
            AutoSize = true
        };
        var btnVerEstoque = new ModernButton
        {
            Text = "Ver Estoque →",
            Style = ModernButtonStyle.Ghost,
            ForeColor = UITheme.PrimaryGreen,
            Size = new Size(120, 30),
            Location = new Point(cardEstoque.Width - 130, 2),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Font = UITheme.FontSmallBold
        };
        btnVerEstoque.Click += (s, e) => _navigateCallback?.Invoke("Estoque");

        pnlEstoqueHeader.Controls.Add(lblEstoqueTitle);
        pnlEstoqueHeader.Controls.Add(btnVerEstoque);

        _dgvEstoqueBaixo = new DataGridView { Dock = DockStyle.Fill };
        UITheme.StyleDataGridView(_dgvEstoqueBaixo);
        ConfigureGridEstoque();

        cardEstoque.Controls.Add(_dgvEstoqueBaixo);
        cardEstoque.Controls.Add(pnlEstoqueHeader);

        // Card Últimas Vendas
        var cardVendas = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(8, 0, 0, 0),
            Padding = new Padding(16)
        };
        var pnlVendasHeader = new Panel { Dock = DockStyle.Top, Height = 36, BackColor = Color.Transparent };
        var lblVendasTitle = new Label
        {
            Text = "🛍️ Últimas Vendas",
            Font = UITheme.FontTitle,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(0, 2),
            AutoSize = true
        };
        var btnVerVendas = new ModernButton
        {
            Text = "Ver Vendas →",
            Style = ModernButtonStyle.Ghost,
            ForeColor = UITheme.PrimaryGreen,
            Size = new Size(120, 30),
            Location = new Point(cardVendas.Width - 130, 2),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Font = UITheme.FontSmallBold
        };
        btnVerVendas.Click += (s, e) => _navigateCallback?.Invoke("Vendas");

        pnlVendasHeader.Controls.Add(lblVendasTitle);
        pnlVendasHeader.Controls.Add(btnVerVendas);

        _dgvUltimasVendas = new DataGridView { Dock = DockStyle.Fill };
        UITheme.StyleDataGridView(_dgvUltimasVendas);
        ConfigureGridVendas();

        cardVendas.Controls.Add(_dgvUltimasVendas);
        cardVendas.Controls.Add(pnlVendasHeader);

        row2.Controls.Add(cardEstoque, 0, 0);
        row2.Controls.Add(cardVendas, 1, 0);
        mainLayout.Controls.Add(row2, 0, 3);

        Controls.Add(mainLayout);
    }

    private void ConfigureGridAgenda()
    {
        _dgvAgendaHoje.Columns.Add("Horario", "Horário");
        _dgvAgendaHoje.Columns.Add("Pet", "Pet");
        _dgvAgendaHoje.Columns.Add("Cliente", "Cliente / Tutor");
        _dgvAgendaHoje.Columns.Add("Servico", "Serviço");
        _dgvAgendaHoje.Columns.Add("Status", "Status");

        _dgvAgendaHoje.Columns["Horario"].Width = 70;
        _dgvAgendaHoje.Columns["Pet"].Width = 100;
        _dgvAgendaHoje.Columns["Status"].Width = 130;

        _dgvAgendaHoje.CellFormatting += (s, e) =>
        {
            if (e.ColumnIndex == _dgvAgendaHoje.Columns["Status"]?.Index && e.Value != null)
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
            }
        };
    }

    private void ConfigureGridEstoque()
    {
        _dgvEstoqueBaixo.Columns.Add("Produto", "Produto");
        _dgvEstoqueBaixo.Columns.Add("Qtd", "Qtd Atual");
        _dgvEstoqueBaixo.Columns.Add("Minimo", "Qtd Mínima");
        _dgvEstoqueBaixo.Columns.Add("Status", "Situação");

        _dgvEstoqueBaixo.Columns["Qtd"].Width = 80;
        _dgvEstoqueBaixo.Columns["Minimo"].Width = 80;
        _dgvEstoqueBaixo.Columns["Status"].Width = 100;

        _dgvEstoqueBaixo.CellFormatting += (s, e) =>
        {
            if (e.ColumnIndex == _dgvEstoqueBaixo.Columns["Status"]?.Index)
            {
                e.CellStyle.ForeColor = UITheme.DangerRed;
                e.CellStyle.BackColor = UITheme.DangerBg;
            }
        };
    }

    private void ConfigureGridVendas()
    {
        _dgvUltimasVendas.Columns.Add("Id", "Pedido");
        _dgvUltimasVendas.Columns.Add("Cliente", "Cliente");
        _dgvUltimasVendas.Columns.Add("Data", "Horário");
        _dgvUltimasVendas.Columns.Add("Total", "Total");
        _dgvUltimasVendas.Columns.Add("Status", "Status");

        _dgvUltimasVendas.Columns["Id"].Width = 70;
        _dgvUltimasVendas.Columns["Data"].Width = 80;
        _dgvUltimasVendas.Columns["Total"].Width = 90;
        _dgvUltimasVendas.Columns["Status"].Width = 100;
    }

    public void LoadDashboardData()
    {
        // 1. Carrega Agenda de Hoje
        _dgvAgendaHoje.Rows.Clear();
        var agendamentosHoje = ServiceContainer.AgendamentoRepository.GetAgendamentosHoje();
        foreach (var a in agendamentosHoje)
        {
            _dgvAgendaHoje.Rows.Add(
                a.Horario,
                a.Pet?.Nome ?? "Pet",
                a.Cliente?.Nome ?? "Cliente",
                a.Servico?.Nome ?? "Serviço",
                a.Status.ToString()
            );
        }

        // 2. Carrega Estoque Baixo
        _dgvEstoqueBaixo.Rows.Clear();
        var estoqueBaixo = ServiceContainer.ProdutoRepository.GetEstoqueBaixo().Take(4);
        foreach (var p in estoqueBaixo)
        {
            _dgvEstoqueBaixo.Rows.Add(
                p.Nome,
                $"{p.QuantidadeEstoque} un",
                $"mín {p.EstoqueMinimo}",
                "Estoque Baixo"
            );
        }

        // 3. Carrega Últimas Vendas
        _dgvUltimasVendas.Rows.Clear();
        var ultimasVendas = ServiceContainer.VendaRepository.GetUltimasVendas(5);
        foreach (var v in ultimasVendas)
        {
            _dgvUltimasVendas.Rows.Add(
                $"#{v.Id}",
                v.Cliente?.Nome ?? "Consumidor",
                v.Data.ToString("HH:mm"),
                $"R$ {v.ValorTotal:N2}",
                v.Status
            );
        }
    }
}
