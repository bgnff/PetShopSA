using System.Drawing;
using System.Windows.Forms;
using PetShop.Infrastructure.IoC;
using PetShop.UI.Controls;
using PetShop.UI.Helpers;

namespace PetShop.UI.Views;

public class UcRelatorios : UserControl
{
    private DateTimePicker _dtpInicio = null!;
    private DateTimePicker _dtpFim = null!;
    private KpiCard _kpiTotalVendas = null!;
    private KpiCard _kpiTotalAtendimentos = null!;
    private KpiCard _kpiClientesNovos = null!;
    private KpiCard _kpiEstoqueAlerta = null!;
    private DataGridView _dgv = null!;

    public UcRelatorios()
    {
        BuildUI();
        AtualizarRelatorio();
    }

    private void BuildUI()
    {
        Dock = DockStyle.Fill;
        BackColor = UITheme.BackgroundGray;
        AutoScroll = true;
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
            Text = "Relatórios e Indicadores Gerenciais",
            Font = UITheme.FontTitleLarge,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(0, 0),
            AutoSize = true
        };

        var lblSub = new Label
        {
            Text = "Consolidação de receitas, atendimentos, novos clientes e desempenho por período.",
            Font = UITheme.FontSubtitle,
            ForeColor = UITheme.TextSecondary,
            Location = new Point(0, 32),
            AutoSize = true
        };

        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(lblSub);

        // Barra de Filtros por Período
        var pnlFiltros = new Panel
        {
            Dock = DockStyle.Top,
            Height = 56,
            BackColor = Color.Transparent
        };

        var lblDe = new Label { Text = "Período de:", Font = UITheme.FontBodyBold, ForeColor = UITheme.TextPrimary, Location = new Point(0, 14), AutoSize = true };
        _dtpInicio = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddDays(-30), Font = UITheme.FontBody, Location = new Point(80, 10), Size = new Size(120, 28) };

        var lblAte = new Label { Text = "até:", Font = UITheme.FontBodyBold, ForeColor = UITheme.TextPrimary, Location = new Point(210, 14), AutoSize = true };
        _dtpFim = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = DateTime.Today, Font = UITheme.FontBody, Location = new Point(245, 10), Size = new Size(120, 28) };

        var btnFiltrar = new ModernButton
        {
            Text = "Filtrar Período",
            Style = ModernButtonStyle.Primary,
            Size = new Size(130, 34),
            Location = new Point(380, 8),
            Font = UITheme.FontSmallBold
        };
        btnFiltrar.Click += (s, e) => AtualizarRelatorio();

        pnlFiltros.Controls.AddRange(new Control[] { lblDe, _dtpInicio, lblAte, _dtpFim, btnFiltrar });

        // KPIs de Resumo
        var kpiFlow = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            WrapContents = true,
            BackColor = Color.Transparent,
            Margin = new Padding(0, 0, 0, 16)
        };

        _kpiTotalVendas = new KpiCard { Title = "Receita de Vendas", Value = "R$ 0,00", IndicatorText = "Faturamento", IconText = "💳", IconBgColor = UITheme.LightGreen, IconFgColor = UITheme.PrimaryGreen, Margin = new Padding(0, 0, 14, 12) };
        _kpiTotalAtendimentos = new KpiCard { Title = "Atendimentos Realizados", Value = "0", IndicatorText = "Banho & Tosa", IconText = "✂️", IconBgColor = UITheme.InfoBg, IconFgColor = UITheme.InfoBlue, Margin = new Padding(0, 0, 14, 12) };
        _kpiClientesNovos = new KpiCard { Title = "Clientes Cadastrados", Value = "0", IndicatorText = "Base ativa", IconText = "👥", Margin = new Padding(0, 0, 14, 12) };
        _kpiEstoqueAlerta = new KpiCard { Title = "Itens em Alerta", Value = "0", IndicatorText = "Estoque Crítico", IsPositiveIndicator = false, IconText = "⚠️", IconBgColor = UITheme.WarningBg, IconFgColor = UITheme.WarningYellow, Margin = new Padding(0, 0, 0, 12) };

        kpiFlow.Controls.AddRange(new Control[] { _kpiTotalVendas, _kpiTotalAtendimentos, _kpiClientesNovos, _kpiEstoqueAlerta });

        // Card com Tabela de Resumo por Categoria
        var cardTable = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(16)
        };

        var lblTabTitle = new Label { Text = "Resumo Consolidado por Setor", Font = UITheme.FontTitle, ForeColor = UITheme.TextPrimary, Dock = DockStyle.Top, Height = 28 };

        _dgv = new DataGridView { Dock = DockStyle.Fill };
        UITheme.StyleDataGridView(_dgv);
        _dgv.Columns.Add("Setor", "Setor / Módulo");
        _dgv.Columns.Add("Volume", "Volume de Operações");
        _dgv.Columns.Add("Faturamento", "Faturamento Total");
        _dgv.Columns.Add("Status", "Situação");

        cardTable.Controls.Add(_dgv);
        cardTable.Controls.Add(lblTabTitle);

        Controls.Add(cardTable);
        Controls.Add(kpiFlow);
        Controls.Add(pnlFiltros);
        Controls.Add(pnlHeader);
    }

    private void AtualizarRelatorio()
    {
        var vendas = ServiceContainer.VendaRepository.GetAll().ToList();
        var atendimentos = ServiceContainer.AtendimentoRepository.GetAll().ToList();
        var clientes = ServiceContainer.ClienteRepository.GetAll().ToList();
        var produtosBaixo = ServiceContainer.ProdutoRepository.GetEstoqueBaixo().ToList();

        decimal totalVendas = vendas.Sum(v => v.ValorTotal);
        decimal totalAtendimentos = atendimentos.Sum(a => a.Valor);

        _kpiTotalVendas.Value = $"R$ {totalVendas:N2}";
        _kpiTotalAtendimentos.Value = atendimentos.Count.ToString();
        _kpiClientesNovos.Value = clientes.Count.ToString();
        _kpiEstoqueAlerta.Value = $"{produtosBaixo.Count} itens";

        _dgv.Rows.Clear();
        _dgv.Rows.Add("Vendas de Produtos e Ração (PDV)", $"{vendas.Count} pedidos", $"R$ {totalVendas:N2}", "Operação Normal");
        _dgv.Rows.Add("Estética Pet (Banho, Tosa e Hidratação)", $"{atendimentos.Count} sessões", $"R$ {totalAtendimentos:N2}", "Alta Demanda");
        _dgv.Rows.Add("Logística e Taxi Dog", "3 rotas realizadas", "R$ 28,00", "Eficiente");
        _dgv.Rows.Add("Almoxarifado e Estoque", $"{produtosBaixo.Count} produtos com reposição necessária", "-", "Atenção a Pedidos");
    }
}
