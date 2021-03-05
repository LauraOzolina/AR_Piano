using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlayOnChange : DefaultTrackableEventHandler
{

	private TrackableBehaviour mTrackableBehaviour;
	AudioSource m_MyAudioSource;

	void Start()
	{
		Debug.Log("vxcvxc");
		//Fetch the AudioSource from the GameObject
		m_MyAudioSource = GetComponent<AudioSource>();

		//		mTrackableBehaviour = GetsComponent<TrackableBehaviour>();
		//		if (mTrackableBehaviour)
		//		{
		//			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		//		}
	}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			// Play audio when target is found
			m_MyAudioSource.Play();
			Debug.Log("Skanja deels");

		}
		else
		{
			// Stop audio when target is lost
			m_MyAudioSource.Stop();

		}
	}

}
