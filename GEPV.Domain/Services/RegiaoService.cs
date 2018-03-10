using GEPV.Domain.Entities;
using GEPV.Domain.Interfaces.Repository;
using GEPV.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEPV.Domain.Services
{
    public class RegiaoService : ServiceBase<Regiao>, IRegiaoService
    {
        private IRegiaoRepository _repository { get; set; }

        public RegiaoService(IRegiaoRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
