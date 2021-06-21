using Application.Models;
using Application.Validators.Interfaces;

namespace Application.Validators {
    public class UserValidator : IUserValidator {
        public string Validate (UserModel user) {
            return "test";
        }
    }
}