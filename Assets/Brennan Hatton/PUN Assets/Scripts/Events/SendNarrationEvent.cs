using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityLibrary;
using BrennanHatton.Logging;

namespace BrennanHatton.Networking.Events
{
	
	public class SendNarrationEvent : MonoBehaviour
	{	

		public StoryMaker story;
		public bool runActions = true;
		
		int interactionsNumber;
		
		
		void Reset()
		{
			story = this.GetComponentInParent<StoryMaker>();
		}
		
		void Start()
		{
			interactionsNumber = story.GPTAPI.interactions.Count;
		}
	
		// Update is called once per frame
		void Update()
		{
			if(runActions)
			{
				//if new story is avalible
				if(story.GPTAPI.interactions.Count != interactionsNumber)
				{
					SendNarrationEventPlz(story.GPTAPI.interactions[story.GPTAPI.interactions.Count-1].generatedText);
			    	
					interactionsNumber = story.GPTAPI.interactions.Count;
				}
			}
		}
			
		public void SendNarrationEventPlz(string text)
		{
			SendNarrationEventManager.SendNarrationTextEvent(text);
		}
	
	}

}
