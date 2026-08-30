using GestaoDeEquipamento.WebApp.Compartilhado.Infraestrutura.Arquivos;
using GestaoDeEquipamento.WebApp.Modulos.Equipamentos.Dominio;

namespace GestaoDeEquipamento.WebApp.Modulos.Equipamentos.Infraestrutura;

public sealed class RepositorioEquipamentoEmArquivo : RepositorioBaseEmArquivo<Equipamento>
{
    public RepositorioEquipamentoEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Equipamento> ObterRegistros()
    {
        return contexto.Equipamentos;
    }
}