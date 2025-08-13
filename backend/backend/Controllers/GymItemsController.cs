using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GymItemsController : ControllerBase
    {
        private static readonly List<GymItem> Items = new()
        {
            new GymItem { Id = 1, Name = "Dumbbell", Price = 49.99m, Quantity = 10 },
            new GymItem { Id = 2, Name = "Treadmill", Price = 799.99m, Quantity = 3 },
            new GymItem { Id = 3, Name = "Yoga Mat", Price = 29.99m, Quantity = 25 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<GymItem>> GetAll()
        {
            return Ok(Items);
        }

        [HttpGet("{id}")]
        public ActionResult<GymItem> GetById(int id)
        {
            var item = Items.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public ActionResult<GymItem> Create(GymItem newItem)
        {
            newItem.Id = Items.Max(x => x.Id) + 1;
            Items.Add(newItem);
            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }
    }
}
