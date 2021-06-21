using Application.Models;

namespace Application.Validators.Interfaces {
    public interface ILogValidator {
        string Validate (LogModel log);
    }
}