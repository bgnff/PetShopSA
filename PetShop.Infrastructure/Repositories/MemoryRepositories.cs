using PetShop.Application.Interfaces;
using PetShop.Domain.Entities;
using PetShop.Domain.Enums;
using PetShop.Infrastructure.Data;

namespace PetShop.Infrastructure.Repositories;

public class ClienteMemoryRepository : IClienteRepository
{
    private readonly InMemoryDatabase _db = InMemoryDatabase.Instance;

    public IEnumerable<Cliente> GetAll() => _db.Clientes.OrderBy(c => c.Nome);

    public Cliente? GetById(int id) => _db.Clientes.FirstOrDefault(c => c.Id == id);

    public IEnumerable<Cliente> Search(string termo)
    {
        if (string.IsNullOrWhiteSpace(termo))
            return GetAll();

        termo = termo.Trim().ToLower();
        return _db.Clientes
            .Where(c => c.Nome.ToLower().Contains(termo) ||
                        c.CPF.ToLower().Contains(termo) ||
                        c.Telefone.ToLower().Contains(termo) ||
                        c.Email.ToLower().Contains(termo))
            .OrderBy(c => c.Nome);
    }

    public void Add(Cliente cliente)
    {
        cliente.Id = _db.Clientes.Any() ? _db.Clientes.Max(c => c.Id) + 1 : 1;
        cliente.DataCadastro = DateTime.Now;
        _db.Clientes.Add(cliente);
    }

    public void Update(Cliente cliente)
    {
        var existing = GetById(cliente.Id);
        if (existing != null)
        {
            existing.Nome = cliente.Nome;
            existing.CPF = cliente.CPF;
            existing.Telefone = cliente.Telefone;
            existing.Email = cliente.Email;
            existing.Endereco = cliente.Endereco;
            existing.Numero = cliente.Numero;
            existing.Complemento = cliente.Complemento;
            existing.Bairro = cliente.Bairro;
            existing.Cidade = cliente.Cidade;
            existing.CEP = cliente.CEP;
            existing.Ativo = cliente.Ativo;
        }
    }

    public void Delete(int id)
    {
        var existing = GetById(id);
        if (existing != null)
        {
            existing.Ativo = false;
        }
    }
}

public class PetMemoryRepository : IPetRepository
{
    private readonly InMemoryDatabase _db = InMemoryDatabase.Instance;

    public IEnumerable<Pet> GetAll() => _db.Pets.OrderBy(p => p.Nome);

    public Pet? GetById(int id) => _db.Pets.FirstOrDefault(p => p.Id == id);

    public IEnumerable<Pet> GetByClienteId(int clienteId) =>
        _db.Pets.Where(p => p.ClienteId == clienteId).OrderBy(p => p.Nome);

    public IEnumerable<Pet> Search(string termo)
    {
        if (string.IsNullOrWhiteSpace(termo))
            return GetAll();

        termo = termo.Trim().ToLower();
        return _db.Pets
            .Where(p => p.Nome.ToLower().Contains(termo) ||
                        p.Raca.ToLower().Contains(termo) ||
                        p.Especie.ToLower().Contains(termo) ||
                        (p.Cliente != null && p.Cliente.Nome.ToLower().Contains(termo)))
            .OrderBy(p => p.Nome);
    }

    public void Add(Pet pet)
    {
        pet.Id = _db.Pets.Any() ? _db.Pets.Max(p => p.Id) + 1 : 1;
        pet.Cliente = _db.Clientes.FirstOrDefault(c => c.Id == pet.ClienteId);
        if (pet.Cliente != null && !pet.Cliente.Pets.Contains(pet))
        {
            pet.Cliente.Pets.Add(pet);
        }
        _db.Pets.Add(pet);
    }

    public void Update(Pet pet)
    {
        var existing = GetById(pet.Id);
        if (existing != null)
        {
            existing.ClienteId = pet.ClienteId;
            existing.Nome = pet.Nome;
            existing.Especie = pet.Especie;
            existing.Raca = pet.Raca;
            existing.Sexo = pet.Sexo;
            existing.DataNascimento = pet.DataNascimento;
            existing.Porte = pet.Porte;
            existing.Peso = pet.Peso;
            existing.Observacoes = pet.Observacoes;
            existing.Foto = pet.Foto;
            existing.Ativo = pet.Ativo;
            existing.Cliente = _db.Clientes.FirstOrDefault(c => c.Id == pet.ClienteId);
        }
    }

    public void Delete(int id)
    {
        var existing = GetById(id);
        if (existing != null)
        {
            existing.Ativo = false;
        }
    }
}

public class ServicoMemoryRepository : IServicoRepository
{
    private readonly InMemoryDatabase _db = InMemoryDatabase.Instance;

    public IEnumerable<Servico> GetAll() => _db.Servicos.OrderBy(s => s.Nome);

    public Servico? GetById(int id) => _db.Servicos.FirstOrDefault(s => s.Id == id);

    public void Add(Servico servico)
    {
        servico.Id = _db.Servicos.Any() ? _db.Servicos.Max(s => s.Id) + 1 : 1;
        _db.Servicos.Add(servico);
    }

