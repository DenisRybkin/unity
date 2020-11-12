using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    private Light myLight;
    public GameObject obj;
    public float range = 5f,moveSpeed = 3f, turnSpeed = 40f;
    public float speed;
    public float rotationSpeed = 100.0f;
    public float xPositionMouse = 2f;
    public float mouse = 5;
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update ()
    {

        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);


        if (Input.GetKeyUp(KeyCode.Space)){
            myLight.enabled = !myLight.enabled;
        }
        if (Input.GetKeyUp(KeyCode.E)){
            obj.SetActive (false);
        }
        if (Input.GetKeyUp(KeyCode.R)){
            obj.GetComponent <Renderer>().material.color = Color.red;
        }
        else if (Input.GetKeyUp(KeyCode.T)){
            obj.GetComponent <Renderer>().material.color = Color.blue;
        }
        else if (Input.GetKeyUp(KeyCode.Y)){
            obj.GetComponent <Renderer>().material.color = Color.green;
        }
    }
    void OnMouseDrag(){
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

            xPositionMouse = Input.GetAxis("MouseX") * mouse;

            Quaternion rotateY = Quaternion.AngleAxis(xPositionMouse, Vector3.up);
            Vector3 pos = new Vector3(rotation * speed * Time.deltaTime, 0, translation * speed * Time.deltaTime);

            transform.Translate(pos);
            transform.rotation *= rotateY;
    }
}
