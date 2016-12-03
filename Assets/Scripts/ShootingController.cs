using UnityEngine;
using System.Collections;

public class ShootingController : MonoBehaviour {

    public GameObject projectile;
    Transform origin;

	// Use this for initialization
	void Start () {
        origin = GetComponentInChildren<Camera>().transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            Shoot(ArrowType.Blue);
        else if (Input.GetMouseButtonDown(1))
            Shoot(ArrowType.Red);
	}

    void Shoot(ArrowType type)
    {
        var proj = (Instantiate(projectile, origin.position + new Vector3(0f, -0.2f, 0f), origin.rotation) as GameObject).GetComponent<ArrowController>();
        proj.arrowType = type;
    }
}
