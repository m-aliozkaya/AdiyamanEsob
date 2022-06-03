using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace Core.Utilities.Images;

public static class ImageHelper
{
    private static async Task<byte[]> ToByteArray(Image image, ResizeOptions resizeOptions)
    {
        image.Mutate(x => x
            .Resize(resizeOptions));

        await using var memoryStream = new MemoryStream();
        await image.SaveAsync(memoryStream, new JpegEncoder()).ConfigureAwait(false);
        memoryStream.Position = 0;
        var result = memoryStream.ToArray();
        return result;
    }

    public static async void SaveImage(byte[] img, string path)
    {
        using var image = Image.Load(img);
        var resizeOptions = new ResizeOptions
        {
            Size = image.Size(),
            Sampler = KnownResamplers.Lanczos3,
            Compand = true,
            Mode = ResizeMode.Stretch
        };

        image.Mutate(x => x
            .Resize(resizeOptions));

        await using var fs = new FileStream(path, FileMode.Create);

        await image.SaveAsync(fs, new JpegEncoder()).ConfigureAwait(false);
    }

    public static async Task<byte[]> Crop(IFormFile img, int width, int height)
    {
        await using var rs = img.OpenReadStream();
        using var image = Image.Load(rs);
        var resizeOptions = new ResizeOptions
        {
            Size = new Size(width, height),
            Sampler = KnownResamplers.Lanczos3,
            Compand = true,
            Mode = ResizeMode.Crop
        };

        return await ToByteArray(image, resizeOptions);
    }

    public static async Task<byte[]> Resize(IFormFile img, int width)
    {
        await using var rs = img.OpenReadStream();
        using var image = Image.Load(rs);

        var resizeOptions = new ResizeOptions
        {
            Size = new Size(width, image.Height * (width / image.Width)),
            Sampler = KnownResamplers.Lanczos3,
            Compand = true,
            Mode = ResizeMode.Stretch
        };

        return await ToByteArray(image, resizeOptions);
    }

    public static async Task<byte[]> Resize(byte[] img, int width)
    {
        using var image = Image.Load(img);

        var resizeOptions = new ResizeOptions
        {
            Size = new Size(width, image.Height * (width / image.Width)),
            Sampler = KnownResamplers.Lanczos3,
            Compand = true,
            Mode = ResizeMode.Stretch
        };

        return await ToByteArray(image, resizeOptions);
    }
}