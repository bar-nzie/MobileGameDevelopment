using UnityEngine;
using UnityEngine.EventSystems;

public class Placement : MonoBehaviour
{

    public GameObject PlacementPrefab;
    public GameObject PlacementPrefab2;
    public GameObject chickenPen;
    public GameObject cowPen;
    public GameObject pigPen;
    public GameObject hay;
    private GameObject currentPlacement;
    private GameObject desiredObject;
    public LayerMask groundMask;
    public Color validColor = Color.white;
    public Color invalidColor = Color.red;
    private Renderer boxRenderer;
    private bool isPlacing = false;
    private bool placementActive = false;
    private float spawnTime;
    private float activationDelay = 0.2f;
    public CameraMovement cam;
    private GameObject toDestroy;


    // Update is called once per frame
    void Update()
    {
        if (!isPlacing) return;

        if (!placementActive )
        {
            if(Time.time - spawnTime >= activationDelay)
            {
                placementActive = true;
            }
            else return;
        }
        HandleTouchInput();
    }

    public void StartPlacementChicken()
    {
        if (isPlacing) return;
        isPlacing = true;
        currentPlacement = Instantiate(PlacementPrefab);
        boxRenderer = currentPlacement.GetComponent<Renderer>();
        placementActive = false ;
        spawnTime = Time.time;
        cam.SetCanMove(false);
        desiredObject = chickenPen;
    }

    public void StartPlacementCow()
    {
        if (isPlacing) return;
        isPlacing = true;
        currentPlacement = Instantiate(PlacementPrefab);
        boxRenderer = currentPlacement.GetComponent<Renderer>();
        placementActive = false;
        spawnTime = Time.time;
        cam.SetCanMove(false);
        desiredObject = cowPen;
    }

    public void StartPlacementPig()
    {
        if (isPlacing) return;
        isPlacing = true;
        currentPlacement = Instantiate(PlacementPrefab);
        boxRenderer = currentPlacement.GetComponent<Renderer>();
        placementActive = false;
        spawnTime = Time.time;
        cam.SetCanMove(false);
        desiredObject = pigPen;
    }

    public void StartPlacementHay()
    {
        if (isPlacing) return;
        isPlacing = true;
        currentPlacement = Instantiate(PlacementPrefab2);
        boxRenderer = currentPlacement.GetComponent<Renderer>();
        placementActive = false;
        spawnTime = Time.time;
        cam.SetCanMove(false);
        desiredObject = hay;
    }

    public void StartMovementHay(GameObject hayMove)
    {
        if (isPlacing) return;
        isPlacing = true;
        currentPlacement = Instantiate(PlacementPrefab2);
        boxRenderer = currentPlacement.GetComponent<Renderer>();
        placementActive = false;
        spawnTime = Time.time;
        cam.SetCanMove(false);
        desiredObject = hay;
        toDestroy = hayMove;
    }

    public void StartMovementChicken(GameObject hayMove)
    {
        if (isPlacing) return;
        isPlacing = true;
        currentPlacement = Instantiate(PlacementPrefab);
        boxRenderer = currentPlacement.GetComponent<Renderer>();
        placementActive = false;
        spawnTime = Time.time;
        cam.SetCanMove(false);
        desiredObject = chickenPen;
        toDestroy = hayMove;
    }

    public void StartMovementCow(GameObject hayMove)
    {
        if (isPlacing) return;
        isPlacing = true;
        currentPlacement = Instantiate(PlacementPrefab);
        boxRenderer = currentPlacement.GetComponent<Renderer>();
        placementActive = false;
        spawnTime = Time.time;
        cam.SetCanMove(false);
        desiredObject = cowPen;
        toDestroy = hayMove;
    }

    public void StartMovementPig(GameObject hayMove)
    {
        if (isPlacing) return;
        isPlacing = true;
        currentPlacement = Instantiate(PlacementPrefab);
        boxRenderer = currentPlacement.GetComponent<Renderer>();
        placementActive = false;
        spawnTime = Time.time;
        cam.SetCanMove(false);
        desiredObject = pigPen;
        toDestroy = hayMove;
    }

    void HandleTouchInput()
    {
        if (Input.touchCount == 0) return;
        Touch touch = Input.GetTouch(0);

        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            return;
        } 

        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray, out RaycastHit hit, 1000f, groundMask))
        {
            currentPlacement.transform.position = hit.point;

            bool isValid = isPositionValid();

            if (isValid)
            {
                boxRenderer.material.color = validColor;
            }
            else
            {
                boxRenderer.material.color=invalidColor;
            }

            if (touch.phase == TouchPhase.Ended && isValid)
            {
                FinalisePlacement();
            }
            else if (touch.phase == TouchPhase.Ended && !isValid)
            {
                CancelPlacement();
            }
        }
    }

    bool isPositionValid()
    {
        Collider[] hits = Physics.OverlapBox(currentPlacement.transform.position, currentPlacement.transform.localScale / 2, Quaternion.identity);
        return hits.Length <= 2;
    }

    void FinalisePlacement()
    {
        Vector3 place = new Vector3(currentPlacement.transform.position.x, currentPlacement.transform.position.y + 0.4f, currentPlacement.transform.position.z);
        Instantiate(desiredObject, place, Quaternion.identity);
        Destroy(currentPlacement);
        Destroy(toDestroy);
        currentPlacement = null;
        boxRenderer = null;
        isPlacing = false;
        cam.SetCanMove(true);
    }

    void CancelPlacement()
    {
        Destroy(currentPlacement);
        currentPlacement = null;
        isPlacing=false;
        cam.SetCanMove(true);
    }
}
