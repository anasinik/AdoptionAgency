namespace AdoptionAgency.Backend.Domain.Model.Chat
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; } = default!;
        public DateTime Timestamp { get; set; }
        public Person.Person Person { get; set; } = default!;
        public Message(){}
        public Message(int id, string text, DateTime timestamp, Person.Person person)
        {
            Id = id;
            Text = text;
            Timestamp = timestamp;
            Person = person;
        }
    }
}
