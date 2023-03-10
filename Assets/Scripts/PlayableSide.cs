using System.Collections.Generic;
using UnityEngine;

namespace Checkers
{
    public class PlayableSide : MonoBehaviour
    {
        public ColorType CurrentSide { get; private set; } = ColorType.White;

        [SerializeField] private ClickHandler _clickHandler;

        private List<BaseClickComponent> _whiteChips = new();
        private List<BaseClickComponent> _blackChips = new();

        private void OnEnable()
        {
            _clickHandler.ObjectsMoved += OnObjectsMoved;
            _clickHandler.GameEnded += OnGameEnded;
            _clickHandler.ChipDestroyed += OnChipDestroyed;
        }

        private void OnDisable()
        {
            _clickHandler.ObjectsMoved -= OnObjectsMoved;
            _clickHandler.GameEnded -= OnGameEnded;
            _clickHandler.ChipDestroyed -= OnChipDestroyed;
        }

        private void Start()
        {
            foreach (var chip in _clickHandler.Chips)
            {
                if (chip.Color == ColorType.White)
                {
                    _whiteChips.Add(chip);
                }
                else
                {
                    _blackChips.Add(chip);
                }
            }
        }

        private void OnChipDestroyed(BaseClickComponent chip)
        {
            if (_whiteChips.Contains(chip))
            {
                _whiteChips.Remove(chip);
            }
            else
            {
                _blackChips.Remove(chip);
            }

            if (_whiteChips.Count == 0)
            {
                OnGameEnded(ColorType.Black);
            }
            else if (_blackChips.Count == 0)
            {
                OnGameEnded(ColorType.White);
            }
        }

        private void OnObjectsMoved()
        {
            CurrentSide = CurrentSide == ColorType.Black ? ColorType.White : ColorType.Black;
        }

        private void OnGameEnded(ColorType side)
        {
            var congrats = side == ColorType.Black ? "черная" : "белая";
            Debug.Log($"Грац,с победой {congrats} команда");
            Time.timeScale = 0f;
        }
    }
}