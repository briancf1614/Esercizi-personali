package com.bripot.myfirstcomposeapp.components

import androidx.compose.foundation.layout.Column
import androidx.compose.material3.TextField
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier


@Composable
fun MyTextField(modifier: Modifier = Modifier) {
    Column(modifier = modifier) {
        TextField("Pepe", onValueChange =
        )
    }
}