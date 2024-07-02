namespace AdoptionAgency.Backend.Domain.Model.Chat
{
    public class GroupChat
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public List<Person.Person> Persons { get; set; } = default!;
        public List<Message> Messages { get; set; } = default!;
        public GroupChat(){}
        public GroupChat(int id, string name, List<Person.Person> persons, List<Message> messages)
        {
            Id = id;
            Name = name;
            Persons = persons;
            Messages = messages;
        }
    }
}
