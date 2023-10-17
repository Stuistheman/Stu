using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSpot : MonoBehaviour
{
	public float threshold;
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < threshold){
	transform.position = new Vector3(-0.26f, 2.159f, -2.72f);
}
    }
}
