﻿namespace DataTransfer.Users
{
    public class UserDto : BaseDto<int>
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
