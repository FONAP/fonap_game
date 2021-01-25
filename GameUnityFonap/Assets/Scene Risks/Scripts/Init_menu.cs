using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Init_menu : MonoBehaviour
{
    public float parallaxSpeed = 0.02f;
    public RawImage clouds;
    public GameObject charter;
    public Vector2 min, max;
    public float speed = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        //charter(transfor.position.x, transfor.position.y);

    }

    // Update is called once per frame
   
    void  FixedUpdate()
    {
        float finalSpeed = parallaxSpeed * Time.deltaTime;
        clouds.uvRect = new Rect(clouds.uvRect.x + finalSpeed, 0f, 1f, 1f);

        //charter.velocity = new Vector2(speed, charter.velocity.x);
        //float positionX = charter(transfor.position.x);

        /*charter.transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, min.x, max.x),
            //Mathf.Clamp(, minCamPosition.y, maxCamPosition.y),
            transform.position.y,
            transform.position.z
        );*/

    }
}
