using System.Drawing;
using System.Windows.Forms;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.IoC;
using PetShop.UI.Controls;
using PetShop.UI.Helpers;

namespace PetShop.UI.Views;

public class UcVendas : UserControl
{
    // Elementos da Aba PDV
    private ComboBox _cboClientePdv = null!;
    private ComboBox _cboProdutoPdv = null!;
    private NumericUpDown _numQtdPdv = null!;
    private DataGridView _dgvCarrinho = null!;
    private Label _lblSubtotalPdv = null!;
    private NumericUpDown _numFretePdv = null!;
    private Label _lblTotalPdv = null!;
    private readonly List<ItemVenda> _carrinho = new();

    // Elementos da Aba Histórico
    private DataGridView _dgvHistorico = null!;
    private KpiCard _kpiVendasHoje = null!;
    private KpiCard _kpiVendasMes = null!;
    private KpiCard _kpiFaturamento = null!;
    private KpiCard _kpiTicketMedio = null!;

    // Controle de Abas
    private Panel _pnlPdv = null!;
    private Panel _pnlHistorico = null!;
    private ModernButton _btnTabPdv = null!;
    private ModernButton _btnTabHistorico = null!;

    public UcVendas()
    {
        BuildUI();
        CarregarDadosPdv();
        CarregarHistorico();
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
            Text = "Comercial e Vendas (PDV)",
            Font = UITheme.FontTitleLarge,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(0, 0),
            AutoSize = true
        };

        var lblSub = new Label
        {
            Text = "Realize vendas no balcão (PDV caixa rápido) e acompanhe o histórico financeiro.",
            Font = UITheme.FontSubtitle,
            ForeColor = UITheme.TextSecondary,
            Location = new Point(0, 32),
            AutoSize = true
        };

        // Botões de alternância de aba
        _btnTabPdv = new ModernButton
        {
            Text = "🛒 Nova Venda (PDV)",
            Style = ModernButtonStyle.Primary,
            Size = new Size(160, 40),
            Location = new Point(pnlHeader.Width - 340, 10),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Font = UITheme.FontSmallBold
        };
        _btnTabPdv.Click += (s, e) => AlternarAba(pdv: true);

        _btnTabHistorico = new ModernButton
        {
            Text = "📋 Histórico de Vendas",
            Style = ModernButtonStyle.Outline,
            Size = new Size(160, 40),
            Location = new Point(pnlHeader.Width - 170, 10),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Font = UITheme.FontSmallBold
        };
        _btnTabHistorico.Click += (s, e) => AlternarAba(pdv: false);

        pnlHeader.Controls.AddRange(new Control[] { lblTitle, lblSub, _btnTabPdv, _btnTabHistorico });

        // Container Central das Abas
        var pnlTabContainer = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        ConstruirPainelPdv(out _pnlPdv);
        ConstruirPainelHistorico(out _pnlHistorico);

        pnlTabContainer.Controls.Add(_pnlPdv);
        pnlTabContainer.Controls.Add(_pnlHistorico);

        Controls.Add(pnlTabContainer);
        Controls.Add(pnlHeader);

