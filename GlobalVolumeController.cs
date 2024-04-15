using UnityEngine;
using UnityEngine.UI;

public class GlobalVolumeController : MonoBehaviour
{
    public Scrollbar volumeScrollbar;

    private void Start()
    {
        if (volumeScrollbar != null)
        {
            volumeScrollbar.value = AudioListener.volume;
        }
    }

    public void SetGlobalVolume()
    {
        if (volumeScrollbar != null)
        {
            // nastav zvuk podla scrollbar's value
            AudioListener.volume = volumeScrollbar.value;
        }
    }
}
