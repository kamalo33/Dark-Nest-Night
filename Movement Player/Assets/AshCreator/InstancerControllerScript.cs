using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancerControllerScript : MonoBehaviour
{
    public GameObject ash;
    public float frequence = 0;
    void Start()
    {

        if (frequence > 0)
        {
            InvokeRepeating("putSomeAsh", frequence, frequence);
        }

    }

    private void putSomeAsh()
    {
        Instantiate(ash);
    }
}
