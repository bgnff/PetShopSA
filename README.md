# 🐾 PetShop Manager

> Sistema desktop administrativo completo e profissional para gerenciamento de Pet Shop desenvolvido em **C#**, **.NET 8** e **Windows Forms (WinForms)**, com arquitetura em camadas e desacoplamento total, 100% preparado para futura integração com banco de dados **SQL Server** e **Entity Framework Core**.

---

## 📌 1. Objetivo do Projeto

O **PetShop Manager** foi concebido para atender às rotinas operacionais, comerciais e de atendimento de clínicas e pet shops modernos. Ele unifica o fluxo desde a recepção e cadastro de clientes e pets até agendamento de serviços, controle de atendimentos em tempo real, ponto de venda (PDV/Caixa), almoxarifado de estoque, logística de transporte (Taxi Dog) e relatórios gerenciais com indicadores de desempenho (KPIs).

---

## 🚀 2. Tecnologias Utilizadas

- **Linguagem:** C# 12 / .NET 8.0
- **Framework UI:** Windows Forms (WinForms) estilizado com visual SaaS contemporâneo
- **Resolução & Responsividade:** Projetado para 1920x1080 com suporte fluido a 1600x900 e 1366x768 através de layouts responsivos (`Dock`, `Anchor`, `TableLayoutPanel`, `FlowLayoutPanel`)
- **Renderização Gráfica:** GDI+ com anti-aliasing e `DoubleBuffered` ativado em todos os componentes para eliminar *flickering*
- **Arquitetura:** Clean Architecture / DDD Light (Separação estrita de responsabilidades)

---

## 📂 3. Estrutura da Solução e Projetos

A solução foi organizada em 4 projetos modulares independentes:

