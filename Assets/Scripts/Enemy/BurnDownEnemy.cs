using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnDownEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _afterDiyngParticles;
    [SerializeField] private Enemies _enemys;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.gameObject.SetActive(false);
            _enemys.EatEnemy();
            GameObject afterDiyngParticles = (GameObject)Instantiate(_afterDiyngParticles, enemy.gameObject.transform.position, transform.rotation);
            Destroy(afterDiyngParticles, afterDiyngParticles.GetComponent<ParticleSystem>().startLifetime);
        }
    }
}
