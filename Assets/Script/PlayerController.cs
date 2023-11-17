using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController cc;

    [Header("Wheels Collider")]

    public WheelCollider FL_WHeelColl;
    public WheelCollider FR_WHeelColl;
    public WheelCollider BL_WHeelColl;
    public WheelCollider BR_WHeelColl;

    [Header("Wheel Transform")]

    public Transform FL_WheelTrans;
    public Transform FR_WheelTrans;
    public Transform BL_WheelTrans;
    public Transform BR_WheelTrans;

    [Header("Truck Engine")]

    public float AccelerationForce = 200f;
    public float BreakingForce = 3000;
    private float presentBreakForce = 0f;
    private float presentAcceleration = 0f;

    [Header("Truck Steering")]
    public float wheelsTorque = 45f;
    public float presentTurnAngle = 0f;

    [Header(" Sound")]

    public AudioSource AccelaerationSound;
    public AudioSource StopSound;
    public AudioSource PickupSound;

    //public Transform[] debrisCollectionPoints; // Reference to the parent GameObject containing collection points.
    public GameObject[] Trashes;
    private bool isCollecting = false;
    public GameObject PickUpButton;

    private bool point_1;
    private bool point_2;
    private bool point_3;
    private bool point_4;
    private bool point_5;

    public TextMeshProUGUI collectedCountText; // UI Text for displaying collected count
    public TextMeshProUGUI depositedCountText; // UI Text for displaying deposited count

    private int collectedCount = 0;
    private int depositedCount = 0;

    public TextMeshProUGUI FInalPickupCount;
    public TextMeshProUGUI FInalDepositCount;
    public GameObject FinishUi;
    public GameObject texts;

    public ParticleSystem[] smokeEffect;

    void Start()
    {
        PickUpButton.SetActive(false);
        FinishUi.SetActive(false);

        for(int i= 0; i <= smokeEffect.Length-1; i++)
        {
            smokeEffect[i].Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveTruck();
        SteeringTruck();

        if(Input.GetKeyDown(KeyCode.B))
        {
            ApplyBreaks();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            //CollectDebris();
           
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("CollectionPoint") )
    //    {
    //        Debug.Log("reached");
    //        collectedCount += 10;
    //        collectedCountText.text =  collectedCount.ToString();
    //    }
    //}

    //private void CollectDebris()
    //{
    //    isCollecting = true;

    //    foreach (Transform collectionPoint in debrisCollectionPoints.transform)
    //    {
    //        Collider[] debrisToCollect = Physics.OverlapSphere(debrisCollectionPoints.transform.position, 2f, LayerMask.GetMask("Debris"));

    //        foreach (Collider debris in debrisToCollect)
    //        {
    //            //if(debris.transform.parent == debrisCollectionPoints)
    //            //    {
    //            //Destroy(debris.gameObject); // You may want to pool or manage collected debris differently.
    //            debris.gameObject.SetActive(false);
    //            Debug.Log("picked up");

    //        }
    //    }
    //    isCollecting = false;
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    // Check if the player enters a deposit area (e.g., with a tag "DepositArea")
    //    if (other.CompareTag("DepositArea"))
    //    {
    //        // Deposit collected debris and update counts
    //        depositedCount += collectedCount;
    //        collectedCount = 0;

    //        // Update UI text for deposited and collected counts
    //        //depositedCountText.text = "Deposited: " + depositedCount.ToString();
    //        //collectedCountText.text = "Collected: " + collectedCount.ToString();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("collectionPoint_1"))
        {
            point_1 = true;
            PickUpButton.SetActive(true);
        }
        if(other.CompareTag("collectionPoint_2"))
        {
            point_2 = true;
            PickUpButton.SetActive(true);
          
        }
        if(other.CompareTag("collectionPoint_3"))
        {
            point_3 = true;
            PickUpButton.SetActive(true);
        }
        if(other.CompareTag("collectionPoint_4"))
        {
            point_4 = true;
            PickUpButton.SetActive(true);
        }
        if(other.CompareTag("collectionPoint_5"))
        {
            point_5 = true;
            PickUpButton.SetActive(true);
        }

        if (other.CompareTag("Finish"))
        {
            FInishUI();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("collectionPoint_1"))
        {
            point_1 = false;
            PickUpButton.SetActive(false);
        }
        if (other.CompareTag("collectionPoint_2"))
        {
            point_2 = false;
            PickUpButton.SetActive(false);
        }
        if (other.CompareTag("collectionPoint_3"))
        {
            point_3 = false;
            PickUpButton.SetActive(false);
        }
        if (other.CompareTag("collectionPoint_4"))
        {
            point_4 = false;
            PickUpButton.SetActive(false);
        }
        if (other.CompareTag("collectionPoint_5"))
        {
            point_5 = false;
            PickUpButton.SetActive(false);
        }
    }

    public void Collect()
    {
        if (point_1)
        {
            Trashes[0].SetActive(false);
            smokeEffect[0].Play();
            collectedCount++;
            depositedCount += 20;
        }
        if (point_2)
        {
            Trashes[1].SetActive(false);
            smokeEffect[1].Play();
            collectedCount++;
            depositedCount += 20;
        }
        if (point_3)
        {
            Trashes[2].SetActive(false);
            smokeEffect[2].Play();
            collectedCount++;
            depositedCount += 20;
        }
        if (point_4)
        {
            Trashes[3].SetActive(false);
            smokeEffect[3].Play();
            collectedCount++;
            depositedCount += 20;
        }
        if (point_5)
        {
            Trashes[4].SetActive(false);
            smokeEffect[4].Play();
            collectedCount++;
            depositedCount += 20;
        }
        collectedCountText.text = collectedCount.ToString();
        depositedCountText.text = depositedCount.ToString();

        PickupSound.Play();
        PickUpButton.SetActive(false);
    }
    public void FInishUI()
    {
        FinishUi.SetActive(true);
        texts.SetActive(false);
        AccelerationForce = 0f;
        collectedCountText.enabled = false;
        depositedCountText.enabled = false;

        FInalPickupCount.text = collectedCount.ToString();
        FInalDepositCount.text = depositedCount.ToString();
    }


    private void MoveTruck()
    {
        // Moving the car forward and backward
        BL_WHeelColl.motorTorque = presentAcceleration;
        BR_WHeelColl.motorTorque = presentAcceleration;

        presentAcceleration = AccelerationForce * Input.GetAxis("Vertical");

        if (presentAcceleration > 0)
        {
            AccelaerationSound.Play();
        }
        else if (presentAcceleration <=  0)
        {
            StopSound.Play();
        }
       
    }

    private void SteeringTruck()
    {
        presentTurnAngle = wheelsTorque * Input.GetAxis("Horizontal");
        FL_WHeelColl.steerAngle = presentTurnAngle;
        FR_WHeelColl.steerAngle = presentTurnAngle;

    }
    private void SteeringWheel(WheelCollider Wc, Transform Wt)
    {
        Vector3 position;
        Quaternion Rotation;

        Wc.GetWorldPose(out position, out Rotation);

        Wt.position = position;
        Wt.rotation = Rotation;
    }
    public void ApplyBreaks()
    {
        StartCoroutine(CarBreak());
    }

    IEnumerator CarBreak()
    {
        presentBreakForce = BreakingForce;

        FL_WHeelColl.brakeTorque = presentBreakForce;
        BR_WHeelColl.brakeTorque = presentBreakForce;
        BL_WHeelColl.brakeTorque = presentBreakForce;
        BR_WHeelColl.brakeTorque = presentBreakForce;

        yield return new WaitForSeconds(2f);

        presentBreakForce = 0f;

        FL_WHeelColl.brakeTorque = presentBreakForce;
        BR_WHeelColl.brakeTorque = presentBreakForce;
        BL_WHeelColl.brakeTorque = presentBreakForce;
        BR_WHeelColl.brakeTorque = presentBreakForce;

    }
}
