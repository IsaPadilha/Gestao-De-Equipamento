using GestaoDeEquipamento.WebApp.Compartilhado.Infraestrutura.Arquivos;
using GestaoDeEquipamento.WebApp.Modulos.Chamados.Infraestrutura;
using GestaoDeEquipamento.WebApp.Modulos.Equipamentos.Infraestrutura;
using GestaoDeEquipamento.WebApp.Modulos.Equipamentos.Dominio;
using GestaoDeEquipamento.WebApp.Modulos.Fabricantes.Dominio;
using GestaoDeEquipamento.WebApp.Modulos.Fabricantes.Infraestrutura;
namespace GestaoDeEquipamento.WebApp.Compartilhado.Infraestrutura;

public static class InjecaoDeDependencia
{
    public static void AdicionarCamadaDeInfraestrutura(
        this IServiceCollection services,
        IConfiguration configuration
        )
    {
        string connectionString = configuration.GetConnectionString("SqlServerLocalDB")!;
        services.AddScoped(services =>
        {
            ContextoJson contexto = new ContextoJson();

            contexto.Carregar();

            return contexto;
        });

        // Configurar repositórios
        services.AddScoped<IRepositorioFabricante>(_ =>
        {
            return new RepositorioFabricanteEmSql(connectionString);
        });

        services.AddScoped<IRepositorioEquipamento>(_ =>
        {
            return new RepositorioEquipamentoEmSql(connectionString);
        });

        services.AddScoped<RepositorioChamadoEmArquivo>();
    }
}