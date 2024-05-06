using Perfume.Models;

namespace Perfume.Services.Interfaces;

public interface IImageConvertorService
{
    Task<byte[]> ConvertFileFormToByteArrayAsync(IFormFile formFile);
    Task<ICollection<byte[]>> ConvertFileFormsToByteArraysAsync(ICollection<IFormFile> formFiles);
    Task<IFormFile> ConvertByteArrayToFileFormAsync(ImageDto input);
    Task<ICollection<IFormFile>>
        ConvertByteArraysToFileFormsAsync(ICollection<ImageDto>  inputS);
    Task<string> ConvertFormFileToImageAsync(IFormFile fileForm);
    Task <List<string>> ConvertFormFilesToImagesAsync(ICollection<IFormFile> formFiles);

}