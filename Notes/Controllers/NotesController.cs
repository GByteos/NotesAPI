﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NotesDataAccess.Data;
using NotesDataAccess.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<Results<Ok<IEnumerable<NoteModel>>, ProblemHttpResult>> Get()
        {
            try
            {
                return TypedResults.Ok(await _noteData.GetAllAsync());
            }
            catch (Exception)
            {
                return TypedResults.Problem("Internal Error");
            }
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NotesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
