using GestaoDeEquipamento.WebApp.Compartilhado.Infraestrutura.Arquivos;

namespace GestaoDeEquipamento.WebApp.Modulos.Fabricantes.Infraestrutura;

public sealed class RepositorioFabricanteEmArquivo : RepositorioBaseEmArquivo<Fabricante>
{
    public RepositorioFabricanteEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Fabricante> ObterRegistros()
    {
        return contexto.Fabricantes;
    }
}