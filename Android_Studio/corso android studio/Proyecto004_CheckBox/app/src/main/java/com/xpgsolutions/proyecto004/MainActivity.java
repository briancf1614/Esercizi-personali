package com.xpgsolutions.proyecto004;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.CheckBox;
import android.widget.Checkable;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    private EditText et1, et2;
    private CheckBox check1, check2;
    private TextView tv1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        et1= findViewById(R.id.et1);
        et2= findViewById(R.id.et2);
        check1= findViewById(R.id.check1);
        check2= findViewById(R.id.check2);
        tv1= findViewById(R.id.tv1);
    }
    public void operar(View view){
        int nro1= Integer.parseInt((et1.getText().toString()));
        int nro2=Integer.parseInt((et2.getText().toString()));
        String resu="";

        if (check1.isChecked()) {
            int suma =nro1+nro2;
            resu+="La suma es "+ suma+ " ";
        }
        if (check2.isChecked()){
            int resta = nro1-nro2;
            resu+="La resta es "+ resta+ " ";
        }

        tv1.setText(resu);

    }
}