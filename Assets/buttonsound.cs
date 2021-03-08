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
    char[] od, tw;
    TextMesh mode_text, song_text, notes_text;
    VirtualButtonBehaviour[] virtualButtonBehaviours;
    string ode_to_joy;
    string twinkle;
    string played_music;
    int which_song;
    bool record;
    int total;
    int correct;
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
   
    }
    void Start()
    {
        soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();
        mode_text = mode_btn.GetComponentInChildren<TextMesh>();
        song_text = song_btn.GetComponentInChildren<TextMesh>();
        ode_to_joy = "EEFGGFEDCCDEEDDEEFGGFEDCCDEDCCDDECEFECDEFEDCDGEEFGGFEDCCDEDCC";
        twinkle = "CCGGAAGFFEEDDCGGFFEEDGGFFEEDCCGGAAGFFEEDDC";
        notes_text = notes.GetComponentInChildren<TextMesh>();
        which_song = 0;
        total = 0;
        correct = 0;
        record = false;
        played_music = "";
        // od= ode_to_joy.ToCharArray();
        //array_of_notes[2] = twinkle.ToCharArray();
        for (int i = 0; i < virtualButtonBehaviours.Length; i++)
        {
            virtualButtonBehaviours[i].GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
            virtualButtonBehaviours[i].GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
        }
        vbBtnObj = GameObject.Find("c_button");

     

    }
    void Update()
    {



    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
  Debug.Log(record);
        if ((mode_text.text == "Stop") && (song_text.text == "Ode To Joy"))
        {
            which_song = 1;
            record = true;
          
        }
  
        if ((mode_text.text == "Stop") && (song_text.text == "Twinkle Twinkle Little Star"))
        {
            which_song = 2;
            record = true;
            Debug.Log(vb.name + "notietwgu");
        }
 
        Debug.Log(vb.name + "Button pressed");
        switch (vb.name)
        {
            case "c_button":
                playSound("sounds/cnote");
                if (record)
                {
                    played_music += "C";
                }
                break;

            case "d_button":
                playSound("sounds/dnote");
                if (record)
                {
                    played_music += "D";
                }
                break;

            case "e_button":
                playSound("sounds/enote");
                if (record)
                {
                    played_music += "E";
                    Debug.Log(" / gno");
                }
              
                break;

            case "f_button":
                playSound("sounds/fnote");
                if (record)
                {
                    played_music += "F"; 
                }
                break;

            case "g_button":
                playSound("sounds/gnote");
                if (record)
                {
                    played_music += "G"; 

                }
                break;

            case "a_button":
                playSound("sounds/anote");
                if (record)
                {
                    played_music += "A";
                }
                break;

            case "b_button":
                playSound("sounds/bnote");
                if (record)
                {
                    played_music += "B";
                }
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
                    switch (which_song)
                    {
                        case 0:
                            break;

                        case 1:
                            total = 0;
                            correct = 0;
                            Debug.Log(played_music); 
                            foreach (char c in ode_to_joy)
                            {
                                Debug.Log(total);
                                if (total >= 0 && total < played_music.Length - 1)
                                {
                                    if (played_music[total] == c)
                                    {
                                        correct++;


                                    }
                                    else
                                    {

                                    }

                                }
                                total++;
                            }
                            notes_text.text = "Result:" + correct + "/" + total;
                            played_music = "";
                            break;

                        case 2:
                            Debug.Log(played_music);
                            total = 0;
                            correct = 0;
                            foreach (char c in twinkle)
                            {
                                Debug.Log(total); 
                                Debug.Log(played_music);
                                if (total >= 0 && total < played_music.Length - 1)
                                {
                                    if (played_music[total] == c)
                                    {
                                        correct++;


                                    }
                                    else
                                    {

                                    }

                                }
                                total++;

                            }
                            notes_text.text = "Result:" + correct + "/" + total;
                            played_music = "";
                            break;
                    }
                }
            
                break;

            case "song_button":
                if (song_text.text == "Choose song")
                {
                    song_text.text = "Ode To Joy";
                    which_song = 1;
                    int j = 0;
                    string to_display = "";
                    foreach (char c in ode_to_joy)
                    {
                        ++j;
                        to_display += c.ToString();
                        if (j > 8)
                        {
                            j = 0;
                            to_display += "\n";
                        }
                    }
                    notes_text.text = to_display;

                }
                else if (song_text.text == "Ode To Joy")
                {
                    song_text.text = "Twinkle Twinkle Little Star";
                    which_song = 2;
                    int j = 0;
                    string to_display = "";
                    foreach (char c in twinkle)
                    {
                        ++j;
                        to_display += c.ToString();
                        if (j > 8)
                        {
                            j = 0;
                            to_display += "\n";
                        }
                    }
                    notes_text.text = to_display;

                }
                else
                {
                    song_text.text = "Choose song";

                }
               
                break;

            default:
                print("nav nekâ");
                break;
        }
        print("______________________");
        print(record);
        print(played_music);

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
     
    }
}
