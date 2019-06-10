using Domain.Models;
using System;
using System.Linq;

namespace Repository.Repositories
{
    public class LocacaoRepository : RepositoryBase<Locacao>
    {
        public bool FilmeAlugado(int idFilme)
        {
            var hoje = DateTime.Now.Date;

            return GetAll().Where(x => x.idFilme == idFilme && x.DataDevolucao.Date > hoje.Date).Any(); //&& x.DataDevolucao.Date <= hoje.Date)).FirstOrDefault();
        }
    }
}