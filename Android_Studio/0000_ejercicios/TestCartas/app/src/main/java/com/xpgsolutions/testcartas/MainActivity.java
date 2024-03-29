package com.xpgsolutions.testcartas;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;

public class MainActivity extends AppCompatActivity {

    private ImageButton ib1, ib2, ib3;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ib1 = findViewById(R.id.ib1);
        ib2 = findViewById(R.id.ib2);
        ib3 = findViewById(R.id.ib3);
    }


    public void presionar(View view){
        ImageButton b = (ImageButton)view;

        b.setVisibility(View.INVISIBLE);
    }

    public void reset(View view){
        //recreate();
        ib1.setVisibility(View.VISIBLE);
        ib2.setVisibility(View.VISIBLE);
        ib3.setVisibility(View.VISIBLE);
    }
}