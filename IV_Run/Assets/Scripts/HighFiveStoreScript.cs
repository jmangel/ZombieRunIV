using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighFiveStoreScript : MonoBehaviour {
	//Pre:NONE
	//Post: get powerup and save to server
	public void clickUpgradePowerup() {

		Player x = GameObject.Find ("PlayerGameObject").GetComponent<PlayerSingleton> ().getPlayer();
		int cur_count = x.getHiFives ();

		//check if they have enough powerups
		if (cur_count < Util.getPowerupCost ()) {
			GameObject.Find ("UpgradeErrorText").GetComponent<Text> ().text = "* Not Enough High Fives";
		} else {
			x.setHiFives (cur_count - Util.getPowerupCost ());
			x.setPowerupLvl (x.getPowerupLvl () + 1);
			x.saveHiFives ();
			x.savePowerupLvl ();
		}
	}

	//PRE:NONE
	//POST: SURFERSelected to play as
	public void clickSelectSurfer() {

		GameObject.Find ("MikeSelected").GetComponent<Text> ().text = "";
		GameObject.Find ("SurferSelected").GetComponent<Text> ().text = "* Currently Selected";

		Player x = GameObject.Find ("PlayerGameObject").GetComponent<PlayerSingleton> ().getPlayer();
		x.setCharacters (1);
		x.saveCharacters ();
	}

	//PRE: NONE
	//POST:MikeSelected to play as
	public void clickSelectMike() {
		GameObject.Find ("SurferSelected").GetComponent<Text> ().text = "";
		GameObject.Find ("MikeSelected").GetComponent<Text> ().text = "* Currently Selected";

		Player x = GameObject.Find ("PlayerGameObject").GetComponent<PlayerSingleton> ().getPlayer();
		x.setCharacters (2);
		x.saveCharacters ();
	}

}
