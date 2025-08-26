using System.Collections.Generic;
using UnityEngine;

public class UIModel
{
    public Queue<string> messages = new Queue<string>();
    public bool crosshairVisible;

    public void pushMessage(string message)
    {
        //TODO: implement message push
    }

    public string popMessage()
    {
        return null;
        //TODO: implement message pop
    }
}
