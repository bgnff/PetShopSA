using System.Drawing;
using System.Drawing.Drawing2D;
using PetShop.Infrastructure.IoC;
using PetShop.UI.Controls;
using PetShop.UI.Helpers;
using PetShop.UI.Views;

namespace PetShop.UI.Forms;

public partial class FrmMain : Form
{
    private bool _isSidebarCollapsed;
    private readonly List<ModernButton> _menuButtons = new();
    private Label _lblLogoTitle = null!;
    private UserControl? _currentPage;

    public FrmMain()
    {
        InitializeComponent();
        ConstruirHeader();
        ConstruirSidebar();
        NavegarPara("Dashboard");
    }

    private void ConstruirSidebar()
    {
        // Topo da Sidebar: Logo, Nome e Botão de Recolher
        var pnlBrand = new Panel
        {
            Dock = DockStyle.Top,
            Height = 65,
            BackColor = Color.FromArgb(5, 45, 20),
            Padding = new Padding(16, 12, 12, 12)
        };

        _lblLogoTitle = new Label
        {
            Text = "🐾 PetShop",
            Font = UITheme.FontTitle,
            ForeColor = Color.White,
            Location = new Point(14, 18),
            AutoSize = true
        };

        var btnToggleSidebar = new Label
        {
            Text = "☰",
            Font = new Font("Segoe UI", 13F, FontStyle.Bold),
            ForeColor = Color.FromArgb(200, 230, 210),
            Cursor = Cursors.Hand,
            Size = new Size(32, 32),
            Location = new Point(pnlSidebar.Width - 42, 16),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            TextAlign = ContentAlignment.MiddleCenter
        };
        btnToggleSidebar.Click += (s, e) => AlternarSidebar();

        pnlBrand.Controls.Add(_lblLogoTitle);
        pnlBrand.Controls.Add(btnToggleSidebar);

        // Menu com Scroll caso a tela seja menor
        var pnlMenuContainer = new Panel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            BackColor = UITheme.VeryDarkGreen,
            Padding = new Padding(8, 12, 8, 12)
        };

        // Itens de Menu
        AdicionarItemMenu(pnlMenuContainer, "📊 Dashboard", "Dashboard");
        AdicionarSeparador(pnlMenuContainer, "CLIENTES & PETS");
        AdicionarItemMenu(pnlMenuContainer, "👥 Clientes", "Clientes");
        AdicionarItemMenu(pnlMenuContainer, "🐶 Pets", "Pets");

        AdicionarSeparador(pnlMenuContainer, "ATENDIMENTOS");
        AdicionarItemMenu(pnlMenuContainer, "📅 Agenda", "Agenda");
        AdicionarItemMenu(pnlMenuContainer, "✂️ Atendimentos", "Atendimentos");
        AdicionarItemMenu(pnlMenuContainer, "🏷️ Serviços", "Serviços");

        AdicionarSeparador(pnlMenuContainer, "COMERCIAL & ESTOQUE");
        AdicionarItemMenu(pnlMenuContainer, "📦 Produtos", "Produtos");
        AdicionarItemMenu(pnlMenuContainer, "📊 Estoque", "Estoque");
        AdicionarItemMenu(pnlMenuContainer, "🛒 Vendas (PDV)", "Vendas");

        AdicionarSeparador(pnlMenuContainer, "LOGÍSTICA & GESTÃO");
        AdicionarItemMenu(pnlMenuContainer, "🚚 Rotas e Fretes", "Logística");
        AdicionarItemMenu(pnlMenuContainer, "📈 Relatórios", "Relatórios");

