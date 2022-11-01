using System.Globalization;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
   public static CoinManager Instance;

   [SerializeField] private TextMeshProUGUI coinText;
   
   private float currentCoinCount = 500;

   private void Awake()
   {
      if (Instance != null && Instance != this)
      {
         Destroy(gameObject);
      } else {
         Instance = this;
      }
   }

   private void Start()
   {
      HoleTrigger.OnBallDrop += OnBallDrop;
      UpgradeManager.Instance.OnUpgradeButtonPressed += OnUpgradeButtonPressed;
   }
   
   
   private void OnDestroy()
   {
      HoleTrigger.OnBallDrop -= OnBallDrop;
      UpgradeManager.Instance.OnUpgradeButtonPressed -= OnUpgradeButtonPressed;
   }

   private void OnUpgradeButtonPressed(UpgradeType arg1, float arg2)
   {
      currentCoinCount -= arg2;
      coinText.text = currentCoinCount.ToString(CultureInfo.InvariantCulture);
   }

   private void OnBallDrop()
   {
      currentCoinCount++;
      coinText.text = currentCoinCount.ToString(CultureInfo.InvariantCulture);
   }
   
   public bool HaveSufficientCoins(float minCoinAmount)
   {
      return currentCoinCount >= minCoinAmount;
   }
}
