using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{
    public static string cid;

    public static string sessID;

	public static string lastArea;

    public static List<ServerInfo> GameServers = new List<ServerInfo>();
   
    public static ServerInfo curServer;

    public static Dictionary<long,CharInfo> charactersCanChoose = new Dictionary<long, CharInfo>();

    public static CharInfo curCharacter;

    public static LevelInfo curLevel;

    public static Dictionary<long,CharInfo> players = new Dictionary<long, CharInfo>();

}
