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
	bool useGravity = false;
	
	void Reset()
	{
		grabbableEvents = this.GetComponent<GrabbableUnityEvents>();
		if(!grabbableEvents)
			grabbableEvents = this.gameObject.AddComponent<GrabbableUnityEvents>();
			
		rb = this.GetComponent<Rigidbody>();
			
		if(this.GetComponent<PhotonView>() != null)
		{
			this.GetComponent<PhotonView>().OwnershipTransfer = OwnershipOption.Takeover;
		}
	}
	
	void Start()
	{
		Debug.Log(grabbableEvents);
		Debug.Log(grabbableEvents.onGrab);
		grabbableEvents.onGrab.AddListener((Grabber grabber)=>{TakeOver();});
		isKinematic = rb.isKinematic;
		useGravity = rb.useGravity;
	}
	
	public override void OnJoinedRoom()
	{
		joined = true;
		if(this.photonView.Owner == null && PhotonNetwork.LocalPlayer.IsMasterClient)
			TakeOver();
	}

    // Update is called once per frame
    void Update()
    {
	    if(!joined)
		    return;
		    
	    if(!owner)
	    {
	    	rb.isKinematic = false;
		    rb.useGravity = false;
	    }
		    
    }
    
	void LateUpdate()
	{
		if(!joined)
			return;
			
		owner = this.photonView.Owner != null && this.photonView.Owner.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber;
		

	}
    
	void TakeOver()
	{
		this.photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
		rb.isKinematic = isKinematic;
		rb.useGravity = useGravity;
	}
}
