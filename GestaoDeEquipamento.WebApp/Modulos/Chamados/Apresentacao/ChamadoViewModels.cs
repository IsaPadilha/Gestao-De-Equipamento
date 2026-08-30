using System.ComponentModel.DataAnnotations;

namespace GestaoDeEquipamento.WebApp.Modulos.Chamados.Apresentacao;

public record ListarChamadoViewModel(
    int Id,
    string Titulo,
    string Descricao,
    string Equipamento,
    DateTime DataAbertura,
    int DiasAberto
);

public record CadastrarChamadoViewModel(
    [Required(ErrorMessage = "O campo \"Título\" é obrigatório.")]
    [StringLength(100, MinimumLength = 3,
        ErrorMessage = "O campo \"Título\" deve conter entre 3 e 100 caracteres.")]
    string? Titulo,

    [Required(ErrorMessage = "O campo \"Descrição\" é obrigatório.")]
    string? Descricao,

    [Range(1, int.MaxValue, ErrorMessage = "Selecione um equipamento válido.")]
    int EquipamentoId,

    [Required(ErrorMessage = "O campo \"Data de Abertura\" é obrigatório.")]
    [DataType(DataType.Date)]
    DateTime? DataAbertura
);

public record EditarChamadoViewModel(
    int Id,

    [Required(ErrorMessage = "O campo \"Título\" é obrigatório.")]
    [StringLength(100, MinimumLength = 3,
        ErrorMessage = "O campo \"Título\" deve conter entre 3 e 100 caracteres.")]
    string? Titulo,

    [Required(ErrorMessage = "O campo \"Descrição\" é obrigatório.")]
    string? Descricao,

    [Range(1, int.MaxValue, ErrorMessage = "Selecione um equipamento válido.")]
    int EquipamentoId,

    [Required(ErrorMessage = "O campo \"Data de Abertura\" é obrigatório.")]
    [DataType(DataType.Date)]
    DateTime? DataAbertura
);

public record ExcluirChamadoViewModel(int Id, string Titulo);