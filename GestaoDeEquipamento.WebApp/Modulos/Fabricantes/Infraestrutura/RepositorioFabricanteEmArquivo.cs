using GestaoDeEquipamento.WebApp.Compartilhado.Infraestrutura.Arquivos;
using GestaoDeEquipamento.WebApp.Modulos.Fabricantes.Dominio;

namespace GestaoDeEquipamento.WebApp.Modulos.Fabricantes.Infraestrutura;

public sealed class RepositorioFabricanteEmArquivo :
    RepositorioBaseEmArquivo<Fabricante>, IRepositorioFabricante
{
    public RepositorioFabricanteEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Fabricante> ObterRegistros()
    {
        return contexto.Fabricantes;
    }
}