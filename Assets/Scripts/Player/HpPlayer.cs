using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;

public class HpPlayer : MonoBehaviour
{
    public int MaxHp=100;
    public int currentHp;
   
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = MaxHp;
        //healthBar = GetComponent<HealthBar>();
        //healthBar.SetmaxHealth(MaxHp);
            
    }
    public void deductHealth(int damage) {
        currentHp -= damage;
          Debug.Log("Player Hasar Aldı : " + currentHp);
        healthBar.SetHealth(currentHp);
        if (currentHp<=0)
        {
            currentHp = 0;
            Debug.Log("Player Öldü");
            Application.LoadLevel(Application.loadedLevel);
        }

      
    }
    
    public void AddHealth(int value) {
        currentHp += value;
        if (currentHp>MaxHp)
        {
            currentHp = MaxHp;
        }
    }
   
public int GetHealth() {
        return currentHp;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
