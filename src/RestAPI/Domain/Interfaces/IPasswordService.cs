namespace Domain.Interfaces
{
    public interface IPasswordService
    {
        bool CheckPass(string saved, string validate);
        string HashingPass(string pass);
    }
}