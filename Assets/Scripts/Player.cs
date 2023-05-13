using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
        public int ColorId;
        
        private void Awake() {
            GetComponent<SpriteRenderer>().color = GamePlayManager.Instance.Colors[ColorId];
        }
}
