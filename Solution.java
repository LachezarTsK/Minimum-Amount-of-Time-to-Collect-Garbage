
public class Solution {

    private final Garbage glassGarbage = new Garbage(Type.Glass);
    private final Garbage metalGarbage = new Garbage(Type.Metal);
    private final Garbage paperGarbage = new Garbage(Type.Paper);

    public int garbageCollection(String[] garbage, int[] travel) {

        int travelTimeFromStart = 0;
        collectGarbageFromHouse(garbage[0], travelTimeFromStart);

        for (int i = 1; i < garbage.length; ++i) {
            travelTimeFromStart += travel[i - 1];
            collectGarbageFromHouse(garbage[i], travelTimeFromStart);
        }

        int minMinutesToPickUpAllGarbage
                = glassGarbage.collectedUnits + glassGarbage.travelTimeFromStart
                + metalGarbage.collectedUnits + metalGarbage.travelTimeFromStart
                + paperGarbage.collectedUnits + paperGarbage.travelTimeFromStart;

        return minMinutesToPickUpAllGarbage;
    }

    private void collectGarbageFromHouse(String garbage, int travelTimeFromStart) {
        for (int i = 0; i < garbage.length(); ++i) {
            char current = garbage.charAt(i);
            if (current == Type.Glass.abbreviation) {
                ++glassGarbage.collectedUnits;
                glassGarbage.travelTimeFromStart = travelTimeFromStart;
            } else if (current == Type.Metal.abbreviation) {
                ++metalGarbage.collectedUnits;
                metalGarbage.travelTimeFromStart = travelTimeFromStart;
            } else {
                ++paperGarbage.collectedUnits;
                paperGarbage.travelTimeFromStart = travelTimeFromStart;
            }
        }
    }
}

enum Type {
    Glass('G'), Metal('M'), Paper('P');
    char abbreviation;

    Type(char abbreviation) {
        this.abbreviation = abbreviation;
    }
}

class Garbage {

    Type type;
    int collectedUnits;
    int travelTimeFromStart;

    Garbage(Type type) {
        this.type = type;
    }
}
