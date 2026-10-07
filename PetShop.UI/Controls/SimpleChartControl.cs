using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PetShop.UI.Helpers;

namespace PetShop.UI.Controls;

public class SimpleChartControl : UserControl
{
    private string _chartTitle = "Vendas nos últimos 7 dias";
    private readonly List<(string Label, decimal Value)> _dataPoints = new()
    {
        ("Seg", 1250m),
        ("Ter", 2100m),
        ("Qua", 1850m),
        ("Qui", 2400m),
        ("Sex", 3100m),
        ("Sáb", 3950m),
        ("Hoje", 3420m)
    };

    [Category("Chart Data")]
    public string ChartTitle
    {
        get => _chartTitle;
        set { _chartTitle = value; Invalidate(); }
    }

    public SimpleChartControl()
    {
        DoubleBuffered = true;
        Size = new Size(500, 240);
        BackColor = UITheme.CardWhite;
    }

    public void SetData(IEnumerable<(string Label, decimal Value)> points)
    {
        _dataPoints.Clear();
        _dataPoints.AddRange(points);
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // Borda e fundo arredondado do card
        var cardRect = new Rectangle(0, 0, Width - 1, Height - 1);
        using (var path = UITheme.GetRoundedPath(cardRect, 14))
        {
            using var bgBrush = new SolidBrush(BackColor);
            g.FillPath(bgBrush, path);

            using var borderPen = new Pen(UITheme.BorderColor, 1);
            g.DrawPath(borderPen, path);
        }

        // Título do gráfico
        var titleRect = new Rectangle(18, 16, Width - 36, 24);
        TextRenderer.DrawText(g, _chartTitle, UITheme.FontBodyBold, titleRect, UITheme.TextPrimary,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

        // Subtítulo
        var subRect = new Rectangle(18, 38, Width - 36, 18);
        TextRenderer.DrawText(g, "Faturamento diário em R$", UITheme.FontSmall, subRect, UITheme.TextSecondary,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

        if (_dataPoints.Count == 0) return;

        // Área do gráfico
        int plotX = 24;
        int plotY = 70;
        int plotWidth = Width - 48;
        int plotHeight = Height - plotY - 38;

        decimal maxValue = _dataPoints.Max(p => p.Value);
        if (maxValue <= 0) maxValue = 1000m;
        // Arredonda para cima para o topo da escala
        maxValue = Math.Ceiling(maxValue / 1000m) * 1000m;

        // Linhas de grade horizontais
        using var gridPen = new Pen(Color.FromArgb(241, 245, 249), 1);
        gridPen.DashStyle = DashStyle.Dash;

        int gridLines = 4;
        for (int i = 0; i <= gridLines; i++)
        {
            int gy = plotY + (int)(plotHeight * (1F - (float)i / gridLines));
            g.DrawLine(gridPen, plotX, gy, plotX + plotWidth, gy);
        }

        // Desenho das Barras
        int barCount = _dataPoints.Count;
        float slotWidth = (float)plotWidth / barCount;
        float barWidth = Math.Min(38F, slotWidth * 0.55F);

        for (int i = 0; i < barCount; i++)
        {
            var point = _dataPoints[i];
            float cx = plotX + (i + 0.5F) * slotWidth;
            float barLeft = cx - (barWidth / 2F);

            float barH = (float)((double)point.Value / (double)maxValue * plotHeight);
            if (barH < 6) barH = 6;
            float barTop = plotY + plotHeight - barH;

            var barRect = new RectangleF(barLeft, barTop, barWidth, barH);

            // Destaca a maior barra ou a barra de "Hoje" com gradiente especial
            bool isHighlight = i == barCount - 1; // Hoje
            Color colTop = isHighlight ? UITheme.AccentOrange : UITheme.PrimaryGreen;
            Color colBottom = isHighlight ? Color.FromArgb(255, 160, 60) : Color.FromArgb(46, 175, 102);

            using (var barPath = UITheme.GetRoundedPath(Rectangle.Round(barRect), 6))
            using (var brush = new LinearGradientBrush(barRect, colTop, colBottom, LinearGradientMode.Vertical))
            {
                g.FillPath(brush, barPath);
            }

            // Valor acima da barra
            string valText = $"R${point.Value:N0}";
            var valSize = TextRenderer.MeasureText(valText, UITheme.FontSmallBold);
            var valRect = new Rectangle((int)(cx - valSize.Width / 2), (int)(barTop - 18), valSize.Width + 4, 16);
            TextRenderer.DrawText(g, valText, UITheme.FontSmallBold, valRect,
                isHighlight ? UITheme.AccentOrange : UITheme.TextSecondary,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            // Label do dia da semana abaixo da barra
            var lblRect = new Rectangle((int)(cx - slotWidth / 2), plotY + plotHeight + 8, (int)slotWidth, 20);
            TextRenderer.DrawText(g, point.Label, isHighlight ? UITheme.FontBodyBold : UITheme.FontSmall,
                lblRect, isHighlight ? UITheme.TextPrimary : UITheme.TextSecondary,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.Top);
        }
    }
}
