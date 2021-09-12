using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public bool isStarted = false;


}
