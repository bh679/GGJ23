using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BNG;

public class ScrollbarHealthbar : MonoBehaviour
{
	
	public BNG.Damageable health;
	public Scrollbar bar;
	public float max = 100f;
		
	void Reset()
	{
		bar = this.GetComponent<Scrollbar>();
		health = this.GetComponent<Damageable>();
	}
	
	void Start()
	{
		health.onDamaged.AddListener(UpdateHealth);
	}
	
	public void UpdateHealth(float change)
	{
		bar.size = 1-(health.Health / max);
	}
    
}
