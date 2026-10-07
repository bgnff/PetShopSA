using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PetShop.UI.Helpers;

public static class UITheme
{
    // Paleta de Cores Oficial
    public static readonly Color VeryDarkGreen = ColorTranslator.FromHtml("#073B1A");
    public static readonly Color PrimaryGreen = ColorTranslator.FromHtml("#156B3A");
    public static readonly Color LightGreen = ColorTranslator.FromHtml("#EAF7EC");
    public static readonly Color HoverGreen = ColorTranslator.FromHtml("#1B8247");
    public static readonly Color AccentOrange = ColorTranslator.FromHtml("#FF7200");
    public static readonly Color HoverOrange = ColorTranslator.FromHtml("#E66700");
    public static readonly Color BackgroundGray = ColorTranslator.FromHtml("#F6F7F8");
    public static readonly Color CardWhite = Color.White;
    public static readonly Color TextPrimary = ColorTranslator.FromHtml("#172019");
    public static readonly Color TextSecondary = ColorTranslator.FromHtml("#6B746D");
    public static readonly Color BorderColor = ColorTranslator.FromHtml("#E2E8F0");
    public static readonly Color DangerRed = ColorTranslator.FromHtml("#DC2626");
    public static readonly Color DangerBg = ColorTranslator.FromHtml("#FEE2E2");
    public static readonly Color WarningYellow = ColorTranslator.FromHtml("#D97706");
    public static readonly Color WarningBg = ColorTranslator.FromHtml("#FEF3C7");
    public static readonly Color InfoBlue = ColorTranslator.FromHtml("#2563EB");
    public static readonly Color InfoBg = ColorTranslator.FromHtml("#DBEAFE");

    // Fontes do Sistema
    public static readonly Font FontTitleLarge = new("Segoe UI", 18F, FontStyle.Bold);
    public static readonly Font FontTitle = new("Segoe UI", 14F, FontStyle.Bold);
    public static readonly Font FontSubtitle = new("Segoe UI", 10F, FontStyle.Regular);
    public static readonly Font FontBodyBold = new("Segoe UI", 9.5F, FontStyle.Bold);
    public static readonly Font FontBody = new("Segoe UI", 9.5F, FontStyle.Regular);
    public static readonly Font FontSmall = new("Segoe UI", 8.5F, FontStyle.Regular);
    public static readonly Font FontSmallBold = new("Segoe UI", 8.5F, FontStyle.Bold);
    public static readonly Font FontKpiValue = new("Segoe UI", 20F, FontStyle.Bold);

    // Utilitário para Desenho de Bordas Arredondadas
    public static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
    {
        GraphicsPath path = new();
        float d = radius * 2F;

        if (radius <= 0)
        {
            path.AddRectangle(rect);
            return path;
        }

        path.StartFigure();
        path.AddArc(rect.X, rect.Y, d, d, 180, 90);
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }

    // Configura DataGridView com visual moderno SaaS
    public static void StyleDataGridView(DataGridView dgv)
    {
        dgv.EnableHeadersVisualStyles = false;
        dgv.BorderStyle = BorderStyle.None;
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgv.GridColor = Color.FromArgb(238, 242, 246);
        dgv.BackgroundColor = Color.White;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;
        dgv.AllowUserToResizeRows = false;
        dgv.AllowUserToAddRows = false;
        dgv.RowTemplate.Height = 44;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // Cabeçalho
        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#475569");
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 10, 12, 10);
        dgv.ColumnHeadersHeight = 44;

        // Linhas padrão
        dgv.DefaultCellStyle.BackColor = Color.White;
        dgv.DefaultCellStyle.ForeColor = TextPrimary;
        dgv.DefaultCellStyle.Font = FontBody;
        dgv.DefaultCellStyle.Padding = new Padding(12, 4, 12, 4);
        dgv.DefaultCellStyle.SelectionBackColor = LightGreen;
        dgv.DefaultCellStyle.SelectionForeColor = VeryDarkGreen;

        // Alternância suave
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 253, 254);
        dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = LightGreen;
        dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = VeryDarkGreen;

        // Habilita DoubleBuffering para fluidez sem cintilação
        SetDoubleBuffered(dgv);
    }

    public static void SetDoubleBuffered(Control control)
    {
        typeof(Control).GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(control, true, null);
    }
}
