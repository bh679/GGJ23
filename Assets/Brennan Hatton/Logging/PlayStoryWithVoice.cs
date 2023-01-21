using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BrennanHatton.Logging
{
	public class PlayStoryWithVoice : MonoBehaviour
	{
	    
		public SpeechManager speech;
		public StoryMaker story;
		TextAsset followUpPrompts;
		
		int storyLength;
		bool executing = false;
		
		void Start()
		{
			storyLength = story.inputResults.text.Length;
		}
	
		// Update is called once per frame
		void Update()
		{
			//if there are actions
			if(story.logger.actions.Count > 0)
			{
				//if its not current making a story
				if(!executing)
				{
					story.Execute();
					executing = true;
					story.logger.actions = new List<LogAction>();
					story.logger.output = "";
				}
				
			}
			
			//if not currently playing
			if(speech.audioSource.isPlaying == false)
			{
				//if new story
				if(executing && story.inputResults.text.Length != storyLength)
				{
					speech.SpeakWithSDKPlugin(story.inputResults.text);
					// ```"+story.inputResults.text+"```" + "prompt:```"+story.inputPrompt.text+story.logger.output+"```");
			    	
					storyLength = story.inputResults.text.Length;
					executing = false;
				}
			}
		}
	}
}