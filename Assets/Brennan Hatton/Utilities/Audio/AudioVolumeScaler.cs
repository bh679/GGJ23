using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeScaler: MonoBehaviour
{
	public Transform mouthToScale;
	public AudioSouceLoudnessTester audioSource;
	public Vector2 scale;
	
    // Start is called before the first frame update
	void Reset()
    {
	    mouthToScale = this.transform;
	    audioSource = this.GetComponent<AudioSouceLoudnessTester>();
    }

    // Update is called once per frame
    void Update()
	{
		float mag = audioSource.Loudness*(scale.y-scale.x)+scale.x;
		mouthToScale.localScale = new Vector3(mag,mag,mag);
    }
}
