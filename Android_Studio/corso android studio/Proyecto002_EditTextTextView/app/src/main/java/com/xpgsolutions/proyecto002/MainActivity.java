package com.xpgsolutions.proyecto002;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    private EditText et1, et2;
    private TextView tv1;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        et1= findViewById(R.id.et1);
        et2= findViewById(R.id.et2);
        tv1 = findViewById(R.id.tv1);
    }

    public void sumar(View view) {
        String valor1= et1.getText().toString();
        String valor2= et2.getText().toString();

        int valore1 = Integer.parseInt(valor1);
        int valore2 = Integer.parseInt(valor2);
        int suma = valore1 + valore2;
        tv1.setText("La suma es: " + suma);
    }
}