
using System;

public class Solution
{
    readonly Garbage glassGarbage = new Garbage(Type.Glass);
    readonly Garbage metalGarbage = new Garbage(Type.Metal);
    readonly Garbage paperGarbage = new Garbage(Type.Paper);

    public int GarbageCollection(string[] garbage, int[] travel)
    {
        int travelTimeFromStart = 0;
        collectGarbageFromHouse(garbage[0], travelTimeFromStart);

        for (int i = 1; i < garbage.Length; ++i)
        {
            travelTimeFromStart += travel[i - 1];
            collectGarbageFromHouse(garbage[i], travelTimeFromStart);
        }

        int minMinutesToPickUpAllGarbage
                = glassGarbage.collectedUnits + glassGarbage.travelTimeFromStart
                + metalGarbage.collectedUnits + metalGarbage.travelTimeFromStart
                + paperGarbage.collectedUnits + paperGarbage.travelTimeFromStart;

        return minMinutesToPickUpAllGarbage;
    }

    private void collectGarbageFromHouse(String garbage, int travelTimeFromStart)
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
    Glass = 'G', Metal = 'M', Paper = 'P';
}

class Garbage
{
    public Type type;
    public int collectedUnits;
    public int travelTimeFromStart;

    public Garbage(Type type)
    {
        this.type = type;
    }
}
