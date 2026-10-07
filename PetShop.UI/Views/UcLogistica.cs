using System.Drawing;
using System.Windows.Forms;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.IoC;
using PetShop.UI.Controls;
using PetShop.UI.Helpers;

namespace PetShop.UI.Views;

public class UcLogistica : UserControl
{
    private ComboBox _cboClienteDestino = null!;
    private TextBox _txtOrigem = null!;
    private TextBox _txtDestino = null!;
    private Label _lblDistancia = null!;
    private Label _lblTempo = null!;
    private Label _lblValorFrete = null!;
    private Label _lblRegraAplicada = null!;

    public UcLogistica()
    {
        BuildUI();
        CarregarClientes();
    }

    private void BuildUI()
    {
        Dock = DockStyle.Fill;
        BackColor = UITheme.BackgroundGray;
        AutoScroll = true;
        Padding = new Padding(24, 20, 24, 24);

        // Cabeçalho
        var pnlHeader = new Panel
        {
            Dock = DockStyle.Top,
            Height = 70,
            BackColor = Color.Transparent
        };

        var lblTitle = new Label
        {
            Text = "Logística, Rotas e Taxi Dog",
            Font = UITheme.FontTitleLarge,
            ForeColor = UITheme.TextPrimary,
            Location = new Point(0, 0),
            AutoSize = true
        };

        var lblSub = new Label
        {
            Text = "Cálculo inteligente de distância, tempo de percurso e frete para transporte de pets.",
            Font = UITheme.FontSubtitle,
            ForeColor = UITheme.TextSecondary,
            Location = new Point(0, 32),
            AutoSize = true
        };

        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(lblSub);

        // Container com 2 Colunas (Esquerda: Calculadora, Direita: Tabela de Tarifas)
        var split = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 480,
            ColumnCount = 2,
            RowCount = 1,
            BackColor = Color.Transparent
        };
        split.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
        split.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));

        // Card da Calculadora
        var cardCalc = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 0, 10, 0),
            Padding = new Padding(20)
        };

        var lblCalcTitle = new Label { Text = "Simulador de Rota e Frete", Font = UITheme.FontTitle, ForeColor = UITheme.TextPrimary, Dock = DockStyle.Top, Height = 28 };

        // Seleção rápida de Cliente
        var pnlCli = new Panel { Dock = DockStyle.Top, Height = 64 };
        var lblCli = new Label { Text = "Selecionar Cliente para preencher destino automaticamente:", Font = UITheme.FontBodyBold, ForeColor = UITheme.TextPrimary, Location = new Point(0, 4), AutoSize = true };
        _cboClienteDestino = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Font = UITheme.FontBody, Location = new Point(0, 28), Size = new Size(420, 30) };
        _cboClienteDestino.SelectedIndexChanged += (s, e) => OnClienteDestinoChanged();
        pnlCli.Controls.AddRange(new Control[] { lblCli, _cboClienteDestino });

        // Endereço Origem (Pet Shop)
        var pnlOrigem = new Panel { Dock = DockStyle.Top, Height = 64 };
        var lblOrigem = new Label { Text = "Ponto de Origem (Sede Pet Shop):", Font = UITheme.FontBodyBold, ForeColor = UITheme.TextPrimary, Location = new Point(0, 4), AutoSize = true };
        _txtOrigem = new TextBox { Font = UITheme.FontBody, Location = new Point(0, 28), Size = new Size(420, 30), Text = "Rua dos Animais, 500 - Jardim Pet, São Paulo - SP" };
        pnlOrigem.Controls.AddRange(new Control[] { lblOrigem, _txtOrigem });

        // Endereço Destino (Cliente)
        var pnlDestino = new Panel { Dock = DockStyle.Top, Height = 64 };
        var lblDestino = new Label { Text = "Ponto de Destino (Residência do Pet):", Font = UITheme.FontBodyBold, ForeColor = UITheme.TextPrimary, Location = new Point(0, 4), AutoSize = true };
        _txtDestino = new TextBox { Font = UITheme.FontBody, Location = new Point(0, 28), Size = new Size(420, 30), Text = "Av. Paulista, 1500 - Bela Vista, São Paulo" };
        pnlDestino.Controls.AddRange(new Control[] { lblDestino, _txtDestino });

        // Botão Calcular
        var pnlBtn = new Panel { Dock = DockStyle.Top, Height = 50, Padding = new Padding(0, 6, 0, 0) };
        var btnCalcular = new ModernButton
        {
            Text = "🚗 Calcular Rota e Frete",
            Style = ModernButtonStyle.Primary,
            Size = new Size(220, 38),
            Location = new Point(0, 6),
            Font = UITheme.FontBodyBold
        };
        btnCalcular.Click += (s, e) => Calcular();
        pnlBtn.Controls.Add(btnCalcular);

        // Card com Resultados do Cálculo
        var cardResultado = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            BackColor = UITheme.LightGreen,
            BorderColor = ColorTranslator.FromHtml("#BCE3C6"),
            Padding = new Padding(16)
        };

        _lblDistancia = new Label { Text = "📏 Distância Estimada: 5,2 km", Font = UITheme.FontBodyBold, ForeColor = UITheme.VeryDarkGreen, Dock = DockStyle.Top, Height = 26 };
        _lblTempo = new Label { Text = "⏱️ Tempo Previsto de Deslocamento: ~19 minutos", Font = UITheme.FontBodyBold, ForeColor = UITheme.VeryDarkGreen, Dock = DockStyle.Top, Height = 26 };
        _lblValorFrete = new Label { Text = "💵 Valor do Frete: R$ 12,00", Font = UITheme.FontTitleLarge, ForeColor = UITheme.PrimaryGreen, Dock = DockStyle.Top, Height = 34 };
        _lblRegraAplicada = new Label { Text = "Regra de Tarifação: Faixa 2 (5 a 10 km = R$ 12,00)", Font = UITheme.FontSmall, ForeColor = UITheme.TextSecondary, Dock = DockStyle.Top, Height = 20 };

        cardResultado.Controls.AddRange(new Control[] { _lblRegraAplicada, _lblValorFrete, _lblTempo, _lblDistancia });

        cardCalc.Controls.Add(cardResultado);
        cardCalc.Controls.Add(pnlBtn);
        cardCalc.Controls.Add(pnlDestino);
        cardCalc.Controls.Add(pnlOrigem);
        cardCalc.Controls.Add(pnlCli);
        cardCalc.Controls.Add(lblCalcTitle);

        // Card Direito: Tabela de Regras e Instruções
        var cardRegras = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(10, 0, 0, 0),
            Padding = new Padding(20)
        };

        var lblRegrasTitle = new Label { Text = "Tabela de Fretes e Tarifas", Font = UITheme.FontTitle, ForeColor = UITheme.TextPrimary, Dock = DockStyle.Top, Height = 28 };

        var dgvRegras = new DataGridView { Dock = DockStyle.Fill };
        UITheme.StyleDataGridView(dgvRegras);
        dgvRegras.Columns.Add("Faixa", "Distância");
        dgvRegras.Columns.Add("Valor", "Tarifa de Taxi Dog");
        dgvRegras.Columns.Add("Descricao", "Observação");
        dgvRegras.Rows.Add("Até 5,0 km", "R$ 8,00", "Bairro local e arredores");
        dgvRegras.Rows.Add("5,1 a 10,0 km", "R$ 12,00", "Média distância");
        dgvRegras.Rows.Add("10,1 a 20,0 km", "R$ 20,00", "Longa distância urbana");
        dgvRegras.Rows.Add("Mais de 20,0 km", "R$ 35,00", "Sob consulta prévia");

        var pnlInfo = new Panel { Dock = DockStyle.Bottom, Height = 80, Padding = new Padding(0, 10, 0, 0) };
        var lblInfo = new Label
        {
            Text = "ℹ️ Arquitetura Pronta para APIs de Mapas:\nAs interfaces IRouteService e IFreteService já abstraem esse cálculo. Futuramente basta conectar à Google Maps API sem modificar esta tela.",
            Font = UITheme.FontSmall,
            ForeColor = UITheme.TextSecondary,
            Dock = DockStyle.Fill
        };
        pnlInfo.Controls.Add(lblInfo);

        cardRegras.Controls.Add(dgvRegras);
        cardRegras.Controls.Add(pnlInfo);
        cardRegras.Controls.Add(lblRegrasTitle);

        split.Controls.Add(cardCalc, 0, 0);
        split.Controls.Add(cardRegras, 1, 0);

        Controls.Add(split);
        Controls.Add(pnlHeader);
    }

    private void CarregarClientes()
    {
        var clientes = ServiceContainer.ClienteRepository.GetAll().Where(c => c.Ativo).ToList();
        _cboClienteDestino.DisplayMember = "Nome";
        _cboClienteDestino.ValueMember = "Id";
        _cboClienteDestino.DataSource = clientes;
    }

    private void OnClienteDestinoChanged()
    {
        if (_cboClienteDestino.SelectedItem is Cliente cliente)
        {
            _txtDestino.Text = cliente.EnderecoCompleto;
            Calcular();
        }
    }

    private void Calcular()
    {
        string origem = _txtOrigem.Text.Trim();
        string destino = _txtDestino.Text.Trim();

        var (distancia, tempo) = ServiceContainer.RouteService.CalcularRota(origem, destino);
        decimal frete = ServiceContainer.FreteService.CalcularFrete(distancia);

        _lblDistancia.Text = $"📏 Distância Estimada: {distancia:N1} km";
        _lblTempo.Text = $"⏱️ Tempo Previsto de Deslocamento: ~{tempo} minutos";
        _lblValorFrete.Text = $"💵 Valor do Frete: R$ {frete:N2}";

        string regra = distancia <= 5.0m ? "Até 5 km (R$ 8,00)" :
                       distancia <= 10.0m ? "5 a 10 km (R$ 12,00)" :
                       distancia <= 20.0m ? "10 a 20 km (R$ 20,00)" : "Mais de 20 km (R$ 35,00)";
        _lblRegraAplicada.Text = $"Regra Aplicada: {regra}";
    }
}
