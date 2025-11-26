using System.Threading;
using UnityEngine;

public class RadarArrow : MonoBehaviour
{
    public string targetTag = "trashCheckpoint";
    public GameObject origin;
    public GameObject radarArrow;

    private void FixedUpdate()
    {
        if (!origin) return;

        GameObject closestObj = null;
        float range = 9999999;                                                                          //Big number that will be larger then whatever real objects distance
        GameObject[] things = GameObject.FindGameObjectsWithTag(targetTag);

        for (int i = 0; i < things.Length; i++)
        {
            float iRange = (things[i].transform.position - origin.transform.position).magnitude;
            if (iRange < range)
            {
                closestObj = things[i];
                range = iRange;
            }
        }

        if (!closestObj) return;

        //Vector3 direction = origin.transform.InverseTransformPoint(closestObj.transform.position);    //Gets angle from boat perspective
        Vector3 direction = closestObj.transform.position - origin.transform.position;                  //Gets angle from absolute posistions
        float angle = -Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        //radarArrow.transform.localEulerAngles = new Vector3(0, 0, angle);
        //radarArrow.transform.localEulerAngles.Set(0, 0, angle);//Y NO WORK

        float angleDiff = radarArrow.transform.localEulerAngles.z - angle;
        if (angleDiff > 180) angleDiff -= 360;

        radarArrow.transform.Rotate(new Vector3(0, 0, angleDiff * -0.15f));
    }
}