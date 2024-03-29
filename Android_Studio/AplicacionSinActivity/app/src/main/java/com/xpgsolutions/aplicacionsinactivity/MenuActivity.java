package com.xpgsolutions.aplicacionsinactivity;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.AppCompatButton;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.xpgsolutions.aplicacionsinactivity.firstapp.FirstAppActivity;
import com.xpgsolutions.aplicacionsinactivity.imccalculaator.IMCCalculatorActivity;
import com.xpgsolutions.aplicacionsinactivity.todoapp.TodoActivity;

public class MenuActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);
        AppCompatButton btn1 = findViewById(R.id.btnSaludApp);
        AppCompatButton btn2 = findViewById(R.id.btnIMCApp);
        AppCompatButton btn3 = findViewById(R.id.btnTODO);
        btn1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                navigateToSaludApp();
            }
        });

        btn2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                navigateToIMCApp();
            }
        });

        btn3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                navigateTODOApp();
            }
        });

    }

    private void navigateTODOApp() {
        Intent intent = new Intent(this, TodoActivity.class);
        startActivity(intent);

    }

    private void navigateToIMCApp() {
        Intent intent = new Intent(this, IMCCalculatorActivity.class);
        startActivity(intent);
    }

    public void navigateToSaludApp(){
        Intent intent = new Intent(this, FirstAppActivity.class);
        startActivity(intent);
    }
}