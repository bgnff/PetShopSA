using PetShop.Domain.Entities;
using PetShop.Domain.Enums;

namespace PetShop.Infrastructure.Data;

public class InMemoryDatabase
{
    private static readonly Lazy<InMemoryDatabase> _instance = new(() => new InMemoryDatabase());
    public static InMemoryDatabase Instance => _instance.Value;

    public List<Cliente> Clientes { get; } = new();
    public List<Pet> Pets { get; } = new();
    public List<Servico> Servicos { get; } = new();
    public List<Agendamento> Agendamentos { get; } = new();
    public List<Atendimento> Atendimentos { get; } = new();
    public List<Produto> Produtos { get; } = new();
    public List<Venda> Vendas { get; } = new();
    public List<Funcionario> Funcionarios { get; } = new();

    private InMemoryDatabase()
    {
        Seed();
    }

    private void Seed()
    {
        // 1. Funcionários
        Funcionarios.Add(new Funcionario
        {
            Id = 1,
            Nome = "Carlos Eduardo",
            Email = "admin@petshop.com",
            Usuario = "admin",
            Senha = "admin123", // Em produção/banco será hash BCrypt
            Cargo = "Gerente Geral",
            Ativo = true
        });

        Funcionarios.Add(new Funcionario
        {
            Id = 2,
            Nome = "Dra. Camila Santos",
            Email = "camila@petshop.com",
            Usuario = "camila",
            Senha = "admin123",
            Cargo = "Médica Veterinária",
            Ativo = true
        });

        Funcionarios.Add(new Funcionario
        {
            Id = 3,
            Nome = "Rafael Lima",
            Email = "rafael@petshop.com",
            Usuario = "rafael",
            Senha = "admin123",
            Cargo = "Tosador Especialista",
            Ativo = true
        });

        // 2. Clientes
        var c1 = new Cliente
        {
            Id = 1,
            Nome = "Carlos Silva",
            CPF = "123.456.789-00",
            Telefone = "(11) 98765-4321",
            Email = "carlos.silva@email.com",
            Endereco = "Av. Paulista",
            Numero = "1500",
            Complemento = "Apto 82",
            Bairro = "Bela Vista",
            Cidade = "São Paulo",
            CEP = "01310-200",
            DataCadastro = DateTime.Now.AddDays(-60),
            Ativo = true
        };

        var c2 = new Cliente
        {
            Id = 2,
            Nome = "Ana Souza",
            CPF = "234.567.890-11",
            Telefone = "(11) 97654-3210",
            Email = "ana.souza@email.com",
            Endereco = "Rua Augusta",
            Numero = "450",
            Complemento = "",
            Bairro = "Consolação",
            Cidade = "São Paulo",
            CEP = "01305-000",
            DataCadastro = DateTime.Now.AddDays(-45),
            Ativo = true
        };

        var c3 = new Cliente
        {
            Id = 3,
            Nome = "Marcos Oliveira",
            CPF = "345.678.901-22",
            Telefone = "(11) 96543-2109",
            Email = "marcos.oliveira@email.com",
            Endereco = "Rua dos Pinheiros",
            Numero = "780",
            Complemento = "Bloco B",
            Bairro = "Pinheiros",
            Cidade = "São Paulo",
            CEP = "05422-001",
            DataCadastro = DateTime.Now.AddDays(-20),
            Ativo = true
        };

        var c4 = new Cliente
        {
            Id = 4,
            Nome = "Juliana Mendes",
            CPF = "456.789.012-33",
            Telefone = "(11) 95432-1098",
            Email = "juliana.mendes@email.com",
            Endereco = "Rua Oscar Freire",
            Numero = "1200",
            Complemento = "",
            Bairro = "Cerqueira César",
            Cidade = "São Paulo",
            CEP = "01426-001",
            DataCadastro = DateTime.Now.AddDays(-10),
            Ativo = true
        };

        Clientes.AddRange(new[] { c1, c2, c3, c4 });

        // 3. Pets
        var p1 = new Pet
        {
            Id = 1,
            ClienteId = 1,
            Nome = "Thor",
            Especie = "Cachorro",
            Raca = "Golden Retriever",
            Sexo = "Macho",
            DataNascimento = DateTime.Now.AddYears(-3),
            Porte = "Grande",
            Peso = 32.5m,
            Observacoes = "Muito dócil, adora água.",
            Ativo = true,
            Cliente = c1
        };

        var p2 = new Pet
        {
            Id = 2,
            ClienteId = 2,
            Nome = "Mel",
            Especie = "Cachorro",
            Raca = "Shih-tzu",
            Sexo = "Fêmea",
            DataNascimento = DateTime.Now.AddYears(-2),
            Porte = "Pequeno",
            Peso = 5.8m,
            Observacoes = "Sensível na limpeza de ouvido.",
            Ativo = true,
            Cliente = c2
        };

        var p3 = new Pet
        {
            Id = 3,
            ClienteId = 3,
            Nome = "Luna",
            Especie = "Gato",
            Raca = "Siamês SRD",
            Sexo = "Fêmea",
            DataNascimento = DateTime.Now.AddYears(-1),
            Porte = "Pequeno",
            Peso = 4.2m,
            Observacoes = "Fica estressada com barulho alto do soprador.",
            Ativo = true,
            Cliente = c3
        };

        var p4 = new Pet
        {
            Id = 4,
            ClienteId = 1,
            Nome = "Bob",
            Especie = "Cachorro",
            Raca = "Bulldog Francês",
            Sexo = "Macho",
            DataNascimento = DateTime.Now.AddYears(-4),
            Porte = "Médio",
            Peso = 13.0m,
            Observacoes = "Cuidado com calor excessivo (braquicefálico).",
            Ativo = true,
            Cliente = c1
        };

        c1.Pets.AddRange(new[] { p1, p4 });
        c2.Pets.Add(p2);
        c3.Pets.Add(p3);

        Pets.AddRange(new[] { p1, p2, p3, p4 });

        // 4. Serviços
        var s1 = new Servico { Id = 1, Nome = "Banho", Descricao = "Banho com shampoo hipoalergênico e secagem", DuracaoMinutos = 40, Preco = 50.00m, Ativo = true };
        var s2 = new Servico { Id = 2, Nome = "Tosa", Descricao = "Tosa higiênica e corte na máquina", DuracaoMinutos = 50, Preco = 60.00m, Ativo = true };
        var s3 = new Servico { Id = 3, Nome = "Banho + Tosa", Descricao = "Pacote completo com hidratação e tosa da raça", DuracaoMinutos = 80, Preco = 95.00m, Ativo = true };
        var s4 = new Servico { Id = 4, Nome = "Corte de Unhas", Descricao = "Corte seguro com lixamento", DuracaoMinutos = 15, Preco = 25.00m, Ativo = true };
        var s5 = new Servico { Id = 5, Nome = "Hidratação", Descricao = "Tratamento de brilho e maciez dos pelos", DuracaoMinutos = 30, Preco = 40.00m, Ativo = true };
        var s6 = new Servico { Id = 6, Nome = "Limpeza de Ouvido", Descricao = "Higiene otológica preventiva", DuracaoMinutos = 15, Preco = 20.00m, Ativo = true };

        Servicos.AddRange(new[] { s1, s2, s3, s4, s5, s6 });

        // 5. Produtos
        Produtos.AddRange(new[]
        {
            new Produto { Id = 1, Nome = "Ração Golden Special 15kg", Descricao = "Ração premium para cães adultos", Categoria = "Ração", Marca = "Golden", SKU = "RAC-GLD-15K", Preco = 159.90m, QuantidadeEstoque = 3, EstoqueMinimo = 5, Ativo = true },
            new Produto { Id = 2, Nome = "Petisco Natural Dog Treats 100g", Descricao = "Bifinho 100% carne bovina", Categoria = "Petisco", Marca = "Natural Treats", SKU = "PET-NAT-100", Preco = 24.90m, QuantidadeEstoque = 18, EstoqueMinimo = 5, Ativo = true },
            new Produto { Id = 3, Nome = "Shampoo Pet Ervas Suaves 500ml", Descricao = "Shampoo neutro para cães e gatos", Categoria = "Higiene", Marca = "PetClean", SKU = "HIG-SHA-500", Preco = 29.90m, QuantidadeEstoque = 7, EstoqueMinimo = 5, Ativo = true },
            new Produto { Id = 4, Nome = "Brinquedo Mordedor Pelúcia Pato", Descricao = "Mordedor resistente com apito", Categoria = "Brinquedo", Marca = "Kong Play", SKU = "BRQ-MOR-PAT", Preco = 18.50m, QuantidadeEstoque = 14, EstoqueMinimo = 5, Ativo = true },
            new Produto { Id = 5, Nome = "Antipulgas NexGard 10-25kg", Descricao = "Tablete mastigável contra pulgas e carrapatos", Categoria = "Medicamento", Marca = "Boehringer", SKU = "MED-NEX-25K", Preco = 89.90m, QuantidadeEstoque = 2, EstoqueMinimo = 4, Ativo = true },
            new Produto { Id = 6, Nome = "Coleira Guia Conforto Premium", Descricao = "Guia resistente com amortecedor", Categoria = "Acessório", Marca = "ZeePet", SKU = "ACS-GUI-CNF", Preco = 45.00m, QuantidadeEstoque = 6, EstoqueMinimo = 3, Ativo = true },
            new Produto { Id = 7, Nome = "Ração Royal Canin Persian 7.5kg", Descricao = "Nutrição específica para gatos persas", Categoria = "Ração", Marca = "Royal Canin", SKU = "RAC-ROY-PER", Preco = 229.00m, QuantidadeEstoque = 1, EstoqueMinimo = 4, Ativo = true }
        });

        // 6. Agendamentos (Hoje)
        var hoje = DateTime.Today;
        Agendamentos.AddRange(new[]
        {
            new Agendamento { Id = 1, ClienteId = 1, PetId = 1, ServicoId = 1, Data = hoje, Horario = "08:00", ValorServico = 50.00m, ValorFrete = 8.00m, ValorTotal = 58.00m, Status = StatusAgendamento.Confirmado, Observacao = "Taxi Dog ida e volta", Cliente = c1, Pet = p1, Servico = s1 },
            new Agendamento { Id = 2, ClienteId = 2, PetId = 2, ServicoId = 3, Data = hoje, Horario = "09:00", ValorServico = 95.00m, ValorFrete = 0.00m, ValorTotal = 95.00m, Status = StatusAgendamento.Confirmado, Observacao = "Cliente trará pessoalmente", Cliente = c2, Pet = p2, Servico = s3 },
            new Agendamento { Id = 3, ClienteId = 3, PetId = 3, ServicoId = 2, Data = hoje, Horario = "10:30", ValorServico = 60.00m, ValorFrete = 12.00m, ValorTotal = 72.00m, Status = StatusAgendamento.EmAtendimento, Observacao = "Tosa na tesoura com cuidado", Cliente = c3, Pet = p3, Servico = s2 },
            new Agendamento { Id = 4, ClienteId = 1, PetId = 4, ServicoId = 3, Data = hoje, Horario = "14:00", ValorServico = 95.00m, ValorFrete = 8.00m, ValorTotal = 103.00m, Status = StatusAgendamento.Pendente, Observacao = "Aguardando confirmação de horário", Cliente = c1, Pet = p4, Servico = s3 },
            new Agendamento { Id = 5, ClienteId = 4, PetId = 2, ServicoId = 5, Data = hoje, Horario = "16:00", ValorServico = 40.00m, ValorFrete = 0.00m, ValorTotal = 40.00m, Status = StatusAgendamento.Confirmado, Observacao = "Hidratação de argan", Cliente = c4, Pet = p2, Servico = s5 }
        });

        // 7. Atendimentos
        Atendimentos.AddRange(new[]
        {
            new Atendimento
            {
                Id = 1,
                AgendamentoId = 3,
                ClienteId = 3,
                PetId = 3,
                ServicoId = 2,
                FuncionarioId = 3,
                DataInicio = DateTime.Now.AddMinutes(-30),
                Observacoes = "Iniciada tosa cuidadosa com Rafael.",
                Valor = 72.00m,
                Status = "Em Atendimento",
                Cliente = c3,
                Pet = p3,
                Servico = s2,
                Funcionario = Funcionarios[2]
            },
            new Atendimento
            {
                Id = 2,
                AgendamentoId = 1,
                ClienteId = 1,
                PetId = 1,
                ServicoId = 1,
                FuncionarioId = 3,
                DataInicio = DateTime.Today.AddHours(8),
                DataFim = DateTime.Today.AddHours(8).AddMinutes(45),
                Observacoes = "Banho realizado com sucesso. Thor se comportou muito bem.",
                Valor = 58.00m,
                Status = "Finalizado",
                Cliente = c1,
                Pet = p1,
                Servico = s1,
                Funcionario = Funcionarios[2]
            }
        });

        // 8. Vendas recentes
        var v1 = new Venda
        {
            Id = 101,
            ClienteId = 1,
            Data = DateTime.Now.AddHours(-1),
            ValorProdutos = 184.80m,
            ValorFrete = 8.00m,
            ValorTotal = 192.80m,
            Status = "Concluída",
            Cliente = c1
        };
        v1.Itens.Add(new ItemVenda { Id = 1, VendaId = 101, ProdutoId = 1, Quantidade = 1, ValorUnitario = 159.90m, Produto = Produtos[0] });
        v1.Itens.Add(new ItemVenda { Id = 2, VendaId = 101, ProdutoId = 2, Quantidade = 1, ValorUnitario = 24.90m, Produto = Produtos[1] });

        var v2 = new Venda
        {
            Id = 102,
            ClienteId = 2,
            Data = DateTime.Now.AddHours(-3),
            ValorProdutos = 74.90m,
            ValorFrete = 0.00m,
            ValorTotal = 74.90m,
            Status = "Concluída",
            Cliente = c2
        };
        v2.Itens.Add(new ItemVenda { Id = 3, VendaId = 102, ProdutoId = 3, Quantidade = 1, ValorUnitario = 29.90m, Produto = Produtos[2] });
        v2.Itens.Add(new ItemVenda { Id = 4, VendaId = 102, ProdutoId = 6, Quantidade = 1, ValorUnitario = 45.00m, Produto = Produtos[5] });

        var v3 = new Venda
        {
            Id = 103,
            ClienteId = 3,
            Data = DateTime.Now.AddHours(-5),
            ValorProdutos = 89.90m,
            ValorFrete = 12.00m,
            ValorTotal = 101.90m,
            Status = "Concluída",
            Cliente = c3
        };
        v3.Itens.Add(new ItemVenda { Id = 5, VendaId = 103, ProdutoId = 5, Quantidade = 1, ValorUnitario = 89.90m, Produto = Produtos[4] });

        Vendas.AddRange(new[] { v1, v2, v3 });
    }
}
