"use strict";
exports.__esModule = true;
exports.Person = void 0;
var Person = /** @class */ (function () {
    function Person(name, age) {
        this.age = age;
        this.name = name;
    }
    Person.prototype.getName = function () {
        return this.name;
    };
    //property
    Person.prototype.getDetails = function () {
        return this.name + ", " + this.age;
    };
    return Person;
}());
exports.Person = Person;
