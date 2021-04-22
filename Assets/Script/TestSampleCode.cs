using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JK;

public class TestSampleCode : MonoBehaviour
{
    public Transform MementoObject;


    // 오브젝트 인터렉션은 귀찮아서 안만듬.
    // 수동으로 조작하고 세이브 버튼을 누르면 해당 포지션이 버퍼에 저장됨

    public void SaveBtnClickEvent()
    {
        Memento memento = new Memento(MementoObject);
        UndoRedoHandler.Instance.SaveMemento(memento);
    }

    public void UndoBtnClickEvent()
    {
        if(UndoRedoHandler.Instance.AtTop())
            UndoRedoHandler.Instance.PushMemento(new Memento(MementoObject));

        Memento undoState = UndoRedoHandler.Instance.Undo();
        if(undoState != null)
        {
            MementoObject.transform.position = undoState.Location;
        }
    }

    public void RedoBtnClickEvent()
    {
        Memento redoState = UndoRedoHandler.Instance.Redo();
        if(redoState != null)
        {
            MementoObject.transform.position = redoState.Location;
        }
    }

    public void ResetBtnClickEvent()
    {
        UndoRedoHandler.Instance.Clear();
    }
}
