using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    public enum PatternType
    {
        horizontalline,
        verticalline,
        square,
        T,
        ninetyT,
        onehundredeightyT,
        twohundredseventyT,
        L,
        ninetyL,
        onehundredeightyL,
        twohundredseventyL,
        flippedL,
        ninetyflippedL,
        onehundredeightyflippedL,
        twohundredseventyflippedL,
        S,
        ninetyS,
        flippedS,
        ninetyflippedS
    }
    public PatternType currentpattern;

    public List<Slot> CheckForPattern(List<Slot> slots)
    {
        switch (currentpattern)
        {
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
                            return Result;
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
                            Result.Add(slots.Find(s => s.y == slot.y + 2 && s.x == slot.x));
                            Result.Add(slots.Find(s => s.x == slot.x && s.y == slot.y + 3));
                            return Result;
                        }
                    }
                }
                break;
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
                            return Result;
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
                            return Result;
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
                            return Result;
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
                            return Result;
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
                            return Result;
                        }
                    }
                }
                break;
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
                            return Result;
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
                            return Result;
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
                            return Result;
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
                            return Result;
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
                            return Result;
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
                            return Result;
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
                            return Result;
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
                            return Result;
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
                            return Result;
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
                            return Result;
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
                            return Result;
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
                            return Result;
                        }
                    }
                }
                break;
            default:
                break;
        }
        return new List<Slot>();
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
            slot.Capture(newOwner);
        }
    }
}
