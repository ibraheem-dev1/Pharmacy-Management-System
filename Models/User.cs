namespace PharmacyWinFormsApp.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int RoleID { get; set; }
        public bool IsActive { get; set; } = true;
        public string RoleName { get; set; } = string.Empty; // For display purposes
    }
}