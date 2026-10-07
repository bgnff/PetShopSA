using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PetShop.UI.Helpers;

namespace PetShop.UI.Controls;

public class KpiCard : RoundedPanel
{
    private string _title = "Métrica";
    private string _value = "0";
    private string _indicatorText = "+0%";
    private bool _isPositiveIndicator = true;
    private string _iconText = "📊";
    private Color _iconBgColor = UITheme.LightGreen;
    private Color _iconFgColor = UITheme.PrimaryGreen;

    [Category("KPI Data")]
    public string Title
    {
        get => _title;
        set { _title = value; Invalidate(); }
    }

    [Category("KPI Data")]
    public string Value
    {
        get => _value;
        set { _value = value; Invalidate(); }
    }

    [Category("KPI Data")]
    public string IndicatorText
    {
        get => _indicatorText;
        set { _indicatorText = value; Invalidate(); }
    }

    [Category("KPI Data")]
    public bool IsPositiveIndicator
    {
        get => _isPositiveIndicator;
        set { _isPositiveIndicator = value; Invalidate(); }
    }

    [Category("KPI Data")]
    public string IconText
    {
        get => _iconText;
        set { _iconText = value; Invalidate(); }
    }

    [Category("KPI Data")]
    public Color IconBgColor
    {
        get => _iconBgColor;
        set { _iconBgColor = value; Invalidate(); }
    }

    [Category("KPI Data")]
    public Color IconFgColor
    {
        get => _iconFgColor;
        set { _iconFgColor = value; Invalidate(); }
    }

    public KpiCard()
    {
        Size = new Size(210, 115);
        BorderRadius = 14;
        BorderColor = UITheme.BorderColor;
        BackColor = UITheme.CardWhite;
        Padding = new Padding(16);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // Desenha Círculo / Quadrado arredondado do Ícone no topo direito
        int iconSize = 40;
        int iconX = Width - iconSize - 16;
        int iconY = 16;
        var iconRect = new Rectangle(iconX, iconY, iconSize, iconSize);

        using (var iconPath = UITheme.GetRoundedPath(iconRect, 10))
        using (var brush = new SolidBrush(_iconBgColor))
        {
            g.FillPath(brush, iconPath);
        }

        // Desenha o caractere/emoji do ícone
        using (var iconFont = new Font("Segoe UI Emoji", 14F, FontStyle.Regular))
        {
            TextRenderer.DrawText(g, _iconText, iconFont, iconRect, _iconFgColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // Título da métrica
        var titleRect = new Rectangle(16, 16, Width - iconSize - 36, 20);
        TextRenderer.DrawText(g, _title, UITheme.FontSubtitle, titleRect, UITheme.TextSecondary,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

        // Valor principal grande
        var valueRect = new Rectangle(16, 40, Width - 32, 38);
        TextRenderer.DrawText(g, _value, UITheme.FontKpiValue, valueRect, UITheme.TextPrimary,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

        // Indicador / Badge inferior
        if (!string.IsNullOrWhiteSpace(_indicatorText))
        {
            Color indBg = _isPositiveIndicator ? UITheme.LightGreen : UITheme.DangerBg;
            Color indFg = _isPositiveIndicator ? UITheme.PrimaryGreen : UITheme.DangerRed;

            var indSize = TextRenderer.MeasureText(_indicatorText, UITheme.FontSmallBold);
            var indRect = new Rectangle(16, Height - 30, indSize.Width + 12, 20);

            using (var indPath = UITheme.GetRoundedPath(indRect, 6))
            using (var brush = new SolidBrush(indBg))
            {
                g.FillPath(brush, indPath);
            }

            TextRenderer.DrawText(g, _indicatorText, UITheme.FontSmallBold, indRect, indFg,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
