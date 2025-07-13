package com.bripot.myfirstcomposeapp.components

import android.util.Log
import androidx.compose.foundation.Image
import androidx.compose.foundation.border
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Icon
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.graphics.Brush
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.layout.ContentScale
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import coil3.compose.AsyncImage
import com.bripot.myfirstcomposeapp.R

@Preview
@Composable
fun MyImage() {
    Image(
        painter = painterResource(R.drawable.img_1),
        contentDescription = "Avatar image preview",
        modifier = Modifier
            .size(300.dp)
            .clip(RoundedCornerShape(bottomEnd = 60.dp, topStart = 90.dp))
            .border(
                width = 5.dp,
                shape = RoundedCornerShape(bottomEnd = 60.dp, topStart = 90.dp),
//                Interesante perche si puo fare quel brush ch emischia i colori e e non solo nelle imagini ma anche in altri componente
                brush = Brush.linearGradient(colors = listOf(Color.Red, Color.Blue, Color.Yellow))
            ),
        contentScale = ContentScale.FillBounds
    )
}

@Composable
fun MyNetworkImage(modifier: Modifier) {
    AsyncImage(
        model = "https://docs.github.com/assets/images/search/copilot-action.png",
        contentDescription = "Image from network",
        modifier = modifier.fillMaxSize(),
        onError = { Log.e("AsyncImage", "Error loading image ${it.result.throwable.message}") }
    )
}

@Preview
@Composable
fun MyIcon(modifier: Modifier = Modifier) {
    Icon(
        painter = painterResource(R.drawable.ic_personita),
        contentDescription = "Icono",
        modifier = modifier.size(300.dp),
        tint = Color.Red
    )
}