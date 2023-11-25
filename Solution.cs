
using System;

public class Solution
{
    Garbage glassGarbage = new Garbage(Type.Glass);
    Garbage metalGarbage = new Garbage(Type.Metal);
    Garbage paperGarbage = new Garbage(Type.Paper);

    public int GarbageCollection(string[] garbage, int[] travel)
    {
        int travelTimeFromStart = 0;
        CollectGarbageFromHouse(garbage[0], travelTimeFromStart);

        for (int i = 1; i < garbage.Length; ++i)
        {
            travelTimeFromStart += travel[i - 1];
            CollectGarbageFromHouse(garbage[i], travelTimeFromStart);
        }

        int minMinutesToPickUpAllGarbage
                = glassGarbage.collectedUnits + glassGarbage.travelTimeFromStart
                + metalGarbage.collectedUnits + metalGarbage.travelTimeFromStart
                + paperGarbage.collectedUnits + paperGarbage.travelTimeFromStart;

        return minMinutesToPickUpAllGarbage;
    }

    private void CollectGarbageFromHouse(String garbage, int travelTimeFromStart)
    {
        foreach (char current in garbage)
        {
            if (current == (char)Type.Glass)
            {
                ++glassGarbage.collectedUnits;
                glassGarbage.travelTimeFromStart = travelTimeFromStart;
            }
            else if (current == (char)Type.Metal)
            {
                ++metalGarbage.collectedUnits;
                metalGarbage.travelTimeFromStart = travelTimeFromStart;
            }
            else
            {
                ++paperGarbage.collectedUnits;
                paperGarbage.travelTimeFromStart = travelTimeFromStart;
            }
        }
    }
}

enum Type
{
    Glass = 'G', Metal = 'M', Paper = 'P'
}

struct Garbage
{
    public Type type;
    public int collectedUnits = 0;
    public int travelTimeFromStart = 0;

    public Garbage(Type type)
    {
        this.type = type;
    }
}
