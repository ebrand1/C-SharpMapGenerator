using System.Collections;
using UnityEngine;

public static class TextureGenerator
{
    public static Texture2D TextureFromColorMap(Color[] colorMap, int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colorMap);
        texture.Apply();
        return texture;
    }

    public static Texture2D TextureFromElevationMap(float[,] elevationMap)
    {
        int width = elevationMap.GetLength(0);
        int height = elevationMap.GetLength(1);

        Color[] colorMap = new Color[width * height];

        //These for loops will convert the 2D noise map array into a 1D color map array
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, elevationMap[x, y]);
            }
        }
        return TextureFromColorMap(colorMap, width, height);
    }
}
