﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _todoRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = _todoRepository.Find(id);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody]TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _todoRepository.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }


        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]TodoItem item)
        {
            if(item == null || item.Key != id)
            {
                return BadRequest();
            }

            var todo = _todoRepository.Find(id);

            if (todo == null)
            {
                return NotFound();
            }
            _todoRepository.Update(item);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var todo = _todoRepository.Find(id);
            if(todo == null)
            {
                return NotFound();
            }
            _todoRepository.Remove(id);
            return new NoContentResult();
        }

    }
}