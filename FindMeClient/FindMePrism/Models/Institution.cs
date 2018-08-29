using Prism.Mvvm;

namespace FindMePrism.Models
{
    public class Institution: BindableBase
    {
        private int id;
        private string name { get; set; }
        private string address { get; set; }
        private string number { get; set; }
        private string openingHours { get; set; }
        private string website { get; set; }
        private City institutionCity { get; set; }

        public int Id { get => id; set { id = value; base.RaisePropertyChanged(); } }
        public string Name { get => name; set { name = value; base.RaisePropertyChanged(); } }
        public string Address { get => address; set { address = value; base.RaisePropertyChanged(); } }
        public string Number { get => number; set { number = value; base.RaisePropertyChanged(); } }
        public string OpeningHours { get => openingHours; set { openingHours = value; base.RaisePropertyChanged(); } }
        public string Website { get => website; set { website = value; base.RaisePropertyChanged(); } }
        public City InstitutionCity { get => institutionCity; set { institutionCity = value; base.RaisePropertyChanged(); } }
    }
}