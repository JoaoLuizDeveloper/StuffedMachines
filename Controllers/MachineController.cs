using Microsoft.AspNetCore.Mvc;
using StuffedMachines.Application.IApplication;
using StuffedMachines.Model;

namespace StuffedMachines.API
{
    [Route("api/machine")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly IMachineApplication _machine;        
        public MachineController(IMachineApplication machine)
        {
            _machine = machine;
        }

        /// <summary>
        /// Get All Machines
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Machine>))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _machine.GetAll().ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get One Machine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("Get/{id:int}", Name = "GetMachine")]
        [ProducesResponseType(200, Type = typeof(Machine))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _machine.GetOne(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Create Machine
        /// </summary>
        /// <param name="machine"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("Create")]
        [ProducesResponseType(201, Type = typeof(Machine))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] Machine machine)
        {
            try
            {
                //Test pipeline
                return Ok(await _machine.Create(machine));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update Machine
        /// </summary>
        /// <param name="machine"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch("Update")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] Machine machine)
        {
            try
            {
                return Ok(await _machine.Update(machine));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete Machine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpDelete("Remove/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                return Ok(await _machine.Remove(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}