using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private HealthBehaviour playerHealthBehaviour;
    [SerializeField] private Image currentHealthImage;
    [SerializeField] private TextMeshProUGUI gameLostText;

    private void Update()
    {
        currentHealthImage.fillAmount = playerHealthBehaviour.currentHealth * 0.2f;
        if (currentHealthImage.fillAmount == 0.0f)
        {
            gameLostText.gameObject.SetActive(true);
        }
    }
}
