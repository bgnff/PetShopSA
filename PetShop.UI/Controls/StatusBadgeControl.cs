using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PetShop.Domain.Enums;
using PetShop.UI.Helpers;

namespace PetShop.UI.Controls;

public class StatusBadgeControl : Control
{
    private string _badgeText = "Status";
    private Color _badgeBg = UITheme.LightGreen;
    private Color _badgeFg = UITheme.PrimaryGreen;

    [Category("Appearance")]
    public string BadgeText
    {
        get => _badgeText;
        set { _badgeText = value; Invalidate(); }
    }

    [Category("Appearance")]
    public Color BadgeBg
    {
        get => _badgeBg;
        set { _badgeBg = value; Invalidate(); }
    }

    [Category("Appearance")]
    public Color BadgeFg
    {
        get => _badgeFg;
        set { _badgeFg = value; Invalidate(); }
    }

    public StatusBadgeControl()
    {
        DoubleBuffered = true;
        Size = new Size(110, 26);
        Font = UITheme.FontSmallBold;
    }

    public void SetStatus(StatusAgendamento status)
    {
        _badgeText = status switch
        {
            StatusAgendamento.Confirmado => "Confirmado",
            StatusAgendamento.Pendente => "Pendente",
            StatusAgendamento.EmAtendimento => "Em Atendimento",
            StatusAgendamento.Finalizado => "Finalizado",
            StatusAgendamento.Cancelado => "Cancelado",
            _ => status.ToString()
        };

        (_badgeBg, _badgeFg) = status switch
        {
            StatusAgendamento.Confirmado => (UITheme.LightGreen, UITheme.PrimaryGreen),
            StatusAgendamento.Pendente => (UITheme.WarningBg, UITheme.WarningYellow),
            StatusAgendamento.EmAtendimento => (UITheme.InfoBg, UITheme.InfoBlue),
            StatusAgendamento.Finalizado => (Color.FromArgb(241, 245, 249), Color.FromArgb(71, 85, 105)),
            StatusAgendamento.Cancelado => (UITheme.DangerBg, UITheme.DangerRed),
            _ => (UITheme.LightGreen, UITheme.PrimaryGreen)
        };

        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        var rect = new Rectangle(0, 0, Width - 1, Height - 1);
        using var path = UITheme.GetRoundedPath(rect, Height / 2);

        using (var brush = new SolidBrush(_badgeBg))
        {
            g.FillPath(brush, path);
        }

        TextRenderer.DrawText(g, _badgeText, Font, rect, _badgeFg,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
}
