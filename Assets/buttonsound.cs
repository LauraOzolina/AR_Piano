using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
public class buttonsound : MonoBehaviour
{

    public GameObject vbBtnObj, mode_btn, song_btn;
    public AudioSource soundTarget;
    public AudioClip clipTarget;
    private AudioSource[] allAudioSources;
    public TextMesh notes;
    TextMesh mode_text, song_text, notes_text;
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
        soundTarget.PlayOneShot(soundTarget.clip);
        Debug.Log(ss);
    }
    void Start()
    {
        soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();
        mode_text = mode_btn.GetComponentInChildren<TextMesh>();
        song_text = song_btn.GetComponentInChildren<TextMesh>();

        notes_text = notes.GetComponentInChildren<TextMesh>();

        for (int i = 0; i < virtualButtonBehaviours.Length; i++)
        {
            virtualButtonBehaviours[i].GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
            virtualButtonBehaviours[i].GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
        }
        vbBtnObj = GameObject.Find("c_button");
        // audioSource = GetComponent<AudioSource>();
        Debug.Log(vbBtnObj);
        Debug.Log("skanas skripts");
        //  vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        // vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
    }
    void Update()
    {
        if ((mode_text.text == "Start") && (song_text.text == "Ode To Joy"))
        {
            notes_text.text = "E E F G G F E D C \n C D E E D D \n E E F G G F E D C C D\n E D C C D D E C  \nD E F E C D E F E D C D G E E F \n G G F E D C C D E D C C";
        }
        else if ((mode_text.text == "Start") && (song_text.text == "Twinkle Twinkle Little Star"))
        {
            notes_text.text = "C C G G A A G\n F F E E D D C\n G G F F E E D\n G G F F E E D\n C C G G A A G F F E E D D C";
        }
        else
        {
            notes_text.text = "notes";
        }


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
            case "mode_button":
                if (mode_text.text == "Practice")
                {
                    mode_text.text = "Start";
                }
                else if (mode_text.text == "Start")
                {
                    mode_text.text = "Stop";
                }
                else
                {
                    mode_text.text = "Practice";
                }
                print(mode_text.text);
                break;
            case "song_button":
                if (song_text.text == "Choose song")
                {
                    song_text.text = "Ode To Joy";
                }
                else if (song_text.text == "Ode To Joy")
                {
                    song_text.text = "Twinkle Twinkle Little Star";
                }
                else
                {
                    song_text.text = "Choose song";
                }
                print(song_text.text);
                break;
            default:
                print("nav nekâ");
                break;
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        // StopAllAudio();
        Debug.Log("Button released");
    }
}
