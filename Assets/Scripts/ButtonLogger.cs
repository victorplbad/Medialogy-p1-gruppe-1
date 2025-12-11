using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLogger : MonoBehaviour
{
    public string filename = "/Debug.txt";

    FileInfo fileInfo;

    private void Start()
    {
        fileInfo = new FileInfo(Application.dataPath + filename);
        WriteFile(fileInfo.FullName, "\n// Starting log.");
        WriteFile(fileInfo.FullName, "\n// " + this.gameObject.name);
        WriteFile(fileInfo.FullName, "\n// " + System.DateTime.Now.ToString());

        foreach (GameObject go in FindTheChildren(this.gameObject, 10))
        {
            Button b = go.GetComponent<Button>();
            if (b) b.onClick.AddListener(delegate { ButtonClicked(b); });
        }
    }

    List<GameObject> FindTheChildren(GameObject root, int searchDepth, int currentDepth = 0)
    {   //Search depth limited so we dont have stack overflows around these parts
        var targets = new List<GameObject>();
        targets.Add(root);
        //Debug.Log("Discovered " + root.transform.name + " at depth " + currentDepth);

        if (currentDepth++ >= searchDepth) return targets;

        for (int i = 0; i < root.transform.childCount; i++)
        {
            targets.AddRange(FindTheChildren(root.transform.GetChild(i).gameObject, searchDepth, currentDepth));
        }

        return targets;
    }

    void ButtonClicked(Button button)
    {
        string name = button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        WriteFile(fileInfo.FullName, "\n" + name);
    }

    public void WriteFile(string filename, string str)
    {
        using (FileStream stream = File.OpenWrite(filename))
        {
            stream.Seek(0, SeekOrigin.End);
            stream.Write(Encoding.ASCII.GetBytes(str), 0, str.Length);
        }
    }
    
    /*public byte[] ReadFile(string filename, long start, int length)
    {
	    if (!File.Exists(filename))
        {
		    Debug.Log("Could not Open the file: " + filename + " for reading.");
            return new byte[0];
	    }
        
        using (FileStream stream = File.OpenRead(filename))
        {
            byte[] buffer = new byte[length];

            stream.Seek(start, SeekOrigin.Begin);
            stream.Read(buffer, 0, length);
            return buffer;
        }
    }*/
}
