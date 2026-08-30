using GestaoDeEquipamento.WebApp.Compartilhado.Dominio;
using GestaoDeEquipamento.WebApp.Modulos.Equipamentos.Dominio;

namespace GestaoDeEquipamento.WebApp.Modulos.Chamados.Dominio;

public sealed class Chamado : EntidadeBase
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public Equipamento Equipamento { get; set; } = null!;
    public DateTime DataAbertura { get; set; }

    public Chamado() { }

    public Chamado(string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura) : this()
    {
        Titulo = titulo;
        Descricao = descricao;
        Equipamento = equipamento;
        DataAbertura = dataAbertura;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Chamado chamadoAtualizado = (Chamado)entidadeAtualizada;

        Titulo = chamadoAtualizado.Titulo;
        Descricao = chamadoAtualizado.Descricao;
        Equipamento = chamadoAtualizado.Equipamento;
        DataAbertura = chamadoAtualizado.DataAbertura;
    }
}