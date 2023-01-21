using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrennanHatton.Discord;

namespace BrennanHatton.Logging
{
	public class StoryToDiscord : MonoBehaviour
	{
		public ClassDiscordConnection discord;
		public StoryMaker story;
		
		int storyLength;
		int promptLength;
		
		void Start()
		{
			storyLength = story.inputResults.text.Length;
			storyLength = story.results.Count;
		}
	
	    // Update is called once per frame
	    void Update()
		{
			    
			if(story.inputPrompt.text.Length != promptLength)
			{
				discord.SendMessage(story.inputPrompt.text, true);
				promptLength = story.inputPrompt.text.Length;
			}
			    
			 
			if(story.results.Count != storyLength)
			{
				discord.SendMessage("```"+story.results[0]+"```", true);
			    storyLength = story.results.Count;
		    }
	    }
	}
}
