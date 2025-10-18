using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public BiomePreset[] biomes;
    public GameObject tilePrefab;

    [Header("Dimensions")]
    public int width = 50;
    public int height = 100;
    public float scale = 1.0f;
    public Vector2 offset;

    [Header("Height Map")]
    public Wave[] heightWaves;
    public float[,] heightMap;

    [Header("Moisture Map")]
    public Wave[] moistureWaves;
    public float[,] moistureMap;

    [Header("Heat Map")]
    public Wave[] heatWaves;
    public float[,] heatMap;

    void GenerateMap()
    {
        //Height Map
        heightMap = NoiseGenerator.Generate(width, height, scale, heightWaves, offset);
        //Moisture Map
        moistureMap = NoiseGenerator.Generate(width, height, scale, moistureWaves, offset);
        //Heat Map
        heatMap = NoiseGenerator.Generate(width, height, scale, heatWaves, offset);

        for (int x = 0; x < width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                tile.GetComponent<SpriteRenderer>().sprite = GetBiome(heightMap[x, y], moistureMap[x, y], heatMap[x, y]).GetTileSprite();
            }   //Fills the size of the map with sprites representing the biomes
        }
    }
    void Start()
    {
        GenerateMap();  //Temporary until UI functional
    }
    BiomePreset GetBiome(float height, float moisture, float heat)
    {
        BiomePreset biomeToReturn = null;
        List<BiomeTempData> biomeTemp = new List<BiomeTempData>();
        foreach (BiomePreset biome in biomes)   //Adds all biomes of a given type into a list.
        {
            if (biome.MatchCondition(height, moisture, heat))
            {
                biomeTemp.Add(new BiomeTempData(biome));
            }
        }   
        float curVal = 0.0f;
        foreach (BiomeTempData biome in biomeTemp)  //Finds the next biome with the lower amount of difference value from the current values
        {
            if (biomeToReturn == null)
            {
                biomeToReturn = biome.biome;
                curVal = biome.GetDiffValue(height, moisture, heat);
            }
            else
            {
                if (biome.GetDiffValue(height, moisture, heat) < curVal)
                {
                    biomeToReturn = biome.biome;
                    curVal = biome.GetDiffValue(height, moisture, heat);
                }
            }
        }
        if (biomeToReturn == null)
        {
            biomeToReturn = biomes[0];
        }
        return biomeToReturn;

    }
}
public class BiomeTempData  //Class to store the data from all the given biomes for easy access.
{
    public BiomePreset biome;
    public BiomeTempData(BiomePreset preset)
    {
        biome = preset;
    }
    public float GetDiffValue (float height, float moisture, float heat)
    {
        return (height - biome.minHeight) + (moisture - biome.minMoisture) + (heat - biome.minHeat);
    }
}
//Code taken from the Zenva Tutorial on 2D Procedural Generation