using System.Collections.Generic;
using System.IO;
using FavoriteMovies.Domain.Models;
using FavoriteMovies.Domain.Services.Api.Results;
using FavoriteMovies.Domain.Services.File;
using Newtonsoft.Json;

namespace FavoriteMovies.Wpf.Data
{
    public class MovieFileDataService:IFileDataService<MovieResult>
    {
        private readonly JsonSerializer _serializer;

        public MovieFileDataService()
        {
            _serializer = new JsonSerializer();
        }
        public List<MovieResult> Read(string fileName)
        {
            using StreamReader file = File.OpenText(fileName);

            return (List<MovieResult>)_serializer.Deserialize(file, typeof(List<MovieResult>));
        }

        public void Write(string fileName, List<MovieResult> movies)
        {
            using StreamWriter file = File.CreateText(fileName);

            _serializer.Serialize(file, movies);
        }
    }
}