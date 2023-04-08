using EntityFramework.Database;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers;

public class FuncionariosController : Controller
{
    private readonly ApplicationDBContext database;
    
    // Fazendo uma injeção de dependência, que é quando inserimos algo dentro de uma classe através do CONSTRUTOR dela.
    // Aqui no caso estamos passando o nosso PRODIVER FACTORY para que possamos abrir a conexão com o banco aqui e utilizar o banco.
    // e Esse database é passado AUTOMATICAMENTE quando dizemos que queremos receber o PROVIDER FACTORY, basicamente o database aqui é a CHAVE de conexão com o BANCO e também teremos ACESSO as ENTIDADES MAPEADAS para a MIGRAÇÃO que ficam dentro da CHAVE/FACTORY
    public FuncionariosController(ApplicationDBContext database)
    {
        this.database = database;
    }

    // Vai para a página Inicial do CONTROLLER, Lista todos os funcionários que existem dentro do banco de dados.
    public IActionResult Index()
    {
        // Recebendo todos os Funcionários da Tabela Funcionários
        // Estamos usando LINQ
        var funcionarios = database.Funcionarios.ToList();
        
        // A melhor forma de passar DADOS TIPADOS de MODELS/ENTIDADES para VIEWS é através do próprio parâmetro da VIEW
        return View(funcionarios);
    }

    // Toda ACTION por padrão pode receber um ID, caso queira verificar vá no arquivo/Classe Program e olhe o mapeamento de rotas.
    public IActionResult Editar(int id)
    {
        // Percorrendo a TABELA e buscando um funcionário através do ID
        Funcionario funcionario = database.Funcionarios.First(f => f.Id == id );

        // Passando um Funcionaro para a View cadastrar, por USARMOS o atributo "ASP-FOR", ele irá associar os as propriedades que estão recebendo valor a instância da entidade passada.
        return View("Cadastrar",funcionario);
    }
    
    // Redirecionando para a View Cadastrar que possui o formulário
    public IActionResult Cadastrar()
    {
        return View("Cadastrar");
    }

    // eu também posso dizer/tipar o TIPO de requisição que essa action/método atenderá se for chamada, nesse caso ele só atenderá se for chamada e o METHOD fizer um POST
    [HttpPost]
    // Temos acesso aos DADOS passados pelo FORMULÁRIO, pois lá FIZEMOS um LINK para a MODEL/ENTIDADE de Funcionário, então via parâmetro podemos ter acesso a esse Funcionário.
    //RESUMO: o ASP.NET é inteligente, então ele criará uma instância da MODEL/ENTIDADE que foi LINKADA, passará os valores dos CAMPOS/INPUTS para essa instância e ENVIARÁ para o MÉTODO/ACTION SALVAR()
    public IActionResult Salvar(Funcionario funcionario) // Cadastrar OU Atualiza um Usuário com base no ID
    {
        // Se o Id do usuário que nos é ENVIADO pelo formulário for IGUAL a "0", significa que o usuário não existe não banco, então irei adicioná-lo lá, caso contrário eu irei atualizar um usuário já existente.
        // Criando/Adicionando um novo usuário ao BANCO caso ele não exista.
        if (funcionario.Id == 0)
        {
            // Adicionando o funcionario para dentro da TABELA do BANCO
            database.Funcionarios.Add(funcionario);
        }
        // Editando um usuário caso ele exista.
        else
        {
            // Pegando o funcionário do BANCO que terá o mesmo ID do funcionário passado pelo usuário.
            Funcionario funcionaroDoBanco = database.Funcionarios.First(registro => registro.Id == funcionario.Id);
            
            // Se eu ALTERAR o OBJETO/CAMPO/REGISTRO/FUNCIONÁRIO que eu busquei do BANCO, já é o SUFICIENTE para ele ENTENDER que você quer modificar, então após o SAVECHANGES() ele irá na REFERÊNCIA que foi TRAZIDA do BANCO e irá APLICAR o UPDATE.
            funcionaroDoBanco.Nome = funcionario.Nome;
            funcionaroDoBanco.Salario = funcionario.Salario;
            funcionaroDoBanco.Cpf = funcionario.Cpf;
        }
        
        // Confirmando as alterações para que elas realmente sejam aplicadas.
        database.SaveChanges();
        
        // Redirecionando o Usuário para a ACTION INDEX() que retorna a VIEW INDEX dos Funcionários
        return RedirectToAction("Index");
    }

    // Excluindo um Registro/Usuário do Banco de dados
    // OBS: TODA ROTA TEM DIREITO EM RECEBER UM "ID", no no casso estamos recebendo o Id do Funcionário que é passado no retorno JUNTO da VIEW no método
    public IActionResult Excluir(int id)
    {
        // Pegando o usuário que irá ser removido/deletado
        Funcionario funcionarioReturned = database.Funcionarios.First(f => f.Id == id);
        
        // Removendo o Usuário escolhido
        database.Funcionarios.Remove(funcionarioReturned);
        
        // Confirmando a remoção
        database.SaveChanges();
        
        // Redirecionando para a ACTION INDEX
        // OBS: Você pode se perguntar o porque de não passarmos direto a VIEW INDEX, isso é porquemos lá na VIEW temos um FOREACH que espera percorrer a MODEL, porém a ACTION INDEX já define um valor para a propriedade MODEL da VIEW, então se simplesmente chamassemos apenas a VIEW direta, teríamos um ERRO, ai você se pergunta então porque não chamar a VIEW e passar um valor para a propriedade MODEL por aqui(pela ACTION EXCLUIR), e a resposta é simples: poderíamos poluir o código e dar "DUAS" FUNÇÕES para a ACTION EXCLUIR, onde ela só deve ter uma ÚNICA FUNÇÃO -> SOLID.
        return RedirectToAction("Index");
    }
    
}