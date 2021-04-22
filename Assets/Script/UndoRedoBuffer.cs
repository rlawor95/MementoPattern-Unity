using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JK;

public class UndoRedoBuffer 
{
    protected List<Memento> buffer;
    protected int idx;

    public bool CanUndo
    {
        get { return idx > 0; }
    }

    public int GetIdx
    {
        get { return idx; }
    }

    public bool CanRedo
    {
        get { return buffer.Count > idx + 1; }
    }

    public bool AtTop
    {
        get { return idx == buffer.Count; }
    }

    public int Count
    {
        get { return buffer.Count; }
    }

    public string UndoAction
    {
        get
        {
            string ret = string.Empty;
            if (idx > 0)
            {
                ret = ((Memento)buffer[idx - 1]).Action;
            }
            return ret;
        }
    }

    public string RedoAction
    {
        get
        {
            string ret = string.Empty;
            if (idx < buffer.Count)
            {
                ret = ((Memento)buffer[idx]).Action;
            }
            return ret;
        }
    }

    public UndoRedoBuffer()
    {
        buffer = new List<Memento>();
        idx = 0;
    }

    public void PushCurrentState(Memento mem)
    {
        buffer.Add(mem);
    }

    public void Do(Memento mem)
    {
        if (buffer.Count > idx)
        {
            buffer.RemoveRange(idx, buffer.Count - idx);
        }

        buffer.Add(mem);
        ++idx;
    }

    public Memento Undo()
    {
        if (idx == 0)
        {
            Debug.Log("Undo Invalid Index");
            return null;
            //throw new UndoRedoException("Invalid index.");
        }
        --idx;
        return (Memento)buffer[idx];
    }

    public Memento Redo()
    {
        if ((idx + 1) < buffer.Count)
        {
            ++idx;
            return (Memento)buffer[idx];
        }
        else
        {
            Debug.Log("Redo null");
            return null;
        }
    }

    public void Flush()
    {
        buffer.Clear();
        idx = 0;
    }

}
