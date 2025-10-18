using UnityEngine;

[CreateAssetMenu(fileName = "Biome Preset", menuName = "New Biome Preset")]
public class BiomePreset : ScriptableObject
{   //Script for creating new Biome types in the Unity Project
    public Sprite[] tiles;
    public float minHeight;
    public float minMoisture;
    public float minHeat;
    public Sprite GetTileSprite()   //Gets the tiles for a given biome at random
    {
        return tiles[Random.Range(0, tiles.Length)];
    }
    public bool MatchCondition(float height, float moisture, float heat) //Checks if the properties of selected biome meets the requirements.
    {
        return height >= minHeight && moisture >= minMoisture && heat >= minHeat;
    }
}
//Code taken from the Zenva tutorial on 2D Procedural Generation