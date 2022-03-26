namespace Domain.Options
{
    public class PasswordOptions
    {
        public string Version { get; set; }

        public int SaltSize { get; set; }

        public int KeySize { get; set; }

        public int Iterations { get; set; }
    }
}
