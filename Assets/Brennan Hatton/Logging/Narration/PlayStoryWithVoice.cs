using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BrennanHatton.Logging
{
	public class PlayStoryWithVoice : MonoBehaviour
	{
	    
		public SpeechManager speech;
		public StoryMaker story;
		
		int interactionsNumber;
		bool executing = false;
		
		void Start()
		{
			interactionsNumber = story.GPTAPI.interactions.Count;
			
			executing = true;
			
			StartCoroutine(RunIntro());
		}
	
		// Update is called once per frame
		void Update()
		{
			
			//if its not current making a story
			if(!executing)
			{
				//if there are actions
				if(story.logger.actions.Count > 0)
				{
					story.NarrateActions();
					executing = true;
				}else
				{
					story.AskQuestion();
					executing = true;
				}
				
			}
			
			//if not currently playing
			if(speech.audioSource.isPlaying == false)
			{
				//if new story is avalible
				if(executing && story.GPTAPI.interactions.Count != interactionsNumber)
				{
					speech.SpeakWithSDKPlugin(story.GPTAPI.interactions[story.GPTAPI.interactions.Count-1].generatedText);
					// ```"+story.inputResults.text+"```" + "prompt:```"+story.inputPrompt.text+story.logger.output+"```");
			    	
					interactionsNumber = story.GPTAPI.interactions.Count;
					executing = false;
				}
			}
		}
		
		IEnumerator RunIntro()
		{
			yield return new WaitForSeconds(1f);
			
			story.Introduction();
		}
		
	}
}