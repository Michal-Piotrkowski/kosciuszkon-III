using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using oodajze.backend.Models;

namespace oodajze.backend.Pages.Scan;
[IgnoreAntiforgeryToken]
public class ScanModel : PageModel
{
    private readonly AppDbContext _dbContext;

    public ScanModel(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public class BarcodeRequest
    {
        public List<string> Barcodes { get; set; }
    }
    public string GenerateUniqueQrCode()
    {
        return Guid.NewGuid().ToString();
    }
    [BindProperty]
    public List<string> Barcodes { get; set; }

    public async Task<IActionResult> OnPost([FromBody] BarcodeRequest request)
    {
        if (request?.Barcodes == null || request.Barcodes.Count == 0)
        {
            return BadRequest("Brak barcode'ów");
        }

        var qrId = await SaveBarcodesAndGenerateQr(request.Barcodes);
    
        return new JsonResult(new { 
            success = true, 
            redirectUrl = $"/Scan/Qr/{qrId}" 
        });
    }
    
    private async Task<string> SaveBarcodesAndGenerateQr(List<string> barcodes)
    {
        
        var products = _dbContext.ProductQrDatas
            .Where(p => barcodes.Contains(p.ProductCode))
            .ToList();
        var qrCode = GenerateUniqueQrCode();
        var collectionPoint = await _dbContext.CollectionPoints
            .FirstOrDefaultAsync(cp => cp.Id == 1);
        var visit = new CollectionVisitQrData
        {
            ScannedAt = DateTime.Now,
            Products = products,
            PointsEarned = products.Sum(p => p.Points),
            CollectionPoint = collectionPoint,
            QrCode = qrCode
           
        };

        await _dbContext.CollectionVisitQrData.AddAsync(visit);
        await _dbContext.SaveChangesAsync();
        
        var qrId = visit.QrCode;

        return qrId;
    }
}