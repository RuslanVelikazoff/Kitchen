using UnityEngine;

public class ResetStaticDataManager : MonoBehaviour
{
    //Этот скрипт вешать только в главном меня для сброса всех static

    private void Awake()
    {
        CuttingCounter.ResetStaticData();
        BaseCounter.ResetStaticData();
        TrashCounter.ResetStaticData();
    }
}
