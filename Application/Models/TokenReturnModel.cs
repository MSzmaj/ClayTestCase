using System.Text;

namespace Application.Models
{
    public class TokenReturnModel
    {
        public int TokenId { get; set; }
        public string Token { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"TokenId: {TokenId}, ");
            sb.Append($"Token: {Token}");

            return sb.ToString();
        }
    }
}
