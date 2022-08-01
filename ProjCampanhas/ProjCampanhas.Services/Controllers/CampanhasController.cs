using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjCampanhas.Application.Commands;
using ProjCampanhas.Application.Interfaces;

namespace ProjCampanhas.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CampanhasController : ControllerBase
    {
        //atributo
        private readonly ICampanhaAppService _campanhaAppService;

        //construtor para injeção de dependência
        public CampanhasController(ICampanhaAppService campanhaAppService)
        {
            _campanhaAppService = campanhaAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CampanhaCreateCommand command)
        {
            try
            {
                 var campanha = await _campanhaAppService.Create(command);

                return StatusCode(201, campanha);//Created
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Errors);//Bad Request
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });//Bad Request
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });//Internal Error
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(CampanhaUpdateCommand command)
        {
            try
            {
                var campanha =  await _campanhaAppService.Update(command);

                return StatusCode(200, campanha);// OK (Updated)
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Errors);//Bad Request
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });//Bad Request
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });//Internal Error
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var command = new CampanhaDeleteCommand { Id = id };

                var campanha = await _campanhaAppService.Delete(command);

                return StatusCode(200, campanha);// OK (deleted)
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });//Bad Request
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });//Internal Error
            }
        }

        [HttpGet("{page}/{limit}")]
        public IActionResult GetAll(int page, int limit)
        {
            try
            {
                var campanhas = _campanhaAppService.GetAll(page, limit);
                if (campanhas.Count == 0)
                {
                    return NoContent();
                }
                return StatusCode(200, campanhas);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });//Bad Request
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });//Internal Error
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var campanha = _campanhaAppService.GetById(id);
                if (campanha == null)
                {
                    return NoContent();
                }
                return StatusCode(200, campanha);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });//Bad Request
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });//Internal Error
            }
        }
    }
}
