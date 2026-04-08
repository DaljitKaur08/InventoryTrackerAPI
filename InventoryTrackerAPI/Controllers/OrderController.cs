using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryTrackerAPI.Data;
using InventoryTrackerAPI.Models;
using InventoryTrackerAPI.DTOs;
using AutoMapper;

namespace InventoryTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrderController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(_mapper.Map<List<OrderDTO>>(orders));
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            return Ok(_mapper.Map<OrderDTO>(order));
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateOrder(OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder),
                new { id = order.OrderId },
                _mapper.Map<OrderDTO>(order));
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderDTO orderDto)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            _mapper.Map(orderDto, order);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}