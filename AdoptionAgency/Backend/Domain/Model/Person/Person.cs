﻿namespace AdoptionAgency.Domain.Model.Person
{
    public abstract class Person
    {
        public int Id { get; set; }
        public int UserId { get; set; } 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
