using UnityEngine;
using System;
//keeps information between scenes without deleting
public class PlayerSingleton : MonoBehaviour
{
	public string player_name = null;
	private Player instance;
	// gets player data from the api
	public Player getPlayer() {
		if (instance == null) {
			if (player_name == null) {
				return null;
			} else {
				instance = ApiClient.getPlayer(player_name);
			}
		}
		return instance;
	}
	//pre: NONE
	//post:: doesnt detroy on loading scene
	public virtual void Awake ()
	{
		DontDestroyOnLoad (this.gameObject);
	}
}
