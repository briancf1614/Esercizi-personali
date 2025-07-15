package com.bripot.myfirstcomposeapp.components

import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.width
import androidx.compose.material3.Checkbox
import androidx.compose.material3.CheckboxDefaults
import androidx.compose.material3.Icon
import androidx.compose.material3.Switch
import androidx.compose.material3.SwitchDefaults
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.unit.dp
import com.bripot.myfirstcomposeapp.R
import com.bripot.myfirstcomposeapp.components.state.CheckBoxState

@Composable
fun MySwitch(modifier: Modifier = Modifier) {
    var switchState by remember { mutableStateOf(true) }
    Box(modifier = modifier.fillMaxSize(), contentAlignment = Alignment.Center) {
        Switch(
            checked = switchState,
            onCheckedChange = { switchState = it },
            thumbContent = {
                Icon(
                    painter = painterResource(R.drawable.ic_personita),
                    contentDescription = null
                )
            }, enabled = true,
            colors = SwitchDefaults.colors(
                // Bolita
                checkedThumbColor = Color.Red,
                uncheckedThumbColor = Color.Blue,
                disabledCheckedThumbColor = Color.Yellow,
                disabledUncheckedThumbColor = Color.Cyan,
                //Icono
                checkedIconColor = Color.Green,
                uncheckedIconColor = Color.Cyan,
                disabledUncheckedIconColor = Color.Green,
                disabledCheckedIconColor = Color.Red,

                // Borde
                checkedBorderColor = Color.Magenta,
                uncheckedBorderColor = Color.Magenta,
                disabledCheckedBorderColor = Color.Magenta,
                disabledUncheckedBorderColor = Color.Magenta,

                //Track
                checkedTrackColor = Color.White,
                uncheckedTrackColor = Color.White,
                disabledCheckedTrackColor = Color.White,
                disabledUncheckedTrackColor = Color.White,
            )
        )
    }
}

@Composable
fun MyCheckbox(modifier: Modifier = Modifier) {
    var state by remember { mutableStateOf(true) }
    Box(modifier = modifier.fillMaxSize(), contentAlignment = Alignment.Center) {
        Row(
            verticalAlignment = Alignment.CenterVertically,
            modifier = modifier.clickable { state = !state }) {
            Checkbox(
                checked = state,
                onCheckedChange = { state = it },
                colors = CheckboxDefaults.colors(
                    checkedColor = Color.Red,
                    uncheckedColor = Color.Blue,
                    checkmarkColor = Color.DarkGray,
                    disabledCheckedColor = Color.Green,
                    disabledUncheckedColor = Color.Yellow
                )
            )
            Spacer(Modifier.width(13.dp))
            Text("Acepto los terminos")
        }
    }
}

@Composable
fun ParentCheckBoxes(modifier: Modifier = Modifier) {
    var state by remember {
        mutableStateOf(
            listOf(
                CheckBoxState(
                    id = "terms",
                    label = "Acepto los terminos"
                ),
                CheckBoxState(
                    id = "newsLetter",
                    label = "Recivir news letter",
                    checked = true
                ),
                CheckBoxState(
                    id = "updates",
                    label = "Recivir updates?"
                )
            )
        )
    }
    Column(modifier = modifier.fillMaxSize()) {
        state.forEach { myState ->
            CheckBocxWithText(
                checkBoxState = myState
            ) {
                // TErminologia di state hoisting in pratica significa che lo stato non cèla la UI ma la lavoriamo tramite codice(credo)
                state = state.map {
                    if (it.id == myState.id){
                        myState.copy(checked =  !myState.checked)
                    }else{
                        it
                    }
                }
            }
        }
    }
}

@Composable
fun CheckBocxWithText(
    modifier: Modifier = Modifier,
    checkBoxState: CheckBoxState,
    onCheckedChange: (CheckBoxState) -> Unit
) {
    Row(
        verticalAlignment = Alignment.CenterVertically,
        modifier = modifier.clickable { onCheckedChange(checkBoxState) }) {
        Checkbox(
            checked = checkBoxState.checked,
            onCheckedChange = { onCheckedChange(checkBoxState) },
            colors = CheckboxDefaults.colors(
                checkedColor = Color.Red,
                uncheckedColor = Color.Blue,
                checkmarkColor = Color.DarkGray,
                disabledCheckedColor = Color.Green,
                disabledUncheckedColor = Color.Yellow
            )
        )
        Spacer(Modifier.width(13.dp))
        Text(checkBoxState.label)
    }
}