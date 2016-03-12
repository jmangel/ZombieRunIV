using UnityEngine;

// object generates device identifier and returns powerup price

public class Util
{
	public static string getDeviceID() {
        string uuid = SystemInfo.deviceUniqueIdentifier;
		return "abc123";
	}

	public static int getPowerupCost() {
		return 50;
	}
}

