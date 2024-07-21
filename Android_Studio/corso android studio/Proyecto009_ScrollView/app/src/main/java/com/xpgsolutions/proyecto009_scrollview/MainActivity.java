package com.xpgsolutions.proyecto009_scrollview;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    private TextView tv1;
    private String pais;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        tv1=findViewById(R.id.tv1);
        int nro = (int)(Math.random()*8);
        switch(nro){
            case 0: pais="Argentina";break;
            case 1: pais="Bolivia";break;
            case 2: pais="Brasil";break;
            case 3: pais="Chile";break;
            case 4: pais="Colombia";break;
            case 5: pais="Perú";break;
            case 6: pais="Uruguay";break;
            case 7: pais="Venezuela";break;
        }
        tv1.setText("Cual es la bandera de " + pais);
    }

    public void presion(View view){
        ImageButton b =(ImageButton)view;
        if(b.getTag().toString().equals(pais))
            Toast.makeText(this, "Felicidades, has seleccionado la bandera correcta", Toast.LENGTH_SHORT).show();
        else
            Toast.makeText(this, "Muy mal... te has equivocado :(", Toast.LENGTH_SHORT).show();
    }
}