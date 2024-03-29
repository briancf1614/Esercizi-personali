package com.example.firstlogin;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class LoginActivity extends AppCompatActivity {

    private EditText etUsername,etPassword;
    private Button btnLogin;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        initComponents();
        initListeners();

    }

    private void initListeners() {
        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(!etUsername.getText().toString().isEmpty() && !etPassword.getText().toString().isEmpty()) {

                    navigateToResult();
                }
            }
        });
    }

    private void navigateToResult() {
        Intent intent = new Intent(this, FirstPageActivity.class);
        intent.putExtra("Login",etUsername.getText().toString());
        intent.putExtra("Password",etPassword.getText().toString());
        startActivity(intent);
    }
    private void initComponents() {
        etUsername = findViewById(R.id.etUsername);
        etPassword = findViewById(R.id.etPassword);
        btnLogin = findViewById(R.id.btnLogin);
    }

}