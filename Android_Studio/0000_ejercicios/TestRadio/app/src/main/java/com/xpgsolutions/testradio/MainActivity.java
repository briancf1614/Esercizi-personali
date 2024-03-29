package com.xpgsolutions.testradio;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    private TextView tv1;
    private EditText et1,et2;
    private RadioButton rb1, rb2;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        tv1 = findViewById(R.id.tv1);
        et1 = findViewById(R.id.et1);
        et2 = findViewById(R.id.et2);
        rb1 = findViewById(R.id.rb1);
        rb2 = findViewById(R.id.rb2);
    }

    public void operar(View view){
        int numero1 = Integer.parseInt(et1.getText().toString());
        int numero2 = Integer.parseInt(et2.getText().toString());
        if(rb1.isChecked())
            tv1.setText("La suma es: "+ (numero1+numero2));
        if(rb2.isChecked())
            tv1.setText("La resta es:"+ (numero1-numero2));
    }
}