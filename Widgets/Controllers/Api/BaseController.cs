using System.Web.Http;
using Widgets.Models;
using Widgets.Repository;
using Widgets.Repository.MockData;

namespace Widgets.Controllers.Api
{
    public class BaseController : ApiController
    {
        IRepository _repository;
        ModelFactory _factory;

        public BaseController()
        {
            _repository = new MockRepository(); // Using MockData 
        }

        protected IRepository Repository
        {
            get
            {
                return _repository;
            }
        }

        protected ModelFactory Factory
        {
            get
            {
                if (_factory == null)
                {
                    _factory = new ModelFactory(_repository, Request);
                }
                return _factory;
            }
        }
    }
}
