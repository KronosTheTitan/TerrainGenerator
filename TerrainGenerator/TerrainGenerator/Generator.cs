using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainGenerator;

using System.IO;

using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
class Generator
{
    Bitmap bmp;
    Mountain[] mountains =
    {
        new Mountain(0,0,64,1.5f),
        new Mountain(0,32,64,1.5f),
        new Mountain(16,48,35,.9f),
        new Mountain(64,64,64,1.5f)
    };
    public void GenerateTerrain()
    {
        bmp = new Bitmap(64,64);
        bmp.SetResolution(64, 64);
        int[,] px = new int[bmp.Width, bmp.Height];
        for(int x = 0; x < bmp.Width;x++)
        {
            for(int y = 0; y < bmp.Height; y++)
            {
                PixelBaseHeight(x, y);
            }
        }
        bmp.Save("Heightmap.bmp");
    }
    public void PixelBaseHeight(int x,int y)
    {
        int pixelHeight = 0;
        List<int> maxHeights = new List<int>();
        foreach(Mountain mountain in mountains)
        {
            Vector3 dist = new Vector3(x, y);
            dist -= mountain.position;
            maxHeights.Add((int)Mathf.Clamp(mountain.position.z - (dist.LengthXY() * mountain.slopeFactor), 0, 255));
        }
        foreach (int i in maxHeights)
            if (i > pixelHeight) pixelHeight = i;
        bmp.SetPixel(x, y, Color.FromArgb(255, pixelHeight, pixelHeight, pixelHeight));
    }
}
