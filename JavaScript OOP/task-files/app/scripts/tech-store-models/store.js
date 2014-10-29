/// <reference path="item.js" />
define(['tech-store-models/item'], function (Item) {
    'use strict';
    var Store;
    Store = (function () {
        //Store constructor
        function Store(name) {
            self = this;
            self._items = [];

            if (name.lenght > 6 && name.lenght < 30) {
                self.name = name;
            }
        }
        // FUNCTION FOR SORTING ARRAY BY NAME
        function sortByName(arrayToSortByName) {
            arrayToSortByName.sort(function (a, b) {
                if (a.name > b.name)
                    return 1;
                if (a.name < b.name)
                    return -1;
                return 0;
            });
        }
        // FUNCTION FOR SORTING ARRAY BY PRICE
        function sortByPrice(arrayToSortByPrice) {
            arrayToSortByPrice.sort(function (a, b) {
                if (a.price > b.price)
                    return 1;
                if (a.price < b.price)
                    return -1;
                return 0;
            });
        }
        // ADDING ITEM TO THE STORE
        Store.prototype.addItem = function (itemToAdd) {
            if (!(itemToAdd instanceof Item)) {
                throw new Error('Trying to add something different from Item to the Store');
            }
            self._items.push(itemToAdd);

            return self
        }

        // GET ALL
        Store.prototype.getAll = function () {
            self._allItems = self._items.slice();

            sortByName(self._allItems);
            
            return self._allItems;
        }
        //GET SMART PHONES
        Store.prototype.getSmartPhones = function () {
            self._smartPhones = [];
            for (var i = 0, len = self._items.length, currentElement; i < len; i++) {

                currentElement = self._items[i];
                if (currentElement.type == 'smart-phone') {

                    self._smartPhones.push(currentElement);
                }
            }
            sortByName(self._smartPhones);
            return self._smartPhones.slice();
        }
        //GET MOBILES
        Store.prototype.getMobiles = function () {
            self._mobiles = [];
            for (var i = 0, len = self._items.length, currentElement; i < len; i++) {

                currentElement = self._items[i];
                if (currentElement.type == 'smart-phone' ||
                    currentElement.type == 'tablet') {

                    self._mobiles.push(currentElement);
                }
            }
            sortByName(self._mobiles);
            return self._mobiles.slice();

        }

        //GET COMPTERS
        Store.prototype.getComputers = function () {
            self._computers = [];
            for (var i = 0, len = self._items.length, currentElement; i < len; i++) {

                currentElement = self._items[i];
                if (currentElement.type == 'pc' ||
                    currentElement.type == 'notebook') {

                    self._computers.push(currentElement);
                }
            }
            sortByName(self._computers);
            return self._computers.slice();
        }

        //FILTER ITEMS BY TYPE
        Store.prototype.filterItemsByType = function (filterType) {
            self._filteredByType = [];
            for (var i = 0, len = self._items.length, currentElement; i < len; i++) {

                currentElement = self._items[i];
                if (currentElement.type == filterType) {

                    self._filteredByType.push(currentElement);
                }
            }
            sortByName(self._filteredByType);
            return self._filteredByType.slice();
        }

        // FILTER ITEMS BY PRICE
        Store.prototype.filterItemsByPrice = function (options) {
            self._filteredByPrice = [];
            if (options) {
                //If there is MIN and MAX
                if (options.min && options.max) {
                    for (var i = 0, len = self._items.length, currentElement; i < len; i++) {

                        currentElement = self._items[i];
                        if ((currentElement.price >= options.min) && (currentElement.price <= options.max)) {

                            self._filteredByPrice.push(currentElement);
                        }
                    }
                }
                    //If there is ONLY MIN 
                else if (options.min) {
                    options.max = Number.POSITIVE_INFINITY;
                    for (var i = 0, len = self._items.length, currentElement; i < len; i++) {

                        currentElement = self._items[i];
                        if (currentElement.price >= options.min) {
                            self._filteredByPrice.push(currentElement);
                        }
                    }
                }
                    //If there is ONLY MAX 
                else if (options.max) {
                    options.min = 0;
                    for (var i = 0, len = self._items.length, currentElement; i < len; i++) {
                        currentElement = self._items[i];
                        if (currentElement.price <= options.max) {
                            self._filteredByPrice.push(currentElement);
                        }
                    }
                }
            } else  {
					//This is the case when the options does not exist at all
                self._filteredByPrice = self._items.slice();
            }
                self._filteredByPrice.sort(function (a, b) {
                    if (a.price > b.price)
                        return 1;
                    if (a.price < b.price)
                        return -1;
                    return 0;
                });
                sortByPrice(self._filteredByPrice);


            return self._filteredByPrice;

        }
        //FILTER ITEMS BY NAME
        Store.prototype.filterItemsByName = function (partOfName) {
            self._filteredByName = [];
            for (var i = 0, len = self._items.length, currentElement; i < len; i++) {

                currentElement = self._items[i];
                if (currentElement.name.toLowerCase().indexOf(partOfName.toLowerCase()) > -1) {

                    self._filteredByName.push(currentElement);
                }
            }
            self._filteredByName.sort(function (a, b) {
                if (a.name > b.name)
                    return 1;
                if (a.name < b.name)
                    return -1;
                return 0;
            });
            return self._filteredByName.slice();
        }
        // COUNT ITEMS BY TYPE
        Store.prototype.countItemsByType = function () {
            self._countItemsByType = {
                'accessory': 0,
                'smart-phone': 0,
                'notebook': 0,
                'pc': 0,
                'tablet' : 0
            };

            var currentElement,
                currentElementType
            for (var i = 0, len = self._items.length; i < len; i++) {
                currentElement = self._items[i];
                currentElementType = currentElement.type;
                self._countItemsByType[currentElementType] += 1;

            }
            return self._countItemsByType;

        }


        return Store;
    }());
    return Store;
})