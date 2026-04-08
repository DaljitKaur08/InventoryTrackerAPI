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
    public class SupplierController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SupplierController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDTO>>> GetSuppliers()
        {
            var suppliers = await _context.Suppliers.ToListAsync();
            return Ok(_mapper.Map<List<SupplierDTO>>(suppliers));
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDTO>> GetSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
                return NotFound();

            return Ok(_mapper.Map<SupplierDTO>(supplier));
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<SupplierDTO>> CreateSupplier(SupplierDTO supplierDto)
        {
            if (string.IsNullOrEmpty(supplierDto.Name))
                return BadRequest("Supplier name is required");

            var supplier = _mapper.Map<Supplier>(supplierDto);

            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSupplier),
                new { id = supplier.SupplierId },
                _mapper.Map<SupplierDTO>(supplier));
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, SupplierDTO supplierDto)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
                return NotFound();

            _mapper.Map(supplierDto, supplier);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
                return NotFound();

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}