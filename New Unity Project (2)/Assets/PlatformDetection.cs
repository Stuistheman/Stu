using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{   
    public GameObject player;
    private GameObject target;
    private Vector3 offset;

    // Start is called before the first frame update


    void Start(){
        target = null;
    }
    // Update is called once per frame
    private void OnTriggerStay(Collider other){
        target = other.gameObject;
	     offset = target.transform.position - transform.position;

    }

    private void OnTriggerExit(Collider other){
        target = null;
    }
    void LateUpdate(){
	if (target != null) {
		target.transform.position = transform.position+offset;
	}
}
}
