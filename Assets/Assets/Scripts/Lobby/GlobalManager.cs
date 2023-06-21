using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager instance { get; private set; }

    [field: SerializeField] public NetworkRunnerController networkRunnerController { get; private set; }
    [SerializeField] private DDOL parentObj;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(parentObj.gameObject);
        }
    }
}
