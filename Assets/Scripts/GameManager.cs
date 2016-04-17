using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score = 0;
    int combo = 0;
    int lifes = 3;

    SpawnScript sc;
    Material[] materials;

    public PlayerController player;
    public Text playerScore;
    public Text comboScore;

    public GameObject ground;
    public AudioSource som;
    
    void Start()
    {
        sc = GameObject.Find("Spawner").GetComponent<SpawnScript>();
        materials = Resources.LoadAll<Material>("Materials");
    }

    void Update()
    {
        if (lifes <= 0)
            EndGame();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Collectible")
        {
         
            Mesh collectibleMesh = coll.gameObject.GetComponent<MeshFilter>().mesh;

            if (player.meshPlayer.mesh.vertexCount == collectibleMesh.vertexCount)
            {
                score++;
                combo++;
                Destroy(coll.gameObject);
                RefreshScoreboard();
                RefreshCombo();
                som.Play();
                ChangeGroundColor();

                if (score%5 == 0)
                    sc.AdjustDifficulty();

                if (combo % 25 == 0)
                    AddLife();
                   
            }

        }
    }
    
    void RefreshScoreboard()
    {
        playerScore.text = score.ToString();
    }

    void RefreshCombo()
    {
        comboScore.text = combo.ToString();
    }

    void EndGame()
    {
        PlayerPrefs.SetInt("currentScore", score);
        StartCoroutine("WaitForEnd");
    }

    IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(3f);
        
    }

    public void RemoveLife()
    {
        lifes = lifes - 1;
        combo = 0;
        RefreshCombo();
    }

    void AddLife()
    {
        lifes = lifes + 1;
    }

    void ChangeGroundColor()
    {
        int color = Random.Range(0, materials.Length);
        ground.GetComponent<MeshRenderer>().material = materials[color];
    }

}
