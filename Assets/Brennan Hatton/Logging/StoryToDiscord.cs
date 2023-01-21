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
	
	void Start()
	{
		storyLength = story.inputResults.text.Length;
	}

    // Update is called once per frame
    void Update()
    {
		    
	    if(story.inputResults.text.Length != storyLength)
	    {
	    	StartCoroutine(sendStory());
	    	// ```"+story.inputResults.text+"```" + "prompt:```"+story.inputPrompt.text+story.logger.output+"```");
	    	
		    storyLength = story.inputResults.text.Length;
	    }
    }
    
	IEnumerator sendStory()
	{
		discord.SendMessage("A new story");
		yield return new WaitForSeconds(0.1f);
		discord.SendMessage(story.inputResults.text, true);
		yield return new WaitForSeconds(0.1f);
		discord.SendMessage("```"+story.Prompt+story.logger.output+"```", true);
		yield return null;
	}
}
}
