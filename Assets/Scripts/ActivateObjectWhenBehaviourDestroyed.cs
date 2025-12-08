using Unity.VisualScripting;
using UnityEngine;

public class ActivateObjectWhenBehaviourDestroyed : MonoBehaviour
{
    public MonoBehaviour behaviour;
    public GameObject go;

    // Update is called once per frame
    void Update()
    {
        if (behaviour.IsDestroyed())
        {
            go.SetActive(behaviour.IsDestroyed());
            Destroy(this);
        }
    }
}