        // Rodapé da Sidebar: Sair
        var pnlFooter = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 60,
            BackColor = Color.FromArgb(5, 45, 20),
            Padding = new Padding(8, 8, 8, 8)
        };

        var btnSair = new ModernButton
        {
            Text = "🚪 Sair do Sistema",
            Style = ModernButtonStyle.Ghost,
            Dock = DockStyle.Fill,
            ForeColor = Color.FromArgb(254, 202, 202),
            Font = UITheme.FontSmallBold
        };
        btnSair.Click += (s, e) => Logout();

        pnlFooter.Controls.Add(btnSair);

        pnlSidebar.Controls.Add(pnlMenuContainer);
        pnlSidebar.Controls.Add(pnlFooter);
        pnlSidebar.Controls.Add(pnlBrand);
    }

    private void AdicionarSeparador(Panel container, string texto)
    {
        var lbl = new Label
        {
            Text = texto,
            Font = UITheme.FontSmallBold,
            ForeColor = ColorTranslator.FromHtml("#6E997C"),
            Height = 24,
            Dock = DockStyle.Top,
            Padding = new Padding(8, 8, 0, 0)
        };
        container.Controls.Add(lbl);
        lbl.BringToFront();
    }

    private void AdicionarItemMenu(Panel container, string titulo, string tag)
    {
        var btn = new ModernButton
        {
            Text = titulo,
            Tag = tag,
            Style = ModernButtonStyle.Ghost,
            Height = 38,
            Dock = DockStyle.Top,
            Font = UITheme.FontBody,
            TextAlign = ContentAlignment.MiddleLeft,
            Margin = new Padding(0, 2, 0, 2)
        };

        btn.Click += (s, e) => NavegarPara(tag);
        _menuButtons.Add(btn);

        container.Controls.Add(btn);
        btn.BringToFront();
    }

    private void AlternarSidebar()
    {
        _isSidebarCollapsed = !_isSidebarCollapsed;
        pnlSidebar.Width = _isSidebarCollapsed ? 65 : 240;
        _lblLogoTitle.Visible = !_isSidebarCollapsed;

        foreach (var b in _menuButtons)
        {
            if (_isSidebarCollapsed)
            {
                string txt = b.Text;
                if (txt.Length >= 2)
                    b.Text = txt.Substring(0, 2);
            }
            else
            {
                string tag = b.Tag?.ToString() ?? "";
                b.Text = tag switch
                {
                    "Dashboard" => "📊 Dashboard",
                    "Clientes" => "👥 Clientes",
                    "Pets" => "🐶 Pets",
                    "Agenda" => "📅 Agenda",
                    "Atendimentos" => "✂️ Atendimentos",
                    "Serviços" => "🏷️ Serviços",
                    "Produtos" => "📦 Produtos",
                    "Estoque" => "📊 Estoque",
                    "Vendas" => "🛒 Vendas (PDV)",
                    "Logística" => "🚚 Rotas e Fretes",
                    "Relatórios" => "📈 Relatórios",
                    _ => tag
                };
            }
        }
    }

    private void ConstruirHeader()
    {
        pnlHeader.Paint += (s, e) =>
        {
            using var pen = new Pen(UITheme.BorderColor, 1);
            e.Graphics.DrawLine(pen, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
        };

        var funcionario = ServiceContainer.AuthenticationService.CurrentUser;
        string nomeFuncionario = funcionario?.Nome ?? "Administrador";
        string cargoFuncionario = funcionario?.Cargo ?? "Gerente Geral";

        // Saudação na Esquerda
        var pnlGreeting = new Panel { Dock = DockStyle.Left, Width = 350, BackColor = Color.Transparent };
        var lblGreeting = new Label
        {
            Text = $"Bom dia, {nomeFuncionario} 👋",
            Font = UITheme.FontTitle,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(24, 12),
            AutoSize = true
        };
        var lblRole = new Label
        {
            Text = $"Cargo: {cargoFuncionario} • Pet Shop Central",
            Font = UITheme.FontSmall,
            ForeColor = UITheme.TextSecondary,
            Location = new Point(24, 38),
            AutoSize = true
        };
        pnlGreeting.Controls.AddRange(new Control[] { lblGreeting, lblRole });

        // Bloco de Perfil e Notificações na Direita
        var pnlRight = new Panel
        {
            Dock = DockStyle.Right,
            Width = 280,
            BackColor = Color.Transparent
        };

        // Ícone de Sino de Notificação
        var btnBell = new Label
        {
            Text = "🔔 3",
            Font = UITheme.FontSmallBold,
            ForeColor = UITheme.PrimaryGreen,
            BackColor = UITheme.LightGreen,
            Size = new Size(50, 32),
            Location = new Point(30, 16),
            TextAlign = ContentAlignment.MiddleCenter,
            Cursor = Cursors.Hand
        };
        btnBell.Paint += (s, e) =>
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var path = UITheme.GetRoundedPath(new Rectangle(0, 0, btnBell.Width - 1, btnBell.Height - 1), 8);
            using var pen = new Pen(ColorTranslator.FromHtml("#BCE3C6"), 1);
            e.Graphics.DrawPath(pen, path);
        };
        btnBell.Click += (s, e) => MessageBox.Show("Você tem 3 notificações:\n1. 2 produtos com estoque baixo.\n2. Banho do Thor agendado para as 08:00.\n3. Novo cliente cadastrado.", "Notificações", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // Avatar Circular
        var pnlAvatar = new Panel
        {
            Size = new Size(38, 38),
            Location = new Point(95, 13),
            BackColor = Color.Transparent
        };
        pnlAvatar.Paint += (s, e) =>
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(UITheme.PrimaryGreen);
            e.Graphics.FillEllipse(brush, 0, 0, 37, 37);
            TextRenderer.DrawText(e.Graphics, "CE", UITheme.FontBodyBold, new Rectangle(0, 0, 38, 38),
                Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        };

        // Nome do Usuário e Menu Suspenso
        var lblUser = new Label
        {
            Text = nomeFuncionario,
            Font = UITheme.FontBodyBold,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(140, 14),
            AutoSize = true
        };

        var lblLogout = new Label
        {
            Text = "Encerrar Sessão",
            Font = UITheme.FontSmall,
            ForeColor = UITheme.AccentOrange,
            Location = new Point(140, 34),
            AutoSize = true,
            Cursor = Cursors.Hand
        };
        lblLogout.Click += (s, e) => Logout();

        pnlRight.Controls.AddRange(new Control[] { btnBell, pnlAvatar, lblUser, lblLogout });

        pnlHeader.Controls.Add(pnlGreeting);
        pnlHeader.Controls.Add(pnlRight);
    }

    public void OpenPage(UserControl page)
    {
        pnlContent.SuspendLayout();

        if (_currentPage != null)
        {
            pnlContent.Controls.Remove(_currentPage);
            _currentPage.Dispose();
        }

        _currentPage = page;
        page.Dock = DockStyle.Fill;
        pnlContent.Controls.Add(page);

        pnlContent.ResumeLayout();
    }

    public void NavegarPara(string destino)
    {
        foreach (var b in _menuButtons)
        {
            b.IsSelected = (b.Tag?.ToString() == destino);
        }

        UserControl page = destino switch
        {
            "Dashboard" => new UcDashboard(tag => NavegarPara(tag)),
            "Clientes" => new UcClientes(),
            "Pets" => new UcPets(),
            "Agenda" => new UcAgenda(),
            "Atendimentos" => new UcAtendimentos(),
            "Serviços" => new UcServicos(),
            "Produtos" => new UcProdutos(),
            "Estoque" => new UcEstoque(),
            "Vendas" => new UcVendas(),
            "Logística" => new UcLogistica(),
            "Relatórios" => new UcRelatorios(),
            _ => new UcDashboard(tag => NavegarPara(tag))
        };

        OpenPage(page);
    }

    private void Logout()
    {
        var confirm = MessageBox.Show("Deseja realmente sair do sistema PetShop Manager?", "Encerrar Sessão",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (confirm == DialogResult.Yes)
        {
            ServiceContainer.AuthenticationService.Logout();
            Hide();
            var frmLogin = new FrmLogin();
            frmLogin.FormClosed += (s, e) => Close();
            frmLogin.Show();
        }
    }
}