    public void Update(Servico servico)
    {
        var existing = GetById(servico.Id);
        if (existing != null)
        {
            existing.Nome = servico.Nome;
            existing.Descricao = servico.Descricao;
            existing.DuracaoMinutos = servico.DuracaoMinutos;
            existing.Preco = servico.Preco;
            existing.Ativo = servico.Ativo;
        }
    }

    public void Delete(int id)
    {
        var existing = GetById(id);
        if (existing != null)
        {
            existing.Ativo = false;
        }
    }
}

public class AgendamentoMemoryRepository : IAgendamentoRepository
{
    private readonly InMemoryDatabase _db = InMemoryDatabase.Instance;

    public IEnumerable<Agendamento> GetAll() =>
        _db.Agendamentos.OrderByDescending(a => a.Data).ThenBy(a => a.Horario);

    public Agendamento? GetById(int id) => _db.Agendamentos.FirstOrDefault(a => a.Id == id);

    public IEnumerable<Agendamento> GetByData(DateTime data) =>
        _db.Agendamentos.Where(a => a.Data.Date == data.Date).OrderBy(a => a.Horario);

    public IEnumerable<Agendamento> GetAgendamentosHoje() =>
        GetByData(DateTime.Today);

    public void Add(Agendamento agendamento)
    {
        agendamento.Id = _db.Agendamentos.Any() ? _db.Agendamentos.Max(a => a.Id) + 1 : 1;
        agendamento.Cliente = _db.Clientes.FirstOrDefault(c => c.Id == agendamento.ClienteId);
        agendamento.Pet = _db.Pets.FirstOrDefault(p => p.Id == agendamento.PetId);
        agendamento.Servico = _db.Servicos.FirstOrDefault(s => s.Id == agendamento.ServicoId);
        _db.Agendamentos.Add(agendamento);
    }

    public void Update(Agendamento agendamento)
    {
        var existing = GetById(agendamento.Id);
        if (existing != null)
        {
            existing.ClienteId = agendamento.ClienteId;
            existing.PetId = agendamento.PetId;
            existing.ServicoId = agendamento.ServicoId;
            existing.Data = agendamento.Data;
            existing.Horario = agendamento.Horario;
            existing.ValorServico = agendamento.ValorServico;
            existing.ValorFrete = agendamento.ValorFrete;
            existing.ValorTotal = agendamento.ValorTotal;
            existing.Status = agendamento.Status;
            existing.Observacao = agendamento.Observacao;
            existing.Cliente = _db.Clientes.FirstOrDefault(c => c.Id == agendamento.ClienteId);
            existing.Pet = _db.Pets.FirstOrDefault(p => p.Id == agendamento.PetId);
            existing.Servico = _db.Servicos.FirstOrDefault(s => s.Id == agendamento.ServicoId);
        }
    }

    public void Delete(int id)
    {
        var existing = GetById(id);
        if (existing != null)
        {
            _db.Agendamentos.Remove(existing);
        }
    }
}

public class AtendimentoMemoryRepository : IAtendimentoRepository
{
    private readonly InMemoryDatabase _db = InMemoryDatabase.Instance;

    public IEnumerable<Atendimento> GetAll() =>
        _db.Atendimentos.OrderByDescending(a => a.DataInicio);

    public Atendimento? GetById(int id) => _db.Atendimentos.FirstOrDefault(a => a.Id == id);

    public IEnumerable<Atendimento> GetAtendimentosHoje() =>
        _db.Atendimentos.Where(a => a.DataInicio.Date == DateTime.Today).OrderByDescending(a => a.DataInicio);

    public void Add(Atendimento atendimento)
    {
        atendimento.Id = _db.Atendimentos.Any() ? _db.Atendimentos.Max(a => a.Id) + 1 : 1;
        atendimento.Cliente = _db.Clientes.FirstOrDefault(c => c.Id == atendimento.ClienteId);
        atendimento.Pet = _db.Pets.FirstOrDefault(p => p.Id == atendimento.PetId);
        atendimento.Servico = _db.Servicos.FirstOrDefault(s => s.Id == atendimento.ServicoId);
        atendimento.Funcionario = _db.Funcionarios.FirstOrDefault(f => f.Id == atendimento.FuncionarioId);
        _db.Atendimentos.Add(atendimento);
    }

    public void Update(Atendimento atendimento)
    {
        var existing = GetById(atendimento.Id);
        if (existing != null)
        {
            existing.DataFim = atendimento.DataFim;
            existing.Observacoes = atendimento.Observacoes;
            existing.Valor = atendimento.Valor;
            existing.Status = atendimento.Status;
        }
    }

    public void Delete(int id)
    {
        var existing = GetById(id);
        if (existing != null)
        {
            _db.Atendimentos.Remove(existing);
        }
    }
}

public class ProdutoMemoryRepository : IProdutoRepository
{
    private readonly InMemoryDatabase _db = InMemoryDatabase.Instance;

    public IEnumerable<Produto> GetAll() => _db.Produtos.OrderBy(p => p.Nome);

