using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextVisible : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }
public GameObject textObject;

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            textObject.SetActive(true);
        }
        else
        {
            textObject.SetActive(false);
        }
    }
    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
