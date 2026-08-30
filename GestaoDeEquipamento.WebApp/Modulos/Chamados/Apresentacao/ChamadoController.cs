using Microsoft.AspNetCore.Mvc;
using GestaoDeEquipamento.WebApp.Modulos.Chamados.Infraestrutura;
using GestaoDeEquipamento.WebApp.Modulos.Equipamentos.Infraestrutura;
using GestaoDeEquipamento.WebApp.Modulos.Chamados.Dominio;

namespace GestaoDeEquipamento.WebApp.Modulos.Chamados.Apresentacao;

public sealed class ChamadoController : Controller
{
    private readonly RepositorioChamadoEmArquivo repositorioChamado;
    private readonly RepositorioEquipamentoEmArquivo repositorioEquipamento;

    public ChamadoController(
        RepositorioChamadoEmArquivo repositorioChamado,
        RepositorioEquipamentoEmArquivo repositorioEquipamento)
    {
        this.repositorioChamado = repositorioChamado;
        this.repositorioEquipamento = repositorioEquipamento;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarChamadoViewModel> viewModels = new List<ListarChamadoViewModel>();

        foreach (Chamado chamado in repositorioChamado.SelecionarTodos())
        {
            int diasAberto = (DateTime.Now.Date - chamado.DataAbertura.Date).Days;

            viewModels.Add(new ListarChamadoViewModel(
                chamado.Id,
                chamado.Titulo,
                chamado.Descricao,
                chamado.Equipamento.Nome,
                chamado.DataAbertura,
                diasAberto
            ));
        }

        return View(viewModels);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        ViewBag.Equipamentos = repositorioEquipamento.SelecionarTodos();

        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarChamadoViewModel CadastrarVm)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Equipamentos = repositorioEquipamento.SelecionarTodos();
            return View(CadastrarVm);
        }

        var equipamentoSelecionado = repositorioEquipamento.SelecionarPorId(CadastrarVm.EquipamentoId);

        if (equipamentoSelecionado == null)
        {
            ModelState.AddModelError(nameof(CadastrarVm.EquipamentoId), "Selecione um equipamento válido.");
            ViewBag.Equipamentos = repositorioEquipamento.SelecionarTodos();
            return View(CadastrarVm);
        }

        Chamado chamado = new Chamado(
            CadastrarVm.Titulo ?? string.Empty,
            CadastrarVm.Descricao ?? string.Empty,
            equipamentoSelecionado,
            CadastrarVm.DataAbertura!.Value
        );

        repositorioChamado.Cadastrar(chamado);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(int id)
    {
        Chamado? chamadoSelecionado = repositorioChamado.SelecionarPorId(id);

        if (chamadoSelecionado == null)
            return NotFound();

        EditarChamadoViewModel viewModel = new EditarChamadoViewModel(
            chamadoSelecionado.Id,
            chamadoSelecionado.Titulo,
            chamadoSelecionado.Descricao,
            chamadoSelecionado.Equipamento.Id,
            chamadoSelecionado.DataAbertura
        );

        ViewBag.Equipamentos = repositorioEquipamento.SelecionarTodos();

        return View(viewModel);
    }

    [HttpPost]
    public ActionResult Editar(EditarChamadoViewModel editarVm)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Equipamentos = repositorioEquipamento.SelecionarTodos();
            return View(editarVm);
        }

        var equipamentoSelecionado = repositorioEquipamento.SelecionarPorId(editarVm.EquipamentoId);

        if (equipamentoSelecionado == null)
        {
            ModelState.AddModelError(nameof(editarVm.EquipamentoId), "Selecione um equipamento válido.");
            ViewBag.Equipamentos = repositorioEquipamento.SelecionarTodos();
            return View(editarVm);
        }

        Chamado chamadoAtualizado = new Chamado(
            editarVm.Titulo ?? string.Empty,
            editarVm.Descricao ?? string.Empty,
            equipamentoSelecionado,
            editarVm.DataAbertura!.Value
        );

        bool conseguiuEditar = repositorioChamado.Editar(editarVm.Id, chamadoAtualizado);

        if (!conseguiuEditar)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }


    [HttpGet]
    public ActionResult Excluir(int id)
    {
        Chamado? chamadoSelecionado = repositorioChamado.SelecionarPorId(id);

        if (chamadoSelecionado == null)
            return NotFound();

        return View(new ExcluirChamadoViewModel(
            chamadoSelecionado.Id,
            chamadoSelecionado.Titulo
        ));
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirChamadoViewModel excluirVm)
    {
        bool conseguiuExcluir = repositorioChamado.Excluir(excluirVm.Id);

        if (!conseguiuExcluir)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }
}