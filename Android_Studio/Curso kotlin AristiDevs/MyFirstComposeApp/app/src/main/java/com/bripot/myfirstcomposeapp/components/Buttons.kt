package com.bripot.myfirstcomposeapp.components

import android.util.Log
import androidx.compose.foundation.BorderStroke
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.ElevatedButton
import androidx.compose.material3.FilledTonalButton
import androidx.compose.material3.OutlinedButton
import androidx.compose.material3.Text
import androidx.compose.material3.TextButton
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.unit.dp

@Composable
fun MyButon(modifier: Modifier) {
    Column(modifier) {
        Button(
            onClick = { Log.i("Aris", "Button pressionato") },
            enabled = false,
            shape = RoundedCornerShape(20),
            border = BorderStroke(2.dp, Color.Red),
//            Interesante che si puo modificare il colore del default
            colors = ButtonDefaults.buttonColors(
                contentColor = Color.Red,
                containerColor = Color.White,
                disabledContainerColor = Color.Green,
                disabledContentColor = Color.Blue
            )
        ) {
            Text("Cliccami")
        }

//        Il outlineButton inquesto caso non è altro che un button con i parametri predefiniti tipo vuoti o buh
        OutlinedButton(
            onClick = {},
            enabled = false,
            colors = ButtonDefaults.outlinedButtonColors(
                containerColor = Color.Yellow,
                disabledContainerColor = Color.Blue
            )
        ) {
            Text("Outlined")
        }

        TextButton(onClick = {}) {
            Text("Hola amigos")
        }

        ElevatedButton(onClick = {},
            elevation = ButtonDefaults.elevatedButtonElevation(defaultElevation = 100.dp, focusedElevation = 100.dp)) {
            Text("ElevatedButton")
        }

        FilledTonalButton(onClick = {}) {

        }
    }
}