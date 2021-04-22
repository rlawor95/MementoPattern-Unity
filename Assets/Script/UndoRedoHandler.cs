using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JK;

public class UndoRedoHandler : Singleton<UndoRedoHandler>
{
    public UndoRedoBuffer mementoBuffer;

    void Start()
    {
        mementoBuffer = new UndoRedoBuffer();
    }

    //완료된 현재 작업을 버퍼에 추가시키는 함수
    public void SaveMemento(Memento memento)
    {
        mementoBuffer.Do(memento);
    }

    // 언두 할때 리두용으로 현재 상태를 임시로 저장하는 함수.
    public void PushMemento(Memento memento)
    {
        mementoBuffer.PushCurrentState(memento);
    }

    public void Clear()
    {
        mementoBuffer.Flush();
    }

    public bool AtTop()
    {
        return mementoBuffer.AtTop;
    }

    public Memento Undo()
    {
        return mementoBuffer.Undo();
    }

    public Memento Redo()
    {
        return mementoBuffer.Redo();
    }

    public bool CanRedo()
    {
        return mementoBuffer.CanRedo;
    }

    public bool CanUndo()
    {
        return mementoBuffer.CanUndo;
    }
}
