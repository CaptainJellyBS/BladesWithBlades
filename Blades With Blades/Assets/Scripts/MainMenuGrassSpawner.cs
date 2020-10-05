using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGrassSpawner : MonoBehaviour
{

    public GameObject normalGrass;
    public float minX, maxX, minZ, maxZ, offsetX, offsetZ;
    // Start is called before the first frame update
    void Start()
    {
        SpawnGrass();
    }

    void SpawnGrass()
    {
        for (float i = minX; i < maxX; i += offsetX)
        {
            for (float j = minZ; j < maxZ; j += offsetZ)
            {
                Instantiate(normalGrass, new Vector3(i, 0, j), Quaternion.identity);
            }
        }
    }
}
