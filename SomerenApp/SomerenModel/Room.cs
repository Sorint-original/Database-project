namespace SomerenModel
{
    public class Room
    {
        public int RoomCode { get; set; }         // database id
        public int RoomNumber { get; set; } // Room number like 226
        public int Floor { get; set; }     // The floor 
        public string Building { get; set; } // Building A or B
        public int NumberBeds { get; set; }   // number of beds, either 4, 6, 8, 12 or 16
        public bool RoomType { get; set; }      // student = false, teacher = true
    }
}