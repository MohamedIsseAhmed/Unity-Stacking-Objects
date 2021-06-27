using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private Transform firstPickUp;
    [SerializeField] private  Vector3 vectorBetweenPickUps;
    [SerializeField] private Transform endPoin›ndicator;

    new WaitForSeconds duration = new WaitForSeconds(1f);

    private List<Collider> colliders = new List<Collider>();
    private List<GameObject> targetPickUps = new List<GameObject>();

    bool canColide = true;

    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            targetPickUps.Add(other.gameObject);
            colliders.Add(other);

            other.gameObject.transform.position = firstPickUp.position + vectorBetweenPickUps;
            other.gameObject.transform.parent = transform;
            firstPickUp = other.gameObject.transform;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EndPoint") && canColide)
        {
            foreach (var target in targetPickUps)
            {
                StartCoroutine(TargetPlacement(target));
            }
        }
    }
   private IEnumerator TargetPlacement(GameObject target)
    {
        target.transform.position = endPoin›ndicator.position + new Vector3(0, 0, 1f);
        foreach (var collider in colliders)
        {
            collider.isTrigger = false;
        }
       
        endPoin›ndicator = target.transform;
        target.transform.parent = null;
        canColide = false;
        yield return duration;
    }

}
