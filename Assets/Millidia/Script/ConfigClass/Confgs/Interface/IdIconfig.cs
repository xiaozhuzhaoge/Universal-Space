using UnityEngine;
using System.Collections;

public abstract class IdIconfig : IConfig
{
	public int id; 

	public virtual void Init(SimpleJson.JsonObject o)
	{
	}
}
