using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PetShop.UI.Helpers;

namespace PetShop.UI.Controls;

public class ModernSearchBox : UserControl
{
    private readonly TextBox _textBox;
    private string _placeholder = "Pesquisar...";
    private bool _isFocused;

    [Category("Behavior")]
    public string PlaceholderText
    {
        get => _placeholder;
        set { _placeholder = value; Invalidate(); }
    }

    [Category("Appearance")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override string? Text
    {
        get => _textBox.Text;
        set => _textBox.Text = value ?? string.Empty;
    }

    public event EventHandler? SearchTextChanged;

    public ModernSearchBox()
    {
        DoubleBuffered = true;
        Size = new Size(280, 38);
        BackColor = Color.White;

        _textBox = new TextBox
        {
            BorderStyle = BorderStyle.None,
            Font = UITheme.FontBody,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(38, 9),
            Size = new Size(Width - 48, 20),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
        };

        _textBox.TextChanged += (s, e) =>
        {
            SearchTextChanged?.Invoke(this, EventArgs.Empty);
            Invalidate();
        };

        _textBox.Enter += (s, e) => { _isFocused = true; Invalidate(); };
        _textBox.Leave += (s, e) => { _isFocused = false; Invalidate(); };

        Controls.Add(_textBox);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        if (_textBox != null)
        {
            _textBox.Location = new Point(38, (Height - _textBox.Height) / 2);
            _textBox.Width = Width - 48;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        var rect = new Rectangle(0, 0, Width - 1, Height - 1);
        using var path = UITheme.GetRoundedPath(rect, 10);

        using (var brush = new SolidBrush(Color.White))
        {
            g.FillPath(brush, path);
        }

        Color borderColor = _isFocused ? UITheme.PrimaryGreen : UITheme.BorderColor;
        using (var pen = new Pen(borderColor, _isFocused ? 1.5F : 1F))
        {
            g.DrawPath(pen, path);
        }

        // Ícone de Lupa
        using (var iconFont = new Font("Segoe UI Emoji", 11F, FontStyle.Regular))
        {
            TextRenderer.DrawText(g, "🔍", iconFont, new Rectangle(10, 0, 24, Height),
                UITheme.TextSecondary, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        // Placeholder se campo vazio e sem foco
        if (string.IsNullOrEmpty(_textBox.Text) && !_isFocused)
        {
            TextRenderer.DrawText(g, _placeholder, UITheme.FontBody,
                new Rectangle(38, 0, Width - 48, Height), ColorTranslator.FromHtml("#94A3B8"),
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }
    }
}
