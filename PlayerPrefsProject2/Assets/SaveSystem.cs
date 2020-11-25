using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem
{
    public GameObject[] Buttons;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("LvlNumber", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("LvlNumber") == 1)
        {
            Buttons[0].active = true;
            Buttons[1].active = false;
            Buttons[2].active = false;
        }

        if (PlayerPrefs.GetInt("LvlNumber") == 2)
        {
            Buttons[0].active = false;
            Buttons[1].active = true;
            Buttons[2].active = false;
        }
    }
}
