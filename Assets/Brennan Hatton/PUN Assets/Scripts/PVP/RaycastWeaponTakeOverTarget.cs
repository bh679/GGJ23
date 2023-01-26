using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class RaycastWeaponTakeOverTarget : MonoBehaviour
{
	public RaycastWeapon weapon;
		
	bool shotHit = false;
		
	void Reset()
	{
		weapon = this.GetComponent<RaycastWeapon>();
	}
		
	// Start is called before the first frame update
	void Start()
	{
		weapon.onRaycastHitEvent.AddListener(HitNetworkedGrabbale);
		shotHit = false;
	}
	
	public void HitNetworkedGrabbale(RaycastHit hit)
	{
		NetworkedGrabbable netGrabbale = hit.transform.gameObject.GetComponentInParent<NetworkedGrabbable>();
		if(netGrabbale != null)
		{
			netGrabbale.TakeOver();
		}
	}
}
