using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    public enum PatternType
    {
        square,
        horizontalline,
        verticalline,
        T,
        ninetyT,
        onehundredeightyT,
        twohundredseventyT,
        S,
        ninetyS,
        flippedS,
        ninetyflippedS,
        L,
        ninetyL,
        onehundredeightyL,
        twohundredseventyL,
        flippedL,
        ninetyflippedL,
        onehundredeightyflippedL,
        twohundredseventyflippedL
    }
    public PatternType currentpattern;
    public bool cleaningNeeded;
    public float timeOfLock;


    // Check Pattern

    public void CheckForPattern(ref List<Slot> slots)
    {
        cleaningNeeded = false;
        switch (currentpattern)
        {
            // Lines and Block

            case (PatternType.horizontalline):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x + 1 && s.y == slot.y) != null && slots.Find(s => s.x == slot.x + 2 && s.y == slot.y) != null && slots.Find(s => s.x == slot.x + 3 && s.y == slot.y) != null))
                        {
                            Debug.Log("Horizontal Line Pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y));
                            Result.Add(slots.Find(s => s.x == slot.x + 2 && s.y == slot.y));
                            Result.Add(slots.Find(s => s.x == slot.x + 3 && s.y == slot.y));
                            HorIsMine(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded=true; break;
                        }
                    }
                }
                break;
            case (PatternType.verticalline):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x && s.y == slot.y + 1) != null && slots.Find(s => s.y == slot.y + 2 && s.x == slot.x) != null && slots.Find(s => s.x == slot.x && s.y == slot.y + 3) != null))
                        {
                            Debug.Log("Vertical Line Pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x && s.y == slot.y + 1));
                            Result.Add(slots.Find(s => s.x == slot.x && s.y == slot.y + 2));
                            Result.Add(slots.Find(s => s.x == slot.x && s.y == slot.y + 3));
                            VertIsMine(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded=true; break;
                        }
                    }
                }
                break;
            case (PatternType.square):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x + 1 && s.y == slot.y) != null && slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 1) != null && slots.Find(s => s.x == slot.x && s.y == slot.y + 1) != null))
                        {
                            Debug.Log("Square pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y));
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 1));
                            Result.Add(slots.Find(s => s.x == slot.x && s.y == slot.y + 1));
                            Defrag(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded = true; break;
                        }
                    }
                }
                break;

                // Ts ans Ss

            case (PatternType.T):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x + 1 && s.y == slot.y) != null && slots.Find(s => s.x == slot.x + 1 && s.y == slot.y - 1) != null && slots.Find(s => s.x == slot.x + 2 && s.y == slot.y) != null))
                        {
                            Debug.Log("T pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y));
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y - 1));
                            Result.Add(slots.Find(s => s.x == slot.x + 2 && s.y == slot.y));
                            Burst(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded=true; break;
                        }
                    }
                }
                break;
            case (PatternType.ninetyT):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x && s.y == slot.y + 1) != null && slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 1) != null && slots.Find(s => s.x == slot.x && s.y == slot.y + 2) != null))
                        {
                            Debug.Log("90 T pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x && s.y == slot.y + 1));
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 1));
                            Result.Add(slots.Find(s => s.x == slot.x && s.y == slot.y + 2));
                            Burst(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded=true; break;
                        }
                    }
                }
                break;
            case (PatternType.onehundredeightyT):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x + 1 && s.y == slot.y) != null && slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 1) != null && slots.Find(s => s.x == slot.x + 2 && s.y == slot.y) != null))
                        {
                            Debug.Log("180 T pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y));
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 1));
                            Result.Add(slots.Find(s => s.x == slot.x + 2 && s.y == slot.y));
                            Burst(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded=true; break;
                        }
                    }
                }
                break;
            case (PatternType.twohundredseventyT):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x && s.y == slot.y) != null && slots.Find(s => s.x == slot.x - 1 && s.y == slot.y + 1) != null && slots.Find(s => s.x == slot.x && s.y == slot.y + 2) != null))
                        {
                            Debug.Log("270 T pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x && s.y == slot.y));
                            Result.Add(slots.Find(s => s.x == slot.x - 1 && s.y == slot.y + 1));
                            Result.Add(slots.Find(s => s.x == slot.x && s.y == slot.y + 2));
                            Burst(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded=true; break;
                        }
                    }
                }
                break;
            case (PatternType.S):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x + 1 && s.y == slot.y) != null && slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 1) != null && slots.Find(s => s.x == slot.x + 2 && s.y == slot.y + 1) != null))
                        {
                            Debug.Log("S pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y));
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 1));
                            Result.Add(slots.Find(s => s.x == slot.x + 2 && s.y == slot.y + 1));
                            Burst(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded=true; break;
                        }
                    }
                }
                break;
            case (PatternType.ninetyS):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x && s.y == slot.y + 1) != null && slots.Find(s => s.x == slot.x - 1 && s.y == slot.y + 1) != null && slots.Find(s => s.x == slot.x - 1 && s.y == slot.y + 2) != null))
                        {
                            Debug.Log("Ninety S pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x && s.y == slot.y + 1));
                            Result.Add(slots.Find(s => s.x == slot.x - 1 && s.y == slot.y + 1));
                            Result.Add(slots.Find(s => s.x == slot.x - 1 && s.y == slot.y + 2));
                            Burst(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded=true; break;
                        }
                    }
                }
                break;
            case (PatternType.flippedS):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x + 1 && s.y == slot.y) != null && slots.Find(s => s.x == slot.x + 1 && s.y == slot.y - 1) != null && slots.Find(s => s.x == slot.x + 2 && s.y == slot.y - 1) != null))
                        {
                            Debug.Log("Flipped S pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y));
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y - 1));
                            Result.Add(slots.Find(s => s.x == slot.x + 2 && s.y == slot.y - 1));
                            Burst(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded=true; break;
                        }
                    }
                }
                break;
            case (PatternType.ninetyflippedS):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x && s.y == slot.y + 1) != null && slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 1) != null && slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 2) != null))
                        {
                            Debug.Log("90 flipped S pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x && s.y == slot.y + 1));
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 1));
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 2));
                            Burst(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded=true; break;
                        }
                    }
                }
                break;

                // Ls

            case (PatternType.L):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x - 1 && s.y == slot.y) != null && slots.Find(s => s.x == slot.x - 1 && s.y == slot.y + 1) != null && slots.Find(s => s.x == slot.x - 1 && s.y == slot.y + 2) != null))
                        {
                            Debug.Log("L pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x - 1 && s.y == slot.y));
                            Result.Add(slots.Find(s => s.x == slot.x - 1 && s.y == slot.y + 1));
                            Result.Add(slots.Find(s => s.x == slot.x - 1 && s.y == slot.y + 2));
                            Lock(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded = true; break;
                        }
                    }
                }
                break;
            case (PatternType.ninetyL):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x + 1 && s.y == slot.y) != null && slots.Find(s => s.x == slot.x + 2 && s.y == slot.y) != null && slots.Find(s => s.x == slot.x + 2 && s.y == slot.y + 1) != null))
                        {
                            Debug.Log("90 L pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y));
                            Result.Add(slots.Find(s => s.x == slot.x + 2 && s.y == slot.y));
                            Result.Add(slots.Find(s => s.x == slot.x + 2 && s.y == slot.y + 1));
                            Lock(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded = true; break;
                        }
                    }
                }
                break;
            case (PatternType.onehundredeightyL):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x + 1 && s.y == slot.y) != null && slots.Find(s => s.x == slot.x + 1 && s.y == slot.y - 1) != null && slots.Find(s => s.x == slot.x + 1 && s.y == slot.y - 2) != null))
                        {
                            Debug.Log("180 L pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y));
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y - 1));
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y - 2));
                            Lock(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded = true; break;
                        }
                    }
                }
                break;
            case (PatternType.twohundredseventyL):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x && s.y == slot.y + 1) != null && slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 1) != null && slots.Find(s => s.x == slot.x + 2 && s.y == slot.y + 1) != null))
                        {
                            Debug.Log("270 L pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x && s.y == slot.y + 1));
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 1));
                            Result.Add(slots.Find(s => s.x == slot.x + 2 && s.y == slot.y + 1));
                            Lock(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded = true; break;
                        }
                    }
                }
                break;
            case (PatternType.flippedL):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x + 1 && s.y == slot.y) != null && slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 1) != null && slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 2) != null))
                        {
                            Debug.Log("Flipped L pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y));
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 1));
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 2));
                            Lock(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded = true; break;
                        }
                    }
                }
                break;
            case (PatternType.ninetyflippedL):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x + 1 && s.y == slot.y) != null && slots.Find(s => s.x == slot.x + 2 && s.y == slot.y) != null && slots.Find(s => s.x == slot.x + 2 && s.y == slot.y - 1) != null))
                        {
                            Debug.Log("90 Flipped L pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y));
                            Result.Add(slots.Find(s => s.x == slot.x + 2 && s.y == slot.y));
                            Result.Add(slots.Find(s => s.x == slot.x + 2 && s.y == slot.y - 1));
                            Lock(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded = true; break;
                        }
                    }
                }
                break;
            case (PatternType.onehundredeightyflippedL):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x && s.y == slot.y + 1) != null && slots.Find(s => s.x == slot.x && s.y == slot.y + 2) != null && slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 2) != null))
                        {
                            Debug.Log("180 Flipped L pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x && s.y == slot.y + 1));
                            Result.Add(slots.Find(s => s.x == slot.x && s.y == slot.y + 2));
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y + 2));
                            Lock(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded = true; break;
                        }
                    }
                }
                break;
            case (PatternType.twohundredseventyflippedL):
                if (slots.Count >= 4)
                {
                    foreach (Slot slot in slots)
                    {
                        if ((slots.Find(s => s.x == slot.x && s.y == slot.y - 1) != null && slots.Find(s => s.x == slot.x + 1 && s.y == slot.y - 1) != null && slots.Find(s => s.x == slot.x + 2 && s.y == slot.y - 1) != null))
                        {
                            Debug.Log("270 Flipped L pattern complete !");
                            List<Slot> Result = new List<Slot>();
                            Result.Add(slot);
                            Result.Add(slots.Find(s => s.x == slot.x && s.y == slot.y - 1));
                            Result.Add(slots.Find(s => s.x == slot.x + 1 && s.y == slot.y - 1));
                            Result.Add(slots.Find(s => s.x == slot.x + 2 && s.y == slot.y - 1));
                            Lock(Result);
                            GetComponent<TimerSystem>().patternInProgress = false; cleaningNeeded = true; break;
                        }
                    }
                }
                break;
            default:
                break;
        }
        if (cleaningNeeded)
            slots.Clear();
    }

    // Boosts

    void HorIsMine(List<Slot> slots)
    {
        List<Slot> mapSlots = new List<Slot>(GetComponentsInChildren<Slot>());
        List<Slot> horSlots = new List<Slot>();
        horSlots.AddRange(mapSlots.FindAll(s => s.y == slots[0].y));
        Player newOwner = slots[0].owner;
        foreach (Slot slot in horSlots)
        {
            if (slot.owner != slots[0].owner)
                slot.Capture(newOwner);
        }
    }

    void VertIsMine(List<Slot> slots)
    {
        List<Slot> mapSlots = new List<Slot>(GetComponentsInChildren<Slot>());
        List<Slot> vertSlots = new List<Slot>();
        vertSlots.AddRange(mapSlots.FindAll(s => s.x == slots[0].x));
        Player newOwner = slots[0].owner;
        foreach (Slot slot in vertSlots)
        {
            if (slot.owner != slots[0].owner)
                slot.Capture(newOwner);
        }
    }

    void Burst(List<Slot> slots)
    {
        List<Slot> mapSlots = new List<Slot>(GetComponentsInChildren<Slot>());
        List<Slot> adjacentSlots = new List<Slot>();
        foreach (Slot slot in slots)
        {
            adjacentSlots.AddRange(mapSlots.FindAll(x => x.SqrMagnitude(slot) <= 1f));
        }
        Player newOwner = slots[0].owner;
        foreach (Slot slot in adjacentSlots)
        {
            if (slot.owner == null)
            slot.Capture(newOwner);
        }
    }

    void Defrag(List<Slot> slots)
    {
        List<Slot> mapSlots = new List<Slot>(GetComponentsInChildren<Slot>());
        List<Slot> adjacentSlots = new List<Slot>();
        foreach (Slot slot in slots)
        {
            adjacentSlots.AddRange(mapSlots.FindAll(x => x.SqrMagnitude(slot) <= 1f));
        }
        Player newOwner = slots[0].owner;
        foreach (Slot slot in adjacentSlots)
        {
            if (slot.owner != null && slot.owner != newOwner)
                slot.Neutral();
        }
    }

    void Lock(List<Slot> slots)
    {
        foreach (Slot slot in slots)
        {
            slot.locked = true;
        }
        StartCoroutine(LockCoroutine(timeOfLock, slots));
    }

    IEnumerator LockCoroutine(float waitTime, List<Slot> slots)
    {
        yield return new WaitForSeconds(waitTime);
        foreach (Slot slot in slots)
        {
            slot.locked = false;
            slot.SendMessage("Unlock");
        }
    }
}
