using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptionAgency.Backend.Domain.Model.Chat
{
    public class GroupChat
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public GroupChat(){}
        public GroupChat(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
