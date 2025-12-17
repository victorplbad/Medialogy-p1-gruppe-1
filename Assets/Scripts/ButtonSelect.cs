using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    void Start()
    {
        List<Button> list = new List<Button>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Button b = transform.GetChild(i).GetComponent<Button>();

            if (b == null) continue;

            list.Add(b);
        }

        Button topButton = list[0];
        for (int i = 0;i < list.Count; i++) {
            if (list[i].transform.position.y > topButton.transform.position.y) topButton = list[i];
        }

        EventSystem.current.SetSelectedGameObject(topButton.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EventSystem.current.currentSelectedGameObject)
        {
            try
            {
                EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
            }
            catch { }
        }
    }
}
