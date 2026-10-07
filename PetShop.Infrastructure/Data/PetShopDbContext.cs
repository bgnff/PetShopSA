using PetShop.Domain.Entities;

namespace PetShop.Infrastructure.Data;

/*
====================================================================================
GUIA DE MIGRAÇÃO FUTURA PARA BANCO DE DADOS (SQL SERVER + ENTITY FRAMEWORK CORE)
====================================================================================
Quando desejar conectar o sistema ao SQL Server real, basta:

1. No projeto PetShop.Infrastructure, adicionar os pacotes NuGet:
   - Microsoft.EntityFrameworkCore.SqlServer
   - Microsoft.EntityFrameworkCore.Tools

2. Descomentar a classe PetShopDbContext abaixo (ou herdar de DbContext):

public class PetShopDbContext : DbContext
{
    public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Pet> Pets => Set<Pet>();
    public DbSet<Servico> Servicos => Set<Servico>();
    public DbSet<Agendamento> Agendamentos => Set<Agendamento>();
    public DbSet<Atendimento> Atendimentos => Set<Atendimento>();
    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<Venda> Vendas => Set<Venda>();
    public DbSet<ItemVenda> ItensVenda => Set<ItemVenda>();
    public DbSet<Funcionario> Funcionarios => Set<Funcionario>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Mapeamentos fluentes, índices e chaves estrangeiras
    }
}

3. Criar os Repositórios SQL que implementam as mesmas interfaces (ex: ClienteSqlRepository : IClienteRepository).
4. No arquivo ServiceContainer.cs, substituir o registro de ClienteMemoryRepository por ClienteSqlRepository.
A interface visual (Forms e UserControls) NÃO sofrerá nenhuma alteração!
====================================================================================
*/

public static class DatabaseConfig
{
    // String de conexão preparada para quando o banco de dados for ativado
    public const string DefaultConnectionString = "Server=(localdb)\\mssqllocaldb;Database=PetShopManagerDb;Trusted_Connection=True;MultipleActiveResultSets=true";
}
