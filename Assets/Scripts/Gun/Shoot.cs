using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int range;
    public Camera camera;
    [Header("Gun Damage On Hit")]
    public int damage;
    public GameObject bloodPrefabs;
    public GameObject decalPrefabs;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire();
        }
    }

    private void fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Zombie")
            {
                hit.transform.GetComponent<ZombieHP>().Hit(damage);
                GenerateBloodEffect(hit);
            }
            else
            {
                GeneratehitEffect(hit);  
            }
        }
    }

    private void GeneratehitEffect(RaycastHit hit)
    {
        GameObject hitObject = Instantiate(decalPrefabs, hit.point,Quaternion.identity);
        hitObject.transform.rotation = Quaternion.FromToRotation(decalPrefabs.transform.forward * -1, hit.normal);
    }

    private void GenerateBloodEffect(RaycastHit hit)
    {
        GameObject bloodObject = Instantiate(bloodPrefabs, hit.point, hit.transform.rotation);
        
    }
}
