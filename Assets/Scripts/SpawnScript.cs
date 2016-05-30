using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
    GameObject[] collectibles;

    public float itemSpeed = 0.1f;
    float spawnTime = 2f;
    float timeElapsed = 0;
    float minSpawnTime = 0.5f;

    // Use this for initialization
    void Start()
    {
        collectibles = Resources.LoadAll<GameObject>("Prefabs");

        //Spawn the first object
        RandomSpawn();
    }


    // Update is called once per frame
    void Update()
    {
        //Count time
        timeElapsed += Time.deltaTime;

        if (timeElapsed > spawnTime)
        {
            RandomSpawn();
            timeElapsed -= spawnTime;
        }
            
    }

    //This function spawn a object in game
    void RandomSpawn()
    {
        int prefab = Random.Range(0, collectibles.Length);
        int xPosition = Random.Range(-1, 2);

        GameObject nextObject = Instantiate(collectibles[prefab]) as GameObject;
        nextObject.transform.parent = this.transform;
        nextObject.transform.position = new Vector3(xPosition, nextObject.transform.position.y, nextObject.transform.position.z);
    }

    //This function adjust the difficulty, reducing the spawn time
    public void AdjustDifficulty()
    {
        if (spawnTime > minSpawnTime)
            spawnTime = spawnTime - 0.1f;       
    }

}
