using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Coin;

    private void Start()
    {
        StartCoroutine(SpawnCoin());
    }
    public void StartTheCoroutine()
    {
        StartCoroutine(SpawnCoin());
       
    }

    public IEnumerator SpawnCoin()
    {

        while (true)
        {
            Instantiate(Coin, new Vector3(Random.Range(-2.0f, 2.0f) -0.25f , -1.67f, 0), Quaternion.identity);
            yield return new WaitForSeconds(3.5f);

        }
            
        
    }
}
