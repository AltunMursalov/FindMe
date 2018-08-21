using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FindMeMobileClient.Models {
    public class Institution : BindableObject {
        private string _address;
        private string _number;
        private int _id;
        private int _cityId;
        private int _institutionTypeId;
        private string _name;
        private string _openingHours;
        private string _website;

        public int Id { get => _id; set { _id = value; base.OnPropertyChanged(); } }
        public int CityId { get => _cityId; set { _cityId = value; base.OnPropertyChanged(); } }
        public int InstitutionTypeId { get => _institutionTypeId; set { _institutionTypeId = value; base.OnPropertyChanged(); } }
        public string Name {
            get => _name; set { _name = value; base.OnPropertyChanged(); }
        }
        public string Address { get => _address; set { _address = value; base.OnPropertyChanged(); } }
        public string Number { get => _number; set { _number = value; base.OnPropertyChanged(); } }
        public string OpeningHours { get => _openingHours; set { _openingHours = value; base.OnPropertyChanged(); } }
        public string Website { get => _website; set {_website = value; base.OnPropertyChanged(); } }

        public InstitutionType InstitutionType { get; set; }
        public City City { get; set; }
    }
}
