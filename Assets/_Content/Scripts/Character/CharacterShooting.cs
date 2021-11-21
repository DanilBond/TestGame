using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    public GameObject bullet;
    GameObject _muzzle;

    private void Start() => FindMuzzle();

        

    private void Update()
    {
        if(CharacterGlobal.instance.characterMovement.parameters.IsReadyToFire)
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = CharacterGlobal.instance.components.cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, CharacterGlobal.instance.parameters.mask))
            {
                _muzzle.transform.LookAt(hit.point);
                Shoot();
            }

        }
    }

    public void FindMuzzle()
    {
        _muzzle = GameObject.FindGameObjectWithTag("Muzzle");
    }

    void Shoot()
    {
        Instantiate(bullet, _muzzle.transform.position, _muzzle.transform.rotation);
        StartCoroutine(_ProcessShake());
    }

    private IEnumerator _ProcessShake(float shakeIntensity = 25f, float shakeTiming = 0.2f)
    {
        Noise(1, shakeIntensity);
        yield return new WaitForSeconds(shakeTiming);
        Noise(1, 1);
    }

    public void Noise(float amplitudeGain, float frequencyGain)
    {
        CharacterGlobal CG = CharacterGlobal.instance;
        Cinemachine.CinemachineBasicMultiChannelPerlin noise
            = CG.components.cinemachine.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();

        noise.m_AmplitudeGain = amplitudeGain;
        noise.m_FrequencyGain = frequencyGain;
    }
}
