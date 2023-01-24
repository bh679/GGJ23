using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun;
using UnityLibrary;

namespace BrennanHatton.Networking.Events
{
	
	public class ReceiveNarrationEvent : MonoBehaviour, IOnEventCallback
	{
		//public GPT3 openaiGPT3;
		public SpeechManager speech;
		
		public UnityEvent onReceive; 
		
		void Reset()
		{
			//openaiGPT3 = this.GetComponentInParent<GPT3>();
			speech = this.GetComponentInParent<SpeechManager>();
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
			
			if(eventCode == SendNarrationEventManager.NarrationTextEventCode)
			{
				object[] data = (object[])photonEvent.CustomData;
				int id = (int)data[0];
				string narration = (string)data[1];
				
				/*InteractionData interactionData = new InteractionData(new RequestData());
				interactionData.generatedText = narration;
				openaiGPT3.interactions.Add(interactionData);*/
				
				speech.SpeakWithSDKPlugin(narration);
				
				onReceive.Invoke();
			}
		}
	}

}
