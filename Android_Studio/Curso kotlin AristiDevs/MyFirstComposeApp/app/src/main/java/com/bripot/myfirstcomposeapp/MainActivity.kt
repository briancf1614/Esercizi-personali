package com.bripot.myfirstcomposeapp

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Checkbox
import androidx.compose.material3.Scaffold
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.tooling.preview.Preview
import com.bripot.myfirstcomposeapp.components.MyButon
import com.bripot.myfirstcomposeapp.components.MyCheckbox
import com.bripot.myfirstcomposeapp.components.MyNetworkImage
import com.bripot.myfirstcomposeapp.components.MyRadioButton
import com.bripot.myfirstcomposeapp.components.MyRadioButtonList
import com.bripot.myfirstcomposeapp.components.MySlider
import com.bripot.myfirstcomposeapp.components.MySliderAdvance
import com.bripot.myfirstcomposeapp.components.MySwitch
import com.bripot.myfirstcomposeapp.components.MyText
import com.bripot.myfirstcomposeapp.components.MyTextField
import com.bripot.myfirstcomposeapp.components.MyTextFieldParent
import com.bripot.myfirstcomposeapp.components.ParentCheckBoxes
import com.bripot.myfirstcomposeapp.components.Progress
import com.bripot.myfirstcomposeapp.components.ProgressAdvance
import com.bripot.myfirstcomposeapp.components.ProgressAnimation
import com.bripot.myfirstcomposeapp.components.TriStateCheckBox
import com.bripot.myfirstcomposeapp.login.Greeting
import com.bripot.myfirstcomposeapp.ui.theme.MyFirstComposeAppTheme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            MyFirstComposeAppTheme {
                Scaffold(modifier = Modifier.fillMaxSize()) { innerPadding ->
                    MySliderAdvance(Modifier.padding(innerPadding))
                }
            }
        }
    }
}


@Preview(showBackground = true)
@Composable
fun GreetingPreview() {
    MyFirstComposeAppTheme {
        Greeting("Android")
    }
}