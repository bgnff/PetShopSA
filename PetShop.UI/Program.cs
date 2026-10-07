using System.Windows.Forms;
using PetShop.UI.Forms;

namespace PetShop.UI;

static class Program
{
    /// <summary>
    ///  Ponto de entrada principal para a aplicação.
    /// </summary>
    [STAThread]
    static void Main()
    {
        System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
        System.Windows.Forms.Application.EnableVisualStyles();
        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
        System.Windows.Forms.Application.Run(new FrmLogin());
    }    
}