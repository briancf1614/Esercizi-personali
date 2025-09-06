package com.bripot.myfirstcomposeapp.components

import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.PaddingValues
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.material3.Button
import androidx.compose.material3.DropdownMenu
import androidx.compose.material3.DropdownMenuItem
import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.material3.ExposedDropdownMenuBox
import androidx.compose.material3.Icon
import androidx.compose.material3.MenuAnchorType
import androidx.compose.material3.MenuItemColors
import androidx.compose.material3.Text
import androidx.compose.material3.TextField
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.unit.DpOffset
import androidx.compose.ui.unit.dp
import androidx.compose.ui.window.PopupProperties
import com.bripot.myfirstcomposeapp.R

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun MyExposedDropdownMenu(modifier: Modifier = Modifier) {
    var expanded by remember { mutableStateOf(false) }
    var selection by remember { mutableStateOf("") }

    ExposedDropdownMenuBox(
        modifier = modifier,
        expanded = expanded,
        onExpandedChange = { expanded = !expanded }) {
        TextField(
            readOnly = true,
            value = selection,
            onValueChange = {},
            label = { Text("Idioma") },
            modifier = Modifier
                .menuAnchor(type = MenuAnchorType.PrimaryNotEditable, true)
                .fillMaxWidth()
        )
        DropdownMenu(expanded = expanded, onDismissRequest = { expanded = false }) {
            DropdownMenuItem(
                text = { Text("Opcion 1") },
                onClick = { selection = "Opcion 1"; expanded = false })
            DropdownMenuItem(
                text = { Text("Opcion 2") },
                onClick = { selection = "Opcion 2"; expanded = false })
            DropdownMenuItem(
                text = { Text("Opcion 3") },
                onClick = { selection = "Opcion 3"; expanded = false })
            DropdownMenuItem(
                text = { Text("Opcion 4") },
                onClick = { selection = "Opcion 4"; expanded = false })
            DropdownMenuItem(
                text = { Text("Opcion 5") },
                onClick = { selection = "Opcion 5"; expanded = false })

        }
    }
}

@Composable
fun MyDropDownMenu(modifier: Modifier = Modifier) {
    var expanded by remember { mutableStateOf(false) }
    Box(modifier = modifier) {
        Button(onClick = { expanded = true }) {
            Text("Ver opciones")
        }

        DropdownMenu(
            expanded = expanded,
            onDismissRequest = { expanded = false },
            offset = DpOffset(16.dp, 16.dp),
            properties = PopupProperties(
                focusable = true,
                dismissOnClickOutside = false,
                dismissOnBackPress = false,
                clippingEnabled = false
            )
        ) {
            DropdownMenuItem(text = { Text("Opcion 1") }, onClick = { expanded = false })
            DropdownMenuItem(text = { Text("Opcion 2") }, onClick = { expanded = false })
            DropdownMenuItem(text = { Text("Opcion 3") }, onClick = { expanded = false })
            DropdownMenuItem(
                text = { TextField("Opcion 4", onValueChange = {}) },
                onClick = { expanded = false })
            DropdownMenuItem(text = { Text("Opcion 5") }, onClick = { expanded = false })
        }
    }
}

@Composable
fun MyDropDownItem(modifier: Modifier = Modifier) {
    Column(modifier = modifier) {
        DropdownMenuItem(
            modifier = Modifier.fillMaxWidth(),
            text = {
                Text("Ejemplo 1")
            },
            onClick = {},
            leadingIcon = {
                Icon(
                    painter = painterResource(R.drawable.ic_personita),
                    contentDescription = ""
                )
            },
            trailingIcon = {
                Icon(
                    painter = painterResource(R.drawable.ic_launcher_foreground),
                    contentDescription = ""
                )
            },
            enabled = true,
            contentPadding = PaddingValues(16.dp),
            colors = MenuItemColors(
                textColor = Color.Blue,
                leadingIconColor = Color.Blue,
                trailingIconColor = Color.Blue,
                disabledTextColor = Color.Blue,
                disabledLeadingIconColor = Color.Blue,
                disabledTrailingIconColor = Color.Blue
            )
        )
    }
}