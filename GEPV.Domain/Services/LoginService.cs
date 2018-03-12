using GEPV.Domain.DTO;
using GEPV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEPV.Domain.Interfaces.Repository;
using GEPV.Domain.Repository;
using GEPV.Domain.Interfaces.Services;

namespace GEPV.Domain.Services
{
    public class LoginService : ServiceBase<Vendedor>, ILoginService
    {
        private ILoginRepository _repository { get; set; }

        public LoginService(ILoginRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Vendedor Logar(LoginDto dados)
        {
           var retorno = _repository.List();
        
           return retorno.Where(x => x.Login == dados.Usuario && x.Senha == dados.Senha).FirstOrDefault();

        }
    }
}
