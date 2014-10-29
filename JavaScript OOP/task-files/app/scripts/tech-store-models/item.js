define(function () {
    'use strict';
    var Item;
    Item = (function () {
        // Items constructor
        function Item(type, name, price) {
			// Check if the name of the Item is valid
            if ((name.length >= 6) && (name.length <= 40)) {
                this.name = name;
            }
                this.price = price;

            // Check if the type of the Item is valid
            if ((type == 'accessory') ||
                (type == 'smart-phone') ||
                (type == 'notebook') ||
                (type == 'pc') ||
                (type == 'tablet')) {
                this.type = type;
            }
        }

        return Item;
    }());
    return Item;
})