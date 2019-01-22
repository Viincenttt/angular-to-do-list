using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Data.Dtos.Response;
using TodoList.Api.Data.Models;
using TodoList.Api.Data.Repositories;
using TodoList.Api.Framework.Extensions;

namespace TodoList.Api.Controllers {
    [Route("api/todo")]
    [Authorize]
    public class TodoItemController : ControllerBase {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IMapper _mapper;

        public TodoItemController(ITodoItemRepository todoItemRepository, IMapper mapper) {
            this._todoItemRepository = todoItemRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll() {
            IList<TodoItemResponse> response = this._todoItemRepository.GetAll()
                .ProjectTo<TodoItemResponse>(this._mapper.ConfigurationProvider)
                .ToList();

            return this.Ok(response);
        }

        [HttpGet]
        [Route("{id}", Name = "GetTodoItem")]
        public IActionResult Get(int id) {
            TodoItem todoItem = this._todoItemRepository.GetById(id);
            if (todoItem == null) {
                return this.NotFound();
            }

            TodoItemResponse response = this._mapper.Map<TodoItemResponse>(todoItem);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Add([FromBody]TodoItemResponse response) {
            if (!this.ModelState.IsValid) {
                return this.BadRequest(this.ModelState);
            }

            TodoItem todoItem = this._mapper.Map<TodoItem>(response);
            todoItem.ApplicationUserId = this.GetUserId();

            this._todoItemRepository.Add(todoItem);
            this._todoItemRepository.SaveChanges();

            return this.CreatedAtRoute("GetTodoItem", new { id = todoItem.Id }, this._mapper.Map<TodoItemResponse>(todoItem));
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody]TodoItemResponse response) {
            if (!this.ModelState.IsValid) {
                return this.BadRequest(this.ModelState);
            }

            TodoItem todoItem = this._todoItemRepository.GetById(id);
            if (todoItem == null) {
                return this.NotFound();
            }

            this._mapper.Map(response, todoItem);
            this._todoItemRepository.SaveChanges();

            return this.CreatedAtRoute("GetTodoItem", new { id = todoItem.Id }, this._mapper.Map<TodoItemResponse>(todoItem));
        }
    }
}