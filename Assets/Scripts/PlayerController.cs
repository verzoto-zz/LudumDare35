using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    Rigidbody rbPlayer;
    public MeshFilter meshPlayer;
    public AudioSource som;

    int actualShape = 0;
    public Mesh[] meshes;

    void Start ()
    {
        rbPlayer = GetComponent<Rigidbody>();
        meshPlayer = GetComponent<MeshFilter>();
	}
	
	
	void Update ()
    {
        //Get the player movement Input
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 moveToPosition;
        
        //Move player
        moveToPosition = new Vector3(rbPlayer.position.x + horizontal, rbPlayer.position.y, rbPlayer.position.z);
        rbPlayer.MovePosition(Vector3.MoveTowards(rbPlayer.position, moveToPosition, 0.1f));


        //Get the player shift shape input
        if (Input.GetButtonDown("Fire1"))
        {
            ChangeForm();
            som.Play();
        }          

    }
    

    //This function is to change the shape of player object
    void ChangeForm()
    {

        if (actualShape == 2)
            actualShape = 0;

        else 
            actualShape++;

        meshPlayer.mesh = meshes[actualShape];

    }
        
}