        AlternarAba(pdv: true);
    }

    private void AlternarAba(bool pdv)
    {
        _pnlPdv.Visible = pdv;
        _pnlHistorico.Visible = !pdv;

        _btnTabPdv.Style = pdv ? ModernButtonStyle.Primary : ModernButtonStyle.Outline;
        _btnTabHistorico.Style = !pdv ? ModernButtonStyle.Primary : ModernButtonStyle.Outline;

        if (!pdv) CarregarHistorico();
    }

    private void ConstruirPainelPdv(out Panel panel)
    {
        panel = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        var split = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 1,
            BackColor = Color.Transparent
        };
        split.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
        split.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));

        // Metade Esquerda: Seleção de Cliente e Adicionar Itens
        var cardSelecao = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 0, 10, 0),
            Padding = new Padding(20)
        };

        var lblSec1 = new Label { Text = "1. Selecionar Cliente", Font = UITheme.FontTitle, ForeColor = UITheme.TextPrimary, Dock = DockStyle.Top, Height = 28 };
        _cboClientePdv = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Font = UITheme.FontBody, Dock = DockStyle.Top, Height = 32 };

        var pnlEspaco1 = new Panel { Dock = DockStyle.Top, Height = 20 };

        var lblSec2 = new Label { Text = "2. Adicionar Produto ao Carrinho", Font = UITheme.FontTitle, ForeColor = UITheme.TextPrimary, Dock = DockStyle.Top, Height = 28 };
        _cboProdutoPdv = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Font = UITheme.FontBody, Dock = DockStyle.Top, Height = 32 };

        var pnlQtd = new Panel { Dock = DockStyle.Top, Height = 75, Padding = new Padding(0, 10, 0, 0) };
        var lblQtd = new Label { Text = "Quantidade:", Font = UITheme.FontBodyBold, ForeColor = UITheme.TextPrimary, Location = new Point(0, 10), AutoSize = true };
        _numQtdPdv = new NumericUpDown { Minimum = 1, Maximum = 100, Value = 1, Font = UITheme.FontBody, Location = new Point(0, 32), Size = new Size(120, 30) };

        var btnAddCarrinho = new ModernButton
        {
            Text = "＋ Adicionar ao Carrinho",
            Style = ModernButtonStyle.Accent,
            Size = new Size(190, 34),
            Location = new Point(135, 30),
            Font = UITheme.FontSmallBold
        };
        btnAddCarrinho.Click += (s, e) => AdicionarItemAoCarrinho();

        pnlQtd.Controls.AddRange(new Control[] { lblQtd, _numQtdPdv, btnAddCarrinho });

        var pnlDica = new RoundedPanel
        {
            Dock = DockStyle.Bottom,
            Height = 110,
            BackColor = UITheme.LightGreen,
            BorderColor = ColorTranslator.FromHtml("#BCE3C6"),
            Padding = new Padding(12)
        };
        var lblDica = new Label
        {
            Text = "💡 Dica de Caixa Rápido:\nSelecione o produto desejado e clique em Adicionar. Você pode ajustar a quantidade no carrinho ou remover itens com duplo clique.",
            Font = UITheme.FontSmall,
            ForeColor = UITheme.VeryDarkGreen,
            Dock = DockStyle.Fill
        };
        pnlDica.Controls.Add(lblDica);

        cardSelecao.Controls.Add(pnlDica);
        cardSelecao.Controls.Add(pnlQtd);
        cardSelecao.Controls.Add(_cboProdutoPdv);
        cardSelecao.Controls.Add(lblSec2);
        cardSelecao.Controls.Add(pnlEspaco1);
        cardSelecao.Controls.Add(_cboClientePdv);
        cardSelecao.Controls.Add(lblSec1);

        // Metade Direita: Carrinho e Fechamento de Venda
        var cardCarrinho = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(10, 0, 0, 0),
            Padding = new Padding(20)
        };

        var lblCarTitle = new Label { Text = "Carrinho de Compras", Font = UITheme.FontTitle, ForeColor = UITheme.TextPrimary, Dock = DockStyle.Top, Height = 28 };

        _dgvCarrinho = new DataGridView { Dock = DockStyle.Fill };
        UITheme.StyleDataGridView(_dgvCarrinho);
        _dgvCarrinho.Columns.Add("Produto", "Produto");
        _dgvCarrinho.Columns.Add("Qtd", "Qtd");
        _dgvCarrinho.Columns.Add("Unitario", "Preço Un.");
        _dgvCarrinho.Columns.Add("Subtotal", "Subtotal");
        _dgvCarrinho.Columns["Qtd"].Width = 60;
        _dgvCarrinho.Columns["Unitario"].Width = 90;
        _dgvCarrinho.Columns["Subtotal"].Width = 100;

        // Rodapé de Totais do PDV
        var pnlTotais = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 150,
            Padding = new Padding(0, 10, 0, 0)
        };

        _lblSubtotalPdv = new Label { Text = "Subtotal Produtos: R$ 0,00", Font = UITheme.FontBodyBold, ForeColor = UITheme.TextSecondary, Location = new Point(0, 10), AutoSize = true };

        var lblFrete = new Label { Text = "Frete / Entrega (R$):", Font = UITheme.FontBodyBold, ForeColor = UITheme.TextSecondary, Location = new Point(0, 36), AutoSize = true };
        _numFretePdv = new NumericUpDown { DecimalPlaces = 2, Maximum = 500, Value = 0, Font = UITheme.FontBody, Location = new Point(140, 34), Size = new Size(100, 26) };
        _numFretePdv.ValueChanged += (s, e) => AtualizarTotaisPdv();

        _lblTotalPdv = new Label { Text = "TOTAL: R$ 0,00", Font = UITheme.FontTitleLarge, ForeColor = UITheme.PrimaryGreen, Location = new Point(0, 68), AutoSize = true };

        var btnFinalizar = new ModernButton
        {
            Text = "Finalizar Venda (Emitir Pedido)",
            Style = ModernButtonStyle.Primary,
            Size = new Size(240, 44),
            Location = new Point(cardCarrinho.Width - 260, 60),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Font = UITheme.FontBodyBold
        };
        btnFinalizar.Click += (s, e) => FinalizarVenda();

        var btnLimpar = new ModernButton
        {
            Text = "Limpar Carrinho",
            Style = ModernButtonStyle.Outline,
            Size = new Size(130, 44),
            Location = new Point(cardCarrinho.Width - 400, 60),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Font = UITheme.FontSmallBold
        };
        btnLimpar.Click += (s, e) => LimparCarrinho();

        pnlTotais.Controls.AddRange(new Control[] { _lblSubtotalPdv, lblFrete, _numFretePdv, _lblTotalPdv, btnLimpar, btnFinalizar });

        cardCarrinho.Controls.Add(_dgvCarrinho);
        cardCarrinho.Controls.Add(pnlTotais);
        cardCarrinho.Controls.Add(lblCarTitle);

        split.Controls.Add(cardSelecao, 0, 0);
        split.Controls.Add(cardCarrinho, 1, 0);

        panel.Controls.Add(split);
    }

    private void ConstruirPainelHistorico(out Panel panel)
    {
        panel = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent,
            Visible = false
        };

        // KPI Cards do Histórico
        var kpiFlow = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            WrapContents = true,
            BackColor = Color.Transparent,
            Margin = new Padding(0, 0, 0, 16)
        };

        _kpiVendasHoje = new KpiCard { Title = "Vendas Hoje", Value = "0", IndicatorText = "Pedidos", IconText = "🛍️", Margin = new Padding(0, 0, 14, 12) };
        _kpiVendasMes = new KpiCard { Title = "Vendas no Mês", Value = "0", IndicatorText = "Acumulado", IconText = "📅", Margin = new Padding(0, 0, 14, 12) };
        _kpiFaturamento = new KpiCard { Title = "Faturamento Hoje", Value = "R$ 0,00", IndicatorText = "+12% vs meta", IconText = "💰", IconBgColor = UITheme.LightGreen, IconFgColor = UITheme.PrimaryGreen, Margin = new Padding(0, 0, 14, 12) };
        _kpiTicketMedio = new KpiCard { Title = "Ticket Médio", Value = "R$ 0,00", IndicatorText = "Média / venda", IconText = "📈", Margin = new Padding(0, 0, 0, 12) };

        kpiFlow.Controls.AddRange(new Control[] { _kpiVendasHoje, _kpiVendasMes, _kpiFaturamento, _kpiTicketMedio });

        var cardTable = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(16)
        };

        _dgvHistorico = new DataGridView { Dock = DockStyle.Fill };
        UITheme.StyleDataGridView(_dgvHistorico);
        _dgvHistorico.Columns.Add("Id", "Pedido");
        _dgvHistorico.Columns.Add("Cliente", "Cliente");
        _dgvHistorico.Columns.Add("Data", "Data / Hora");
        _dgvHistorico.Columns.Add("Itens", "Itens");
        _dgvHistorico.Columns.Add("Valor", "Total Venda");
        _dgvHistorico.Columns.Add("Status", "Status");

        _dgvHistorico.Columns["Id"].Width = 80;
        _dgvHistorico.Columns["Data"].Width = 130;
        _dgvHistorico.Columns["Itens"].Width = 240;
        _dgvHistorico.Columns["Valor"].Width = 110;
        _dgvHistorico.Columns["Status"].Width = 100;

        cardTable.Controls.Add(_dgvHistorico);

        panel.Controls.Add(cardTable);
        panel.Controls.Add(kpiFlow);
    }

    private void CarregarDadosPdv()
    {
        var clientes = ServiceContainer.ClienteRepository.GetAll().Where(c => c.Ativo).ToList();
        _cboClientePdv.DisplayMember = "Nome";
        _cboClientePdv.ValueMember = "Id";
        _cboClientePdv.DataSource = clientes;

        var produtos = ServiceContainer.ProdutoRepository.GetAll().Where(p => p.Ativo && !p.SemEstoque).ToList();
        _cboProdutoPdv.DisplayMember = "Nome";
        _cboProdutoPdv.ValueMember = "Id";
        _cboProdutoPdv.DataSource = produtos;
    }

    private void AdicionarItemAoCarrinho()
    {
        if (_cboProdutoPdv.SelectedItem is not Produto produto)
        {
            MessageBox.Show("Selecione um produto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        int qtd = (int)_numQtdPdv.Value;
        if (produto.QuantidadeEstoque < qtd)
        {
            MessageBox.Show($"Estoque insuficiente! Disponível em estoque: {produto.QuantidadeEstoque} un.", "Estoque Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var itemExistente = _carrinho.FirstOrDefault(i => i.ProdutoId == produto.Id);
        if (itemExistente != null)
        {
            itemExistente.Quantidade += qtd;
        }
        else
        {
            _carrinho.Add(new ItemVenda
            {
                ProdutoId = produto.Id,
                Produto = produto,
                Quantidade = qtd,
                ValorUnitario = produto.Preco
            });
        }

        AtualizarGridCarrinho();
    }

    private void AtualizarGridCarrinho()
    {
        _dgvCarrinho.Rows.Clear();
        foreach (var item in _carrinho)
        {
            _dgvCarrinho.Rows.Add(
                item.Produto?.Nome ?? "Produto",
                $"{item.Quantidade}x",
                $"R$ {item.ValorUnitario:N2}",
                $"R$ {item.Subtotal:N2}"
            );
        }
        AtualizarTotaisPdv();
    }

    private void AtualizarTotaisPdv()
    {
        decimal subtotal = _carrinho.Sum(i => i.Subtotal);
        decimal frete = _numFretePdv.Value;
        decimal total = ServiceContainer.PriceService.CalcularTotalVenda(subtotal, frete);

        _lblSubtotalPdv.Text = $"Subtotal Produtos: R$ {subtotal:N2}";
        _lblTotalPdv.Text = $"TOTAL: R$ {total:N2}";
    }

    private void LimparCarrinho()
    {
        _carrinho.Clear();
        AtualizarGridCarrinho();
    }

    private void FinalizarVenda()
    {
        if (_carrinho.Count == 0)
        {
            MessageBox.Show("Adicione pelo menos um produto ao carrinho antes de finalizar a venda.", "Carrinho Vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_cboClientePdv.SelectedItem is not Cliente cliente)
        {
            MessageBox.Show("Selecione o cliente comprador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        decimal subtotal = _carrinho.Sum(i => i.Subtotal);
        decimal frete = _numFretePdv.Value;
        decimal total = ServiceContainer.PriceService.CalcularTotalVenda(subtotal, frete);

        var venda = new Venda
        {
            ClienteId = cliente.Id,
            Data = DateTime.Now,
            ValorProdutos = subtotal,
            ValorFrete = frete,
            ValorTotal = total,
            Status = "Concluída",
            Itens = new List<ItemVenda>(_carrinho)
        };

        // Dá baixa no estoque para cada item vendido
        var produtoRepo = ServiceContainer.ProdutoRepository;
        foreach (var item in _carrinho)
        {
            produtoRepo.AtualizarEstoque(item.ProdutoId, item.Quantidade);
        }

        // Salva venda no repositório
        ServiceContainer.VendaRepository.Add(venda);

        MessageBox.Show($"Venda #{venda.Id} finalizada com sucesso!\nValor Total: R$ {total:N2}\nEstoque atualizado automaticamente.", "Venda Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);

        LimparCarrinho();
        CarregarDadosPdv();
    }

    private void CarregarHistorico()
    {
        var vendas = ServiceContainer.VendaRepository.GetAll().ToList();
        var vendasHoje = vendas.Where(v => v.Data.Date == DateTime.Today).ToList();

        decimal faturamentoHoje = vendasHoje.Sum(v => v.ValorTotal);
        decimal ticketMedio = vendas.Any() ? vendas.Average(v => v.ValorTotal) : 0;

        _kpiVendasHoje.Value = vendasHoje.Count.ToString();
        _kpiVendasMes.Value = vendas.Count.ToString();
        _kpiFaturamento.Value = $"R$ {faturamentoHoje:N2}";
        _kpiTicketMedio.Value = $"R$ {ticketMedio:N2}";

        _dgvHistorico.Rows.Clear();
        foreach (var v in vendas)
        {
            string resumoItens = string.Join(", ", v.Itens.Select(i => $"{i.Quantidade}x {i.Produto?.Nome ?? "Item"}"));
            if (string.IsNullOrWhiteSpace(resumoItens)) resumoItens = "Itens diversos";

            _dgvHistorico.Rows.Add(
                $"#{v.Id}",
                v.Cliente?.Nome ?? "Consumidor",
                v.Data.ToString("dd/MM/yyyy HH:mm"),
                resumoItens,
                $"R$ {v.ValorTotal:N2}",
                v.Status
            );
        }
    }
}
