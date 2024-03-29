package com.xpgsolutions.proyecto010_framelayout;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void presion(View view){
        ImageButton ib = (ImageButton)view;
        ib.setVisibility(View.INVISIBLE);
    }

    public void mostrarCartas(View view){
        ImageButton ib1 = findViewById(R.id.ib1);
        ImageButton ib2 = findViewById(R.id.ib2);
        ImageButton ib3 = findViewById(R.id.ib3);

        ib1.setVisibility(View.VISIBLE);
        ib2.setVisibility(View.VISIBLE);
        ib3.setVisibility(View.VISIBLE);
    }
}