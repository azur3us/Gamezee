namespace Gamezee.Domain.Abstraction.Authorization
{
    public interface IAuthResponse
    {
        public bool Result { get; set; }
        public string Token { get; set; }
    }
}
