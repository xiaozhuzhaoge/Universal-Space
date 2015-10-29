using UnityEngine;
using System;
using System.Collections;

public class TimeCom
{
    public static TimeCom instance;
    static int time = 0;
    static long lastRealTime = 0;
    static public int frameLength = 200;
	static long localTimeOnSet=0;//tick
	static long serverTime=0;//ms
	static long utcOffset=-480*60*1000;

    static public void Init()
    {
        lastRealTime = GetUTCMS();
    }

    static public int GetTime()
    {
        var temp = GetUTCMS();
        time += (int)(temp - lastRealTime);
        lastRealTime = temp;
        return time;
    }

    static public void SetTime(int time)
    {
        TimeCom.time = time;
        lastRealTime = GetUTCMS();
    }

    static public int GetFrameOffsetTime(int time)
    {
        return time % frameLength;
    }

    public static long GetUTCMS()
    {
		long localOffset=DateTime.Now.Ticks/10000-localTimeOnSet;
		DateTime correctTime = new DateTime(TimeCom.CorrectServerTime(serverTime)*10000+localOffset*10000,DateTimeKind.Utc);
		return correctTime.Ticks / 10000;
    }

    public static DateTime GetUTCTime()
    {
		return new DateTime(TimeCom.GetUTCMS() * 10000,DateTimeKind.Utc);
    }

	public static void SetServerTime(long serverT,int utcOff=-100000)
    {
		serverTime=serverT;
		localTimeOnSet=DateTime.Now.Ticks/10000;
		if(utcOff!=-100000)
			utcOffset=utcOff*60*1000;
    }

    public static bool IsYesterday(long utcTime)
    {
		DateTime now = GetUTCTime();
		DateTime midnight = GetMidnight(now);
        return TimeCom.CorrectServerTime(utcTime)< midnight.Ticks / 10000;
    }

	public static long CorrectServerTime(long serverTime)
	{
		DateTime offSetTime = new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc);
		DateTime serverTim = new DateTime ((serverTime-utcOffset)*10000,DateTimeKind.Utc);
		DateTime serverUtcTime = new DateTime (offSetTime.Ticks+serverTim.Ticks,DateTimeKind.Utc);
		return serverUtcTime.Ticks / 10000;
	}

	static DateTime GetMidnight(DateTime now)
	{
		return new DateTime(now.Year, now.Month, now.Day,0,0,0,DateTimeKind.Utc);
	}

	public static long GetTodayPastTime()
	{
		DateTime now = GetUTCTime();
		DateTime midnight =GetMidnight(now);
		return (now.Ticks-midnight.Ticks)/ 10000000;
	}

}
