using Domain.Models;
using NUnit.Framework;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Test
{
    internal class ClienteTeste
    {
        private ClienteRepository _clienteRepository;

        [SetUp]
        public void Setup()
        {
            _clienteRepository = new ClienteRepository();
        }

        [Test, Order(1)]
        public void CargaCliente()
        {
            try
            {
                var lista = new List<Cliente>() { new Cliente { Email = "renato1@gmail.com", Fone = "61984201289", NomeCompleto = "Renato 1" },
                                                  new Cliente { Email = "renato2@gmail.com", Fone = "61984201289", NomeCompleto = "Renato 1" },
                                                  new Cliente { Email = "renato3@gmail.com", Fone = "61984201289", NomeCompleto = "Renato 1" }
                };

                lista.ForEach(x => _clienteRepository.Insert(ref x));
                Assert.IsTrue(_clienteRepository.GetAll().Any());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void GetAllClients()
        {
            try
            {
                var result = _clienteRepository.GetAll().ToList();
                Assert.IsTrue(result.Any());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}