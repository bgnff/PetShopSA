using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PetShop.Domain.Entities;
using PetShop.UI.Helpers;

namespace PetShop.UI.Controls;

public class PetCardControl : RoundedPanel
{
    public Pet Pet { get; }

    public event EventHandler<Pet>? OnEditClicked;
    public event EventHandler<Pet>? OnScheduleClicked;

    public PetCardControl(Pet pet)
    {
        Pet = pet;
        Size = new Size(270, 200);
        BorderRadius = 14;
        BorderColor = UITheme.BorderColor;
        BackColor = UITheme.CardWhite;
        Padding = new Padding(14);
        Margin = new Padding(8);

        BuildUI();
    }

    private void BuildUI()
    {
        // Painel Superior: Avatar + Nome + Raça
        var topPanel = new Panel
        {
            Dock = DockStyle.Top,
            Height = 58,
            BackColor = Color.Transparent
        };

        // Avatar com ícone da espécie
        var avatarPanel = new Panel
        {
            Size = new Size(50, 50),
            Location = new Point(0, 4),
            BackColor = UITheme.LightGreen
        };
        avatarPanel.Paint += (s, e) =>
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(UITheme.LightGreen);
            e.Graphics.FillEllipse(brush, 0, 0, 48, 48);

            string icon = Pet.Especie.ToLower().Contains("gato") ? "🐱" : "🐶";
            using var f = new Font("Segoe UI Emoji", 18F);
            TextRenderer.DrawText(e.Graphics, icon, f, new Rectangle(0, 0, 50, 50),
                UITheme.VeryDarkGreen, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        };

        var lblName = new Label
        {
            Text = Pet.Nome,
            Font = UITheme.FontTitle,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(58, 4),
            AutoSize = true
        };

        var lblBreed = new Label
        {
            Text = $"{Pet.Especie} • {Pet.Raca}",
            Font = UITheme.FontSmall,
            ForeColor = UITheme.TextSecondary,
            Location = new Point(58, 28),
            AutoSize = true
        };

        topPanel.Controls.Add(avatarPanel);
        topPanel.Controls.Add(lblName);
        topPanel.Controls.Add(lblBreed);

        // Painel Central: Informações de Tutor, Porte, Peso
        var infoPanel = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent,
            Padding = new Padding(0, 6, 0, 0)
        };

        string tutorNome = Pet.Cliente?.Nome ?? "Tutor não vinculado";
        var lblTutor = new Label
        {
            Text = $"👤 Tutor: {tutorNome}",
            Font = UITheme.FontBody,
            ForeColor = UITheme.TextPrimary,
            Dock = DockStyle.Top,
            Height = 22
        };

        var lblDetails = new Label
        {
            Text = $"⚖️ Porte {Pet.Porte} • {Pet.Peso:N1} kg • {Pet.Sexo}",
            Font = UITheme.FontSmall,
            ForeColor = UITheme.TextSecondary,
            Dock = DockStyle.Top,
            Height = 22
        };

        string obs = string.IsNullOrWhiteSpace(Pet.Observacoes) ? "Sem observações registradas." : Pet.Observacoes;
        var lblObs = new Label
        {
            Text = $"📝 {obs}",
            Font = UITheme.FontSmall,
            ForeColor = ColorTranslator.FromHtml("#94A3B8"),
            Dock = DockStyle.Top,
            Height = 20
        };

        infoPanel.Controls.Add(lblObs);
        infoPanel.Controls.Add(lblDetails);
        infoPanel.Controls.Add(lblTutor);

        // Painel Inferior: Botões de Ação
        var actionPanel = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 36,
            BackColor = Color.Transparent
        };

        var btnSchedule = new ModernButton
        {
            Text = "Agendar",
            Style = ModernButtonStyle.Primary,
            Size = new Size(115, 34),
            Location = new Point(0, 0),
            Font = UITheme.FontSmallBold
        };
        btnSchedule.Click += (s, e) => OnScheduleClicked?.Invoke(this, Pet);

        var btnEdit = new ModernButton
        {
            Text = "Editar",
            Style = ModernButtonStyle.Secondary,
            Size = new Size(115, 34),
            Location = new Point(125, 0),
            Font = UITheme.FontSmallBold
        };
        btnEdit.Click += (s, e) => OnEditClicked?.Invoke(this, Pet);

        actionPanel.Controls.Add(btnSchedule);
        actionPanel.Controls.Add(btnEdit);

        Controls.Add(infoPanel);
        Controls.Add(actionPanel);
        Controls.Add(topPanel);
    }
}
