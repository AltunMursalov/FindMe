using Prism.Mvvm;

namespace FindMePrism.Models
{
    public class InstitutionType : BindableBase
    {
        private int id;
        private string type { get; set; }

        public int Id { get => id; set { id = value; base.RaisePropertyChanged(); } }
        public string Type { get => type; set { type = value; base.RaisePropertyChanged(); } }
    }
}
