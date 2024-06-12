const inventory = [
    { name: "asparagus", type: "vegetables", quantity: 5 },
    { name: "bananas", type: "fruit", quantity: 0 },
    { name: "goat", type: "meat", quantity: 23 },
    { name: "cherries", type: "fruit", quantity: 5 },
    { name: "fish", type: "meat", quantity: 22 },
];

const groupBy = () => {
    const groupedInventory = inventory.reduce((acc, item) => {
        const { type, ...rest } = item;
        if (!acc[type]) {
            acc[type] = [];
        }
        acc[type].push(rest);
        return acc;
    }, {});
    console.log(groupedInventory);
}
(function main() {
    groupBy();
}());
