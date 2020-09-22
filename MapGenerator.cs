using System.Collections;
using UnityEngine;

//MapGenerator Class will be used to store and control all of the variables for the map
public class MapGenerator : MonoBehaviour
{
    public enum DrawMode {ElevationNoiseMap, BasicColorMap};
    public DrawMode drawMode;

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;
    public float lacunarity;
    [Range(0,1)]
    public float persistence;

    public int seed;
    public Vector2 offset;

    public bool autoUpdate;

    public TerrainType[] biomes;

    //This method will process the Noise Map to turn it into the Terrain Map
    public void GenerateMap()
    {
        float[,] elevationMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistence, lacunarity, offset);

        Color[] colorMap = new Color[mapWidth * mapHeight];

        //These for loops assign the colors to biomes based on elevation
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float currentHeight = elevationMap[x, y];
                for (int i = 0; i < biomes.Length; i++)
                {
                    if (currentHeight <= biomes[i].elevation)
                    {
                        colorMap[y * mapWidth + x] = biomes[i].color;
                        break;
                    }
                }
            }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>();
        if (drawMode == DrawMode.ElevationNoiseMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromElevationMap(elevationMap));
        }
        else if (drawMode == DrawMode.BasicColorMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromColorMap(colorMap, mapWidth, mapHeight));
        }
    }

    private void OnValidate()
    {
        if (mapWidth < 1)
        {
            mapWidth = 1;
        }
        if (mapHeight < 1)
        {
            mapHeight = 1;
        }
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }
        if (octaves < 0)
        {
            octaves = 0;
        }
    }
}

[System.Serializable]
public struct TerrainType
{
    public string terrainName;
    public float elevation;
    public Color color;
}