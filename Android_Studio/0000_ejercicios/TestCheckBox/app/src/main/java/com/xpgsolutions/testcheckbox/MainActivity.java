package com.xpgsolutions.testcheckbox;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    private EditText et1,et2;
    private TextView tv1, tv2;
    private CheckBox check1, check2;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        et1 = findViewById(R.id.et1);
        et2 = findViewById(R.id.et2);
        tv1 = findViewById(R.id.tv1);
        tv2 = findViewById(R.id.tv2);
        check1 = findViewById(R.id.check1);
        check2 = findViewById(R.id.check2);
    }
    public void operacion(View view){

        int numero1 = Integer.parseInt(et1.getText().toString());
        int numero2 = Integer.parseInt(et2.getText().toString());
        String respuesta = "";
        if(check1.isChecked())
            respuesta+="La suma es: " + (numero1+numero2) + "\n";
        if(check2.isChecked())
            respuesta += "La resta es: "+ (numero1-numero2);
        tv2.setText(respuesta);
    }
}