using GestaoDeEquipamento.WebApp.Compartilhado.Infraestrutura.Arquivos;
using GestaoDeEquipamento.WebApp.Modulos.Chamados.Dominio;

namespace GestaoDeEquipamento.WebApp.Modulos.Chamados.Infraestrutura;

public sealed class RepositorioChamadoEmArquivo : RepositorioBaseEmArquivo<Chamado>
{
    public RepositorioChamadoEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Chamado> ObterRegistros()
    {
        return contexto.Chamados;
    }
}