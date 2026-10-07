using PetShop.Domain.Enums;

namespace PetShop.Domain.Entities;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Complemento { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string CEP { get; set; } = string.Empty;
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    public bool Ativo { get; set; } = true;

    public List<Pet> Pets { get; set; } = new();

    public string EnderecoCompleto => $"{Endereco}, {Numero}{(string.IsNullOrWhiteSpace(Complemento) ? "" : " - " + Complemento)} - {Bairro}, {Cidade}";
}

public class Pet
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Especie { get; set; } = "Cachorro";
    public string Raca { get; set; } = string.Empty;
    public string Sexo { get; set; } = "Macho";
    public DateTime? DataNascimento { get; set; }
    public string Porte { get; set; } = "Médio";
    public decimal Peso { get; set; }
    public string Observacoes { get; set; } = string.Empty;
    public string? Foto { get; set; }
    public bool Ativo { get; set; } = true;

    public Cliente? Cliente { get; set; }
}

public class Servico
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int DuracaoMinutos { get; set; }
    public decimal Preco { get; set; }
    public bool Ativo { get; set; } = true;
}

public class Agendamento
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int PetId { get; set; }
    public int ServicoId { get; set; }
    public DateTime Data { get; set; }
    public string Horario { get; set; } = "09:00";
    public decimal ValorServico { get; set; }
    public decimal ValorFrete { get; set; }
    public decimal ValorTotal { get; set; }
    public StatusAgendamento Status { get; set; } = StatusAgendamento.Confirmado;
    public string Observacao { get; set; } = string.Empty;

    public Cliente? Cliente { get; set; }
    public Pet? Pet { get; set; }
    public Servico? Servico { get; set; }
}

public class Atendimento
{
    public int Id { get; set; }
    public int? AgendamentoId { get; set; }
    public int ClienteId { get; set; }
    public int PetId { get; set; }
    public int ServicoId { get; set; }
    public int FuncionarioId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public string Observacoes { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string Status { get; set; } = "Em Atendimento";

    public Cliente? Cliente { get; set; }
    public Pet? Pet { get; set; }
    public Servico? Servico { get; set; }
    public Funcionario? Funcionario { get; set; }
}

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Categoria { get; set; } = "Outros";
    public string Marca { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
    public int EstoqueMinimo { get; set; }
    public bool Ativo { get; set; } = true;

    public bool EstoqueBaixo => QuantidadeEstoque <= EstoqueMinimo;
    public bool SemEstoque => QuantidadeEstoque <= 0;
}

public class Venda
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;
    public decimal ValorProdutos { get; set; }
    public decimal ValorFrete { get; set; }
    public decimal ValorTotal { get; set; }
    public string Status { get; set; } = "Concluída";

    public Cliente? Cliente { get; set; }
    public List<ItemVenda> Itens { get; set; } = new();
}

public class ItemVenda
{
    public int Id { get; set; }
    public int VendaId { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal Subtotal => Quantidade * ValorUnitario;

    public Produto? Produto { get; set; }
}

public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public bool Ativo { get; set; } = true;
}
