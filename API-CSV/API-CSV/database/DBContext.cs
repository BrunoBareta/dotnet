using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using API_CSV.database.models;
using Microsoft.Extensions.Configuration.CommandLine;

namespace API_CSV.database 
{
    public class DBContext  
        
    {
        public const string PathName =
           "C:\\Users\\USER\\Desktop\\FACULDADE 2023.2024\\API-DOTNET\\API-CSV\\API-CSV\\animais.txt";

        private List<Animal> _animais = new(); 

        public DBContext()
        {
            string[] lines =
             File.ReadAllLines(PathName);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] coluns =
                    lines[i].Split(';');

                Animal animal = new();
                animal.id = int.Parse(coluns[0]);
                animal.Name = coluns[1];
                animal.Classification = coluns[2];
                animal.Origin = coluns[3];
                animal.Reproduction = coluns[4];
                animal.Feeding = coluns[5];

                _animais.Add(animal);
            }
        }

        public List<Animal> Animais => _animais;

        public object Animals { get; internal set; }
    }
}

