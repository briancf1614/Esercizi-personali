using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Regolo2020.Base.Business;
using Regolo2020.Base.DataModels;

namespace Regolo2020.Base.Controllers
{
    [ApiController]
    [Route("Regolo2020/RestService/[controller]")]
    public class BaseCrudController<TDbContext, TDataModel> : ControllerBase
        where TDbContext : DbContext
        where TDataModel : class, IDataModel
    {
        protected readonly IBusinessCrud<TDbContext, TDataModel> _business;

        public BaseCrudController(IBusinessCrud<TDbContext, TDataModel> business)
        {
            _business = business;
        }

        // /items? price[gte] = 10 & price[lte] = 100
        // /items? price=gte:10&price=lte:100

        // 'EQ' => '=',
        // 'NE' => '!=',
        // 'GT' => '>',
        // 'GE' => '>=',
        // 'LT' => '<',
        // 'LE' => '<=',
        // 'LIKE' => 'LIKE',
        // 'LIKESTART' => 'LIKE',
        // 'LIKEEND' => 'LIKE',
        // 'IS' => 'IS',
        // 'ISVALIDDATE' => 'ISVALIDDATE',
        // 'ANDLIKE' => 'LIKE',
        // 'ORLIKE' => 'LIKE',
        // 'REGEXP' => 'REGEXP'

        [HttpGet]
        public virtual ActionResult<IEnumerable<TDataModel>> Get([FromQuery(Name = "field")] string[] fieldsFilter, [FromQuery] int limit, [FromQuery] int offset, [FromQuery] string? fields)
        {
            var result = _business.Find(fieldsFilter, limit, offset);

            Response.Headers.Add("X-Total-Count", result.Count.ToString());

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public virtual ActionResult<TDataModel> Get(int id)
        {
            var item = _business.Get(id);

            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public virtual CreatedAtActionResult Create(TDataModel item)
        {
            var insertedItem = _business.Insert(item);
            return CreatedAtAction(nameof(Get), new { id = insertedItem.Id }, insertedItem);
        }

        [HttpPut("{id}")]
        public virtual ActionResult Update(int id, TDataModel item)
        {
            if (item != null)
            {
                // Make sure the ID and the passed object match.
                if (item.Id != id) return BadRequest("Id and item.Id are not the same");
                
                _business.Update(item);
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public virtual ActionResult Delete(int id)
        {
            // Make sure the object exists before performing a delete.
            var existingItem = _business.Get(id);
            if (existingItem == null) return NotFound();

            _business.Delete(existingItem);  

            return NoContent();
        }
    }
}