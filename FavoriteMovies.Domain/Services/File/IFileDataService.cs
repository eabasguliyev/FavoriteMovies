using System.Collections.Generic;
using FavoriteMovies.Domain.Models;

namespace FavoriteMovies.Domain.Services.File
{
    public interface IFileDataService<T>
    {
        List<T> Read(string fileName);
        void Write(string fileName, List<T> data);
    }
}