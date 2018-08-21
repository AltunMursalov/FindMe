namespace ApplicationCore.DataTransferObjects
{
    public class InstitutionTypeDTO
    {
        public InstitutionTypeDTO(string type)
        {
            this.Type = type;
        }

        public string Type { get; set; }
    }
}