var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
console.log("*** Method decorator ***");
function log(target, key, descriptor) {
    console.log(key + " was called!");
}
var P = /** @class */ (function () {
    function P() {
    }
    P.prototype.foo = function () {
        console.log("Do something");
    };
    __decorate([
        log
    ], P.prototype, "foo", null);
    return P;
}());
var p = new P();
p.foo();
// printed to console :
// foo was called!
// Do something
console.log("*** Property Decorator ***");
function calcCircleParams(target, key) {
    // Property value.
    var _val = this[key];
    // Property getter.
    var getter = function () {
        return _val;
    };
    // Property setter.
    var setter = function (newVal) {
        _val = newVal;
        this['Area'] = _val * _val * Math.PI;
        this['Circumference'] = 2 * _val * Math.PI;
    };
    // Delete property.
    if (delete this[key]) {
        // Create new property with getter and setter
        Object.defineProperty(target, key, {
            get: getter,
            set: setter,
            enumerable: true,
            configurable: true
        });
    }
}
var Circle1 = /** @class */ (function () {
    function Circle1() {
    }
    __decorate([
        calcCircleParams
    ], Circle1.prototype, "Radius", void 0);
    return Circle1;
}());
var c = new Circle1();
c.Radius = 3;
console.log("Radius: " + c.Radius + ", Area: " + c.Area + ", Circumference: " + c.Circumference); // Radius: 3, Area: 28.274333882308138, Circumference: 18.84955592153876
c.Radius = 5;
console.log("Radius: " + c.Radius + ", Area: " + c.Area + ", Circumference: " + c.Circumference); // Radius: 5, Area: 78.53981633974483, Circumference: 31.41592653589793
console.log("*** Parameter Decorator ***");
function required(target, key, index) {
    var metadataKey = "__required_" + key + "_parameters";
    if (Array.isArray(target[metadataKey])) {
        target[metadataKey].push(index);
    }
    else {
        target[metadataKey] = [index];
    }
}
function validate(target, key, descriptor) {
    var originalMethod = descriptor.value;
    descriptor.value = function () {
        var args = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            args[_i] = arguments[_i];
        }
        var metadataKey = "__required_" + key + "_parameters";
        var indices = target[metadataKey];
        for (var i = 0; i < args.length; i++) {
            if (arguments[i] == undefined) {
                throw 'missing required parameter';
            }
        }
        var result = originalMethod.apply(this, args);
        return result;
    };
    return descriptor;
}
var Calculator = /** @class */ (function () {
    function Calculator() {
    }
    Calculator.prototype.add = function (a, b) {
        return a + b;
    };
    __decorate([
        validate,
        __param(0, required), __param(1, required)
    ], Calculator.prototype, "add", null);
    return Calculator;
}());
var c1 = new Calculator();
console.log("result is: " + c1.add(2, 3)); // result is: 5
console.log("result is: " + c1.add(2, undefined)); // throw 'missing required parameter'
//# sourceMappingURL=assignment_decorator.js.map