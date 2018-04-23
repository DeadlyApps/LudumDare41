using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(FriendlyGoldManager))]
public class FriendlyUnit : MonoBehaviour
{
    private float speed = 50;

    [SerializeField]
    private float normalSpeed = 50;


    [SerializeField]
    private float hasteSpeed = 75;

    [SerializeField]
    private float slowSpeed = 25;

    [SerializeField]
    private float maxHasteDuration = 3f;

    private float hasteDuration = 0;

    [SerializeField]
    private float maxSlowDuration = 3f;

    private float slowDuration = 0;

    private Transform target;

    private NavMeshAgent navMeshAgent;
    private Mine[] mines;
    private Spawn[] spawns;
    private FriendlyGoldManager goldManager;
    private bool hasGold = false;
    private int mineIndex;
    private int spawnIndex;
    private float freezeDuration;

    public event Action OnKill = delegate { };

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        mines = FindObjectsOfType<Mine>();
        spawns = FindObjectsOfType<Spawn>();
        goldManager = GetComponent<FriendlyGoldManager>();
        speed = normalSpeed;
    }

    private void Start()
    {
        GameManager.Instance.AddPopulation(1);
    }

    internal void ActivateHaste()
    {
        hasteDuration = maxHasteDuration;
    }

    internal void ActivateSlow()
    {
        slowDuration = maxSlowDuration;
    }

    private void OnDestroy()
    {
        GameManager.Instance.RemovePopulation(1);
    }

    private void Update()
    {
        AcquireTarget();

        speed = normalSpeed;
        if (hasteDuration > 0)
        {
            speed = hasteSpeed;
        }
        if (slowDuration > 0)
        {
            speed = slowSpeed;
        }

        navMeshAgent.speed = speed;
        navMeshAgent.isStopped = freezeDuration > 0;

        hasteDuration -= Time.deltaTime;
        slowDuration -= Time.deltaTime;
        freezeDuration -= Time.deltaTime;

    }

    private void AcquireTarget()
    {
        if (target == null)
        {
            if (!goldManager.HasGold())
            {
                SetTarget(mines[mineIndex++].transform);
                mineIndex = mineIndex % mines.Length;
            }
            else
            {
                SetTarget(spawns[spawnIndex++].transform);
                spawnIndex = spawnIndex % spawns.Length;
            }
        }
        else if (Vector3.Distance(target.position, transform.position) < 1f)
        {
            target = null;
        }
    }

    private void SetTarget(Transform transform)
    {
        target = transform;
        navMeshAgent.destination = transform.position;
        navMeshAgent.isStopped = false;
    }

    internal void Freeze(float freezeDuration)
    {
        this.freezeDuration = freezeDuration;
        navMeshAgent.isStopped = true;
    }

    internal void Kill()
    {
        OnKill();
        Destroy(gameObject);
    }
}
