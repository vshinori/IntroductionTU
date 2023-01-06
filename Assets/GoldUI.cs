using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    public int goldCount;
    public Text goldCountText;
    public Text goldCountEnd;

    public static GoldUI instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGold(int count)
    {
        goldCount += count;
        goldCountText.text = goldCount.ToString();
        goldCountEnd.text = goldCount.ToString();
    }
}
