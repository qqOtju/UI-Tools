using UnityEngine;

public class Vsync : MonoBehaviour
{
    void Start()
    {
        QualitySettings.vSyncCount = -1;
    }
}