    public Produto? GetById(int id) => _db.Produtos.FirstOrDefault(p => p.Id == id);

    public IEnumerable<Produto> GetEstoqueBaixo() =>
        _db.Produtos.Where(p => p.EstoqueBaixo).OrderBy(p => p.QuantidadeEstoque);

    public IEnumerable<Produto> Search(string termo, string? categoria = null)
    {
        var query = _db.Produtos.AsQueryable();

        if (!string.IsNullOrWhiteSpace(categoria) && categoria != "Todas" && categoria != "Todos")
        {
            query = query.Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(termo))
        {
            termo = termo.Trim().ToLower();
            query = query.Where(p => p.Nome.ToLower().Contains(termo) ||
                                     p.SKU.ToLower().Contains(termo) ||
                                     p.Marca.ToLower().Contains(termo));
        }

        return query.OrderBy(p => p.Nome);
    }

    public void Add(Produto produto)
    {
        produto.Id = _db.Produtos.Any() ? _db.Produtos.Max(p => p.Id) + 1 : 1;
        _db.Produtos.Add(produto);
    }

    public void Update(Produto produto)
    {
        var existing = GetById(produto.Id);
        if (existing != null)
        {
            existing.Nome = produto.Nome;
            existing.Descricao = produto.Descricao;
            existing.Categoria = produto.Categoria;
            existing.Marca = produto.Marca;
            existing.SKU = produto.SKU;
            existing.Preco = produto.Preco;
            existing.QuantidadeEstoque = produto.QuantidadeEstoque;
            existing.EstoqueMinimo = produto.EstoqueMinimo;
            existing.Ativo = produto.Ativo;
        }
    }

    public void Delete(int id)
    {
        var existing = GetById(id);
        if (existing != null)
        {
            existing.Ativo = false;
        }
    }

    public void AtualizarEstoque(int produtoId, int quantidadeDelta)
    {
        var existing = GetById(produtoId);
        if (existing != null)
        {
            existing.QuantidadeEstoque -= quantidadeDelta;
            if (existing.QuantidadeEstoque < 0) existing.QuantidadeEstoque = 0;
        }
    }
}

public class VendaMemoryRepository : IVendaRepository
{
    private readonly InMemoryDatabase _db = InMemoryDatabase.Instance;

    public IEnumerable<Venda> GetAll() => _db.Vendas.OrderByDescending(v => v.Data);

    public Venda? GetById(int id) => _db.Vendas.FirstOrDefault(v => v.Id == id);

    public IEnumerable<Venda> GetUltimasVendas(int quantidade = 5) =>
        _db.Vendas.OrderByDescending(v => v.Data).Take(quantidade);

    public decimal GetFaturamentoHoje() =>
        _db.Vendas.Where(v => v.Data.Date == DateTime.Today).Sum(v => v.ValorTotal);

    public decimal GetFaturamentoMes() =>
        _db.Vendas.Where(v => v.Data.Month == DateTime.Today.Month && v.Data.Year == DateTime.Today.Year).Sum(v => v.ValorTotal);

    public void Add(Venda venda)
    {
        venda.Id = _db.Vendas.Any() ? _db.Vendas.Max(v => v.Id) + 1 : 101;
        venda.Data = DateTime.Now;
        venda.Cliente = _db.Clientes.FirstOrDefault(c => c.Id == venda.ClienteId);
        _db.Vendas.Add(venda);
    }
}

public class FuncionarioMemoryRepository : IFuncionarioRepository
{
    private readonly InMemoryDatabase _db = InMemoryDatabase.Instance;

    public IEnumerable<Funcionario> GetAll() => _db.Funcionarios.OrderBy(f => f.Nome);

    public Funcionario? GetById(int id) => _db.Funcionarios.FirstOrDefault(f => f.Id == id);

    public Funcionario? GetByUsuario(string usuarioOuEmail)
    {
        if (string.IsNullOrWhiteSpace(usuarioOuEmail)) return null;
        usuarioOuEmail = usuarioOuEmail.Trim().ToLower();
        return _db.Funcionarios.FirstOrDefault(f =>
            f.Usuario.ToLower() == usuarioOuEmail ||
            f.Email.ToLower() == usuarioOuEmail);
    }

    public void Add(Funcionario funcionario)
    {
        funcionario.Id = _db.Funcionarios.Any() ? _db.Funcionarios.Max(f => f.Id) + 1 : 1;
        _db.Funcionarios.Add(funcionario);
    }

    public void Update(Funcionario funcionario)
    {
        var existing = GetById(funcionario.Id);
        if (existing != null)
        {
            existing.Nome = funcionario.Nome;
            existing.Email = funcionario.Email;
            existing.Usuario = funcionario.Usuario;
            existing.Cargo = funcionario.Cargo;
            existing.Ativo = funcionario.Ativo;
            if (!string.IsNullOrWhiteSpace(funcionario.Senha))
                existing.Senha = funcionario.Senha;
        }
    }

    public void Delete(int id)
    {
        var existing = GetById(id);
        if (existing != null)
        {
            existing.Ativo = false;
        }
    }
}
