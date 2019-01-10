using AnimalCentre.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private AnimalCentre centerController;
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.centerController = new AnimalCentre();
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command = String.Empty;
            while ((command = this.reader.readData()) != "End")
            {

                try
                {
                    this.ReadCommand(command);
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine("ArgumentException: " + e.Message);
                }
                catch (InvalidOperationException e)
                {
                    this.writer.WriteLine("InvalidOperationException: " + e.Message);
                }

            }

            this.writer.WriteLine(this.centerController.AdoptedAnimals());
        }

        private void ReadCommand(string command)
        {
            string[] tokens = command.Split(" ");
            var output = string.Empty;

            string[] regData = tokens.Skip(1).ToArray();

            switch (tokens[0])
            {
                case "RegisterAnimal":
                    var animal = regData[0];
                    var name = regData[1];
                    int energy = int.Parse(regData[2]);
                    int happiness = int.Parse(regData[3]);
                    int playTime = int.Parse(regData[4]);

                    output = this.centerController.RegisterAnimal(animal, name, energy, happiness, playTime);
                    break;

                case "Chip":
                    string animalName = regData[0];
                    int procedureTime = int.Parse(regData[1]);
                    output = this.centerController.Chip(animalName, procedureTime);
                    break;

                case "Play":
                    string playName = regData[0];
                    int playProcTime = int.Parse(regData[1]);
                    output = this.centerController.Play(playName, playProcTime);
                    break;

                case "Fitness":
                    string fitnessName = regData[0];
                    int fitnessProcTime = int.Parse(regData[1]);
                    output = this.centerController.Fitness(fitnessName, fitnessProcTime);
                    break;

                case "NailTrim":
                    string nailTrimName = regData[0];
                    int nailTrimProcTime = int.Parse(regData[1]);
                    output = this.centerController.NailTrim(nailTrimName, nailTrimProcTime);
                    break;

                case "Vaccinate":
                    string vaccinateName = regData[0];
                    int vacProcTime = int.Parse(regData[1]);
                    output = this.centerController.Vaccinate(vaccinateName, vacProcTime);
                    break;

                case "DentalCare":
                    string dentalCareName = regData[0];
                    int dentalCareProcTime = int.Parse(regData[1]);
                    output = this.centerController.DentalCare(dentalCareName, dentalCareProcTime);
                    break;

                case "Adopt":
                    string adoptName = regData[0];
                    string owner = regData[1];
                    output = this.centerController.Adopt(adoptName, owner);
                    break;

                case "History":
                    output = this.centerController.History(tokens[1]);
                    break;
            }

            if (output != string.Empty)
            {
                this.writer.WriteLine(output);
            }
        }
    }
}
