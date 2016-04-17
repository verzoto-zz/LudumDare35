using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {
   
    Rigidbody rbItem;
    SpawnScript sc;

	// Use this for initialization
	void Start ()
    {
        rbItem = GetComponent<Rigidbody>();
        sc = GameObject.Find("Spawner").GetComponent<SpawnScript>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        rbItem.transform.Translate(0, 0, -sc.itemSpeed);
	}


}
