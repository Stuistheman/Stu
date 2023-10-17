using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
   [SerializeField]
   private GameObject cube;
   private Renderer cubeRenderer;
   private Color newCubeColor;
   private float randomChannelOne, randomChannelTwo, randomChannelThree;

   void Start(){
    cubeRenderer = cube.GetComponent<Renderer>();
    gameObject.GetComponent<Button>().onClick.AddListener(ChangeCubeColor);
   }

   private void ChangeCubeColor(){
    randomChannelOne = Random.Range(0f, 1f);
    
    randomChannelTwo = Random.Range(0f, 1f);
    
    randomChannelThree = Random.Range(0f, 1f);

    newCubeColor = new Color(randomChannelOne, randomChannelTwo, randomChannelThree);
    cubeRenderer.material.SetColor("_Color", newCubeColor);
   }

}
