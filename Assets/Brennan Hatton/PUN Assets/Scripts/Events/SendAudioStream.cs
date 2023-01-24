using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace BrennanHatton.Networking.Events
{
	
	public class SendAudioStream : MonoBehaviour
	{
		public SpeechManager speechManager;
		
		long length = 0;
		float clipLength = 0;
		
		void Update()
		{
			
			if(speechManager.audiodata != null && speechManager.audiodata.Length != clipLength)
			{
				SendAudioclipEvent();
				clipLength = speechManager.audiodata.Length;
			}
		}
				
			
			
		public void SendAudioclipEvent()
		{
			SendNarrationEventManager.SendAudioclipEvent(speechManager.audiodata);
		}
	
	}

}
