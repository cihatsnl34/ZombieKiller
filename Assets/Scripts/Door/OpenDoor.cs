using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenDoor : MonoBehaviour
{



   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Playera çarptım");
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }

}
