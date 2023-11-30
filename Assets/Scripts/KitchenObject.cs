using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
  [SerializeField] private KitchenObjectSO kitchenObjectSo;

  public KitchenObjectSO GetKitchenObjectSo()
  {
    return kitchenObjectSo;
  }
}