```text
PetShopManager/
├── PetShop.sln                   # Arquivo de solução compatível com Visual Studio 2022+
├── PetShop.slnx                  # Arquivo de solução no novo formato XML
│
├── PetShop.Domain/               # Camada de Domínio (Entidades e Enums do Negócio)
│   ├── Entities/
│   │   ├── Cliente.cs            # Cadastro de clientes e dados de contato
│   │   ├── Pet.cs                # Dados dos pets, raça, porte e vínculos
│   │   ├── Servico.cs            # Catálogo de serviços, tempos e preços
│   │   ├── Agendamento.cs        # Agendamentos de serviços e taxi dog
│   │   ├── Atendimento.cs        # Atendimentos em execução e finalizados
│   │   ├── Produto.cs            # Produtos, SKU, categorias e estoque
│   │   ├── Venda.cs              # Registro de vendas e pedidos
│   │   ├── ItemVenda.cs          # Itens da venda
│   │   └── Funcionario.cs        # Credenciais e cargos da equipe
│   └── Enums/
│       └── Enums.cs              # StatusAgendamento, CategoriaProduto, etc.
│
├── PetShop.Application/          # Camada de Aplicação (Contratos e Abstrações)
│   └── Interfaces/
│       ├── IRepositories.cs      # IClienteRepository, IPetRepository, etc.
│       └── IServices.cs          # IAuthenticationService, IRouteService, IFreteService, IPriceService
│
├── PetShop.Infrastructure/       # Camada de Infraestrutura e Persistência
│   ├── Data/
│   │   ├── InMemoryDatabase.cs   # Base de dados em memória inicializada com Mock
│   │   └── PetShopDbContext.cs   # Blueprint pronto para EF Core e SQL Server
│   ├── IoC/
│   │   └── ServiceContainer.cs   # Injeção de Dependências desacoplada
│   ├── Repositories/
│   │   └── MemoryRepositories.cs # Implementações In-Memory de todos os repositórios
│   └── Services/
│       └── Services.cs           # Implementações de autenticação, rota, frete e preço
│
└── PetShop.UI/                   # Camada de Interface de Usuário (Windows Forms)
    ├── Controls/
    │   ├── KpiCard.cs            # Cartões de indicadores KPI com badge e ícones
    │   ├── ModernButton.cs       # Botões modernos com estilos Primary, Accent, Ghost
    │   ├── ModernSearchBox.cs    # Campo de busca arredondado com ícone
    │   ├── PetCardControl.cs     # Cards visuais de pets com ações diretas
    │   ├── RoundedPanel.cs       # Painéis de cantos arredondados e bordas suaves
    │   ├── SimpleChartControl.cs # Gráfico semanal de vendas com renderização GDI+
    │   └── StatusBadgeControl.cs # Badges de status coloridas (Confirmado, Pendente, etc.)
    ├── Forms/
    │   ├── FrmLogin.cs           # Tela de Login moderna estilo split SaaS com pet hero
    │   ├── FrmMain.cs            # Janela principal com Sidebar retrátil e Header superior
    │   ├── FrmCliente.cs         # Modal de cadastro e edição de clientes
    │   ├── FrmPet.cs             # Modal de cadastro e edição de pets
    │   ├── FrmAgendamento.cs     # Modal de agendamento de serviços com cálculo de frete
    │   └── FrmProduto.cs         # Modal de cadastro e edição de produtos
    ├── Views/
    │   ├── UcDashboard.cs        # Dashboard com KPIs, agenda do dia, gráfico e alertas
    │   ├── UcClientes.cs         # Grid de clientes, busca em tempo real e ações
    │   ├── UcPets.cs             # Grid em cards com perfis dos pets e agendamento rápido
    │   ├── UcAgenda.cs           # Agenda com alternância Dia/Semana/Mês e ações de status
    │   ├── UcAtendimentos.cs     # Monitor de atendimentos ativos e histórico
    │   ├── UcServicos.cs         # Tabela de preços e catálogo de banho/tosa
    │   ├── UcProdutos.cs         # Catálogo de produtos com filtro de categoria
    │   ├── UcEstoque.cs          # Controle de estoque crítico e reposição
    │   ├── UcVendas.cs           # PDV Caixa com carrinho lateral e histórico de vendas
    │   ├── UcLogistica.cs        # Simulador de rotas e cálculo de frete Taxi Dog
    │   └── UcRelatorios.cs       # Relatórios consolidados por período
    ├── Helpers/
    │   └── UITheme.cs            # Paleta de cores, fontes e estilo global DataGridView
    └── Resources/
        └── pet_hero.jpg          # Imagem de demonstração da mascote na tela de Login
```

---

## 🔑 4. Credenciais de Teste

O sistema já vem configurado com credenciais para teste imediato:

| Campo | Valor |
| :--- | :--- |
| **Usuário** | `admin` |
| **Senha** | `admin123` |
| **Perfil** | Gerente Geral |

*(Outros usuários cadastrados no mock: `camila` / `admin123` [Veterinária] e `rafael` / `admin123` [Tosador]).*

---

## 🖥️ 5. Como Executar o Projeto

