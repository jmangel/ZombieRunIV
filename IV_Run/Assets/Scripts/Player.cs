using System;
using System.Collections.Generic;

public class Player
{
	int id;
	string name;
	string device_id;
	int hifive_count;
	int last_hifives;
	int characters;
	int powerup_lvl;
    Score lastScore = null;
    int lastRank = -1;

	public Player (int id, string name, int hifive_count, int characters, int powerup_lvl) {
		this.id = id;
		this.device_id = Util.getDeviceID ();
		this.name = name;
		this.hifive_count = hifive_count;
		this.characters = characters;
		this.powerup_lvl = powerup_lvl;
	}

	public string toString() {
		return "Player " + this.id + " has name " + this.name + 
			" \nand is registered on device " + this.device_id + 
			" \nwith " + this.hifive_count + " high fives, \n" + 
			this.characters + " characters, \nand powerup level " + this.powerup_lvl;
	}

	public int getID() {
		return this.id;
	}

	public string getName() {
		return this.name;
	}

	public int getLastScore() {
		return this.lastScore.score;
	}

	public int getLastRank() {
		return this.lastRank;
	}

	/**
	 * `hifive_count` operations
	 */

	public void addHiFives(int hifives) {
		this.last_hifives = hifives;
		this.setHiFives(this.getHiFives() + hifives);
	}

	public int getHiFives() {
		return this.hifive_count;
	}

	public void setHiFives(int hifives) {
		this.hifive_count = hifives;
	}

	public bool saveHiFives() {
		return ApiClient.saveHiFives (this.id, this.hifive_count);
	}

	public int getLastHifives() {
		return this.last_hifives;
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
        this.lastScore = new Score(score, this.name, null);
		this.lastRank = ApiClient.newScore (this.lastScore);
        return this.lastRank;
	}
}