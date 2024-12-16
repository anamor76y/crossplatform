using System;
using System.Linq; 

namespace LabUtils;

public static class CalculateMin
{
	private const int SecondsIn12h = 60 * 60 * 12;
	public static int ConvertTimeToSec(string time)
	{
		var timeParts = time.Split(':').Select(int.Parse).ToArray();
		int hours = timeParts[0];
		int minutes = timeParts[1];
		int seconds = timeParts[2];

		return (hours % 12) * 3600 + minutes * 60 + seconds;
	}

	public static string ConvertSecondsToTime(int totalSeconds)
	{
		int hours = totalSeconds / 3600;
		if (hours == 0)
		{
			hours = 12;
		}

		int minutes = (totalSeconds % 3600) / 60;
		int seconds = totalSeconds % 60;

		return $"{hours}:{minutes:D2}:{seconds:D2}";
	}

	public static string CalculateMinimumAdjustmentTime(string[] times)
	{

		int[] SecondsSum = new int[SecondsIn12h];




		foreach (var time in times)
		{
			int timeInSeconds = ConvertTimeToSec(time);
			for (int currentSecond = 0; currentSecond < SecondsIn12h; currentSecond++)
			{
				int adjustment = (currentSecond - timeInSeconds + SecondsIn12h) % SecondsIn12h;
				SecondsSum[currentSecond] += adjustment;
			}
		}

		int minAdjustment = SecondsSum.Min();
		int bestTime = Array.IndexOf(SecondsSum, minAdjustment);

		return ConvertSecondsToTime(bestTime);
	}

}



