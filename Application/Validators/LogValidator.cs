using Application.Models;
using Application.Validators.Interfaces;

namespace Application.Validators {
    public class LogValidator : ILogValidator {
        public string Validate (LogModel log) {
            return "test";
        }
    }
}