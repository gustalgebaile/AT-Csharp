using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;

namespace AT.Services
{
    public class CarregarImagem
    {
        public static async Task Start(IFormFile file, string caminhoArquivo)
        {
            var ms = new MemoryStream();
            await file.CopyToAsync(ms);

            ms.Position = 0;
            var img = await Image.LoadAsync(ms);

            var imagemEnc = new PngEncoder();
            img.SaveAsPng(ms, imagemEnc);

            ms.Position = 0;
            img = await Image.LoadAsync(ms);
            ms.Close();
            ms.Dispose();

            await img.SaveAsync(caminhoArquivo + ".png");
        }
    }
}