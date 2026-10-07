using PetShop.Domain.Entities;
using PetShop.Domain.Enums;
using PetShop.Infrastructure.IoC;

namespace PetShop.UI.Forms;

public partial class FrmProduto : Form
{
    private readonly Produto? _produtoExistente;

    public bool IsSaved { get; private set; }

    public FrmProduto(Produto? produto = null)
    {
        _produtoExistente = produto;
        InitializeComponent();
        CarregarCategorias();
        PreencherDados();
    }

    private void CarregarCategorias()
    {
        cboCategoria.Items.Clear();
        foreach (var cat in Enum.GetNames<CategoriaProduto>())
        {
            cboCategoria.Items.Add(cat);
        }
        cboCategoria.SelectedIndex = 0;
    }

    private void PreencherDados()
    {
        if (_produtoExistente != null)
        {
            Text = $"Editar Produto: {_produtoExistente.Nome}";
            lblTitle.Text = $"Editar: {_produtoExistente.Nome}";
            txtNome.Text = _produtoExistente.Nome;
            txtSKU.Text = _produtoExistente.SKU;
            cboCategoria.SelectedItem = _produtoExistente.Categoria;
            txtMarca.Text = _produtoExistente.Marca;
            txtDescricao.Text = _produtoExistente.Descricao;
            numPreco.Value = _produtoExistente.Preco;
            numQtd.Value = _produtoExistente.QuantidadeEstoque;
            numEstoqueMin.Value = _produtoExistente.EstoqueMinimo;
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
            MostrarErro("Informe o nome do produto.");
            txtNome.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtSKU.Text))
        {
            MostrarErro("Informe o código SKU.");
            txtSKU.Focus();
            return;
        }

        var repo = ServiceContainer.ProdutoRepository;

        if (_produtoExistente == null)
        {
            var novo = new Produto
            {
                Nome = txtNome.Text.Trim(),
                SKU = txtSKU.Text.Trim().ToUpper(),
                Categoria = cboCategoria.SelectedItem?.ToString() ?? "Outros",
                Marca = txtMarca.Text.Trim(),
                Descricao = txtDescricao.Text.Trim(),
                Preco = numPreco.Value,
                QuantidadeEstoque = (int)numQtd.Value,
                EstoqueMinimo = (int)numEstoqueMin.Value,
                Ativo = true
            };
            repo.Add(novo);
        }
        else
        {
            _produtoExistente.Nome = txtNome.Text.Trim();
            _produtoExistente.SKU = txtSKU.Text.Trim().ToUpper();
            _produtoExistente.Categoria = cboCategoria.SelectedItem?.ToString() ?? "Outros";
            _produtoExistente.Marca = txtMarca.Text.Trim();
            _produtoExistente.Descricao = txtDescricao.Text.Trim();
            _produtoExistente.Preco = numPreco.Value;
            _produtoExistente.QuantidadeEstoque = (int)numQtd.Value;
            _produtoExistente.EstoqueMinimo = (int)numEstoqueMin.Value;
            repo.Update(_produtoExistente);
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
