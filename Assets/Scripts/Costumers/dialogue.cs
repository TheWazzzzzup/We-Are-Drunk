using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject dialogueBox;


    [Button]
    public void ShowDialogue(string dialogue)
    {
        text.text = dialogue;
    }
}
