package com.bripot.myfirstcomposeapp.components

import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.material3.Icon
import androidx.compose.material3.Text
import androidx.compose.material3.TopAppBar
import androidx.compose.material3.TopAppBarDefaults
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.painterResource
import com.bripot.myfirstcomposeapp.R

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun MyTopAppBar(modifier: Modifier = Modifier) {
    TopAppBar(
        title = { Text("My app") },
        navigationIcon = {
            Icon(painter = painterResource(R.drawable.ic_personita), contentDescription = "")
        },
        actions = {
            Icon(painter = painterResource(R.drawable.ic_personita), contentDescription = "")
            Icon(
                painter = painterResource(R.drawable.ic_personita),
                contentDescription = "",
                tint = Color.Red
            )
            Icon(painter = painterResource(R.drawable.ic_personita), contentDescription = "")
        },
        colors = TopAppBarDefaults.topAppBarColors(
            containerColor = Color.Gray,
            titleContentColor = Color.White,
            navigationIconContentColor = Color.Magenta,
            actionIconContentColor = Color.Yellow,
            scrolledContainerColor = Color.Black
        )
    )
}