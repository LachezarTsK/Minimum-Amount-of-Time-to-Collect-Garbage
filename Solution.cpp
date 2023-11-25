
#include <vector>
#include <string>
#include <string_view>
using namespace std;

class Solution {

    enum class Type {Glass = 'G', Metal = 'M', Paper = 'P'};

    struct Garbage {
    
        Type type;
        int collectedUnits = 0;
        int travelTimeFromStart = 0;

        explicit Garbage(Type type): type {type}{}
    };

    Garbage glassGarbage {Type::Glass};
    Garbage metalGarbage {Type::Metal};
    Garbage paperGarbage {Type::Paper};

public:
    int garbageCollection(const vector<string>& garbage, const vector<int>& travel) {
        
        int travelTimeFromStart = 0;
        collectGarbageFromHouse(garbage[0], travelTimeFromStart);

        for (size_t i = 1; i < garbage.size(); ++i) {
            travelTimeFromStart += travel[i - 1];
            collectGarbageFromHouse(garbage[i], travelTimeFromStart);
        }

        int minMinutesToPickUpAllGarbage
                = glassGarbage.collectedUnits + glassGarbage.travelTimeFromStart
                + metalGarbage.collectedUnits + metalGarbage.travelTimeFromStart
                + paperGarbage.collectedUnits + paperGarbage.travelTimeFromStart;

        return minMinutesToPickUpAllGarbage;
    }

private:
    //alternative to 'string_view': 'const string&'
    void collectGarbageFromHouse(string_view garbage, int travelTimeFromStart) {
        for (const auto& current : garbage) {
            if (current == static_cast<underlying_type_t<Type>>(Type::Glass)) {
                ++glassGarbage.collectedUnits;
                glassGarbage.travelTimeFromStart = travelTimeFromStart;
            } else if (current == static_cast<underlying_type_t<Type>>(Type::Metal)) {
                ++metalGarbage.collectedUnits;
                metalGarbage.travelTimeFromStart = travelTimeFromStart;
            } else {
                ++paperGarbage.collectedUnits;
                paperGarbage.travelTimeFromStart = travelTimeFromStart;
            }
        }
    }
};
