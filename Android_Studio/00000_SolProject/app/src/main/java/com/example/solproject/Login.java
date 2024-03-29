package com.example.solproject;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;

import android.content.Context;
import android.content.pm.PackageManager;
import android.os.Build;
import android.os.Bundle;
import android.telephony.TelephonyManager;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.Manifest;
import android.widget.Toast;

public class Login extends AppCompatActivity {
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
            public void onClick(View view) {
//                Ricordarsi di importare manualmente android.Manifest;
                if(ContextCompat.checkSelfPermission(Login.this,Manifest.permission.READ_PHONE_STATE)!= PackageManager.PERMISSION_GRANTED){
                    ActivityCompat.requestPermissions(Login.this,new String[]{Manifest.permission.READ_PHONE_STATE},1);
                }else {
                    getSimInfo();
                }
            }
        });
    }

    private void getSimInfo() {
        final  TelephonyManager telephonyManager = (TelephonyManager) getSystemService(Context.TELEPHONY_SERVICE);
        String spn = telephonyManager.getSimOperatorName();
//        String iccid = telephonyManager.getSimSerialNumber();
        int simState = telephonyManager.getSimState();
//        String imsi = telephonyManager.getSubscriberId();
        Toast.makeText(this, "SPN: " + spn + "\nICCID: No se puede papu"  + "\nSIM State: " + simState + "\nIMSI: Tampoco se puede papu" , Toast.LENGTH_LONG).show();

    }

    private void initComponents() {
        etUsername = findViewById(R.id.etUsername);
        etPassword = findViewById(R.id.etPassword);
        btnLogin = findViewById(R.id.btnLogin);
    }
}