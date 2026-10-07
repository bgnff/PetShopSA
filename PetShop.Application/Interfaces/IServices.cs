using PetShop.Domain.Entities;

namespace PetShop.Application.Interfaces;

public interface IAuthenticationService
{
    Funcionario? Login(string usuarioOuEmail, string senha);
    Funcionario? CurrentUser { get; }
    void Logout();
}

public interface IRouteService
{
    (decimal DistanciaKm, int TempoMinutos) CalcularRota(string origem, string destino);
}

public interface IFreteService
{
    decimal CalcularFrete(decimal distanciaKm);
}

public interface IPriceService
{
    decimal CalcularTotalAgendamento(decimal valorServico, decimal valorFrete);
    decimal CalcularTotalVenda(decimal subtotalProdutos, decimal valorFrete);
}
