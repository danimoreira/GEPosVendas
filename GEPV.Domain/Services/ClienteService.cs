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
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private IClienteRepository _repository { get; set; }

        public ClienteService(IClienteRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
