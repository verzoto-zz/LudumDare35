using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour
{
    GameManager game;
    public AudioSource som;

    void Start()
    {
        game = GameObject.Find("Player").GetComponent<GameManager>();
    }


    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Collectible")
        {
            som.Play();
            Destroy(coll.gameObject);
            game.RemoveLife();
        }
    }

}
