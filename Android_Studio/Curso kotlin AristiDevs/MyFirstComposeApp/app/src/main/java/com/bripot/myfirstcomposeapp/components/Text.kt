package com.bripot.myfirstcomposeapp.components

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontStyle
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.text.style.TextDecoration
import androidx.compose.ui.text.style.TextOverflow
import androidx.compose.ui.unit.sp

@Composable
fun MyText(modifier: Modifier) {
    Column(modifier) {
        Text(text = "Pepe");
        Text(text = "Pepe Rojo", color = Color.Red);
        Text(text = "Pepe Rojo", fontSize = 19.sp);
        Text(text = "Pepe Rojo", fontStyle = FontStyle.Italic);
        Text(text = "Pepe Rojo", fontWeight = FontWeight.W900);
        Text(text = "Pepe Rojo", letterSpacing = 20.sp);
        Text(text = "Pepe Rojo", textDecoration = TextDecoration.LineThrough);
        Text(
            text = "Pepe Rojo",
            textDecoration = TextDecoration.LineThrough + TextDecoration.Underline
        );
        Text(
            text = "Pepe Rojo Pepe Rojo Pepe Rojo Pepe Rojo Pepe Rojo Pepe Rojo Pepe Rojo Pepe Rojo Pepe Rojo jajajaajajaj",
            textAlign = TextAlign.Center,
            modifier = Modifier
                .fillMaxWidth()
                .background(Color.Red),
            maxLines = 1, overflow = TextOverflow.Ellipsis
        );
    }
}