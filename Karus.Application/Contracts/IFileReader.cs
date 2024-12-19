namespace Karus.Application.Contracts;

public interface IFileReader
{
    Task<string?> ReadWebroothPathFileAsync(params string[] pathSegments);
}
