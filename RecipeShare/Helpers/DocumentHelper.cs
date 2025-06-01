using RecipeShare.ViewModels;

namespace RecipeShare.Helpers
{
    public class DocumentHelper
    {
        public static DocumentViewModel SaveDocumentToMedia(IWebHostEnvironment hostingEnvironment, IFormFile document, string code, string fileType)
        {
            // Determine the path within the wwwroot folder to save the document
            string path = Path.Combine(hostingEnvironment.WebRootPath, "media", fileType, code);

            path = path.ToLower().Trim().Replace(" ", "-");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var fileExtension = Path.GetExtension(document.FileName);

            // Generate a unique file name to avoid overwriting existing files
            string fileName = Guid.NewGuid().ToString() + fileExtension;

            // Combine the folder path with the unique file name
            string filePath = Path.Combine(path, fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                document.CopyTo(fileStream);
            }

            // Create the relative path for the document view model
            string relativePath = Path.Combine("media", fileType, code, fileName).Replace(Path.DirectorySeparatorChar, '/');

            DocumentViewModel viewModel = new DocumentViewModel()
            {
                Document = "/" + relativePath.ToLower().Trim().Replace(" ", "-"),
            };

            return viewModel;
        }
    }
}
