﻿namespace AdoptionAgency.Backend.Domain.Model.Person
{
    public class Person
    {
        public int Id { get; set; }
        public User.User User { get; set; } 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        public Person() { }
        public Person(int id, User.User user, string name, string lastName, string email, string phoneNumber)
        {
            Id = id;
            User = user;
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public Person(User.User user, string name, string lastName, string email, string phoneNumber)
        {
            User = user;
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
