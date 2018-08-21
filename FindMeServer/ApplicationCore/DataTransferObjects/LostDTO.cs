using ApplicationCore.Models;
using System;

namespace ApplicationCore.DataTransferObjects
{
    public class LostDTO
    {
        public LostDTO(string firstName, string middleName, string clothes, BodyType bodyType, string eyeColor, string hairColor, 
            string signs, string lastName, int ageBegin, int ageEnd, int height, string imagePath, string comment, string description, 
            string detectionDescription, DateTime detectionTime, Gender gender, InstitutionDTO institution)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.Clothes = clothes;
            this.BodyType = bodyType;
            this.EyeColor = eyeColor;
            this.HairColor = hairColor;
            this.Signs = signs;
            this.LastName = lastName;
            this.AgeBegin = ageBegin;
            this.AgeEnd = ageEnd;
            this.Height = height;
            this.ImagePath = imagePath;
            this.Comment = comment;
            this.Description = description;
            this.DetectionDescription = detectionDescription;
            this.DetectionTime = detectionTime;
            this.Gender = gender;
            this.Institution = institution;
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Clothes { get; set; }
        public BodyType BodyType { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
        public string Signs { get; set; }
        public string LastName { get; set; }
        public int AgeBegin { get; set; }
        public int AgeEnd { get; set; }
        public int Height { get; set; }
        public string ImagePath { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public string DetectionDescription { get; set; }
        public DateTime DetectionTime { get; set; }
        public Gender Gender { get; set; }
        public InstitutionDTO Institution { get; set; }
    }
}