using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BrennanHatton.Logging
{
	public class PlayStoryWithVoice : MonoBehaviour
	{
	    
		public SpeechManager speech;
		public StoryMaker story;
		
		int storyLength;
		
		void Start()
		{
			storyLength = story.inputResults.text.Length;
		}
	
		// Update is called once per frame
		void Update()
		{
			    
			if(story.inputResults.text.Length != storyLength)
			{
				speech.SpeakWithSDKPlugin(story.inputResults.text);
				// ```"+story.inputResults.text+"```" + "prompt:```"+story.inputPrompt.text+story.logger.output+"```");
		    	
				storyLength = story.inputResults.text.Length;
			}
		}
	}
}