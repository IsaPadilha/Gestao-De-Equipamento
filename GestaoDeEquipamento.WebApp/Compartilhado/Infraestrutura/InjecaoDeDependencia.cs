using GestaoDeEquipamento.WebApp.Compartilhado.Infraestrutura.Arquivos;
using GestaoDeEquipamento.WebApp.Modulos.Fabricantes.Infraestrutura;

namespace GestaoDeEquipamento.WebApp.Compartilhado.Infraestrutura;

public static class InjecaoDeDependencia
{
    public static void AdicionarCamadaDeInfraestrutura(this IServiceCollection services)
    {
        services.AddScoped(services =>
        {
            ContextoJson contexto = new ContextoJson();

            contexto.Carregar();

            return contexto;
        });

        // Configurar repositórios
        services.AddScoped<RepositorioFabricanteEmArquivo>();
    }
}