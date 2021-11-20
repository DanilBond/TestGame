using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody _rb;
    private void Awake() { _rb = GetComponent<Rigidbody>(); _rb.AddForce(transform.forward * CharacterGlobal.instance.parameters.bulletForce); }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HitBox>())
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(
                Vector3.forward * CharacterGlobal.instance.parameters.impactForce, transform.position);
            GameObject blood = Instantiate(CharacterGlobal.instance.parameters.bloodParticle, transform.position, Quaternion.identity);
            Destroy(blood, 1f);
            
        }
        Destroy(gameObject,.05f);
    }

}
