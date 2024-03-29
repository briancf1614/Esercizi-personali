package com.xpgsolutions.testescojebandera;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    private ImageButton ib1,ib2,ib3,ib4,ib5,ib6,ib7,ib8;
    private String pais;
    private TextView tv1;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        tv1 = findViewById(R.id.tv1);
        int nro = (int)(Math.random()*8);
        switch(nro){
            case 0: pais="Argentina";break;
            case 1: pais="Bolivia";break;
            case 2: pais="Brasil";break;
            case 3: pais="Chile";break;
            case 4: pais="Colombia";break;
            case 5: pais="Peru";break;
            case 6: pais="Uruguay";break;
            case 7: pais="Venezuela";break;
        }
        tv1.setText("Dime la bandera de..." + pais);
    }

    public void presionar(View view){
        ImageButton b = (ImageButton)view;
        if(b.getTag().toString().equals(pais))
            Toast.makeText(this, "Bravo " + b.getTag() + " es el pais correcto", Toast.LENGTH_SHORT).show();
        else
            Toast.makeText(this, "Mi dispiace " + b.getTag() + " no es el pais correcto", Toast.LENGTH_SHORT).show();
    }
}