using System.Drawing;
using System.Windows.Forms;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.IoC;
using PetShop.UI.Controls;
using PetShop.UI.Helpers;

namespace PetShop.UI.Views;

public class UcEstoque : UserControl
{
    private DataGridView _dgv = null!;
    private KpiCard _kpiTotal = null!;
    private KpiCard _kpiDisponiveis = null!;
    private KpiCard _kpiBaixo = null!;
    private KpiCard _kpiZerado = null!;

    private ModernButton _btnTodos = null!;
    private ModernButton _btnNormal = null!;
    private ModernButton _btnBaixo = null!;
    private ModernButton _btnSemEstoque = null!;
    private string _filtroAtual = "Todos";

    public UcEstoque()
    {
        BuildUI();
        CarregarEstoque();
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
            Height = 65,
            BackColor = Color.Transparent
        };

        var lblTitle = new Label
        {
            Text = "Controle de Estoque e Almoxarifado",
            Font = UITheme.FontTitleLarge,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(0, 0),
            AutoSize = true
        };

        var lblSub = new Label
        {
            Text = "Monitore reposições de rações, produtos com estoque crítico e disponibilidade.",
            Font = UITheme.FontSubtitle,
            ForeColor = UITheme.TextSecondary,
            Location = new Point(0, 32),
            AutoSize = true
        };

        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(lblSub);

