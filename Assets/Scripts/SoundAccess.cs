using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAccess : MonoBehaviour
{
    // Start is called before the first frame update
    public void playClick()
    {
        if(!SharedVariables.Instance.muteSound)
            SoundScript.Instance.gameObject.GetComponents<AudioSource>()[1].Play();
    }

    public void playHover()
    {
        if (!SharedVariables.Instance.muteSound)
            SoundScript.Instance.gameObject.GetComponents<AudioSource>()[0].Play();
    }

    public void playClickSlider()
    {
        if (!SharedVariables.Instance.muteSound)
            SoundScript.Instance.gameObject.GetComponents<AudioSource>()[2].Play();
    }

}
