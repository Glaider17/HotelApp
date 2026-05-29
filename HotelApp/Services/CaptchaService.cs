namespace HotelApp.Services;

public class CaptchaService
{
    private readonly Random _random = new Random();
    private const string Alphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

    public string CurrentCode { get; private set; } = "";

    public string Generate()
    {
        CurrentCode = new string(Enumerable.Range(0, 5)
            .Select(_ => Alphabet[_random.Next(Alphabet.Length)])
            .ToArray());
        return CurrentCode;
    }

    public bool Validate(string input)
    {
        return string.Equals(CurrentCode, input?.Trim(), StringComparison.OrdinalIgnoreCase);
    }
}