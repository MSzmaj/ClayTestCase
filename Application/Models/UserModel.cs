using System.Text;
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
            userValidator.ValidateExistingUser(this);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"Id: {Id}, ");
            sb.Append($"FullName: {FullName}, ");
            sb.Append($"UserName: {UserName}, ");
            sb.Append($"Email: {Email}");

            return sb.ToString();
        }
    }
}
