using Prism.Mvvm;
using System;

namespace FindMePrism.Models
{
    public class Institution : BindableBase, ICloneable
    {
        private int id;
        private string name;
        private string address;
        private string phone;
        private string login;
        private string password;
        private string openingHours;
        private string website;
        private City institutionCity;
        private bool isAdmin;
        private int institutionTypeId;
        private InstitutionType institutionType;
        private double latitude;
        private double longitude;
        private int cityId;

        public int Id { get => id; set { id = value; base.RaisePropertyChanged(); } }
        public int CityId { get => cityId; set { cityId = value; base.RaisePropertyChanged(); } }
        public int InstitutionTypeId { get => institutionTypeId; set { institutionTypeId = value; base.RaisePropertyChanged(); } }
        public string Password { get => password; set { password = value; base.RaisePropertyChanged(); } }
        public string Name { get => name; set { name = value; base.RaisePropertyChanged(); } }
        public string Address { get => address; set { address = value; base.RaisePropertyChanged(); } }
        public string Phone { get => phone; set { phone = value; base.RaisePropertyChanged(); } }
        public string Login { get => login; set { login = value; base.RaisePropertyChanged(); } }
        public string OpeningHours { get => openingHours; set { openingHours = value; base.RaisePropertyChanged(); } }
        public string Website { get => website; set { website = value; base.RaisePropertyChanged(); } }
        public bool IsAdmin { get => isAdmin; set { isAdmin = value; base.RaisePropertyChanged(); } }
        public InstitutionType InstitutionType { get => institutionType; set { institutionType = value; base.RaisePropertyChanged(); } }
        public City City { get => institutionCity; set { institutionCity = value; base.RaisePropertyChanged(); } }
        public double Latitude { get => latitude; set { latitude = value; base.RaisePropertyChanged(); } }
        public double Longitude { get => longitude; set { longitude = value; base.RaisePropertyChanged(); } }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}