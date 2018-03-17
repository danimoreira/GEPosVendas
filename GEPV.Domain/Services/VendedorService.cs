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
    public class VendedorService : ServiceBase<Vendedor>, IVendedorService
    {
        private IVendedorRepository _repository { get; set; }

        public VendedorService(IVendedorRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
