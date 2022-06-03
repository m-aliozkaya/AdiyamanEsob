using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Files;

public static class FileHelper
{
    private const string UploadPath = "wwwroot/upload/";
    
    public static async Task<IResult> UploadFileAsync(IFormFile file, string path)
    {
        if (file == null || file.Length == 0)  
            return new ErrorResult("Dosya seçilmedi");
  
        var filePath = Path.Combine(  
            Directory.GetCurrentDirectory(), UploadPath,
            path, file.FileName);

        var fileInfo = new FileInfo(filePath);

        if (fileInfo.Directory is { Exists: false })
        {
            fileInfo.Directory.Create();
        }

        await using var stream = fileInfo.Create();
        await file.CopyToAsync(stream);

        return new SuccessResult();
    }

    public static async Task<IResult> UpdateFileAsync(IFormFile file, string path, string oldPath)
    {
        DeleteFile(path, oldPath);

        return await UploadFileAsync(file, path);
    }

    public static void DeleteFile(string path, string oldPath)
    {
        if (string.IsNullOrEmpty(oldPath)) return;
        
        FileInfo deletedFile = new(Path.Combine(
            Directory.GetCurrentDirectory(), UploadPath,
            path, oldPath));

        if (deletedFile.Exists)
        {
            deletedFile.Delete();
        }
    }
}