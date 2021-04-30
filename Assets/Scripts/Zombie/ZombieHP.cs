using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ZombieHP : MonoBehaviour
{
    public int startHp = 100;
    private int currentHp;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = startHp;
    }
    public int GetHealth()
    {
        return currentHp;
    }
  public void Hit(int damage)
    {

        currentHp -= damage;
        if (currentHp<0)
        {
            currentHp = 0;
            //TODO:Zombie Öldü
            Debug.Log("Zombi Öldü");
        }
        Debug.Log("Zombi Hasar Aldı "+ currentHp);
    }
}
