using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;

public class GetCoins : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (File.Exists("c:/temp/test.txt"))
        {
            moneyText.text = File.ReadLines("c:/temp/test.txt").First();
        }
    }
}
