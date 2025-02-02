﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class AudioSouceLoudnessTester : MonoBehaviour {

	public AudioSource audioSource;
	public float updateStep = 0.1f;
	public int sampleDataLength = 1024;
	
	private float currentUpdateTime = 0f;
	
	public float Loudness{get{return clipLoudness;}}
	private float clipLoudness;
	private float[] clipSampleData;
	
	// Use t$$anonymous$$s for initialization
	void Awake () {
	
		if (!audioSource) {
			Debug.LogError(GetType() + ".Awake: there was no audioSource set.");
		}
		clipSampleData = new float[sampleDataLength];
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(audioSource.clip != null && audioSource.isPlaying)
		{
			currentUpdateTime += Time.deltaTime;
			if (currentUpdateTime >= updateStep) {
				currentUpdateTime = 0f;
				audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, w$$anonymous$$ch is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
				clipLoudness = 0f;
				foreach (var sample in clipSampleData) {
					clipLoudness += Mathf.Abs(sample);
				}
				clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for
			}
		}
		else
			clipLoudness = 0f;
	
	}

}