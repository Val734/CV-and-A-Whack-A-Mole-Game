using UnityEngine;

public class MoleSpawnerController : MonoBehaviour
{
    [SerializeField] GameObject scoreManager;
    public GameObject[] hole_prefab;

    int molePrefabForInstantiate = 0;
    int timesForSpawnMoles = 0;
    int moleChangeCounter = 0;

    float actualSpawnTime;
    int holes;
    int molePosition;
    float timer;

    void OnEnable()
    {
        TimeBehavior.OnGameFinished += ChangeSpawnTimeAndPrefab;
        holes = gameObject.transform.childCount;
        actualSpawnTime = GetSpawnTime();
    }

    void Update()
    {
        timer = FindObjectOfType<TimeBehavior>().timer; 
        actualSpawnTime -= Time.deltaTime;

        if (actualSpawnTime < 0f)
        {
            ConsultHoleAvailable();
            actualSpawnTime = GetSpawnTime();
        }
    }

    public void ConsultHoleAvailable()
    {
        if (AllHollesAreFull())
        {
            return;
        }

        bool moleSpawned = false;

        molePosition = Random.Range(0, holes);

        while (!moleSpawned)
        {
            Transform hole = gameObject.transform.GetChild(molePosition);
            bool HoleAvaiable = hole.GetComponent<SpawnMoles>().MoleChecker();

            if (HoleAvaiable)
            {
                moleSpawned = true;
                hole.GetComponent<SpawnMoles>().SpawnMole(hole_prefab[molePrefabForInstantiate]);

            }
            else
            {
                molePosition++;
                if (molePosition >= holes)
                {
                    molePosition = 0;
                }
            }
        }
    }

    private bool AllHollesAreFull()
    {
        for (int i = 0; i < holes; i++)
        {
            Transform hole = gameObject.transform.GetChild(i);
            if (hole.GetComponent<SpawnMoles>().MoleChecker())
            {
                return false;
            }
        }
        return true;
    }

    public void OnMoleKilled()
    {
        scoreManager.GetComponent<ScoreController>().AddScore();
    }

    private void ChangeSpawnTimeAndPrefab()
    {
        moleChangeCounter++;
        if (moleChangeCounter == 2 || moleChangeCounter == 4 || moleChangeCounter == 5)
        {
            molePrefabForInstantiate++;
        }
        timesForSpawnMoles++;
        actualSpawnTime = GetSpawnTime();
    }

    private float GetSpawnTime()
    {
        if (timer > 50f)
        {
            return 3f;
        }
        else if (timer >40f)
        {
            return 2f;
        }
        else if (timer>30f)
        {
            return 1f;
        }
        else if (timer>20f)
        {
            return 0.5f;
        }
        else if (timer>10f)
        {
            return 0.25f;
        }
        else
        {
            return 0.15f;
        }
    }
}

