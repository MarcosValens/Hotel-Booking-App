namespace HotelApp.Models
{
    public class AppConfigModel
    {
        public string DATA_TYPE { get; set; } = "FS"; // o "DB"
        public string? FS_FOLDER { get; set; }
        public string? DB_CONNECTION { get; set; }
    }
}
