using System;

// Score is an object that stores the score, name, and time of a score. This is used to store information on the server.

public class Score
{
	//declare variables
	public int score;
	public string name;
	public DateTime time;

	//constructor
	public Score (int score, string name, string time)
	{
		this.score = score;
		this.name = name;
		if (time != null) {
			this.time = DateTime.Parse (time);
		}
	}

	//translates it to format that is server friendly
	public string toJson() {
		return "{" +
			"\"name\": \"" + this.name + "\"" +
			"\"score\": " + this.score +
			"\"device_id\": \"" + Util.getDeviceID() + "\"" +
		"}";
	}

	//ToString method
	public override string ToString()
	{
		return "[" +  this.name + " - " + this.score + " @ " + this.time + "]";
	}
}
