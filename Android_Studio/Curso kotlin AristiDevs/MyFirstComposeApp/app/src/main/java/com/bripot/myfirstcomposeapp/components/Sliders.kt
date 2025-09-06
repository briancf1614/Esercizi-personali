@file:OptIn(ExperimentalMaterial3Api::class)

package com.bripot.myfirstcomposeapp.components

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.shape.CircleShape
import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.material3.RangeSlider
import androidx.compose.material3.RangeSliderState
import androidx.compose.material3.Slider
import androidx.compose.material3.SliderDefaults
import androidx.compose.material3.SliderState
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableFloatStateOf
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.unit.dp

@Composable
fun MySlider(modifier: Modifier = Modifier) {
    var myValue by remember { mutableFloatStateOf(0f) }
    Column(modifier = modifier.padding(horizontal = 30.dp)) {
        Slider(
            enabled = true,
            value = myValue, onValueChange = { myValue = it }, colors = SliderDefaults.colors(
                thumbColor = Color.Red,
                disabledThumbColor = Color.Blue,
                activeTrackColor = Color.Green,
                activeTickColor = Color.Magenta,
                disabledActiveTrackColor = Color.Yellow,
                disabledActiveTickColor = Color.Cyan,
                inactiveTrackColor = Color.DarkGray,
                inactiveTickColor = Color.LightGray,
                disabledInactiveTickColor = Color.Gray,
                disabledInactiveTrackColor = Color.Black

            )
        )
        Text(myValue.toString())
    }
}

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun MySliderAdvance(modifier: Modifier = Modifier) {
    var example by remember { mutableStateOf(":(") }
    val state = remember {
        SliderState(
            value = 5f,
            valueRange = 0f..10f,
            steps = 9,
            onValueChangeFinished = { example = "FELIZ" }
        )
    }

    val colors = SliderDefaults.colors(
        thumbColor = Color.Red,
        disabledThumbColor = Color.Blue,
        activeTrackColor = Color.Green,
        activeTickColor = Color.Magenta,
        disabledActiveTrackColor = Color.Yellow,
        disabledActiveTickColor = Color.Cyan,
        inactiveTrackColor = Color.DarkGray,
        inactiveTickColor = Color.LightGray,
        disabledInactiveTickColor = Color.Gray,
        disabledInactiveTrackColor = Color.Black

    )

    Column(modifier = modifier.padding(horizontal = 30.dp)) {
        Slider(
            state = state,
            colors = colors,
            thumb = { state: SliderState -> Text(state.value.toString()) },
            track = { state: SliderState ->
                Box(
                    Modifier
                        .fillMaxWidth()
                        .height(30.dp)
                        .background(Color.Red)
                )
            }
        )
//        Text(state.value.toString())
        Text(example)
    }

}

@Composable
fun MyRangeSlider(modifier: Modifier = Modifier) {
    var state = remember {
        RangeSliderState(
            activeRangeStart = 3f,
            activeRangeEnd = 6f,
            valueRange = 0f..10f,
            steps = 8,
            onValueChangeFinished = {}
        )
    }
    val colors = SliderDefaults.colors(
        thumbColor = Color.Red,
        disabledThumbColor = Color.Blue,
        activeTrackColor = Color.Green,
        activeTickColor = Color.Magenta,
        disabledActiveTrackColor = Color.Yellow,
        disabledActiveTickColor = Color.Cyan,
        inactiveTrackColor = Color.DarkGray,
        inactiveTickColor = Color.LightGray,
        disabledInactiveTickColor = Color.Gray,
        disabledInactiveTrackColor = Color.Black

    )
    Column(modifier.padding(horizontal = 30.dp)) {
        RangeSlider(state = state, colors = colors, startThumb = {
            Box(
                Modifier
                    .size(30.dp)
                    .clip(CircleShape)
                    .background(Color.Cyan),
                contentAlignment = Alignment.Center
            ) {
                Text(String.format("%.1f", it.activeRangeStart))
            }
        }, endThumb = {
            Box(
                Modifier
                    .size(30.dp)
                    .clip(CircleShape)
                    .background(Color.Cyan),
                contentAlignment = Alignment.Center
            ) {
                Text(String.format("%.1f", it.activeRangeEnd))
            }
        })
    }
}