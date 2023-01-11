using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public GameObject owner; // Saves a reference to its root object so we don't need to do any transform.parent chains
    //For now this is manually set, you could probably automatically find every child object with this script in the owner's Start method or something.

}
