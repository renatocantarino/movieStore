using NUnit.Framework;
using Repository.Repositories;
using System;

namespace Store.Test
{
    internal class locacaoTeste
    {
        private LocacaoRepository _locacaoRepository;

        [SetUp]
        public void Setup()
        {
            _locacaoRepository = new LocacaoRepository();
        }

        [Test]
        public void Alugar()
        {
            try
            {
                var _loc = new Domain.Models.Locacao() { idCliente = 1, idFilme = 1 };
                _locacaoRepository.Insert(ref _loc);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}