using UnityEngine;

// in the final version, this would return the device unique identifier so that multiple users could have the same name but doesn't statistics.

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

