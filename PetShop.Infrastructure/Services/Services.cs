using PetShop.Application.Interfaces;
using PetShop.Domain.Entities;

namespace PetShop.Infrastructure.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IFuncionarioRepository _funcionarioRepository;

    public Funcionario? CurrentUser { get; private set; }

    public AuthenticationService(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
    }

    public Funcionario? Login(string usuarioOuEmail, string senha)
    {
        if (string.IsNullOrWhiteSpace(usuarioOuEmail) || string.IsNullOrWhiteSpace(senha))
            return null;

        var funcionario = _funcionarioRepository.GetByUsuario(usuarioOuEmail);
        if (funcionario == null || !funcionario.Ativo)
            return null;

        // NOTA DE ARQUITETURA: Na transição para banco de dados real,
        // substituir a comparação direta por verificação de Hash BCrypt:
        // if (!BCrypt.Net.BCrypt.Verify(senha, funcionario.Senha)) return null;
        if (funcionario.Senha != senha)
            return null;

        CurrentUser = funcionario;
        return funcionario;
    }

    public void Logout()
    {
        CurrentUser = null;
    }
}

public class RouteService : IRouteService
{
    public (decimal DistanciaKm, int TempoMinutos) CalcularRota(string origem, string destino)
    {
        if (string.IsNullOrWhiteSpace(origem) || string.IsNullOrWhiteSpace(destino))
            return (0, 0);

        // Algoritmo simulado para cálculo de rota em ambiente mock
        // Futuramente substitui-se por chamada à Google Maps API ou OpenStreetMap
        int seed = Math.Abs((origem + destino).GetHashCode());
        decimal distanciaKm = (seed % 180) / 10.0m + 2.5m; // Varia entre 2.5km e 20.5km
        distanciaKm = Math.Round(distanciaKm, 1);

        int tempoMinutos = (int)Math.Round(distanciaKm * 2.8m + 5);

        return (distanciaKm, tempoMinutos);
    }
}

public class FreteService : IFreteService
{
    public decimal CalcularFrete(decimal distanciaKm)
    {
        // Regras de negócio especificadas:
        // Até 5 km = R$ 8,00
        // 5 a 10 km = R$ 12,00
        // 10 a 20 km = R$ 20,00
        // Mais de 20 km = R$ 35,00 (consultar / taxa base)
        if (distanciaKm <= 0)
            return 0.00m;

        if (distanciaKm <= 5.0m)
            return 8.00m;

        if (distanciaKm <= 10.0m)
            return 12.00m;

        if (distanciaKm <= 20.0m)
            return 20.00m;

        return 35.00m;
    }
}

public class PriceService : IPriceService
{
    public decimal CalcularTotalAgendamento(decimal valorServico, decimal valorFrete)
    {
        return valorServico + valorFrete;
    }

    public decimal CalcularTotalVenda(decimal subtotalProdutos, decimal valorFrete)
    {
        return subtotalProdutos + valorFrete;
    }
}
