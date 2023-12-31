using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedVariables : MonoBehaviour
{
    public static SharedVariables instance;
    public bool activeInfo;
    public bool muteSound;
    public bool muteNarrator;
    public bool freshStarted;
 
    private SharedVariables()
    {
        muteSound = false;
        muteNarrator = false;
        activeInfo = true;
        freshStarted = true;
    }

    public void toggleSound()
    {
        muteSound = !muteSound;
    }
    
    public void toggleNarrator()
    {
        muteNarrator = !muteNarrator;
    }

    public void toggleInfo()
    {
        activeInfo = !activeInfo;
        if (freshStarted)
            freshStarted = !freshStarted;
    }

    public bool getNarrator()
    {
        return muteNarrator;
    }

    public bool getInfo()
    {
        return activeInfo;
    }



    public static SharedVariables Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
