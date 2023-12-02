using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class KitchenObject : MonoBehaviour
{ 
  [SerializeField] private KitchenObjectSO kitchenObjectSO;

  private IKitchenObjectParent kitchenObjectParent;
  
  public KitchenObjectSO GetKitchenObjectSO()
  {
    return kitchenObjectSO;
  }

  public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
  {
    
    //clear kitchen objects
    if (this.kitchenObjectParent != null)
    {
      this.kitchenObjectParent.ClearKitchenObject();
    }
    
    //added new kitchen objects
    
    this.kitchenObjectParent = kitchenObjectParent;
    
    if (kitchenObjectParent.HasKitchenObject())
    {
      Debug.Log("IKitchenObjectParent already has a KitchenObject!");
    }
    kitchenObjectParent.SetKitchenObject(this);
    
    //update the visual of objects
    transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
    transform.localPosition = Vector3.zero;
  }

  public IKitchenObjectParent GetKitchenObjectParent()
  {
    return kitchenObjectParent;
  }

  public void DestroySelf()
  { 
    kitchenObjectParent.ClearKitchenObject();
    Destroy(gameObject);
  }

  public static KitchenObject SpawnKitchenObject(KitchenObjectSO kitchenObjectSO,
    IKitchenObjectParent kitchenObjectParent)
  {
    Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);

    KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
    
    kitchenObject.SetKitchenObjectParent(kitchenObjectParent);

    return kitchenObject;
  }
}
