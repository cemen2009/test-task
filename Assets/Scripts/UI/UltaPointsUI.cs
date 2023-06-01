using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltaPointsUI : MonoBehaviour
{
    private Text ultaPointsText;

    // Start is called before the first frame update
    void Start()
    {
        ultaPointsText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ultaPointsText.text = "UltaPoints: " + GameManger.instance.ultaPoints + "/350";
    }
}
