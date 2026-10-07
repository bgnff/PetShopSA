using System.Drawing;
using System.Windows.Forms;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.IoC;
using PetShop.UI.Controls;
using PetShop.UI.Forms;
using PetShop.UI.Helpers;

namespace PetShop.UI.Views;

public class UcProdutos : UserControl
{
    private DataGridView _dgv = null!;
    private ModernSearchBox _searchBox = null!;
    private ComboBox _cboCategoriaFiltro = null!;

    public UcProdutos()
    {
        BuildUI();
        CarregarProdutos();
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
            Text = "Produtos e Artigos Pet",
            Font = UITheme.FontTitleLarge,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(0, 0),
            AutoSize = true
        };

        var lblSub = new Label
        {
            Text = "Gerencie o catálogo de rações, brinquedos, medicamentos e acessórios.",
            Font = UITheme.FontSubtitle,
            ForeColor = UITheme.TextSecondary,
            Location = new Point(0, 32),
            AutoSize = true
        };

        var btnNovo = new ModernButton
        {
            Text = "+ Novo Produto",
            Style = ModernButtonStyle.Primary,
            Size = new Size(150, 42),
            Location = new Point(pnlHeader.Width - 160, 10),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Font = UITheme.FontBodyBold
        };
        btnNovo.Click += (s, e) => AbrirNovoProduto();

        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(lblSub);
        pnlHeader.Controls.Add(btnNovo);

        // Barra de Pesquisa e Filtro de Categoria
        var pnlActions = new Panel
        {
            Dock = DockStyle.Top,
            Height = 56,
            BackColor = Color.Transparent
        };

        _searchBox = new ModernSearchBox
        {
            PlaceholderText = "Pesquisar por produto, SKU ou marca...",
            Location = new Point(0, 8),
            Size = new Size(380, 40)
        };
        _searchBox.SearchTextChanged += (s, e) => CarregarProdutos();

        _cboCategoriaFiltro = new ComboBox
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            Font = UITheme.FontBody,
            Location = new Point(400, 12),
            Size = new Size(180, 32)
        };
        _cboCategoriaFiltro.Items.Add("Todas Categorias");
        foreach (var c in Enum.GetNames<Domain.Enums.CategoriaProduto>())
        {
            _cboCategoriaFiltro.Items.Add(c);
        }
        _cboCategoriaFiltro.SelectedIndex = 0;
        _cboCategoriaFiltro.SelectedIndexChanged += (s, e) => CarregarProdutos();

        pnlActions.Controls.Add(_searchBox);
        pnlActions.Controls.Add(_cboCategoriaFiltro);

        // Tabela de Produtos
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

        var btnEditar = new ModernButton
        {
            Text = "Editar Produto",
            Style = ModernButtonStyle.Outline,
            Size = new Size(140, 36),
            Location = new Point(0, 8),
            Font = UITheme.FontSmallBold
        };
        btnEditar.Click += (s, e) => EditarSelecionado();

        var btnDesativar = new ModernButton
        {
            Text = "Desativar Produto",
            Style = ModernButtonStyle.Danger,
            Size = new Size(150, 36),
            Location = new Point(150, 8),
            Font = UITheme.FontSmallBold
        };
        btnDesativar.Click += (s, e) => DesativarSelecionado();

        pnlFooter.Controls.Add(btnEditar);
        pnlFooter.Controls.Add(btnDesativar);

        Controls.Add(cardTable);
        Controls.Add(pnlFooter);
        Controls.Add(pnlActions);
        Controls.Add(pnlHeader);
    }

    private void ConfigureGrid()
    {
        _dgv.Columns.Add("Id", "ID");
        _dgv.Columns.Add("SKU", "SKU");
        _dgv.Columns.Add("Nome", "Produto");
        _dgv.Columns.Add("Categoria", "Categoria");
        _dgv.Columns.Add("Marca", "Marca");
        _dgv.Columns.Add("Preco", "Preço");
        _dgv.Columns.Add("Estoque", "Estoque");
        _dgv.Columns.Add("Status", "Situação");

        _dgv.Columns["Id"].Width = 50;
        _dgv.Columns["SKU"].Width = 110;
        _dgv.Columns["Nome"].Width = 220;
        _dgv.Columns["Categoria"].Width = 120;
        _dgv.Columns["Marca"].Width = 120;
        _dgv.Columns["Preco"].Width = 100;
        _dgv.Columns["Estoque"].Width = 90;
        _dgv.Columns["Status"].Width = 110;

        _dgv.CellFormatting += (s, e) =>
        {
            if (e.ColumnIndex == _dgv.Columns["Status"]?.Index && e.Value != null)
            {
                string status = e.Value?.ToString() ?? "";
                if (status == "Disponível")
                {
                    e.CellStyle.ForeColor = UITheme.PrimaryGreen;
                    e.CellStyle.BackColor = UITheme.LightGreen;
                }
                else if (status == "Estoque Baixo")
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

        _dgv.CellDoubleClick += (s, e) => EditarSelecionado();
    }

    public void CarregarProdutos()
    {
        string termo = _searchBox.Text.Trim();
        string cat = _cboCategoriaFiltro.SelectedItem?.ToString() ?? "Todas Categorias";
        if (cat == "Todas Categorias") cat = "";

        var repo = ServiceContainer.ProdutoRepository;
        var produtos = repo.Search(termo, cat).Where(p => p.Ativo);

        _dgv.Rows.Clear();
        foreach (var p in produtos)
        {
            string situacao = p.SemEstoque ? "Sem Estoque" : (p.EstoqueBaixo ? "Estoque Baixo" : "Disponível");
            _dgv.Rows.Add(
                p.Id,
                p.SKU,
                p.Nome,
                p.Categoria,
                p.Marca,
                $"R$ {p.Preco:N2}",
                $"{p.QuantidadeEstoque} un",
                situacao
            );
        }
    }

    private void AbrirNovoProduto()
    {
        using var modal = new FrmProduto();
        if (modal.ShowDialog() == DialogResult.OK)
        {
            CarregarProdutos();
        }
    }

    private void EditarSelecionado()
    {
        if (_dgv.SelectedRows.Count == 0) return;
        int id = Convert.ToInt32(_dgv.SelectedRows[0].Cells["Id"].Value);
        var p = ServiceContainer.ProdutoRepository.GetById(id);
        if (p != null)
        {
            using var modal = new FrmProduto(p);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                CarregarProdutos();
            }
        }
    }

    private void DesativarSelecionado()
    {
        if (_dgv.SelectedRows.Count == 0) return;
        int id = Convert.ToInt32(_dgv.SelectedRows[0].Cells["Id"].Value);
        var p = ServiceContainer.ProdutoRepository.GetById(id);
        if (p != null)
        {
            var res = MessageBox.Show($"Deseja desativar o produto '{p.Nome}'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                ServiceContainer.ProdutoRepository.Delete(id);
                CarregarProdutos();
            }
        }
    }
}
