using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMePrism.Models
{
    public class Lost : BindableBase
    {
        private int id;
        private string firstName;
        private string middleName;
        private string lastName;
        //private string fullName;
        private string eyeColor;
        private string hairColor;
        private string clothes;
        private string bodyType;
        private string signs;
        private string age;
        private int height;
        private string imagePath;
        private string comment;
        private string description;
        private string detectionDescription;
        private DateTime detectionTime;
        private string gender;
        private Institution institution;

        public int Id { get => id; set { id = value; base.RaisePropertyChanged(); } }
        public string FirstName { get => firstName; set { firstName = value; base.RaisePropertyChanged(); } }
        public string MiddleName { get => middleName; set { middleName = value; base.RaisePropertyChanged(); } }
        public string LastName { get => lastName; set { lastName = value; base.RaisePropertyChanged(); } }
        //public string FullName { get => fullName; set { fullName = value; base.RaisePropertyChanged(); } }
        public string EyeColor { get => eyeColor; set { eyeColor = value; base.RaisePropertyChanged(); } }
        public string HairColor { get => hairColor; set { hairColor = value; base.RaisePropertyChanged(); } }
        public string Clothes { get => clothes; set { clothes = value; base.RaisePropertyChanged(); } }
        public string BodyType { get => bodyType; set { bodyType = value; base.RaisePropertyChanged(); } }
        public string Signs { get => signs; set { signs = value; base.RaisePropertyChanged(); } }
        public string Age { get => age; set { age = value; base.RaisePropertyChanged(); } }
        public int Height { get => height; set { height = value; base.RaisePropertyChanged(); } }
        public string ImagePath { get => imagePath; set { imagePath = value; base.RaisePropertyChanged(); } }
        public string Comment { get => comment; set { comment = value; base.RaisePropertyChanged(); } }
        public string Description { get => description; set { description = value; base.RaisePropertyChanged(); } }
        public string DetectionDescription { get => detectionDescription; set { detectionDescription = value; base.RaisePropertyChanged(); } }
        public DateTime DetectionTime { get => detectionTime; set { detectionTime = value; base.RaisePropertyChanged(); } }
        public string Gender { get => gender; set { gender = value; base.RaisePropertyChanged(); } }
        public Institution Institution { get => institution; set { institution = value; base.RaisePropertyChanged(); } }

        public string FullName => string.Join(" ", FirstName, MiddleName, LastName);
    }
}
