using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopUpButton : MonoBehaviour
{
       [SerializeField]
       public GameObject textBoxxx;

    // Start is called before the first frame update
    void Start()
    {
             gameObject.GetComponent<Button>().onClick.AddListener(Unfreeze);

    }

    void Unfreeze(){
        Time.timeScale = 1;
        textBoxxx.SetActive(false);
    }
}
