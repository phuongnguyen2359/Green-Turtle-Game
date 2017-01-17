using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Inventory : MonoBehaviour, IHasChanged {
    public void HasChanged()
    {
//        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {
        HasChanged();
	}
}
namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}