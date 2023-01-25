using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using BNG;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(PhotonTransformView))]
public class NetworkedGrabbable : MonoBehaviourPunCallbacks
{
	bool joined, owner;
	public GrabbableUnityEvents grabbableEvents;
	public Rigidbody rb;
	
	bool isKinematic = false;
	bool useGravity = true;
	bool grabbed = false;
	
	void Reset()
	{
		grabbableEvents = this.GetComponent<GrabbableUnityEvents>();
		if(!grabbableEvents)
			grabbableEvents = this.gameObject.AddComponent<GrabbableUnityEvents>();
			
		rb = this.GetComponent<Rigidbody>();
			
		if(this.GetComponent<PhotonView>() != null)
			this.GetComponent<PhotonView>().OwnershipTransfer = OwnershipOption.Takeover;
		
		if(this.GetComponent<PhotonTransformView>() != null)
			this.GetComponent<PhotonTransformView>().m_UseLocal = false;
	}
	
	void Start()
	{
		Debug.Log(grabbableEvents);
		Debug.Log(grabbableEvents.onGrab);
		grabbableEvents.onGrab.AddListener((Grabber grabber)=>{
			TakeOver();
			grabbed = true;
		});
		grabbableEvents.onRelease.AddListener(()=>{
			grabbed = false;
		});
		isKinematic = rb.isKinematic;
		useGravity = rb.useGravity;
	}
	
	public override void OnJoinedRoom()
	{
		joined = true;
		//if(this.photonView.Owner == null && PhotonNetwork.LocalPlayer.IsMasterClient)
		//	TakeOver();
	}
	
	Vector3 pos;

    // Update is called once per frame
    void Update()
    {
	    if(!joined)
		    return;
		    
	    if(this.photonView.Owner == null && pos != transform.position)
		    TakeOver();
		    
	    if(owner && !grabbed && rb.IsSleeping())
		    Release();
		    
    }
    
	void LateUpdate()
	{
		if(!joined)
			return;
			
		owner = this.photonView.Owner != null && this.photonView.Owner.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber;
		pos = this.transform.position;
		
		    
		if(!owner && owner != null)
		{
			rb.isKinematic = true;
			rb.useGravity = false;
		}

	}
    
	void TakeOver()
	{
		this.photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
		rb.isKinematic = false;//isKinematic;
		rb.useGravity = true;//useGravity;
	}
	
	void Release()
	{
		this.photonView.TransferOwnership(-1);
		rb.isKinematic = false;//isKinematic;
		rb.useGravity = true;
	}
}
