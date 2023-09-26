using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedVariables : MonoBehaviour
{
    public static SharedVariables instance;
    public bool muteSound;
    public bool muteNarrator;
    public bool activeInfo;

    private SharedVariables()
    {
        muteSound = false;
        muteNarrator = false;
        activeInfo = false;
}

    public static SharedVariables Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new SharedVariables();
            }
            return instance;
        }
    }
}
