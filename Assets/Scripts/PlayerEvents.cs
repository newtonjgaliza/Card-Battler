using UnityEngine;
using System;

public class PlayerEvents : MonoBehaviour
{
    public static event Action<CardData> OnCardPlayed;

    public static void CardPlayed(CardData cardData)
    {
        OnCardPlayed?.Invoke(cardData);
    }
}
