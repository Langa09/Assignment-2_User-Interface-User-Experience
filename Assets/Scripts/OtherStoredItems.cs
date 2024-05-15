using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OtherStoredItems : MonoBehaviour
{
    public int itemID;
    public Button transferButton;
    public Button moveButton;
    
    public TextMeshProUGUI sourceText;
    public TextMeshProUGUI targetText;

    public int SourceAmount { get; private set; }

    private int maxTransferAmount = 4;
    //private bool isUpgradeEnabled = false;

    private void Awake()
    {
        transferButton.onClick.AddListener(TransferValue);
        moveButton.onClick.AddListener(MoveToOther);
        
        CheckTextChild();
    }

    private void CheckTextChild()
    {
        if (sourceText != null && targetText != null)
        {
            transferButton.interactable = true;
            moveButton.interactable = true;
            
        }
    }

    private void TransferValue()
    {
        if (sourceText != null && targetText != null)
        {
            int sourceAmount = int.Parse(sourceText.text);
            int targetAmount = int.Parse(targetText.text);

            
            if (targetAmount > 0 && sourceAmount < maxTransferAmount)
            {
                sourceAmount++;
                targetAmount--;
            }

            sourceText.text = sourceAmount.ToString();
            targetText.text = targetAmount.ToString();

            CheckTextChild();
        }
    }

    private void MoveToOther()
    {
        if (sourceText != null && targetText != null)
        {
            int sourceAmount = int.Parse(sourceText.text);
            int targetAmount = int.Parse(targetText.text);

            if (sourceAmount > 0)
            {
                sourceAmount--;
                targetAmount++;

                sourceText.text = sourceAmount.ToString();
                targetText.text = targetAmount.ToString();
            }
        }
    }
}