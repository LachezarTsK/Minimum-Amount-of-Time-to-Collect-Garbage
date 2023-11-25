
/**
 * @param {string[]} garbage
 * @param {number[]} travel
 * @return {number}
 */
var garbageCollection = function (garbage, travel) {
    this.Type = {Glass: 'G', Metal: 'M', Paper: 'P'};
    this.glassGarbage = new Garbage(this.Type.Glass);
    this.metalGarbage = new Garbage(this.Type.Metal);
    this.paperGarbage = new Garbage(this.Type.Paper);

    let travelTimeFromStart = 0;
    collectGarbageFromHouse(garbage[0], travelTimeFromStart);

    for (let i = 1; i < garbage.length; ++i) {
        travelTimeFromStart += travel[i - 1];
        collectGarbageFromHouse(garbage[i], travelTimeFromStart);
    }

    let minMinutesToPickUpAllGarbage
            = this.glassGarbage.collectedUnits + this.glassGarbage.travelTimeFromStart
            + this.metalGarbage.collectedUnits + this.metalGarbage.travelTimeFromStart
            + this.paperGarbage.collectedUnits + this.paperGarbage.travelTimeFromStart;

    return minMinutesToPickUpAllGarbage;
};

/**
 * @param {string[]} garbage
 * @param {number} travelTimeFromStart
 * @return {void}
 */
function collectGarbageFromHouse(garbage, travelTimeFromStart) {
    for (let current of garbage) {
        if (current === this.Type.Glass) {
            ++this.glassGarbage.collectedUnits;
            this.glassGarbage.travelTimeFromStart = travelTimeFromStart;
        } else if (current === this.Type.Metal) {
            ++this.metalGarbage.collectedUnits;
            this.metalGarbage.travelTimeFromStart = travelTimeFromStart;
        } else {
            ++this.paperGarbage.collectedUnits;
            this.paperGarbage.travelTimeFromStart = travelTimeFromStart;
        }
    }
}


class Garbage {

    /**
     * @param {Type} type
     */
    constructor(type) {
        this.type = type;
        this.collectedUnits = 0;
        this.travelTimeFromStart = 0;
    }
}
