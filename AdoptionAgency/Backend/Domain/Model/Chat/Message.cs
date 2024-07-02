using AdoptionAgency.Domain.Model.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptionAgency.Backend.Domain.Model.Chat
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; } = default!;
        public DateTime Timestamp { get; set; }
        public Person Person { get; set; } = default!;
        public Message(){}
        public Message(int id, string text, DateTime timestamp, Person person)
        {
            Id = id;
            Text = text;
            Timestamp = timestamp;
            Person = person;
        }
    }
}
