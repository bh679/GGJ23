using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun;
using System.IO;

namespace BrennanHatton.Networking.Events
{
	
	public class RecieveAudioStream : MonoBehaviour, IOnEventCallback
	{
		public SpeechManager speechManager;
		
		public UnityEvent onReceive; 
		
		void Reset()
		{
			speechManager = this.GetComponent<SpeechManager>();
		}
		
		private void OnEnable()
		{
			PhotonNetwork.AddCallbackTarget(this);
		}
	
		private void OnDisable()
		{
			PhotonNetwork.RemoveCallbackTarget(this);
		}
	
		public void OnEvent(EventData photonEvent)
		{
			byte eventCode = photonEvent.Code;
			
			if(eventCode == SendAudioStreamEventManager.SteamEventCode)
			{
				object[] data = (object[])photonEvent.CustomData;
				int id = (int)data[0];
				Stream audioStream = (Stream)data[1];
				
				speechManager.PlayAudio(audioStream);
				
				onReceive.Invoke();
			}
		}
	}

}
