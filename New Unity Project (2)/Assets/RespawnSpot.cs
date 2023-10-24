using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSpot : MonoBehaviour
{
	public float threshold;
    public Vector3 repos; 

    public int relocation; 
    // Update is called once per frame
void Start(){
    repos = new Vector3(-0.26f, 2.159f, 2.72f);
}
    void Update()
    {
        if(transform.position.y < threshold){
	transform.position = repos;
}


    }
    void OnCollisionEnter(Collision theCollision){

        if(theCollision.gameObject.tag == "Respawn"){
            repos = theCollision.gameObject.transform.position;
        }
        if(theCollision.gameObject.tag == "death"){
            transform.position = repos;
        }
    }
}
