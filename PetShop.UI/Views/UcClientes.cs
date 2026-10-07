using System.Drawing;
using System.Windows.Forms;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.IoC;
using PetShop.UI.Controls;
using PetShop.UI.Forms;
using PetShop.UI.Helpers;

namespace PetShop.UI.Views;

public class UcClientes : UserControl
{
    private DataGridView _dgv = null!;
    private ModernSearchBox _searchBox = null!;
    private List<Cliente> _currentList = new();

    public UcClientes()
    {
        BuildUI();
        LoadData();
    }

    private void BuildUI()
    {
        Dock = DockStyle.Fill;
        BackColor = UITheme.BackgroundGray;
        Padding = new Padding(24, 20, 24, 24);

        // Painel Superior
        var pnlHeader = new Panel
        {
            Dock = DockStyle.Top,
            Height = 70,
            BackColor = Color.Transparent
        };

        var lblTitle = new Label
        {
            Text = "Clientes",
            Font = UITheme.FontTitleLarge,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(0, 0),
            AutoSize = true
        };

        var lblSub = new Label
        {
            Text = "Gerencie os tutores e clientes cadastrados no Pet Shop.",
            Font = UITheme.FontSubtitle,
            ForeColor = UITheme.TextSecondary,
            Location = new Point(0, 32),
            AutoSize = true
        };

        var btnNovo = new ModernButton
        {
            Text = "+ Novo Cliente",
            Style = ModernButtonStyle.Primary,
            Size = new Size(150, 42),
            Location = new Point(pnlHeader.Width - 160, 10),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Font = UITheme.FontBodyBold
        };
        btnNovo.Click += (s, e) => AbrirNovoCliente();

        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(lblSub);
        pnlHeader.Controls.Add(btnNovo);

        // Barra de Ações / Filtros
        var pnlActions = new Panel
        {
            Dock = DockStyle.Top,
            Height = 56,
            BackColor = Color.Transparent
        };

        _searchBox = new ModernSearchBox
        {
            PlaceholderText = "Pesquisar por nome, CPF ou telefone...",
            Location = new Point(0, 8),
            Size = new Size(380, 40)
        };
        _searchBox.SearchTextChanged += (s, e) => FiltrarDados();

        pnlActions.Controls.Add(_searchBox);

        // Container do Card com a Tabela
        var cardTable = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(16)
        };

        _dgv = new DataGridView { Dock = DockStyle.Fill };
        UITheme.StyleDataGridView(_dgv);
        ConfigureGrid();

        cardTable.Controls.Add(_dgv);

        // Painel de Rodapé / Ações de Linha Selecionada
        var pnlBottom = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 50,
            BackColor = Color.Transparent,
            Padding = new Padding(0, 10, 0, 0)
        };

        var btnEditar = new ModernButton
        {
            Text = "Editar Selecionado",
            Style = ModernButtonStyle.Outline,
            Size = new Size(160, 36),
            Location = new Point(0, 10),
            Font = UITheme.FontSmallBold
        };
        btnEditar.Click += (s, e) => EditarSelecionado();

        var btnExcluir = new ModernButton
        {
            Text = "Desativar Cliente",
            Style = ModernButtonStyle.Danger,
            Size = new Size(150, 36),
            Location = new Point(170, 10),
            Font = UITheme.FontSmallBold
        };
        btnExcluir.Click += (s, e) => ExcluirSelecionado();

        pnlBottom.Controls.Add(btnEditar);
        pnlBottom.Controls.Add(btnExcluir);

        Controls.Add(cardTable);
        Controls.Add(pnlBottom);
        Controls.Add(pnlActions);
        Controls.Add(pnlHeader);
    }

    private void ConfigureGrid()
    {
        _dgv.Columns.Add("Id", "ID");
        _dgv.Columns.Add("Nome", "Nome");
        _dgv.Columns.Add("CPF", "CPF");
        _dgv.Columns.Add("Telefone", "Telefone");
        _dgv.Columns.Add("Email", "E-mail");
        _dgv.Columns.Add("Pets", "Pets");
        _dgv.Columns.Add("DataCadastro", "Data Cadastro");
        _dgv.Columns.Add("Status", "Status");

        _dgv.Columns["Id"].Width = 50;
        _dgv.Columns["Nome"].Width = 180;
        _dgv.Columns["CPF"].Width = 120;
        _dgv.Columns["Telefone"].Width = 130;
        _dgv.Columns["Pets"].Width = 140;
        _dgv.Columns["DataCadastro"].Width = 110;
        _dgv.Columns["Status"].Width = 90;

        _dgv.CellFormatting += (s, e) =>
        {
            if (e.ColumnIndex == _dgv.Columns["Status"]?.Index && e.Value != null)
            {
                if (e.Value?.ToString() == "Ativo")
                {
                    e.CellStyle.ForeColor = UITheme.PrimaryGreen;
                    e.CellStyle.BackColor = UITheme.LightGreen;
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

    public void LoadData()
    {
        var repo = ServiceContainer.ClienteRepository;
        _currentList = repo.GetAll().ToList();
        PopularGrid(_currentList);
    }

    private void FiltrarDados()
    {
        string termo = _searchBox.Text.Trim();
        var repo = ServiceContainer.ClienteRepository;
        _currentList = repo.Search(termo).ToList();
        PopularGrid(_currentList);
    }

    private void PopularGrid(IEnumerable<Cliente> clientes)
    {
        _dgv.Rows.Clear();
        foreach (var c in clientes)
        {
            string petsDesc = c.Pets.Any() ? string.Join(", ", c.Pets.Select(p => p.Nome)) : "Nenhum";
            _dgv.Rows.Add(
                c.Id,
                c.Nome,
                c.CPF,
                c.Telefone,
                c.Email,
                petsDesc,
                c.DataCadastro.ToString("dd/MM/yyyy"),
                c.Ativo ? "Ativo" : "Inativo"
            );
        }
    }

    private Cliente? ObterClienteSelecionado()
    {
        if (_dgv.SelectedRows.Count == 0) return null;
        int id = Convert.ToInt32(_dgv.SelectedRows[0].Cells["Id"].Value);
        return ServiceContainer.ClienteRepository.GetById(id);
    }

    private void AbrirNovoCliente()
    {
        using var modal = new FrmCliente();
        if (modal.ShowDialog() == DialogResult.OK)
        {
            LoadData();
        }
    }

    private void EditarSelecionado()
    {
        var cliente = ObterClienteSelecionado();
        if (cliente == null)
        {
            MessageBox.Show("Selecione um cliente na tabela para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var modal = new FrmCliente(cliente);
        if (modal.ShowDialog() == DialogResult.OK)
        {
            LoadData();
        }
    }

    private void ExcluirSelecionado()
    {
        var cliente = ObterClienteSelecionado();
        if (cliente == null)
        {
            MessageBox.Show("Selecione um cliente para desativar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var confirm = MessageBox.Show($"Deseja desativar o cadastro do cliente '{cliente.Nome}'?",
            "Confirmar Desativação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (confirm == DialogResult.Yes)
        {
            ServiceContainer.ClienteRepository.Delete(cliente.Id);
            LoadData();
        }
    }
}
