using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using System.Linq;

public class ShowLeaderboard : MonoBehaviour
{
    [SerializeField] private RankView _template;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private MoneyCounter _moneyCounter;

    private readonly string _leadearboardName = "EatAllTreusersLeaderbord";
    private readonly string _anonymousName = "Anonymous";

    private void OnEnable()
    {
        PlayerAccount.Authorize();
        ClearChildren(_itemContainer.transform);

        if (PlayerAccount.IsAuthorized == false)
        {
            PlayerAccount.Authorize();
        }

        if (PlayerAccount.IsAuthorized == true)
        {
            Leaderboard.SetScore(_leadearboardName, _moneyCounter.Money);
            ShowAllUsers();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void ShowAllUsers()
    {
        Leaderboard.GetEntries(_leadearboardName, (result) =>
        {
            foreach (var entry in result.entries)
            {
                if (entry.score > 0)
                {
                    var view = Instantiate(_template, _itemContainer.transform);
                    string name = entry.player.publicName;

                    if (string.IsNullOrEmpty(name))
                        name = _anonymousName;

                    view.Render(entry.rank, name, entry.score);
                }
            }
        });
    }

    private void ClearChildren(Transform transform)
    {
        var children = transform.Cast<Transform>().ToArray();

        foreach (var child in children)
        {
            Object.DestroyImmediate(child.gameObject);
        }
    }

}
