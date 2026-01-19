using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRenderer : MonoBehaviour
{
    private Dictionary<int, UnitData.AnimatiomData> aniamationContainer = new Dictionary<int, UnitData.AnimatiomData>();
    [SerializeField] private ParticleSystem ps;
    private ParticleSystemRenderer psRenderer;
    private ParticleSystem.TextureSheetAnimationModule textureSheet;
    private Coroutine hitAnimRoutine;

    private int currentAnimationID;

    public void InitAnimationData(UnitData data)
    {
        // 다른 사용자한테 0 = Run, 1 = Hit 등 메뉴얼을 알려줘야하는
        // 안전성없는 방식인 걸 알지만 1인 개발이라
        // 이런 코드를 짜도 되는 것인가에 대한 고찰
        // Enum도 좋은 방법이지만 만약에 특정 몬스터만 애니메이션이 많아질 때
        // 그 몬스터 때매 Enum 추가하는건 뭔가뭔가하다

        psRenderer = ps.GetComponent<ParticleSystemRenderer>();
        textureSheet = ps.textureSheetAnimation;
        for (int i = 0; i < data.animatiomDatas.Length; i++)
        {
            aniamationContainer.Add(i, data.animatiomDatas[i]);
        }
    }

    public void SetAnimation(int animationID) // 파티클 시스템 머테리얼 변경 및 나중에 애니메이션 시트 분리하는 것 까지 담당?
    {
        aniamationContainer.TryGetValue(animationID, out var animationData);

        LoadAnimationData(animationData);
        currentAnimationID = animationID;

    }


    public void PlayHitAnimation()
    {
        aniamationContainer.TryGetValue(1, out var animationData);
        LoadAnimationData(animationData);


        // 여기서 지정한 fps가 지난 후 다시 원래 애니메이션으로 돌아가는 코드가 있어야함 
    }

    private void LoadAnimationData(UnitData.AnimatiomData animationData)
    {
        psRenderer.material = animationData.animationMaterial;

        textureSheet.numTilesX = animationData.animationSheetSizeX;
        textureSheet.numTilesY = animationData.animationSheetSizeY;
        textureSheet.fps = animationData.animationDataFps;
    }
}
