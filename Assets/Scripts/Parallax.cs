using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

    public Transform[] backgrounds;
    public float[] parallaxDistance;
    public float moveParallax;

    Vector3 prevCameraPos;

	// Use this for initialization
	void Start () {

        prevCameraPos = transform.position;
        parallaxDistance = new float[backgrounds.Length];
        for(int i = 0; i<parallaxDistance.Length; ++i)
        {
            parallaxDistance[i] = backgrounds[i].position.z * -1;
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LateUpdate()
    {
        for(int i = 0; i<backgrounds.Length; ++i)
        {
            Vector3 parallax = (prevCameraPos - transform.position) * (parallaxDistance[i]/moveParallax);
            backgrounds[i].position = new Vector3(backgrounds[i].position.x + parallax.x, backgrounds[i].position.y + parallax.y, backgrounds[i].position.z);
        }

        prevCameraPos = transform.position;

    }
}
