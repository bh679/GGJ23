using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class ScaleOnEnable : MonoBehaviour
{
	public bool onEnable = true;
	public float duration = 0.5f;
	public float delay = 0f;
	
	GameObject transformTarget;

	void Awake()
	{
		//create a new gameobject and copy over this gameobject's starting scale values
		transformTarget = new GameObject();
		transformTarget.transform.parent = this.transform;
		transformTarget.transform.name = "Transform Target";
		transformTarget.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
    }

	void OnEnable()
	{
		if(onEnable)
			scaleUp();
	}

	public void scaleUp()
	{
		Tween.LocalScale(this.transform, Vector3.zero, transformTarget.transform.localScale, duration, delay, Tween.EaseInOut);
	}
	
	public void scaleToZero()
	{
		Tween.LocalScale(this.transform, Vector3.zero, duration, delay, Tween.EaseInOut);
	}
}
