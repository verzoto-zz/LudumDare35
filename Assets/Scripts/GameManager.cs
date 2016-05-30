using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score = 0;
    int lifes = 3;

    SpawnScript sc;
    Material[] materials;

    public PlayerController player;
    public Text playerScore;
    public Text playerLifes;
    public Text gameOver;

    public GameObject ground;
    public AudioSource som;
    
    void Start()
    {
        //Get SpawnScript
        sc = GameObject.Find("Spawner").GetComponent<SpawnScript>();

        //Put materials inside Resources/Materials in Array
        materials = Resources.LoadAll<Material>("Materials");

        //Initiate player Lifes
        RefreshPlayerLifes();
    }

    void Update()
    {
        //If the player lose all of your lifes, then the game ends
        if (lifes <= 0)
            EndGame();
    }


    void OnTriggerEnter(Collider coll)
    {
        //Check if the object collided is a collectible
        if (coll.gameObject.tag == "Collectible")
        {
            
            //Get the mesh of collectible
            Mesh collectibleMesh = coll.gameObject.GetComponent<MeshFilter>().mesh;

            //Check if the player and the collectible have the same mesh
            if (player.meshPlayer.mesh.vertexCount == collectibleMesh.vertexCount)
            {
                
                score++; //Add a score
                Destroy(coll.gameObject); //Destroy the Object collided
                                
                RefreshScoreboard();
                som.Play();
                ChangeGroundColor();

                if (score%5 == 0)
                    sc.AdjustDifficulty();
                   
            }

        }
    }
    
    //This function update the Score UI
    void RefreshScoreboard()
    {
        playerScore.text = score.ToString();
    }

    //This function update Player Life UI
    void RefreshPlayerLifes()
    {
        playerLifes.text = lifes.ToString();
    }


    //This function set the Game Over
    void EndGame()
    {
        //Enable the Game Over UI
        gameOver.enabled = true;

        //Set the player score
        PlayerPrefs.SetInt("currentScore", score);

        StartCoroutine("WaitForEnd");
    }

    //This function wait and load the Endgame Scene
    IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Endgame");
    }

    //This function is to remove one life of the player
    public void RemoveLife()
    {
        if (lifes >= 0)
        {
            lifes = lifes - 1;
            RefreshPlayerLifes();
        }
        
    }

    //This function is to change the ground color
    void ChangeGroundColor()
    {
        int color = Random.Range(0, materials.Length);
        ground.GetComponent<MeshRenderer>().material = materials[color];
    }



}
