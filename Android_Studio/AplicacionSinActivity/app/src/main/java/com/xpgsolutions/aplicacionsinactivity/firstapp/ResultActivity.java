package com.xpgsolutions.aplicacionsinactivity.firstapp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.xpgsolutions.aplicacionsinactivity.R;

public class ResultActivity extends AppCompatActivity {



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_result);
        TextView tvresult = findViewById(R.id.tvresult);
        String name = getIntent().getStringExtra("Extra_Name");
        tvresult.setText("Hola " + name);
        tvresult.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Toast.makeText(ResultActivity.this, "Hola perros", Toast.LENGTH_SHORT).show();
            }
        });
    }
}
