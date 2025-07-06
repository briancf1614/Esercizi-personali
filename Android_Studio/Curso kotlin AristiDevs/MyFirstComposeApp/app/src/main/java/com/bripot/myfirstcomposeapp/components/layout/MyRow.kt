package com.bripot.myfirstcomposeapp.components.layout

import androidx.compose.foundation.background
import androidx.compose.foundation.horizontalScroll
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.rememberScrollState
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color


@Composable
fun MyRow(modifier : Modifier){
    Row (modifier = modifier.fillMaxWidth().horizontalScroll(rememberScrollState())){
        Text("Hola 1", Modifier.background(Color.Red))
        Text("Hola 2", Modifier.background(Color.Blue))
        Text("Hola 3", Modifier.background(Color.Cyan))
        Text("Hola 1", Modifier.background(Color.Red))
        Text("Hola 2", Modifier.background(Color.Blue))
        Text("Hola 3", Modifier.background(Color.Cyan))
        Text("Hola 1", Modifier.background(Color.Red))
        Text("Hola 2", Modifier.background(Color.Blue))
        Text("Hola 3", Modifier.background(Color.Cyan))
        Text("Hola 1", Modifier.background(Color.Red))
        Text("Hola 2", Modifier.background(Color.Blue))
        Text("Hola 3", Modifier.background(Color.Cyan))
        Text("Hola 1", Modifier.background(Color.Red))
        Text("Hola 2", Modifier.background(Color.Blue))
        Text("Hola 3", Modifier.background(Color.Cyan))
        Text("Hola 1", Modifier.background(Color.Red))
        Text("Hola 2", Modifier.background(Color.Blue))
        Text("Hola 3", Modifier.background(Color.Cyan))
        Text("Hola 1", Modifier.background(Color.Red))
        Text("Hola 2", Modifier.background(Color.Blue))
        Text("Hola 3", Modifier.background(Color.Cyan))
        Text("Hola 1", Modifier.background(Color.Red))
        Text("Hola 2", Modifier.background(Color.Blue))
        Text("Hola 3", Modifier.background(Color.Cyan))
        Text("Hola 1", Modifier.background(Color.Red))
        Text("Hola 2", Modifier.background(Color.Blue))
        Text("Hola 3", Modifier.background(Color.Cyan))
        Text("Hola 1", Modifier.background(Color.Red))
        Text("Hola 2", Modifier.background(Color.Blue))
        Text("Hola 3", Modifier.background(Color.Cyan))
    }
}