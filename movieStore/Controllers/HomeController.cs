using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using movieStore.Models;
using System.Diagnostics;
using System.Linq;

namespace movieStore.Controllers
{
    public class HomeController : BaseController
    {
        private readonly Repository.Repositories.FilmeRepository filmeRepository;
        private readonly Repository.Repositories.LocacaoRepository locacaoRepository;
        private readonly Repository.Repositories.ClienteRepository clienteRepository;
        private readonly Repository.Repositories.ReservaRepository reservaRepository;

        public HomeController()
        {
            filmeRepository = new Repository.Repositories.FilmeRepository();
            locacaoRepository = new Repository.Repositories.LocacaoRepository();
            clienteRepository = new Repository.Repositories.ClienteRepository();
        }

        public IActionResult Login()
        {
            return View("Privacy", new UsuarioVM());
        }

        [HttpPost]
        public IActionResult Login(UsuarioVM usuarioVm)
        {
            var usuario = clienteRepository.GetList(x => x.Email == usuarioVm.Email).FirstOrDefault();
            if (usuario != null)
            {
                TempData["usuario"] = usuario.Id;
                return RedirectToAction("Index");
            }

            ShowMessage("usuario não localizado");
            return View("Privacy", new UsuarioVM());
        }

        public IActionResult Index()
        {
            return View(filmeRepository.GetAll().ToList());
        }

        public IActionResult Alugar(int id)
        {
            try
            {
                var _loc = new Locacao { idCliente = (int)TempData["usuario"], idFilme = id };
                var _filme = filmeRepository.GetById(id);
                _filme.Alugado = true;

                filmeRepository.Update(_filme);
                locacaoRepository.Insert(ref _loc);
                ShowMessage("Obrigado por alugar este filme");
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IActionResult Devolver(int id)
        {
            try
            {
                var _loc = new Locacao { idCliente = (int)TempData["usuario"], idFilme = id };
                var _filme = filmeRepository.GetById(id);
                _filme.Alugado = false;

                filmeRepository.Update(_filme);
                reservaRepository.AvisarClienteFilmeDisponivel(new Reserva { idFilme = id });
                ShowMessage("Filme devolvido! Obrigadado");

                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IActionResult Reservar(int id)
        {
            try
            {
                var _loc = new Reserva { idCliente = (int)TempData["usuario"], idFilme = id };
                reservaRepository.Insert(ref _loc);
                ShowMessage("Filme Reservado, você será avisado quando estiver disponivel! Obrigadado");

                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}