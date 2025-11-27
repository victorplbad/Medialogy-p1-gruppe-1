using UnityEngine;

public class RadarArrow : MonoBehaviour
{
    public string targetTag = "trashCheckpoint";
    public GameObject origin;
    public GameObject radarArrow;

    private void FixedUpdate()
    {
        if (!origin) return;

        GameObject closestObject = null;
        float range = 9999999;                                                                          //Big number that will be larger then whatever real objects distance

        GameObject[] objects = GameObject.FindGameObjectsWithTag(targetTag);

        for (int i = 0; i < objects.Length; i++)
        {
            float iRange = (objects[i].transform.position - origin.transform.position).magnitude;
            if (iRange < range)
            {
                closestObject = objects[i];
                range = iRange;
            }
        }

        if (!closestObject) return;

        //Vector3 direction = origin.transform.InverseTransformPoint(closestObj.transform.position);    //Gets angle from boat perspective
        Vector3 direction = closestObject.transform.position - origin.transform.position;               //Gets angle from absolute posistions
        float angle = Mathf.Atan2(-direction.x, direction.z) * Mathf.Rad2Deg;

        //radarArrow.transform.localEulerAngles.Set(0, 0, angle);//Y NO WORK
        //radarArrow.transform.localEulerAngles = new Vector3(0, 0, angle);

        float angleDiff = radarArrow.transform.localEulerAngles.z - angle;
        if (angleDiff > 180) angleDiff -= 360;

        radarArrow.transform.Rotate(new Vector3(0, 0, angleDiff * -0.15f));
    }
}
