using System.ComponentModel.DataAnnotations;

namespace disprz.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string PasswordHash { get; set; }
        public UserTypeEnum UserType { get; set; } = UserTypeEnum.Default;
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }

    public enum UserTypeEnum
    {
        [Display(Name = "Default")]
        Default = 0,
        [Display(Name = "Corporate")]
        Corporate = 1,
        [Display(Name = "Consultant")]
        Consultant = 2,
        [Display(Name = "Freelancer")]
        Freelancer = 3
    }
}
