using System;

public class Score
{
	public int score;
	public string name;
	public DateTime time;

	public Score (int score, string name, string time)
	{
		this.score = score;
		this.name = name;
		if (time != null) {
			this.time = DateTime.Parse (time);
		}
	}

	public string toJson() {
		return "{" +
			"\"name\": \"" + this.name + "\"" +
			"\"score\": " + this.score +
			"\"device_id\": \"" + Util.getDeviceID() + "\"" +
		"}";
	}

	public override string ToString()
	{
		return "[" +  this.name + " - " + this.score + " @ " + this.time + "]";
	}
}
