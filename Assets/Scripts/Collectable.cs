using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UI;

public class Collectable : MonoBehaviour
{
    private int candies = 0;
    [SerializeField] public TextMeshProUGUI winNumber;

    [SerializeField] public TextMeshProUGUI number;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
            Destroy(collision.gameObject);
            candies++;
            number.text = ": " + candies;  
            winNumber.text = ": " + candies;
        }
        
    }
}
