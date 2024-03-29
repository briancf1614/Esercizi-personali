package com.xpgsolutions.testspinnerlistas;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    private EditText et1, et2;
    private TextView tv3;
    private Spinner spinner;
    private String[] operaciones = {"Sumar","Restar","Multiplicar","Dividir"};
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        et1 = findViewById(R.id.et1);
        et2 = findViewById(R.id.et2);
        tv3 = findViewById(R.id.tv3);
        spinner = findViewById(R.id.spinner);

        ArrayAdapter<String> adaptador1 = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item,operaciones);
        spinner.setAdapter(adaptador1);
    }

    public void operar(View view ){
        int valore1 = Integer.parseInt(et1.getText().toString());
        int valore2 = Integer.parseInt(et2.getText().toString());
        String operacion = spinner.getSelectedItem().toString();
        if(operacion.equals("Sumar")){
            tv3.setText("La respuesta es: "+(valore1+valore2));
        if (operacion.equals("Restar"))
            tv3.setText("La respuesta es: "+(valore1-valore2));
        if(operacion.equals("Dividir"))
            tv3.setText("La respuesta es: "+(valore1/valore2));
        if(operacion.equals("Multiplicar"))
            tv3.setText("La respuesta es: "+(valore1*valore2));

        }

    }

}