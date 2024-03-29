package com.xpgsolutions.proyecto003;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {
    private EditText et1,et2;
    private RadioButton r1,r2;
    private TextView tv1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        et1=findViewById(R.id.et1);
        et2=findViewById(R.id.et2);
        r1=findViewById(R.id.rb1);
        r2=findViewById(R.id.rb2);
        tv1=findViewById(R.id.tv1);
    }

    public void operar(View view){
        int s1 = Integer.parseInt(et1.getText().toString());
        int s2 = Integer.parseInt(et2.getText().toString());

        if (r1.isChecked()) {
            tv1.setText("LA suma es: "+(s1+s2));
        } else if (r2.isChecked()) {
            tv1.setText("La resta es: "+(s1-s2));
        }

    }
}