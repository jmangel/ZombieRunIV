using System;
using System.Collections.Generic;

public class Player
{
	int id;
	string name;
	string device_id;
	int hifive_count;
	int characters;
	int powerup_lvl;

	public Player (int id, string name, int hifive_count, int characters, int powerup_lvl) {
		this.id = id;
		this.device_id = Util.getDeviceID ();
		this.name = name;
		this.hifive_count = hifive_count;
		this.characters = characters;
		this.powerup_lvl = powerup_lvl;
	}

	public int getID() {
		return this.id;
	}

	public string getName() {
		return this.name;
	}

	/**
	 * `hifive_count` operations
	 */

	public int getHiFives() {
		return this.hifive_count;
	}

	public void setHiFives(int hifives) {
		this.hifive_count = hifives;
	}

	public bool saveHiFives() {
		return ApiClient.saveHiFives (this.id, this.hifive_count);
	}

	/**
	 * `characters` operations
	 */

	public int getCharacters() {
		return this.characters;
	}

	public void setCharacters(int characters) {
		this.characters = characters;
	}

	public bool saveCharacters() {
		return ApiClient.saveCharacters (this.id, this.characters);
	}

	/**
	 * `powerup_lvl` operations
	 */

	public int getPowerupLvl() {
		return this.powerup_lvl;
	}

	public void setPowerupLvl(int powerup_lvl) {
		this.powerup_lvl = powerup_lvl;
	}

	public bool savePowerupLvl() {
		return ApiClient.savePowerupLvl (this.id, this.powerup_lvl);

	}

	public List<Score> getScores() {
		return ApiClient.getScores (this);
	}

	public int addScore(int score) {
		return ApiClient.newScore (score, this.name);
	}
}
