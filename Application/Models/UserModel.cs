using Application.Validators.Interfaces;

namespace Application.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public virtual void Validate(IUserValidator userValidator) {
            
        }
    }
}
