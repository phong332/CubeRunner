using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text Text;
   void Start()
    {
        string path = Application.dataPath + "/Score.txt";
        if (Text)
        {
            Text.text = (File.ReadAllText(path));
        }

    }
}
