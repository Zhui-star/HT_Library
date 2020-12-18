using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Utility;
using UnityEngine.UI;
/// <summary>
/// 牌类模板使用实例（斗地主模板）
/// 1. 初始化牌库 回合 先手
/// 2. 洗牌
/// 3. 发牌
/// 4. 回合判定
/// </summary>
public class PlayingCardTestPanel : MonoBehaviour
{
    public Text screenText;
    List<Card> playerCardList = new List<Card>();
    List<Card> computerRightList = new List<Card>();
    public CardChracterAI computerAIRight;

    /// <summary>
    /// 初始化
    /// 1. 牌库初始化
    /// 2. 回合初始化
    /// 3. 先手初始化
    /// </summary>
    private void Start()
    {
        CardLibraryUtility.Instance.InitCardLibrary();
        TraverseCards();

        CardRoundBaseUtility.Instance.InitRound();
        CardRoundBaseUtility.Instance.Start(CharacterType.Player);
    }

    /// <summary>
    /// AI注册
    /// </summary>
    private void OnEnable()
    {
        CardRoundBaseUtility.ComputerHandler += ComputerHanlde;
    }

    private void OnDisable()
    {
        CardRoundBaseUtility.ComputerHandler -= ComputerHanlde;
    }

    /// <summary>
    /// 洗牌按钮
    /// </summary>
    public void ShuffleClick()
    {
        CardLibraryUtility.Instance.Shuffle();
        ClearText();

        BanCurrentUI();

        TraverseCards();
    }

    /// <summary>
    /// 发牌按钮
    /// </summary>
    public void DealCardClick()
    {
        ClearText();
        //给每个人17张
        CharacterType curr = CharacterType.Player;
        screenText.text += "which card player own:";
        Card playerCard;
        for (int i = 0; i < 51; i++)
        {
            if (curr == CharacterType.Desk || curr == CharacterType.Library)
            {
                curr = CharacterType.Player;
            }

            if (curr == CharacterType.Player)
            {

                playerCard = CardLibraryUtility.Instance.DealCard(curr);
                playerCardList.Add(playerCard);
                AddText(playerCard.CardName);
            }
            else if (curr == CharacterType.ComputerRight)
            {
                playerCard = CardLibraryUtility.Instance.DealCard(curr);
                computerRightList.Add(playerCard);

            }

            curr++;

        }

        BanCurrentUI();

    }

    void BanCurrentUI()
    {
        var obj = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        obj.GetComponent<Button>().interactable = false;
        obj.GetComponent<Button>().image.color = Color.gray;
    }

    /// <summary>
    /// 玩家出牌按钮
    /// </summary>
    public void PlayCardClick()
    {
        List<Card> cardList = new List<Card>();
        cardList.Add(playerCardList[0]);
        CardType cardType;

        ClearText();

        if (CardRulersUtility.CanPop(cardList, out cardType))
        {
            CardRoundBaseUtility.Instance.BiggestCharacter = CharacterType.Player;
            CardRoundBaseUtility.Instance.CurrentLength = 1;
            // CardRoundBaseUtility.Instance.CurrentWeight =(int) cardList[0].Cardweight;
            CardRoundBaseUtility.Instance.CurrentType = cardType;
            CardRoundBaseUtility.Instance.CurrentCharacter = CharacterType.Player;

            screenText.text += "\n Player card:";

            TraverseCards(cardList);

            CardRoundBaseUtility.Instance.Turn();
        }

        cardList.RemoveAt(0);
        playerCardList.RemoveAt(0);
    }
    /// <summary>
    /// AI 出牌
    /// </summary>
    /// <param name="e"></param>
    public void ComputerHanlde(ComputerSmartArgs e)
    {
        if (CardRoundBaseUtility.Instance.CurrentCharacter == CharacterType.ComputerRight)
        {
            computerAIRight.SmartSelectCards(computerRightList, CardRoundBaseUtility.Instance.CurrentType,
            CardRoundBaseUtility.Instance.CurrentWeight, 1, CardRoundBaseUtility.Instance.BiggestCharacter == CharacterType.ComputerRight);

            screenText.text += "\n Computer card:";
            TraverseCards(computerAIRight.selecCards);
            computerRightList.RemoveAt(0);
        }

        CardRoundBaseUtility.Instance.Turn();
    }

    /// <summary>
    /// 显示文本内容
    /// </summary>
    /// <param name="str"></param>
    void AddText(string str)
    {
        screenText.text += str + " ";
    }

    /// <summary>
    /// 遍历队
    /// </summary>
    void TraverseCards()
    {
        foreach (var temp in CardLibraryUtility.Instance.GetCards())
        {
            AddText((temp as Card).CardName + " ");
        }
    }

    /// <summary>
    /// 遍历List
    /// </summary>
    /// <param name="cards"></param>
    void TraverseCards(List<Card> cards)
    {
        foreach (var temp in cards)
        {
            AddText((temp as Card).CardName + " ");
        }
    }

    /// <summary>
    /// 清空文本
    /// </summary>
    void ClearText()
    {
        screenText.text = "";
    }

 
}
