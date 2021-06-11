using UnityEngine;
using UnityEngine.UI;

public class Build_Blueprint : MonoBehaviour
{
    [SerializeField] LayerMask LM;

    public RaycastHit hit;
    public Vector3 movePoint;
    public GameObject buildingPrefab;

    public Slider buildingProgress;
    public float buildingPercent;
    public float buildingSpeed;

    public bool canBuild;
    public bool startBuilding;

    public bool canMove;

    void Start()
    {
        canMove = true;
        startBuilding = false;

        buildingPercent = 0f;

        canBuild = true;
        buildingProgress.value = buildingPercent;
        buildingProgress.gameObject.SetActive(false);

        if (canMove == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            

            if (Physics.Raycast(ray, out hit, 6000000f, LM))
            {
                transform.position = hit.point;
            }
        }

        buildingProgress.value = buildingPercent;
    }
    void Update()
    {
        buildingProgress.value = buildingPercent;
        if (canMove == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 6000000f, LM))
            {
                transform.position = hit.point;
            }
        }

        if (Input.GetMouseButtonDown(0) && canBuild == true)
        {
            startBuilding = true;
            canMove = false;
        }

        if(startBuilding == true && canMove == false)
        {
            buildingProgress.gameObject.SetActive(true);
            buildingPercent += buildingSpeed * Time.deltaTime;

            if (buildingProgress.value == 100)
            {
                buildingPercent = 100f;
                Instantiate(buildingPrefab, this.transform.position, this.transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Lava" || other.gameObject.tag == "Building" || other.gameObject.tag == "Trooper")
        {
            canBuild = false;
        }
    }
}
