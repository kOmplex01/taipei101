using UnityEngine;
using UnityEngine.UI;

public class Ropes : MonoBehaviour
{
    //public Transform upperEnd;
    public Transform Parent;
    public GameObject lowerPoint;
    private GameObject upperPoint;
    public float defaultLength;
    public float k;
    public float b;
    public Rigidbody sphere;
    public int flip = 1;

    public Slider stiffness;
    public Slider lengthchanger;
    public float stiff = 10000;
    public float wirek = 10000;
    public bool wire;
    public float breakingDir;

    //GameObject contact;
    // Start is called before the first frame update

    private void OnEnable()
    {
        defaultLength = (lowerPoint.transform.position - gameObject.transform.position).magnitude;
    }

    void Start()
    {
        upperPoint = gameObject;


        if (!wire)
        {

            stiffness.onValueChanged.AddListener((l) =>
            {
                k = stiff * l;
            });
        }
        else
        {
            k = wirek;
        }

        lengthchanger.onValueChanged.AddListener((l) =>
        {
            defaultLength = (lowerPoint.transform.position - upperPoint.transform.position).magnitude;
        });
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = (lowerPoint.transform.position - upperPoint.transform.position).normalized;
        float newLength = (lowerPoint.transform.position - upperPoint.transform.position).magnitude;
        float difference = newLength - defaultLength;
        float force;
        if (wire)
        {
            //float currForce = k * flip * difference;
            //if(breakingDir < difference)
            {
                //GetComponent<LineRenderer>().enabled = false;
                //gameObject.SetActive(false);
                Debug.Log(difference);
                Debug.Log(Physics.gravity);
            }

            force = Mathf.Clamp(k * flip * difference, 0, sphere.mass * 9.8f / 4f);
        }
        else
        {
            force = k * flip * difference;
        }
        sphere.AddForce(-force * dir - b * sphere.velocity);

        //PivotTo();
        //transform.LookAt(lowerPoint.transform);
    }
}
