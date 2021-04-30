using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHealth : MonoBehaviour
{
    HpPlayer hpPlayer;
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        hpPlayer = GetComponent<HpPlayer>();
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward, out hit,10))
        {
            if (hit.transform.tag=="Apple")
            {
                Debug.Log("Elma Görüldü");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            hpPlayer.AddHealth(10);
            other.gameObject.SetActive(false);
            Debug.Log("10 can eklendi Şuan ki Can :" + hpPlayer.GetHealth());
        }
    }
}
