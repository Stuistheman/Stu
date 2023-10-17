using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 10.0f;
    public float rotationSpeed = 200.0f;
	public bool isgrounded = true;
    public GameObject Sprinttrail; 
    public GameObject Dashtrail; 
    public GameObject cube;
    private Renderer cubeRenderer;
   private Color newCubeColor;
    public bool sprintUn;
    public GameObject pause; 
    private bool pauseStat = false;
    public GameObject powerUpText; 
    

    private float dashCool = 1f;
    public float dashCoolCurrent = 0.0f;
    public bool dashReady = false;


    private bool dashUnlock; 
    public Slider dashSlider;

    // Start is called before the first frame update
    void Start()
    {
        cubeRenderer = cube.GetComponent<Renderer>();
        Dashtrail.SetActive(false);
        dashUnlock = false;
        sprintUn = false; 
        pause.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        

		 float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
         

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);
if(Input.GetButtonDown("Jump") && isgrounded == true){
		GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
        cube.transform.Rotate(0, 0, 360, Space.World);
        isgrounded= false;

	}
    if(Input.GetKey(KeyCode.LeftShift) && sprintUn == true){
        speed = 20.0f;
        Sprinttrail.SetActive(true);

    }
    else{
        speed = 10.0f;
        Sprinttrail.SetActive(false);
    }


        
        if(dashReady == true && dashUnlock == true){
            
            if(Input.GetButtonDown("dash") && dashUnlock == true && dashReady == true){
           Dashtrail.SetActive(true);
            newCubeColor = new Color(0.1f, 0.1f, 0.1f);
            cubeRenderer.material.SetColor("_Color", newCubeColor);
            dashCoolCurrent += Time.deltaTime;


            CooldownStart();

        cube.transform.Translate(translation,0,10);
        
        }
        }
        else{
            dashReady = false;
            
        }

        dashSlider.value = dashCoolCurrent/dashCool;

        if(Input.GetButtonDown("pause")){
            PauseToggle(pause);
        }



}
void PauseToggle(GameObject pause){
    if(Time.timeScale > 0){
        Time.timeScale = 0;
        pause.SetActive(true);
}
else if(Time.timeScale == 0){
    Time.timeScale = 1;
    pause.SetActive(false);
}

}


void OnCollisionEnter(Collision theCollision){
    if(theCollision.gameObject.tag == "floor" || theCollision.gameObject.tag == "MovingPlatform"){
        isgrounded = true;
    }
    else
    {
        isgrounded = false;
    }
    if(theCollision.gameObject.tag == "Bounce"){
       GetComponent<Rigidbody>().velocity = new Vector3(0, 20, 0); 
    }
    if(theCollision.gameObject.tag == "DashPower" && dashUnlock == false){
        dashUnlock = true;
        powerUpText.SetActive(true); 
        Time.timeScale = 0;
        dashReady = true;
    }
    if(theCollision.gameObject.tag == "SprintPower"){
        sprintUn = true;
    }
}
public void CooldownStart(){
    StartCoroutine(CooldownCoroutine(dashCool));

   
}
IEnumerator CooldownCoroutine(float cd){
    dashReady = false;
    yield return new WaitForSeconds(cd);
    dashReady = true;
    Dashtrail.SetActive(false);
      newCubeColor = new Color(1f, 0.25f, 0.25f);
            cubeRenderer.material.SetColor("_Color", newCubeColor);
    dashSlider.value = 0;
    
}

        
// // 	if(Input.GetButtonDown("up")){
// // 		GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5);
// // 	}
// if(Input.GetButtonDown("Horizontal")){
// 		GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);
// 	}
// if(Input.GetButtonDown("Horizontal")){
// 		GetComponent<Rigidbody>().velocity = new Vector3(-5, 0, 0);
// 	}
// // if(Input.OnKeyDown("down")){
// // 		GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);
// // 	}
}