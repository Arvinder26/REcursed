using UnityEngine;

public class AnomalyModel : MonoBehaviour 
{
    private AnomalyData AnomalyData;
    //private AnomalyConfig config; (Uncomment if anomaly config is implemented)

    public AnomalyData spawnAnomaly()
    {
        //TODO: implement anomaly spawn
        return null;
    }

    public void resolveAnomaly(string ID, bool ok)
    {
        //TODO: implement anomaly resolve
    }

    public void actOn(AnomalyData a)
    {
        //TODO: implement 'actOn' anomaly
    }

    public bool isActive()
    {
        //TODO: implement anomaly active state
        return false;
    }
}
