using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCardPlacement : CardPlacement
{
    protected override void OnCardPlacement()
    {
        base.OnCardPlacement();
        targetList[0].GetComponent<BoardPlaceTargetSetter>().DoAction();
    }

    [ContextMenu("TestCardPlacement")]
    public void TestCardPlacement() 
    {
        OnCardPlacement();
    }
}