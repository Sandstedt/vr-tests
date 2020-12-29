using UnityEngine;
public class GameManager : MonoBehaviour
{
    void Awake()
    {
        OVRPlugin.systemDisplayFrequency = 90.0f;
    }
}
