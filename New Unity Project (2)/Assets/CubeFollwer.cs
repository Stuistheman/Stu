using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFollwer : MonoBehaviour
{
     public GameObject CubeToFollow;
     public GameObject thisCube;
     private Vector3 Repos;
     private Quaternion ReposR;
    // Start is called before the first frame update
    void Start()
    {
        Repos = CubeToFollow.transform.position; 
        ReposR = CubeToFollow.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
        Repos = CubeToFollow.transform.position;
        ReposR = CubeToFollow.transform.rotation;
        transform.position = Repos;
        transform.rotation = ReposR;
    }
}
