using Prism.Mvvm;
using System;

namespace FindMePrism.Models
{
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Unknown = 3
    }

    public enum BodyType
    {
        Thin = 1,
        Fat = 2,
        Medium = 3
    }

    public class Lost : BindableBase, ICloneable
    {
        private int id;
        private string firstName;
        private string middleName;
        private string lastName;
        private string eyeColor;
        private string hairColor;
        private string clothes;
        private BodyType bodyType;
        private string signs;
        private int? ageBegin;
        private int? ageEnd;
        private int? height;
        private string imagePath;
        private string comment;
        private string description;
        private string detectionDescription;
        private DateTime detectionTime;
        private Gender gender;
        private Institution institution;
        private int institutionId;
        private bool isFound;

        public int Id { get => id; set { id = value; base.RaisePropertyChanged(); } }
        public string FirstName { get => firstName; set { firstName = value; base.RaisePropertyChanged(); } }
        public string MiddleName { get => middleName; set { middleName = value; base.RaisePropertyChanged(); } }
        public string Clothes { get => clothes; set { clothes = value; base.RaisePropertyChanged(); } }
        public BodyType BodyType { get => bodyType; set { bodyType = value; base.RaisePropertyChanged(); } }
        public string EyeColor { get => eyeColor; set { eyeColor = value; base.RaisePropertyChanged(); } }
        public string HairColor { get => hairColor; set { hairColor = value; base.RaisePropertyChanged(); } }
        public string Signs { get => signs; set { signs = value; base.RaisePropertyChanged(); } }
        public string LastName { get => lastName; set { lastName = value; base.RaisePropertyChanged(); } }
        public int? AgeBegin { get => ageBegin; set { ageBegin = value; base.RaisePropertyChanged(); } }
        public int? AgeEnd { get => ageEnd; set { ageEnd = value; base.RaisePropertyChanged(); } }
        public int? Height { get => height; set { height = value; base.RaisePropertyChanged(); } }
        public string ImagePath { get => imagePath; set { imagePath = value; base.RaisePropertyChanged(); } }
        public string Comment { get => comment; set { comment = value; base.RaisePropertyChanged(); } }
        public string Description { get => description; set { description = value; base.RaisePropertyChanged(); } }
        public string DetectionDescription { get => detectionDescription; set { detectionDescription = value; base.RaisePropertyChanged(); } }
        public DateTime DetectionTime { get => detectionTime; set { detectionTime = value; base.RaisePropertyChanged(); } }
        public Gender Gender { get => gender; set { gender = value; base.RaisePropertyChanged(); } }
        public Institution Institution { get => institution; set { institution = value; base.RaisePropertyChanged(); } }
        public int InstitutionId { get => institutionId; set { institutionId = value; base.RaisePropertyChanged(); } }
        public bool IsFound { get => isFound; set { isFound = value; base.RaisePropertyChanged(); } }

        public string FullName => string.Join(" ", FirstName, MiddleName, LastName);
        public string Age => string.Join(" - ", AgeBegin, AgeEnd);

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
