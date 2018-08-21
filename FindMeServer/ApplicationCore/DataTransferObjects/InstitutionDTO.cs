namespace ApplicationCore.DataTransferObjects
{
    public class InstitutionDTO
    {
        public InstitutionDTO(string name, string address, string phone, string openingHours, 
                                string website, bool isAdmin, InstitutionTypeDTO institutionType, CityDTO city)
        {
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.OpeningHours = openingHours;
            this.Website = website;
            this.IsAdmin = isAdmin;
            this.InstitutionType = institutionType;
            this.City = city;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string OpeningHours { get; set; }
        public string Website { get; set; }
        public bool IsAdmin { get; set; }
        public InstitutionTypeDTO InstitutionType { get; set; }
        public CityDTO City { get; set; }
    }
}