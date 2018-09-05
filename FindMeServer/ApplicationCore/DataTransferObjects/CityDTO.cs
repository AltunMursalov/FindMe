namespace ApplicationCore.DataTransferObjects
{
    public class CityDTO
    {
        public CityDTO(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}