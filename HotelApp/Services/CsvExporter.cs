using HotelApp.Data;
using System.Text;
using System.Windows.Forms;

namespace HotelApp.Services;

public static class CsvExporter
{
    public static void ExportToCsv<T>(IEnumerable<T> data, string fileName, string userLogin, ActionLogRepository logRepo)
    {
        var props = typeof(T).GetProperties();
        var sb = new StringBuilder();
        sb.AppendLine(string.Join(";", props.Select(p => p.Name)));

        foreach (var item in data)
        {
            var values = props.Select(p => p.GetValue(item)?.ToString()?.Replace(";", ",") ?? "");
            sb.AppendLine(string.Join(";", values));
        }

        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
        File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        logRepo.Log(userLogin, "EXPORT", typeof(T).Name, "All", $"Экспорт в CSV: {path}");
        MessageBox.Show($"Экспорт завершён. Файл сохранён: {path}", "Экспорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}