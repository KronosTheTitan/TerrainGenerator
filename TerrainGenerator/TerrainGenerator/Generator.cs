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
        new Mountain(0,0,64),
        new Mountain(0,32,64),
        new Mountain(16,48,35),
        new Mountain(128,128,64)
    };
    int[] pRidges =
    {
        0,1,
        1,2
    };
    public void GenerateTerrain()
    {
        bmp = new Bitmap(512,512);
        bmp.SetResolution(64, 64);

        GenerateRidges();

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
            maxHeights.Add((int)mountain.GetHeightEffect(x,y));
        }
        foreach (int i in maxHeights)
            if (i > pixelHeight) pixelHeight = i;
        bmp.SetPixel(x, y, Color.FromArgb(255, pixelHeight, pixelHeight, pixelHeight));
    }
    public void GenerateRidges()
    {
        for(int i = 0; i < pRidges.Length; i += 2)
        {
            MountainRidge ridge = new MountainRidge(mountains[pRidges[i]], mountains[pRidges[i+1]]);
        }
        foreach(Mountain mountain in mountains)
        {
            mountain.AddRidges();
        }
    }
}
