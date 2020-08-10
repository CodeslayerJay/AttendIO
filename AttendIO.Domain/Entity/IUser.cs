namespace AttendIO.Domain.Entity
{
    public interface IUser
    {
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        bool IsActive { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        string Username { get; set; }
    }
}