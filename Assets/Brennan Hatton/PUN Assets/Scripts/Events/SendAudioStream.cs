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
		
		
		void Update()
		{
			//make it autosend
			if(speechManager.audioStream != null && speechManager.audioStream.CanRead)
			{
				if(speechManager.audioStream.Length != length)
				{
					SendUpdateHealthEvent();
					length = speechManager.audioStream.Length;
				}
			
			}	
		}
				
			
		public void SendUpdateHealthEvent()
		{
			SendAudioStreamEventManager.SendUpdateHealthEvent(speechManager.audioStream);
		}
	
	}

}
