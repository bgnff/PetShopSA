using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PetShop.UI.Helpers;

namespace PetShop.UI.Controls;

public enum ModernButtonStyle
{
    Primary,
    Accent,
    Secondary,
    Outline,
    Danger,
    Ghost
}

public class ModernButton : Button
{
    private int _borderRadius = 8;
    private ModernButtonStyle _style = ModernButtonStyle.Primary;
    private bool _isHovered;
    private bool _isPressed;
    private bool _isSelected;

    [Category("Appearance")]
    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = value; Invalidate(); }
    }

    [Category("Appearance")]
    public ModernButtonStyle Style
    {
        get => _style;
        set { _style = value; ApplyStyle(); Invalidate(); }
    }

    [Category("Appearance")]
    public bool IsSelected
    {
        get => _isSelected;
        set { _isSelected = value; Invalidate(); }
    }

    public ModernButton()
    {
        DoubleBuffered = true;
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Cursor = Cursors.Hand;
        Font = UITheme.FontBodyBold;
        Size = new Size(130, 40);
        ApplyStyle();
    }

    private void ApplyStyle()
    {
        switch (_style)
        {
            case ModernButtonStyle.Primary:
                BackColor = UITheme.PrimaryGreen;
                ForeColor = Color.White;
                break;
            case ModernButtonStyle.Accent:
                BackColor = UITheme.AccentOrange;
                ForeColor = Color.White;
                break;
            case ModernButtonStyle.Secondary:
                BackColor = UITheme.LightGreen;
                ForeColor = UITheme.VeryDarkGreen;
                break;
            case ModernButtonStyle.Outline:
                BackColor = Color.White;
                ForeColor = UITheme.TextPrimary;
                break;
            case ModernButtonStyle.Danger:
                BackColor = UITheme.DangerRed;
                ForeColor = Color.White;
                break;
            case ModernButtonStyle.Ghost:
                BackColor = Color.Transparent;
                ForeColor = Color.White;
                break;
        }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        _isHovered = true;
        Invalidate();
        base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        _isHovered = false;
        Invalidate();
        base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(MouseEventArgs mevent)
    {
        _isPressed = true;
        Invalidate();
        base.OnMouseDown(mevent);
    }

    protected override void OnMouseUp(MouseEventArgs mevent)
    {
        _isPressed = false;
        Invalidate();
        base.OnMouseUp(mevent);
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        var rect = new Rectangle(0, 0, Width - 1, Height - 1);
        using var path = UITheme.GetRoundedPath(rect, _borderRadius);

        Color currentBg;
        Color currentFg;
        Color borderColor = Color.Transparent;

        if (_style == ModernButtonStyle.Ghost)
        {
            if (_isSelected)
            {
                currentBg = UITheme.PrimaryGreen;
                currentFg = Color.White;
            }
            else if (_isHovered)
            {
                currentBg = Color.FromArgb(40, 255, 255, 255);
                currentFg = Color.White;
            }
            else
            {
                currentBg = Color.Transparent;
                currentFg = Color.FromArgb(220, 255, 255, 255);
            }
        }
        else if (_style == ModernButtonStyle.Outline)
        {
            currentBg = _isHovered ? UITheme.LightGreen : Color.White;
            currentFg = _isHovered ? UITheme.PrimaryGreen : UITheme.TextPrimary;
            borderColor = _isHovered ? UITheme.PrimaryGreen : UITheme.BorderColor;
        }
        else if (_style == ModernButtonStyle.Secondary)
        {
            currentBg = _isHovered ? Color.FromArgb(215, 240, 220) : UITheme.LightGreen;
            currentFg = UITheme.VeryDarkGreen;
        }
        else if (_style == ModernButtonStyle.Accent)
        {
            currentBg = _isPressed ? Color.FromArgb(210, 85, 0) : (_isHovered ? UITheme.HoverOrange : UITheme.AccentOrange);
            currentFg = Color.White;
        }
        else if (_style == ModernButtonStyle.Danger)
        {
            currentBg = _isHovered ? Color.FromArgb(185, 28, 28) : UITheme.DangerRed;
            currentFg = Color.White;
        }
        else // Primary
        {
            currentBg = _isPressed ? UITheme.VeryDarkGreen : (_isHovered ? UITheme.HoverGreen : UITheme.PrimaryGreen);
            currentFg = Color.White;
        }

        // Desenha Fundo
        using (var brush = new SolidBrush(currentBg))
        {
            g.FillPath(brush, path);
        }

        // Desenha Borda se Outline ou Ghost selecionado
        if (borderColor != Color.Transparent)
        {
            using var pen = new Pen(borderColor, 1);
            g.DrawPath(pen, path);
        }
        else if (_style == ModernButtonStyle.Ghost && _isSelected)
        {
            // Barra lateral de destaque laranja no menu selecionado
            using var orangeBrush = new SolidBrush(UITheme.AccentOrange);
            g.FillRectangle(orangeBrush, new Rectangle(0, 4, 4, Height - 8));
        }

        // Desenha Ícone se houver
        int textX = 12;
        if (Image != null)
        {
            int imgY = (Height - Image.Height) / 2;
            int imgX = 14;
            g.DrawImage(Image, imgX, imgY, Image.Width, Image.Height);
            textX = imgX + Image.Width + 8;
        }

        // Desenha Texto
        TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine;
        if (TextAlign == ContentAlignment.MiddleCenter && Image == null)
        {
            flags |= TextFormatFlags.HorizontalCenter;
            TextRenderer.DrawText(g, Text, Font, new Rectangle(0, 0, Width, Height), currentFg, flags);
        }
        else
        {
            flags |= TextFormatFlags.Left;
            int textWidth = Width - textX - 8;
            TextRenderer.DrawText(g, Text, Font, new Rectangle(textX, 0, textWidth, Height), currentFg, flags);
        }
    }
}
