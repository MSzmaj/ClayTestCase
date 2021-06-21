using Application.Models;

namespace Application.Validators.Interfaces {
    public interface ITokenValidator {
       string Validate (TokenModel token); 
    }
}