using UnityEngine;

public class SpawnDinos : MonoBehaviour
{
    private scoreControl logic;
    public GameObject L1Dino;
    public GameObject L2Dino;
    public GameObject cD;
    public float spawnRate = 5f;
    private float timer = 0f;
    private int tick = 0;
    public AudioSource audat;

    void Start()
    {
        logic = GameObject.Find("LogicManager").GetComponent<scoreControl>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate && logic.gamePlaying == true)
        {
            timer = 0f;
            int chance = Random.Range(0, 10);

            Vector3 spawnPos = new Vector3(cD.transform.position.x - 2, 0, 0);

            if (tick > 6 && chance == 5 && logic.gamePlaying == true)
                Instantiate(L2Dino, spawnPos, Quaternion.identity);
            else
                Instantiate(L1Dino, spawnPos, Quaternion.identity);

            tick++;

            if (tick % 2 == 0 && spawnRate > 1)
            {
                spawnRate *= 0.9f; // reduce by 10% every 5 ticks
            }
        }
        if (logic.gamePlaying == false)
        {
            audat.Stop();
        }
    }
}
