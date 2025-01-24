namespace WebCar.Application.Application.Models.Requests;

public record ImageRequest(string fileName, string filePath, string contentType, long fileSize)
{
}
