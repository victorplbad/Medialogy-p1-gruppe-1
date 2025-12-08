using Unity.VisualScripting;
using UnityEngine;

public class ActivateObjectWhenBehaviourDestroyed : MonoBehaviour
{
    public MonoBehaviour behaviour;
    public GameObject gameObject;

    // Update is called once per frame
    void Update()
    {
        if (behaviour.IsDestroyed())
        {
            gameObject.SetActive(behaviour.IsDestroyed());
            Destroy(this);
        }
    }
}
