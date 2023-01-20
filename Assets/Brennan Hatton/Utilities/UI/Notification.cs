using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
	public Text title, body;
	public Image icon;
	
	public UnityEvent onFinish;
	
	public void SetUp(string _title, string _description, Sprite _icon)
	{
		title.text = _title;
		body.text = _description;
		icon.sprite = _icon;
	}
    
	public void Close()
	{
		onFinish.Invoke();
		this.gameObject.SetActive(false);
	}
}
