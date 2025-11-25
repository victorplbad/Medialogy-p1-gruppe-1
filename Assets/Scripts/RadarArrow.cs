using UnityEngine;

public class RadarArrow : MonoBehaviour
{
    public GameObject origin;
    public string targetTag = "trashCheckpoint";
    public GameObject radarArrow;

    private void FixedUpdate()
    {
        if (!origin) return;

        GameObject closestObj = null;
        float range = 9999999;
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
        //Vector3 direction = origin.transform.InverseTransformPoint(closestObj.transform.position);
        Vector3 direction = closestObj.transform.position - origin.transform.position;
        
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg - 90;

        radarArrow.transform.localEulerAngles = new Vector3(0, 0, angle);
    }
}