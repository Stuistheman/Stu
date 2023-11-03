using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void OpenLevel(int lvlId)
    {
        string lvlname = "Level" + lvlId;

        SceneManager.LoadScene(lvlname);

    }

    // Update is called once per frame
   
}
