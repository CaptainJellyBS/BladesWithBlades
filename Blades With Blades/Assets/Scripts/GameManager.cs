using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject normalGrass;
    public float minX, maxX, minZ, maxZ, offsetX, offsetZ;
    public GameObject[] evilGrasses;
    public float evilGrassSpawnDelayMin, evilGrassSpawnDelayMax;
    int score = 0;
    public int Score 
    { 
        get{ return score; }
        set{ score = value; MenuButtons.Instance.ScoreText = value.ToString(); }
    }

    public static GameManager Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnGrass();
        StartCoroutine(SpawnEvilGrass());
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnGrass()
    {
        for (float i = minX; i < maxX; i += offsetX)
        {
            for(float j = minZ; j < maxZ; j+=offsetZ)
            {
                Instantiate(normalGrass, new Vector3(i, 0, j), Quaternion.identity);
            }
        }
    }

    IEnumerator SpawnEvilGrass()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(evilGrassSpawnDelayMin, evilGrassSpawnDelayMax));
            Vector3 randomPos = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
            if(Vector3.Distance(randomPos, PlayerMovement.Instance.transform.position) < 5) { continue; }
            Instantiate(evilGrasses[Random.Range(0, evilGrasses.Length)], randomPos, Quaternion.identity);
        }
    }

    public void Die()
    {
        StopTime();
        MenuButtons.Instance.Die();
    }

    public void StopTime()
    {
        Time.timeScale = 0.0f;
    }

    public void StartTime()
    {
        Time.timeScale = 1.0f;
    }
}
