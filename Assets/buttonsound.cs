using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class buttonsound : MonoBehaviour { 

    public GameObject vbBtnObj;
    public AudioSource soundTarget;
    public AudioClip clipTarget;
    private AudioSource[] allAudioSources;

    VirtualButtonBehaviour[] virtualButtonBehaviours;
    // Use this for initialization
    //function to stop all sounds
    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    //function to play sound
    void playSound(string ss)
    {
        clipTarget = (AudioClip)Resources.Load(ss);
        soundTarget.clip = clipTarget;
        soundTarget.loop = false; 
        soundTarget.playOnAwake = false;
        soundTarget.Play();
        Debug.Log(ss);
    }
    void Start()
    {
        soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0;i< virtualButtonBehaviours.Length; i++)
        {
            virtualButtonBehaviours[i].GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
            virtualButtonBehaviours[i].GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
        }
        vbBtnObj = GameObject.Find("c_button"); 
       // audioSource = GetComponent<AudioSource>();
        Debug.Log(vbBtnObj);
      //  vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
   // vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
}
    void Update()
    {
         
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
   
 
        Debug.Log(vb.name + "Button pressed");
        switch (vb.name)
        {
            case "c_button":
                playSound("sounds/cnote");
                break;

            case "d_button":
                playSound("sounds/dnote");
                print("dnots");
            break;
            case "e_button":
                playSound("sounds/enote");
                print("enots");
                break;
            case "f_button":
                playSound("sounds/fnote");
                print("fnots");
                break;
            case "g_button":
                playSound("sounds/gnote");
                print("gnots");
                break;
            case "a_button":
                playSound("sounds/anote");
                print("anots");
                break;
            case "b_button":
                playSound("sounds/bnote");
                print("bnots");
                break;
            default:
                print("nav nekâ");
            break;
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        StopAllAudio();
        Debug.Log("Button released");
    }
}
  