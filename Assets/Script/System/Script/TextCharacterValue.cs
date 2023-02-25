using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCharacterValue : MonoBehaviour
{
    public List<Value> trackValue;
    public Character character;

    // ReSharper disable Unity.PerformanceAnalysis
    void UpdateText()
    {
        foreach (Value i in trackValue)
        {
            string str = character.statsContainer.GetText(i);
            GetComponent<Text>().text = str;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Value i in trackValue)
        {
            character.statsContainer.Subscribe(UpdateText, i);
            UpdateText();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
