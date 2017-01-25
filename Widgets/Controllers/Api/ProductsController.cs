using System.Linq;
using System.Web.Http;
using Widgets.Models;

namespace Widgets.Controllers.Api
{
    public class ProductsController : BaseController
    {
        // GET: api/Products
        public object Get()
        {
            var widgets = Repository.Widgets.GetAllWidgets();
            int totalRecords = widgets.Count();
            return new
            {
                TotalRecords = totalRecords,
                Products = widgets.Select(x => Factory.Create(x))
            };
        }

        // GET: api/Products/{id}
        public IHttpActionResult Get(int id)
        {
            var widget = Repository.Widgets.GetWidgetById(id);
            if (widget != null)
            {
                return Ok(Factory.Create(widget));
            }
            return NotFound();
        }

        // POST: api/Products
        public IHttpActionResult Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!Repository.Widgets.CreateWidget(Factory.Create(product)))
            {
                return InternalServerError();
            }

            return Ok();
        }

        // PUT: api/Products
        public IHttpActionResult Put(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!Repository.Widgets.UpdateWidget(Factory.Create(product)))
            {
                return InternalServerError();
            }

            return Ok();
        }

        // DELETE: api/Products
        public IHttpActionResult Delete(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!Repository.Widgets.DeleteWidget(Factory.Create(product)))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}