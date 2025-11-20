using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public void ChestAnimation()
    {
        _animator.SetBool("ChestOpen", true);
    }
}
