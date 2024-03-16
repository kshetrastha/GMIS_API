namespace gmis.Infrastructure.Helper.HelperRepository
{
    //public class FileHelper : IFileHelper
    //{
    //    private readonly IWebHostEnvironment _webHostEnvironment;
    //    public FileHelper(IWebHostEnvironment webHostEnvironment)
    //    {
    //        _webHostEnvironment = webHostEnvironment;
    //    }

    //    public async Task<List<Guid>> UploadMultipleFiles(string destination, List<IFormFile> files,
    //        IFileHelper.MyFunctionDelegate createInDatabase)
    //    {
    //        var response = new List<Guid>();
    //        foreach (var file in files)
    //        {
    //            response.Add(await UploadSingleFiles(destination, file, createInDatabase));
    //        }
    //        return response;
    //    }

    //    public async Task<Guid> UploadSingleFiles(string destination, IFormFile file,
    //        IFileHelper.MyFunctionDelegate createInDatabase)
    //    {
    //        try
    //        {
    //            if (file != null && file.Length > 0)
    //            {
    //                var fileId = Guid.NewGuid();
    //                string saveFile = $"{fileId + Path.GetExtension(file.FileName)}";
    //                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", destination);
    //                if (!Directory.Exists(filePath))
    //                    Directory.CreateDirectory(filePath);
    //                string savedFilePath = Path.Combine(filePath, saveFile);
    //                if (await UploadedFile(file, savedFilePath))
    //                {
    //                    return await createInDatabase(new FileDetail
    //                    {
    //                        OriginalName = file.FileName,
    //                        FileURL = destination + "/" + saveFile,
    //                        ContentType = file.ContentType,
    //                        FileName = saveFile
    //                    });
    //                }
    //                return new Guid();
    //            }
    //            else
    //                return new Guid();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }
    //    private async Task<bool> UploadedFile(IFormFile file, string folder)
    //    {
    //        try
    //        {
    //            using var fileStream = new FileStream(folder, FileMode.Create);
    //            await file.CopyToAsync(fileStream);
    //            return true;
    //        }
    //        catch (Exception)
    //        {
    //            return false;
    //        }
    //    }
    //}
}
