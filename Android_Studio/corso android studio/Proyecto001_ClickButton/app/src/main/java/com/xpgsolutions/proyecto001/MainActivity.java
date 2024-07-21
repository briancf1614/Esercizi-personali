package com.xpgsolutions.proyecto001;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void presioname(View view) {
        Toast.makeText(this, "Presionaste el botón, Bravo !!", Toast.LENGTH_SHORT).show();
    }

    public void presion2(View view) {
        Toast.makeText(this, "Presionaste el botón 2, Bravo !!", Toast.LENGTH_SHORT).show();
    }
}