using UnityEngine;
using UnityEngine.Events;

public class EntranceZone : MonoBehaviour
{
    public event UnityAction PlayerGoInEnteranceZone;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out JetPack player))
        {
            PlayerGoInEnteranceZone?.Invoke();
        }
    }
}
