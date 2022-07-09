using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextToSpeech : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        WindowsVoice.speak("Drücke zum Starten auf den grünen Button");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
