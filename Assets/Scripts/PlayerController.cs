using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    public Mesh form0;
    public Mesh form1;
    public Mesh form2;
    public Mesh form3;

    Rigidbody rbPlayer;
    public MeshFilter meshPlayer;
    public AudioSource som;

    int actualForm = 0;

    void Start ()
    {
        rbPlayer = GetComponent<Rigidbody>();
        meshPlayer = GetComponent<MeshFilter>();
        
	}
	
	
	void Update ()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 moveToPosition;
        
        moveToPosition = new Vector3(rbPlayer.position.x + horizontal, rbPlayer.position.y, rbPlayer.position.z);
        rbPlayer.MovePosition(Vector3.MoveTowards(rbPlayer.position, moveToPosition, 0.1f));


        if (Input.GetButtonDown("Fire1"))
        {
            ChangeForm();
            som.Play();
        }          

    }
    

    void ChangeForm()
    {
        if (actualForm == 0)
        {
            meshPlayer.mesh = form1;
            actualForm = 1;
        }


        else if (actualForm == 1)
        {
            meshPlayer.mesh = form2;
            actualForm = 2;
        }


        else if (actualForm == 2)
        {
            meshPlayer.mesh = form3;
            actualForm = 3;
        }

        else if (actualForm == 3)
        {
            meshPlayer.mesh = form0;
            actualForm = 0;
        }
    }
        
}
