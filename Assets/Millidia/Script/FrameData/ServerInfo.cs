using UnityEngine;
using System;
using System.Collections;

public class ServerInfo
{
    public int id;
    public string name;
    public string address;
    public int port;
    public int status;
    public string recommond = "";

    public ServerInfo(SimpleJson.JsonObject obj)
    {
        id = Convert.ToInt32(obj ["id"]);
        name = Convert.ToString(obj ["name"]);
        address = Convert.ToString(obj ["address"]);
        port = Convert.ToInt32(obj ["port"]);       
        if (obj.ContainsKey("status"))
        {
            status = Convert.ToInt32(obj ["status"]);
        }
        if (obj.ContainsKey("content"))
        {
            recommond = Convert.ToString(obj ["content"]);
        }
    }
}
