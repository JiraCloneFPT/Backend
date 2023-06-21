namespace be.DTOs
{
    public class UserUpdateInfor
    {
        public UserUpdateInfor()
        {

        }
        public int UserId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public string Status { get; set; }
    }
}
