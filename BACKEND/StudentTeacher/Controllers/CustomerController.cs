using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTeacher.Core.Dtos;
using StudentTeacher.Core.Models;
using StudentTeacher.Repo.Data;
using StudentTeacher.Service.Filters.ActionFilters;
using StudentTeacher.Service.Interfaces;

namespace StudentTeacher.Controllers
{
    [Route("api/customers")]
    [ApiController]
    [AllowAnonymous]

    public class CustomerController : BaseApiController
    {
        public CustomerController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }

        [HttpGet]
        [ResponseCache(CacheProfileName = "30SecondsCaching")]
        public async Task<IActionResult> GetCustomer()
        {
            try
            {
                var teachers = await _repository.Customer.GetAllCustomer(trackChanges: false);
                var teachersDto = _mapper.Map<IEnumerable<CustomerDto>>(teachers);
                return Ok(teachersDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCustomer)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreationDto customer)
        {
            var teacherdata = _mapper.Map<Customer>(customer);
            await _repository.Customer.CreateCustomer(teacherdata);
            await _repository.SaveAsync();
            var teacherReturn = _mapper.Map<CustomerDto>(teacherdata);
            return Ok("Müşteri Oluşturuldu");
        }

        [HttpPost("CreateRange")]
        public async Task<IActionResult> CreateRange([FromBody] IEnumerable<CustomerCreationDto> entityDtos)
        {
            Random random = new Random();

            if(entityDtos!=null)
            {

            
            foreach (var item in entityDtos)
            {
            if (item.CompanyMail == null)
            {
                        item.CompanyMail = Guid.NewGuid().ToString() + "@example.com";
            }
            if (item.CompanyWeb == null)
            {
                    item.CompanyWeb = "null";
            }
            if (item.CompanyTel == null)
            {
                    item.CompanyTel = random.Next(10000, 99999);

            }
            if (item.CompanySector == null)
            {
                    item.CompanySector = "null";
            }
            }
            }
            // DTO listesini varlık listesine dönüştür
            var entities = _mapper.Map<IEnumerable<Customer>>(entityDtos);

            await _repository.Customer.CreateRangeAsync(entities);
            await _repository.SaveAsync();


            return Ok("Toplu olarak başarıyla oluşturuldu.");
        }

        [HttpGet("Customer/GetById/{customerId}", Name = "CustomerById")]
        public async Task<IActionResult> GetCustomer(int customerId)
        {
            var teacher = await _repository.Customer.GetCustomer(customerId, trackChanges: false);
            if (teacher is null)
            {
                _logger.LogInfo($"Teacher with id: {customerId} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var teacherDto = _mapper.Map<CustomerDto>(teacher);
                return Ok(teacherDto);
            }
        }

        [HttpPost("Customer/Delete/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var customer = await _repository.Customer.GetCustomer(id, trackChanges: false);

                if (customer == null)
                {
                    _logger.LogError($"Customer with id {id} was not found.");
                    return NotFound();
                }

                await _repository.Customer.DeleteCustomer(customer);
                await _repository.SaveAsync();

                return NoContent(); // İşlem başarılı, içerik döndürülmedi.
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(DeleteCustomer)} action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("Customer/Update/{CustomerId}")]

        public async Task<IActionResult> UpdateCustomer(int CustomerId, [FromBody] Customer customer)
        {
            var existingCustomer = await _repository.Customer.GetCustomer(CustomerId, trackChanges: true);

            if (existingCustomer == null)
            {
                return NotFound();
            }
            // Güncellenecek bilgileri mevcut müşteri nesnesine aktarın
            existingCustomer.CompanyName = customer.CompanyName;
            existingCustomer.CompanyMail = customer.CompanyMail;
            existingCustomer.CompanySector = customer.CompanySector;
            existingCustomer.CompanyTel = customer.CompanyTel;
            existingCustomer.CompanyWeb = customer.CompanyWeb;

            // Güncellenen müşteriyi veritabanına kaydedin
            await _repository.Customer.UpdateCustomer(existingCustomer);
            await _repository.SaveAsync();

            // Güncellenen müşteri bilgisini dönün (isteğe bağlı)
            var updatedCustomerDto = _mapper.Map<CustomerDto>(existingCustomer);
            return Ok(updatedCustomerDto);
        }

    }
}
