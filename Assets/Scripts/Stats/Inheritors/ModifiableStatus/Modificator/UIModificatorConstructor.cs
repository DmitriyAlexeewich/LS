using Assets.Extensions;
using Assets.Scripts.Stats.Enumerators;
using Assets.Scripts.Stats.Inheritors.ModifiableStatus.Modificator.ModificatorAlgorithm;
using Assets.Scripts.Stats.Inheritors.ModifiableStatus.Modificator.ModificatorAlgorithm.Enumerators;
using Assets.Scripts.Stats.Inheritors.ModifiableStatus.Modificator.ModificatorAlgorithm.Inheritors;
using Assets.Scripts.Weapon.Ammo.Perk.Inheritors.ModifyParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Stats.Inheritors.ModifiableStatus.Modificator
{
    public class UIModificatorConstructor
    {

        private int _selectedModifiedFieldType = 0;
        private int _selectedMathOperationType = 0;
        private int _modifierValue = 0;
        private int _selectedModificatorAlgorithm = 0;

        private int _lifetime = 0;
        private int _stepCount = 0;

        private string[] _modifiedFieldTypes = Enum.GetValues(typeof(EnumModifiedFieldType)).Cast<int>().Select(item => ((EnumModifiedFieldType)item).ToString()).ToArray();
        private string[] _mathOperationTypes = Enum.GetValues(typeof(EnumMathOperationType)).Cast<int>().Select(item => ((EnumMathOperationType)item).ToString()).ToArray();
        private string[] _modificatorAlgorithm = new string[] { "Static", "Dynamic", "Dynamic step" };

        public void AddModificator(Rect position, SerializedProperty property, int height, ModifiableStatus target)
        {
            height = 140;
            Rect _addButtonRect = ShowConstructor(position, property, height);

            if (GUI.Button(_addButtonRect, "Add modificator"))
            {
                EnumModifiedFieldType _modifiedFieldType = (EnumModifiedFieldType)(_selectedModifiedFieldType + 1);
                EnumMathOperationType _mathOperationType = (EnumMathOperationType)(_selectedMathOperationType + 1);

                switch (_selectedModificatorAlgorithm)
                {
                    case 0:
                        target.AddStatusModificator(new StatusModificator(target.StatusType, new StaticStatusModificator(_modifiedFieldType, _mathOperationType, _modifierValue)));
                        break;
                    case 1:
                        target.AddStatusModificator(new StatusModificator(target.StatusType, new DynamicStatusModificatorAlgorithm(_modifiedFieldType, _mathOperationType, _modifierValue, _lifetime)));
                        break;
                    case 2:
                        target.AddStatusModificator(new StatusModificator(target.StatusType, new DynamicStepStatusModificatorAlgorithm(_modifiedFieldType, _mathOperationType, _modifierValue, _lifetime, _stepCount)));
                        break;
                }

            }
        }

        public void AddModificator(Rect position, SerializedProperty property, int height, ModifyParametersPerk target)
        {
            height = 140;
            Rect _addButtonRect = ShowConstructor(position, property, height);

            if (GUI.Button(_addButtonRect, "Add modificator"))
            {
                EnumModifiedFieldType _modifiedFieldType = (EnumModifiedFieldType)(_selectedModifiedFieldType + 1);
                EnumMathOperationType _mathOperationType = (EnumMathOperationType)(_selectedMathOperationType + 1);

                switch (_selectedModificatorAlgorithm)
                {
                    case 0:
                        target.AddStatusModificator(new StatusModificator((EnumStatusType)0, new StaticStatusModificator(_modifiedFieldType, _mathOperationType, _modifierValue)));
                        break;
                    case 1:
                        target.AddStatusModificator(new StatusModificator((EnumStatusType)0, new DynamicStatusModificatorAlgorithm(_modifiedFieldType, _mathOperationType, _modifierValue, _lifetime)));
                        break;
                    case 2:
                        target.AddStatusModificator(new StatusModificator((EnumStatusType)0, new DynamicStepStatusModificatorAlgorithm(_modifiedFieldType, _mathOperationType, _modifierValue, _lifetime, _stepCount)));
                        break;
                }

            }
        }

        private Rect ShowConstructor(Rect position, SerializedProperty property, int height)
        {
            float _topPadding = position.y + property.GetElementsHight() + 3 * EditorGUIUtility.standardVerticalSpacing;

            Rect _rect = new Rect(position.x, _topPadding, position.width, 1);
            EditorGUI.DrawRect(_rect, new Color(0.5f, 0.5f, 0.5f, 1));

            _topPadding += EditorGUIUtility.standardVerticalSpacing;

            Rect _mainLabelRect = new Rect((position.width / 2), _topPadding, position.width, 20);
            Rect _selectorModifiedFieldTypeGridRect = new Rect(position.x, _topPadding + 20 + EditorGUIUtility.standardVerticalSpacing, position.width, 20);
            Rect _selectorMathOperationTypeGridRect = new Rect(position.x, _topPadding + 40 + 2 * EditorGUIUtility.standardVerticalSpacing, position.width, 20);

            Rect _modifierValueLabelRect = new Rect(position.x, _topPadding + 60 + 3 * EditorGUIUtility.standardVerticalSpacing, 90, 20);
            Rect _modifierValueTextFieldRect = new Rect(position.x + 90, _topPadding + 60 + 3 * EditorGUIUtility.standardVerticalSpacing, position.width - 90, 20);

            Rect _selectorModificatorAlgorithmRect = new Rect(position.x, _topPadding + 80 + 4 * EditorGUIUtility.standardVerticalSpacing, position.width, 20);

            GUI.Label(_mainLabelRect, "Modificator constructor");

            _selectedModifiedFieldType = GUI.SelectionGrid(_selectorModifiedFieldTypeGridRect, _selectedModifiedFieldType, _modifiedFieldTypes, 3);
            _selectedMathOperationType = GUI.SelectionGrid(_selectorMathOperationTypeGridRect, _selectedMathOperationType, _mathOperationTypes, 4);

            GUI.Label(_modifierValueLabelRect, "Modifier value");
            int.TryParse(GUI.TextField(_modifierValueTextFieldRect, _modifierValue.ToString()), out _modifierValue);

            _selectedModificatorAlgorithm = GUI.SelectionGrid(_selectorModificatorAlgorithmRect, _selectedModificatorAlgorithm, _modificatorAlgorithm, 3);
            Rect _addButtonRect = new Rect(position.x, _topPadding + 100 + 5 * EditorGUIUtility.standardVerticalSpacing, position.width, 20);

            switch (_selectedModificatorAlgorithm)
            {
                case 0:
                    height = 140;
                    break;
                case 1:
                    Rect _lifetimeLabelRect = new Rect(position.x, _topPadding + 100 + 5 * EditorGUIUtility.standardVerticalSpacing, 60, 20);
                    Rect _lifetimeTextFieldRect = new Rect(position.x + 60, _topPadding + 100 + 5 * EditorGUIUtility.standardVerticalSpacing, position.width - 60, 20);
                    _addButtonRect.y = _topPadding + 120 + 6 * EditorGUIUtility.standardVerticalSpacing;

                    GUI.Label(_lifetimeLabelRect, "Lifetime");
                    int.TryParse(GUI.TextField(_lifetimeTextFieldRect, _lifetime.ToString()), out _lifetime);
                    height = 160;
                    break;
                case 2:
                    Rect _stepTimeLabelRect = new Rect(position.x, _topPadding + 100 + 5 * EditorGUIUtility.standardVerticalSpacing, 60, 20);
                    Rect _stepTimeTextFieldRect = new Rect(position.x + 60, _topPadding + 100 + 5 * EditorGUIUtility.standardVerticalSpacing, position.width - 60, 20);
                    Rect _stepCountLabelRect = new Rect(position.x, _topPadding + 120 + 6 * EditorGUIUtility.standardVerticalSpacing, 70, 20);
                    Rect _stepCountTextFieldRect = new Rect(position.x + 70, _topPadding + 120 + 6 * EditorGUIUtility.standardVerticalSpacing, position.width - 70, 20);
                    _addButtonRect.y = _topPadding + 140 + 7 * EditorGUIUtility.standardVerticalSpacing;

                    GUI.Label(_stepTimeLabelRect, "Step time");
                    int.TryParse(GUI.TextField(_stepTimeTextFieldRect, _lifetime.ToString()), out _lifetime);

                    GUI.Label(_stepCountLabelRect, "Step count");
                    int.TryParse(GUI.TextField(_stepCountTextFieldRect, _stepCount.ToString()), out _stepCount);
                    height = 180;
                    break;
            }

            return _addButtonRect;
        }
    }
}
