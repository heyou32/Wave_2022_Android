using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBoardCollision : MonoBehaviour
{
    public BoardCardPlacement boardCardPlacement;
    public Collider boardCollider;

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        if (other == boardCollider) {
            boardCardPlacement.isCorrect = true;
            //boardCardPlacement.OnCardPlacement();
        }
    }
}
