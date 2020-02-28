using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiToDo.Models
{
    public class ToDoModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string ToDoText { get; set; }
        public bool IsComplete { get; set; }
        
    }
}