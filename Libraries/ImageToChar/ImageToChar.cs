namespace ImageToChar
{
    using SkiaSharp;
    using System.Text;

    public class ImageReader
    {
        public static string[] ToASCII(string url, char solidChar = '█')
        {
            // Gets bitmap from the image url
            SKBitmap bitmap = SKBitmap.Decode(url);
            string[] ascii = new string[bitmap.Height];

            for (int y = 0; y < bitmap.Height; y++)
            {
                StringBuilder sb = new StringBuilder(bitmap.Width);
                for (int x = 0; x < bitmap.Width; x++)
                {
                    if (bitmap.GetPixel(x, y).Alpha < 10)
                    {
                        sb.Append(' ');
                    }
                    else
                    {
                        sb.Append(solidChar);
                    }
                }
                ascii[y] = sb.ToString();
            }

            return ascii;
        }

        public static void GetImageInfo(string url)
        {
            // Check if everything is working
            Console.WriteLine("Hello from ImageToChar!");
            Console.WriteLine($"URL: {url}");
            Console.WriteLine("");
            
            SKBitmap bitmap = SKBitmap.Decode(url);
            int countTransparentPixels = 0;
            int countOpaquePixels = 0;
            int imageWidth = bitmap.Width;
            int imageHeight = bitmap.Height;

            for (int y = 0; y < imageHeight; y++)
            {
                for (int x = 0; x < imageWidth; x++)
                {
                    SKColor pixel = bitmap.GetPixel(x, y);
                    if (pixel.Alpha < 10)
                    {
                        countTransparentPixels++;
                    }
                    else
                    {
                        countOpaquePixels++;
                    }
                }
            }

            Console.WriteLine($"Image info:\n-Width: {imageWidth}\n-Height: {imageHeight}\n-Total Pixels: {imageWidth * imageHeight}\n-Transparent Pixels: {countTransparentPixels}\n-Opaque Pixels: {countOpaquePixels}");
            Console.WriteLine("");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
