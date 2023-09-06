using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NotesDataAccess.Data;
using NotesDataAccess.Models;
using System.Net.Mime;

namespace Notes.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteData _noteData;

        public NotesController(INoteData noteData)
        {
            _noteData = noteData;
        }

        // GET: api/<NotesController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<NoteModel>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<Results<NotFound, Ok<IEnumerable<NoteModel>>, ProblemHttpResult>> Get()
        {
            try
            {
                var result = await _noteData.GetAllAsync();
                return result == null ? TypedResults.NotFound() : TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Problem("Internal Error");
            }
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(NoteModel), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<Results<NotFound, Ok<NoteModel>, ProblemHttpResult>> Get(int id)
        {
            try
            {
                var result = await _noteData.GetAsync(id);
                return result == null ? TypedResults.NotFound() : TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Problem("Internal Error");
            }
        }

        // POST api/<NotesController>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(NoteModel), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<Results<BadRequest<string>, Ok<NoteModel>, ProblemHttpResult>> Post([FromBody] NoteModel value)
        {
            try
            {
                var result = await _noteData.InsertAsync(value);
                return result == null ? TypedResults.BadRequest("Validation error") : TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Problem("Internal Error");
            }
        }

        // PUT api/<NotesController>/5
        [HttpPut()]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(NoteModel), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<Results<BadRequest<string>, Ok<NoteModel>, ProblemHttpResult>> Put([FromBody] NoteModel value)
        {
            try
            {
                var result = await _noteData.UpdateAsync(value);
                return result == null ? TypedResults.BadRequest("Validation error") : TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Problem("Internal Error");
            }
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(NoteModel), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<Results<BadRequest<string>, Ok<NoteModel>, ProblemHttpResult>> Delete(int id)
        {
            try
            {
                var result = await _noteData.DeleteAsync(id);
                return result == null ? TypedResults.BadRequest("Validation error") : TypedResults.Ok(result);
            }
            catch (Exception)
            {
                return TypedResults.Problem("Internal Error");
            }
        }
    }
}
