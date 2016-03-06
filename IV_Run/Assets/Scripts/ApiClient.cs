using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

using UnityEngine;

public class ApiClient
{
	static string api = "https://zombie-run-iv.herokuapp.com";

	public static Player getPlayer(string name) {
		Player player = null;
		string endpoint = api + "/players/find?name=" + name + "&device_id=" + Util.getDeviceID ();

		string response = null;
		try {
			WebClient client = new WebClient ();
			response = client.DownloadString (endpoint);
		} catch(Exception e) {
			Debug.LogError ("creating player inside try catch");
			return ApiClient.createPlayer (name);
		}
		if (!response.Contains ("id")) {
			Debug.LogError ("creating player outside try catch");
			return ApiClient.createPlayer (name);
		}



//		HttpWebRequest req = (HttpWebRequest)WebRequest.Create (endpoint);
//		HttpWebResponse resp = (HttpWebResponse)req.GetResponse ();
//
//		if (resp.StatusCode == HttpStatusCode.NotFound) {
//			resp.Close ();
//			Debug.LogError ("Couldn't find user, creating it new");
//			return ApiClient.createPlayer (name);
//		} else if (resp.StatusCode != HttpStatusCode.OK) {
//			Debug.LogError ("Couldn't connect to server");
//			return null;
//		} else {
//			Debug.LogError ("Found the user!");
//		}
//		Stream dataStream = resp.GetResponseStream();
//		StreamReader reader = new StreamReader(dataStream);
//		string data = reader.ReadToEnd();
//		Console.WriteLine (data);

		JObject json = JObject.Parse (response);
		player = new Player(
			(int)json["id"],
			(string)json["name"],
			(int)json["hifive_count"],
			(int)json["characters"],
			(int)json["powerup_lvl"]
		);
		return player;
	}

	public static Player createPlayer(string name) {
		Player player = null;
		string endpoint = api + "/players?name=" + name + "&device_id=" + Util.getDeviceID ();
//		HttpWebRequest req = (HttpWebRequest)WebRequest.Create (endpoint);
//		req.Method = "POST";

		WebClient client = new WebClient ();
		string response = client.UploadString (endpoint,"");

//		HttpWebResponse resp = (HttpWebResponse)req.GetResponse ();
//		Stream dataStream = resp.GetResponseStream();
//		StreamReader reader = new StreamReader(dataStream);
//		string data = reader.ReadToEnd();
//		Console.WriteLine (data);

		JObject json = JObject.Parse (response);
		player = new Player(
			(int)json["id"],
			(string)json["name"],
			(int)json["hifive_count"],
			(int)json["characters"],
			(int)json["powerup_lvl"]
		);
		return player;

	}

	public static List<Score> getScores() {
		List<Score> scores = new List<Score>();

		WebClient client = new WebClient();
		string scores_json = client.DownloadString(api + "/scores");
		//Console.WriteLine(scores);
		JObject joresp = JObject.Parse(scores_json);
		Console.WriteLine(joresp["scores"][0].ToString());

		IList<JToken> results = joresp ["scores"].Children ().ToList ();

		foreach (JToken result in results) {
			scores.Add (new Score (
				(int)result ["score"], 
				(string)result ["player"] ["name"], 
				(string)result ["time"])
			);
		}
//		scores = jscores.Select(
//			o => new Score((int)o["score"],(string)o["player"]["name"], (string)o["time"])
//		).ToList();
		return scores;
	}

	public static List<Score> getScores(string name) {
		Player player = ApiClient.getPlayer (name);
		return ApiClient.getScores (player);
	}

	public static List<Score> getScores(Player player) {
		List<Score> scores = new List<Score>();
		if (player == null) {
			Console.WriteLine ("Not Found");
			return new List<Score> ();
		}

		WebClient client = new WebClient();
		string scores_json = client.DownloadString(api + "/players/" + player.getID() + "/scores");
		//Console.WriteLine(scores);
		JObject joresp = JObject.Parse(scores_json);
		Console.WriteLine(joresp["scores"][0].ToString());

		IList<JToken> results = joresp ["scores"].Children ().ToList ();

		foreach (JToken result in results) {
			scores.Add (new Score (
				(int)result ["score"], 
				(string)result ["player"] ["name"], 
				(string)result ["time"])
			);
		}

//		scores = jscores.Select(
//			o => new Score((int)o["score"],(string)o["player"]["name"], (string)o["time"])
//		).ToList();
		return scores;
	}

	public static int newScore(int score, string name)
	{
		Score s = new Score(score, name, null);
		return ApiClient.newScore(s);
	}

	public static int newScore(Score score)
	{
		string endpoint = api + "/scores?name=" + score.name +
		                  "&device_id=" + Util.getDeviceID () +
		                  "&score=" + score.score;
		HttpWebRequest req = (HttpWebRequest)WebRequest.Create (endpoint);
		req.Method = "POST";
		HttpWebResponse resp = (HttpWebResponse)req.GetResponse ();

		string data = new StreamReader (resp.GetResponseStream ()).ReadToEnd ();
		JObject jdata = JObject.Parse (data);

		if (resp.StatusCode == HttpStatusCode.OK) {
			return (int)jdata ["rank"];
		} else {
			return -1;
		}
	}

	public static bool saveHiFives(int pid, int hifives) {
		string endpoint = api + "/players/"+pid+"/hifives?hifives="+hifives;
		HttpWebRequest req = (HttpWebRequest)WebRequest.Create (endpoint);
		req.Method = "POST";
		HttpWebResponse resp = (HttpWebResponse)req.GetResponse ();

		return resp.StatusCode == HttpStatusCode.OK;
	}

	public static bool saveCharacters(int pid, int characters) {
		string endpoint = api + "/players/"+pid+"/characters?characters="+characters;
		HttpWebRequest req = (HttpWebRequest)WebRequest.Create (endpoint);
		req.Method = "POST";
		HttpWebResponse resp = (HttpWebResponse)req.GetResponse ();

		return resp.StatusCode == HttpStatusCode.OK;
	}

	public static bool savePowerupLvl(int pid, int powerup_lvl) {
		string endpoint = api + "/players/"+pid+"/powerup_lvl?powerup_lvl="+powerup_lvl;
		HttpWebRequest req = (HttpWebRequest)WebRequest.Create (endpoint);
		req.Method = "POST";
		HttpWebResponse resp = (HttpWebResponse)req.GetResponse ();

		return resp.StatusCode == HttpStatusCode.OK;
	}
}