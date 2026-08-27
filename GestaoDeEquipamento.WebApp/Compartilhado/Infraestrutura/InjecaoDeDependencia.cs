using GestaoDeEquipamento.WebApp.Compartilhado.Infraestrutura.Arquivos;

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
    }
}