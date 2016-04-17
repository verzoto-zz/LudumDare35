using UnityEngine;
using System.Collections;

public class GroundControl : MonoBehaviour {

    float _Speed = 0.5f;

    MeshRenderer _Render;

	// Use this for initialization
	void Start ()
    {
        _Render = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float _Offset = Time.time * _Speed;

        _Render.material.mainTextureOffset = new Vector2(0, -_Offset);
	}
}
