using System.Drawing;
using System.Windows.Forms;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.IoC;
using PetShop.UI.Controls;
using PetShop.UI.Forms;
using PetShop.UI.Helpers;

namespace PetShop.UI.Views;

public class UcPets : UserControl
{
    private FlowLayoutPanel _cardsContainer = null!;
    private ModernSearchBox _searchBox = null!;
    private List<Pet> _allPets = new();

    public UcPets()
    {
        BuildUI();
        LoadPets();
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
            Text = "Pets Cadastrados",
            Font = UITheme.FontTitleLarge,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(0, 0),
            AutoSize = true
        };

        var lblSub = new Label
        {
            Text = "Visualize o perfil completo, raça, tutor e histórico de agendamentos dos pets.",
            Font = UITheme.FontSubtitle,
            ForeColor = UITheme.TextSecondary,
            Location = new Point(0, 32),
            AutoSize = true
        };

        var btnNovo = new ModernButton
        {
            Text = "+ Novo Pet",
            Style = ModernButtonStyle.Primary,
            Size = new Size(140, 42),
            Location = new Point(pnlHeader.Width - 150, 10),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Font = UITheme.FontBodyBold
        };
        btnNovo.Click += (s, e) => AbrirNovoPet();

        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(lblSub);
        pnlHeader.Controls.Add(btnNovo);

        // Barra de Pesquisa e Filtros
        var pnlActions = new Panel
        {
            Dock = DockStyle.Top,
            Height = 56,
            BackColor = Color.Transparent
        };

        _searchBox = new ModernSearchBox
        {
            PlaceholderText = "Pesquisar por nome do pet, raça ou tutor...",
            Location = new Point(0, 8),
            Size = new Size(400, 40)
        };
        _searchBox.SearchTextChanged += (s, e) => FiltrarPets();

        pnlActions.Controls.Add(_searchBox);

        // Container de Cards com Scroll Automático
        _cardsContainer = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            BackColor = Color.Transparent,
            WrapContents = true,
            Padding = new Padding(0, 8, 0, 0)
        };

        Controls.Add(_cardsContainer);
        Controls.Add(pnlActions);
        Controls.Add(pnlHeader);
    }

    public void LoadPets()
    {
        _allPets = ServiceContainer.PetRepository.GetAll().Where(p => p.Ativo).ToList();
        RenderCards(_allPets);
    }

    private void FiltrarPets()
    {
        string termo = _searchBox.Text.Trim();
        var filtrados = ServiceContainer.PetRepository.Search(termo).Where(p => p.Ativo).ToList();
        RenderCards(filtrados);
    }

    private void RenderCards(IEnumerable<Pet> pets)
    {
        _cardsContainer.SuspendLayout();
        _cardsContainer.Controls.Clear();

        var list = pets.ToList();
        if (list.Count == 0)
        {
            var lblEmpty = new Label
            {
                Text = "Nenhum pet encontrado para a busca informada.",
                Font = UITheme.FontSubtitle,
                ForeColor = UITheme.TextSecondary,
                AutoSize = true,
                Margin = new Padding(20)
            };
            _cardsContainer.Controls.Add(lblEmpty);
        }
        else
        {
            foreach (var pet in list)
            {
                var card = new PetCardControl(pet);
                card.OnEditClicked += (s, p) => EditarPet(p);
                card.OnScheduleClicked += (s, p) => AgendarServico(p);
                _cardsContainer.Controls.Add(card);
            }
        }

        _cardsContainer.ResumeLayout();
    }

    private void AbrirNovoPet()
    {
        using var modal = new FrmPet();
        if (modal.ShowDialog() == DialogResult.OK)
        {
            LoadPets();
        }
    }

    private void EditarPet(Pet pet)
    {
        using var modal = new FrmPet(pet);
        if (modal.ShowDialog() == DialogResult.OK)
        {
            LoadPets();
        }
    }

    private void AgendarServico(Pet pet)
    {
        using var modal = new FrmAgendamento(pet);
        if (modal.ShowDialog() == DialogResult.OK)
        {
            MessageBox.Show($"Agendamento confirmado para {pet.Nome} com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
