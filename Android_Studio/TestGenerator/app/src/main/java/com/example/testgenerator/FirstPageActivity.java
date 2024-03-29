package com.example.testgenerator;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.honeywell.aidc.AidcManager;
import com.honeywell.aidc.BarcodeReader;
import com.honeywell.aidc.InvalidScannerNameException;

public class FirstPageActivity extends AppCompatActivity {
    private static BarcodeReader barcodeReader;
    private AidcManager manager;
    private EditText etUsername,etPassword;
    private Button btnLogin;

//    gli creo un getter per prendere il barcodeReader
    public static BarcodeReader getBarcodeReader() {
        return barcodeReader;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_first_page);
        initComponents();
        initListeners();
    }


    private void initComponents() {
        etUsername = findViewById(R.id.etUsername);
        etPassword = findViewById(R.id.etPassword);
        btnLogin = findViewById(R.id.btnLogin);

///////////////////////////////////////////////////////////
//        qui creo listanza del singleton del AidcMAnager
//////////////////////////////////////////////////////////
        AidcManager.create(this, new AidcManager.CreatedCallback() {
            @Override
            public void onCreated(AidcManager aidcManager) {
                manager = aidcManager;
                try {
                    barcodeReader = manager.createBarcodeReader();
                } catch (InvalidScannerNameException e) {
                    e.printStackTrace();
                }
            }
        });

    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        if (barcodeReader != null){
            barcodeReader.close();
            barcodeReader = null;
        }
        if (manager != null){
            manager.close();
        }
    }

    private void initListeners() {
        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(FirstPageActivity.this, GeneratorActivity.class);
                startActivity(intent);
            }
        });
    }
}