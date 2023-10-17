using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{   
    public GameObject player;


    // Start is called before the first frame update


    // Update is called once per frame
    private void OnTriggerEnter(Collider other){
        if(other.gameObject == player){
            player.transform.parent = transform; 
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject == player){
            player.transform.parent = null;
        }
    }
}
