using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Unity.VisualScripting;

namespace Scenes.Ingame.Journal
{
    public class JournalPresenter : MonoBehaviour
    {
        [SerializeField] private JournalView _jornalView;
        private JournalPageManager _journalPageManager;
        void Start()
        {
            _journalPageManager = GetComponent<JournalPageManager>();
            _journalPageManager.Init();
            _jornalView.Init();
            _journalPageManager.CurrentPage.Skip(1).Subscribe(pageType => _jornalView.PageChange(pageType)).AddTo(this);
            _journalPageManager.OnJornalOpen.Subscribe(_ => _jornalView.Open()).AddTo(this);
            _journalPageManager.OnJornalClose.Subscribe(_ => _jornalView.Close()).AddTo(this);
            _jornalView.OnJornalTagClick.Subscribe(pageType =>
            {
                Debug.Log("OnJornalTagClick");
                _journalPageManager.ChangePage(pageType);
            }).AddTo(this);
        }
    }
}