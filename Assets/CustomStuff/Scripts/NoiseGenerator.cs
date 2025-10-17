using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{

    public static float[,] Generate(int width, int height, float scale, Wave[] waves, Vector2 offset)
    {
        //Create the noise map
        float[,] noiseMap = new float[width, height];
        //Loop through each element in the noise map
        for (int x = 0; x < width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {
                //Calculate the  sample positions
                float samplePosX = (float)x * scale + offset.x;
                float samplePosY = (float)y * scale + offset.y;

                float normalization = 0.0f;

                //Loop through each wave
                foreach (Wave wave in waves)
                {
                    //Sample the perlin noise taking into consideration amplitude and frequency
                    noiseMap[x, y] += wave.amplitude * Mathf.PerlinNoise(samplePosX * wave.frequency + wave.seed, samplePosY * wave.frequency + wave.seed);
                    normalization += wave.amplitude;
                }
                //Normalize the value
                noiseMap[x, y] /= normalization;

            }
        }
        return noiseMap;
        
    }
    
}
public class Wave
{
    public float seed;
    public float frequency;
    public float amplitude;

}
