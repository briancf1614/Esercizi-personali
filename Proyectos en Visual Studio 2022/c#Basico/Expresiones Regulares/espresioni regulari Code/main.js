// const  regex = /^hola amigos$/;//empiesa y termina toda la frase entera
// * indica infinitas veces aaaaaaaaa osea que se repite varias veces




const regex = /^a*e*$/
const texto="abc";

console.log("Hola mundo");

if(regex.test(texto)){
    console.log("Es correcto");
}else{
    console.log("No es correcto");
}