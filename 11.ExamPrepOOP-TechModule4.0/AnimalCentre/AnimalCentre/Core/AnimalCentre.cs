﻿using AnimalCentre.Models.Contracts;
using AnimalCentre.Core.AnimalFactory;
using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models;
using AnimalCentre.Models.Procedures;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private IAnimalFactory animalFactory;
        private readonly IHotel hotel;

        public AnimalCentre()
        {
            this.animalFactory = new AnimalFactory.AnimalFactory();
            this.hotel = new Hotel();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animal = this.animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);

            this.hotel.Accommodate(animal);

            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            var animal = this.hotel.Animals[name];
            var chip = new Chip();
            chip.DoService(animal, procedureTime);

            return $"{animal.Name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            var animal = this.hotel.Animals[name];
            var vaccinate = new Vaccinate();

            vaccinate.DoService(animal, procedureTime);

            return $"{animal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            var animal = this.hotel.Animals[name];
            var fitness = new Fitness();

            fitness.DoService(animal, procedureTime);

            return $"{animal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            var animal = this.hotel.Animals[name];
            var play = new Play();

            play.DoService(animal, procedureTime);

            return $"{animal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            var animal = this.hotel.Animals[name];
            var dentalCate = new DentalCare();

            dentalCate.DoService(animal, procedureTime);

            return $"{animal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            var animal = this.hotel.Animals[name];
            var nailTrim = new NailTrim();

            nailTrim.DoService(animal, procedureTime);

            return $"{animal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            throw new NotImplementedException();
        }

        public string History(string type)
        {
            throw new NotImplementedException();
        }

    }
}
