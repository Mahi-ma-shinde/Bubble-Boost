using UnityEngine;
using UnityEngine.EventSystems;

namespace FWC
{
    public class HoverAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
    {
        Vector3 currentScale;
        [SerializeField] float scaleChange = 1.1f;

        [SerializeField] AudioSource source;


        public void OnPointerEnter(PointerEventData eventData)
        {
            currentScale = transform.localScale;
            transform.localScale *= scaleChange;

            if (source.clip == null) return;

            source.PlayOneShot(source.clip);

        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.localScale = currentScale;

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            transform.localScale = currentScale;
        }
    }

}
