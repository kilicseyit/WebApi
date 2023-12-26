using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync(IFormFile  formData)
        { 
            if (formData != null)
            {
                try
                {
                    // Veriyi JSON formatında metin dosyasına kaydetme
                    string json = JsonSerializer.Serialize(formData);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "FormData.txt");
                    await System.IO.File.WriteAllTextAsync(filePath, json);

                    return Ok("Veri başarıyla kaydedildi.");
                }
                catch (Exception ex)
                {
                    return BadRequest("Hata oluştu: " + ex.Message);
                }
            }
            else
            {
                return BadRequest("Geçersiz veri.");
            }
        }
    }

    public class FormData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Diğer veri alanlarını buraya ekleyebilirsiniz.
    }
}
