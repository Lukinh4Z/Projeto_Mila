using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Combat
{
    public class Fracture : MonoBehaviour
    {
        [Tooltip("\"Fractured\" is the object that this will break into")]
        public GameObject fractured;
        private GameObject fractures;
        public float lifeTime = 0.5f;


        public void FractureObject()
        {
            fractures = Instantiate(fractured, transform.position, transform.rotation);
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<DamageableMisc>().enabled = false;

            StartCoroutine(KillFracture(lifeTime));
        }

        IEnumerator KillFracture(float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(fractures);
        }
    }
}
