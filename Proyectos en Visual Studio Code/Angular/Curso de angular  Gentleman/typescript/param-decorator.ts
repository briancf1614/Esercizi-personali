function registrarYModificarArgumentos(
    method:Function,
    context: ClassAccessorDecoratorContext
){
    return function(...args:any[]){
        const argsModified = args.map((args) =>{
            typeof args === 'string' ? args.toUpperCase() : args;
        });

        console.log (`Method ${String(context.name)} called with arguments: ${argsModified}`);
        return method.apply(this, argsModified);
    }
}




class Saludar{
    saludar(parametro : string){
        console.log('Hola ' + parametro);
    }
}