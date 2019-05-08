using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ashControllerScript : MonoBehaviour
{
    public float movementx = 0;
    public float movementy = 0;
    public float frequence = 0;
    public bool yrandonm = true;
    public float xExtraRangeToBeSummoned = 0;
    public float timetodestroyself = 10;

    private float yrandvalue = 0;


    void Start()
    {
        if (xExtraRangeToBeSummoned != 0)
        {
            xExtraRangeToBeSummoned = Random.Range(-xExtraRangeToBeSummoned, xExtraRangeToBeSummoned * 1.1f);
        }
        //transform.parent = null;
        transform.position = new Vector3(this.transform.position.x - 1 + xExtraRangeToBeSummoned, this.transform.position.y, this.transform.position.z);

        if (frequence > 0)
        {
            InvokeRepeating("Move",frequence,frequence);
            Invoke("destroyMe", timetodestroyself);
        }

    }

    private void Move()
    {
        if (yrandonm)
        {
            yrandvalue = Random.Range(-movementy*2,movementy);
        }
        transform.position = new Vector3(this.transform.position.x + movementx, this.transform.position.y + movementy + yrandvalue, this.transform.position.z);
    }
    private void destroyMe()
    {
        Destroy(gameObject);
    }

}
