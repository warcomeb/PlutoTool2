namespace PlutoTool.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public int? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? NIN { get; set; }
        public bool Active { get; set; }
        public DateOnly? Birthday { get; set; }
        public string? Note { get; set; }
        public OrganizationRole OrganizationRoleType { get; set; }
        public SystemRole SystemRoleType { get; set; }

        public enum OrganizationRole
        {
            ADMIN,
            EDITOR,
            VISUALIZER
        }

        public enum SystemRole
        {
            ADMIN,
            USER
        }
    }
}