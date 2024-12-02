using Microsoft.AspNetCore.Mvc;

namespace Base64ToPDFWebApp
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadBase64(string base64String)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64String);

                // Assuming the file will be saved as "output.pdf"
                string outputPath = "output.pdf";

                // Write the bytes to a PDF file
                System.IO.File.WriteAllBytes(outputPath, bytes);

                // Set success message
                TempData["SuccessMessage"] = "PDF file has been successfully processed.";
            }
            catch (Exception ex)
            {
                // Set error message
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
            }

            // Redirect back to Index page
            return RedirectToAction("Index");
        }
    }
}
