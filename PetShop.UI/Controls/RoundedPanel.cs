using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PetShop.UI.Helpers;

namespace PetShop.UI.Controls;

public class RoundedPanel : Panel
{
    private int _borderRadius = 12;
    private Color _borderColor = UITheme.BorderColor;
    private int _borderWidth = 1;

    [Category("Appearance")]
    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = value; Invalidate(); }
    }

    [Category("Appearance")]
    public Color BorderColor
    {
        get => _borderColor;
        set { _borderColor = value; Invalidate(); }
    }

    [Category("Appearance")]
    public int BorderWidth
    {
        get => _borderWidth;
        set { _borderWidth = value; Invalidate(); }
    }

    public RoundedPanel()
    {
        DoubleBuffered = true;
        BackColor = UITheme.CardWhite;
        Padding = new Padding(16);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        var rect = new Rectangle(0, 0, Width - 1, Height - 1);
        using var path = UITheme.GetRoundedPath(rect, _borderRadius);

        using var brush = new SolidBrush(BackColor);
        e.Graphics.FillPath(brush, path);

        if (_borderWidth > 0 && _borderColor != Color.Transparent)
        {
            using var pen = new Pen(_borderColor, _borderWidth);
            e.Graphics.DrawPath(pen, path);
        }
    }
}
