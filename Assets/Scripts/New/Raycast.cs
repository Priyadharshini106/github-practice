using UnityEngine;

public class Raycast : MonoBehaviour
{
    GameObject ball;
    public Texture2D cursor;
    public GameObject cube;
    ballMovement ballMove;

    public int points = 30;

    public LineRenderer lineRenderer;
    bool drag, CanMove;
    Vector3 velocity;
    void Start()
    {
        ball = (GameObject)Instantiate(Resources.Load("Sphere"));
        ballMove = ball.AddComponent<ballMovement>();

    }
    // Update is called once per frame
    void Update()
    {
        if (Camera.main == null)
            return; // Prevents null errors

        Vector3 mousePos = Input.mousePosition;
       
        if (mousePos.x < 0 || mousePos.x > Screen.width ||
       mousePos.y < 0 || mousePos.y > Screen.height)
        {
            // Mouse is outside the game view, skip raycast
            return;
        }
        if (Input.GetMouseButtonDown(0)) drag = true;
         if (Input.GetMouseButtonUp(0))drag = false;
        if (drag)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "Wall" && hit.collider.gameObject.layer == 8)
                {
                    CanMove = true;
                    lineRenderer.enabled = true;

                    Vector3 Target = hit.point;
                    Vector3 distance = Target - transform.position;
                    float height = Target.y + transform.position.y; //distance.y+distance.magnitude*0.25f; Debug.Log(""+hit.point.y + ball.transform.position.y);
                    float displacementAlongY = distance.y;
                    Vector3 distanceAlongX = new Vector3(distance.x, 0, distance.z);
                    float time = Mathf.Sqrt(-2 * height / Physics.gravity.y) + Mathf.Sqrt(2 * (displacementAlongY - height) / Physics.gravity.y);
                    Vector3 vy = Vector3.up * Mathf.Sqrt(-2 * Physics.gravity.y * height);
                    Vector3 vx = distanceAlongX / time;
                    velocity = vx + vy;
                    GetTrajectory(velocity, time);
                }


            }
            else 
            {
                CanMove = false;
                lineRenderer.enabled = false;
            }

        }
        else if (lineRenderer.enabled)
        {
            lineRenderer.enabled = false;
            if (CanMove)
            {
                CanMove = false;
                ballMove.AddingForce(velocity);
            }

        }
    }
    

    

    public void GetTrajectory(Vector3 Velocity, float time)
    {
        lineRenderer.positionCount = points;
        for (int i = 0; i < points; i++)
        {
            float t = i / (float)(points - 1) * time;
            Vector3 point = ball.transform.position + Velocity * t + 0.5f * Physics.gravity * t * t;
            lineRenderer.SetPosition(i, point);
        }
    }



}
