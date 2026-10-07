using System.IO;
using PetShop.Infrastructure.IoC;

namespace PetShop.UI.Forms;

public partial class FrmLogin : Form
{
    public FrmLogin()
    {
        InitializeComponent();
        CarregarImagemHero();
    }

    private void CarregarImagemHero()
    {
        try
        {
            string heroPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "pet_hero.jpg");
            if (File.Exists(heroPath))
            {
                picHero.Image = Image.FromFile(heroPath);
                return;
            }

            string devHeroPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "pet_hero.jpg");
            if (File.Exists(devHeroPath))
            {
                picHero.Image = Image.FromFile(devHeroPath);
            }
        }
        catch
        {
            // Tratamento silencioso em tempo de design
        }
    }

    private void btnEntrar_Click(object? sender, EventArgs e)
    {
        ExecutarLogin();
    }

    private void ExecutarLogin()
    {
        string usuario = txtUsuario.Text.Trim();
        string senha = txtSenha.Text;

        var authService = ServiceContainer.AuthenticationService;
        var funcionario = authService.Login(usuario, senha);

        if (funcionario == null)
        {
            lblError.Text = "Usuário ou senha inválidos.";
            lblError.Visible = true;
            txtSenha.Focus();
            txtSenha.SelectAll();
            return;
        }

        lblError.Visible = false;

        // Login realizado com sucesso! Abre tela principal
        Hide();
        var frmMain = new FrmMain();
        frmMain.FormClosed += (s, e) => Close();
        frmMain.Show();
    }

    private void lblLogo_Click(object sender, EventArgs e)
    {

    }
}
