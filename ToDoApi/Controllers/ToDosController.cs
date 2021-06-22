using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApi.Models;
using ToDoApi.Services;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/todos")]
    [Authorize]
    public class ToDosController: ControllerBase
    {

        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public ToDosController(IMapper mapper, ITodoRepository todoRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetTodosAsync()
        {
            var todos = await _todoRepository.GetToDosAsync();
            return Ok(_mapper.Map<IEnumerable<TodoDTO>>(todos));
        }

        [HttpGet]
        [Route("{id}", Name = "GetTodoAsync")]
        public async Task<IActionResult> GetTodoAsync(int id)
        {
            var toDo = await _todoRepository.GetToDoAsync(id);
            if(toDo == null)
            {
                return NotFound("Todo does not exist");
            }
            return Ok(_mapper.Map<TodoDTO>(toDo));
        }

        [HttpPost]
        public IActionResult AddToDo([FromBody] TodoDTO todo)
        {
            var todoEntity = _mapper.Map<Entities.ToDo>(todo);
            if (!string.IsNullOrWhiteSpace(todoEntity.Title) && !string.IsNullOrWhiteSpace(todoEntity.Description)
                && todoEntity.Priority != 0)
            {
                //add and save changes
                _todoRepository.AddToDo(todoEntity);
                _todoRepository.SaveChanges();
                return Ok("Todo Created");
                //return CreatedAtRoute("GetTodoAsync", new { id = todoEntity.Id });
            }
            return BadRequest("todo entity is empty");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTodo(int Id)
        {
            if (_todoRepository.ToDoExists(Id)){
                var todo = await _todoRepository.GetToDoAsync(Id);
                var todoEntity = _mapper.Map<Entities.ToDo>(todo);
                _todoRepository.DeleteToDo(todoEntity);
                _todoRepository.SaveChanges();

                return Ok("Todo deleted");
            } else { return NotFound("Todo does not exists"); }
        }

        [HttpPut]
        public IActionResult UpdateTodo([FromBody] TodoDTO todoDTO)
        {
            if (_todoRepository.ToDoExists(todoDTO.Id))
            {
                var todoEntity = _mapper.Map<Entities.ToDo>(todoDTO);
                _todoRepository.UpdateToDo(todoEntity);
                _todoRepository.SaveChanges();

                return Ok("Todo updated");               
            }return NotFound("Todo does not exist");
        }
    }
}
