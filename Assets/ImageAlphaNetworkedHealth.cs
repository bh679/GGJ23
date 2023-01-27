using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using BNG;

public class ImageAlphaNetworkedHealth : MonoBehaviourPunCallbacks
{
	public Image image;
	public Sprite damaged, dead;
	Damageable health;
	
    // Start is called before the first frame update
	public override void OnJoinedRoom()
	{
		StartCoroutine(findHealthAfterTime(0.1f));
	}
	
	IEnumerator findHealthAfterTime(float time)
	{
		yield return new WaitForSeconds(time);
		health = FindLocalDamagable();
	}
    
	Damageable FindLocalDamagable()
	{
		EqualReality.Networking.NetworkPlayer[] players = GameObject.FindObjectsOfType<EqualReality.Networking.NetworkPlayer>();
		for(int i =0 ;i < players.Length; i++){
			if(players[i].PhotonView.IsMine)
				return players[i].PhotonView.GetComponent<Damageable>();
			
		}
		
		Debug.LogError("No health found");
		return null;
	}

    // Update is called once per frame
    void Update()
	{
		if(health != null)
		{
			if(health.Health <= 0)
			{
				image.sprite = dead;
				image.color = new Color(image.color.r, image.color.g, image.color.b, 0.75f);
			}
			else
			{
				image.sprite = damaged;
				image.color = new Color(image.color.r, image.color.g, image.color.b, 1-health.Health/100f);
			}
			//Debug.Log(health.Health);
		}
    }
}
