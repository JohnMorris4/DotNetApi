using System;
using System.Collections.Generic;
using ApiToDo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiToDo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IMongoCRUD _db;

        public ToDoController(IMongoCRUD db)
        {
            _db = db;
        }
        [HttpGet]
        public IEnumerable<ToDoModel> Get()
        {
            return _db.LoadRecords<ToDoModel>(ApplicationSettings.MongoToDoTable);
        }

        [HttpGet]
        [Route("{id}")]
        public ToDoModel GetOne(Guid id)
        {
            return _db.LoadRecordById<ToDoModel>(ApplicationSettings.MongoToDoTable, id);
        }

        [HttpPost]
        public void Post(ToDoModel todo) //creates todo
        {
            _db.InsertRecord(ApplicationSettings.MongoToDoTable, todo);
        }

        [HttpPut]
        public void Put(ToDoModel todo)
        {
            _db.UpsertRecord(ApplicationSettings.MongoToDoTable, todo.Id, todo);
        }

        [HttpPatch]
        public void Patch(ToDoModel todo)
        {
            ToDoModel original = _db.LoadRecordById<ToDoModel>(ApplicationSettings.MongoToDoTable, todo.Id);
            original.IsComplete = todo.IsComplete;
            _db.UpsertRecord(ApplicationSettings.MongoToDoTable, original.Id, original);
        }

        [HttpDelete]
        public void Delete(ToDoModel todo)
        {
            _db.DeleteRecord<ToDoModel>(ApplicationSettings.MongoToDoTable, todo.Id);
        }
    }
}