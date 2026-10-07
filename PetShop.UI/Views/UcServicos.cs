using System.Drawing;
using System.Windows.Forms;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.IoC;
using PetShop.UI.Controls;
using PetShop.UI.Helpers;

namespace PetShop.UI.Views;

public class UcServicos : UserControl
{
    private DataGridView _dgv = null!;

    public UcServicos()
    {
        BuildUI();
        CarregarServicos();
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
            Text = "Catálogo de Serviços",
            Font = UITheme.FontTitleLarge,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(0, 0),
            AutoSize = true
        };

        var lblSub = new Label
        {
            Text = "Configure os serviços disponíveis, tempo de execução estimado e valores praticados.",
            Font = UITheme.FontSubtitle,
            ForeColor = UITheme.TextSecondary,
            Location = new Point(0, 32),
            AutoSize = true
        };

        var btnNovo = new ModernButton
        {
            Text = "+ Novo Serviço",
            Style = ModernButtonStyle.Primary,
            Size = new Size(150, 42),
            Location = new Point(pnlHeader.Width - 160, 10),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Font = UITheme.FontBodyBold
        };
        btnNovo.Click += (s, e) => AbrirModalServico();

        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(lblSub);
        pnlHeader.Controls.Add(btnNovo);

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

        var btnEditar = new ModernButton
        {
            Text = "Editar Serviço",
            Style = ModernButtonStyle.Outline,
            Size = new Size(140, 36),
            Location = new Point(0, 8),
            Font = UITheme.FontSmallBold
        };
        btnEditar.Click += (s, e) => EditarSelecionado();

        var btnToggle = new ModernButton
        {
            Text = "Ativar / Desativar",
            Style = ModernButtonStyle.Secondary,
            Size = new Size(150, 36),
            Location = new Point(150, 8),
            Font = UITheme.FontSmallBold
        };
        btnToggle.Click += (s, e) => AlternarStatusSelecionado();

        pnlFooter.Controls.Add(btnEditar);
        pnlFooter.Controls.Add(btnToggle);

        Controls.Add(cardTable);
        Controls.Add(pnlFooter);
        Controls.Add(pnlHeader);
    }

    private void ConfigureGrid()
    {
        _dgv.Columns.Add("Id", "ID");
        _dgv.Columns.Add("Nome", "Serviço");
        _dgv.Columns.Add("Descricao", "Descrição");
        _dgv.Columns.Add("Duracao", "Duração");
        _dgv.Columns.Add("Preco", "Preço");
        _dgv.Columns.Add("Status", "Status");

        _dgv.Columns["Id"].Width = 50;
        _dgv.Columns["Nome"].Width = 180;
        _dgv.Columns["Descricao"].Width = 280;
        _dgv.Columns["Duracao"].Width = 110;
        _dgv.Columns["Preco"].Width = 110;
        _dgv.Columns["Status"].Width = 100;

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

    public void CarregarServicos()
    {
        _dgv.Rows.Clear();
        var servicos = ServiceContainer.ServicoRepository.GetAll();
        foreach (var s in servicos)
        {
            _dgv.Rows.Add(
                s.Id,
                s.Nome,
                s.Descricao,
                $"{s.DuracaoMinutos} min",
                $"R$ {s.Preco:N2}",
                s.Ativo ? "Ativo" : "Inativo"
            );
        }
    }

    private void AbrirModalServico(Servico? servico = null)
    {
        using var form = new Form
        {
            Text = servico == null ? "Novo Serviço" : "Editar Serviço",
            Size = new Size(460, 380),
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false,
            BackColor = Color.White
        };

        var lblNome = new Label { Text = "Nome do Serviço:", Location = new Point(24, 20), AutoSize = true, Font = UITheme.FontBodyBold };
        var txtNome = new TextBox { Location = new Point(24, 44), Size = new Size(395, 28), Font = UITheme.FontBody, Text = servico?.Nome ?? "" };

        var lblDesc = new Label { Text = "Descrição:", Location = new Point(24, 82), AutoSize = true, Font = UITheme.FontBodyBold };
        var txtDesc = new TextBox { Location = new Point(24, 106), Size = new Size(395, 28), Font = UITheme.FontBody, Text = servico?.Descricao ?? "" };

        var lblDur = new Label { Text = "Duração (minutos):", Location = new Point(24, 144), AutoSize = true, Font = UITheme.FontBodyBold };
        var numDur = new NumericUpDown { Location = new Point(24, 168), Size = new Size(180, 28), Font = UITheme.FontBody, Maximum = 480, Value = servico?.DuracaoMinutos ?? 40 };

        var lblPreco = new Label { Text = "Preço (R$):", Location = new Point(220, 144), AutoSize = true, Font = UITheme.FontBodyBold };
        var numPreco = new NumericUpDown { Location = new Point(220, 168), Size = new Size(199, 28), Font = UITheme.FontBody, DecimalPlaces = 2, Maximum = 2000, Value = servico?.Preco ?? 50.00m };

        var btnSalvar = new ModernButton { Text = "Salvar", Style = ModernButtonStyle.Primary, Location = new Point(299, 270), Size = new Size(120, 38) };
        btnSalvar.Click += (s, e) =>
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do serviço.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var repo = ServiceContainer.ServicoRepository;
            if (servico == null)
            {
                repo.Add(new Servico
                {
                    Nome = txtNome.Text.Trim(),
                    Descricao = txtDesc.Text.Trim(),
                    DuracaoMinutos = (int)numDur.Value,
                    Preco = numPreco.Value,
                    Ativo = true
                });
            }
            else
            {
                servico.Nome = txtNome.Text.Trim();
                servico.Descricao = txtDesc.Text.Trim();
                servico.DuracaoMinutos = (int)numDur.Value;
                servico.Preco = numPreco.Value;
                repo.Update(servico);
            }
            form.DialogResult = DialogResult.OK;
        };

        var btnCanc = new ModernButton { Text = "Cancelar", Style = ModernButtonStyle.Outline, Location = new Point(190, 270), Size = new Size(100, 38) };
        btnCanc.Click += (s, e) => form.DialogResult = DialogResult.Cancel;

        form.Controls.AddRange(new Control[] { lblNome, txtNome, lblDesc, txtDesc, lblDur, numDur, lblPreco, numPreco, btnSalvar, btnCanc });

        if (form.ShowDialog() == DialogResult.OK)
        {
            CarregarServicos();
        }
    }

    private void EditarSelecionado()
    {
        if (_dgv.SelectedRows.Count == 0) return;
        int id = Convert.ToInt32(_dgv.SelectedRows[0].Cells["Id"].Value);
        var s = ServiceContainer.ServicoRepository.GetById(id);
        if (s != null) AbrirModalServico(s);
    }

    private void AlternarStatusSelecionado()
    {
        if (_dgv.SelectedRows.Count == 0) return;
        int id = Convert.ToInt32(_dgv.SelectedRows[0].Cells["Id"].Value);
        var repo = ServiceContainer.ServicoRepository;
        var s = repo.GetById(id);
        if (s != null)
        {
            s.Ativo = !s.Ativo;
            repo.Update(s);
            CarregarServicos();
        }
    }
}
