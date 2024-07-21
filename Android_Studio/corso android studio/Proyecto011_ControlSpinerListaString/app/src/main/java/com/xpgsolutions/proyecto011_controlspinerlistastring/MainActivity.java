package com.xpgsolutions.proyecto011_controlspinerlistastring;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    private Spinner spinner1;
    private TextView tv3;
    private EditText et1,et2;
    private String[] operaciones = {"Sumar","Restar","Multiplicar","Dividir"};
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        et1 = findViewById(R.id.et1);
        et2 = findViewById(R.id.et2);
        tv3 = findViewById(R.id.tv3);
        spinner1 = findViewById(R.id.spinner1);

        ArrayAdapter<String> adaptador1= new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, operaciones);
        spinner1.setAdapter(adaptador1);
    }

    public void operar(View v){
        int valor1 = Integer.parseInt(et1.getText().toString());
        int valor2 = Integer.parseInt(et2.getText().toString());
        String operacion = spinner1.getSelectedItem().toString();

        if(operacion=="Sumar")
            tv3.setText("La suma es: "+(valor1+valor2));
        else if(operacion=="Restar")
            tv3.setText("La resta es: "+(valor1-valor2));
        else if(operacion=="Multiplicar")
            tv3.setText("La multiplicación es: "+(valor1*valor2));
        else if(operacion=="Dividir")
            tv3.setText("La división es: "+(valor1/valor2));
    }
}