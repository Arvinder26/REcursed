using UnityEngine;

public class AnomalyData
{
    public string id;
    public AnomalyType type;
    public string roomID;
    public int severity;
    public bool isActive;
}

public enum AnomalyType
{
    //TODO: implement anomaly type names
}