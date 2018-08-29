using Prism.Mvvm;

namespace FindMePrism.Models
{
    public class City : BindableBase
    {
        private int id;
        private string name { get; set; }

        public int Id { get => id; set { id = value; base.RaisePropertyChanged(); } }
        public string Name { get => name; set { name = value; base.RaisePropertyChanged(); } }

    }
}