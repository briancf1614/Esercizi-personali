//add property to a class

function gentlemanApproves<T extends { new(...args: any[]):{}}>(constructor: T): T {
    return class extends constructor{
        gentleman = 'Yes';
    };
}

@gentlemanApproves
class MyClass {

    constructor(){
    }
}
const instance = new MyClass();
console.log((instance as any).gentleman);