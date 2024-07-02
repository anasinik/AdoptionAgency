﻿
using AdoptionAgency.Backend.Domain.Model.Common;

namespace AdoptionAgency.Backend.Domain.Model.Animal
{
    public class Animal
    {
        public int Id { get; set; }
        public AnimalSpecies Species {  get; set; }
        public DateTime BirthDate { get; set; }
        public string FoundLocation { get; set; }
        public Place FoundPlace {  get; set; }
        public string HealthCondition { get; set; }
        public string Behaviour { get; set; }
        public Gender Gender {  get; set; }
        public bool Adopted {  get; set; }
        public double Weight { get; set; }
        public string Size {  get; set; }
        
        public Animal(int id, AnimalSpecies species, DateTime birthDate, string foundLocation, Place foundPlace,
                      string healthCondition, string behaviour, Gender gender, double weight, string size)
        {
            Id = id;
            Species = species;
            BirthDate = birthDate;
            FoundLocation = foundLocation;
            FoundPlace = foundPlace;
            HealthCondition = healthCondition;
            Behaviour = behaviour;
            Gender = gender;
            Weight = weight;
            Size = size;
            Adopted = false;
        }
    }
}
