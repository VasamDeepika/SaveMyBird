using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float time;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver == false)
        {
            time += Time.deltaTime;
            if (Random.Range(0, 100) < 5)
            {
                GameObject en = Pool.instance.Get("Enemy");
                if (en != null)
                {
                    en.transform.position = this.transform.position + new Vector3(8, Random.Range(-1.5f, 4f), 0);
                    en.SetActive(true);

                }
                GameObject food = Pool.instance.Get("Food");
                if (food != null)
                {
                    food.transform.position = this.transform.position + new Vector3(8, Random.Range(-1f, 3f), 0);
                    if (time > 2f) // 2 seconds of time gap between each fruit prefab
                    {
                        time = 0;
                        food.SetActive(true);
                    }
                }
                GameObject life = Pool.instance.Get("Life");
                if (life != null)
                {
                    life.transform.position = this.transform.position + new Vector3(8, Random.Range(-1f, 3f), 0);
                    if (time > 2f)
                    {
                        time = 0;
                        life.SetActive(true);
                    }
                }
            }
        }
    }
}