### Opção 1: Pelo Visual Studio
1. Abra o arquivo [PetShop.sln](file:///C:/Users/EBB2NL306.AzureAD/.gemini/antigravity-ide/scratch/PetShopManager/PetShop.sln) no Visual Studio 2022 (versão 17.8 ou superior com suporte ao .NET 8).
2. Defina o projeto `PetShop.UI` como **Projeto de Inicialização** (*Set as Startup Project*).
3. Pressione **F5** ou clique no botão **Iniciar**.

### Opção 2: Pela Linha de Comando (CLI .NET)
Abra o terminal na pasta `PetShopManager` e execute:
```powershell
dotnet run --project PetShop.UI/PetShop.UI.csproj
```

---

## 🎨 6. Paleta de Cores e Identidade Visual

O design segue a paleta do guia com identidade visual moderna de software SaaS:

| Cor | Código HEX | Utilização |
| :--- | :--- | :--- |
| **Verde Muito Escuro** | `#073B1A` | Sidebar de navegação, títulos e destaques |
| **Verde Principal** | `#156B3A` | Botões primários, itens ativos e status de sucesso |
| **Verde Claro** | `#EAF7EC` | Fundo de badges, seleção de linhas e cards de destaque |
| **Laranja de Acento** | `#FF7200` | Botões de conversão (PDV, Agendar) e alertas visuais |
| **Fundo Neutro** | `#F6F7F8` | Plano de fundo geral da aplicação |
| **Cards e Painéis** | `#FFFFFF` | Superfície de cartões, formulários e tabelas |
| **Texto Primário** | `#172019` | Tipografia de títulos e valores |
| **Texto Secundário** | `#6B746D` | Legendas, instruções e cabeçalhos secundários |

---

## 🗄️ 7. Arquitetura Preparada para Banco de Dados (Database Ready)

O sistema foi concebido para que **nenhuma interface visual (`Forms` ou `UserControls`)** acerte coleções de dados diretamente. Todo o acesso a dados é mediado por interfaces:

```csharp
public interface IClienteRepository
{
    IEnumerable<Cliente> GetAll();
    Cliente? GetById(int id);
    IEnumerable<Cliente> Search(string termo);
    void Add(Cliente cliente);
    void Update(Cliente cliente);
    void Delete(int id);
}
```

### Repositórios em Memória Atuais
Atualmente, as implementações ativas no projeto `PetShop.Infrastructure/Repositories/MemoryRepositories.cs` são:
- `ClienteMemoryRepository`
- `PetMemoryRepository`
- `ServicoMemoryRepository`
- `AgendamentoMemoryRepository`
- `AtendimentoMemoryRepository`
- `ProdutoMemoryRepository`
- `VendaMemoryRepository`
- `FuncionarioMemoryRepository`

### Como Conectar o SQL Server Realmente no Futuro

Quando for o momento de plugar o SQL Server e o Entity Framework Core:

1. **Adicionar os pacotes NuGet no projeto `PetShop.Infrastructure`:**
   ```powershell
   dotnet add PetShop.Infrastructure/PetShop.Infrastructure.csproj package Microsoft.EntityFrameworkCore.SqlServer
   dotnet add PetShop.Infrastructure/PetShop.Infrastructure.csproj package Microsoft.EntityFrameworkCore.Tools
   ```

2. **Ativar o `PetShopDbContext`:**
   No arquivo `PetShop.Infrastructure/Data/PetShopDbContext.cs`, já consta o modelo de mapeamento pronto herdando de `DbContext`, com `DbSet<Cliente>`, `DbSet<Pet>`, `DbSet<Produto>`, etc.

3. **Criar as classes de repositório SQL correspondentes:**
   Exemplo:
   ```csharp
   public class ClienteSqlRepository : IClienteRepository
   {
       private readonly PetShopDbContext _context;
       public ClienteSqlRepository(PetShopDbContext context) => _context = context;

       public IEnumerable<Cliente> GetAll() => _context.Clientes.Where(c => c.Ativo).ToList();
       public Cliente? GetById(int id) => _context.Clientes.Find(id);
       public void Add(Cliente cliente) { _context.Clientes.Add(cliente); _context.SaveChanges(); }
       public void Update(Cliente cliente) { _context.Clientes.Update(cliente); _context.SaveChanges(); }
       public void Delete(int id) { /* exclusão lógica */ }
   }
   ```

4. **Alterar uma única linha em `ServiceContainer.cs`:**
   ```csharp
   // Antes:
   public static IClienteRepository ClienteRepository { get; set; } = new ClienteMemoryRepository();

   // Depois:
   public static IClienteRepository ClienteRepository { get; set; } = new ClienteSqlRepository(new PetShopDbContext(options));
   ```

> 🎯 **Resultado:** Todas as telas (`UcClientes`, `UcPets`, `UcAgenda`, `UcVendas`, etc.) continuarão funcionando imediatamente sem precisar alterar uma única linha de código nos formulários!
