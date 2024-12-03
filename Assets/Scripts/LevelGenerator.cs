using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject springPrefab;
    public GameObject superSpringPrefab;
    public GameObject slowerPrefab;

    public int NumberOfPlatforms;
    public int NumberOfSprings;
    public int NumberOfSuperSprings;
    public int NumberOfSlower;

    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < NumberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(Randomizer(), spawnPosition, Quaternion.identity);
        }
    }

    GameObject Randomizer()
    {
        int r = Random.Range(0, 100);        
        if (r > 1 && r < 3)
        {
            Debug.Log(r);
            if (NumberOfSuperSprings > 0)
            {                
                NumberOfSuperSprings--;
                return superSpringPrefab;
            }
            else
            {
                return platformPrefab;
            }            
        }
        else if (r > 10 && r < 15)
        {
            Debug.Log(r);
            if (NumberOfSprings > 0)
            {
                NumberOfSprings--;
                return springPrefab;
            }
            else
            {
                return platformPrefab;
            }
        }
        else if (r > 56 && r < 61)
        {
            Debug.Log(r);
            if (NumberOfSlower > 0)
            {
                NumberOfSlower--;
                return slowerPrefab;
            }
            else
            {
                return platformPrefab;
            }
        }
        else
        {
            Debug.Log(r);
            return platformPrefab;
        }
    }
}
