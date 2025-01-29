// OOJS and ECMAScript6 Combined Demo

// 1. let, var, const: Variable Declarations
function VariableDemo() {
    var x = 10; // function-scoped
    let y = 20; // block-scoped
    const z = 30; // block-scoped, cannot be reassigned

    if (true) {
        var x = 40; // re-declared globally in function scope
        let y = 50; // block-scoped inside if block
        console.log('Inside block: ', x, y, z); // Output: 40, 50, 30
    }

    console.log('Outside block: ', x, y, z); // Output: 40, 20, 30
}
VariableDemo();

// 2. OOJS: Class Implementation, Static Methods, Property Declaration
class Animal {
    // Property declaration in ES6+ syntax
    type = 'Mammal'; // Class-level property
    
    constructor(name, sound) {
        this.name = name;
        this.sound = sound;
    }

    // Instance method
    Speak() {
        console.log(`${this.name} makes a ${this.sound} sound.`);
    }

    // Static method: Belongs to the class, not instances
    static Kingdom() {
        return 'Animalia';
    }
}

const dog = new Animal('Dog', 'bark');
dog.Speak(); // Output: Dog makes a bark sound.
console.log(Animal.Kingdom()); // Output: Animalia

// 3. Arrow Functions: Shorter Syntax for Functions
const Greet = (name) => `Hello, ${name}!`;
console.log(Greet('Alice')); // Output: Hello, Alice!

// Arrow function for simple addition
const Add = (a, b) => a + b;
console.log(Add(5, 10)); // Output: 15

// 4. Import and Export (Conceptual Example)
// file1.js
// export const message = 'Hello, World!';
// export function SayHello(name) { return `Hello, ${name}!`; }

// file2.js
// import { message, SayHello } from './file1.js';
// console.log(message); // Output: Hello, World!
// console.log(SayHello('Alice')); // Output: Hello, Alice!

// 5. Async/Await: Handling Asynchronous Code
const FetchData = async () => {
    const promise = new Promise((resolve) => {
        setTimeout(() => resolve('Data fetched!'), 10000);
    });
    
    const result = await promise; // Wait for the promise to resolve
    console.log(result); // Output: Data fetched!
};
FetchData();

// 6. Comparison Operators: == vs ===, != vs !==
console.log(5 == '5');  // Output: true (type coercion happens)
console.log(5 === '5'); // Output: false (strict comparison, different types)

console.log(5 != '5');  // Output: false (type coercion happens)
console.log(5 !== '5'); // Output: true (strict comparison, different types)
