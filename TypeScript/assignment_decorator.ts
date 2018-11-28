
console.log("*** Method decorator ***");

function log(target, key, descriptor) {
    console.log(`${key} was called!`);
    }
    
    class P {
    @log
    foo() {
    console.log("Do something");
    }
    }
    const p = new P();
    p.foo();
    
    // printed to console :
    // foo was called!
    // Do something

console.log("*** Property Decorator ***");

function calcCircleParams(target: any, key: string) {
    // Property value.
    let _val = this[key];
    // Property getter.
    const getter = function () {
    return _val;
    };
    // Property setter.
    const setter = function (newVal) {
    _val = newVal;
    this['Area'] = _val*_val*Math.PI;
    this['Circumference'] = 2*_val*Math.PI;
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
    
    class Circle1 {
    @calcCircleParams
    public Radius: Number;
    public Area: Number;
    public Circumference: Number;
    constructor() {
    }
    }
    let c = new Circle1();
    c.Radius = 3;
    console.log(`Radius: ${c.Radius}, Area: ${c.Area}, Circumference: ${c.Circumference}`); // Radius: 3, Area: 28.274333882308138, Circumference: 18.84955592153876
    c.Radius = 5;
    console.log(`Radius: ${c.Radius}, Area: ${c.Area}, Circumference: ${c.Circumference}`); // Radius: 5, Area: 78.53981633974483, Circumference: 31.41592653589793

console.log("*** Parameter Decorator ***");

function required(target: any, key: string, index: number) {
    var metadataKey = `__required_${key}_parameters`;
    if (Array.isArray(target[metadataKey])) {
    target[metadataKey].push(index);
    }
    else {
    target[metadataKey] = [index];
    }
    }
    function validate(target, key, descriptor) {
    var originalMethod = descriptor.value;
    descriptor.value = function (...args: any[]) {
    var metadataKey = `__required_${key}_parameters`;
    var indices = target[metadataKey];
    for (var i = 0; i < args.length; i++) {
    if (arguments[i] == undefined) {
    throw 'missing required parameter'
    }
    }
    var result = originalMethod.apply(this, args);
    return result;
    }
    return descriptor;
    }
    class Calculator {
    @validate
    add(@required a: number, @required b: number) {
    return a + b;
    }
    }
    const c1 = new Calculator();
    console.log(`result is: ${c1.add(2,3)}`); // result is: 5
    console.log(`result is: ${c1.add(2,undefined)}`); // throw 'missing required parameter'

    
      