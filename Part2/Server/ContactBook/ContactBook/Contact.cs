﻿namespace ContactBook
{
    public class Contact
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string MiddleName { get; set; }

        public string? Email { get; set; }
    }
}
