using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
    GameObject[] collectibles;

    float spawnTime = 3f;
    public float itemSpeed = 0.1f;

    float timeElapsed = 0;
    int difficulty = 0;

    // Use this for initialization
    void Start()
    {
        collectibles = Resources.LoadAll<GameObject>("Prefabs");
        RandomSpawn();
    }


    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > spawnTime)
        {
            RandomSpawn();
            timeElapsed -= spawnTime;
        }
            
    }


    void RandomSpawn()
    {
        int prefab = Random.Range(0, collectibles.Length);
        int xPosition = Random.Range(-1, 2);

        GameObject nextObject = Instantiate(collectibles[prefab]) as GameObject;
        nextObject.transform.parent = this.transform;
        nextObject.transform.position = new Vector3(xPosition, nextObject.transform.position.y, nextObject.transform.position.z);
    }


    public void AdjustDifficulty()
    {
        itemSpeed += 0.05f;
        difficulty++;

        if (difficulty % 2 == 0)
            spawnTime -= 0.1f;       
    }

}
