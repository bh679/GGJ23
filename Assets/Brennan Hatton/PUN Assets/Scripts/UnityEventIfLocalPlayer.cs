using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

public class UnityEventIfLocalPlayer : MonoBehaviour
{
	public PhotonView player;
	public bool onStart;
	public UnityEvent EventIfLocaPlayer = new UnityEvent();
	
	void Reset()
	{
		player = this.GetComponentInParent<PhotonView>();
	}
		
	// Start is called before the first frame update
	void Start()
	{
		if(onStart)
			RunEventIfLocal();
	}
	
	public void RunEventIfLocal()
	{
		if(player.Owner.IsLocal)
		{
			EventIfLocaPlayer.Invoke();
		}
	}
}