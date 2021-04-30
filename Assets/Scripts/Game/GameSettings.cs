using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSettings : MonoBehaviour
{
    public Text saniyeYazi;
    public float second,red;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        saniyeYazi.text = "" + (int)second;
        second -= Time.deltaTime;
        if (second <= 0)
        {
            gameAgain();
        }
        if (second<red)
        {
            saniyeYazi.color =Color.red;
        }
        else
        {
            saniyeYazi.color = Color.green;
        }
    }
    void gameAgain()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
