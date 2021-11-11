namespace MSSQL_Core_App.DTOs
{
    public class DeerWithClubsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ElvesOrdered { get; set; }
        public int ClubsCount { get; set; }

        public override string ToString()
        {
            return $"Id = {Id} Name = {Name} ElvesOrdered = {ElvesOrdered} ClubsCount = {ClubsCount}";
        }
    }
}
