using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.InputSystem;
using System;

namespace Scenes.Ingame.Journal
{
    public class JournalPageManager : MonoBehaviour
    {
        PlayerAction _inputs;


        [SerializeField]
        PlayerJournalTest _player;

        private ReactiveProperty<PageType> _currentPage = new ReactiveProperty<PageType>(PageType.Progress);//���݂̃y�[�W
        public IObservable<PageType> CurrentPage { get { return _currentPage; } }
        private Subject<Unit> _jornalOpen = new Subject<Unit>();
        public IObservable<Unit> OnJornalOpen { get { return _jornalOpen; } }
        private Subject<Unit> _jornalClsoe = new Subject<Unit>();
        public IObservable<Unit> OnJornalClose { get { return _jornalClsoe; } }
        int _nowPage = 0;

        void Awake()
        {
            _inputs = new PlayerAction();
            _inputs.UI.ChangePage.performed += OnChangePage;  //�y�[�W�ύX�{�^���������ꂽ�Ƃ��̃R�[���o�b�N��o�^
        }

        public void Init()
        {
            _player.OnChangeJournalState
                .Subscribe(x =>
                {
                    if (x == true)
                        OpenJournal();
                    else
                        CloseJournal();
                }).AddTo(this);
        }

        void OnEnable()
        {
            _inputs.Enable();   //InputAction��L����
        }

        //�W���[�i�����J��
        private void OpenJournal()
        {
            _jornalOpen.OnNext(default);
        }

        //�y�[�W���w�肵�ĕύX
        public void ChangePage(PageType pageType)
        {
            _currentPage.Value = pageType;
        }

        //�y�[�W�ύX
        private void OnChangePage(InputAction.CallbackContext context)
        {
            //if (!this.gameObject.activeSelf) return;
            Debug.Log("OnChangePage");
            _currentPage.Value = (PageType)Enum.ToObject(typeof(PageType), ((int)_currentPage.Value + 1) % Enum.GetValues(typeof(PageType)).Length);
        }

        void OnDestroy()
        {
            _inputs?.Dispose();    //IDisposable�Ȃ��߁A�I�u�W�F�N�g�j�󎞂�Dispose
        }

        //�W���[�i�������
        void CloseJournal()
        {
            _jornalClsoe.OnNext(default);
        }
    }
}

