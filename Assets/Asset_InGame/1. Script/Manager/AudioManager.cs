using UnityEngine;

public class AudioManager : ManagerBase
{ 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource bgmAudioSource;

    public override void Init()
    {
        Debug.Log("사운드 시작 재생 뿌슝빠슝!!!");
    }

    public override void ManagerUpdate()
    {
        Debug.Log("사운드 연속 재생 뿌슝빠슝!!!");
    }
}
