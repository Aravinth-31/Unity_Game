using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PointsUpdate : MonoBehaviour
{
    // public GameObject pointsText;
    public TextMeshProUGUI pointsText;
    public int points=0;
    // Start is called before the first frame update
    void Start()
    {
        pointsText.text="Points this hand: "+points;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text="Points this hand: "+points;        
    }
}
