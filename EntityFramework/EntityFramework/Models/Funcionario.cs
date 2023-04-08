namespace EntityFramework.Models;

public class Funcionario
{
    // as propriedades precisam ter um nome que comece com a letra MAIÚSCULA, precisam ser PÚBLICAS e ter ACCESSORS(get) E MUTATORS(set)
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Salario { get; set; }
    public string Cpf { get; set; }
}