using UnityEngine;
using UnityEngine.UI;

public class KilledEnemiesUI : MonoBehaviour
{
    private Text killedEnemiesText;

    // Start is called before the first frame update
    void Start()
    {
        killedEnemiesText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        killedEnemiesText.text = "Killed Enemies: " + GameManger.instance.killedEnemies;
    }
}
