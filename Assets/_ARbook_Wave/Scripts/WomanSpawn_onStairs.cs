using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanSpawn_onStairs : MonoBehaviour
{
    [SerializeField] GameObject woman_staris, door;
    [SerializeField] List<Transform> spawnTrm;

    IEnumerator womanCoroution;

    float curTime;
    [SerializeField]
    float doorTiming = 82;

    AudioSource stairsAudio;
    void OnEnable()
    {
        stairsAudio = GetComponent<AudioSource>();

        door.SetActive(false);

        womanCoroution = WomanSawanAgain();
        StartCoroutine(womanCoroution);
        curTime = 0;
    }
    private void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= doorTiming)
            door.SetActive(true);
    }
    IEnumerator WomanSawanAgain(float time = 7.5f)
    {
        foreach (var trm in spawnTrm)
        {
            GameObject woman = GameObject.Instantiate(woman_staris, trm.position, trm.rotation);
            woman.transform.SetParent(trm);
            woman.transform.localScale = Vector3.one;
            yield return new WaitForSeconds(time);
            Destroy(woman);
        }
       // StopCoroutine(womanCoroution);
        //StartCoroutine(womanCoroution);
        //stairsAudio.Stop();
    }
}
