using PetShop.Domain.Entities;

namespace PetShop.Application.Interfaces;

public interface IClienteRepository
{
    IEnumerable<Cliente> GetAll();
    Cliente? GetById(int id);
    IEnumerable<Cliente> Search(string termo);
    void Add(Cliente cliente);
    void Update(Cliente cliente);
    void Delete(int id);
}

public interface IPetRepository
{
    IEnumerable<Pet> GetAll();
    Pet? GetById(int id);
    IEnumerable<Pet> GetByClienteId(int clienteId);
    IEnumerable<Pet> Search(string termo);
    void Add(Pet pet);
    void Update(Pet pet);
    void Delete(int id);
}

public interface IServicoRepository
{
    IEnumerable<Servico> GetAll();
    Servico? GetById(int id);
    void Add(Servico servico);
    void Update(Servico servico);
    void Delete(int id);
}

public interface IAgendamentoRepository
{
    IEnumerable<Agendamento> GetAll();
    Agendamento? GetById(int id);
    IEnumerable<Agendamento> GetByData(DateTime data);
    IEnumerable<Agendamento> GetAgendamentosHoje();
    void Add(Agendamento agendamento);
    void Update(Agendamento agendamento);
    void Delete(int id);
}

public interface IAtendimentoRepository
{
    IEnumerable<Atendimento> GetAll();
    Atendimento? GetById(int id);
    IEnumerable<Atendimento> GetAtendimentosHoje();
    void Add(Atendimento atendimento);
    void Update(Atendimento atendimento);
    void Delete(int id);
}

public interface IProdutoRepository
{
    IEnumerable<Produto> GetAll();
    Produto? GetById(int id);
    IEnumerable<Produto> GetEstoqueBaixo();
    IEnumerable<Produto> Search(string termo, string? categoria = null);
    void Add(Produto produto);
    void Update(Produto produto);
    void Delete(int id);
    void AtualizarEstoque(int produtoId, int quantidadeVendida);
}

public interface IVendaRepository
{
    IEnumerable<Venda> GetAll();
    Venda? GetById(int id);
    IEnumerable<Venda> GetUltimasVendas(int quantidade = 5);
    decimal GetFaturamentoHoje();
    decimal GetFaturamentoMes();
    void Add(Venda venda);
}

public interface IFuncionarioRepository
{
    IEnumerable<Funcionario> GetAll();
    Funcionario? GetById(int id);
    Funcionario? GetByUsuario(string usuarioOuEmail);
    void Add(Funcionario funcionario);
    void Update(Funcionario funcionario);
    void Delete(int id);
}
