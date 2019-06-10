using Domain.Models;
using NUnit.Framework;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class FilmeTeste
    {
        private FilmeRepository _filmeRepository;
        private LocacaoRepository _locacaoRepository;
        private ReservaRepository _reservaRepository;

        [SetUp]
        public void Setup()
        {
            _filmeRepository = new FilmeRepository();
            _locacaoRepository = new LocacaoRepository();
            _reservaRepository = new ReservaRepository();
        }

        [Test, Order(1)]
        public void CargaFilme()
        {
            try
            {
                List<Filme> lista = new List<Filme>() { new Filme() { Nome = "Filme 1", AnoLancamento = 2014, Resumo = "Resumo" , Caminho = "~/images/2.jpg" , Alugado =false }
                                                     , new Filme() { Nome = "Filme 2", AnoLancamento = 2015, Resumo = "Resumo" ,  Caminho = "~/images/1.jpg", Alugado =false  }
                                                     ,  new Filme() { Nome = "Filme 2", AnoLancamento = 2015, Resumo = "Resumo" ,  Caminho = "~/images/3.jpg" , Alugado =false }
                                                     , new Filme() { Nome = "Filme 2", AnoLancamento = 2015, Resumo = "Resumo" ,  Caminho = "~/images/4.jpg", Alugado =false  }
                                                     , new Filme() { Nome = "Filme 2", AnoLancamento = 2015, Resumo = "Resumo" ,  Caminho = "~/images/5.jpg", Alugado =false  }
                                                     , new Filme() { Nome = "Filme 2", AnoLancamento = 2015, Resumo = "Resumo" ,  Caminho = "~/images/6.jpg", Alugado =false  }
                                                     , new Filme() { Nome = "Filme 2", AnoLancamento = 2015, Resumo = "Resumo" ,  Caminho = "~/images/8.jpg", Alugado =false  }
                                                     , new Filme() { Nome = "Filme 3", AnoLancamento = 2016, Resumo = "Resumo" ,  Caminho = "~/images/7.jpg", Alugado =false  }};

                lista.ForEach(x => _filmeRepository.Insert(ref x));
                Assert.IsTrue(_filmeRepository.GetAll().Any());
            }
            catch (Exception)
            {
                Assert.Fail("Erro ao inserir carga");
            }
        }

        [Test]
        public void GetAllMovies()
        {
            try
            {
                var result = _filmeRepository.GetAll().ToList();
                Assert.IsTrue(result.Any());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void FilmeAlugado()
        {
            try
            {
                var idFilme = 1;
                var consulta = _filmeRepository.GetById(idFilme);
                if (consulta != null)
                    Assert.IsTrue(consulta.Alugado == true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        public void Devolver()
        {
            var alugado = false;
            var idFilme = 1;
            var idCliente = 1;
            var reserva = new Reserva { Id = 1, idCliente = idCliente, idFilme = idFilme };
            var filme = new Filme() { Id = idFilme, Alugado = alugado };

            try
            {
                _filmeRepository.Update(filme);
                _reservaRepository.AvisarClienteFilmeDisponivel(new Reserva { Id = idFilme, idCliente = idCliente });
                _reservaRepository.Delete(reserva.Id);
                var _filme = _filmeRepository.GetById(filme.Id);
                Assert.IsTrue(_filme.Alugado == false);
            }
            catch (Exception)
            {
                Assert.Fail("Erro no fluxo de devolução.");
            }
        }
    }
}