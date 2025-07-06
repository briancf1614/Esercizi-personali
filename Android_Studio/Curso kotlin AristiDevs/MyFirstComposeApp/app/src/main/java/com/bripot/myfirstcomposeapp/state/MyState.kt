package com.bripot.myfirstcomposeapp.state

import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Column
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableIntStateOf
import androidx.compose.runtime.saveable.rememberSaveable
import androidx.compose.runtime.setValue
import androidx.compose.ui.Modifier

// Roba figa per poter cambiare el valor de numerito resiste al ondestroy al girare lo schermo
@Composable
fun MyState(modifier: Modifier) {
    var number by rememberSaveable { mutableIntStateOf(0) }
    Column(modifier = modifier) {
        StateExample1(number, onClick = { number++ })
        StateExample2(number, { number++ })
    }
}

@Composable
fun StateExample1(number : Int, onClick: () -> Unit) {
    // Il remember o il rememberSaveable è necesario perche se non lo meto il
    // ricaricatore automatico reinicia el valor a 0
    // recomposicion
    // al decir val estoy diciendo que la caja es no modificabile ma solo il contenuto ma se uso il by stoy usando
    // directamente el contenido de la caja que si es modificable por eso el var
    Text("Pulsame $number", modifier = Modifier.clickable { onClick() })

}

@Composable
fun StateExample2(number : Int, onClick: () -> Unit) {
    Text("pulsame 2: $number", modifier = Modifier.clickable { onClick() })
}