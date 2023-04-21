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
    [SerializeField] private Player _player;

    private void ShowAllUsers()
    {
        Leaderboard.GetEntries("EatAllTreusersLeaderbord", (result) =>
        {
            foreach (var entry in result.entries)
            {
                if (entry.score > 0)
                {
                    var view = Instantiate(_template, _itemContainer.transform);
                    string name = entry.player.publicName;

                    if (string.IsNullOrEmpty(name))
                        name = "Anonymous";

                    view.Render(entry.rank, name, entry.score);
                }
            }
        });
    }

    private void ShowCurrentUser()
    {
        Leaderboard.GetPlayerEntry("EatAllTreusersLeaderbord", (result) =>
        {
            string name = result.player.publicName;

            if (string.IsNullOrEmpty(name))
                name = "Anonymous";

            //_currentUser.Render(result.rank, name, result.score);
        });
    }

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
            Leaderboard.SetScore("EatAllTreusersLeaderbord", _player.Money);
            ShowAllUsers();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void ClearChildren(Transform transform)
    {
        var children = transform.Cast<Transform>().ToArray();

        foreach (var child in children)
        {
            Object.DestroyImmediate(child.gameObject);
        }
    }


    private void DemoMethod()
    {
        List<int> ranks = new List<int>()
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };

        List<string> names = new List<string>()
        {
            "asdasd", "asdasd","asdasd","asdasd","asdasd","asdasd","asdasd","asdasd","asdasd","asdasd"
        };

        List<int> scores = new List<int>()
        {
            25,4324,555,6778,890,90,213,213,43,333
        };

        for(int i=0; i < ranks.Count;i++)
        {
            var view = Instantiate(_template, _itemContainer.transform);
            view.Render(ranks[i], names[i], scores[i]);
        }
    }

}
