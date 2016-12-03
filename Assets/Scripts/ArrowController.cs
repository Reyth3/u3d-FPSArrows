using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {

    public ArrowType arrowType;
    public float speed = 5f;

    Renderer r;

    Vector3 gravity = Vector3.up * -9.81f;
    float drag = 0.01f;
    Vector3 velocity;

    float lifteTime, force;
    float gravDivider = 4;
    bool isMoving;

    public void Fire()
    {
        force = speed;
        velocity = transform.forward * force;
        isMoving = true;
    }

    // Use this for initialization
    void Start () {
        r = GetComponentInChildren<Renderer>();
        if (arrowType == ArrowType.Blue)
            r.material.color = new Color(0.5f, 0.5f, 1f);
        else if (arrowType == ArrowType.Red)
            r.material.color = new Color(1f, 0.5f, 0.5f);
        Fire();
    }
	
	// Update is called once per frame
	void Update () {
        if (isMoving)
        {
            velocity += (gravity / gravDivider) * Time.deltaTime;
            velocity -= velocity * Mathf.Pow(drag, (Time.time - lifteTime) / gravDivider);
            Vector3 moveAmount = (velocity * Time.deltaTime);
            transform.LookAt(transform.position + moveAmount);
            transform.position += moveAmount;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, r.bounds.size.z / 2 + 0.2f, 1 << 10))
                OnCollision();
        }
    }

    void OnCollision()
    {
        Debug.Log("Collided!");
        isMoving = false;
        transform.Translate(0f, 0f, 0.15f, Space.Self);
    }
}

public enum ArrowType { Blue, Red }
