using Application.Validators.Interfaces;

namespace Application.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public int FullName { get; set; }
        public int UserName { get; set; }
        public int Email { get; set; }

        public virtual void Validate(IUserValidator userValidator) {
            
        }
    }
}
