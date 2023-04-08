using System.Configuration;
using  EntityFramework.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container/ Adicionando o padrão de arquitetura MVC ao Projeto.
builder.Services.AddControllersWithViews();


// OBS: Você pode digitar a String Connection direto (Hard Code), ou seguir as boas práticas e coloca-la dentro de um arquivo, geralmente o arquivo é o appSettings.json
// Definindo a configuração do banco no arquivo principal, também é aqui que dizemos a nossa FACTORY com qual banco iremos fazer a conexão.
// Resumo: Eu to adicionando ao meu PROJETO a minha Classe ApplicationDBContext que será a minha FACTORY, além de dizer para o projeto que ele usará as configurações da Classe ApplicationDBContext e ela também servirá como modelo para instâncias que servirão para manipular o banco.
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection") ));
// OBS: Vale ressaltar a SINTAXE pode mudar um pouco de acordo com o BANCO que você usa, e cada banco tem um PACOTE DIFERENTE.



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();