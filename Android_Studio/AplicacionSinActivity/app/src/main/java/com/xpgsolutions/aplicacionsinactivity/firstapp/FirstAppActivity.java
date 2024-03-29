package com.xpgsolutions.aplicacionsinactivity.firstapp;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.AppCompatButton;
import androidx.appcompat.widget.AppCompatEditText;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Toast;

import com.xpgsolutions.aplicacionsinactivity.R;

public class FirstAppActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_first_app);
        AppCompatButton btnStart = findViewById(R.id.btnStart);
        AppCompatEditText et1 = findViewById(R.id.etNome);
        btnStart.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(!et1.getText().toString().isEmpty()){
                    Intent intent = new Intent(FirstAppActivity.this,ResultActivity.class);
                    intent.putExtra("Extra_Name",et1.getText().toString());
                    startActivity(intent);
                }
            }
        });

    }

}