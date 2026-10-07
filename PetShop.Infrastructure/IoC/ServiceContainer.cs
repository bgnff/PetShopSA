using PetShop.Application.Interfaces;
using PetShop.Infrastructure.Repositories;
using PetShop.Infrastructure.Services;

namespace PetShop.Infrastructure.IoC;

/// <summary>
/// Contêiner de Injeção de Dependências simples e desacoplado.
/// Permite trocar as implementações de Repositório (Memória -> SQL Server / EF Core) em um único ponto.
/// </summary>
public static class ServiceContainer
{
    public static IClienteRepository ClienteRepository { get; set; } = new ClienteMemoryRepository();
    public static IPetRepository PetRepository { get; set; } = new PetMemoryRepository();
    public static IServicoRepository ServicoRepository { get; set; } = new ServicoMemoryRepository();
    public static IAgendamentoRepository AgendamentoRepository { get; set; } = new AgendamentoMemoryRepository();
    public static IAtendimentoRepository AtendimentoRepository { get; set; } = new AtendimentoMemoryRepository();
    public static IProdutoRepository ProdutoRepository { get; set; } = new ProdutoMemoryRepository();
    public static IVendaRepository VendaRepository { get; set; } = new VendaMemoryRepository();
    public static IFuncionarioRepository FuncionarioRepository { get; set; } = new FuncionarioMemoryRepository();

    public static IAuthenticationService AuthenticationService { get; set; } = new AuthenticationService(FuncionarioRepository);
    public static IRouteService RouteService { get; set; } = new RouteService();
    public static IFreteService FreteService { get; set; } = new FreteService();
    public static IPriceService PriceService { get; set; } = new PriceService();
}
