using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.InputSystem;

namespace Scenes.Ingame.Journal
{
    public class PlayerJournalTest : MonoBehaviour
    {
        ReactiveProperty<bool> _journal = new BoolReactiveProperty();
        public IReactiveProperty<bool> OnChangeJournalState => _journal;

        public void OnOpenJournal(InputAction.CallbackContext context)
        {
            if (context.performed)
                _journal.Value = true;
        }

        public void OnCloseJournal(InputAction.CallbackContext context)
        {
            if (context.performed)
                _journal.Value = false;
        }
    }
}

