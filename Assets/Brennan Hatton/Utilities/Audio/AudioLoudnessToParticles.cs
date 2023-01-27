using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessToParticles : MonoBehaviour
{
	public ParticleSystem ps;
	public AudioSouceLoudnessTester audioSource;
	public float minLoudness;
	
	// Start is called before the first frame update
	void Reset()
	{
		ps = this.GetComponent<ParticleSystem>();
		audioSource = this.GetComponent<AudioSouceLoudnessTester>();
	}

	// Update is called once per frame
	void Update()
	{
		if(audioSource.Loudness > minLoudness)
		{
			ps.loop = true;
			ps.Play();
		}
		else
			ps.loop = false;
	}
}
