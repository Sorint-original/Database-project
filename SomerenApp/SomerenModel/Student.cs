using System;

namespace SomerenModel
{
    public class Student
    {
        public int StudentNumber { get; set; }     // database id
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; } // Thelephone number
        public string Class {  get; set; }
        public int RoomCode {  get; set; }
    }
}