using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]

public class RecipeSO : ScriptableObject
{
    public List<KitchenObjectSO> KitchenObjectSOList;
    public string recipeName;
}