        // Linha de KPI Cards
        var kpiFlow = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            WrapContents = true,
            BackColor = Color.Transparent,
            Margin = new Padding(0, 0, 0, 16)
        };

        _kpiTotal = new KpiCard { Title = "Produtos Cadastrados", Value = "0", IndicatorText = "Total geral", IconText = "📦", Margin = new Padding(0, 0, 14, 12) };
        _kpiDisponiveis = new KpiCard { Title = "Em Estoque Normal", Value = "0", IndicatorText = "Regular", IconText = "✅", IconBgColor = UITheme.LightGreen, IconFgColor = UITheme.PrimaryGreen, Margin = new Padding(0, 0, 14, 12) };
        _kpiBaixo = new KpiCard { Title = "Estoque Baixo", Value = "0", IndicatorText = "Atenção", IsPositiveIndicator = false, IconText = "⚠️", IconBgColor = UITheme.WarningBg, IconFgColor = UITheme.WarningYellow, Margin = new Padding(0, 0, 14, 12) };
        _kpiZerado = new KpiCard { Title = "Sem Estoque (Zerados)", Value = "0", IndicatorText = "Urgente", IsPositiveIndicator = false, IconText = "🚨", IconBgColor = UITheme.DangerBg, IconFgColor = UITheme.DangerRed, Margin = new Padding(0, 0, 0, 12) };

        kpiFlow.Controls.AddRange(new Control[] { _kpiTotal, _kpiDisponiveis, _kpiBaixo, _kpiZerado });

        // Barra de Filtros
        var pnlFilters = new Panel
        {
            Dock = DockStyle.Top,
            Height = 52,
            BackColor = Color.Transparent
        };

        _btnTodos = new ModernButton { Text = "Todos", Style = ModernButtonStyle.Primary, Size = new Size(80, 36), Location = new Point(0, 8), Font = UITheme.FontSmallBold };
        _btnTodos.Click += (s, e) => DefinirFiltro("Todos");

        _btnNormal = new ModernButton { Text = "Normal", Style = ModernButtonStyle.Outline, Size = new Size(85, 36), Location = new Point(90, 8), Font = UITheme.FontSmallBold };
        _btnNormal.Click += (s, e) => DefinirFiltro("Normal");

        _btnBaixo = new ModernButton { Text = "Estoque Baixo", Style = ModernButtonStyle.Outline, Size = new Size(125, 36), Location = new Point(185, 8), Font = UITheme.FontSmallBold };
        _btnBaixo.Click += (s, e) => DefinirFiltro("Baixo");

        _btnSemEstoque = new ModernButton { Text = "Sem Estoque", Style = ModernButtonStyle.Outline, Size = new Size(115, 36), Location = new Point(320, 8), Font = UITheme.FontSmallBold };
        _btnSemEstoque.Click += (s, e) => DefinirFiltro("SemEstoque");

        pnlFilters.Controls.AddRange(new Control[] { _btnTodos, _btnNormal, _btnBaixo, _btnSemEstoque });

        // Card com Tabela
        var cardTable = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(16)
        };

        _dgv = new DataGridView { Dock = DockStyle.Fill };
        UITheme.StyleDataGridView(_dgv);
        ConfigureGrid();

        cardTable.Controls.Add(_dgv);

        // Rodapé de Ações de Ajuste de Estoque
        var pnlFooter = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 50,
            BackColor = Color.Transparent,
            Padding = new Padding(0, 8, 0, 0)
        };

        var btnAdd10 = new ModernButton
        {
            Text = "+ Entrada de 10 un",
            Style = ModernButtonStyle.Secondary,
            Size = new Size(160, 36),
            Location = new Point(0, 8),
            Font = UITheme.FontSmallBold
        };
        btnAdd10.Click += (s, e) => AjustarEstoque(10);

        var btnSub1 = new ModernButton
        {
            Text = "- Saída de 1 un",
            Style = ModernButtonStyle.Outline,
            Size = new Size(140, 36),
            Location = new Point(170, 8),
            Font = UITheme.FontSmallBold
        };
        btnSub1.Click += (s, e) => AjustarEstoque(-1);

        pnlFooter.Controls.Add(btnAdd10);
        pnlFooter.Controls.Add(btnSub1);

        Controls.Add(cardTable);
        Controls.Add(pnlFooter);
        Controls.Add(pnlFilters);
        Controls.Add(kpiFlow);
        Controls.Add(pnlHeader);
    }

    private void ConfigureGrid()
    {
        _dgv.Columns.Add("Id", "ID");
        _dgv.Columns.Add("SKU", "SKU");
        _dgv.Columns.Add("Produto", "Produto");
        _dgv.Columns.Add("Categoria", "Categoria");
        _dgv.Columns.Add("Qtd", "Qtd Atual");
        _dgv.Columns.Add("Minimo", "Qtd Mínima");
        _dgv.Columns.Add("Preco", "Preço");
        _dgv.Columns.Add("Status", "Situação");

        _dgv.Columns["Id"].Width = 50;
        _dgv.Columns["SKU"].Width = 110;
        _dgv.Columns["Produto"].Width = 240;
        _dgv.Columns["Categoria"].Width = 120;
        _dgv.Columns["Qtd"].Width = 90;
        _dgv.Columns["Minimo"].Width = 90;
        _dgv.Columns["Preco"].Width = 100;
        _dgv.Columns["Status"].Width = 120;

        _dgv.CellFormatting += (s, e) =>
        {
            if (e.ColumnIndex == _dgv.Columns["Status"]?.Index && e.Value != null)
            {
                string status = e.Value?.ToString() ?? "";
                if (status == "Normal")
                {
                    e.CellStyle.ForeColor = UITheme.PrimaryGreen;
                    e.CellStyle.BackColor = UITheme.LightGreen;
                }
                else if (status == "Baixo")
                {
                    e.CellStyle.ForeColor = UITheme.WarningYellow;
                    e.CellStyle.BackColor = UITheme.WarningBg;
                }
                else
                {
                    e.CellStyle.ForeColor = UITheme.DangerRed;
                    e.CellStyle.BackColor = UITheme.DangerBg;
                }
            }
        };
    }

    private void DefinirFiltro(string filtro)
    {
        _filtroAtual = filtro;
        _btnTodos.Style = filtro == "Todos" ? ModernButtonStyle.Primary : ModernButtonStyle.Outline;
        _btnNormal.Style = filtro == "Normal" ? ModernButtonStyle.Primary : ModernButtonStyle.Outline;
        _btnBaixo.Style = filtro == "Baixo" ? ModernButtonStyle.Primary : ModernButtonStyle.Outline;
        _btnSemEstoque.Style = filtro == "SemEstoque" ? ModernButtonStyle.Primary : ModernButtonStyle.Outline;
        CarregarEstoque();
    }

    public void CarregarEstoque()
    {
        var produtos = ServiceContainer.ProdutoRepository.GetAll().Where(p => p.Ativo).ToList();

        int total = produtos.Count;
        int zerados = produtos.Count(p => p.SemEstoque);
        int baixos = produtos.Count(p => p.EstoqueBaixo && !p.SemEstoque);
        int normais = total - zerados - baixos;

        _kpiTotal.Value = total.ToString();
        _kpiDisponiveis.Value = normais.ToString();
        _kpiBaixo.Value = baixos.ToString();
        _kpiZerado.Value = zerados.ToString();

        IEnumerable<Produto> exibidos = _filtroAtual switch
        {
            "Normal" => produtos.Where(p => !p.EstoqueBaixo && !p.SemEstoque),
            "Baixo" => produtos.Where(p => p.EstoqueBaixo && !p.SemEstoque),
            "SemEstoque" => produtos.Where(p => p.SemEstoque),
            _ => produtos
        };

        _dgv.Rows.Clear();
        foreach (var p in exibidos)
        {
            string sit = p.SemEstoque ? "Sem Estoque" : (p.EstoqueBaixo ? "Baixo" : "Normal");
            _dgv.Rows.Add(
                p.Id,
                p.SKU,
                p.Nome,
                p.Categoria,
                $"{p.QuantidadeEstoque} un",
                $"{p.EstoqueMinimo} un",
                $"R$ {p.Preco:N2}",
                sit
            );
        }
    }

    private void AjustarEstoque(int delta)
    {
        if (_dgv.SelectedRows.Count == 0)
        {
            MessageBox.Show("Selecione um produto na tabela para ajustar estoque.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        int id = Convert.ToInt32(_dgv.SelectedRows[0].Cells["Id"].Value);
        var repo = ServiceContainer.ProdutoRepository;
        var p = repo.GetById(id);
        if (p != null)
        {
            p.QuantidadeEstoque += delta;
            if (p.QuantidadeEstoque < 0) p.QuantidadeEstoque = 0;
            repo.Update(p);
            CarregarEstoque();
        }
    }
}
