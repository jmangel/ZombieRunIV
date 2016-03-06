using UnityEngine;
using System;

public class PlayerSingleton : MonoBehaviour
{
	public string player_name = null;
	private Player instance;

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

	public virtual void Awake ()
	{
		DontDestroyOnLoad (this.gameObject);
	}
}
