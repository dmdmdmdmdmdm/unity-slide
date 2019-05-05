using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestTextScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private TextMeshPro tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = player.GetComponent<PlayerMovement>().rotSpeedActual.ToString("F3") ;
    }
}
