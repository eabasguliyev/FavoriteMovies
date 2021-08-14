using System.Windows.Documents;
using FavoriteMovies.Wpf.ViewModels;

namespace FavoriteMovies.Wpf.Wrappers
{
    public abstract class ModelWrapper<T>:ObservableObject where T:class
    {
        public T Model { get; set; }

        public ModelWrapper(T model)
        {
            Model = model;
        }
    }
}