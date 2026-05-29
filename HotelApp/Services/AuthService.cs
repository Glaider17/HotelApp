using HotelApp.Data;
using HotelApp.Models;

namespace HotelApp.Services;

public class AuthService
{
    private readonly UserRepository _userRepo;
    private int _failedAttempts;
    private DateTime? _blockedUntil;

    public AuthService(UserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public User Login(string login, string password)
    {
        if (_blockedUntil.HasValue && DateTime.Now < _blockedUntil.Value)
            throw new InvalidOperationException("Вход временно заблокирован. Попробуйте через 30 секунд.");

        var user = _userRepo.FindByLogin(login);
        if (user == null || !PasswordHasher.Verify(password, user.PasswordSalt, user.PasswordHash))
        {
            RegisterFailure(login);
            throw new InvalidOperationException("Неверный логин или пароль.");
        }

        if (!user.IsActive)
        {
            RegisterFailure(login);
            throw new InvalidOperationException("Учётная запись деактивирована.");
        }

        _failedAttempts = 0;
        _blockedUntil = null;
        _userRepo.AddLoginAttempt(login, true, "Успешный вход");
        return user;
    }

    private void RegisterFailure(string login)
    {
        _failedAttempts++;
        _userRepo.AddLoginAttempt(login, false, "Неверный логин или пароль");
        if (_failedAttempts >= 3)
        {
            _blockedUntil = DateTime.Now.AddSeconds(30);
            _failedAttempts = 0;
        }
    }
}