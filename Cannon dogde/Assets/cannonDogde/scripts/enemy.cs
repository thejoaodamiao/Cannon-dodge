using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    
    [SerializeField]
    private float canFire = 0.0f;
    [SerializeField]
    private float fireRate = 0.1f;
    [SerializeField]
    private GameObject BallPrefab;
    [SerializeField]
    private float spawnRate = 2f;
    [SerializeField]
    private bool GameOver = false;
    [SerializeField]
    float timeToBoost = 5f;
    float nextBoost = 0f;
    [SerializeField]
    private float increaser = 0f;

    private float nextSpawn;
    private AudioSource fire;
    


    // Start is called before the first frame update
    public void Start()
    {
        transform.position = new Vector3(0, 2.459f, 0);
        Time.timeScale = 1f;
        nextSpawn = Time.time + spawnRate;
        nextBoost = Time.unscaledTime + timeToBoost;
        fire = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Time.time + increaser > nextSpawn)
        {
            Teleport();
        }

        if (Time.timeSinceLevelLoad > 3f)
        {
            Shoot();
        }

        if (Time.unscaledTime > nextBoost)
        {
            BoostTime();
        }

        if (GameOver == true)
        {
            Destroy(this.gameObject);
        }
        
    }

    public void Teleport()
    {
        nextSpawn = Time.time + spawnRate;
        float randomX = Random.Range(-2.0f, 2.0f);
        transform.position = new Vector3(randomX - 0.25f , 2.459f, 0);
    }

    public void Shoot()
    {
        if (Time.unscaledTime > canFire)
        {
            fire.Play();
            Instantiate(BallPrefab, transform.position, Quaternion.identity);
            canFire = Time.unscaledTime + fireRate;
        }
    }

    public void BoostTime()
    {
        nextBoost = Time.unscaledTime + timeToBoost;
        increaser += 0.028f;
    }


}
