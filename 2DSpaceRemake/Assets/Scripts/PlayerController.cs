using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick input;
    public float moveSpeed;
    public float maxRotation = 25f;

    private Rigidbody rb;
    private float minX, maxX, minY, maxY;

    public int currentHealth;
    public int maxHealth = 100;
    public InGameManager manager;

    public GameObject deathMenu;

    public Transform[] misslespawnPoints;
    public GameObject rocketprefab;

    public float fireInterval = 2f;
    private bool canFire = true;

    public ScriptableObjectshop sco;

    private Vector3 raycastDirection = new Vector3(0f, 0f, 1f);
    public float raycastDst = 100f;
    int layerMask;
    private List<GameObject> previoustargets = new List<GameObject>(); 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetUpBoundries();
        currentHealth = maxHealth;
        layerMask = LayerMask.GetMask("EnemyRaycastLayer");
        Time.timeScale = 1;
        moveSpeed = sco.speed;
    }

   
    void Update()
    {
        MovePlayer();
        RotatePlayer();

        CalculateBoundries();

        RaycastAsteroids();
    }

    private void RaycastAsteroids()
    {
        List<GameObject> currentTarget = new List<GameObject>();
        foreach(Transform misslespawnpoint in misslespawnPoints)
        {
            RaycastHit hit;
            Ray ray = new Ray(misslespawnpoint.position, raycastDirection);
            if(Physics.Raycast(ray, out hit, raycastDst,layerMask))
            {
                GameObject target = hit.transform.gameObject;
                currentTarget.Add(target);
            }
        }
        bool listsChanged = false;
        // check is previous target and current are the same
        if (currentTarget.Count != previoustargets.Count)
        {
            listsChanged = true;
        }
        else
        {
            for(int i = 0; i< currentTarget.Count; i++)
            {
                if(currentTarget[i] != previoustargets[i])
                {
                    listsChanged = true;
                }
            }
        }

        if(listsChanged == true)
        {
            // update asteroids
            entitiesController.Instance.UpdateAsteroids(currentTarget);
            previoustargets = currentTarget;
        }

    }

    private void RotatePlayer()
    {
        float currentX = transform.position.x;
        float newRotatinZ;

        if(currentX < 0)
        {
            //rotate negative
            newRotatinZ = Mathf.Lerp(0f, -maxRotation, currentX / minX);
        }
        else
        {
            //rotate positive
            newRotatinZ = Mathf.Lerp(0f, maxRotation, currentX / maxX);
        }

        Vector3 currentRotationVector3 = new Vector3(0f, 0f, newRotatinZ);
        Quaternion newRotation = Quaternion.Euler(currentRotationVector3);
        transform.localRotation = newRotation;
    }

    public void FireRockets()
    {
        if (canFire)
        {

            // fire rockets
            foreach(Transform t in misslespawnPoints)
            {
                Instantiate(rocketprefab, t.position, Quaternion.identity);
            }

            canFire = false;
            StartCoroutine(ReloadDelay());
        }
    }

    private IEnumerator ReloadDelay()
    {
        //play reload sound
        yield return new WaitForSeconds(fireInterval);

        canFire = true;
    }

    private void CalculateBoundries()
    {
        Vector3 currentPosition = transform.position;

        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);

        transform.position = currentPosition;
    }

    private void SetUpBoundries()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorners = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, camDistance));
        Vector2 topCorners = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, camDistance));

        //calculate the size of the gameobject
        Bounds gameObjectBouds = GetComponent<Collider>().bounds;
        float objectWidth = gameObjectBouds.size.x;
        float objectHeight = gameObjectBouds.size.y;
        


        minX = bottomCorners.x + objectWidth;
        maxX = topCorners.x - objectWidth;

        minY = bottomCorners.y + objectHeight;
        maxY = topCorners.y - objectHeight;

        entitiesController.Instance.maxX = maxX;
        entitiesController.Instance.minX = minX;
        entitiesController.Instance.maxY = maxY;
        entitiesController.Instance.minY = minY;
    }

    private void MovePlayer()
    {
        float horizontalMovement = input.Horizontal;
        float verticalMovement = input.Vertical;

        Vector3 movementVector = new Vector3(horizontalMovement, verticalMovement, 0f);

        rb.velocity = movementVector * moveSpeed;
        
    }

    public void OnAsteroidImpact()
    {
        currentHealth--;
        // change health bar
        manager.ChangeHealthbar(maxHealth, currentHealth);
        if(currentHealth == 0)
        {
            OnPlayerDeath();
        }
    }

    private void OnPlayerDeath()
    {
        //play animation
        Debug.Log("Player Died(duh duh duhhhh)");
        deathMenu.SetActive(true);
    }
}
