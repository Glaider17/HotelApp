using HotelApp.Data;
using HotelApp.Forms;
using HotelApp.Services;

namespace HotelApp;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        DatabaseInitializer.Initialize();
        Application.Run(new LoginForm());
    }
}