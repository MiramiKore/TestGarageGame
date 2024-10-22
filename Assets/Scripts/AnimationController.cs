using System.Collections;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // Задержка перед началом проигрывания анимации
    [SerializeField] private float animationDelay = 2f;
    
    private static readonly int IsOpenGarage = Animator.StringToHash("isOpenGarage");
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(OpenGarageDoor(animationDelay));
    }

    // Запускаем анимацию открытия гаражной двери с установленной задержкой
    private IEnumerator OpenGarageDoor(float delay)
    {
        yield return new WaitForSeconds(delay);

        _animator.SetTrigger(IsOpenGarage);
    }
}