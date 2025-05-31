using Microsoft.AspNetCore.Mvc.RazorPages;
using QRCoder;

public class ScanQrModel : PageModel
{
    public string QrCodeSvg { get; set; }

    public void OnGet(string qrId)
    {
        if (string.IsNullOrEmpty(qrId))
        {
            QrCodeSvg = null;
            return;
        }

        QrCodeSvg = GenerateQrSvg(qrId);
    }

    private string GenerateQrSvg(string content)
    {
        var generator = new QRCodeGenerator();
        var data = generator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
        var svgQr = new SvgQRCode(data);
        return svgQr.GetGraphic(5);  
    }
}